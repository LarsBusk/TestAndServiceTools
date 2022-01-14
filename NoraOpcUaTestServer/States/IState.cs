using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoraOpcUaTestServer.States
{
  public interface IState
  {
    string StateName { get; }
    void StartServer();
    void StopServer();
    void StartStopMeasuring(string product);
    void ChangeProduct(string product);
    void StartZero();
    void StartRinse();
    void OpenSettings();
  }
}
