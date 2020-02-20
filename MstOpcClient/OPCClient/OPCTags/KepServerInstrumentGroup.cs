using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerInstrumentGroup : OPCGroup
  {
    public OPCTag<int> SampleCounter;
    public OPCTag<bool> ProductCanBeChanged;
    public OPCTag<int> ModeN;
    public OPCTag<int> WatchdogCounter;
    public OPCTag<bool> DoingCalibrationSample;
    public KepServerInstrumentGroup(string serverPrefix) : base(serverPrefix)
    {
      SampleCounter = new OPCTag<int>(serverPrefix, "Instrument.SampleCounter");
      OPCTags.Add(SampleCounter);
      ProductCanBeChanged = new OPCTag<bool>(serverPrefix, "Instrument.ProductCanBeChanged");
      OPCTags.Add(ProductCanBeChanged);
      ModeN = new OPCTag<int>(serverPrefix, "Instrument.ModeN");
      OPCTags.Add(ModeN);
      WatchdogCounter = new OPCTag<int>(serverPrefix, "Instrument.WatchdogCounter");
      OPCTags.Add(WatchdogCounter);
      DoingCalibrationSample = new OPCTag<bool>(serverPrefix, "Instrument.DoingCalibrationSample");
      OPCTags.Add(DoingCalibrationSample);
    }
  }
}
