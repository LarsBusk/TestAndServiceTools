using System.Collections.Generic;
using System.Data.SqlClient;

namespace RemovePmsFromFi
{
    public class DatabaseHelper
    {
        ProductsForm form;
        public List<string> UsedProducts()
        {
            List<string> programs = new List<string>();
            var conn = new SqlConnection(ConnectionString());
            var command = new SqlCommand("Select Distinct Program From Jobs Where Program<>''", conn);
            conn.Open();

            using (var rows = command.ExecuteReader())
            {
                while (rows.Read())
                {
                    programs.Add($"{rows["Program"]}");
                }
            }

            conn.Close();
            return programs;
        }

        private string ConnectionString()
        {
            var connstr = new SqlConnectionStringBuilder();
            connstr.DataSource = Properties.Settings.Default.SqlServer;
            connstr.InitialCatalog = Properties.Settings.Default.Database;
            connstr.UserID = "FIAdmin";
            connstr.Password = "db1Master";

            return connstr.ToString();
        }
    }
}
