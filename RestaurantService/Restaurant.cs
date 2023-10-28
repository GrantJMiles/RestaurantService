using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService
{
    internal class Restaurant(string name, 
                            IWelcomeService welcomeService, 
                            IBookingService bookingService, 
                            IUserPromptService userPromptService)
    {
        private readonly string _name = name;
        private readonly IWelcomeService _welcomeService = welcomeService;
        private readonly IBookingService _bookingService =  bookingService;
        private readonly IUserPromptService _userPromptService = userPromptService;

        private static readonly IEnumerable<RestaurantCommand> RestaurantCommands = [
            new RestaurantCommand(1, "Make a booking"),
            new RestaurantCommand(2, "Show All Bookings"),
            new RestaurantCommand(3, "Cancel Booking"),
            new RestaurantCommand(4, "Exit")
        ];

        private bool _keepRunning = true;
        private int _commandCount = 0;
        
        public void Start()
        {
            while (_keepRunning)
            {
                Console.Clear();
                _welcomeService.ShowWelcomeMessage();
                var requestedService = _userPromptService.GetUserSelectionResponse(
                    prompt: "What would you like to do?",
                    selectionOptions: RestaurantCommands,
                    propertySelector: p => p.Name);
                ProcessRestaurantCommand(requestedService);
                if (_keepRunning)
                {
                    var userToContinue = _userPromptService.PromptUserForYesNo("Would you like to perform another action?");
                    if (!userToContinue) _keepRunning = false;
                }
            }
        }

        private void ProcessRestaurantCommand(RestaurantCommand restaurantCommand)
        {
            switch (restaurantCommand.Id)
            {
                case 1:
                    _bookingService.MakeBooking();
                    break;
                case 2:
                    _bookingService.ShowBookings();
                    break;
                case 3:
                    _bookingService.CancelBooking();
                break;
                case 4:
                    OutputService.WriteText("Thank you for using ", false);
                    OutputService.WriteText(_name, ConsoleColor.Blue, false);
                    OutputService.WriteText(". Please leave a review");
                    _keepRunning = false;
                break;
                default:
                    throw new NotImplementedException("You have requested an action that is not yet available. Contact your administrator.");
            }
        }




    }
}
