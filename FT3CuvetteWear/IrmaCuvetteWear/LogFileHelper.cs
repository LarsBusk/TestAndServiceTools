using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace IrmaCuvetteWear
{
    public class LogFileHelper
    {
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

        public event ProgressEventHandler ProgressEvent;

        public void CreateCsvFile(string folder)
        {
            var files = LogFiles(folder).ToArray();
            var wearResults = new List<WearResult>();

            for (var i = 0; i < files.Length; i++)
            {
                var progress = 100 * i / files.Length;
                var fileName = files[i].Substring(files[i].LastIndexOf("\\") + 1);
                ProgressEvent.Invoke(this, new ProgressEventArgs(progress, $"Reading from {fileName}"));
                var lines = ResultLines(files[i]);
                wearResults.AddRange(GetWearResults(lines));
            }

            wearResults.Sort();
            SaveToCsv(wearResults);
        }

        private void SaveToCsv(List<WearResult> results)
        {
            var csvLines = new List<string> { WearResult.FileHeader };
            csvLines.AddRange(results.Select(r => r.ToString()));
            File.WriteAllLines("WearLog.csv", csvLines);
            ProgressEvent.Invoke(this, new ProgressEventArgs(0, "Ready"));
        }

        private IEnumerable<string> LogFiles(string logsFolder)
        {
            return Directory.GetFiles(logsFolder)
                .Where(f => f.Contains("IrmaDairyServerHost.txt") | f.Contains("IrmaServerHost.txt"));
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
            var wearResults = new List<WearResult>();

            foreach (var line in lines)
            {
                if (line.Contains("Updating the SBRef average."))
                {
                    var res = new WearResult(ResultDateTime(line));

                    res.ResultLines.AddRange(lines.Where(l =>
                        Math.Abs((res.ResultDateTime - ResultDateTime(l)).TotalMilliseconds) < 10000));

                    wearResults.Add(res);
                }
            }

            return wearResults;
        }

        private List<string> ResultLines(string logFile)
        {
            var lines = new List<string>();
            
            string[] lookFors =
            {
                "DarkSignalCalculator", "CleaningLiquidCalculator", "LimestoneCalculator", "MilkstoneCalculator",
                "ProteinCalculator", "MisalignmentCalculator", "Updating the SBRef average.",
                "AbsoluteMoistureLevelCalculator", "CleanConductivityCheck", "ZeroConductivityCheck",
                "ConductivityGhCheck"
            };

            using (var fileStream = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var textReader = new StreamReader(fileStream))
            {
                var content = textReader.ReadToEnd();
                lines = content.Split(
                new []{ "\r\n" }, StringSplitOptions.None).ToList();
            }

            lines = lines.Where(li => li.Contains("[Result]")).ToList();

            return lines.Where(l => lookFors.Any(lo => l.Contains(lo))).ToList();
        }
    }
}
