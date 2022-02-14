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

      Opc.UaFx.Licenser.LicenseKey =
        "AALSA4IRQPJKOGVQOZP32DTKRRNAIWS3CQLTG7RJEPUAZGVQG6NPQK2OL4DOJNVLSSUDQOEUY5KDHHJWYQSTXUITOEOGOOFL2R5TEIIMCGFE5JV6CQM7TDVFY35SPAB" +
        "5T4YNCIPWM2Y7YCY2ZLFSWL5ZU64WK3J4M7AL7CCMS7SPGXUJ22YFGCJUV6F5OZALRVWJ5W73O6CQUGPEFZQJVHYZS3ORBJ75O3BS6N2JM75CCQTK5V6NIQOUB2PIHK" +
        "C6XIA7OU6PYI6NX5XAABZ7QGSNRZICR44DL5OGS2DXUQV4JBDAXDLXYK3VDBPDEFEUR7E2CBVAU4BI6I2EYJ3MRUNYTQK5UQXDKCOEMKZW52XMK3X27YNRPMNPNSSJF" +
        "LT737QGAJILKL2KCQFSW4PSN7BXXGT3GUQO4BBL7MUKZ5EUTQRE3DTAQATVRPL427ZPZJOLBNDGUOGH6L4SH34PFHHANIG2IKNLPVN3OFNKHFHA4ZFFKOV5W2SBLCMM" +
        "7JFAGAA7VH6AW56COVRCXJ5OWACCUVQ7OBRZV5TG3QODO67J444B7MALRM2OV7KZ5RG7FJLXZXQNWKTG7ZRHSNNRMVOMLI37IEOSO4E5FN5YRZKGZMAJHWYIKNZ7TPR" +
        "IRHTTZ2ZJCAVWIIYP3O2WI5RQQ3QZT5YIN477RSEML6AX226MIGNWMLYAHJNC6IDLQQF2E5VAQCTQYCJI7CH3NOWYJDANMP5RA74LVYMRAX326BZ4S3MPU6SC6RRV7C" +
        "HKBAPKEU6YE464ZFRQ7IPACBBUMKZ22P6ZEP4D3AJOQU4P4EGRTNDNJ7QVIS4OFBKYWNLN4FE6L6ASYF2QMDRXD3AM2OJMW4ZVQ7LNFVRMEVKAQX7HYYBWXGCDKML57" +
        "64TEQITT3TGRWNJB7HDBEZYK3UCBVDXQ7BTWZT6PGS2COL2ZHKMK6O3LGKUB5KXRYSQYM76SAWOANBS7FAPNYE2O6SYOIAZRQQAAHK5EDDYR3XVMGDQHGTESGEDTVQZ" +
        "VSBANGDJBTYCHKC7TILXWXJP64DDSDVSNAAWE2AF4KXDJFUYJNVIMEEDMLCJXVVSH27QB4NT3U6YPEEAD62NKXCU2H3MY5T2DHHC2NHCR2AOZJFHNASEBB7OLZ32GLJ" +
        "APLH3XEINORMCAUJJL6H3X2ODOPPLDBPL5T6HPS7EENJJAKWSZV622J65FXMI2QZCWEGAAOEV6A56FSAHNWUS3MFPBMBB";

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
