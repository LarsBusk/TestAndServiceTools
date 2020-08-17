using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OPC;
using OPCClient.OPCTags;
using OPCDA;
using OPCDA.NET;

namespace OPCClient
{
  /// <summary>
  /// Class that extracts data from a MeatMasterIIOPCTags class.
  /// Helper class for working with OpcDa.Net opc server.
  /// </summary>
  public class OPCGetData
  {
    private readonly List<OPCItemResult[]> listOfOpcResults = new List<OPCItemResult[]>();
    private readonly IOpcTags opcTags;
    private readonly List<string> opcReadTags = new List<string>();
    private int numberOfReadOPCTags;

    #region CreateGroup
    public void CreateAllReadTags()
    {
      foreach (IOPCTag element in opcTags.OPCTags)
      {
        CreateReadOPCTag(element);
      }
    }
    #endregion CreateGroup


    public OpcGroup OPCReadGroup;

    public OPCGetData(IOpcTags opcTags)
    {
      this.opcTags = opcTags;
    }


    public void ReadAllOPCData()
    {
      var iHnd = new Int32[numberOfReadOPCTags];

      for (int i = 0; i < numberOfReadOPCTags; i++)
      {
        iHnd[i] = listOfOpcResults[i][0].HandleServer;
      }
      OPCItemState[] readState;

      int rtc = OPCReadGroup.Read(
          OPCDATASOURCE.OPC_DS_DEVICE, iHnd, out readState);
      if (HRESULTS.Failed(rtc))
      {
        for (int i = 0; i < numberOfReadOPCTags; i++)
        {
          if (iHnd[i] == 0)
          {
            throw new ArgumentException(
                "Could not read " + opcReadTags[i]);
          }
        }
      }

      int mmIIopcTagIndex = 0;
      for (int i = 0; i < numberOfReadOPCTags; i++)
      {
        if (opcTags.OPCTags[mmIIopcTagIndex].FullName == "Nova Server.GetSample.RawValue01.Value")
        {
          mmIIopcTagIndex++;
        }
        opcTags.OPCTags[mmIIopcTagIndex].ObjectValue = readState[i].DataValue;
        mmIIopcTagIndex++;
      }
    }

    #region CreateOPCTag
    public bool CreateReadOPCTag(IOPCTag opcTag)
    {
      if (opcTag.Type == typeof(int)) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_I4); }
      if (opcTag.Type == typeof(bool)) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_BOOL); }
      if (opcTag.Type == typeof(string)) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_BSTR); }
      if (opcTag.Type == typeof(DateTime)) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_DATE); }
      if (opcTag.Type == typeof(double)) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_R8); }
      if (opcTag.Type == typeof(float)) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_R4); }
      if (opcTag.Type == typeof(string[])) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_BSTR | VarEnum.VT_ARRAY); }
      if (opcTag.Type == typeof(int[])) { return CreateReadOPCTag(opcTag.FullName, VarEnum.VT_I4 | VarEnum.VT_ARRAY); }
      return false;
    }

    /// <summary>
    ///     lov level function which creates an opc tag of specific COM type
    /// </summary>
    /// <param name="opcTag"></param>
    /// <param name="dataType"></param>
    /// <returns></returns>
    private bool CreateReadOPCTag(string opcTag, VarEnum dataType)
    {
      numberOfReadOPCTags++;
      opcReadTags.Add(opcTag);

      var items = new OPCItemDef[1];
      items[0] = new OPCItemDef(opcTag, true, 0, dataType);

      OPCItemResult[] readResults;

      int rtc2 = OPCReadGroup.AddItems(items, out readResults);
      listOfOpcResults.Add(readResults);

      if (HRESULTS.Failed(rtc2))
      {
        //srv.Disconnect();
        {
          return false;
        }
      }
      return true;
    }
    #endregion CreateOPCTag


  }
}