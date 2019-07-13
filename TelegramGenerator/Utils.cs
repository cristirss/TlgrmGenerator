using System;
using System.Linq;

namespace TelegramGenerator
{
    public class Utils
    {
        private static readonly Random _RND = new Random();

        public static string GenerateHexString(int digits)
        {
            return string.Concat(Enumerable.Range(0, digits).Select(_ => _RND.Next(16).ToString("X")));
        }

        public static string GenerateRandomNumbers(int length = 10)
        {
            //Initiate objects & vars  
            byte[] seed = Guid.NewGuid().ToByteArray();
            Random random = new Random(BitConverter.ToInt32(seed, 0));
            int randNumber = 0;
            //Loop ‘length’ times to generate a random number or character
            String randomNumber = "";
            for (int i = 0; i < length; i++)
            {
                randNumber = random.Next(48, 58);
                randomNumber = randomNumber + (char)randNumber;
                //append random char or digit to randomNumber string

            }
            return randomNumber;
        }
    }
}
