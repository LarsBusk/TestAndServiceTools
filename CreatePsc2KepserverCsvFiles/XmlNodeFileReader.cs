using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreatePsc2KepserverCsvFiles
{
    public class XmlNodeFileReader
    {
        public IEnumerable<OpcUaNodeContent> GetOpcUaNodes(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            XNamespace ns = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd";
            var nodeElements = doc.Root.Elements(ns + "UAVariable");
            var nodes = nodeElements.Select(e =>
                new OpcUaNodeContent(
                    e.Attribute("NodeId").Value,
                    e.Attribute("DataType").Value,
                    e.Attributes("ArrayDimensions").Any())).ToList();

            return nodes;
        }

        public struct OpcUaNodeContent
        {
            public OpcUaNodeContent(string nodeIdentifier, string type, bool isArray)
            {
                var tempNode = nodeIdentifier.Substring(nodeIdentifier.IndexOf('.') + 1);
                NodeIdentifier = tempNode.Substring(tempNode.IndexOf('.') + 1);
                Type = type;
                IsArray = isArray;
            }

            public string NodeIdentifier;
            public string Type;
            public bool IsArray;
        }
    }
}
