using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFiEvents
{
    public class EventContent
    {
        private readonly string eventType;
        private readonly string module;
        private readonly int eventCode;
        private readonly string eventText;
        private readonly string eventHint;

        public EventContent(string eventType, string module, int eventCode, string eventText, string eventHint)
        {
            this.eventType = eventType;
            this.module = module;
            this.eventCode = eventCode;
            this.eventText = eventText;
            this.eventHint = eventHint;
        }

        public override string ToString()
        {
            return $"{eventType};{eventCode};{module};{eventText};{eventHint}";
        }
    }
}
