using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleParametersGroupMst : OPCGroup
  {
    public OPCTag<double> Fat;
    public OPCTag<double> Weight;
    public OPCTag<double> Lactose;
    public OPCTag<double> TS;

    public KepServerSampleParametersGroupMst(string serverPrefix) : base(serverPrefix)
    {
      Fat=new OPCTag<double>(serverPrefix, "Sample.Parameters.FAT.Result");
      OPCTags.Add(Fat);
      Weight = new OPCTag<double>(serverPrefix, "Sample.Parameters.Protein.Result");
      OPCTags.Add(Weight);
      Lactose = new OPCTag<double>(serverPrefix, "Sample.Parameters.Lactose.Result");
      OPCTags.Add(Lactose);
      TS = new OPCTag<double>(serverPrefix, "Sample.Parameters.TS.Result");
      OPCTags.Add(TS);
    }
  }
}
