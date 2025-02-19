using System;
using System.Linq;
using System.Xml.Linq;

namespace UpdateLics
{
    internal class LicenseReader
    {
        public LicenseContainer ReadLicense(string fileName)
        {
            var license = new LicenseContainer();
            XNamespace ns = "http://www.foss.dk/pmlicense";
            var licenseFile = XDocument.Load(fileName);

            var lic = licenseFile.Root;
            var target = lic.Element(ns + "Target");
            if (target.Elements(ns + "Instrument").Any())
            {
                license.SerialNumber = target.Element(ns + "Instrument").Attribute("InstrumentSerialNumber").Value;
                license.ExpirationDate = target.Element(ns + "Instrument").Attributes("ExpirationDate").Any()
                    ? DateTime.Now.Add(TimeSpan.FromDays(Properties.Settings.Default.DaysToAdd)) : 
                     DateTime.MinValue;
            }

            if (target.Elements(ns + "AnyInstrument").Any())
            {
                license.ExpirationDate = DateTime.Now.Add(TimeSpan.FromDays(Properties.Settings.Default.DaysToAdd));
                license.SerialNumber = string.Empty;
            }

            var objects = lic.Element(ns + "Objects");
            var features = objects.Elements(ns + "Feature");

            foreach (var feature in features)
            {
                license.Features.Add(new Feature
                {
                    PartNumber = int.Parse(feature.Attribute("PartNumber").Value),
                    Name = feature.Attribute("Name").Value
                });
            }

            var models = objects.Elements(ns + "PredictionModel");

            foreach (var model in models)
            {
                license.Models.Add(int.Parse(model.Attribute("PartNumber").Value));
            }

            license.Customer = lic.Element(ns + "CustomerInfo").Attribute("Name").Value;

            return license;
        }
    }
}
