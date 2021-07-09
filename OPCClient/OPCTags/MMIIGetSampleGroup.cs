using System;

namespace OPCClient.OPCTags
{
  /// <summary>
  /// Class that represents a SampleGroup
  /// </summary>
  public class MMIIGetSampleGroup : OPCGroup
  {
    public OPCTag<int> EventAmount;
    public OPCTag<int> Identifier;
    public OPCTag<string> Number;
    public OPCTag<int> ParameterAmount;
    public OPCTag<int> ProductCode;
    public OPCTag<int> ProductIdentifier;
    public OPCTag<string> ProductName;
    public OPCTag<string> SubType;
    public OPCTag<DateTime> Time;
    public OPCTag<int> Type;
    public OPCTag<int> RawValue01Length;
    public OPCTag<string> RawValue01Name;
    public OPCTag<string> RawValue01Type;
    public OPCTag<object> RawValue01Value;

    public MMIIGetSampleGroup(string serverPrefix) : base(serverPrefix)
    {
      EventAmount = new OPCTag<int>(ServerPrefix, "GetSample.EventAmount");
      OPCTags.Add(EventAmount);
      Identifier = new OPCTag<int>(ServerPrefix, "GetSample.Identifier");
      OPCTags.Add(Identifier);
      Number = new OPCTag<string>(ServerPrefix, "GetSample.Number");
      OPCTags.Add(Number);
      ParameterAmount = new OPCTag<int>(ServerPrefix, "GetSample.ParameterAmount");
      OPCTags.Add(ParameterAmount);
      ProductCode = new OPCTag<int>(ServerPrefix, "GetSample.ProductCode");
      OPCTags.Add(ProductCode);
      ProductIdentifier = new OPCTag<int>(ServerPrefix, "GetSample.ProductIdentifier");
      OPCTags.Add(ProductIdentifier);
      ProductName = new OPCTag<string>(ServerPrefix, "GetSample.ProductName");
      OPCTags.Add(ProductName);
      SubType = new OPCTag<string>(ServerPrefix, "GetSample.SubType");
      OPCTags.Add(SubType);
      Time = new OPCTag<DateTime>(ServerPrefix, "GetSample.Time");
      OPCTags.Add(Time);
      Type = new OPCTag<int>(ServerPrefix, "GetSample.Type");
      OPCTags.Add(Type);
      RawValue01Length = new OPCTag<int>(ServerPrefix, "GetSample.RawValue01.Length");
      OPCTags.Add(RawValue01Length);
      RawValue01Name = new OPCTag<string>(ServerPrefix, "GetSample.RawValue01.Name");
      OPCTags.Add(RawValue01Name);
      RawValue01Type = new OPCTag<string>(ServerPrefix, "GetSample.RawValue01.Type");
      OPCTags.Add(RawValue01Type);
      RawValue01Value = new OPCTag<object>(ServerPrefix, "GetSample.RawValue01.Value");
      OPCTags.Add(RawValue01Value);
    }
  }
}
