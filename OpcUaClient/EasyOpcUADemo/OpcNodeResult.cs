using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpcLabs.EasyOpc.UA;

namespace EasyOpcUADemo
{
  public class OpcNodeResult
  {
    public string NodeName;
    public string NodeValue;
    public DateTime ServerDateTime;

    public OpcNodeResult(string nodeName, string nodeValue)
    {
      this.NodeName = nodeName;
      this.NodeValue = nodeValue;
    }

    public OpcNodeResult(string nodeName, UAAttributeData attributeData)
    {
      this.NodeValue = attributeData.DisplayValue();
      this.ServerDateTime = attributeData.ServerTimestamp;
      this.NodeName = nodeName;
    }
  }
}
