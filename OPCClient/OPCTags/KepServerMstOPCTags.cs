using System.Collections.Generic;
using OPCClient.Properties;

namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represent an OPC KEPServer 
    /// </summary>
    public class KepServerMstOPCTags : IOpcTags
    {
      /// <summary>
      /// List of Opc tags
      /// </summary>
      public List<IOPCTag> OPCTags { get; set; }

    public KepServerMstOPCTags()
       : this(Settings.Default.KepServerGroupName) {}

    public string ServerName => Settings.Default.KepServerName;

    public KepServerMstOPCTags(string serverPrefix)
      {
        OPCTags = new List<IOPCTag>();

        SampleGroup = new KepServerSampleGroupMst(serverPrefix);
        OPCTags.AddRange(SampleGroup.OPCTags);
        ControllerGroup = new KepServerControllerGroupMst(serverPrefix);
        OPCTags.AddRange(ControllerGroup.OPCTags);
        InstrumentGroup = new KepServerInstrumentGroup(serverPrefix);
        OPCTags.AddRange(InstrumentGroup.OPCTags);
      }


      #region GetTags

      public KepServerSampleGroupMst SampleGroup { get; private set; }
      public KepServerControllerGroupMst ControllerGroup { get; private set; }
      public KepServerInstrumentGroup InstrumentGroup { get; private set; }
      #endregion
    }
}