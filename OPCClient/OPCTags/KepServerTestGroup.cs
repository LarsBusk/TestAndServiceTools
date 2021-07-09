using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerTestGroup : OPCGroup
  {
    public OPCTag<double> BoneOut;
    public OPCTag<double> FatOut;
    public OPCTag<double> MetalOut;
    public OPCTag<double> WeightOut;
    public OPCTag<int> SampleNoOut;

    public KepServerTestGroup(string serverPrefix) : base(serverPrefix)
    {
      BoneOut = new OPCTag<double>(serverPrefix, "Test.Bone_Out");
      FatOut = new OPCTag<double>(serverPrefix, "Test.Fat_Out");
      MetalOut = new OPCTag<double>(serverPrefix, "Test.Metal_Out");
      WeightOut = new OPCTag<double>(serverPrefix, "Test.Weight_Out");
      SampleNoOut = new OPCTag<int>(serverPrefix, "Test.SampleNo_Out");

      OPCTags.Add(BoneOut);
      OPCTags.Add(FatOut);
      OPCTags.Add(MetalOut);
      OPCTags.Add(WeightOut);
      OPCTags.Add(SampleNoOut);
    }
  }
}
