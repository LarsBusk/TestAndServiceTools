using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class MMIIGetBatchParamaterGroup : OPCGroup
  {
    private readonly List<Parameter> parameters = new List<Parameter>();

    /// <summary>
    /// Struct that represents a single parameter
    /// </summary>
    private struct Parameter
    {
      public Parameter(string serverPrefix, int parameterNumber)
      {
        Name = new OPCTag<string>(serverPrefix, string.Format("GetBatch.Parameter{0:00}.Name", parameterNumber));
        Unit = new OPCTag<string>(serverPrefix, string.Format("GetBatch.Parameter{0:00}.Unit", parameterNumber));
        Value = new OPCTag<double>(serverPrefix, string.Format("GetBatch.Parameter{0:00}.Value", parameterNumber));
      }

      public readonly OPCTag<string> Name;
      public readonly OPCTag<string> Unit;
      public readonly OPCTag<double> Value;
    }

    public readonly OPCTag<int> GetBatchIdentifier;

    public MMIIGetBatchParamaterGroup(string serverPrefix, int numberOfParameters) : base(serverPrefix)
    {
      for (int i = 0; i < numberOfParameters; i++)
      {
        var parameter = new Parameter(serverPrefix, i + 1);

        OPCTags.Add(parameter.Name);
        OPCTags.Add(parameter.Unit);
        OPCTags.Add(parameter.Value);

        parameters.Add(parameter);
      }

      GetBatchIdentifier = new OPCTag<int>(serverPrefix, "GetBatch.Identifier");
      OPCTags.Add(GetBatchIdentifier);
    }

  }
}
