using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace mattberther.chef
{
    public static class StringHelpers
    {
        public static string ToBase64EncodedSha1String(this string input)
        {
            var s = new SHA1Managed();
            return Convert.ToBase64String(s.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

        public static IEnumerable<string> Split(this string input, int length)
        {
            for (int i = 0; i < input.Length; i += length)
                yield return input.Substring(i, Math.Min(length, input.Length - i));
        }

        public static string ToBase64String(this string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
                
        }

       

    }
}