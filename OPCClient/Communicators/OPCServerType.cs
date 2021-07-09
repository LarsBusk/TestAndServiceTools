namespace OPCClient.Communicators
{
  /// <summary>
  /// Which type of Opc server to work with
  /// </summary>
  public enum OPCServerType
  {
    /// <summary>
    /// Work with Opc tags of the MeatMaster II Opc server
    /// </summary>
    MeatMaster = 1,
    /// <summary>
    /// Work with Opc tags of the LinkMaster
    /// </summary>
    LinkMaster = 2,
    /// <summary>
    /// Work with Opc tags of the KepServer
    /// </summary>
    KepServer = 3,
  }
}