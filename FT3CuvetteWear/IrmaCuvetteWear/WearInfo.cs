using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaCuvetteWear
{
  public class WearInfo: IComparable
  {
    public string Date;
    public string Time;
    public string Correction;

    public int CompareTo(object obj)
    {
      return this.weardateTime().CompareTo(((WearInfo)obj).weardateTime());
    }

    public override string ToString()
    {
      return $"{Date};{Time};{Correction.Replace('.', ',')}";
    }

    private DateTime weardateTime()
    {
      string dtString = $"{Date}T{Time.Substring(0, 8)}Z";
      return DateTime.Parse(dtString, new DateTimeFormatInfo());
    }
  }
}
