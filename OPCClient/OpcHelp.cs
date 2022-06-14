using System;
using log4net;
using OPC;
using OPCClient.Communicators;
using OPCClient.OPCTags;
using OPCDA.NET;

namespace OPCClient
{
  /// <summary>
  /// Helper class that wraps call to setting/getting Opc data on OpcDa.Net opc server
  /// </summary>
  public class OpcHelp
  {
    private readonly IOpcTags MeatMasterIIOPCTags;
    private OpcServer srv;
    private static readonly ILog log = LogManager.GetLogger(typeof(OpcHelp));

    /// <summary>
    /// Helper for getting opc data
    /// </summary>
    public OPCGetData OPCGetData;

    /// <summary>
    /// Helper for setting opc data
    /// </summary>
    public OPCSetData OPCSetData;

    /// <summary>
    /// Construct
    /// </summary>
    /// <param name="meatMasterIIOPCTags"></param>
    public OpcHelp(IOpcTags meatMasterIIOPCTags)
    {
      log.Debug("Creating a new instance of OpcHelp");
      MeatMasterIIOPCTags = meatMasterIIOPCTags;
      OPCGetData = new OPCGetData(MeatMasterIIOPCTags);
      OPCSetData = new OPCSetData();
      log.Debug("Instance created....");
    }

    /// <summary>
    /// Connect to opc server
    /// </summary>
    /// <param name="serverName"></param>
    /// <param name="requestedUpdateRate">In case of use of LinkMaster and Kepserver simulation, this value should match the LinkMaster value</param>
    /// <returns></returns>
    public bool Connect(string serverName, int requestedUpdateRate=250)
    {
      srv = new OpcServer();
      log.Debug($"Opc server is created, trying to connect to {serverName}");
      int rtc = srv.Connect(serverName);
      if (HRESULTS.Failed(rtc))
      {
        string mes = srv.GetErrorString(rtc, 0);//MBR added 0 return Srv.GetErrorString( rtc);
        log.Error(mes);
        return false;
      }

      float deadBand = 0.0F;

      //Get data start
      try
      {
        OPCGetData.OPCReadGroup = srv.AddGroup("Group1GetData", true, requestedUpdateRate, ref deadBand, 0, 0);
      }
      catch (Exception)
      {
        srv.Disconnect();
        return false;
        //return ex.Message;
      }
      //Get data end

      //Set data start
      try
      {
        OPCSetData.OPCWriteGroup = srv.AddGroup("Group1SetData", true, requestedUpdateRate, ref deadBand, 0, 0);
      }
      catch (Exception)
      {
        srv.Disconnect();
        return false;//return ex.Message;
      }

      return true; //ok
    }

    /// <summary>
    /// Disconnect from opc server
    /// </summary>
    public void Disconnect()
    {
      OPCGetData.OPCReadGroup.Remove(true);
      srv.Disconnect();
    }
  }
}
