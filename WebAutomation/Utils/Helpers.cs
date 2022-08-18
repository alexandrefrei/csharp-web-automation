using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace WebAutomation.Utils
{
    public class Helpers
    {

        private static Random _rand = new Random();

        public static string GenerateRandomString(int size)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                var asciiChar = (char)_rand.Next(65, 90);
                sb.Append(asciiChar.ToString());
            }

            return sb.ToString();
        }
    }
}
