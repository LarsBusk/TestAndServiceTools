using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerSampleParametersGroup : OPCGroup
  {
    public OPCTag<double> Fat;
    public OPCTag<double> Lactose;
    public OPCTag<double> Protein;
    public OPCTag<double> Snf;
    public OPCTag<double> TotalSolids;
    public OPCTag<double> Weight;

    public KepServerSampleParametersGroup(string serverPrefix) : base(serverPrefix)
    {
      Fat=new OPCTag<double>(serverPrefix, "Sample.Parameters.FAT.Result");
      OPCTags.Add(Fat);
      Weight = new OPCTag<double>(serverPrefix, "Sample.Parameters.WEIGHT.Result");
      OPCTags.Add(Weight);
      Lactose = new OPCTag<double>(serverPrefix, "Sample.Parameters.LACTOSE.Result");
      OPCTags.Add(Lactose);
      Protein = new OPCTag<double>(serverPrefix, "Sample.Parameters.PROTEIN.Result");
      OPCTags.Add(Protein);
      Snf = new OPCTag<double>(serverPrefix, "Sample.Parameters.SNF.Result");
      OPCTags.Add(Snf);
      TotalSolids = new OPCTag<double>(serverPrefix, "Sample.Parameters.TOTALSOLIDS.Result");
      OPCTags.Add(TotalSolids);
    }
  }
}
