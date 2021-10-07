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
    public OPCTag<int> WatchdogCounter;
    public OPCTag<bool> ProductCanBeChanged;
    public OPCTag<bool> DoingCalibrationSample;
    public OPCTag<int> ModeN;
    public KepServerInstrumentGroup(string serverPrefix) : base(serverPrefix)
    {
      SampleCounter = new OPCTag<int>(serverPrefix, "Instrument.SampleCounter");
      WatchdogCounter = new OPCTag<int>(serverPrefix, "Instrument.WatchdogCounter");
      ProductCanBeChanged = new OPCTag<bool>(serverPrefix, "Instrument.ProductCanBeChanged");
      DoingCalibrationSample = new OPCTag<bool>(serverPrefix, "Instrument.DoingCalibrationSample");
      ModeN = new OPCTag<int>(serverPrefix, "Instrument.ModeN");
      OPCTags.Add(SampleCounter);
      OPCTags.Add(ProductCanBeChanged);
      OPCTags.Add(ModeN);
      OPCTags.Add(WatchdogCounter);
      OPCTags.Add(DoingCalibrationSample);
    }
  }
}
