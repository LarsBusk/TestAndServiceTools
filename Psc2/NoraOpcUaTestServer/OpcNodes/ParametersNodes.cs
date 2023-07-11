﻿using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
    public class ParametersNodes : NodeBase
    {
        public OpcDataVariableNode<float> FatValue;
        public OpcDataVariableNode<string> FatUnit;
        public OpcDataVariableNode<float> ProteinValue;
        public OpcDataVariableNode<string> ProteinUnit;
        public OpcDataVariableNode<float> LactoseValue;
        public OpcDataVariableNode<string> LactoseUnit;
        public OpcDataVariableNode<float> SnfValue;
        public OpcDataVariableNode<string> SnfUnit;
        public OpcDataVariableNode<float> TsValue;
        public OpcDataVariableNode<string> TsUnit;
        public List<IOpcNode> Nodes => nodes;
        
        private readonly OpcFolderNode parametersFolder;
        private readonly List<IOpcNode> nodes = new List<IOpcNode>();
        private readonly string[] parameters = { "Fat", "Protein", "Lactose", "SNF", "TS" };


        public ParametersNodes(OpcFolderNode parentFolderNode)
        {
            this.FolderName = "Parameters";
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
            var valueNode = CreateOpcUaNode<float>(parameterFolder, $"{parameterName}{NodeSeparator}Result");
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
