using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using INI.CustomExceptions;

namespace INI
{
    public class INIFileReader : IDisposable
    {
        private StreamReader reader;
        public INIFileReader(string INIFilename)
        {
            reader = new StreamReader(INIFilename);
        }

        public string GetProperty(string section, string ptyKey)
        {
            ptyKey += "=";
            string value = String.Empty;
            try
            {
                bool foundSection = false;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.Contains(section)) 
                    {
                        foundSection = true;
                        continue;
                    }
                    if (foundSection && line.Contains(ptyKey))
                    {
                        value = line.Replace(ptyKey, String.Empty);
                        break;
                    }
                }
                if (String.IsNullOrEmpty(value)) throw new INIPropertyNotFoundException();

            }
            catch (Exception)
            {
                throw;
            }
            return value;
        }

        public Dictionary<string, string> GetProperties(string section)
        {
            var dictionary = new Dictionary<string, string>();
            try
            {
                bool foundSection = false;
                var line = String.Empty;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.Contains(section))
                    {
                        foundSection = true;
                        continue;
                    }

                    if (foundSection)
                    {
                        if (line.StartsWith("[") || String.IsNullOrEmpty(line))
                        {
                            break;
                        }
                        if (!line.StartsWith(";"))
                        {
                            var keyValue = line.Split('=');
                            dictionary.Add(keyValue[0], keyValue[1]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dictionary;
        }

        public virtual void Dispose()
        {
            reader.Dispose();
        }
    }
}
