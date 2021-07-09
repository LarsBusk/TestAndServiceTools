using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class MMIISetPostRegistrationGroup : OPCGroup
  {
    private readonly List<PostRegistration> postRegistrations = new List<PostRegistration>();
    private readonly OPCTag<int> sendSampleRegistrationOnSample;

    private struct PostRegistration
    {
      public PostRegistration(string serverPrefix, int registrationNumber)
      {
        Name = new OPCTag<string>(serverPrefix,
          string.Format("SetPostRegistration.SampleRegistration{0:00}.Name", registrationNumber));
        Value = new OPCTag<int>(serverPrefix,
          string.Format("SetPostRegistration.SampleRegistration{0:00}.Value", registrationNumber));
      }

      public readonly OPCTag<string> Name;
      public readonly OPCTag<int> Value;
    }

    public MMIISetPostRegistrationGroup(string serverPrefix, int numberOfPostRegs) : base(serverPrefix)
    {
      for (int i = 0; i < numberOfPostRegs; i++)
      {
        PostRegistration postRegistration = new PostRegistration(serverPrefix, i + 1);
        OPCTags.Add(postRegistration.Name);
        OPCTags.Add(postRegistration.Value);
        postRegistrations.Add(postRegistration);
      }

      sendSampleRegistrationOnSample = new OPCTag<int>(serverPrefix,
        "SetPostRegistration.SendSampleRegistrationOnSample.Value");
      OPCTags.Add(sendSampleRegistrationOnSample);
    }
  }
}
