using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoraOpcUaTestServer.States
{
  public class StateNoraZeroing : IState
  {
    public string StateName => "Zeroing";
    private OpcUaHelper helper;

    public StateNoraZeroing(OpcUaHelper opcUaHelper)
    {
      helper = opcUaHelper;
    }

    public void ChangeProduct(string product)
    {}

    public void OpenSettings()
    {
      throw new NotImplementedException();
    }

    public void StartRinse()
    {}

    public void StartServer()
    {}

    public void StartStopMeasuring(string product)
    {}

    public void StartZero()
    {}

    public void StopServer()
    {
      helper.StopServer();
    }
  }
}
