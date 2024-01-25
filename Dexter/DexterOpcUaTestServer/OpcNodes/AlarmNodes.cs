using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.UaFx;

namespace DexterOpcUaTestServer.OpcNodes
{
    public class AlarmNodes : NodeBase  
    {
        public List<IOpcNode> Nodes => nodes;
        public OpcDataVariableNode<bool> ReferenceMeasurementNeeded;
        public OpcDataVariableNode<uint> Count;
        public OpcDataVariableNode<bool> SystemAlarms;
        private readonly OpcFolderNode alarmsFolder;
        private List<IOpcNode> nodes = new List<IOpcNode>();

        public AlarmNodes(OpcFolderNode parentFolder)
        {
            this.FolderName = "Alarms";
            alarmsFolder = new OpcFolderNode(parentFolder, FolderName);
            SetNodeTree(parentFolder, FolderName);
            GetNodes();
        }

        public void GetNodes()
        {
            ReferenceMeasurementNeeded = CreateOpcUaNode<bool>(alarmsFolder, "ReferenceMeasurementNeeded", nodes);
            Count = CreateOpcUaNode<uint>(alarmsFolder, "Count", nodes);
            SystemAlarms = CreateOpcUaNode<bool>(alarmsFolder, "SystemAlarms", nodes);
        }
    }
}
