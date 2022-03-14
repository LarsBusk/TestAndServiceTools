using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoraOpcUaTestServer.States
{
  class StateNoraCip : IState
  {
    public string StateName => "Clean in place";

    private OpcUaHelper helper;

    public StateNoraCip(OpcUaHelper helper)
    {
      this.helper = helper;
    }

    public void ChangeProduct(string product)
    {
    }

    public void OpenSettings()
    {
    }

    public void StartRinse()
    {
    }

    public void StartServer()
    {
    }

    public void StartStopMeasuring(string product)
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
