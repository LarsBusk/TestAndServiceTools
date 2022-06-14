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

    private static int newProduct = 1;

    /// <summary>
    /// Construct - work with the specified type of Opc server
    /// </summary>
    public MeatMasterOPCCommunicatior(OPCServerType opcServerType)
    {
      this.opcServerType = opcServerType;
      log.Debug($"Opc server type is {opcServerType}");
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
    public void ConnectToMeatMasterOPCServer()
    {
      MeatMasterIIOPCTags = new MeatMasterIIOPCTags();

      OpcHelp = new OpcHelp(MeatMasterIIOPCTags);

      log.Debug($"Now connecting to {MeatMasterIIOPCTags.ServerName}...");

      try
      {
        OpcHelp.Connect(MeatMasterIIOPCTags.ServerName, 100);
      }
      catch (Exception e)
      {
        log.Error($"C'est le merde...{e.Message} {e.InnerException}");
        throw new IOException("Could not connect to OPC server");
        
      }
      /*if (!OpcHelp.Connect(MeatMasterIIOPCTags.ServerName, 100))
      {
        log.Error("C'est le merde...");
        throw new IOException("Could not connect to OPC server");
      }*/

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
      SetValueOfOpcTag(MeatMasterIIOPCTags.SetInstrumentStateGroup.Mode, InstrumentStateMode.StartMeasuring);
    }

    /// <summary>
    /// Set instrument in standby
    /// </summary>
    public static void GotoStandby()
    {
      SetValueOfOpcTag(MeatMasterIIOPCTags.SetInstrumentStateGroup.Mode, InstrumentStateMode.GotoStandby);
    }

    /// <summary>
    /// Set two registration values
    /// </summary>
    /// <param name="regValue1"></param>
    public static void SetPreRegistrationsValue1(int regValue1)
    {
      SetValueOfOpcTag(MeatMasterIIOPCTags.SetPreregistrationGroup.GetRegistrationValue(1), regValue1);
    }

    public static void SetPreRegistrationsValue2(int regValue2)
    {
      SetValueOfOpcTag(MeatMasterIIOPCTags.SetPreregistrationGroup.GetRegistrationValue(2), regValue2);
    }

    public static void ChangeProduct(int productCode)
    {
      SetValueOfOpcTag(MeatMasterIIOPCTags.SetInstrumentStateGroup.ProductCode, productCode);
      SetValueOfOpcTag(MeatMasterIIOPCTags.SetInstrumentStateGroup.NewProduct, newProduct);
      newProduct++;
    }

    public static void KepServerSetRegistrationValue2(int value)
    {
      SetValueOfOpcTag(KepServerOpcTags.ControllerGroup.PreregistrationValue2, value);
    }

    public static void KepServerSetRegistrationValue1(int value)
    {
      SetValueOfOpcTag(KepServerOpcTags.ControllerGroup.PreregistrationValue1, value);
    }

    public static bool KepServerSetProductCodeN(int productCodeN)
    {
      return SetValueOfOpcTag(KepServerOpcTags.ControllerGroup.ProductCodeN, productCodeN);
    }


    public static void KepServerStartMeasuring(bool startMeasuring)
    {
      SetValueOfOpcTag(KepServerOpcTags.ControllerGroup.StartMeasuring, startMeasuring);
    }

    public static void KepserverUpdateWatchDogCounter(int counter)
    {
      SetValueOfOpcTag(KepServerOpcTags.ControllerGroup.WatchdogCounter, counter);
    }

    private static bool SetValueOfOpcTag(IOPCTag tag, object value)
    {
      log.Debug($"Setting value of {tag.ShortName} to {value}");
      tag.ObjectValue = value;
      bool res = OpcHelp.OPCSetData.SetOneOPCTag(tag);
      log.Debug($"Value of tag {tag.ShortName} set: {res}");
      return res;
    }
  }
}