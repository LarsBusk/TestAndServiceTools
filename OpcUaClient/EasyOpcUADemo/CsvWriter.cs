using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpcLabs.EasyOpc.UA;

namespace OpcUaTestClient
{
  public static class CsvWriter
  {
    private static string header;
    private const string FileName = "Results.csv";



    public static void WriteToFile(List<OpcNodeResult> results)
    {
      if (!File.Exists(FileName))
      {
        CreateHeader(results);
        File.AppendAllText(FileName, $"{header}\n");
      }
      else
      {
        string line = CreateLine(results);
        File.AppendAllText(FileName, $"{line}\n");
      }
    }

    public static void WriteToFile(Dictionary<string, UAAttributeData> results)
    {
      if (!File.Exists(FileName))
      {
        CreateHeader(results);
        File.AppendAllText(FileName, $"{header}\n");
      }
      else
      {
        string line = CreateLine(results);
        File.AppendAllText(FileName, $"{line}\n");
      }
    }

    private static void CreateHeader(List<OpcNodeResult> results)
    {
      StringBuilder builder = new StringBuilder();

      builder.Append("ServerTime;");
      builder.Append("ResultTime;");

      foreach (var opcResult in results)
      {
        builder.Append($"{opcResult.NodeName};");
      }

      header = builder.ToString();
    }

    private static void CreateHeader(Dictionary<string, UAAttributeData> results)
    {
      StringBuilder builder = new StringBuilder();

      builder.Append("ServerTime;");
      builder.Append("ResultTime;");

      foreach (var opcResult in results)
      {
        builder.Append($"{opcResult.Key};");
      }

      header = builder.ToString();
    }

    private  static string CreateLine(List<OpcNodeResult> results)
    {
      StringBuilder builder = new StringBuilder();
      string dateFormat = "yyyy-MM-dd HH:mm:ss,fff";

      builder.Append($"{results[0].ServerDateTime.ToString(dateFormat)};");
      builder.Append($"{CreateResultTime(results).ToString(dateFormat)};");

      foreach (var opcResult in results)
      {
        builder.Append($"{opcResult.NodeValue};");
      }

      return builder.ToString();
    }

    private static string CreateLine(Dictionary<string, UAAttributeData> results)
    {
      StringBuilder builder = new StringBuilder();
      string dateFormat = "yyyy-MM-dd HH:mm:ss,fff";

      builder.Append($"{results["Watchdog"].ServerTimestamp.ToString(dateFormat)};");
      builder.Append($"{CreateResultTime(results).ToString(dateFormat)};");

      foreach (var opcResult in results)
      {
        builder.Append($"{opcResult.Value.DisplayValue()};");
      }

      return builder.ToString();
    }

    private static DateTime CreateResultTime(List<OpcNodeResult> result)
    {
      int year = int.Parse(result.Find(r => r.NodeName.Equals("Year")).NodeValue);
      int month = int.Parse(result.Find(r => r.NodeName.Equals("Month")).NodeValue);
      int day = int.Parse(result.Find(r => r.NodeName.Equals("Day")).NodeValue);
      int hour = int.Parse(result.Find(r => r.NodeName.Equals("Hour")).NodeValue);
      int min = int.Parse(result.Find(r => r.NodeName.Equals("Minute")).NodeValue);
      int sec = int.Parse(result.Find(r => r.NodeName.Equals("Second")).NodeValue);
      int msec = int.Parse(result.Find(r => r.NodeName.Equals("Msec")).NodeValue);

      return new DateTime(year, month, day, hour, min, sec, msec).ToUniversalTime();
    }

    private static DateTime CreateResultTime(Dictionary<string, UAAttributeData> results)
    {
      int year = int.Parse(results["Year"].DisplayValue());
      int month = int.Parse(results["Month"].DisplayValue());
      int day = int.Parse(results["Day"].DisplayValue());
      int hour = int.Parse(results["Hour"].DisplayValue());
      int min = int.Parse(results["Minute"].DisplayValue());
      int sec = int.Parse(results["Second"].DisplayValue());
      int msec = int.Parse(results["Msec"].DisplayValue());

      return new DateTime(year, month, day, hour, min, sec, msec).ToUniversalTime();
    }
  }
}
