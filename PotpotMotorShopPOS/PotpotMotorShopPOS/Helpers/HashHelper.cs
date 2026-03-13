using System;
using System.Security.Cryptography;
using System.Text;

namespace PotpotMotorShopPOS.Helpers
{
    internal class HashHelper
    {
        // Hash a string using SHA256
        public static string HashPassword(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input cannot be null or empty.");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2")); // convert to hex
                }
                return builder.ToString();
            }
        }

    }
}
