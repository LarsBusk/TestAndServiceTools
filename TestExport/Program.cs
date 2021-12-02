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
      watcher.Created += Watcher_Created;

      File.AppendAllText(fileName, "DeletedTime;Filename;SampleNumber\n");

      Console.Read();
    }

    private static void Watcher_Created(object sender, FileSystemEventArgs e)
    {
      string sampleNumber = "NoNumber";
      Thread.Sleep(1000);
      string[] lines = File.ReadAllLines(e.FullPath);

      if (lines.Length>1)
      {
        string resLine = lines[1];
        sampleNumber = resLine.Split(',')[2];
      }

      string line = $"{DateTime.Now};{e.Name};{sampleNumber}\n";
      File.Delete(e.FullPath);
      File.AppendAllText(fileName, line);
    }
  }
}
