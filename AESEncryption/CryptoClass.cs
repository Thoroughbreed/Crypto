using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Crypto.UTIL;

namespace Crypto
{
    public class CryptoClass
    {
        private List<Password> _passwords;
        private const string _pwHash = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8";
        private string _unlockKey = "C97390943929DB556B200656837B778D";
        private string _iv = "E8B48407387C429B681C7BE4211D1860";

        public CryptoClass()
        {
            _passwords = new();
            LoadFromFile();
        }
        private byte[] GenerateRandomNumber(int length)
        {
            byte[] randomNumber = new byte[length];
            RandomNumberGenerator.Create().GetBytes(randomNumber);
            return randomNumber;
        }

        private byte[] Crypto(byte[] data, byte[] key, byte[] iv, bool encrypt = false)
        {
            using var cryptography = Aes.Create();
            cryptography.Key = key;
            cryptography.Padding = PaddingMode.PKCS7;
            if (encrypt)
            {
                return cryptography.EncryptCbc(data, iv);
            }
            else
            {
                cryptography.Key = key;
                return cryptography.DecryptCbc(data, iv);
            }
        }
        public string[] Encrypt(string data)
        {
            byte[] key = Convert.FromHexString(_unlockKey);
            byte[] i = GenerateRandomNumber(16);
            string[] result =
            {
                Convert.ToHexString(key),
                Convert.ToHexString(i),
                Convert.ToHexString(Crypto(Encoding.UTF8.GetBytes(data), key, i, true))
            };
            return result;
        }

        public string Decrypt(string? key, string iv, string text)
        {
            byte[] k = String.IsNullOrEmpty(key) ? Convert.FromHexString(_unlockKey) : Convert.FromHexString(key);
            byte[] t = Convert.FromHexString(text);
            byte[] i = Convert.FromHexString(iv);
            byte[] decryptedData = Crypto(t, k, i);
            return Encoding.UTF8.GetString(decryptedData);
        }

        public bool CheckPassword(string pw)
        {
            var bytes = Encoding.UTF8.GetBytes(pw);
            using SHA256 sha256 = SHA256.Create();
            var hash = Convert.ToHexString(sha256.ComputeHash(bytes));
            if (hash == _pwHash)
            {
                _unlockKey = hash;
                return true;
            }
            else return false;
        }

        public void AddPassword(string hint, string password)
        {
            if (!string.IsNullOrEmpty(hint) || !string.IsNullOrEmpty(password))
            {
                _passwords.Add(new Password(Encrypt(hint)[2], Encrypt(password)[2]));
                SaveToFile();
            }
        }

        public List<Password> ListPasswords()
        {
            List<Password> decryptedPasswords = new();
            foreach (var password in _passwords)
            {
                var h = Decrypt(_unlockKey, _iv, password.hint);
                var p = Decrypt(_unlockKey, _iv, password.password);
                decryptedPasswords.Add(new Password(h, p));
            }
            return decryptedPasswords;
        }

        public void SaveToFile()
        {
            FileLogger.WriteTo(null, _passwords, false);
        }

        private void LoadFromFile()
        {
            string[] _pwHashes = FileLogger.ReadFrom(false);
            foreach (var password in _pwHashes)
            {
                string[] split = password.Split("\t");
                _passwords.Add(new Password(split[0], split[1]));
            }
        }
    }
}