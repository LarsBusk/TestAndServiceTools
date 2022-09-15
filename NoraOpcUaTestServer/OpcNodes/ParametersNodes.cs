using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.UaFx;

namespace NoraOpcUaTestServer.OpcNodes
{
    public class ParametersNodes : NodeBase
    {
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
        public List<IOpcNode> Nodes => nodes;

        private const string FolderName = "Parameters";

        private readonly OpcFolderNode parametersFolder;
        private readonly List<IOpcNode> nodes = new List<IOpcNode>();
        private readonly string[] parameters = { "Fat", "Protein", "Lactose", "SNF", "TS" };


        public ParametersNodes(OpcFolderNode parentFolderNode)
        {
            parametersFolder = new OpcFolderNode(parentFolderNode, FolderName);
            SetNodeTree(parentFolderNode, FolderName);
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
            var parameterFolder = new OpcFolderNode(parametersFolder, parameterName);
            var valueNode = CreateOpcUaNode<double>(parameterFolder, $"{parameterName}{NodeSeparator}Result");
            var unitNode = CreateOpcUaNode<string>(parameterFolder, $"{parameterName}{NodeSeparator}Unit");

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
