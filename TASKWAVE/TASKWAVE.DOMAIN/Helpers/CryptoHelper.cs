using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TASKWAVE.DOMAIN.Helpers
{
    public static class CryptoHelper
    {
        private static readonly byte[] KeyBytes = HexStringToByteArray("0793cae1d88c581b193ba8561f8f4c45");
        private static readonly byte[] IVBytes = HexStringToByteArray("ca93b33c57308ce05efa9d68a09c1884");

        private static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length / 2)
                .Select(i => Convert.ToByte(hex.Substring(i * 2, 2), 16))
                .ToArray();
        }


        public static string EncryptToUrlSafe(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = KeyBytes;
            aes.IV = IVBytes;


            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var writer = new StreamWriter(cs))
            {
                writer.Write(plainText);
            }

            var encryptedBytes = ms.ToArray();
            var base64 = Convert.ToBase64String(encryptedBytes);
            return HttpUtility.UrlEncode(Base64UrlEncode(base64));
        }

        public static string DecryptFromUrlSafe(string encryptedBase64Url)
        {
            var base64 = Base64UrlDecode(HttpUtility.UrlDecode(encryptedBase64Url));
            var encryptedBytes = Convert.FromBase64String(base64);

            using var aes = Aes.Create();
            aes.Key = KeyBytes;
            aes.IV = IVBytes;


            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(encryptedBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs);
            return reader.ReadToEnd();
        }

        private static string Base64UrlEncode(string input)
        {
            return input.Replace("+", "-").Replace("/", "_").Replace("=", "");
        }

        private static string Base64UrlDecode(string input)
        {
            string output = input.Replace("-", "+").Replace("_", "/");
            switch (output.Length % 4)
            {
                case 2: output += "=="; break;
                case 3: output += "="; break;
            }
            return output;
        }
    }
}
