﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MstEmbeddedLogger
{
  class Program
  {
    private static Process fssProcess = new Process();
    static void Main(string[] args)
    {
      while (true)
      {
        StopFossServiceScan();
        Thread.Sleep(TimeSpan.FromMinutes(1));
        StartFossServiceScanLogging();
        Thread.Sleep(TimeSpan.FromHours(4));
        DeleteOldFiles();
      }
    }

    static void StartFossServiceScanLogging()
    {
      ProcessStartInfo info = new ProcessStartInfo();
      info.FileName = "Foss Service Scan.exe";
      info.Arguments = "saveTrace Service4u";

      fssProcess.StartInfo = info;
      fssProcess.Start();
    }

    static void StopFossServiceScan()
    {
      fssProcess = Process.GetProcessesByName("Foss Service Scan").FirstOrDefault();

      if (fssProcess != null)
      {
        fssProcess.Kill();
      }
    }

    static void DeleteOldFiles()
    {
      var files = Directory.GetFiles("\\AutoTrace");

      foreach (var file in files)
      {
        if (new FileInfo(file).LastWriteTime < DateTime.Now - TimeSpan.FromDays(7))
        {
          File.Delete(file);
        }
      }
    }
  }
}
