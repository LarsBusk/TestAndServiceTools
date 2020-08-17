using System;

namespace ProfossOpcClient
{
  /// <summary>
  /// TODO: Copy/Pasted from Plugins.ProFoss so we dont need to drag in a lot of assemblies as references. Better fix is pending!
  /// </summary>
  /// <summary>
  /// </summary>
  public enum ProFossStateTypes
  {
    /// <summary>
    /// </summary>
    Start = 0,

    /// <summary>
    /// </summary>
    Connecting = 1,

    /// <summary>
    /// </summary>
    Stopped = 2,

    /// <summary>
    /// </summary>
    Measuring = 3,

    /// <summary>
    /// </summary>
    Error = 4,

    /// <summary>
    /// </summary>
    Initializing = 5,

    /// <summary>
    /// </summary>
    WaitForDataBaseState = 6,

    /// <summary>
    /// </summary>
    PerformanceTestState = 7,

    /// <summary>
    /// </summary>
    StartUpTestState = 8,

    /// <summary>
    /// </summary>
    Canceling = 9,

    /// <summary>
    /// </summary>
    WaitForInstrumentDiscovery = 10,

    /// <summary>
    /// </summary>
    Disconnected = 11,

    /// <summary>
    /// </summary>
    ChangingLamp = 12,

    /// <summary>
    /// </summary>
    Updating = 13,

    /// <summary>
    /// </summary>
    InitializingInstrument = 15,

    /// <summary>
    /// Updating measurement state (used when switching product on fly)
    /// </summary>
    SwitchingProduct = 16,
  }
}
