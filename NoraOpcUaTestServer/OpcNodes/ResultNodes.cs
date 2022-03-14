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
    public OpcDataVariableNode<double> LactoseValue;
    public OpcDataVariableNode<string> LactoseUnit;
    public OpcDataVariableNode<double> SnfValue;
    public OpcDataVariableNode<string> SnfUnit;
    public OpcDataVariableNode<double> TsValue;
    public OpcDataVariableNode<string> TsUnit;
    public OpcDataVariableNode<string> SampleNumber;

    private readonly OpcFolderNode resultFolder;
    private string folderName = "Result";
    private List<IOpcNode> nodes = new List<IOpcNode>();
    private string[] parameters = new string[] {"Fat", "Protein", "Lactose", "SNF", "TS"};

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

      SampleNumber = GetNode<string>(resultFolder, "Sample number");
      nodes.Add(SampleNumber);
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
        case "Lactose":
          LactoseValue = valueNode;
          LactoseUnit = unitNode;
          break;
        case "SNF":
          SnfValue = valueNode;
          SnfUnit = unitNode;
          break;
        case "TS":
          TsValue = valueNode;
          TsUnit = unitNode;
          break;
      }

      nodes.Add(valueNode);
      nodes.Add(unitNode);

      return nodes;
    }
  }
}

