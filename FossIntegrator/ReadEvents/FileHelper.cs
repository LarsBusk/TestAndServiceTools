using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadEvents
{
    public class FileHelper
    {
        public List<EventContent> ReadEvents()
        {
            var lines = File.ReadAllLines("FiEvents.txt");
            var events = new List<EventContent>();

            foreach (var line in lines)
            {
                var eventArray = line.Split(';');
                //if (eventArray.Length != 12) continue;
           
                var eventTime = DateTime.Parse(eventArray[0]);
                events.Add(new EventContent
                {
                    EventTime = eventTime,
                    Text = eventArray[1].Trim(),
                    Hint = eventArray[2].Trim(),
                    Type = int.Parse(eventArray[3]),
                    Code = int.Parse(eventArray[7]),
                    DeviceName = eventArray[9].Trim(),
                    ModuleLongName = eventArray[10].Trim(),
                    ModuleShortName = eventArray[11].Trim()
                });
            }

            return events;
        }
    }

    public class EventContent
    {
        public DateTime EventTime;
        public string Text;
        public string Hint;
        public int Type;
        public int Code;
        public string DeviceName;
        public string ModuleShortName;
        public string ModuleLongName;
    }
}
