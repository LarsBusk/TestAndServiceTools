using System;
using System.Collections.Generic;

namespace UpdateLics
{
    internal class LicenseContainer
    {
        public List<int> Models;
        public List<Feature> Features;
        public string SerialNumber;
        public DateTime ExpirationDate;
        public string Customer;

        public LicenseContainer()
        {
            Models = new List<int>();
            Features = new List<Feature>();
        }

        public override string ToString()
        {
            var fileName = Customer;
            if (ExpirationDate > DateTime.MinValue)
                fileName += $"_Exp_{ExpirationDate.ToString("yyyyMMdd")}";
            if (!string.IsNullOrEmpty(SerialNumber))
                fileName += $"_SN_{SerialNumber}";
             
            return $"{fileName}.lic";
        }
    }

    public struct Feature
    {
        public int PartNumber;
        public string Name;
    }
}
