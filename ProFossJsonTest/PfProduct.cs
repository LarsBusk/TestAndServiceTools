using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFossJsonTest
{
  public class PfProduct
  {
    public string ProductId;

    public string Name;

    public PfProduct(string name, string id)
    {
      this.Name = name;
      this.ProductId = id;
    }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
