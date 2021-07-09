namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represents an OpcServerStateGroup
    /// </summary>
    public class MMIIGetOpcServerStateGroup : OPCGroup
    {
        public OPCTag<string> NovaVersion;
        public OPCTag<int> OpcHeartbeatCounter;
        public OPCTag<int> SampleCounter;

        public MMIIGetOpcServerStateGroup(string serverPrefix): base(serverPrefix)
        {
            NovaVersion = new OPCTag<string>(ServerPrefix, "GetOpcServerState.Nova Version");
            OPCTags.Add(NovaVersion);
            OpcHeartbeatCounter = new OPCTag<int>(ServerPrefix, "GetOpcServerState.OpcHeartbeatCounter");
            OPCTags.Add(OpcHeartbeatCounter);
            SampleCounter = new OPCTag<int>(ServerPrefix, "GetOpcServerState.SampleCounter");
            OPCTags.Add(SampleCounter);

        }

    }
}
