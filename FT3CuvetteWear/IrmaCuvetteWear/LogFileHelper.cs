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
      var files = LogFiles(folder);
      var lines = ResultLines(files);
      int progress = 0;

      List<WearResult> wearResults = new List<WearResult>();
      Stopwatch watch = new Stopwatch();
      watch.Start();
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

        if (i*100/numOflines > progress + 1)
        {
          progress++;
          ProgressEvent.Invoke(this, new ProgressEventArgs(progress, "Creating wearlog.csv"));
        }
      }

      wearResults.Sort();
      watch.Stop();
      SaveToCsv(wearResults);
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
      return Directory.GetFiles(logsFolder).Where(f => f.Contains("IrmaDairyServerHost.txt"));
    }

    private DateTime ResultDateTime(string resultLine)
    {
      DateTimeFormatInfo dtInfo = new DateTimeFormatInfo();
      dtInfo.FullDateTimePattern = "yyyy-MM-dd hh:mm:ss,fff";
      //dtInfo.LongTimePattern = "hh:mm:ss,fff";

      string[] lineParts = resultLine.Split(' ');
      string dtString = $"{lineParts[0]} {lineParts[1]}";
      DateTime resultDateTime = DateTime.ParseExact(dtString, "yyyy-MM-dd HH:mm:ss,fff", dtInfo);

      return resultDateTime;
    }

    private List<string> ResultLines(IEnumerable<string> logFiles)
    {
      ProgressEvent.Invoke(this, new ProgressEventArgs(0, "Reading logs"));
      List<string> resultLines = new List<string>();
      string[] lookFors =
      {
        "DarkSignalCalculator", "CleaningLiquidCalculator", "LimestoneCalculator", "MilkstoneCalculator",
        "ProteinCalculator", "MisalignmentCalculator", "Updating the SBRef average.",
        "AbsoluteMoistureLevelCalculator", "CleanConductivityCheck", "ZeroConductivityCheck"
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
  }
}
