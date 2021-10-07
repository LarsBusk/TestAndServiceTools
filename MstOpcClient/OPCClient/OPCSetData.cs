using System;
using System.Linq;
using System.Runtime.InteropServices;
using OPC;
using OPCClient.OPCTags;
using OPCDA.NET;


namespace OPCClient
{
  /// <summary>
  /// Helper class for working with OpcDa.Net opc server
  /// </summary>
  public class OPCSetData
  {
    //Set OPC data
    public OpcGroup OPCWriteGroup;

    public bool SetOneOPCTag(IOPCTag opcTag)
    {
      return SetOneOPCTag(opcTag, VarEnum.VT_I4);
    }

    private bool SetOneOPCTag(IOPCTag opcTag, VarEnum dataType)
    {
      var items = new OPCItemDef[1];
      items[0] = new OPCItemDef(opcTag.FullName, true, 0, dataType);

      OPCItemResult[] addRslt;
      int rtc = OPCWriteGroup.AddItems(items, out addRslt);
      if (HRESULTS.Failed(rtc))
        return false;// "Error at AddItem";

      var iHnd = new Int32[addRslt.Length];
      for (int i = 0; i < addRslt.Length; ++i)
        iHnd[i] = addRslt[i].HandleServer;
      int[] err;
      var val = new object[addRslt.Length];
      val[0] = opcTag.ObjectValue;

      rtc = OPCWriteGroup.Write(iHnd, val, out err);

      //string errTxt = "OK";
      if (HRESULTS.Failed(rtc))
      {
        return false;
        //errTxt = srv.GetErrorString(rtc, 0);
      }
      // succeeded 
      // check item error codes 
      if (err.Any(HRESULTS.Failed))
      {
        return false;
      }

      OPCWriteGroup.RemoveItems(iHnd, out err);
      return true;
      //            return errTxt;
    }

    public bool SetOPCTags(IOPCTag[] opcTags, VarEnum[] dataTypes)
    {
      int numberOfTags = opcTags.Length;
      var items = new OPCItemDef[numberOfTags];
      OPCItemResult[] addRslt = new OPCItemResult[numberOfTags];

      for (int i = 0; i < opcTags.Length; i++)
      {
        items[i] = new OPCItemDef(opcTags[i].FullName, true, 0, dataTypes[i]);
      }
      
      int rtc = OPCWriteGroup.AddItems(items, out addRslt);
      if (HRESULTS.Failed(rtc))
        return false;// "Error at AddItem";

      var iHnd = new Int32[numberOfTags];
      for (int i = 0; i < addRslt.Length; ++i)
        iHnd[i] = addRslt[i].HandleServer;
      int[] err;
      var val = new object[numberOfTags];

      for (int i = 0; i < numberOfTags; i++)
      {
         val[i] = opcTags[i].ObjectValue;
      }

      rtc = OPCWriteGroup.Write(iHnd, val, out err);

      //string errTxt = "OK";
      if (HRESULTS.Failed(rtc))
      {
        return false;
        //errTxt = srv.GetErrorString(rtc, 0);
      }
      // succeeded 
      // check item error codes 
      if (err.Any(HRESULTS.Failed))
      {
        return false;
      }

      OPCWriteGroup.RemoveItems(iHnd, out err);
      return true;
    }
  }
}