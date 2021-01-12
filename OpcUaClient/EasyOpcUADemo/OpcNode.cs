using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaTestClient
{
  public class OpcNode
  {
    public string Header;
    public string Address;

    public OpcNode(string header, string address)
    {
      this.Address = address;
      this.Header = header;
    }
  }
}
