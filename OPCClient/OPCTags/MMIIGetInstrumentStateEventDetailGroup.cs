namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represents an InstrumentStateEventDetailGroup
    /// </summary>
    public class MMIIGetInstrumentStateEventDetailGroup : OPCGroup
    {
        public OPCTag<string> Hint;
        public OPCTag<int> Identifier;
        public OPCTag<string> Message;
        public OPCTag<int> Severity;
        public OPCTag<string> Source;

        public MMIIGetInstrumentStateEventDetailGroup(string serverPrefix)
            : base(serverPrefix)
        {
            Hint = new OPCTag<string>(ServerPrefix, "GetInstrumentState.EventDetail.Hint");
            OPCTags.Add(Hint);
            Identifier = new OPCTag<int>(ServerPrefix, "GetInstrumentState.EventDetail.Identifier");
            OPCTags.Add(Identifier);
            Message = new OPCTag<string>(ServerPrefix, "GetInstrumentState.EventDetail.Message");
            OPCTags.Add(Message);
            Severity = new OPCTag<int>(ServerPrefix, "GetInstrumentState.EventDetail.Severity");
            OPCTags.Add(Severity);
            Source = new OPCTag<string>(ServerPrefix, "GetInstrumentState.EventDetail.Source");
            OPCTags.Add(Source);
        }
    }
}