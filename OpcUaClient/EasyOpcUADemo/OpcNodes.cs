using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace OpcUaTestClient
{
  public class OpcNodes
  {
    public UAReadArguments[] ReadNodes;


    private readonly string serverEndPoint;
    private readonly List<OpcNode> opcReadNodeList;
    private readonly List<OpcNode> opcWriteNodeList;
    private readonly string prefix;

    public OpcNodes(string serverEndPoint, string group)
    {
      this.serverEndPoint = serverEndPoint;
      prefix = $"ns=2;s={group}";
      opcReadNodeList = AllReadNodes();
      opcWriteNodeList = Controller();
      CreateNodes();
    }

    private void CreateNodes()
    {
      List<UAReadArguments> nodeList = new List<UAReadArguments>();

      foreach (var node in AllReadNodes())
      {
        nodeList.Add(new UAReadArguments(serverEndPoint, node.Address));
      }

      ReadNodes = nodeList.ToArray();
    }

    public List<OpcNode> AllReadNodes()
    {
      List<OpcNode> nodes = new List<OpcNode>();

      nodes.AddRange(InstrumentGroup());
      nodes.AddRange(SampleGroup());

      return nodes;
    }

    public OpcNode GetNodeByName(string name)
    {
      return opcReadNodeList.First(n => n.Header.Equals(name));
    }

    #region Opc nodes


    private List<OpcNode> InstrumentGroup()
    {
      List<OpcNode> nodes = new List<OpcNode>();

      string gr = "Instrument";

      nodes.Add(new OpcNode("Watchdog", $"{prefix}.{gr}.WatchdogCounter"));
      nodes.Add(new OpcNode("SampleCounter", $"{prefix}.{gr}.SampleCounter"));
      nodes.Add(new OpcNode("Mode", $"{prefix}.{gr}.Mode"));
      nodes.Add(new OpcNode("CurrentProductCode", $"{prefix}.{gr}.CurrentProductCode"));
      nodes.Add(new OpcNode("CurrentProductName", $"{prefix}.{gr}.CurrentProductName"));

      return nodes;
    }

    private List<OpcNode> SampleGroup()
    {
      List<OpcNode> nodes = new List<OpcNode>();

      string gr = "Sample";

      nodes.Add(new OpcNode("SampleNumber", $"{prefix}.{gr}.Number"));
      nodes.Add(new OpcNode("Year", $"{prefix}.{gr}.Year"));
      nodes.Add(new OpcNode("Month", $"{prefix}.{gr}.Month"));
      nodes.Add(new OpcNode("Day", $"{prefix}.{gr}.Day"));
      nodes.Add(new OpcNode("Hour", $"{prefix}.{gr}.Hour"));
      nodes.Add(new OpcNode("Minute", $"{prefix}.{gr}.Minute"));
      nodes.Add(new OpcNode("Second", $"{prefix}.{gr}.Second"));
      nodes.Add(new OpcNode("Msec", $"{prefix}.{gr}.Msec"));
      nodes.Add(new OpcNode("CalibrationSample", $"{prefix}.{gr}.CalibrationSample"));
      nodes.AddRange(Parameters());

      return nodes;
    }

    private List<OpcNode> Parameters()
    {
      List<OpcNode> nodes = new List<OpcNode>();

      string gr = "Sample.Parameters";

      string[] parameters = {"Fat", "Weight", "Bone", "Metal"};

      foreach (var parameter in parameters)
      {
        nodes.Add(new OpcNode(parameter, $"{prefix}.{gr}.{parameter}.Result"));
      }

      return nodes;
    }

    private List<OpcNode> Controller()
    {
      List<OpcNode> nodes = new List<OpcNode>();

      string gr = "Controller";

      nodes.Add(new OpcNode("ProductCodeN", $"{prefix}.{gr}.ProductCodeN"));
      nodes.Add(new OpcNode("StartMeasuring", $"{prefix}.{gr}.StartMeasuring"));
      nodes.Add(new OpcNode("StartReferenceMeasurement", $"{prefix}.{gr}.StartReferenceMeasurement"));
      nodes.Add(new OpcNode("WatchdogCounter", $"{prefix}.{gr}.WatchdogCounter"));

      return nodes;
    }

    #endregion
  }
}
