using System;
using System.IO;

namespace NoraOpcUaTestServer
{
  public class CsvHelper
  {
    private string fileName;
    public CsvHelper(string fileName = "ResultValues.csv")
    {
      this.fileName = Path.Combine(Properties.Settings.Default.LogFolder, fileName);

      if (!File.Exists(this.fileName))
      {
        File.AppendAllText(this.fileName, "Time;SampleCounter;SampleNumber;SampleRegistrationValue;Fat;Protein;Lactose;SNF;TS;Diff\n");
      }
    }

    public void WriteValues(DateTime time, uint sampleCounter, string sampleNumber, string smapleRegistrationValue, double fat, double protein, double lactose, double ts, double snf, TimeSpan timeDif)
    {
      File.AppendAllText(this.fileName, $"{time};{sampleCounter};{sampleNumber};{smapleRegistrationValue};{fat};{protein};{lactose};{snf};{ts};{(int)timeDif.TotalMilliseconds}\n");
    }
  }
}
