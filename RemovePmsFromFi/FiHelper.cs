using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RemovePmsFromFi
{
    public class FiHelper
    {
        public static string SelectedVersion;

        public static FiVersions[] GetVersions()
        {
            var versions = new List<FiVersions>();

            var fiRootFolder = @"C:\ProgramData\FossIntegrator";

            if (!Directory.Exists(fiRootFolder)) return new FiVersions[] { };

            versions = Directory.GetDirectories(fiRootFolder, "*x*x*").Select(f => new FiVersions(f)).ToList();
            return versions.ToArray();
        }

        public static void DeleteMccFile(XElement component)
        {
            var compName = ComponentName(component);
            var activeCompPath = Path.Combine(SelectedVersion, "ActiveComponents");
            var compFiles = Directory.GetFiles(activeCompPath)
                .Where(f => f.Contains(compName.Item1) && f.Contains(compName.Item2)).ToList();

            foreach (var compFile in compFiles)
            {
                File.Delete(compFile);
            }
        }

        private static Tuple<string,string> ComponentName(XElement component)
        {
            var name = component.Element("sName").Value.Replace(" ", "");
            var created = component.Element("sCreated").Value;
            var date = created.Split(' ')[0].Split('-');
            var time = created.Split(' ')[1].Replace(":", "");
            created = $"{date[2]}{date[1]}{date[0]}{time}";

            return Tuple.Create(name, created);
        }
    }
}
