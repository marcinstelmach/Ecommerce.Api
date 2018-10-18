using System;
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
            return str + new string(chars.ToArray());
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
    }
}
