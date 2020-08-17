using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFossJsonTest
{
  public class PfProduct
  {
    public string ProductCode;

    public string Name;

    public PfProduct(string name, string code)
    {
      this.Name = name;
      this.ProductCode = code;
    }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
