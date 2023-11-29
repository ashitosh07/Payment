// SecureHashHelper.cs
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Payment
{
    public static class SecureHashHelper
    {
        public static string GenerateSecureHash(Dictionary<string, string> data)
        {
            // Order the data and concatenate it
            StringBuilder orderedData = new StringBuilder();

            foreach (var entry in data.OrderBy(x => x.Key))
            {
                orderedData.Append(entry.Value);
            }

            // Include your secret key
            orderedData.Insert(0, "MWI5MjE3Y2IyZDBkZjA2MzE3OTY2OWZi");

            // Hash the string
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(orderedData.ToString());
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder hashString = new StringBuilder();

                foreach (byte x in hash)
                {
                    hashString.AppendFormat("{0:x2}", x);
                }

                return hashString.ToString();
            }
        }
    }
}
