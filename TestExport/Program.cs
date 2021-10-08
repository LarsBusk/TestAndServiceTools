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
      FileSystemWatcher watcher = new FileSystemWatcher("C:\\Export");

      watcher.EnableRaisingEvents = true;
      watcher.Created += Watcher_Created;

      File.AppendAllText(fileName, "DeletedTime;Filename\n");

      Console.Read();
    }

    private static void Watcher_Created(object sender, FileSystemEventArgs e)
    {
      Thread.Sleep(1000);
      string line = $"{DateTime.Now};{e.Name}\n";
      File.Delete(e.FullPath);
      File.AppendAllText(fileName, line);
    }
  }
}
