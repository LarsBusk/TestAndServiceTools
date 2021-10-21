using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaCuvetteWear
{
  public class ProgressEventArgs
  {
    public int Progress;
    public string State;

    public ProgressEventArgs(int progress, string state)
    {
      this.Progress = progress;
      this.State = state;
    }
  }
}
