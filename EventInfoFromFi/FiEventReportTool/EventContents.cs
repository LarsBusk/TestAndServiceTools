using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiEventReportTool
{
  public class EventContents
  {
    public string EventType;
    public string EventCode;
    public int Count;
    public string EventText;

    public EventContents(string eventType, string eventCode, int count, string eventText)
    {
      this.EventType = eventType;
      this.EventCode = eventCode;
      this.Count = count;
      this.EventText = RemoveBadCharacters(eventText);
    }

    private string RemoveBadCharacters(string eventText)
    {
      eventText = eventText.Replace("'", "");

      return eventText;
    }
  }
}
