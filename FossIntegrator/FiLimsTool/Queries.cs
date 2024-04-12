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
    }
}
