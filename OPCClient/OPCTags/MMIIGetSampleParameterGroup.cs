using System.Collections.Generic;

namespace OPCClient.OPCTags
{
    /// <summary>
    /// Class that represents a SampleParameterGroup
    /// </summary>
    public class MMIIGetSampleParameterGroup : OPCGroup
    {
        readonly List<Parameter> parameters = new List<Parameter>();

        /// <summary>
        /// Struct that represents a single parameter
        /// </summary>
        private struct Parameter
        {
            public Parameter(string serverPrefix,int parameterNumber)
            {
                Name = new OPCTag<string>(serverPrefix, string.Format("GetSample.Parameter{0:00}.Name", parameterNumber));
                Unit = new OPCTag<string>(serverPrefix, string.Format("GetSample.Parameter{0:00}.Unit", parameterNumber));              
                Value = new OPCTag<double>(serverPrefix, string.Format("GetSample.Parameter{0:00}.Value", parameterNumber));              
            }
            public readonly OPCTag<string> Name;
            public readonly OPCTag<string> Unit;
            public readonly OPCTag<double> Value;            
        }

        public MMIIGetSampleParameterGroup(string serverPrefix,int numberOfParameters): base(serverPrefix)
        {
            for (int i = 0; i < numberOfParameters; i++)
            {
                var parameter = new Parameter(serverPrefix,i+1);
                
                OPCTags.Add(parameter.Unit);
                OPCTags.Add(parameter.Value);
                OPCTags.Add(parameter.Name);

                parameters.Add(parameter);
            }
        }
    }
}
