using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyOpcUADemo
{
  public class OpcClientEventArgs
  {
    private string newValue;
    private string nodeDescription;

    public string NewValue
    {
      get => newValue;
      set => newValue = value;
    }

    public string NodeDescription
    {
      get => nodeDescription;
      set => nodeDescription = value;
    }

    public OpcClientEventArgs(string val, string nodedes)
    {
      NewValue = val;
      NodeDescription = nodedes;
    }
  }
}
