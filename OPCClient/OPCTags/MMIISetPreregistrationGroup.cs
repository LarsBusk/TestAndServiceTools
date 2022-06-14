using System.Collections.Generic;

namespace OPCClient.OPCTags
{
  /// <summary>
  /// Class that represents a SetPreregistrationGroup
  /// </summary>
  public class MMIISetPreregistrationGroup : OPCGroup
  {
    // List that contains all the 
    readonly List<PreRegistration> preRegistrations = new List<PreRegistration>();

    private struct PreRegistration
    {
      public PreRegistration(string serverPrefix, int registrationNumber)
      {
        //Name = new OPCTag<string>(serverPrefix, string.Format("SetSample.Registration{0:00}.Name", registrationNumber));
        Value = new OPCTag<int>(serverPrefix, $"SetPreregistration.SampleRegistration0{registrationNumber}.Value");
      }
      //public readonly OPCTag<string> Name;
      public readonly OPCTag<int> Value;
    }

    /// <summary>
    /// Construct
    /// </summary>
    public MMIISetPreregistrationGroup(string serverPrefix, int numberOfSampleRegistration)
      : base(serverPrefix)
    {
      for (int i = 0; i < numberOfSampleRegistration; i++)
      {
        var preRegistration = new PreRegistration(ServerPrefix, i + 1);

        OPCTags.Add(preRegistration.Value);
        preRegistrations.Add(preRegistration);
      }
    }

    /// <summary>
    /// 1 is first value
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public IOPCTag GetRegistrationValue(int i) { return preRegistrations[i - 1].Value; }
  }
}
