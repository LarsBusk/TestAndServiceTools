using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class MMIIGetSampleBoneGroup : OPCGroup
  {
    private readonly List<Parameter> parameters = new List<Parameter>();

    /// <summary>
    /// Struct that represents a single parameter
    /// </summary>
    private struct Parameter
    {
      public Parameter(string serverPrefix, int parameterNumber)
      {
        Length = new OPCTag<int>(serverPrefix, string.Format("GetSample.Bone{0:00}.Length", parameterNumber));
        Size = new OPCTag<int>(serverPrefix, string.Format("GetSample.Bone{0:00}.Size", parameterNumber));
        Width = new OPCTag<int>(serverPrefix, string.Format("GetSample.Bone{0:00}.Width", parameterNumber));
        X = new OPCTag<int>(serverPrefix, string.Format("GetSample.Bone{0:00}.X", parameterNumber));
        Y = new OPCTag<int>(serverPrefix, string.Format("GetSample.Bone{0:00}.Y", parameterNumber));
      }

      public readonly OPCTag<int> Length;
      public readonly OPCTag<int> Size;
      public readonly OPCTag<int> Width;
      public readonly OPCTag<int> X;
      public readonly OPCTag<int> Y;

    }

    public MMIIGetSampleBoneGroup(string serverPrefix, int numberOfParameters) : base(serverPrefix)
    {
      for (int i = 0; i < numberOfParameters; i++)
      {
        var parameter = new Parameter(serverPrefix, i + 1);

        OPCTags.Add(parameter.Length);
        OPCTags.Add(parameter.Size);
        OPCTags.Add(parameter.Width);
        OPCTags.Add(parameter.X);
        OPCTags.Add(parameter.Y);

        parameters.Add(parameter);
      }
    }
  }
}
