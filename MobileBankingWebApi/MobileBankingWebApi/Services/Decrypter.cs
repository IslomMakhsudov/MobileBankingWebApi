using System.Security.Cryptography;
using System.Text;

namespace MobileBankingWebApi.Services
{
    public class Decrypter
    {
        public string DecryptAes(string hash, string encryptedString)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedString);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(hash);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using var memoryStream = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }
    }
}
