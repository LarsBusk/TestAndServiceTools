using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
  public class NodeBase
  {
    public static string NodeSeparator = Properties.Settings.Default.NodeSeparator;
    public static string OpcNameSpace = Properties.Settings.Default.OpcNameSpace;

    public List<string> NodeTree = new List<string>();

    public OpcDataVariableNode<T> GetNode<T>(OpcFolderNode folder, string name)
    {
      return new OpcDataVariableNode<T>(folder, name, NodeId(name));
    }

    public OpcDataVariableNode<T> GetNode<T>(OpcFolderNode folder, string name, T value)
    {
      return new OpcDataVariableNode<T>(folder, name, NodeId(name), value);
    }

    public void SetNodeTree(OpcFolderNode parentFolder, string folderName)
    {
      NodeTree.AddRange(parentFolder.Id.ValueAsString.Split('/'));
      NodeTree.Add(folderName);
    }

    private OpcNodeId NodeId(string node)
    {
      List<string> nodeTree = new List<string>(NodeTree);
      nodeTree.Add(node);
      string name = string.Join(NodeSeparator, nodeTree);
      return $"ns={OpcNameSpace};s={name}";
    }
  }
}
