using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TecJobsAPI.Shared.Utils
{
    public static class ExpandSecret
    {
        public static string ExpandSecretTo256Bits(string secret)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
                byte[] hashedBytes = sha256.ComputeHash(secretBytes);

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}