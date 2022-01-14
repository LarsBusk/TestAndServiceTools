using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
  public class EventNodes : NodeBase
  {
    public List<IOpcNode> Nodes => nodes;
    public OpcDataVariableNode<uint> EventsCount;
    public OpcDataVariableNode<string[]> EventMessages;
    public OpcDataVariableNode<string[]> EventHints;
    public OpcDataVariableNode<int[]> EventCodes;

    private readonly OpcFolderNode eventsFolder;
    private string folderName = "Events";
    private readonly List<IOpcNode> nodes = new List<IOpcNode>();

    public EventNodes(OpcFolderNode parentFolder)
    {
      eventsFolder = new OpcFolderNode(parentFolder, folderName);
      SetNodeTree(parentFolder, folderName);
      GetNodes();
    }

    private void GetNodes()
    {
      EventsCount = GetNode<uint>(eventsFolder, "Count");
      nodes.Add(EventsCount);
      EventMessages = GetNode<string[]>(eventsFolder, "Messages");
      nodes.Add(EventMessages);
      EventCodes = GetNode<int[]>(eventsFolder, "Codes");
      nodes.Add(EventCodes);
      EventHints = GetNode<string[]>(eventsFolder, "Hints");
      nodes.Add(EventHints);
    }
  }
}
