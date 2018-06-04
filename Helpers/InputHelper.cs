using System;
using System.Linq;

namespace TestTask.Helpers
{
    public static class InputHelper
    {
        public static int ValidateDigitInput(ConsoleKeyInfo input, int[] values)
        {
            if (char.IsDigit(input.KeyChar))
            {
                int number = int.Parse(input.KeyChar.ToString());

                if (values.Contains(number))
                    return number;
            }

            Console.WriteLine("\nPlease, insert a digit from the list");

            return ValidateDigitInput(Console.ReadKey(), values);
        }

        public static char ValidateLetterOrDigitInput(ConsoleKeyInfo input)
        {            
            if (!char.IsLetterOrDigit(input.KeyChar))
            {
                Console.WriteLine("\nPlease, insert a letter or digit");

                return ValidateLetterOrDigitInput(Console.ReadKey());
            }

            return input.KeyChar;
        }

        public static int ValidateTwoDigitNumberInput(string input, int[] values)
        {
            if ((input.Count() == 1  || (input.Count() == 2 && char.IsDigit(input[1]))) && char.IsDigit(input[0]))
            {
                int number = int.Parse(input);

                if (values.Contains(number))
                    return number;
            }             

            Console.WriteLine("\nPlease, insert a number from the list");

            return ValidateTwoDigitNumberInput(Console.ReadLine(), values);
        }
    }
}
