using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace EasyOpcUADemo
{
  public class OpcUaClient
  {
    

    private const string DefaultUser = "KepLars";
    private const string DefaultPassWord = "FossAnalytical1234";

    private readonly string serverEndPoint;
    private readonly string @group;
    private EasyUAClient easyUaClient;
    private int handle;
    private readonly OpcNodes opcNodes;


    public event EventHandler<OpcClientEventArgs> RaiseDataChangeEvent; 

    public OpcUaClient(string endPoint, string group, string user, string password)
    {
      this.easyUaClient = new EasyUAClient()
      {
        Isolated = true,
        IsolatedParameters =
        {
          SessionParameters =
          {
            RequireMatchingServerSoftwareCertificates = false,
            UserIdentity =
            {
              UserNameTokenInfo =
              {
                UserName = user,
                Password = password
              }
            }
          }
        }
      };

      this.serverEndPoint = endPoint;
      this.@group = group;
      this.opcNodes = new OpcNodes(serverEndPoint, group);

      easyUaClient.DataChangeNotification += EasyUaClient_DataChangeNotification;
      
      }

    public OpcUaClient(string endPoint, string group)
      : this(endPoint, group, DefaultUser, DefaultPassWord)
    {
    }

    public UAAttributeData ReadSingleValue(string node)
    {
      UAAttributeData attributeData = null;

      attributeData = easyUaClient.Read(serverEndPoint, node);
      
      return attributeData;
    }

    public void SubscribeSingleNode(string node)
    {
      handle = easyUaClient.SubscribeDataChange(serverEndPoint, node,
        100);
    }

    public void SubscribeSampleCounter()
    {
      easyUaClient.SubscribeDataChange(serverEndPoint, "ns=2;s=MMII.PDx.Instrument.SampleCounter", 100);
    }

    public void WriteItem(string nodeId, string valueToWrite)
    {
      easyUaClient.WriteValue(serverEndPoint, nodeId, valueToWrite);
    }

    public void Unsubscribe()
    {
      easyUaClient.UnsubscribeAllMonitoredItems();
    }

    public List<OpcNodeResult> ReadAll()
    {
      var readNodes = ReadMultipleNodes(opcNodes.Nodes);
      List<OpcNodeResult> opcResults = new List<OpcNodeResult>();

      for (int i = 0; i < readNodes.Length - 1; i++)
      {
        opcResults.Add(new OpcNodeResult(opcNodes.AllNodes()[i].Header, readNodes[i].AttributeData));
      }

      return opcResults;
    }

    private UAAttributeDataResult[] ReadMultipleNodes(UAReadArguments[] nodes)
    {
      return easyUaClient.ReadMultiple(nodes);
    }

    private void EasyUaClient_DataChangeNotification([JetBrains.Annotations.NotNull] object sender, [JetBrains.Annotations.NotNull] EasyUADataChangeNotificationEventArgs e)
    {
      OnRaiseDataChangeEvent(new OpcClientEventArgs(e.AttributeData.DisplayValue(), e.Arguments.NodeDescriptor.NodeId.StringIdentifier));
    }

    protected virtual void OnRaiseDataChangeEvent(OpcClientEventArgs e)
    {
      EventHandler<OpcClientEventArgs> handler = RaiseDataChangeEvent;

      if (handler != null)
      {
        handler(this, e);
      }
    }
  }
}
