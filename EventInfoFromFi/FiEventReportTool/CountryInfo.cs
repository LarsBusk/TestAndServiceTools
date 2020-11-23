using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FiEventReportTool
{
  public class CountryInfo : IComparable
  {
    public int CountryId;
    public string CountryName;

    public CountryInfo(int coutryId, string countryName)
    {
      this.CountryId = coutryId;
      this.CountryName = countryName;
    }

    public int CompareTo(object obj)
    {
      string otherCompanyName = ((CountryInfo)obj).CountryName;
      return this.CountryName.CompareTo(otherCompanyName);
    }

    public override string ToString()
    {
      return this.CountryName;
    }
  }
}
