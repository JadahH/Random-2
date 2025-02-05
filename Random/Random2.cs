﻿using System;
using System.Text;
namespace Random;

public class Class1
{

  private static Random random = new Random();

        /// <summary>
        /// Generates a normally distributed random number using the Box-Muller transform.
        /// </summary>
        /// <param name="mean">Mean of the distribution.</param>
        /// <param name="stdDev">Standard deviation.</param>
        /// <returns>A normally distributed random number.</returns>
        public static double GenerateNormalRandom(double mean, double stdDev)
        {
            double u1 = 1.0 - random.NextDouble();
            double u2 = 1.0 - random.NextDouble();
            double normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            return mean + stdDev * normal;
        }  

        /// <summary>
        /// Generates a random password consisting of A-Z, a-z, 0-9, and underscore.
        /// </summary>
        /// <param name="length">Length of the password.</param>
        /// <returns>A random password string.</returns>
        public static string GeneratePassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
            StringBuilder password = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }
            return password.ToString();

}


        /// <summary>
        /// Generates a random color in hex and RGB format.
        /// </summary>
        /// <returns>A tuple containing the hex string and RGB values.</returns>
        public static (string, (int, int, int)) GenerateRandomColor()
        {
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);
            string hex = $"#{r:X2}{g:X2}{b:X2}";
            return (hex, (r, g, b));
        }
    }



