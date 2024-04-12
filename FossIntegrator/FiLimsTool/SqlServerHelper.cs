using System;
using FiLimsTool;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace DataBaseServiceTool
{
    class SqlServerHelper
    {
        public SqlServerHelper(string server)
        {
            ServerName = server;
        }

        public string ServerName { get; set; }

        private static string ConnectionString(string serverName)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = $"{serverName}",
                IntegratedSecurity = true,
                InitialCatalog = "FiLimsExport",
                TrustServerCertificate = true
            };
            var connString = builder.ToString();
            return connString;
        }

        public List<int> GetZeroIds()
        {
            var zerolist = GetDataTable(Queries.GetZeros).Select();
            return zerolist.Select(s => (int)s["ExportId"]).ToList();
        }

        public List<SpectrumLine> GetSpectrum(int exportID)
        {
            var spectrum = GetDataTable(Queries.GetSpectra(exportID)).Select();
            return spectrum.Select(s =>
                new SpectrumLine(exportID, (int)s["RawDataID"], (int)s["IndexNo"], (double)s["IndexValue"])).ToList();
        }

        public List<Tuple<int, DateTime>> GetSampleHeader(int exportID)
        {
            var header = GetDataTable(Queries.GetSampleheader(exportID)).Select();
            return header.Select(s =>
                new Tuple<int, DateTime>((int)s["SampleIntakeNo"], (DateTime)s["SampleTestDateTime"])).ToList();
        }


        private DataTable GetDataTable(string query)
        {
            var dataAdapter = new SqlDataAdapter(query, ConnectionString(ServerName));
            var table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dataAdapter.Fill(table);
            return table;
        }
    }
}