using System;
using System.IO;

namespace NoraOpcUaTestServer
{
  public class CsvHelper
  {
    private string fileName;
    public CsvHelper(string fileName = "FatValues.csv")
    {
      this.fileName = fileName;

      if (!File.Exists(fileName))
      {
        File.AppendAllText(fileName, "Time;Fat;Diff\n");
      }
    }

    public void WriteValues(DateTime time, double fat, TimeSpan timeDif)
    {
      File.AppendAllText(fileName, $"{time};{fat};{(int)timeDif.TotalMilliseconds}\n");
    }
  }
}
