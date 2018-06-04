using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestTask.Helpers
{
    public static class DictionaryExtensions
    {
        public static Dictionary<string, char> DeserializeFromFile(string path)
        {
            try
            {
                using (var fs = File.OpenRead(path))
                {
                    return (Dictionary<string, char>)new BinaryFormatter().Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void SerializeToFile(this Dictionary<string, char> dictionary, string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                     new BinaryFormatter().Serialize(fs, dictionary);
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }    
    }
}
