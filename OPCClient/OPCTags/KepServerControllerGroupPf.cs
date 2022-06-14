using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerControllerGroupPf : OPCGroup
  {
    public OPCTag<int> WatchdogCounter;
    public OPCTag<int> ProductCodeN;
    public OPCTag<bool> StartMeasuring;
    public OPCTag<bool> CalibrationSample;

    public KepServerControllerGroupPf(string serverPrefix) : base(serverPrefix)
    {
      WatchdogCounter = new OPCTag<int>(serverPrefix, "Controller.WatchdogCounter");
      OPCTags.Add(WatchdogCounter);
      ProductCodeN = new OPCTag<int>(serverPrefix, "Controller.ProductCodeN");
      OPCTags.Add(ProductCodeN);
      StartMeasuring = new OPCTag<bool>(serverPrefix, "Controller.StartMeasuring");
      OPCTags.Add(StartMeasuring);
      CalibrationSample = new OPCTag<bool>(serverPrefix, "Controller.CalibrationSample");
      OPCTags.Add(CalibrationSample);
    }
  }
}
