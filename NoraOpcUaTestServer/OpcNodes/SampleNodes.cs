using Opc.UaFx;
using System.Collections.Generic;

namespace NoraOpcUaTestServer.OpcNodes
{
    public class SampleNodes : NodeBase
    {
        public List<IOpcNode> Nodes => nodes;
        public ParametersNodes ParametersNodes;
        public OpcDataVariableNode<string> SampleNumber;
        public OpcDataVariableNode<string> SampleregistrationValue;

        private readonly OpcFolderNode sampleFolder;
        private string folderName = "Sample";
        private readonly List<IOpcNode> nodes = new List<IOpcNode>();

        public SampleNodes(OpcFolderNode parentFolder)
        {
            sampleFolder = new OpcFolderNode(parentFolder, folderName);
            SetNodeTree(parentFolder, folderName);
            GetNodes();
        }

        private void GetNodes()
        {
            SampleNumber = CreateOpcUaNode<string>(sampleFolder, "Number", nodes);
            SampleregistrationValue = CreateOpcUaNode<string>(sampleFolder, $"Registration{NodeSeparator}Value", nodes);

            ParametersNodes = new ParametersNodes(sampleFolder);
            nodes.AddRange(ParametersNodes.Nodes);
        }
    }
}

