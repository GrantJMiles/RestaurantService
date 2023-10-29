using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService.Service
{
    internal class SpectreOutputService : IOutputService
    {
        public void PrintSeperator()
        {
            AnsiConsole.WriteLine("---------------------------------------------------");
        }

        public void WriteText(string message, ConsoleColor colour, bool writeLine = true)
        {
            WriteText(message, writeLine);
        }
        public void WriteText(string message, bool writeLine = true)
        {
            if (writeLine) AnsiConsole.Write(new Markup($"{message}\n"));
            else AnsiConsole.Write(message);
        }
    }
}
