using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleGroupMst : OPCGroup
  {
    public KepServerSampleGroup SamlpleGroup;
    public KepServerSampleParametersGroupMst SampleParametersGroup;

    public KepServerSampleGroupMst(string serverPrefix) : base(serverPrefix)
    {
      SamlpleGroup = new KepServerSampleGroup(serverPrefix);
      SampleParametersGroup = new KepServerSampleParametersGroupMst(serverPrefix);

      OPCTags.AddRange(SamlpleGroup.OPCTags);
      OPCTags.AddRange(SampleParametersGroup.OPCTags);
    }
  }
}
