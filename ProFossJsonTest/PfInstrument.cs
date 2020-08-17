using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFossJsonTest
{
  public class PfInstrument
  {
    public string Name;

    public string SerialNumber;

    public PfInstrument(string name, string serialNumber)
    {
      this.Name = name;
      this.SerialNumber = serialNumber;
    }

    public override string ToString()
    {
      return $"{Name}, ({SerialNumber})";
    }
  }
}
