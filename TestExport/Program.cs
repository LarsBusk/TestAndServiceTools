using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestExport
{
  class Program
  {
    static string fileName = "DeletedFiles.csv";

    static void Main(string[] args)
    {
        FileSystemWatcher watcher = new FileSystemWatcher(Properties.Settings.Default.Folder);

        watcher.EnableRaisingEvents = true;
        watcher.Created += LogEvents;
        watcher.Changed += LogEvents;
        watcher.Deleted += LogEvents;
        watcher.Renamed += LogEvents;

        File.AppendAllText(fileName, "DeletedTime;Filename;SampleNumber;NumberOfColumns\n");

        Console.Read();
    }

    private static void Watcher_Created(object sender, FileSystemEventArgs e)
    {
      string sampleNumber = "NoNumber";
      Thread.Sleep(1000);
      string[] lines = File.ReadAllLines(e.FullPath);
      int noOfCols = 0;

      if (lines.Length>1)
      {
        string headerLine = lines[0];
        var resultLine = lines[1];
        sampleNumber = resultLine.Split(',')[4];
        noOfCols = headerLine.Split(',').Length;
      }

      string line = $"{DateTime.Now};{e.Name};{sampleNumber};{noOfCols}\n";
      File.Delete(e.FullPath);
      File.AppendAllText(fileName, line);
    }

    private static void LogEvents(object sender, FileSystemEventArgs e)
    {
        File.AppendAllText("Event.log",  $"{DateTime.Now.ToString("O")} {e.ChangeType} {e.Name}\n");
    }
  }
}
