using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Resx2Csv
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      string resourceFile = args.Length > 0 ? args[0] : "EventLocalizationResources.resx";

      XDocument doc = XDocument.Load(resourceFile);

      XElement root = doc.Root;

      IEnumerable<XElement> dataeElements = root.Elements("data");

      List<EventEntry> eventEntries = new List<EventEntry>();

      foreach (XElement dataeElement in dataeElements)
      {
        string eventName = dataeElement.Attribute("name").Value;
        int lastUnder = eventName.LastIndexOf("_");
        if (lastUnder != -1)
        {
          EventEntry eventEntry = new EventEntry(eventName.Substring(0, lastUnder));
          eventEntry.Type = eventName.Substring(lastUnder + 1);
          eventEntry.Message =  dataeElement.Element("value").Value.Replace("\n", " ");
          eventEntries.Add(eventEntry);
        }
      }


      List<string> csvLines = new List<string>();
      csvLines.Add("Unit;Source;ID;Message;Hint");

      foreach (EventEntry eventEntry in eventEntries)
      {
        if (eventEntry.Type == "Message")
        {
          string csvLine = eventEntry.Unit + ";" + eventEntry.Module + ";" + eventEntry.ErrorNumber + ";" + eventEntry.Message + ";";
          EventEntry hintEntry = eventEntries.FirstOrDefault(e => e.Type == "Hint" && e.Error == eventEntry.Error);
          if (hintEntry != null)
          {
            csvLine += hintEntry.Message.Replace("\n", " ");
          }

          csvLines.Add(csvLine);
        }
      }

      File.WriteAllLines("Errors.csv", csvLines);
    }
  }
}
