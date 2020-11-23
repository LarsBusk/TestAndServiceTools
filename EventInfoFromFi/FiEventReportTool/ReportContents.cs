using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiEventReportTool
{
  public class ReportContents
  {
    public string WorkStationName;
    public string Configuration;
    public int MeasureInPeriod;
    public int TotalMeasure;
    public string ChassisId;
    public string SoftWareVersion;
    public DateTime StartDateTime;
    public DateTime EndDateTime;
    public int CountryId;
    public int CompanyId;

    public List<EventContents> EventList;

    public ReportContents()
    {
      EventList = new List<EventContents>();
    }

    public void AddEvent(string eventType, string eventCode, int count, string eventText)
    {
      EventList.Add(new EventContents( eventType,  eventCode,  count,  eventText));
    }

    public override string ToString()
    {
      return $"Workstation: {WorkStationName}\n" +
             $"Configuration: {Configuration} \n" +
             $"Chassis id: {ChassisId} \n" +
             $"Period: {StartDateTime} to {EndDateTime} \n" +
             $"Software version: {SoftWareVersion} \n" +
             $"Samples measured. In period: {MeasureInPeriod} Total: {TotalMeasure}.";
    }
  }
}
