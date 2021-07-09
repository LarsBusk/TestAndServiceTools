using System.Collections.Generic;

namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represents a GetSampleRegistrationGroup
    /// </summary>
    public class MMIIGetSampleRegistrationGroup : OPCGroup
    {
        readonly List<Registration> registrations = new List<Registration>();

        private struct Registration
        {

            public Registration(string serverPrefix, int registrationNumber)
            {
              // Name is not used
              //  Name = new OPCTag<string>(serverPrefix, string.Format("GetSample.{0:00}.Name", registrationNumber));
                Value = new OPCTag<double>(serverPrefix, string.Format("GetSample.Registration{0:00}.Value", registrationNumber));
            }
            //public readonly OPCTag<string> Name;
            public readonly OPCTag<double> Value;
        }
   
        public MMIIGetSampleRegistrationGroup(string serverPrefix,int numberOfSampleRegistration): base(serverPrefix)
        {
            for (int i = 0; i < numberOfSampleRegistration; i++)
            {
                var registration = new Registration(serverPrefix, i+1);
                //OPCTags.Add(registration.Name);
                OPCTags.Add(registration.Value);

                registrations.Add(registration);
            }

        }
      public string GetValue(int i) { return string.Format(ServerPrefix + "GetSample.Registration{0:00}.Value", i); }
    
    }

}
