using System;
using System.IO;

namespace NoraOpcUaTestServer
{
  public class CsvHelper
  {
    private readonly string fileName;
    public CsvHelper(string fileName = "ResultValues.csv")
    {
      this.fileName = Path.Combine(Properties.Settings.Default.LogFolder, fileName);

      if (!File.Exists(this.fileName))
      {
        File.AppendAllText(this.fileName, "Time;SampleCounter;SampleNumber;Diff;Delay;SampleRegistrationValue;Fat;Protein;Lactose;SNF;TS\n");
      }
    }

    public void WriteValues(DateTime time, uint sampleCounter, string sampleNumber, string sampleRegistrationValue, double fat, double protein, double lactose, double ts, double snf, TimeSpan timeDif, TimeSpan delay)
    {
      File.AppendAllText(this.fileName, $"{time.ToString("yyy-MM-dd HH:mm:ss,fff")};{sampleCounter};{sampleNumber};{(int)timeDif.TotalMilliseconds};{(int)delay.TotalMilliseconds};{sampleRegistrationValue};{fat};{protein};{lactose};{snf};{ts}\n");
    }
  }
}
