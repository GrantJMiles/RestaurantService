using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService
{
    internal static class OutputService
    {
        public static void WriteText(string message, ConsoleColor colour, bool writeLine = true)
        {
            Console.ForegroundColor = colour;
            WriteText(message, writeLine);
            Console.ResetColor();
        }
        public static void WriteText(string message, bool writeLine = true)
        {
            if (writeLine) Console.WriteLine(message);
            else Console.Write(message);
        }
        public static void PrintSeperator()
        {
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
