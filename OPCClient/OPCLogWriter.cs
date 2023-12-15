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
