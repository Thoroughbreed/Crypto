using System;
using System.Collections.Generic;
using System.Threading;

namespace Crypto.UTIL
{
    public class ASCII
    {
        public List<string> MenuItems { get; }
        public event Action<int> IndexChanged;

        private readonly int _screenWidth;
        private readonly int _screenHeight;
        private readonly int _offset;
        private readonly bool _clear;

        /// <summary>
        /// Starts a horizontal wash-thing (must be started with the return value, default 1)
        /// </summary>
        /// <param name="x">Cursor position</param>
        /// <param name="y">Cursor position</param>
        /// <param name="key">Program step</param>
        /// <returns>Program step</returns>
        public static int HorisontalWash(int x, int y, int key)
        {
            if (key > 9) key = 1;
            if (key == 1)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("-. .-.   .-. .-.   .-. .-.   .");
                Console.WriteLine("||\\|||\\ /|||\\|||\\ /|||\\|||\\ /|");
                Console.WriteLine("|/ \\|||\\|||/ \\|||\\|||/ \\|||\\||");
                Console.WriteLine("~   `-~ `-`   `-~ `-`   `-~ `-");
            }
            if (key == 2)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(". .-.   .-. .-.   .-. .-.   .-");
                Console.WriteLine("|\\|||\\ /|||\\|||\\ /|||\\|||\\ /||");
                Console.WriteLine("/ \\|||\\|||/ \\|||\\|||/ \\|||\\|||");
                Console.WriteLine("   `-~ `-`   `-~ `-`   `-~ `-~");
            }
            if (key == 3)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" .-.   .-. .-.   .-. .-.   .-.");
                Console.WriteLine("\\|||\\ /|||\\|||\\ /|||\\|||\\ /|||");
                Console.WriteLine(" \\|||\\|||/ \\|||\\|||/ \\|||\\|||/");
                Console.WriteLine("  `-~ `-`   `-~ `-`   `-~ `-~ ");
            }
            if (key == 4)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(".-.   .-. .-.   .-. .-.   .-. ");
                Console.WriteLine("|||\\ /|||\\|||\\ /|||\\|||\\ /|||\\");
                Console.WriteLine("\\|||\\|||/ \\|||\\|||/ \\|||\\|||/ ");
                Console.WriteLine(" `-~ `-`   `-~ `-`   `-~ `-~  ");
            }
            if (key == 4)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("-.   .-. .-.   .-. .-.   .-. .");
                Console.WriteLine("||\\ /|||\\|||\\ /|||\\|||\\ /|||\\|");
                Console.WriteLine("|||\\|||/ \\|||\\|||/ \\|||\\|||/ \\");
                Console.WriteLine("`-~ `-`   `-~ `-`   `-~ `-~   ");
            }
            if (key == 5)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(".   .-. .-.   .-. .-.   .-. .-");
                Console.WriteLine("|\\ /|||\\|||\\ /|||\\|||\\ /|||\\||");
                Console.WriteLine("||\\|||/ \\|||\\|||/ \\|||\\|||/ \\|");
                Console.WriteLine("-~ `-`   `-~ `-`   `-~ `-~   `");
            }
            if (key == 6)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("   .-. .-.   .-. .-.   .-. .-.");
                Console.WriteLine("\\ /|||\\|||\\ /|||\\|||\\ /|||\\|||");
                Console.WriteLine("|\\|||/ \\|||\\|||/ \\|||\\|||/ \\||");
                Console.WriteLine("~ `-`   `-~ `-`   `-~ `-~   `-");
            }
            if (key == 7)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("  .-. .-.   .-. .-.   .-. .-. ");
                Console.WriteLine(" /|||\\|||\\ /|||\\|||\\ /|||\\|||\\");
                Console.WriteLine("\\|||/ \\|||\\|||/ \\|||\\|||/ \\|||");
                Console.WriteLine(" `-`   `-~ `-`   `-~ `-~   `-~");
            }
            if (key == 8)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" .-. .-.   .-. .-.   .-. .-.  ");
                Console.WriteLine("/|||\\|||\\ /|||\\|||\\ /|||\\|||\\ ");
                Console.WriteLine("|||/ \\|||\\|||/ \\|||\\|||/ \\|||\\");
                Console.WriteLine("`-`   `-~ `-`   `-~ `-~   `-~ ");
            }
            if (key == 9)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(".-. .-.   .-. .-.   .-. .-.   ");
                Console.WriteLine("|||\\|||\\ /|||\\|||\\ /|||\\|||\\ /");
                Console.WriteLine("||/ \\|||\\|||/ \\|||\\|||/ \\|||\\|");
                Console.WriteLine("-`   `-~ `-`   `-~ `-~   `-~ `");
            }
            key++;
            return key;
        }

        /// <summary>
        /// Starts a vertical wash-thing - runs infinite (until thread dies)
        /// </summary>
        /// <param name="x">Cursor position</param>
        /// <param name="y">Cursor position</param>
        public static void VerticalWash(int x, int y)
        {
            int x1;
            int y1;
            while (1 == 1)
            {
                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x, y);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                Thread.Sleep(150);

                x1 = x; y1 = y;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o %:% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %:::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %:::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %:% o(86098)                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("  (86098)o                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("6098)o %::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("098)o %::::::% o9                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine(" 6o %::::::% o(860                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("    6o %::% o(8609                ");
                y1++;
                Console.SetCursorPosition(x1, y1);
                Console.WriteLine("       o(86098)                ");
                Thread.Sleep(150);
            }
        }

        /// <summary>
        /// Displays a "loading" spinner - spins 1000 times (or until thread dies)
        /// </summary>
        /// <param name="z">Cursor position</param>
        /// <param name="y">Cursor position</param>
        public static void Spinner(int z, int y)
        {
            int x = 0;
            for (int i = 0; i < 1000; i++)
            {
                Console.SetCursorPosition(z, y);
                if (x == 0) { Console.Write("/"); x = 1; }
                else if (x == 1) { Console.Write("-"); x = 2; }
                else if (x == 2) { Console.Write("\\"); x = 3; }
                else if (x == 3) { Console.Write("|"); x = 0; }
                Thread.Sleep(150);
            }
        }

        /// <summary>
        /// Displays a "loading" spinner - spins until the boolean is false
        /// </summary>
        /// <param name="z">Cursor position</param>
        /// <param name="y">Cursor position</param>
        /// <param name="x">Bool - spin now?</param>
        public static void SpinnerBool(int z, int y, bool x)
        {
            int i = 0;
            while (x)
            {
                Console.SetCursorPosition(z, y);
                if (i == 0) { Console.Write("/"); i = 1; }
                else if (i == 1) { Console.Write("-"); i = 2; }
                else if (i == 2) { Console.Write("\\"); i = 3; }
                else if (i == 3) { Console.Write("|"); i = 0; }
                Thread.Sleep(150);
            }
        }

        /// <summary>
        /// Displays the administrator ASCII art menu
        /// </summary>
        /// <returns>isAdmin?</returns>
        public static bool AdminMenu()
        {
            Console.Clear();
            Console.WriteLine(@"8888888888888888888888888888888888888888888888888888888888888");
            Console.WriteLine(@"8888888888888888888888888888888888888888888888888888888888888");
            Console.WriteLine(@"8888888888888888888888888P""""  """"98888888888888888888888888888");
            Console.WriteLine(@"8888888888888888P""88888P          988888""98888888888888888888");
            Console.WriteLine(@"8888888888888888  ""9888            888P""  8888888888888888888");
            Console.WriteLine(@"888888888888888888bo ""9  d8o  o8b  P"" od888888888888888888888");
            Console.WriteLine(@"888888888888888888888bob 98""  ""8P dod888888888888888888888888");
            Console.WriteLine(@"888888888888888888888888    db    888888888888888888888888888");
            Console.WriteLine(@"88888888888888888888888888      88888888888888888888888888888");
            Console.WriteLine(@"88888888888888888888888P""9bo  odP""988888888888888888888888888");
            Console.WriteLine(@"88888888888888888888P"" od88888888bo ""988888888888888888888888");
            Console.WriteLine(@"888888888888888888   d88888888888888b   888888888888888888888");
            Console.WriteLine(@"8888888888888888888oo8888888888888888oo8888888888888888888888");
            Console.WriteLine(@"8888888888888888888888888888888888888888888888888888888888888");
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║             WELCOME TO THE SECRET ADMIN MODE!             ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════╣");
            Console.WriteLine("║                      Please select:                       ║");
            Console.WriteLine("║     _.........._                         _.........._     ║");
            Console.WriteLine("║    | |  DOOM  | |    [I]nspect          | |  DOOM  | |    ║");
            Console.WriteLine("║    | | DISK 1 | |    [D]issect          | | DISK 2 | |    ║");
            Console.WriteLine("║    | |  OF 4  | |    [K]ill init        | |  OF 4  | |    ║");
            Console.WriteLine("║    | |________| |    [F]ind user        | |________| |    ║");
            Console.WriteLine("║    |   ______   |    [A]ll information  |   ______   |    ║");
            Console.WriteLine("║    |  |    | |  |                       |  |    | |  |    ║");
            Console.WriteLine("║    |__|____|_|__|    [X] Exit           |__|____|_|__|    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            return true;
        }


        // Converts GIF to ASCII art
        /* Virker ikke på .Net Core til macOS :(
        public static void ConvertGif()
        {
            Image image = Image.FromFile(@"C:\some_animated_gif.gif");
            FrameDimension dimension = new FrameDimension(
                                image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);
            StringBuilder sb;

            // Remember cursor position
            int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '#', '#', '@', '%', '=', '+',
                        '*', ':', '-', '.', ' ' };
            for (int i = 0; ; i = (i + 1) % frameCount)
            {
                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }

                Console.SetCursorPosition(left, top);
                Console.Write(sb.ToString());

                Thread.Sleep(100);
            }
        }
        */

        /// <summary>
        /// Shows the old-style user menu
        /// </summary>
        /// <param name="pname">Parking lot name</param>
        /// <param name="wname">Wash name</param>
        static void Menu(string pname, string wname)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════╗");
            Console.WriteLine("║  {0} | {1}  ║", wname, pname);
            Console.WriteLine("╠══════════════════════════╣");
            Console.WriteLine("║      Please select:      ║");
            Console.WriteLine("║      [W]ash car          ║");
            Console.WriteLine("║      [O]pen account      ║");
            Console.WriteLine("║      [S]ee account       ║");
            Console.WriteLine("║      [H]eureka!          ║");
            Console.WriteLine("║                          ║");
            Console.WriteLine("║      [P]ark              ║");
            Console.WriteLine("║      [A]dd time          ║");
            Console.WriteLine("║      [R]evoke ticket     ║");
            Console.WriteLine("║      [C]heckout parking  ║");
            Console.WriteLine("║                          ║");
            Console.WriteLine("║      [X] Exit            ║");
            Console.WriteLine("╚══════════════════════════╝");
        }

        /// <summary>
        /// Initiates the "fancy menu"
        /// </summary>
        /// <param name="menuItems">String-list of menu items</param>
        /// <param name="screenWidth">Optional - console width</param>
        /// <param name="screenHeight">Optional - console height</param>
        /// <param name="offset">Optional - x offset</param>
        /// <param name="clear">Optional - clears console (default true)</param>
        public ASCII(List<string> menuItems, int screenWidth = -1, int screenHeight = -1, int offset = 0, bool clear = true)
        {
            MenuItems = menuItems;
            _screenWidth = screenWidth == -1 ? Console.WindowWidth : screenWidth;
            _screenHeight = screenHeight == -1 ? Console.WindowHeight : screenHeight;
            _offset = offset;
            _clear = clear;
        }

        /// <summary>
        /// Draws the menu itself
        /// </summary>
        /// <returns>Integer for the list index</returns>
        public int Draw()
        {
            if (_clear)
                Console.Clear();

            Console.CursorVisible = false;
            int posY = (_screenHeight - MenuItems.Count) / 2;
            int selectedItemIndex = 0;

            #region Input validation
            if (posY <= 0)
                throw new InvalidOperationException("There is not enough space");
            if (MenuItems.TrueForAll(i => i.Length > _screenWidth - 4))
                throw new InvalidOperationException("One of the items are longer than the screen width");
            #endregion

            while (true)
            {
                // Centers text vertically
                posY = (_screenHeight - MenuItems.Count) / 2;
                foreach (var item in MenuItems)
                {
                    // Centers text horizontally
                    int posX = (_screenWidth - item.Length) / 2 + _offset;
                    if (MenuItems.IndexOf(item) == selectedItemIndex)
                    {
                        Console.SetCursorPosition(posX, posY++);
                        Console.Write($"[ ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{item}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" ]");
                        IndexChanged?.Invoke(selectedItemIndex);
                    }
                    else
                    {
                        Console.SetCursorPosition(posX, posY++);
                        Console.WriteLine($"  {item}  ");
                    }
                }

                #region Controls
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedItemIndex <= 0)
                            selectedItemIndex = MenuItems.Count - 1;
                        else
                            selectedItemIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedItemIndex >= MenuItems.Count - 1)
                            selectedItemIndex = 0;
                        else
                            selectedItemIndex++;
                        break;
                    case ConsoleKey.Escape:
                        return 9;
                    case ConsoleKey.X:
                        return 9;
                #endregion
                    case ConsoleKey.Enter:
                        // Uncomment line below to show the cursor
                        // Console.CursorVisible = true;

                        // { "Wash car", "Create Account", "See account", "See wash status", "Park car", "Add time", "Revoke ticket", "Checkout parking", "Exit" });
                        if (selectedItemIndex == 0) return 0;
                        if (selectedItemIndex == 1) return 1;
                        if (selectedItemIndex == 2) return 2;
                        if (selectedItemIndex == 3) return 3;
                        if (selectedItemIndex == 4) return 4;
                        if (selectedItemIndex == 5) return 5;
                        if (selectedItemIndex == 6) return 6;
                        if (selectedItemIndex == 7) return 7;
                        if (selectedItemIndex == 8) return 8;
                        break;
                }
            }
        }

        /// <summary>
        /// DOOM!
        /// </summary>
        public static void DOOM()
        {
            int posX = (Console.WindowWidth - 71) / 2;
            int posY = 5;
            Console.WriteLine("");

            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("=================     ===============     ===============   ========  ========");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("\\\\ . . . . . . .\\\\   //. . . . . . .\\\\   //. . . . . . .\\\\  \\\\. . .\\\\// . . //");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||. . ._____. . .|| ||. . ._____. . .|| ||. . ._____. . .|| || . . .\\/ . . .||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("|| . .||   ||. . || || . .||   ||. . || || . .||   ||. . || ||. . . . . . . ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||. . ||   || . .|| ||. . ||   || . .|| ||. . ||   || . .|| || . | . . . . .||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("|| . .||   ||. _-|| ||-_ .||   ||. . || || . .||   ||. _-|| ||-_.|\\ . . . . ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||. . ||   ||-'  || ||  `-||   || . .|| ||. . ||   ||-'  || ||  `|\\_ . .|. .||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("|| . _||   ||    || ||    ||   ||_ . || || . _||   ||    || ||   |\\ `-_/| . ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||_-' ||  .|/    || ||    \\|.  || `-_|| ||_-' ||  .|/    || ||   | \\  / |-_.||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||    ||_-'      || ||      `-_||    || ||    ||_-'      || ||   | \\  / |  `||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||    `'         || ||         `'    || ||    `'         || ||   | \\  / |   ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||            .===' `===.         .==='.`===.         .===' /==. |  \\/  |   ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||         .=='   \\_|-_ `===. .==='   _|_   `===. .===' _-|/   `==  \\/  |   ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||      .=='    _-'    `-_  `='    _-'   `-_    `='  _-'   `-_  /|  \\/  |   ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||   .=='    _-'          `-__\\._-'         `-_./__-'         `' |. /|  |   ||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("||.=='    _-'                                                     `' |  /==.||");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("== '    _-'                                                           \\/   `==");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine("\\   _ -'                                                               `-_   /");
            Console.SetCursorPosition(posX, posY++);
            Console.WriteLine(" `''                                                                     ``'");
        }
    }
}