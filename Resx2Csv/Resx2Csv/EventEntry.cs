using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resx2Csv
{
  class EventEntry
  {
    public string Type { get; set; }

    public string Error { get; set; }

    public string Message { get; set; }

    public string Unit
    {
      get { return errorElements[0]; }
    }

    public string Module
    {
      get { return errorElements[1]; }
    }

    public int ErrorNumber
    {
      get { return Convert.ToInt32(errorElements[3]); }
    }

    private string[] errorElements;

    public EventEntry(string error)
    {
      this.Error = error;

      this.errorElements = error.Split('_');
    }
  }
}
