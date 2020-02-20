﻿using System.Collections.Generic;
using OPCClient.Properties;

namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represent an OPC KEPServer 
    /// </summary>
    public class KepServerOPCTags : IOpcTags
    {
      /// <summary>
      /// List of Opc tags
      /// </summary>
      public List<IOPCTag> OPCTags { get; set; }

    public KepServerOPCTags()
       : this(Settings.Default.KepServerGroupName) {}

    public string ServerName
    {
      get
      {
        return Settings.Default.KepServerName;
      }
    }

    public KepServerOPCTags(string serverPrefix)
      {
        OPCTags = new List<IOPCTag>();

        GetGate01 = new OPCTag<bool>(serverPrefix, "Gates.Gate01.Activate");
        OPCTags.Add(GetGate01);

        GetSampleGroup = new KepServerSampleGroup(serverPrefix);
        OPCTags.AddRange(GetSampleGroup.OPCTags);
        ControllerGroup = new KepServerControllerGroup(serverPrefix);
        OPCTags.AddRange(ControllerGroup.OPCTags);
        InstrumentGroup = new KepServerInstrumentGroup(serverPrefix);
        OPCTags.AddRange(InstrumentGroup.OPCTags);
      }


      #region GetTags

      public OPCTag<bool> GetGate01 { get; private set; }
      public KepServerSampleGroup GetSampleGroup { get; private set; }
      public KepServerControllerGroup ControllerGroup { get; private set; }
      public KepServerInstrumentGroup InstrumentGroup { get; private set; }
      #endregion
    }
}