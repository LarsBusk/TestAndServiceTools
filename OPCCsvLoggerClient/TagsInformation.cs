using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCCsvLoggerClient
{
  public class TagsInformation
  {
    public string SampleNumber;
    public int SampleNumberN;
    public DateTime OpcClientTime;
    public DateTime SampleTime;
    public int ElapsedTime;
    public int SampleCounter;
    public double Fat;
    public double Weight;
    public int Registration1;
    public int Registration2;
    public bool StartMeasuring;
    public int ProductCodeN;
    public double FatOut;
    public double WeightOut;
    public int SampleNoOut;

    public TagsInformation(int sampleNumberN, DateTime opcClientTime, DateTime sampleTime, int elapsedTime,
      int sampleCounter, double fat, double weight, int reg1, int reg2, bool startMeasuring, int productCodeN,
      double fatOut, double weightOut, int sampleNoOut)
    {
      SampleNumberN = sampleNumberN;
      OpcClientTime = opcClientTime;
      SampleTime = sampleTime;
      ElapsedTime = elapsedTime;
      SampleCounter = sampleCounter;
      Fat = fat;
      Weight = weight;
      Registration1 = reg1;
      Registration2 = reg2;
      StartMeasuring = startMeasuring;
      ProductCodeN = productCodeN;
      FatOut = fatOut;
      WeightOut = weightOut;
      SampleNoOut = sampleNoOut;
    }
  }
}
