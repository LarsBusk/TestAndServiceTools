using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
    public class PfSampleRegistrationGroup : OPCGroup
    {
        public OPCTag<int> PreRegistration01;
        public OPCTag<int> PreRegistration02;
        public OPCTag<int> PreRegistration03;
        public OPCTag<int> PreRegistration04;
        public OPCTag<int> PreRegistration05;
        public OPCTag<int> PreRegistration06;
        public OPCTag<int> PreRegistration07;
        public OPCTag<int> PreRegistration08;

        public PfSampleRegistrationGroup(string serverPrefix) : base(serverPrefix)
        {
            PreRegistration01 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration01");
            OPCTags.Add(PreRegistration01);
            PreRegistration02 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration02");
            OPCTags.Add(PreRegistration02);
            PreRegistration03 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration03");
            OPCTags.Add(PreRegistration03);
            PreRegistration04 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration04");
            OPCTags.Add(PreRegistration04);
            PreRegistration05 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration05");
            OPCTags.Add(PreRegistration05);
            PreRegistration06 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration06");
            OPCTags.Add(PreRegistration06);
            PreRegistration07 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration07");
            OPCTags.Add(PreRegistration07);
            PreRegistration08 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration08");
            OPCTags.Add(PreRegistration08);
        }
    }
}
