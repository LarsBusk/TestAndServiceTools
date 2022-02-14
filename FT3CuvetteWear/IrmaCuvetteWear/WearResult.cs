using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace IrmaCuvetteWear
{
  public class WearResult : IComparable
  {
    public DateTime ResultDateTime;

    public string IntensityCorrection => GetIntensityCorrection();

    public string DarkLevel => GetValue("DarkSignalCalculator", "dark level is", ", upper limit is");

    public string CleaningLiquidRatio => GetValue("CleaningLiquidCalculator", "ratio is", ", lower limit is");

    public string LimeStoneRatio => GetValue("LimestoneCalculator", "ratio is", ", lower limit is");

    public string MilkStoneRatio => GetValue("MilkstoneCalculator", "ratio is", ", lower limit is");

    public string ProteinRatio => GetValue("ProteinCalculator", "ratio is", ", lower limit is");

    public string InterferometerMisalignmentRatio => GetValue("MisalignmentCalculator", "ratio is", ", lower limit is");

    public string AbsoluteMoistureLevel => GetValue("AbsoluteMoistureLevelCalculator", "abs moisture level", ", upper limit is");

    public string ConductivityGhCheck => GetValue("ConductivityGhCheck", "worst value is", ", limit is");

    public string CleanConductivityCheck => GetValue("CleanConductivityCheck", "value is", ", lower limit is");

    public string ZeroConductivityCheck => GetValue("ZeroConductivityCheck", "value is", ", upper limit is");

    public List<string> ResultLines;
    public WearResult(DateTime resultDateTime)
    {
      this.ResultDateTime = resultDateTime;
      this.ResultLines = new List<string>();
    }

    private string GetIntensityCorrection()
    {
      string logLine = this.ResultLines.Find(l => l.Contains("Updating the SBRef average."));
      string[] lineParts = logLine.Split(' ');
      string info;
      string correctionPart = lineParts.First(lp => lp.StartsWith("intensityCorrection"));
      info = correctionPart.Split('=')[1];

      return info;
    }

    private string GetValue(string lineIdent, string startIndicator, string endIndicator)
    {
      string getValue = String.Empty;
      string logLine = ResultLines.Find(l => l.Contains(lineIdent));

      if (!string.IsNullOrEmpty(logLine))
      {
        int startPos = logLine.IndexOf(startIndicator) + startIndicator.Length + 1;
        int length = logLine.IndexOf(endIndicator, startPos) - startPos;
        getValue = logLine.Substring(startPos, length);
      }

      return getValue;
    }

    public static string FileHeader =>
      "DateTime;IntensityCorrection;DarkLevel;CleaningLiquidRatio;LimeStoneRatio;MilkStoneRatio;ProteinRatio;InterferometerMisalignmentRatio;" +
      "AbsoluteMoistureLevel;ConductivityGhCheck;CleanConductivityCheck;ZeroConductivityCheck";

    public override string ToString()
    {
      string uiSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
      return
        $"{ResultDateTime};{IntensityCorrection};{DarkLevel};{CleaningLiquidRatio};{LimeStoneRatio};{MilkStoneRatio};{ProteinRatio};{InterferometerMisalignmentRatio};{AbsoluteMoistureLevel};{ConductivityGhCheck};{CleanConductivityCheck};{ZeroConductivityCheck}"
          .Replace(".", uiSep);
    }

    public int CompareTo(object obj)
    {
      return this.ResultDateTime.CompareTo(((WearResult) obj).ResultDateTime);
    }
  }
}
