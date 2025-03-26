using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeA_App
{
    public class RandomObjectGenerator
    {
        static Random random = new Random();

        public static string GenerateRandomObject()
        {
            int objectType = random.Next(4);

            switch (objectType)
            {
                case 0:
                    return GenerateInteger().ToString();
                case 1:
                    return GenerateRealNumber().ToString();
                case 2:
                    return GenerateAlphabeticalString(random.Next(1, 11));
                case 3:
                    return GenerateAlphanumericString(random.Next(1, 11));
                default:
                    return null;
            }
        }

        private static string GenerateAlphabeticalString(int length)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = alphabets[random.Next(alphabets.Length)];
            }

            return new string(result);
        }

        private static string GenerateAlphanumericString(int length)
        {
            string alphaNumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            int leadingSpaces = random.Next(0, 11);
            int trailingSpaces = random.Next(0, 11);

            char[] alphanumeric = new char[length];
            for (int i = 0; i < length; i++)
            {
                alphanumeric[i] = alphaNumericChars[random.Next(alphaNumericChars.Length)];
            }

            return new string(' ', leadingSpaces) + new string(alphanumeric) + new string(' ', trailingSpaces);
        }

        private static double GenerateRealNumber()
        {
            return random.NextDouble() * 1000000;
        }

        private static int GenerateInteger()
        {
            return random.Next(int.MinValue, int.MaxValue);
        }
    }
}
