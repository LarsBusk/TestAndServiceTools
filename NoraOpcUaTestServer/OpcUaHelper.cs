using Opc.UaFx;
using Opc.UaFx.Server;
using System;
using System.Threading;
using NoraOpcUaTestServer.OpcNodes;

namespace NoraOpcUaTestServer
{
  public class OpcUaHelper
  {
    

    public uint HeartBeat => this.noraNodes.ReadNodes.HeartbeatNode.Value;
    public OpcDataVariableNode<double> FatValue => this.noraNodes.ReadNodes.ResultNodes.FatValue;
    public string FatUnit => this.noraNodes.ReadNodes.ResultNodes.FatUnit.Value;
    public double ProteinValue => this.noraNodes.ReadNodes.ResultNodes.ProteinValue.Value;
    public string ProteinUnit => this.noraNodes.ReadNodes.ResultNodes.ProteinUnit.Value;
    public int Mode => this.noraNodes.ReadNodes.Mode.Value;
    public OpcDataVariableNode<string> ProductName => this.noraNodes.ReadNodes.ProductName;
    public OpcDataVariableNode<uint> EventsCount => noraNodes.ReadNodes.EventNodes.EventsCount;
    public string[] EventMessages => noraNodes.ReadNodes.EventNodes.EventMessages.Value;
    public OpcServer Server;
    public OpcDataVariableNode<string> StateNode => noraNodes.ReadNodes.State;
    public OpcDataVariableNode<uint> HeartbeatNode => noraNodes.ReadNodes.HeartbeatNode;

    private readonly NoraNodes noraNodes;
    private readonly CsvHelper csvHelper;
    private DateTime lastSampleDateTime = DateTime.MinValue;


    public OpcUaHelper(string serverName, string homeFolderName = "Foss")
    {
      noraNodes = new NoraNodes(homeFolderName);
      csvHelper = new CsvHelper();

      Server = new OpcServer(
        serverName,
        noraNodes.Nodes);

      noraNodes.ReadNodes.ResultNodes.FatValue.AfterApplyChanges += FatValue_AfterApplyChanges;
    }

    public void StartServer()
    {
      Server.Start();
    }

    public void StopServer()
    {
      Server.Stop();
    }

    public void StartMeasuring(string product)
    {
      SetNodeValue(noraNodes.WriteNodes.Product, product);
      SetNodeValue(noraNodes.WriteNodes.SetMode, 1);
      SetNodeValue(noraNodes.WriteNodes.Measuring, true);
    }

    public void StopMeasuring()
    {
      SetNodeValue(noraNodes.WriteNodes.Measuring, false);
      SetNodeValue(noraNodes.WriteNodes.SetMode, 0);
    }
    
    public void SetCip()
    {
      SetNodeValue(noraNodes.WriteNodes.SetCleanInPlace, !noraNodes.WriteNodes.SetCleanInPlace.Value);
    }

    public void ChangeProduct(string newProduct)
    {
      SetNodeValue<string>(noraNodes.WriteNodes.Product, newProduct);
    }

    public void StartZero()
    {
      SetNodeValue(noraNodes.WriteNodes.SetMode, 4);
    }

    public void StartClean()
    {
      SetNodeValue(noraNodes.WriteNodes.SetMode, 3);
    }

    private void SetNodeValue<T>(OpcDataVariableNode<T> node, object value)
    {
      node.Value = (T) value;
      node.ApplyChanges(Server.SystemContext);
    }

    private void FatValue_AfterApplyChanges(object sender, Opc.UaFx.OpcNodeChangesEventArgs e)
    {
      var node = (OpcDataVariableNode) sender;
      DateTime sampleDateTime = node.Timestamp ?? DateTime.Now;
      double fat = (double) node.Value;
      TimeSpan timeDif = TimeSpan.Zero;

      if (lastSampleDateTime > DateTime.MinValue)
        timeDif = sampleDateTime.Subtract(lastSampleDateTime);

      csvHelper.WriteValues(sampleDateTime, fat, timeDif);
      lastSampleDateTime = sampleDateTime;
    }
  }
}
