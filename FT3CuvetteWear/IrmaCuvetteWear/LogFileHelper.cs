using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaCuvetteWear
{
  public class LogFileHelper
  {
    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

    public event ProgressEventHandler ProgressEvent;

    public void CreateCsvFile(string folder)
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();
      var files = LogFiles(folder).ToArray();
      List<WearResult> wearResults = new List<WearResult>();
      int progress = 0;

      for (int i = 0; i < files.Length; i++)
      {
        progress = 100 * i / files.Length;
        string fileName = files[i].Substring(files[i].LastIndexOf("\\") + 1);
        ProgressEvent.Invoke(this, new ProgressEventArgs(progress, $"Reading from {fileName}"));
        var lines = ResultLines(files[i]);
        wearResults.AddRange(GetWearResults(lines));
      }

      wearResults.Sort();
      SaveToCsv(wearResults);

      watch.Stop();
    }

    private void SaveToCsv(List<WearResult> results)
    {
      List<string> csvLines = new List<string>();
      csvLines.Add(WearResult.FileHeader);
      csvLines.AddRange(results.Select(r => r.ToString()));
      File.WriteAllLines("WearLog.csv", csvLines);
      ProgressEvent.Invoke(this, new ProgressEventArgs(0, "Ready"));
    }

    private IEnumerable<string> LogFiles(string logsFolder)
    {
      return Directory.GetFiles(logsFolder).Where(f => f.Contains("IrmaDairyServerHost.txt") | f.Contains("IrmaServerHost.txt"));
    }

    private DateTime ResultDateTime(string resultLine)
    {
      DateTimeFormatInfo dtInfo = new DateTimeFormatInfo();
      dtInfo.FullDateTimePattern = "yyyy-MM-dd hh:mm:ss,fff";

      string[] lineParts = resultLine.Split(' ');
      string dtString = $"{lineParts[0]} {lineParts[1]}";
      DateTime resultDateTime = DateTime.ParseExact(dtString, "yyyy-MM-dd HH:mm:ss,fff", dtInfo);

      return resultDateTime;
    }

    private List<WearResult> GetWearResults(List<string> lines)
    {
      int progress = 0;
      List<WearResult> wearResults = new List<WearResult>();

      int numOflines = lines.Count;
      for (int i = 0; i < numOflines; i++)
      {
        if (lines[i].Contains("Updating the SBRef average."))
        {
          var res = new WearResult(ResultDateTime(lines[i]));

          res.ResultLines.AddRange(lines.Where(l =>
            Math.Abs((res.ResultDateTime - ResultDateTime(l)).TotalMilliseconds) < 10000));

          wearResults.Add(res);
        }

        if (i * 100 / numOflines > progress + 1)
        {
          progress++;
          //ProgressEvent.Invoke(this, new ProgressEventArgs(progress, "Creating wearlog.csv"));
        }
      }

      return wearResults;
    }

    private List<string> ResultLines(IEnumerable<string> logFiles)
    {
      ProgressEvent.Invoke(this, new ProgressEventArgs(0, "Reading logs"));
      List<string> resultLines = new List<string>();
      string[] lookFors =
      {
        "DarkSignalCalculator", "CleaningLiquidCalculator", "LimestoneCalculator", "MilkstoneCalculator",
        "ProteinCalculator", "MisalignmentCalculator", "Updating the SBRef average.",
        "AbsoluteMoistureLevelCalculator", "CleanConductivityCheck", "ZeroConductivityCheck", "ConductivityGhCheck"
      };

      foreach (var logFile in logFiles)
      {
        var lines = File.ReadAllLines(logFile).Where(li => li.Contains("[Result]"));

        foreach (var line in lines)
        {
          if (lookFors.Any(l => line.Contains(l)))
          {
            resultLines.Add(line);
          }
        }
      }

      return resultLines;
    }

    private List<string> ResultLines(string logFile)
    {
      //ProgressEvent.Invoke(this, new ProgressEventArgs(0, $"Reading logfile."));
      List<string> resultLines = new List<string>();
      string[] lookFors =
      {
        "DarkSignalCalculator", "CleaningLiquidCalculator", "LimestoneCalculator", "MilkstoneCalculator",
        "ProteinCalculator", "MisalignmentCalculator", "Updating the SBRef average.",
        "AbsoluteMoistureLevelCalculator", "CleanConductivityCheck", "ZeroConductivityCheck", "ConductivityGhCheck"
      };

      var lines = File.ReadAllLines(logFile).Where(li => li.Contains("[Result]"));

      foreach (var line in lines)
      {
        if (lookFors.Any(l => line.Contains(l)))
        {
          resultLines.Add(line);
        }
      }

      return resultLines;
    }
  }
}
