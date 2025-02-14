using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiLimsTool
{
    internal class CsvCreator
    {
        public CsvCreator() { }

        public void CreateCsvForAcquiredData(IEnumerable<Tuple<int, double[]>> acquiredData)
        {
            var fileName = "AcquiredValues.csv";

            var lines = new List<string>();

            foreach (var spec in acquiredData)
            {
                var type = spec.Item1;
                lines.AddRange(spec.Item2.Select(l => $"{type}; {l}").ToList());
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            File.AppendAllLines(fileName, lines);
        }
    }
}
