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
            bool mainMenuActive = true;
            do
            {
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

                        Console.WriteLine("Press any key to continue ...");
                        Console.ReadKey(true);
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
                        try
                        {
                            Console.WriteLine(crypto.Decrypt(key, iv, text));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something seems to have happened ...");
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine("Press any key to continue ...");
                        Console.ReadKey(true);
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Please enter passcode: ");
                        _approved = crypto.CheckPassword(Console.ReadLine());
                        if (_approved) LoadSubMenu();
                        else
                        {
                            Console.WriteLine("!WRONG PASSWORD!");
                            Console.WriteLine("Press any key to continue ...");
                            Console.ReadKey(true);
                        }

                        break;

                    case 3:
                        mainMenuActive = false;
                        break;
                    case 9:
                        mainMenuActive = false;
                        break;
                }
            } while (mainMenuActive);

            crypto.SaveToFile();
        }

        static void LoadSubMenu()
        {
            _subMenu = new ASCII(new List<string>
            {
                "List passwords",
                "Add new password",
                "Return to main menu"
            });

            bool subMenu = true;
            do
            {
                switch (_subMenu.Draw())
                {
                    case 0:
                        try
                        {
                            foreach (var password in crypto.ListPasswords())
                            {
                                Console.WriteLine(
                                    $"Hint: {password.hint} - Username: {password.username} - Password: {password.password}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something weird just happened ...");
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 1:
                        Console.Write("Please type password hint: ");
                        var hint = Console.ReadLine();
                        Console.Write("Please type username: ");
                        var uname = Console.ReadLine();
                        Console.Write("Please type password: ");
                        var pw = Console.ReadLine();
                        try
                        {
                            crypto.AddPassword(hint, uname, pw);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something seems to have happened ...");
                            Console.WriteLine(e.Message);
                        }

                        Console.Clear();
                        Console.WriteLine("Password saved. Press any key to continue.");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        subMenu = false;
                        break;
                    case 9:
                        subMenu = false;
                        break;
                }
            } while (subMenu);
        }
    }
}