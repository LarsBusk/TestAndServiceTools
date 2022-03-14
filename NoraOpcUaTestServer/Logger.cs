using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace NoraOpcUaTestServer
{
  public class Logger
  {
    private readonly string fileName;
    public Logger(string fileName)
    {
      this.fileName = Path.Combine(Properties.Settings.Default.LogFolder, fileName);

      if (!File.Exists(fileName))
      {
        File.AppendAllText(fileName, "Start Logging");
      }
    }

    public void LogInfo(string message)
    {
      Log(message, "INFO");
    }

    public void LogError(string message)
    {
      Log(message, "ERROR");
    }

    private void Log(string message, string logLevel)
    {
      DateTime logTime = DateTime.Now;
      File.AppendAllText(fileName, $"{logTime} [{logLevel}] {message}\n");
    }

    private long GetSize(string fileName)
    {
      FileInfo fileInfo = new FileInfo(fileName);
      long size = fileInfo.Length;
      return size;
    }
  }
}
