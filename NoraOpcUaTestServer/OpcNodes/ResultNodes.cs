using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
  public class ResultNodes : NodeBase
  {
    public List<IOpcNode> Nodes => nodes;
    public OpcDataVariableNode<double> FatValue;
    public OpcDataVariableNode<string> FatUnit;
    public OpcDataVariableNode<double> ProteinValue;
    public OpcDataVariableNode<string> ProteinUnit;

    private readonly OpcFolderNode resultFolder;
    private string folderName = "Result";
    private List<IOpcNode> nodes = new List<IOpcNode>();
    private string[] parameters = new string[] {"Fat", "Protein"};

    public ResultNodes(OpcFolderNode parentFolder)
    {
      resultFolder = new OpcFolderNode(parentFolder, folderName);
      SetNodeTree(parentFolder, folderName);
      GetNodes();
    }

    private void GetNodes()
    {
      foreach (var parameter in parameters)
      {
        nodes.AddRange(ResultFolderNodes(parameter));
      }
    }

    private List<IOpcNode> ResultFolderNodes(string parameterName)
    {
      var nodes = new List<IOpcNode>();
      var parameterFolder = new OpcFolderNode(resultFolder, parameterName);
      var valueNode = GetNode<double>(parameterFolder, $"{parameterName}{NodeSeparator}Value");
      var unitNode = GetNode<string>(parameterFolder, $"{parameterName}{NodeSeparator}Unit");

      switch (parameterName)
      {
        case "Fat":
          FatValue = valueNode;
          FatUnit = unitNode;
          break;
        case "Protein":
          ProteinValue = valueNode;
          ProteinUnit = unitNode;
          break;
      }

      nodes.Add(valueNode);
      nodes.Add(unitNode);

      return nodes;
    }
  }
}

