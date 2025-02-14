using System;
using DataBaseServiceTool;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FiLimsTool
{
    internal class FiHelpers
    {
        private SqlServerHelper helper;
        private string snapShotFolder = @"\\Lab-W10-Cmt\Snapshot2"; //@"C:\ProgramData\FossIntegrator\Snapshot2";

        public FiHelpers()
        {
            helper = new SqlServerHelper("Lab-W10-Cmt\\foss_fi2");
        }

        public IEnumerable<SetupContainer> GetMissingSetups()
        {
            var sysIndexes = helper.GetSetupIndexes();
            var sysFileContainers = sysIndexes.
                Select(i => new SetupContainer("Sys", i, Converters.GetFileName(i, true)));
            
            var sysFiles = Directory.GetFiles(snapShotFolder, "Sys*")
                .Select(f => f.Substring(f.LastIndexOf(@"\") + 1));
            var missing = sysFileContainers.
                Where(n => !sysFiles.Any(f => f.ToUpper() == n.SetupFileName.ToUpper()));
            
            var comIndexes = helper.GetComponentIndexes();
            var comFileContainers =
                comIndexes.Select(i => new SetupContainer("Com", i, Converters.GetFileName(i, false)));
            var comFiles = Directory.GetFiles(snapShotFolder, "Com*")
                .Select(f => f.Substring(f.LastIndexOf(@"\") + 1));
            var missingComs = comFileContainers.
                Where(n => !comFiles.Any(f => f.ToUpper() == n.SetupFileName.ToUpper()));

            foreach (var missingCom in missingComs)
            {
                missing = missing.Append(missingCom);
            }
            
            return missing;
        }
    }
}
