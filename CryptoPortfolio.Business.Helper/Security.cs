using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptoPortfolio.Business.Helper
{
    public class Security
    {
        public string SHA256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public string GetHMACSignature(string secretKey, string totalParams)
        {
            var paramBytes = Encoding.UTF8.GetBytes(totalParams);
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var hash = new HMACSHA256(keyBytes);
            var computedHash = hash.ComputeHash(paramBytes);
            return BitConverter.ToString(computedHash).Replace("-", "").ToLower();
        }

        public string GetKuCoinHMCACSignature(string secretKey, string totalParams)
        {
            secretKey = secretKey ?? "";
            var encoding = new ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            byte[] messageByte = encoding.GetBytes(totalParams);
            using (var mac = new HMACSHA256(keyByte))
            {
                byte[] hashMessage = mac.ComputeHash(messageByte);
                return Convert.ToBase64String(hashMessage);
            }

            //    var paramBytes = Encoding.UTF8.GetBytes(totalParams);
            //var encodedParam = Convert.ToBase64String(paramBytes);

            //var secretBytes = Encoding.UTF8.GetBytes(secretKey);
            //var mac = new HMACSHA256(secretBytes);
            
        }
    }
}
