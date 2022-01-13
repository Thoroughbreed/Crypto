using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Crypto.UTIL;

namespace Crypto
{
    class Program
    {
        private static CryptoClass? _crypto;

        private static void Main()
        {
            FileLogger.WriteTo("Application start", null);
            Console.Clear();
            Console.CursorVisible = false;
            _crypto = new CryptoClass();
            ASCII mainMenu = new (new List<string>
            {
                "Encrypt",
                "Decrypt",
                "Log in",
                "-- EXIT --"
            });
            bool mainMenuActive = true;
            do
            {
                switch (mainMenu.Draw())
                {
                    case 0:
                        Console.Clear();
                        Console.Write("Enter secret message: ");
                        var result = _crypto.Encrypt(HideInput());
                        string[] uiText = new[] { "KEY", "IV", "CIPHER" };
                        for (int i = 0; i < result.Length; i++)
                        {
                            Console.WriteLine($"{uiText[i]}:\t{result[i]}");
                        }
                        FileLogger.WriteTo("Encryption successful", null);

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
                            Console.WriteLine(_crypto.Decrypt(key, iv, text));
                            FileLogger.WriteTo("Decryption successful", null);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something seems to have happened ...");
                            Console.WriteLine(e.Message);
                            FileLogger.WriteTo(e.Message, null);
                        }

                        Console.WriteLine("Press any key to continue ...");
                        Console.ReadKey(true);
                        break;

                    case 2:
                        Console.Clear();
                        FileLogger.WriteTo("Login attempt", null);
                        Console.Write("Please enter passcode: ");
                        if (_crypto.CheckPassword(HideInput())) LoadSubMenu();
                        else
                        {
                            Console.WriteLine("!WRONG PASSWORD!");
                            FileLogger.WriteTo("Wrong password typed!", null);
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
            _crypto.SaveToFile();
            FileLogger.WriteTo("Application terminated", null);
        }
        
        /// <summary>
        /// Sub-menu after successful login
        /// </summary>
        private static void LoadSubMenu()
        {
            ASCII subMenu = new (new List<string>
            {
                "List passwords",
                "Add new password",
                "Return to main menu"
            });

            bool subMenuActive = true;
            do
            {
                switch (subMenu.Draw())
                {
                    case 0:
                        try
                        {
                            foreach (var password in _crypto.ListPasswords())
                            {
                                Console.WriteLine(
                                    $"Hint: {password.hint} - Username: {password.username} - Password: {password.password}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something weird just happened ...");
                            Console.WriteLine(e.Message);
                            FileLogger.WriteTo(e.Message, null);
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
                            _crypto.AddPassword(hint, uname, pw);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something seems to have happened ...");
                            Console.WriteLine(e.Message);
                            FileLogger.WriteTo(e.Message, null);
                        }

                        Console.Clear();
                        Console.WriteLine("Password saved. Press any key to continue.");
                        Console.ReadKey(true);
                        break;
                    
                    case 2:
                        subMenuActive = false;
                        break;
                    case 9:
                        subMenuActive = false;
                        break;
                }
            } while (subMenuActive);
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
                    
                    FileLogger.WriteTo($"Weird input detected - {key.KeyChar}", null);
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