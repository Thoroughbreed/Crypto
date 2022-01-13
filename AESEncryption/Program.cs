using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                        _original = HideInput();
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
                        _approved = crypto.CheckPassword(HideInput());
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
                        
                        Console.WriteLine("Press any key to continue ...");
                        Console.ReadKey(true);
                        break;
                    
                    case 1:
                        Console.Write("Please type password hint: ");
                        var hint = Console.ReadLine();
                        Console.Write("Please type username: ");
                        var uname = Console.ReadLine();
                        Console.Write("Please type password: ");
                        var pw = HideInput();
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
        /// <summary>
        /// Simple method to hide user-input in the console and replace them with a generic char.
        /// </summary>
        /// <returns>The string the user inputs</returns>
        private static string HideInput()
        {
            StringBuilder input = new();
            while (true)
            {
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.SetCursorPosition(x - 1, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x - 1, y);
                }
                else if( key.KeyChar < 32 || key.KeyChar > 126 )
                {
                    Trace.WriteLine("Output suppressed: no key char"); //catch non-printable chars, e.g F1, CursorUp and so ...
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    input.Append(key.KeyChar);
                    Console.Write("");
                }
            }
            return input.ToString();
        }
    }
}