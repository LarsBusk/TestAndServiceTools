using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleGroupPf : OPCGroup
  {
    public KepServerSampleGroup SampleGroup;
    public KepServerSampleParametersGroupPf SampleParametersGroup;

    public KepServerSampleGroupPf(string serverPrefix) : base(serverPrefix)
    {
      OPCTags.AddRange(SampleGroup.OPCTags);
      OPCTags.AddRange(SampleParametersGroup.OPCTags);
    }
  }
}
