using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
  public class ReadNodes : NodeBase
  {
    public ResultNodes ResultNodes;
    public EventNodes EventNodes;

    public OpcDataVariableNode<uint> HeartbeatNode;
    public OpcDataVariableNode<int> Mode;
    public OpcDataVariableNode<string> State;
    public OpcDataVariableNode<string> ProductName;
    public OpcDataVariableNode<string> SerialNumber;
    public List<IOpcNode> Nodes => nodes;

    private OpcFolderNode readFolder;
    private string folderName = "Read";
    private List<IOpcNode> nodes = new List<IOpcNode>();


    public ReadNodes(OpcFolderNode parentFolder)
    {
      readFolder = new OpcFolderNode(parentFolder, folderName);
      SetNodeTree(parentFolder, folderName);
      GetNodes();
    }

    private void GetNodes()
    {
      HeartbeatNode = GetNode<uint>(readFolder, "Heartbeat");
      nodes.Add(HeartbeatNode);
      Mode = GetNode<int>(readFolder, "Mode");
      nodes.Add(Mode);
      nodes.Add(GetNode<string>(readFolder, "Product"));
      ProductName = GetNode<string>(readFolder, "ProductName");
      nodes.Add(ProductName);
      State = GetNode<string>(readFolder, "State", "Disconnected");
      nodes.Add(State);
      SerialNumber = GetNode<string>(readFolder, "Serial number");
      nodes.Add(SerialNumber);
      
      //Sub groups
      ResultNodes = new ResultNodes(readFolder);
      nodes.AddRange(ResultNodes.Nodes);
      EventNodes = new EventNodes(readFolder);
      nodes.AddRange(EventNodes.Nodes);
    }
  }
}
