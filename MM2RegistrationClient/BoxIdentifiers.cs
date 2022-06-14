using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationClient
{
  [Serializable]
  public class BoxIdentifiers
  {
    public List<int> SampleIds;

    public List<int> ProductCodes;

    public BoxIdentifiers()
    {
      SampleIds = new List<int>();
      ProductCodes = new List<int>();
    }
  }
}
