using System;
using System.IO;
using OPCClient.OPCTags;

namespace OPCClient
{
    public static class OPCLogWriter
    {

        public static void WriteTextToFile(string fileName, string text)
        {
            var streamWriter = GetStreamWriter(fileName);
            streamWriter.Write(text);
            streamWriter.Close();
        }

        public static void WriteTextLineToFile(string fileName, string text)
        {
            WriteTextToFile(fileName, text+ Environment.NewLine);
        }

        public static void WriteOPCDataToFile(string fileName, MeatMasterIIOPCTags meatMasterIIOPCTags)
        {
/*
              if (handShake == sampleGroup.Identifier)
                return;

              handShake = sampleGroup.Identifier;
        */
            var streamWriter = GetStreamWriter(fileName);

            streamWriter.Write(meatMasterIIOPCTags.ServerName.PadRight(50) + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + Environment.NewLine);


            foreach (var element in meatMasterIIOPCTags.OPCTags)
            {
                streamWriter.Write(element.ShortName.PadRight(50) +  element + Environment.NewLine);
            }

            streamWriter.WriteLine();
            streamWriter.WriteLine();
            streamWriter.WriteLine();
            streamWriter.Close();

        }

        private static StreamWriter GetStreamWriter(string fileName)
        {
            string combinedFileName = Path.Combine("", fileName);

            StreamWriter streamWriter;
            if (!File.Exists(combinedFileName))
            {
                streamWriter = new StreamWriter(combinedFileName, false);
            }
            else
            {
                streamWriter = new StreamWriter(combinedFileName, true);
            }
            return streamWriter;
        }
    }
}
