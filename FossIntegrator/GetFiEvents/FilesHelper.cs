using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetFiEvents
{
    public class FilesHelper
    {
        private Dictionary<string, string> moduleTable;


        public FilesHelper()
        {
            FillModuleTable();
        }
        public string[] GetAllCppFiles(string folder)
        {
            var files = Directory.GetFiles(folder, "*.cpp", SearchOption.AllDirectories);
            return files;
        }

        public List<Tuple<string, string>> GetErrorLines(string file)
        {
            var errorLines = new List<Tuple<string,string>>();
            string errTxt;

            var lines = File.ReadAllLines(file).Select(l => l.Trim())
                .Where(l => !l.StartsWith(@"//")).ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("RS_ERROR"))
                {
                    var ext = 0;

                    if (lines[i].EndsWith(";"))
                    {
                        errTxt =lines[i];
                    }
                    else
                    {
                        errTxt = lines[i];

                        while (!lines[i + ext].EndsWith(";")) 
                        {
                            ext++;
                            errTxt += lines[i + ext];
                        }
                    }

                    errorLines.Add(new Tuple<string, string>(errTxt, file));
                }
            }

            return errorLines;
        }

        public List<string> GetWarningLines(string file)
        {
            var lines = File.ReadAllLines(file).Where(l => l.Contains("RS_WARNING"));
            return lines.ToList();
        }



        public EventContent GetEventContent(string line, string type, string file)
        {
            var errDict = GetErrorTexts(file);

            var elements = SplitEvent(line);
            if (!int.TryParse(elements[0], out var code))
            {
                code = 0;
            }

            var module = Module(elements[1], file);

            var text = elements[2].Trim()
                .Replace("LPCTSTR", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("CString", "");
            text = errDict.ContainsKey(text) ? errDict[text] : text;

            var hint = elements[3];
            return new EventContent(type, module, code, text, hint);
        }

        private string Module(string name, string file)
        {
            if (!moduleTable.ContainsKey(name))
            {
                var fileLines  = File.ReadAllLines(file);
                var idLine = fileLines.FirstOrDefault(l => l.Contains("m_lCurrentDeviceID"));
                if (string.IsNullOrEmpty(idLine)) 
                {
                    return $"UNKNOWN_MODULE ({name})";
                }
                 
                return idLine.Trim().Substring(idLine.IndexOf("="));
            }
                
            return moduleTable[name];
        }

        private string[] SplitEvent(string line)
        {
            var content = line.Substring(line.IndexOf('(') + 1);
            content = content.Substring(0, content.Length - 2);
            var elements = content.Split(',').Select(e => e.Trim());
            return elements.ToArray();
        }

        private void FillModuleTable()
        {
            moduleTable = new Dictionary<string, string>();
            var lines = File.ReadAllLines("DeviceID.txt");
            var modules = lines.Select(l => l.Split(','));
            
            foreach (var m in modules)
            {
                if (m.Length != 5) continue;
                moduleTable.Add(m[0], m[2]);
            }
        }

        private Dictionary<string, string> GetErrorTexts(string file)
        {
            var errorDict = new Dictionary<string, string>();
            string errTxt;
            var folder = Path.GetDirectoryName(file);
            var rcFiles = Directory.GetFiles(folder, "*.rc");
            foreach (var rcFile in rcFiles)
            {
                var lines = File.ReadAllLines(rcFile).Select(l => l.Trim()).ToArray();

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("IDS_") || lines[i].StartsWith("IDP_"))
                    {
                        int ext = 0;
                        if (lines[i].EndsWith("\""))
                        {
                            errTxt = lines[i];
                        }
                        else
                        {
                            errTxt = lines[i];

                            while (!lines[i + ext].EndsWith("\""))
                            {
                                ext++;
                                errTxt += lines[i + ext];
                            }
                        }

                        var errorArr = errTxt.Split('"');
                        errorDict.Add(errorArr[0].Trim(), errorArr[1].Trim());
                    }
                }
            }
            return errorDict;
        }
    }
}
