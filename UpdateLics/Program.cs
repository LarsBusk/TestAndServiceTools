using System;

namespace UpdateLics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new LicenseReader();
            var creator = new LicenseCreator();

            if (args.Length == 0)
            {
                Console.WriteLine("Drag and drop the licenses to be renewed.");
            }
            else
            {
                foreach (var license in args)
                {
                    var lic = reader.ReadLicense(license);
                    creator.CreateLicense(lic);
                }
            }

            Console.Read();
        }
    }
}
