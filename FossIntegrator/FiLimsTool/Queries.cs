using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiLimsTool
{
    public static class Queries
    {
        public static string GetZeros =>
            "Select ExportId From SampleHeader Where SampleType = 'ZERO' and SampleSubType='VALUE'";

        public static string GetSpectra(int exportId)
        {
            return $"Select RawDataID, IndexNo, IndexValue From RawDataValues Where ExportID = {exportId} And RawDataID In (11,21)";
        }

        public static string GetSampleheader(int exportId)
        {
            return
                $"Select SampleIntakeNumber, SampleTestDateTime From SampleHeader Where ExportID = {exportId}";
        }

        public static string GetSpectraFromFiBase(int exportId)
        {
            return
                $"Select AcquiredDataType, AcqData From AcquiredData Where SampleIndex = {exportId} And IntakeNumerator = 1";
        }

        public static string GetSetupIndexes()
        {
            return "Select Distinct SetupIndex From Results";
        }

        public static string GetComponentIndexes()
        {
            return "Select Distinct ComponentIndex From Jobs Where ComponentIndex <> 0 Order by ComponentIndex";
        }

        public static string GetJobsToDelete(IEnumerable<int> componentIndexes)
        {
            var indexes = string.Join(",", componentIndexes);
            return $"Select JobIndex, ID From Jobs Where ComponentIndex In ({indexes})";
        }

        public static string DeleteJobSampleFields(IEnumerable<int> ids)
        {
            var idsToDelete = string.Join(",", ids);
            return $"Delete From JobSampleFields Where JobID In ({idsToDelete})";
        }

        public static string DeleteJobExtensionData(IEnumerable<int> indexes)
        {
            var jobIndexes = string.Join(",", indexes);
            return $"Delete From JobExtensionData Where JobIndex In ({jobIndexes})";
        }
    }
}
