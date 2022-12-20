using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemovePmsFromFi
{
    public class FiVersions
    {
        public string Version;

        public FiVersions(string version)
        {
            Version = version;
        }

        public override string ToString()
        {
            return Version.Substring(Version.LastIndexOf(@"\") + 1);
        }
    }
}
