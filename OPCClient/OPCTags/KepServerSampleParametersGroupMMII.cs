using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleParametersGroupMMII : OPCGroup
  {
    public OPCTag<double> Fat;
    public OPCTag<double> Weight;
    public OPCTag<int> Registration01;
    public OPCTag<int> Registration02;

    public KepServerSampleParametersGroupMMII(string serverPrefix) : base(serverPrefix)
    {
      Fat=new OPCTag<double>(serverPrefix, "Sample.Parameters.FAT.Result");
      OPCTags.Add(Fat);
      Weight = new OPCTag<double>(serverPrefix, "Sample.Parameters.WEIGHT.Result");
      OPCTags.Add(Weight);
      Registration01 = new OPCTag<int>(serverPrefix, "Sample.Registration.Value01");
      OPCTags.Add(Registration01);
      Registration02 = new OPCTag<int>(serverPrefix, "Sample.Registration.Value02");
      OPCTags.Add(Registration02);
    }
  }
}
