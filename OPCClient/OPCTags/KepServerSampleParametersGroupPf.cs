using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleParametersGroupPf : OPCGroup
  {
    public OPCTag<double> Fat;
    public OPCTag<double> Lactose;
    public OPCTag<double> Protein;
    public OPCTag<double> Moisture;

    public KepServerSampleParametersGroupPf(string serverPrefix) : base(serverPrefix)
    {
      Fat=new OPCTag<double>(serverPrefix, "Sample.Parameters.FAT.Result");
      OPCTags.Add(Fat);
      Lactose = new OPCTag<double>(serverPrefix, "Sample.Parameters.Lactose.Result");
      OPCTags.Add(Lactose);
      Protein = new OPCTag<double>(serverPrefix, "Sample.Parameters.Protein.Result");
      OPCTags.Add(Protein);
      Moisture = new OPCTag<double>(serverPrefix, "Sample.Parameters.Moisture.Result");
      OPCTags.Add(Moisture);
    }
  }
}
