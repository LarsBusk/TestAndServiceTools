using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using log4net;
using System.Threading;
using OPCClient.OPCTags;
using OPCClient.Properties;

namespace OPCClient.KepServer
{
  /// <summary>
  /// Communicate with Opc Server of given type
  /// </summary>
  public class KepServerCommunicator
  {

    private static readonly ILog log = LogManager.GetLogger(typeof(KepServerCommunicator));


    public static KepServerOPCTags KepServerOpcTags;

    /// <summary>
    /// Helper class for getting/setting opc tags
    /// </summary>
    public static OpcHelp OpcHelp;

    /// <summary>
    /// Connect
    /// </summary>


    public void ConnectToKepServer()
    {
      this.ConnectToKepServer(Properties.Settings.Default.KepServerName,
        Properties.Settings.Default.KepServerGroupName);
    }



    public void ConnectToKepServer(string kepServerName, string groupName)
    {
      groupName += "."; //Needed to get the full path of the tagnames right.
      KepServerOpcTags = new KepServerOPCTags(groupName);

      OpcHelp = new OpcHelp(KepServerOpcTags);
      
      log.DebugFormat("Trying to connect to {0} group: {1}", kepServerName, groupName);

      if (!OpcHelp.Connect(kepServerName, 10000))
      {
        throw new IOException("Could not connect to OPC server");
      }

      OpcHelp.OPCGetData.CreateAllReadTags();
    }

    /// <summary>
    /// Disconnect
    /// </summary>
    public void DisconnectFromKepServer()
    {
      OpcHelp.Disconnect();
      OpcHelp = null;
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

    public static void TestNewResult(double fatValue, int sampleNumberN, int sampleCounter)
    {
      KepServerOpcTags.GetSampleGroup.SampleParametersGroup.Fat.ObjectValue = fatValue;
      KepServerOpcTags.GetSampleGroup.Identifier.ObjectValue = sampleNumberN;
      IOPCTag[] tags = new IOPCTag[2];
      tags = new IOPCTag[] {KepServerOpcTags.GetSampleGroup.SampleParametersGroup.Fat , KepServerOpcTags.GetSampleGroup.Identifier};
      VarEnum[] types = new VarEnum[2];
      types = new VarEnum[] {VarEnum.VT_R4, VarEnum.VT_I2};
      OpcHelp.OPCSetData.SetOPCTags(tags, types);
      Thread.Sleep(20);
      KepServerOpcTags.InstrumentGroup.SampleCounter.ObjectValue = sampleCounter;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.InstrumentGroup.SampleCounter);
    }

    public static void UpdateWatchDogCounter(int counter)
    {
      KepServerOpcTags.ControllerGroup.WatchdogCounter.ObjectValue = counter;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.WatchdogCounter);
    }

    public static void SetCalibrationSample(bool measureCal)
    {
      log.DebugFormat("Setting Calibrationsample to {0}", measureCal);
      KepServerOpcTags.ControllerGroup.CalibrationSample.ObjectValue = measureCal;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.CalibrationSample);
    }

    public static void SetCip(bool cip)
    {
      log.DebugFormat("Setting CIP to {0}", cip);
      KepServerOpcTags.ControllerGroup.CIP.ObjectValue = cip;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.CIP);
    }

    public static void SetWaterRef(bool waterRef)
    {
      log.DebugFormat("Setting waterRef to {0}", waterRef);
      KepServerOpcTags.ControllerGroup.WaterRef.ObjectValue = waterRef;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.WaterRef);
    }
  }
}