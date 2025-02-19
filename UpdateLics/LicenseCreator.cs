using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UpdateLics
{
    internal class LicenseCreator
    {
        public LicenseCreator() { }

        public void CreateLicense(LicenseContainer license)
        {
            var arguments = new StringBuilder();
            arguments.Append("CreateLicense ");
            arguments.Append($"{Properties.Settings.Default.ThumbPrint} ");
            arguments.Append($"\"{license.Customer}\" ");
            arguments.Append("\"");

            if (license.Features.Any())
            {
                var maxFeature = license.Features.Count - 1;

                for (int i = 0; i < maxFeature; i++)
                {
                    arguments.Append($"F,{license.Features[i].PartNumber},{license.Features[i].Name}|");
                }

                arguments.Append($"F,{license.Features[maxFeature].PartNumber},{license.Features[maxFeature].Name}");

                if (license.Models.Any())
                {
                    arguments.Append("|");
                }
            }

            if (license.Models.Any())
            {
                var maxModel = license.Models.Count - 1;

                for (int i = 0; i < maxModel; i++)
                {
                    arguments.Append($"PM,{license.Models[i]}|");
                }

                arguments.Append($"PM,{license.Models[maxModel]}");
            }

            arguments.Append("\" ");

            if (!string.IsNullOrEmpty(license.SerialNumber))
            {
                arguments.Append($"-s {license.SerialNumber} ");
            }

            if (license.ExpirationDate > DateTime.MinValue)
            {
                var expirationDate = license.ExpirationDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                arguments.Append($"-e {expirationDate} ");
            }

            arguments.Append($"{license.ToString()}");

            var arg = arguments.ToString();
            Console.WriteLine(arg);

            var fossProtect = new Process
            {
                StartInfo = new ProcessStartInfo("FossProtect.exe", arg)
            };
            fossProtect.Start();
        }
    }
}
