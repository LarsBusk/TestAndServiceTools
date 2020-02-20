

namespace MstOpcClient
{
  /// <summary>
  /// </summary>
  public enum MatildeStateTypes
  {
    /// <summary>
    /// </summary>
    Start = 0,

    /// <summary>
    /// </summary>
    Connecting = 1,

    /// <summary>
    /// </summary>
    HardwareSelftesting = 2,

    /// <summary>
    /// </summary>
    FringeCalibration = 3,

    /// <summary>
    /// </summary>
    StartUpNotCompleted = 4,

    /// <summary>
    /// </summary>
    Stopped = 5,

    /// <summary>
    /// </summary>
    Measuring = 6,

    /// <summary>
    /// </summary>
    SelfTestFailed = 7,

    /// <summary>
    /// </summary>
    Error = 8,

    /// <summary>
    /// </summary>
    WaitForInstrument = 9,

    /// <summary>
    /// 
    /// </summary>
    Updating = 11,

    /// <summary>
    /// </summary>
    WaitingForMatlab = 12,

    /// <summary>
    /// </summary>
    ServiceMode = 13,

    /// <summary>
    /// </summary>
    AirMeasuring = 14,

    /// <summary>
    /// </summary>
    StartDelayedMeasurement = 15,

    /// <summary>
    /// </summary>
    Terminated = 16,

    /// <summary>
    /// </summary>
    WaitForInstrumentDiscovery = 17,

    /// <summary>
    /// </summary>
    IfuAdjusting = 18,

    /// <summary>
    /// </summary>
    Canceling = 19,

    /// <summary>
    /// </summary>
    TestingMotorDrift = 20,

    /// <summary>
    /// </summary>
    ReferenceMeasuring = 21,

    /// <summary>
    /// </summary>
    Disconnected = 22,

    /// <summary>
    /// </summary>
    CIPDetectedError = 23,

    /// <summary>
    /// Updating measurement state (used when switching product on fly)
    /// </summary>
    SwitchingProduct = 24
  }
}
