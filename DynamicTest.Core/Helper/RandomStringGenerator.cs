using System;
using System.Linq;

namespace DynamicTest.Core.Helper
{
    public static class RandomStringGenerator
    {
        private static readonly Random Rnd = new();
        public static string RandomizedString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Rnd.Next(s.Length)]).ToArray());
        }
    }
}