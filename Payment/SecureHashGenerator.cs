using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Payment
{
    public static class SecureHashGenerator
    {
        public static string GenerateSecureHash(string secretKey, SortedDictionary<string, string> parameters)
        {
            StringBuilder orderedString = new StringBuilder();
            orderedString.Append(secretKey);

            foreach (var kv in parameters)
            {
                orderedString.Append(kv.Value);
            }

            using (SHA256 sha256 = SHA256Managed.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(orderedString.ToString());
                byte[] hash = sha256.ComputeHash(bytes);

                return string.Join("", hash);
            }
        }
    }
}
