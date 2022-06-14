using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerControllerGroupMM : OPCGroup
  {
    public OPCTag<int> PreregistrationValue1;
    public OPCTag<int> PreregistrationValue2;
    public OPCTag<int> WatchdogCounter;
    public OPCTag<int> ProductCodeN;
    public OPCTag<bool> StartMeasuring;


    public KepServerControllerGroupMM(string serverPrefix) : base(serverPrefix)
    {
      PreregistrationValue1 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration.Value01");
      OPCTags.Add(PreregistrationValue1);
      PreregistrationValue2 = new OPCTag<int>(serverPrefix, "Controller.SampleRegistration.PreRegistration.Value02");
      OPCTags.Add(PreregistrationValue2);
      WatchdogCounter = new OPCTag<int>(serverPrefix, "Controller.WatchdogCounter");
      OPCTags.Add(WatchdogCounter);
      ProductCodeN = new OPCTag<int>(serverPrefix, "Controller.ProductCodeN");
      OPCTags.Add(ProductCodeN);
      StartMeasuring = new OPCTag<bool>(serverPrefix, "Controller.StartMeasuring");
      OPCTags.Add(StartMeasuring);

    }
  }
}
