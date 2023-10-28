using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService
{
    internal class WelcomeService(string restaurantName) : IWelcomeService
    {
        private bool _firstRun = true;
  

        public void ShowWelcomeMessage(bool showAll = false)
        {
            OutputService.PrintSeperator();
            OutputService.WriteText($"Hello and Welcome to ", false);
            OutputService.WriteText(restaurantName, ConsoleColor.Blue);
            if (_firstRun || showAll)
            {
                _firstRun = false;
                OutputService.WriteText("Using this service you can Book, See all current bookings and cancel existing bookings");
                OutputService.WriteText("At any time if you feel stuck type help to see a list of available commands");
                OutputService.WriteText("If you start a command and want to return, type exit and you will return to the main menu", ConsoleColor.Yellow);
            }
        }
    }
}
