using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NiceLittleLogger;

namespace GetFiEvents
{
    public partial class Form1 : Form
    {
        private List<EventContent> events;
        private Logger logger;
        public Form1()
        {
            InitializeComponent();
            events = new List<EventContent>();

            if (File.Exists("lines.txt"))
            {
                File.Delete("lines.txt");
            }

            logger = new Logger("lines.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var errorLines = new List<Tuple<string,string>>();
            var warningLines = new List<string>();
            var fiFolder = "C:\\Users\\lab\\Projects\\Git\\FI\\Foss Integrator";
            var helper = new FilesHelper();
            var files = helper.GetAllCppFiles(fiFolder);

            foreach (var file in files)
            {
                errorLines.AddRange(helper.GetErrorLines(file));
                warningLines.AddRange(helper.GetWarningLines(file));
            }

            foreach (var line in errorLines)
            {
                //logger.LogInfo(line);
                var eventCont = helper.GetEventContent(line.Item1, "Error", line.Item2);
                events.Add(eventCont);
                logger.LogInfo(eventCont.ToString() + line.Item2);
            }
        }
    }
}
