using System.Collections.Generic;

namespace TestTask.Helpers
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Split(this string s, int size)
        {
            int count = s.Length / size;
            for (int i = 0; i < count; i++)
                yield return s.Substring(i * size, size);

            if (size * count < s.Length)
                yield return s.Substring(size * count);
        }
    }
}
