using System;
using System.IO;

namespace NiceLittleLogger
{
    public class Logger
    {
        private readonly string _fileName;

        private const string TimeFormat = "yyyy-MM-dd HH:mm:ss,fff";

        /// <summary>
        /// Creates a new instance of the logger with the logfile in the current folder.
        /// </summary>
        /// <param name="fileName">Name of the logfile</param>
        public Logger(string fileName)
        {
            this._fileName = fileName;
            Initiate(string.Empty);
        }

        /// <summary>
        /// Creates a new instance of the logger with the logfile in the given folder.
        /// </summary>
        /// <param name="folder">Folder for the log files</param>
        /// <param name="fileName">Name of the logfile</param>
        public Logger(string folder, string fileName)
        {
            this._fileName = Path.Combine(folder, fileName);
            Initiate(folder);
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        private void Log(string message, string logLevel)
        {
            var logTime = DateTime.UtcNow.ToString(TimeFormat);
            File.AppendAllText(_fileName, $"{logTime} [{logLevel}] {message}\n");
        }

        private long GetSize(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            long size = fileInfo.Length;
            return size;
        }

        private void Initiate(string folder)
        {
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            
            if (!File.Exists(_fileName))
                LogInfo("Start logging.");
        }
    }

}