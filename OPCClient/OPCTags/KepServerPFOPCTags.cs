using System.Collections.Generic;
using OPCClient.Properties;

namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represent an OPC KEPServer 
    /// </summary>
    public class KepServerPFOPCTags : IOpcTags
    {
      /// <summary>
      /// List of Opc tags
      /// </summary>
      public List<IOPCTag> OPCTags { get; set; }

    public KepServerPFOPCTags()
       : this(Settings.Default.KepServerGroupName) {}

    public string ServerName => Settings.Default.KepServerName;

    public KepServerPFOPCTags(string serverPrefix)
      {
        OPCTags = new List<IOPCTag>();

        SampleGroup = new KepServerSampleGroupPf(serverPrefix);
        OPCTags.AddRange(SampleGroup.OPCTags);
        ControllerGroup = new KepServerControllerGroupPf(serverPrefix);
        OPCTags.AddRange(ControllerGroup.OPCTags);
        InstrumentGroup = new KepServerInstrumentGroup(serverPrefix);
        OPCTags.AddRange(InstrumentGroup.OPCTags);
      }


      #region GetTags

      public KepServerSampleGroupPf SampleGroup { get; private set; }
      public KepServerControllerGroupPf ControllerGroup { get; private set; }
      public KepServerInstrumentGroup InstrumentGroup { get; private set; }
      #endregion
    }
}