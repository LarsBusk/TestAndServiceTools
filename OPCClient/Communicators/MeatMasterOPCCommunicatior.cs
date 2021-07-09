using System;
using System.Diagnostics;
using System.IO;
using log4net;
using System.Threading;
using OPCClient.OPCTags;
using OPCClient.Properties;

namespace OPCClient.Communicators
{
  /// <summary>
  /// Communicate with Opc Server of given type
  /// </summary>
  public class MeatMasterOPCCommunicatior
  {
    private readonly OPCServerType opcServerType;

    private static readonly ILog log = LogManager.GetLogger(typeof(MeatMasterOPCCommunicatior));

    /// <summary>
    /// Construct - work with the specified type of Opc server
    /// </summary>
    public MeatMasterOPCCommunicatior(OPCServerType opcCServerType)
    {
      opcServerType = opcCServerType;
    }

    /// <summary>
    /// All MeatMaster II opc tags
    /// </summary>
    public static MeatMasterIIOPCTags MeatMasterIIOPCTags;

    public static KepServerMeatMasterIIOPCTags KepServerOpcTags;

    /// <summary>
    /// Helper class for getting/setting opc tags
    /// </summary>
    public static OpcHelp OpcHelp;

    /// <summary>
    /// Connect
    /// </summary>
    public void ConnectToMeatMasterOPCServer(string groupName = "MMII.PDx.")
    {
      switch (opcServerType)
      {
        case OPCServerType.MeatMaster:
          MeatMasterIIOPCTags = new MeatMasterIIOPCTags();
          break;
        case OPCServerType.KepServer:
          KepServerOpcTags = new KepServerMeatMasterIIOPCTags(groupName);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      OpcHelp = new OpcHelp(MeatMasterIIOPCTags);

      if (!OpcHelp.Connect(MeatMasterIIOPCTags.ServerName, 100))
      {
        throw new IOException("Could not connect to OPC server");
      }

      OpcHelp.OPCGetData.CreateAllReadTags();
    }

    public void ConnectToKepServer()
    {
      KepServerOpcTags = new KepServerMeatMasterIIOPCTags();

      OpcHelp = new OpcHelp(KepServerOpcTags);

      string kepServerName = Settings.Default.KepServerName;
      log.DebugFormat("Trying to connect to {0}", kepServerName);

      if (!OpcHelp.Connect(kepServerName, 100))
      {
        throw new IOException("Could not connect to OPC server");
      }

      OpcHelp.OPCGetData.CreateAllReadTags();
    }

    public void ConnectToKepServer(string kepServerName, string groupName, int updateRate = 100)
    {
      groupName += "."; //Needed to get the full path of the tagnames right.
      KepServerOpcTags = new KepServerMeatMasterIIOPCTags(groupName);

      OpcHelp = new OpcHelp(KepServerOpcTags);
      
      log.DebugFormat("Trying to connect to {0} group: {1}", kepServerName, groupName);

      if (!OpcHelp.Connect(kepServerName, updateRate))
      {
        throw new IOException("Could not connect to OPC server");
      }

      OpcHelp.OPCGetData.CreateAllReadTags();
    }

    /// <summary>
    /// Disconnect
    /// </summary>
    public void DisconnectFromOPCServer()
    {
      OpcHelp.Disconnect();
      OpcHelp = null;
    }

    /// <summary>
    /// Read all samples and returns when next sample is available
    /// </summary>
    /// <param name="maxWaitingTimeInMilliSeconds"></param>
    /// <param name="pollingInterVal"></param>
    /// <returns>true if sample was found, false if no sample was found within timespan</returns>
    public bool WaitForNextSample(int maxWaitingTimeInMilliSeconds, int pollingInterVal = 1000)
    {
      bool gotSample = true;
      int lastSampleId = MeatMasterIIOPCTags.GetSampleGroup.Identifier.Value;
      int milliSecondsGone = 0;

      while (MeatMasterIIOPCTags.GetSampleGroup.Identifier.Value == lastSampleId)
      {
        milliSecondsGone += pollingInterVal;
        OpcHelp.OPCGetData.ReadAllOPCData();

        Thread.Sleep(pollingInterVal);
        Debug.WriteLine("{0} gone of {1}", milliSecondsGone, maxWaitingTimeInMilliSeconds);

        if (milliSecondsGone > maxWaitingTimeInMilliSeconds)
        {
          gotSample = false;
          break;
        }
      }
      return gotSample;
    }

    /// <summary>
    /// Start measuring with the current product
    /// </summary>
    public static void StartMeasuring()
    {
      MeatMasterIIOPCTags.SetInstrumentStateGroup.Mode.ObjectValue = InstrumentStateMode.StartMeasuring;
      OpcHelp.OPCSetData.SetOneOPCTag(MeatMasterIIOPCTags.SetInstrumentStateGroup.Mode);
    }

    /// <summary>
    /// Set instrument in standby
    /// </summary>
    public static void GotoStandby()
    {
      MeatMasterIIOPCTags.SetInstrumentStateGroup.Mode.ObjectValue = InstrumentStateMode.GotoStandby;
      OpcHelp.OPCSetData.SetOneOPCTag(MeatMasterIIOPCTags.SetInstrumentStateGroup.Mode);
    }

    /// <summary>
    /// Set product to use by specifying product code
    /// </summary>
    /// <param name="productCode"></param>
    public static void SetProduct(int productCode)
    {
      MeatMasterIIOPCTags.SetInstrumentStateGroup.ProductCode.ObjectValue = productCode;
      OpcHelp.OPCSetData.SetOneOPCTag(MeatMasterIIOPCTags.SetInstrumentStateGroup.ProductCode);
    }

    /// <summary>
    /// Set two registration values
    /// </summary>
    /// <param name="r1"></param>
    /// <param name="r2"></param>
    public static void SetPreRegistrationsValues(int r1, int r2)
    {
      MeatMasterIIOPCTags.SetPreregistrationGroup.GetRegistrationValue(1).ObjectValue = r1;
      OpcHelp.OPCSetData.SetOneOPCTag(MeatMasterIIOPCTags.SetPreregistrationGroup.GetRegistrationValue(1));
      MeatMasterIIOPCTags.SetPreregistrationGroup.GetRegistrationValue(2).ObjectValue = r2;
      OpcHelp.OPCSetData.SetOneOPCTag(MeatMasterIIOPCTags.SetPreregistrationGroup.GetRegistrationValue(2));
    }

    public static void KepServerSetRegistrationValue2(int value)
    {
      KepServerOpcTags.ControllerGroup.PreregistrationValue2.ObjectValue = value;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.PreregistrationValue2);
    }

    public static void KepServerSetRegistrationValue1(int value)
    {
      KepServerOpcTags.ControllerGroup.PreregistrationValue1.ObjectValue = value;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.PreregistrationValue1);
    }

    public static void KepServerSetProductCodeN(int productCodeN)
    {
      log.DebugFormat("Setting product code to {0}", productCodeN);
      KepServerOpcTags.ControllerGroup.ProductCodeN.ObjectValue = productCodeN;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.ProductCodeN);
    }


    public static void KepServerStartMeasuring(bool startMeasuring)
    {
      log.DebugFormat("Setting StartMeasuring to {0}", startMeasuring);
      KepServerOpcTags.ControllerGroup.StartMeasuring.ObjectValue = startMeasuring;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.StartMeasuring);
    }

    public static void UpdateWatchDogCounter(int counter)
    {
      KepServerOpcTags.ControllerGroup.WatchdogCounter.ObjectValue = counter;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.WatchdogCounter);
    }
  }
}