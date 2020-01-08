using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Streetwood.Core.Extensions
{
    public static class StringExtensions
    {
        public static string AppendRandom(this string str, int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var rnd = new Random();
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[rnd.Next(0, pool.Length)]);
            return $"{str.RemoveSpecialCharacters()}_{new string(chars.ToArray())}";
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public static string GetUniqueFileName(this string value)
        {
            value = value.RemoveSpecialCharacters();
            var random = string.Empty;
            var index = value.LastIndexOf('.');
            var extension = string.Empty;
            if (index > -1)
            {
                extension = value.Substring(index);
            }

            var uniqueName = $"{value.Substring(0, index)}{random.AppendRandom(10)}{extension}";
            return uniqueName.Replace(' ', '_');
        }

        public static string FirstCharToUpper(this string input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString(CultureInfo.InvariantCulture).ToUpper(CultureInfo.InvariantCulture) + input.Substring(1)
            };
        }
    }
}
