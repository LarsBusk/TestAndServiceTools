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
    public KepServerInstrumentGroup(string serverPrefix) : base(serverPrefix)
    {
      SampleCounter = new OPCTag<int>(serverPrefix, "Instrument.SampleCounter");
      ProductCanBeChanged = new OPCTag<bool>(serverPrefix, "Instrument.ProductCanBeChanged");
      ModeN = new OPCTag<int>(serverPrefix, "Instrument.ModeN");
      OPCTags.Add(SampleCounter);
      OPCTags.Add(ProductCanBeChanged);
      OPCTags.Add(ModeN);
    }
  }
}
