using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace BalanceSimulator
{
  public class SerialHelper
  {
    public SerialPort Serial;
    Logger log = new Logger();

    

    public SerialHelper()
    {
      Serial = new SerialPort();
      Serial.DataReceived += Serial_DataReceived;
    }

    private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      string receivedData = Serial.ReadExisting();
    }

    public string[] AvailablePorts()
    {
      var ports = SerialPort.GetPortNames();
      return ports;
    }

    public void SendWeight()
    {
      Random ran = new Random();
      string weight = (ran.NextDouble()*25 + 1).ToString("+ ##.###");
      log.LogInfo("Weight is: {0}", weight);
      Serial.Write(weight);
    }
  }
}
