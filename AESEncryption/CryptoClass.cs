using System;
using System.IO;
using System.Security.Cryptography;

namespace Crypto
{
    public class CryptoClass
    {
        public byte[] GenerateRandomNumber(int length)
        {
            byte[] randomNumber = new byte[length];
            RandomNumberGenerator.Create().GetBytes(randomNumber);
            return randomNumber;
        }

        public byte[] Crypto(byte[] data, byte[] key, byte[] iv, bool encrypt = false)
        {
            ICryptoTransform mode;
            using var cryptography = Aes.Create();
            cryptography.Key = key;
            if (encrypt)
            {
                return cryptography.EncryptCbc(data, iv);
            }
            else
            {
                return cryptography.DecryptCbc(data, iv);
            }
        }
    }
}