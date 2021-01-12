using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCClient.OPCTags
{
  public class KepServerControllerGroup : OPCGroup
  {
    public OPCTag<int> ProductCodeN;
    public OPCTag<string> ProductCode;
    public OPCTag<int> WatchdogCounter;
    public OPCTag<bool> StartMeasuring;
    public OPCTag<bool> CalibrationSample;
    public OPCTag<bool> CIP;
    public OPCTag<bool> WaterRef;

    public KepServerControllerGroup(string serverPrefix) : base(serverPrefix)
    {
      ProductCodeN = new OPCTag<int>(serverPrefix, "Controller.ProductCodeN");
      OPCTags.Add(ProductCodeN);
      ProductCode = new OPCTag<string>(serverPrefix, "Controller.ProductCode");
      OPCTags.Add(ProductCode);
      WatchdogCounter = new OPCTag<int>(serverPrefix, "Controller.WatchdogCounter");
      OPCTags.Add(WatchdogCounter);
      StartMeasuring = new OPCTag<bool>(serverPrefix, "Controller.StartMeasuring");
      OPCTags.Add(StartMeasuring);
      CalibrationSample = new OPCTag<bool>(serverPrefix, "Controller.CalibrationSample");
      OPCTags.Add(CalibrationSample);
      CIP = new OPCTag<bool>(serverPrefix, "Controller.CIP");
      OPCTags.Add(CIP);
      WaterRef = new OPCTag<bool>(serverPrefix, "Controller.WaterRef");
      OPCTags.Add(WaterRef);
    }
  }
}
