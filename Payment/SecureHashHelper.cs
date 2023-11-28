using System;
using System.Security.Cryptography;
using System.Text;

namespace Payment
{
    public static class SecureHashHelper
    {
        public static string GenerateSecureHash(string data)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    if (sha256 == null)
                    {
                        // Log or throw an exception indicating SHA256 creation failure
                        throw new InvalidOperationException("SHA256 algorithm is not supported on this system.");
                    }

                    byte[] bytes = Encoding.UTF8.GetBytes(data);

                    if (bytes == null)
                    {
                        // Log or throw an exception indicating data encoding failure
                        throw new InvalidOperationException("Failed to encode data to UTF-8 bytes.");
                    }

                    byte[] hash = sha256.ComputeHash(bytes);

                    if (hash == null)
                    {
                        // Log or throw an exception indicating hash computation failure
                        throw new InvalidOperationException("Failed to compute hash.");
                    }

                    StringBuilder hashString = new StringBuilder();

                    foreach (byte x in hash)
                    {
                        hashString.AppendFormat("{0:x2}", x);
                    }

                    return hashString.ToString();
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Exception in GenerateSecureHash: {ex.Message}");
                return string.Empty; // Or handle the exception as needed
            }
        }
    }
}
