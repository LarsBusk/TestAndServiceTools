using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FiEventReportTool
{
  class EventReportXmlHelper
  {
    private ReportContents reportContents;
    private XDocument eventReport;

    public EventReportXmlHelper(string fileName)
    {
      eventReport = XDocument.Load(fileName);
      reportContents = new ReportContents();
    }

    public ReportContents ReadReport()
    {
      ReadReportHeader();
      ReadEventList();

      return reportContents;
    }

    private void ReadReportHeader()
    {
      var topElements = this.eventReport.Root.Elements("top");
      var firstTop = topElements.First(e => e.Elements("system").Any());
      var secondTop = topElements.First(e => e.Elements("time").Any());

      var systemElement = firstTop.Element("system");
      reportContents.WorkStationName = systemElement.Element("workstationname").Attribute("value").Value;
      reportContents.Configuration = systemElement.Element("configuration").Attribute("value").Value;
      var instrumentElement = systemElement.Element("instrument");
      if (instrumentElement != null)
      {
        reportContents.ChassisId = instrumentElement.Attribute("value3").Value;
        reportContents.MeasureInPeriod = int.Parse(instrumentElement.Attribute("value").Value);
        reportContents.TotalMeasure = int.Parse(instrumentElement.Attribute("value2").Value);
      }
      else
      {
        reportContents.ChassisId = string.Empty;
        reportContents.MeasureInPeriod = 0;
        reportContents.TotalMeasure = 0;
      }

      reportContents.SoftWareVersion = firstTop.Element("swversion").Attribute("version").Value;

      reportContents.StartDateTime = GetTime(secondTop.Element("time").Attribute("start").Value);
      reportContents.EndDateTime = GetTime(secondTop.Element("time").Attribute("end").Value);
    }

    private void ReadEventList()
    {
      var eventsElement = eventReport.Root.Element("events");
      var eventTypeElements = eventsElement.Elements("eventtype");

      foreach (var eventTypeElement in eventTypeElements)
      {
        string eventType = eventTypeElement.Attribute("type").Value;
        var eventElements = eventTypeElement.Elements("event");

        foreach (var eventElement in eventElements)
        {
          string eventId = eventElement.Attribute("id").Value;
          string text = @eventElement.Attribute("text").Value;
          int count = int.Parse(eventElement.Attribute("count").Value);

          reportContents.AddEvent(eventType, eventId, count, text);
        }
      }
    }

    private DateTime GetTime(string dateString)
    {
      DateTime tid;

      if (DateTime.TryParse(dateString, out tid))
      {
        return tid;
      }

      return DateTime.MinValue;
    }
  }
}
