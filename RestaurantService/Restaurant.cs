using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService
{
    internal class Restaurant(string _name, 
                            IWelcomeService _welcomeService, 
                            IBookingService _bookingService, 
                            IUserPromptService _userPromptService,
                            IOutputService _outputService,
                            IMessagePromptService _messagePromptService)
    {

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
                    prompt: _messagePromptService.PromptRestaurantCommand,
                    selectionOptions: RestaurantCommands,
                    propertySelector: p => p.Name);
                ProcessRestaurantCommand(requestedService);
                if (_keepRunning)
                {
                    var userToContinue = _userPromptService.PromptUserForYesNo(_messagePromptService.PromptUserToContinue);
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
                    _outputService.WriteText(_messagePromptService.GoodbyeMessage(_name));
                    foreach(var line in _messagePromptService.ExtendedGoodbye ?? Enumerable.Empty<string>())
                    {
                        _outputService.WriteText(line);
                    }
                    _keepRunning = false;
                break;
                default:
                    throw new NotImplementedException("You have requested an action that is not yet available. Contact your administrator.");
            }
        }




    }
}
