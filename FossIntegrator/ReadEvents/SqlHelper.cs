using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadEvents
{
    public class SqlHelper
    {
        public SqlHelper()
        {
            
        }

        public string ServerName { get; set; }

        public void AddEvent(EventContent eventContent)
        {
            var evText = eventContent.Text.Replace('\\', ' ').Replace('\"', ' ').Replace('\'', ' ');
            var hint = eventContent.Hint.Replace('\\', ' ').Replace('\"', ' ').Replace('\'', ' ');
            var query =
                $"Insert Into FiEvents Values ('{eventContent.EventTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{evText}','{hint}',{eventContent.Type},{eventContent.Code},'{eventContent.DeviceName}'," +
                $"'{eventContent.ModuleShortName}','{eventContent.ModuleLongName}')";
            GetDataTable(query);
        }

        private static string ConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = ".\\SQL2019",
                IntegratedSecurity = true,
                InitialCatalog = "TestDb",
                TrustServerCertificate = true
            };
            var connString = builder.ToString();

            return connString;
        }

        private DataTable GetDataTable(string query)
        {
            var dataAdapter = new SqlDataAdapter(query, ConnectionString());
            var table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            dataAdapter.Fill(table);
            return table;
        }
        
    }
}
