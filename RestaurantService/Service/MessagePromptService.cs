using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantService.Service
{
    internal class MessagePromptService(
        IUserPrompts _userPrompts
    ) : IMessagePromptService
    {
        public string RestaurantName => _userPrompts.RestaurantName;
        public string WelcomeMessage(string restaurantName) => string.Format(_userPrompts.WelcomeMessage, restaurantName);
        public IReadOnlyList<string> ExtendedWelcome => _userPrompts.ExtendedWelcome;
        public string PromptRestaurantCommand => _userPrompts.PromptRestaurantCommand;
        public string PromptUserToContinue => _userPrompts.PromptUserToContinue;
        public string GoodbyeMessage(string restaurantName) => string.Format(_userPrompts.GoodbyeMessage, restaurantName);
        public IReadOnlyList<string> ExtendedGoodbye => _userPrompts.ExtendedGoodbye;
        public string CancelPromptUserForName => _userPrompts.CancelPromptUserForName;
        public string CancelPromptUserForTable => _userPrompts.CancelPromptUserForTable;
        public string CancelPromptToConfirm(string nameBookedUnder) => string.Format(_userPrompts.CancelPromptToConfirm, nameBookedUnder);
        public string BookingPromptForTime => _userPrompts.BookingPromptForTime;
        public string BookingPromptForTable => _userPrompts.BookingPromptForTable;
        public string BookingPromptForTableDisplay(int tableNumber, int covers) => string.Format(_userPrompts.BookingPromptForTableDisplay, tableNumber, covers);
        public string BookingPromptForName => _userPrompts.BookingPromptForName;
        public string BookingPromptToConfirm(int covers, int tableNumber, string time, string name) => string.Format(_userPrompts.BookingPromptToConfirm, covers, tableNumber, time, name);
        public string ShowBookingForTimeSlotMessage(string name) => string.Format(_userPrompts.ShowBookingForTimeSlotMessage, name);
        public string ShowBookingNoBookingsForTimeSlot(string time) => string.Format(_userPrompts.ShowBookingNoBookingsForTimeSlot, time);
        public string ShowBookingNumberOfCoversMessage(int coverCount, int coverSize) => string.Format(_userPrompts.ShowBookingNumberOfCoversMessage, coverCount, coverSize);
        public string ShowBookingBookedTableMessage(string name) => string.Format(_userPrompts.ShowBookingBookedTableMessage, name);
    }
}

