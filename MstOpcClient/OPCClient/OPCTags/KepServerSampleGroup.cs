using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleGroup : OPCGroup
  {
    public OPCTag<int> Identifier;
    public OPCTag<string> Number;
    public OPCTag<double> SampleDateTime;
    public OPCTag<int> Year;
    public OPCTag<int> Month;
    public OPCTag<int> Day;
    public OPCTag<int> Hour;
    public OPCTag<int> Minute;
    public OPCTag<int> Second;
    public OPCTag<int> MilliSecond;
    public OPCTag<int> ProductCodeN;
    public OPCTag<bool> CalibrationSample;
    public KepServerSampleParametersGroup SampleParametersGroup;

    public KepServerSampleGroup(string serverPrefix) : base(serverPrefix)
    {
      Identifier = new OPCTag<int>(serverPrefix, "Sample.NumberN");
      OPCTags.Add(Identifier);
      Number = new OPCTag<string>(serverPrefix, "Sample.Number");
      OPCTags.Add(Number);
      SampleDateTime = new OPCTag<double>(serverPrefix, "Sample.DateTime");
      OPCTags.Add(SampleDateTime);
      Year = new OPCTag<int>(serverPrefix, "Sample.Year");
      OPCTags.Add(Year);
      Month = new OPCTag<int>(serverPrefix, "Sample.Month");
      OPCTags.Add(Month);
      Day= new OPCTag<int>(serverPrefix, "Sample.Day");
      OPCTags.Add(Day);
      Hour = new OPCTag<int>(serverPrefix, "Sample.Hour");
      OPCTags.Add(Hour);
      Minute = new OPCTag<int>(serverPrefix, "Sample.Minute");
      OPCTags.Add(Minute);
      Second = new OPCTag<int>(serverPrefix, "Sample.Second");
      OPCTags.Add(Second);
      MilliSecond = new OPCTag<int>(serverPrefix, "Sample.Msec");
      OPCTags.Add(MilliSecond); 
      ProductCodeN = new OPCTag<int>(serverPrefix, "Sample.ProductCodeN");
      OPCTags.Add(ProductCodeN);
      CalibrationSample = new OPCTag<bool>(serverPrefix, "Sample.CalibrationSample");
      OPCTags.Add(CalibrationSample);
      SampleParametersGroup = new KepServerSampleParametersGroup(serverPrefix);
      OPCTags.AddRange(SampleParametersGroup.OPCTags);
    }
  }
}
