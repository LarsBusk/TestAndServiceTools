namespace OPCClient.OPCTags
{
  /// <summary>
  /// Class that represents a SetInstrumentStateGroup
  /// </summary>
  public class MMIISetInstrumentStateGroup : OPCGroup
  {

    public OPCTag<int> EventIdentifier;
    public OPCTag<int> Mode;
    public OPCTag<int> NewProduct;
    public OPCTag<int> ProductCode;
    public OPCTag<int> SampleIdentifier;
    public OPCTag<bool> StartReferenceMeasurement;

    public MMIISetInstrumentStateGroup(string serverPrefix) : base(serverPrefix)
    {
      EventIdentifier = new OPCTag<int>(ServerPrefix, "SetInstrumentState.EventIdentifier");
      OPCTags.Add(EventIdentifier);
      Mode = new OPCTag<int>(ServerPrefix, "SetInstrumentState.Mode");
      OPCTags.Add(Mode);
      NewProduct = new OPCTag<int>(ServerPrefix, "SetInstrumentState.NewProduct");
      OPCTags.Add(NewProduct);
      ProductCode = new OPCTag<int>(ServerPrefix, "SetInstrumentState.ProductCode");
      OPCTags.Add(ProductCode);
      SampleIdentifier = new OPCTag<int>(ServerPrefix, "SetInstrumentState.SampleIdentifier");
      OPCTags.Add(SampleIdentifier);
      StartReferenceMeasurement = new OPCTag<bool>(ServerPrefix, "SetInstrumentState.StartReferenceMeasurement");
      OPCTags.Add(StartReferenceMeasurement);
    }


  }
}