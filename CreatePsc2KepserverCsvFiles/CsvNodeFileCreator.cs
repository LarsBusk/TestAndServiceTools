using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePsc2KepserverCsvFiles
{
    public class CsvNodeFileCreator
    {
        private int stringAddress = 1;
        private int numberAddress = 1;

        public void CreateCsvFiles(IEnumerable<XmlNodeFileReader.OpcUaNodeContent> nodeContents)
        {
            CreateCsvFile("Psc2KepServerStandard.csv", nodeContents, true);
            CreateCsvFile("Psc2KepServerMemoryBased.csv", nodeContents, false);
        }

        private void CreateCsvFile(string fileName, IEnumerable<XmlNodeFileReader.OpcUaNodeContent> nodeContents,
            bool isStandard)
        {
            CreateNewFile(fileName);
            var nodes = nodeContents.Select(n => CreateLine(n, isStandard));
            File.AppendAllLines(fileName, nodes);
        }

        private void CreateNewFile(string fileName)
        {
            var headers =
                "Tag Name,Address,Data Type,Respect Data Type,Client Access,Scan Rate,Scaling,Raw Low,Raw High,Scaled Low," +
                "Scaled High,Scaled Data Type,Clamp Low,Clamp High,Eng Units,Description,Negate Value\n";
            File.WriteAllText(fileName, headers);
        }

        private string CreateLine(XmlNodeFileReader.OpcUaNodeContent nodeContent, bool isStandard)
        {
            var nodeType = GetType(nodeContent.Type);
            var nodeIdentifier = nodeContent.NodeIdentifier;
            var address = isStandard ? "?" : nodeContent.IsArray ? "?" : NextAddress(nodeType);
            return $"\"{nodeIdentifier}\",\"{address}\",{nodeType},1,R/W,100,,,,,,,,,,\"\",";
        }

        private string GetType(string typeName)
        {
            switch (typeName)
            {
                case "Int32":
                    return "Long";
                case "UInt32":
                    return "DWord";
                case "UInt16":
                    return "Word";
                default:
                    return typeName;

            }
        }

        private string NextAddress(string type)
        {
            string address;

            switch (type)
            {
                case "String":
                    address = $"S{stringAddress:D5}";
                    stringAddress += 2;
                    break;
                case "Boolean":
                    address = $"D{numberAddress:D5}.1";
                    numberAddress += 2;
                    break;
                case "DateTime":
                    address = "?";
                    break;
                case "DWord":
                    address = $"D{numberAddress:D5}";
                    numberAddress += 4;
                    break;
                case "Long":
                    address = $"D{numberAddress:D5}";
                    numberAddress += 4;
                    break;
                default:
                    address = $"D{numberAddress:D5}";
                    numberAddress += 2;
                    break;
            }
            
            return address;
        }
    }
}
