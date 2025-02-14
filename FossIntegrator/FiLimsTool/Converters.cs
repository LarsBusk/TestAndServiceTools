using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiLimsTool
{
    public class Converters
    {
        public static List<Tuple<int, double[]>> GetAcquiredDoubleData(DataTable table)
        {
            var ret = new List<Tuple<int, double[]>>();

            foreach (DataRow dataRow in table.Rows)
            {
                var type = (int)dataRow[0];
                var bytes = dataRow.ItemArray[1] as byte[];
                var values = new double[bytes.Length / 8];
                for (var i = 0; i < values.Length; i++)
                    values[i] = BitConverter.ToDouble(bytes, i * 8);
                ret.Add(new Tuple<int, double[]>(type, values));
            }

            return ret;
        }

        public static IEnumerable<Tuple<int, float[]>> GetAcquiredData(DataTable table)
        {
            var ret = new List<Tuple<int, float[]>>();
            
            foreach (DataRow dataRow in table.Rows)
            {
                var type = (int)dataRow[0];
                var bytes = dataRow.ItemArray[1] as byte[];
                var values = new float[bytes.Length / 4];
                for (var i = 0; i < values.Length; i++)
                    values[i] = BitConverter.ToSingle(bytes, i * 4);
                ret.Add(new Tuple<int, float[]>(type, values));
            }

            return ret;
        }

        public static string GetFileName(int id, bool isSys)
        {
            var preFix = isSys ? "Sys" : "Com";
            var name =  $"{preFix}{id.ToString("X8")}-1.xml";
            return name;
        }


    }
}
