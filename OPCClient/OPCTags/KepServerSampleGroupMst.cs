using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleGroupMst : OPCGroup
  {
    public KepServerSampleGroup SampleGroup;
    public KepServerSampleParametersGroupMst SampleParametersGroup;

    public KepServerSampleGroupMst(string serverPrefix) : base(serverPrefix)
    {
      SampleGroup = new KepServerSampleGroup(serverPrefix);
      SampleParametersGroup = new KepServerSampleParametersGroupMst(serverPrefix);

      OPCTags.AddRange(SampleGroup.OPCTags);
      OPCTags.AddRange(SampleParametersGroup.OPCTags);
    }
  }
}
