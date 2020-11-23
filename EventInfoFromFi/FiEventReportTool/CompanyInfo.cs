using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiEventReportTool
{
  public class CompanyInfo : IComparable
  {
    public int CompanyId;

    public string CompanyName;

    public CompanyInfo(int companyId, string companyName)
    {
      this.CompanyId = companyId;
      this.CompanyName = companyName;
    }

    public int CompareTo(object ci)
    {
      string otherCompanyName = ((CompanyInfo) ci).CompanyName;
      return this.CompanyName.CompareTo(otherCompanyName);
    }

    public override string ToString()
    {
      return this.CompanyName;
    }
  }
}
