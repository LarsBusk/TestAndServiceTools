using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
  public class NoraNodes
  {
    #region Public nodegroups

    //Nodegroups
    public ReadNodes ReadNodes;
    public WriteNodes WriteNodes;

    #endregion


    public List<IOpcNode> Nodes => this.nodes;

    private List<IOpcNode> nodes;
    private OpcFolderNode homeFolder;

    public NoraNodes(string homeFolderName = "Foss")
    {
      nodes = new List<IOpcNode>();
      homeFolder = new OpcFolderNode(homeFolderName);
      GetNodes();
    }

    private void GetNodes()
    {
      ReadNodes = new ReadNodes(homeFolder);
      nodes.AddRange(ReadNodes.Nodes);
      WriteNodes = new WriteNodes(homeFolder);
      nodes.AddRange(WriteNodes.Nodes);
    }
  }
}
