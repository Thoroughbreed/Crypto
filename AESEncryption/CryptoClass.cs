﻿using System;
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
        // SHA256 hashed master-password
        private const string _pwHash = "0BA8E1E5A89330ED3F159A67FD6C80AD345048B8CE84242BD0CB08B5C4834550";
        // The default unlock-key for en-/decryption of messages
        private string _unlockKey = "C97390943929DB556B200656837B778D";
        // The default i-Vector for en-/decryption of the encrypted List<Password>
        // It uses the SHA256 hash-hex from a part of the master-password converted to bit as the key
        private string _iv = "E8B48407387C429B681C7BE4211D1860";

        /// <summary>
        /// Constructor of the Cryptography Class.
        /// Loads encrypted passwords from file and stores them in memory.
        /// </summary>
        public CryptoClass()
        {
            _passwords = new List<Password>();
            LoadFromFile();
        }
        
        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <param name="length">Length in bytes</param>
        /// <returns>Random number</returns>
        private byte[] GenerateRandomNumber(int length)
        {
            byte[] randomNumber = new byte[length];
            RandomNumberGenerator.Create().GetBytes(randomNumber);
            return randomNumber;
        }

        /// <summary>
        /// This is where the magic happens
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="key">Encryption key</param>
        /// <param name="iv">Integration vector</param>
        /// <param name="encrypt">Encrypt/decrypt (default decrypt)</param>
        /// <returns>Byte of the en/decrypted data</returns>
        private byte[] Crypto(byte[] data, byte[] key, byte[] iv, bool encrypt = false)
        {
            using var cryptography = Aes.Create();
            cryptography.Key = key;
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
        
        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="data">String to be encrypted</param>
        /// <returns>Encryption key, Integration Vector, Cipher text</returns>
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

        /// <summary>
        /// Decrypt a cipher text
        /// </summary>
        /// <param name="key">Encryption key (leave blank for own cipher)</param>
        /// <param name="iv">Integration vector</param>
        /// <param name="text">Cipher text</param>
        /// <returns>Decrypted data</returns>
        public string Decrypt(string? key, string iv, string text)
        {
            byte[] k = String.IsNullOrEmpty(key) ? Convert.FromHexString(_unlockKey) : Convert.FromHexString(key);
            byte[] t = Convert.FromHexString(text);
            byte[] i = Convert.FromHexString(iv);
            byte[] decryptedData = Crypto(t, k, i);
            return Encoding.UTF8.GetString(decryptedData);
        }

        /// <summary>
        /// Checks a string via SHA256 if the password matches the predefined one
        /// </summary>
        /// <param name="pw">Password string</param>
        /// <returns>Boolean</returns>
        public bool CheckPassword(string pw)
        {
            var bytes = Encoding.UTF8.GetBytes(pw);
            using SHA256 sha256 = SHA256.Create();
            var hash = Convert.ToHexString(sha256.ComputeHash(bytes));
            if (hash == _pwHash)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Gets the master-password and sets the unlock key
        /// </summary>
        /// <param name="unlock">Master-password</param>
        public void SetUnlockKey(string unlock)
        {
            var bytes = Encoding.UTF8.GetBytes(unlock);
            using SHA256 sha256 = SHA256.Create();
            _unlockKey = Convert.ToHexString(sha256.ComputeHash(bytes));
        }

        /// <summary>
        /// Adds a new password to the vault and saves it to file.
        /// </summary>
        /// <param name="hint">A password hint (where)</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public void AddPassword(string hint, string username, string password)
        {
            if (!string.IsNullOrEmpty(hint) || !string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                
                var h = Crypto(Encoding.UTF8.GetBytes(hint),
                    Convert.FromHexString(_unlockKey),
                    Convert.FromHexString(_iv), true);
                var u = Crypto(Encoding.UTF8.GetBytes(username),
                    Convert.FromHexString(_unlockKey),
                    Convert.FromHexString(_iv), true);
                var p = Crypto(Encoding.UTF8.GetBytes(password),
                    Convert.FromHexString(_unlockKey),
                    Convert.FromHexString(_iv), true);
                _passwords.Add(new Password(Convert.ToHexString(h), Convert.ToHexString(u), Convert.ToHexString(p)));
                SaveToFile();
            }
        }

        /// <summary>
        /// Lists the encrypted passwords (decrypted)
        /// </summary>
        /// <returns>Decrypted passwords</returns>
        public List<Password> ListPasswords()
        {
            try
            {
                List<Password> decryptedPasswords = new();
                foreach (var password in _passwords)
                {
                    var h = Decrypt(_unlockKey, _iv, password.hint);
                    var u = Decrypt(_unlockKey, _iv, password.username);
                    var p = Decrypt(_unlockKey, _iv, password.password);
                    decryptedPasswords.Add(new Password(h, u, p));
                }
                return decryptedPasswords;
            }
            catch (Exception e)
            {
                FileLogger.WriteTo(e.Message, null);
                throw new BadUser();
            }
        }

        /// <summary>
        /// Saves the passwords to file
        /// </summary>
        public void SaveToFile()
        {
            FileLogger.WriteTo(null, _passwords, false);
        }

        /// <summary>
        /// Loads the passwords from file
        /// </summary>
        private void LoadFromFile()
        {
            string[] pwHashes = FileLogger.ReadFrom(false);
            if (pwHashes != null)
            {
                foreach (var password in pwHashes)
                {
                    string[] split = password.Split("X"); // Security by obscurity, X is not a HEX char
                    try
                    {
                        _passwords.Add(new Password(split[0], split[1], split[2]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        FileLogger.WriteTo(e.Message, null);
                    }
                }
            }
        }
    }
}