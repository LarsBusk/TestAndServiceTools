using System;
using System.Collections.Generic;

namespace OPCClient.OPCTags
{
  /// <summary>
  /// Contains all MeatMaster II opc tags
  /// </summary>
  public class MeatMasterIIOPCTags : IOpcTags
  {
    /// <summary>
    /// List of Opc tags
    /// </summary>
    public List<IOPCTag> OPCTags { get; set; }

    /// <summary>
    /// Construct
    /// </summary>
    public MeatMasterIIOPCTags()
      : this("Nova Server.")
    { }

    /// <summary>
    /// Construct all MeatMaster II opc tags
    /// </summary>
    protected MeatMasterIIOPCTags(string serverPrefix, int numberOfParameters = 15, int numberOfSampleRegistration = 2)
    {
      OPCTags = new List<IOPCTag>();

      GetBatchParamedterGroup = new MMIIGetBatchParamaterGroup(serverPrefix, 10);
      OPCTags.AddRange(GetBatchParamedterGroup.OPCTags);

      GetCurrentSystemTime = new OPCTag<DateTime>(serverPrefix, "GetCurrentSystemTime.Time");
      OPCTags.Add(GetCurrentSystemTime);

      GetGate01 = new OPCTag<bool>(serverPrefix, "GetGates.Gate01.Value");
      OPCTags.Add(GetGate01);

      SetInstrumentStateGroup = new MMIISetInstrumentStateGroup(serverPrefix);
      OPCTags.AddRange(SetInstrumentStateGroup.OPCTags);
      
      SetPreregistrationGroup = new MMIISetPreregistrationGroup(serverPrefix, numberOfSampleRegistration);
      OPCTags.AddRange(SetPreregistrationGroup.OPCTags);

      SetPostRegistrationGroup = new MMIISetPostRegistrationGroup(serverPrefix, 10);
      OPCTags.AddRange(SetPostRegistrationGroup.OPCTags);
      
      GetInstrumentStateGroup = new MMIIGetInstrumentStateGroup(serverPrefix);
      OPCTags.AddRange(GetInstrumentStateGroup.OPCTags);

      GetInstrumentStateEventDetailGroup = new MMIIGetInstrumentStateEventDetailGroup(serverPrefix);
      OPCTags.AddRange(GetInstrumentStateEventDetailGroup.OPCTags);

      //Can not be mapped to Siemens 
      GetInstrumentStateProductGroup = new MMIIGetInstrumentStateProductGroup(serverPrefix);
      OPCTags.AddRange(GetInstrumentStateProductGroup.OPCTags);

      GetOpcServerStateGroup = new MMIIGetOpcServerStateGroup(serverPrefix);
      OPCTags.AddRange(GetOpcServerStateGroup.OPCTags);

      GetSampleEventDetailGroup = new MMIIGetSampleEventDetailGroup(serverPrefix);
      OPCTags.AddRange(GetSampleEventDetailGroup.OPCTags);

      GetSampleGroup = new MMIIGetSampleGroup(serverPrefix);
      OPCTags.AddRange(GetSampleGroup.OPCTags);

      GetSampleParameterGroup = new MMIIGetSampleParameterGroup(serverPrefix, numberOfParameters);
      OPCTags.AddRange(GetSampleParameterGroup.OPCTags);

      GetSampleBoneGroup = new MMIIGetSampleBoneGroup(serverPrefix, 5);
      OPCTags.AddRange(GetSampleBoneGroup.OPCTags);

      GetSampleMetalGroup = new MMIIGetSampleMetalGroup(serverPrefix, 5);
      OPCTags.AddRange(GetSampleMetalGroup.OPCTags);

      GetSampleRegistrationGroup = new MMIIGetSampleRegistrationGroup(serverPrefix, numberOfSampleRegistration);
      OPCTags.AddRange(GetSampleRegistrationGroup.OPCTags);
    }

    /// <summary>
    /// must be overridden of inherited classes, e.g. LinkMaster and KepServer
    /// </summary>
    public virtual string ServerName
    {
      get { return "Foss.Nova.OPCServer"; }
    }

    #region SetTags
    public MMIISetInstrumentStateGroup SetInstrumentStateGroup { get; private set; }
    public MMIISetPreregistrationGroup SetPreregistrationGroup { get; private set; }
    public MMIISetPostRegistrationGroup SetPostRegistrationGroup { get; private set; }
    #endregion SetTags

    #region GetTags
    public OPCTag<DateTime> GetCurrentSystemTime { get; private set; }
    public OPCTag<bool> GetGate01 { get; private set; } 
    public MMIIGetBatchParamaterGroup GetBatchParamedterGroup { get; private set; }
    public MMIIGetInstrumentStateGroup GetInstrumentStateGroup { get; private set; }
    public MMIIGetInstrumentStateEventDetailGroup GetInstrumentStateEventDetailGroup { get; private set; }
    public MMIIGetInstrumentStateProductGroup GetInstrumentStateProductGroup { get; private set; }
    public MMIIGetOpcServerStateGroup GetOpcServerStateGroup { get; private set; }
    public MMIIGetSampleEventDetailGroup GetSampleEventDetailGroup { get; private set; }
    public MMIIGetSampleGroup GetSampleGroup { get; private set; }
    public MMIIGetSampleParameterGroup GetSampleParameterGroup { get; private set; }
    public MMIIGetSampleBoneGroup GetSampleBoneGroup { get; private set; }
    public MMIIGetSampleMetalGroup GetSampleMetalGroup { get; private set; }
    public MMIIGetSampleRegistrationGroup GetSampleRegistrationGroup { get; private set; }
    #endregion GetTags
  }
}