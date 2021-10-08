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
  public class ProFossKepServerCommunicator
  {

    private static readonly ILog log = LogManager.GetLogger(typeof(ProFossKepServerCommunicator));


    public static KepServerPFOPCTags KepServerOpcTags;

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
      KepServerOpcTags = new KepServerPFOPCTags(groupName);

      OpcHelp = new OpcHelp(KepServerOpcTags);
      
      log.DebugFormat("Trying to connect to {0} group: {1}", kepServerName, groupName);

      if (!OpcHelp.Connect(kepServerName, 100))
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
  }
}