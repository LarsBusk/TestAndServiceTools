using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleGroupMMII : OPCGroup
  {
    public KepServerSampleGroup SampleGroup;
    public KepServerSampleParametersGroupMMII SampleParametersGroup;

    public KepServerSampleGroupMMII(string serverPrefix) : base(serverPrefix)
    {
      SampleGroup = new KepServerSampleGroup(serverPrefix);
      SampleParametersGroup = new KepServerSampleParametersGroupMMII(serverPrefix);
      OPCTags.AddRange(SampleGroup.OPCTags);
      OPCTags.AddRange(SampleParametersGroup.OPCTags);
    }
  }
}
