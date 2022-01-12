using System;
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

            var encrypted = crypto.Crypto(Encoding.UTF8.GetBytes(original), key, iv, true);
            var decrypted = crypto.Crypto(encrypted, key, iv, false);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("AES Encryption Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Key = " + Convert.ToBase64String(key));
            Console.WriteLine("IV = " + Convert.ToBase64String(iv));
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + decryptedMessage);
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Please enter key: ");
            var keyInput = Convert.FromBase64String(Console.ReadLine());
            Console.WriteLine("Please enter initialization vector: ");
            var ivInput = Convert.FromBase64String(Console.ReadLine());
            Console.WriteLine("Please enter encrypted message: ");
            var encryptedMsg = Convert.FromBase64String(Console.ReadLine());
            decrypted = crypto.Crypto(encryptedMsg, keyInput, ivInput);
            Console.WriteLine("Your secret message was:");
            Console.WriteLine(Encoding.UTF8.GetString(decrypted));
        }
    }
}
