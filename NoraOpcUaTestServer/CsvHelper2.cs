using System;
using System.IO;

namespace NoraOpcUaTestServer
{
  public class CsvHelper2
  {
    private readonly string fileName;
    public CsvHelper2(string fileName)
    {
      this.fileName = fileName;

      if (!File.Exists(fileName))
      {
        File.AppendAllText(fileName, "Start Logging");
      }
    }

    public void WriteValues(string message)
    {
      DateTime logTime = DateTime.Now;
      File.AppendAllText(fileName, $"{logTime} {message}\n");
    }
  }
}
