namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represents a SampleEventDetailGroup
    /// </summary>
    public class MMIIGetSampleEventDetailGroup : OPCGroup
    {
        public OPCTag<string> Hint;
        public OPCTag<int> Identifier;
        public OPCTag<string> Message;
        public OPCTag<int> Severity;
        public OPCTag<string> Source;

        public MMIIGetSampleEventDetailGroup(string serverPrefix): base(serverPrefix)
        {
            Hint = new OPCTag<string>(ServerPrefix, "GetSample.EventDetail.Hint");
            OPCTags.Add(Hint);
            Identifier = new OPCTag<int>(ServerPrefix, "GetSample.EventDetail.Identifier");
            OPCTags.Add(Identifier);
            Message = new OPCTag<string>(ServerPrefix, "GetSample.EventDetail.Message");
            OPCTags.Add(Message);
            Severity = new OPCTag<int>(ServerPrefix, "GetSample.EventDetail.Severity");
            OPCTags.Add(Severity);
            Source = new OPCTag<string>(ServerPrefix, "GetSample.EventDetail.Source");
            OPCTags.Add(Source);
        }

    }
}
