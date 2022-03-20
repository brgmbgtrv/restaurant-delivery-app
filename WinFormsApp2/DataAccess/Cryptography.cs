using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WinFormsApp2.DataAccess
{
    class Cryptography
    {
        public static byte[] salt = { 19, 17, 17, 99, 18, 37, 18, 25 };

        public static string Encrypt(HashAlgorithm hashAlgorithm, string input, byte[] salt)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var saltedInput = new byte[salt.Length + bytes.Length];
            Array.Copy(salt, 0, saltedInput, 0, salt.Length);
            Array.Copy(bytes, 0, saltedInput, salt.Length, bytes.Length);
            byte[] data = hashAlgorithm.ComputeHash(saltedInput);
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash, byte[] salt)
        {
            var hashOfInput = Encrypt(hashAlgorithm, input, salt);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
