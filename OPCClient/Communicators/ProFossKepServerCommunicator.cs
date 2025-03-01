﻿using System;
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
  public class ProFossKepServerCommunicator : KepServerCommunicator
  {

    private static readonly ILog log = LogManager.GetLogger(typeof(ProFossKepServerCommunicator));


    public static KepServerPFOPCTags KepServerOpcTags;


    public static void SetCalibrationSample(bool measureCal)
    {
      log.DebugFormat("Setting Calibrationsample to {0}", measureCal);
      KepServerOpcTags.ControllerGroup.CalibrationSample.ObjectValue = measureCal;
      OpcHelp.OPCSetData.SetOneOPCTag(KepServerOpcTags.ControllerGroup.CalibrationSample);
    }

    public static void SetRegistrationToCalSample(int registration)
    {
        while (!KepServerOpcTags.InstrumentGroup.DoingCalibrationSample.Value)
        {
            KepServerOpcTags.ControllerGroup.SampleRegistrationGroup.PreRegistration01.ObjectValue = registration;
            OpcHelp.OPCSetData.SetOneOPCTag(
                KepServerOpcTags.ControllerGroup.SampleRegistrationGroup.PreRegistration01);
            Thread.Sleep(1000);
        }
        KepServerOpcTags.ControllerGroup.SampleRegistrationGroup.PreRegistration01.ObjectValue = null;
        OpcHelp.OPCSetData.SetOneOPCTag(
            KepServerOpcTags.ControllerGroup.SampleRegistrationGroup.PreRegistration01);
        }
  }
}