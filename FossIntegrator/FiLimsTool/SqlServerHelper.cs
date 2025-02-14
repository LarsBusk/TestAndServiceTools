using System;
using FiLimsTool;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using static System.Windows.Forms.LinkLabel;

namespace DataBaseServiceTool
{
    class SqlServerHelper
    {
        public SqlServerHelper(string server)
        {
            ServerName = server;
        }

        public string ServerName { get; set; }

        private static string ConnectionString(string serverName, bool isFiBase)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = serverName,
                IntegratedSecurity = true,
                InitialCatalog = isFiBase ? "FiBase2" : "FiLimsExport",
                TrustServerCertificate = true
            };
            var connString = builder.ToString();

            return connString;
        }

        public IEnumerable<Tuple<int, double[]>> GetAcquiredDoubleData(int sampleIndex)
        {
            var query = Queries.GetSpectraFromFiBase(sampleIndex);
            var res = GetDataTable(query, true);
            return Converters.GetAcquiredDoubleData(res);
        }

        public IEnumerable<Tuple<int, float[]>> GetAcquiredData(int sampleIndex)
        {
            var query = Queries.GetSpectraFromFiBase(sampleIndex);
            var res = GetDataTable(query, true);
            return Converters.GetAcquiredData(res);
        }

        public IEnumerable<int> GetZeroIds()
        {
            var zerolist = GetDataTable(Queries.GetZeros, false).Select();
            return zerolist.Select(s => (int)s["ExportId"]).ToList();
        }

        public IEnumerable<SpectrumLine> GetSpectrum(int exportID)
        {
            var spectrum = GetDataTable(Queries.GetSpectra(exportID), false).Select();
            return spectrum.Select(s =>
                new SpectrumLine(exportID, (int)s["RawDataID"], (int)s["IndexNo"], (double)s["IndexValue"])).ToList();
        }

        public IEnumerable<Tuple<int, DateTime>> GetSampleHeader(int exportId)
        {
            var header = GetDataTable(Queries.GetSampleheader(exportId), false).Select();
            return header.Select(s =>
                new Tuple<int, DateTime>((int)s["SampleIntakeNo"], (DateTime)s["SampleTestDateTime"])).ToList();
        }

        public IEnumerable<int> GetSetupIndexes()
        {
            var indexes = GetDataTable(Queries.GetSetupIndexes(), true).Select();
            return indexes.Select(s => (int)s["SetupIndex"]);
        }

        public IEnumerable<int> GetComponentIndexes()
        {
            var indexes = GetDataTable(Queries.GetComponentIndexes(), true).Select();
            return indexes.Select(c => (int)c["ComponentIndex"]);
        }


        private DataTable GetDataTable(string query, bool isFiBase)
        {
            var dataAdapter = new SqlDataAdapter(query, ConnectionString(ServerName, isFiBase));
            var table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dataAdapter.Fill(table);
            return table;
        }
    }
}