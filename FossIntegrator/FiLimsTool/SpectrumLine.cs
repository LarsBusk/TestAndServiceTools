using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiLimsTool
{
    internal class SpectrumLine
    {
        public int ExportId;
        public int RawDataId;
        public int IndexNo;
        public double IndexValue;

        public SpectrumLine(int exportId, int rawDataId, int indexNo, double indexValue)
        {
            ExportId = exportId;
            RawDataId = rawDataId;
            IndexNo = indexNo;
            IndexValue = indexValue;
        }
    }
}
