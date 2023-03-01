using System;
using System.Collections.Generic;
using System.Linq;
using NoraJitterTool.Model;

namespace NoraJitterTool
{
    public class DataHelper
    {
        private readonly NoraJitterData context;
        private readonly Statistics statistics;

        public DataHelper()
        {
            context = new NoraJitterData();
            statistics = new Statistics(context);
        }

        public int AddTestSystem(string serialNumber, decimal chassisId, string type, string systemName)
        {
            if (GetTestSystem(chassisId) != 0) return GetTestSystem(chassisId);

            context.TestSystem.Add(new TestSystem
            {
                ChassisId = chassisId,
                SerialNumber = serialNumber,
                Type = type,
                SystemName = systemName
            });
            context.SaveChanges();
            var testSystemId = context.TestSystem.Max(t => t.TestSystemId);

            return testSystemId;
        }

        public int GetTestSystem(decimal chassisId)
        {
            var systems = context.TestSystem.FirstOrDefault(t => t.ChassisId.Equals(chassisId));
            return systems is null ? 0 : systems.TestSystemId;
        }

        public List<TestSystemComboItem> TestSystems()
        {
            var comboItems = new List<TestSystemComboItem>();
            var systems = context.TestSystem.Distinct().ToList();
            comboItems = systems.Select(s => new TestSystemComboItem(s.SystemName, s.ChassisId)).ToList();
            return comboItems;
        }

        public List<TestSetupComboItems> TestSetups()
        {
            var comboItems = new List<TestSetupComboItems>();
            var setups = context.TestSetup.Distinct().ToList();
            comboItems = setups.Select(s => new TestSetupComboItems(s.TestTime, s.TestSetupId)).ToList();
            return comboItems;
        }

        public List<DelayComboItem> Delays(int testSetupId)
        {
            var comboItems = new List<DelayComboItem>();
            var delays = context.Delays.Where(d => d.TestSetupId.Equals(testSetupId)).ToList();
            comboItems = delays.Select(d => new DelayComboItem(d.SampleNumber, d.DelaysId)).ToList();
            return comboItems;
        }

        public string[] NoraVersions()
        {
            var versions = context.TestSetup.Select(t => t.NoraVersion).Distinct().ToArray();
            return versions;
        }

        public string[] PlatformVersions()
        {
            var versions = context.TestSetup.Select(t => t.PlatformVersion).Distinct().ToArray();
            return versions;
        }

        public int AddNewTestSetup(decimal chassisId, string novaVersion, DateTime testTime, string platformVersion,  string comment, string csvFileName, bool noDelayedResults)
        {
           var testSystem = context.TestSystem.First(t => t.ChassisId.Equals(chassisId));
           testSystem.TestSetup.Add(new TestSetup
           {
               NoraVersion = novaVersion, 
               TestTime = testTime, 
               PlatformVersion = platformVersion, 
               Comment = comment,
               CsvFileName = csvFileName,
               NoDelayedResults = noDelayedResults
           });
           context.SaveChanges();

           return context.TestSetup.Max(t => t.TestSetupId);
        }

        public void RemoveTestSetup(int setupId)
        {
            var testSetup = GetTestSetup(setupId);
            context.TestSetup.Remove(testSetup);
            context.SaveChanges();
        }

        public void RemoveDelay(int delayId)
        {
            var delay = GetDelay(delayId);
            context.Delays.Remove(delay);
            context.SaveChanges();
        }

        public void AddDelays(int testSetupId, List<DelayInfo> delayInfos)
        {
            var testSetup = GetTestSetup(testSetupId);

            foreach (var delayInfo in delayInfos)
            {
                AddDelay(testSetup, delayInfo); 
            }
            
            context.SaveChangesAsync();
        }

        public JitterStatistics GetDelayStatistics(int setupId)
        {
            return statistics.GetDelayStatistics(setupId);
        }

        private void AddDelay(TestSetup testSetup, DelayInfo delayInfo)
        {
            testSetup.Delays.Add(new Delays
            {
                SampleNumber = delayInfo.SampleNumber,
                TimeBetweenSamples = delayInfo.TimeBetweenSamples,
                Delay = delayInfo.Delay,
                OpcServerTimeStamp = delayInfo.OpcTimeStamp,
                SampleDateTime = delayInfo.SampleTimeStamp
            });
        }

        private TestSetup GetTestSetup(int setupId)
        {
            var testSetup = context.TestSetup.First(t => t.TestSetupId.Equals(setupId));
            return testSetup;
        }

        private Delays GetDelay(int delayId)
        {
            var delay = context.Delays.First(d => d.DelaysId.Equals(delayId));
            return delay;
        }
    }
}
