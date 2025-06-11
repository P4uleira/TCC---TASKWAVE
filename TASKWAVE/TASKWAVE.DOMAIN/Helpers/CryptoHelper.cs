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
        private static readonly string Key = "v8c3#40"; // 32 bytes para AES-256
        private static readonly string IV = "IVv8c3#40"; // 16 bytes para AES

        public static string EncryptToUrlSafe(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

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
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

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
