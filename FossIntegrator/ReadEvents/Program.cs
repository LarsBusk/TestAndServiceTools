using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var helper = new FileHelper();
            var sqlHelper = new SqlHelper();
             var events = helper.ReadEvents();

             foreach (var eventContent in events)
             {
                 sqlHelper.AddEvent(eventContent);
             }
        }
    }
}
