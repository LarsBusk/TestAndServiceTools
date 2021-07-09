using System;
using System.Collections.Generic;

namespace OPCClient.OPCTags
{
  /// <summary>
  /// abstract class that represents an OPC Group
  /// </summary>
  public abstract class OPCGroup
  {
    protected OPCGroup(string serverPrefix)
    {
      ServerPrefix = serverPrefix;
    }

    public string ServerPrefix { get; private set; }

    public List<IOPCTag> OPCTags = new List<IOPCTag>();
  }
}