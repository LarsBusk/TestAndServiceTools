using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
  public class WriteNodes : NodeBase
  {
    public List<IOpcNode> Nodes => nodes;
    public OpcDataVariableNode<bool> Measuring;
    public OpcDataVariableNode<string> Product;
    public OpcDataVariableNode<int> SetMode;
    public OpcDataVariableNode<bool> SetCleanInPlace;

    private readonly OpcFolderNode writeFolder;
    private string folderName = "Write";
    private List<IOpcNode> nodes = new List<IOpcNode>();

    public WriteNodes(OpcFolderNode parentFolder)
    {
      writeFolder = new OpcFolderNode(parentFolder, folderName);
      SetNodeTree(parentFolder, folderName);
      GetNodes();
    }

    private void GetNodes()
    { 
      Measuring = GetNode<bool>(writeFolder, "Measuring");
      nodes.Add(Measuring);
      SetMode = GetNode<int>(writeFolder, "SetMode");
      nodes.Add(SetMode);
      Product = GetNode<string>(writeFolder, "Product");
      nodes.Add(Product);
      SetCleanInPlace = GetNode<bool>(writeFolder, "SetCleanInPlace");
      nodes.Add(SetCleanInPlace);
    }
  }
}
