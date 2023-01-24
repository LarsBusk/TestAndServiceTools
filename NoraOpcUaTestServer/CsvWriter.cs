using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace NoraOpcUaTestServer
{
    public class CsvWriter
    {
        private readonly string _fileName = "ResultValues.csv";

        private readonly string _columnNames =
            "Time;SampleCounter;SampleNumber;Diff;Delay;SampleRegistrationValue;Fat;Protein;Lactose;SNF;TS\n";


        private const string TimeFormat = "yyyy-MM-dd HH:mm:ss,fff";

        public CsvWriter()
        {
            this._fileName = Path.Combine(Properties.Settings.Default.LogFolder, _fileName);
            CreateCsvIfNeeded();
        }

        public CsvWriter(string fileName, string columnNames)
        {
            this._fileName = Path.Combine(Properties.Settings.Default.LogFolder, fileName);
            this._columnNames = columnNames;
            CreateCsvIfNeeded();
        }

        public void WriteValues(DateTime time, uint sampleCounter, string sampleNumber, string sampleRegistrationValue,
            double fat, double protein, double lactose, double ts, double snf, TimeSpan timeDif, TimeSpan delay)
        {
            File.AppendAllText(this._fileName,
                $"{time.ToString(TimeFormat)};{sampleCounter};{sampleNumber};{(int)timeDif.TotalMilliseconds};{(int)delay.TotalMilliseconds};{sampleRegistrationValue};{fat};{protein};{lactose};{snf};{ts}\n");
        }

        public void WriteValues(DateTime time, params object[] values)
        {
            var builder = new StringBuilder();

            builder.Append($"{time.ToString(TimeFormat)};");
            var numberOfValues = values.Length;

            for (int i = 0; i < numberOfValues-1; i++)
            {
                builder.Append($"{values[i]};");
            }

            builder.Append($"{values[numberOfValues - 1]}\n");

            File.AppendAllText(_fileName, builder.ToString());
        }

        private void CreateCsvIfNeeded()
        {
            if (!File.Exists(this._fileName))
            {
                File.AppendAllText(this._fileName, _columnNames);
            }
        }
    }
}
