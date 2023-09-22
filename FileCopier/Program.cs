using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace FileCopier
{
    internal class Program
    {
        private static string sourceFolder;
        private static string targetFolder;

        static void Main(string[] args)
        {
            sourceFolder = Properties.Settings.Default.FromFolder;
            targetFolder = Properties.Settings.Default.ToFolder;
            var watcher = new FileSystemWatcher
            {
                Path = sourceFolder,
                EnableRaisingEvents = true,
                Filter = "*.csv"
            };
            watcher.Created += Watcher_Created;
            var timer = new Timer(CopyRest, null, TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(10));
            Console.Read();
        }

        private static void CopyRest(object state)
        {
            var fileNames = Directory.GetFiles(sourceFolder, "*.csv");
            foreach (var file in fileNames)
            {
                MoveFile(Path.GetFileName(file));
            }
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            var fileName = Path.GetFileName(e.FullPath);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            MoveFile(fileName);
        }

        private static void MoveFile(string fileName)
        {
            var sourceFileName = Path.Combine(sourceFolder, fileName);
            var destFileName = Path.Combine(targetFolder, fileName);
            try
            {
                File.Copy(sourceFileName, destFileName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }

            File.Delete(sourceFileName);
        }

    }
}
