using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoraOpcUaTestServer.States
{
  public class StateServerStopped : IState
  {
    public string StateName => "Server stopped";
    private OpcUaHelper helper;
    public StateServerStopped(OpcUaHelper opcUaHelper)
    {
      helper = opcUaHelper;
    }
    public void ChangeProduct(string product)
    { }

   public void StartStopMeasuring(string product)
    { }

    public void StartRinse()
    {}
    
    public void StartServer()
    {
      helper.StartServer();
    }

    public void StartZero()
    {}
    
    public void StopServer()
    {}

    public void OpenSettings()
    {
      SettingsForm form = new SettingsForm();
      form.Show();
    }
  }
}
