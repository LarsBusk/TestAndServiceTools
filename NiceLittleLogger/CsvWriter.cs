using System;
using System.IO;
using System.Text;

namespace NiceLittleLogger
{
    public class CsvWriter
    {
        private readonly string _fileName;

        private readonly string _columnNames;

        private const string TimeFormat = "yyyy-MM-dd HH:mm:ss,fff";


        public CsvWriter(string fileName, string columnNames)
        {
            this._fileName = Path.Combine(fileName);
            this._columnNames = columnNames;
            CreateCsvIfNeeded();
        }

        public CsvWriter(string folder, string fileName, string columnNames)
        {
            this._fileName = Path.Combine(folder, fileName);
            this._columnNames = columnNames;
            CreateCsvIfNeeded(folder);
        }

        public void WriteValues(DateTime time, params object[] values)
        {
            var builder = new StringBuilder();

            builder.Append($"{time.ToString(TimeFormat)};");
            var numberOfValues = values.Length;

            for (int i = 0; i < numberOfValues - 1; i++)
            {
                builder.Append($"{values[i]};");
            }

            builder.Append($"{values[numberOfValues - 1]}\n");

            File.AppendAllText(_fileName, builder.ToString());
        }

        private void CreateCsvIfNeeded(string folder = "")
        {
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            if (!File.Exists(this._fileName))
            {
                File.AppendAllText(this._fileName, _columnNames);
            }
        }
    }
}
