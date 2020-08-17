using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FindChassisIds
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] chassisIds =
      {
        "6039797851863400400", "8724152550785789952", "3019898971934340100", "15267266651866700000",
        "16944988313201400000", "22817013851897299000"
      };

      string[] lines = File.ReadAllLines("FscIds.csv");

      List<string> serialNumbers = new List<string>();

      foreach (var line in lines)
      {
        string[] elements = line.Split(';');
        string low = elements[2];
        string hi = elements[3];

        foreach (var chassisId in chassisIds)
        {
          if (chassisId.StartsWith(hi))
          {
            serialNumbers.Add(elements[0] + " hi");
          }

          if (chassisId.StartsWith(low))
          {
            serialNumbers.Add(elements[0] + " lo");
          }
        }
      }

      File.WriteAllLines("res.csv", serialNumbers);
    }
  }
}
