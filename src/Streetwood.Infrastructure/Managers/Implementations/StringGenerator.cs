using System;
using Streetwood.Core.Managers;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class StringGenerator : IStringGenerator
    {
        public string Generate(int length)
        {
            var rd = new Random();
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
