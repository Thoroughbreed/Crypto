using System;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    class Program
    {
        static void Main()
        {
            var crypto = new CryptoClass();
            var key = crypto.GenerateRandomNumber(32);
            var iv = crypto.GenerateRandomNumber(16);
            const string original = "Encrypto-testo!";

            Console.WriteLine("Lets try to encrypt!");
            var result = Encrypt(original, key, iv, crypto);
            foreach (var VARIABLE in result)
            {
                Console.WriteLine(VARIABLE);
            }

            Console.WriteLine("Lets try to decrypt then...");
            var print = Decrypt(
                "C7jKInp7Qmc99Gep3YLsQZnT/js/qnXRbFldAPTQDCk=",
                "8X7durkBX/De6ASyPFYV6Q==",
                "TVcDK8KUr6af1YQJXQeLog==",
                crypto);
            Console.WriteLine(print);
        }

        static string[] Encrypt(string data, byte[] key, byte[] iv,CryptoClass c)
        {
            string[] result = {
                                    Convert.ToBase64String(key),
                                    Convert.ToBase64String(iv),
                                    Convert.ToBase64String(c.Crypto(Encoding.UTF8.GetBytes(data), key, iv, true))
                                };
            return result;
        }

        static string Decrypt(string key, string iv, string text, CryptoClass c)
        {
            var t = Convert.FromBase64String(text);
            var k = Convert.FromBase64String(key);
            var i = Convert.FromBase64String(iv);
            var decryptedData = c.Crypto(t,k, i);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
