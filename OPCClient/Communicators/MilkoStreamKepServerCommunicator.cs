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
  public class MilkoStreamKepServerCommunicator : KepServerCommunicator
  {

    private static readonly ILog log = LogManager.GetLogger(typeof(MilkoStreamKepServerCommunicator));


    public static KepServerMstOPCTags KepServerOpcTags;

    public static void SetCalibrationSample(bool measureCal)
    {
      log.DebugFormat("Setting Calibrationsample to {0}", measureCal);
      KepServerOpcTags.ControllerGroup.CalibrationSample.ObjectValue = measureCal;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.CalibrationSample);
    }

    public static void SetCip(bool cip)
    {
      log.DebugFormat("Setting CIP to {0}", cip);
      KepServerOpcTags.ControllerGroup.Cip.ObjectValue = cip;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.Cip);
    }

    public static void SetWaterRef(bool waterRef)
    {
      log.DebugFormat("Setting waterRef to {0}", waterRef);
      KepServerOpcTags.ControllerGroup.WaterReference.ObjectValue = waterRef;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.WaterReference);
    }
  }
}