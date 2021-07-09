namespace OPCClient.OPCTags
{
  /// <summary>
  /// Class that represents an InstrumentStateGroup
  /// </summary>
  public class MMIIGetInstrumentStateGroup : OPCGroup
  {
    public OPCTag<int[]> CurrentEvents;
    public OPCTag<int> CurrentProductCode;
    public OPCTag<int> EventAmount;
    public OPCTag<int> Mode;
    public OPCTag<int> ProductAmount;
    public OPCTag<bool> ReadyToReceiveSample;
    public OPCTag<bool> ReferenceMeasurementNeeded;
    public OPCTag<bool> RequestedReferenceRunning;

    public MMIIGetInstrumentStateGroup(string serverPrefix) : base(serverPrefix)
    {
      CurrentEvents = new OPCTag<int[]>(ServerPrefix, "GetInstrumentState.CurrentEvents");
      OPCTags.Add(CurrentEvents);
      CurrentProductCode = new OPCTag<int>(ServerPrefix, "GetInstrumentState.CurrentProductCode");
      OPCTags.Add(CurrentProductCode);
      EventAmount = new OPCTag<int>(ServerPrefix, "GetInstrumentState.EventAmount");
      OPCTags.Add(EventAmount);
      Mode = new OPCTag<int>(ServerPrefix, "GetInstrumentState.Mode");
      OPCTags.Add(Mode);
      ProductAmount = new OPCTag<int>(ServerPrefix, "GetInstrumentState.ProductAmount");
      OPCTags.Add(ProductAmount);
      ReadyToReceiveSample = new OPCTag<bool>(ServerPrefix, "GetInstrumentState.ReadyToReceiveSample");
      OPCTags.Add(ReadyToReceiveSample);
      ReferenceMeasurementNeeded = new OPCTag<bool>(ServerPrefix, "GetInstrumentState.ReferenceMeasurementNeeded");
      OPCTags.Add(ReferenceMeasurementNeeded);
      RequestedReferenceRunning = new OPCTag<bool>(ServerPrefix, "GetInstrumentState.RequestedReferenceRunning");
      OPCTags.Add(RequestedReferenceRunning);
    }
  }
}