using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpcLabs.EasyOpc.UA;
using log4net;
using OpcLabs.EasyOpc.UA.Engine;
using OpcLabs.EasyOpc.UA.OperationModel;

namespace OpcUaTestClient
{
  public class OpcUaClient
  {
    private const string DefaultUser = "KepLars";
    private const string DefaultPassWord = "FossAnalytical1234";

    private readonly string serverEndPoint;
    private readonly EasyUAClient easyUaClient;
    private int handle;
    private readonly OpcNodes opcNodes;

    private static readonly ILog log = LogManager.GetLogger(typeof(OpcUaClient));


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
            EndpointSelectionPolicy = UAEndpointSelectionPolicy.NoMessageSecurity,
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
      this.opcNodes = new OpcNodes(serverEndPoint, group);

      easyUaClient.DataChangeNotification += EasyUaClient_DataChangeNotification;

      log.Debug("Uaclient is initiated.");
    }

    public OpcUaClient(string endPoint, string group)
      : this(endPoint, group, DefaultUser, DefaultPassWord)
    {
    }

    public UAAttributeData ReadSingleValue(string node)
    {
      UAAttributeData attributeData = null;

      attributeData = easyUaClient.Read(serverEndPoint, node);
      log.Debug($"Value read from {node}: {attributeData.DisplayValue()}");

      return attributeData;
    }

    public void SubscribeSingleNode(string node)
    {
      handle = easyUaClient.SubscribeDataChange(serverEndPoint, node,
        100);
    }

    /// <summary>
    /// Uses the SubscribeDataChange method. This seem to a stable way of detecting changes in the sample counter.
    /// </summary>
    /// <param name="samplingInterval"></param>
    public void SubscribeSampleCounter(int samplingInterval = 100)
    {
      string counterNode = opcNodes.GetNodeByName("SampleCounter").Address;
      easyUaClient.SubscribeDataChange(serverEndPoint, counterNode, samplingInterval);
    }

    public void SubscribeMultipleNodes()
    {
      EasyUAMonitoredItemArguments[] arguments =
        opcNodes.ReadNodes.Select(a => new EasyUAMonitoredItemArguments(a)).ToArray();
      easyUaClient.SubscribeMultipleMonitoredItems(arguments);
    }

    /// <summary>
    /// Uses the subscribeMonitoredItem method. Does not seem to be stable, misses samples very often.
    /// </summary>
    public void Subs()
    {
      EasyUAMonitoredItemArguments arg = new EasyUAMonitoredItemArguments()
      {
        EndpointDescriptor = serverEndPoint,
        NodeDescriptor = opcNodes.GetNodeByName("SampleCounter").Address,
        SubscriptionParameters =
        {
          PublishingInterval = 0
        }
      };

      easyUaClient.SubscribeMonitoredItem(arg);
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
      DateTime startRead= DateTime.Now;
      var readNodes = ReadMultipleNodes(opcNodes.ReadNodes);
      log.Info($"Reading {readNodes.Length} nodes took {DateTime.Now.Subtract(startRead).TotalMilliseconds}");

      List<OpcNodeResult> opcResults = new List<OpcNodeResult>();

      for (int i = 0; i < readNodes.Length - 1; i++)
      {
        opcResults.Add(new OpcNodeResult(opcNodes.AllReadNodes()[i].Header, readNodes[i].AttributeData));
      }

      return opcResults;
    }

    public Dictionary<string, UAAttributeData> ReadAll2()
    {
      DateTime startRead = DateTime.Now;
      var readNodes = ReadMultipleNodes(opcNodes.ReadNodes);
      log.Info($"Reading {readNodes.Length} nodes took {DateTime.Now.Subtract(startRead).TotalMilliseconds}");

      Dictionary<string, UAAttributeData> opcResults = new Dictionary<string, UAAttributeData>();

      for (int i = 0; i < readNodes.Length - 1; i++)
      {
        opcResults.Add(opcNodes.AllReadNodes()[i].Header, readNodes[i].AttributeData);
      }

      return opcResults;
    }

    private UAAttributeDataResult[] ReadMultipleNodes(UAReadArguments[] nodes)
    {
      return easyUaClient.ReadMultiple(nodes);
    }

    private void EasyUaClient_DataChangeNotification([JetBrains.Annotations.NotNull] object sender, [JetBrains.Annotations.NotNull] EasyUADataChangeNotificationEventArgs e)
    {
      OnRaiseDataChangeEvent(new OpcClientEventArgs()
      {
        NewValue = e.AttributeData.DisplayValue(), 
        NodeDescription = e.Arguments.NodeDescriptor.NodeId.StringIdentifier
      });
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
