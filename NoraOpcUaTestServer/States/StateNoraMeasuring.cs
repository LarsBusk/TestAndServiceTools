using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoraOpcUaTestServer.States
{
  public class StateNoraMeasuring : IState
  {
    public string StateName => "Measuring";
    private OpcUaHelper helper;

    public StateNoraMeasuring(OpcUaHelper opcUaHelper)
    {
      helper = opcUaHelper;
      var currentProduct = helper.ProductName.Value;
      helper.StartMeasuring(currentProduct);
    }

    public void ChangeProduct(string product)
    {
      helper.ChangeProduct(product);
    }

    public void OpenSettings()
    {
    }

    public void StartStopMeasuring(string product)
    {
      helper.StopMeasuring();
    }

    public void StartRinse()
    {
    }

    public void StartServer()
    {
    }

    public void StartZero()
    {
    }

    public void StopServer()
    {
      helper.StopServer();
    }
  }
}
