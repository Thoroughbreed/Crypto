using System;
using System.Collections.Generic;
using System.Text;
using Crypto.UTIL;

namespace Crypto
{
    class Program
    {
        private static ASCII _mainMenu;
        private static ASCII _subMenu;
        private static string _original;
        private static bool _approved;
        private static List<Password> _passwords;
        private static CryptoClass crypto;

        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;
            crypto = new CryptoClass();
            ConsoleKeyInfo menuKey;
            _mainMenu = new ASCII(new List<string>
            {
                "Encrypt",
                "Decrypt",
                "Log in",
                "-- EXIT --"
            });

            switch (_mainMenu.Draw())
            {
                case 0:
                    Console.Clear();
                    Console.Write("Enter secret message: ");
                    _original = Console.ReadLine();
                    var result = crypto.Encrypt(_original);
                    string[] uiText = new[] { "KEY", "IV", "CIPHER" };
                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.WriteLine($"{uiText[i]}:\t{result[i]}");
                    }
                    break;
                
                case 1:
                    Console.Clear();
                    Console.WriteLine("Lets try to decrypt then...");
                    Console.Write("Please enter key (press enter for none): ");
                    var key = Console.ReadLine();
                    Console.Write("Please enter integration vector: ");
                    var iv = Console.ReadLine();
                    Console.Write("Please enter cipher text: ");
                    var text = Console.ReadLine();
                    Console.WriteLine(crypto.Decrypt(key, iv, text));
                    break;
                
                case 2:
                    Console.Clear();
                    Console.Write("Please enter passcode: ");
                    _approved = crypto.CheckPassword(Console.ReadLine());
                    if (_approved) LoadSubMenu();
                    else Console.WriteLine("!WRONG PASSWORD!");
                    break;
                case 9:
                    break;
            }

            crypto.SaveToFile();
        }

        static void LoadSubMenu()
        {
            _mainMenu = new ASCII(new List<string>
            {
                "List passwords",
                "Add new password",
                "-- EXIT --"
            });

            switch (_mainMenu.Draw())
            {
                case 0:
                    foreach (var password in crypto.ListPasswords())
                    {
                        Console.WriteLine($"Hint: {password.hint} - Password: {password.password}");
                    }
                    break;
                case 1:
                    Console.Write("Please type password hint: ");
                    var hint = Console.ReadLine();
                    Console.Write("Please type password: ");
                    var pw = Console.ReadLine();
                    crypto.AddPassword(hint, pw);
                    break;
                case 9:
                    break;
            }
        }
    }
}