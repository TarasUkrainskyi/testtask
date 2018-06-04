using System.Collections.Generic;
using System.Text;

namespace TestTask.Helpers
{
    public static class Converter
    {
        public static List<string> ConvertToAccountNumbers(List<StringBuilder> contents)
        {
            var patterns = DictionaryExtensions.DeserializeFromFile(@"patterns.xml");

            if (patterns == null)
                patterns = new Dictionary<string, char>();

            List<string> convertValues = new List<string>();
            StringBuilder convertValue = new StringBuilder();

            for (int i = 0; i < contents.Count; i++)
            {
                char v = '?';

                if (patterns.TryGetValue(contents[i].ToString(), out v))
                {
                    convertValue.Append(v);

                    if ((i + 1) % 9 == 0)
                    {
                        convertValues.Add(convertValue.ToString());
                        convertValue = new StringBuilder();
                    }
                }
            }

            return convertValues;
        }
    }
}
