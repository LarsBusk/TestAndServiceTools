namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represents an InstrumentStateProductGroup
    /// </summary>
    public class MMIIGetInstrumentStateProductGroup : OPCGroup
    {
        public OPCTag<string[]> AvailableProducts;

        public MMIIGetInstrumentStateProductGroup(string serverPrefix)
            : base(serverPrefix)
        {
            AvailableProducts = new OPCTag<string[]>(ServerPrefix, "GetInstrumentState.Product.AvailableProducts");
            OPCTags.Add(AvailableProducts);
        }
    }
}
