using System.Collections.Generic;
using OPCClient.Properties;

namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represent an OPC KEPServer 
    /// </summary>
    public class KepServerMeatMasterIIOPCTags : IOpcTags
    {
      /// <summary>
      /// List of Opc tags
      /// </summary>
      public List<IOPCTag> OPCTags { get; set; }

    public KepServerMeatMasterIIOPCTags()
       : this(Settings.Default.KepServerGroupName) {}

    public string ServerName => Settings.Default.KepServerName;
  
    public KepServerMeatMasterIIOPCTags(string serverPrefix)
      {
        OPCTags = new List<IOPCTag>();

        GetGate01 = new OPCTag<bool>(serverPrefix, "Gates.Gate01.Activate");
        OPCTags.Add(GetGate01);

        SampleGroup = new KepServerSampleGroupMMII(serverPrefix);
        OPCTags.AddRange(SampleGroup.OPCTags);
        ControllerGroup = new KepServerControllerGroupMM(serverPrefix);
        OPCTags.AddRange(ControllerGroup.OPCTags);
        InstrumentGroup = new KepServerInstrumentGroup(serverPrefix);
        OPCTags.AddRange(InstrumentGroup.OPCTags);
        TestGroup = new KepServerTestGroup(serverPrefix);
        OPCTags.AddRange(TestGroup.OPCTags);
      }


      #region GetTags

      public OPCTag<bool> GetGate01 { get; private set; }
      public KepServerSampleGroupMMII SampleGroup { get; private set; }
      public KepServerControllerGroupMM ControllerGroup { get; private set; }
      public KepServerInstrumentGroup InstrumentGroup { get; private set; }

      public KepServerTestGroup TestGroup { get; private set; }
      #endregion
    }
}