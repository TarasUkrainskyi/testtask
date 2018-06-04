using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask.Helpers;

namespace TestTask.Services
{
    public class PatternsService
    {
        public void UpdatePatterns(List<StringBuilder> contents)
        {
            Dictionary<string, char> patterns = DictionaryExtensions.DeserializeFromFile(@"patterns.xml");

            if (patterns == null)
                patterns = new Dictionary<string, char>();

            foreach (var pattern in contents)
            {
                if (!patterns.ContainsKey(pattern.ToString()))
                {
                    patterns.Add(pattern.ToString(), '?');
                    Console.WriteLine("\n" + pattern);
                }
            }

            patterns.SerializeToFile(@"patterns.xml");
        }

        public void EditPatterns()
        {
            var patterns = DictionaryExtensions.DeserializeFromFile(@"patterns.xml");

            if (patterns == null)
                Console.WriteLine("\nSorry, no patterns");

            ShowPatterns(patterns);

            Console.WriteLine("\nPlease, input number pattern for edit");
           
            int[] patternNumbers = Enumerable.Range(1, patterns.Count).ToArray();
            int number = InputHelper.ValidateTwoDigitNumberInput(Console.ReadLine(), patternNumbers);
            var pattern = patterns.ToList()[number - 1];

            Console.WriteLine("\nPlease, input new value for pattern");
            Console.WriteLine("\n" + pattern.Key);

            char value = InputHelper.ValidateLetterOrDigitInput(Console.ReadKey());

            patterns[pattern.Key] = value;
            
            patterns.SerializeToFile(@"patterns.xml");
                        
            Console.WriteLine("\n\nСhanges saved successfully");
        }

        public void ShowPatterns()
        {
            var patterns = DictionaryExtensions.DeserializeFromFile(@"patterns.xml");

            if (patterns == null)
                Console.WriteLine("\nSorry, no patterns");

            ShowPatterns(patterns);
        }

        public void ShowPatterns(Dictionary<string, char> patterns)
        {
            int i = 0;

            foreach (var pattern in patterns)
            {
                i++;
                Console.WriteLine("\n" + i + ". \n" + pattern.Key + " - " + pattern.Value);
            }
        }
    }
}
