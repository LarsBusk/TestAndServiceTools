using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoraOpcUaTestServer.States
{
  public class StateNoraStopped : IState
  {
    public string StateName => "Stopped";
    private OpcUaHelper helper;

    public StateNoraStopped(OpcUaHelper opcUaHelper)
    {
      helper = opcUaHelper;
      helper.StopMeasuring();
    }
    public void ChangeProduct(string product)
    {
      helper.ChangeProduct(product);
    }

    public void OpenSettings()
    {}

    public void StartStopMeasuring(string product)
    {
      helper.StartMeasuring(product);
    }

    public void StartRinse()
    {
      helper.StartClean();
    }

    public void StartServer()
    { }

    public void StartZero()
    {
      helper.StartZero();
    }

    public void StopServer()
    {
      helper.StopServer();
    }
  }
}
