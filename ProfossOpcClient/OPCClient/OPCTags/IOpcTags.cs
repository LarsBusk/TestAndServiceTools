using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public interface IOpcTags
  {
    List<IOPCTag> OPCTags { get; set; }

    string ServerName { get; }
  }
}
