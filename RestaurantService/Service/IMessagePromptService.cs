
namespace RestaurantService
{
    internal interface IMessagePromptService
    {
        string BookingPromptForName { get; }
        string BookingPromptForTable { get; }
        string BookingPromptForTime { get; }
        string CancelPromptUserForName { get; }
        string CancelPromptUserForTable { get; }
        IReadOnlyList<string> ExtendedGoodbye { get; }
        IReadOnlyList<string> ExtendedWelcome { get; }
        string PromptRestaurantCommand { get; }
        string PromptUserToContinue { get; }
        string RestaurantName { get; }
        string WelcomeMessage(string restaurantName);
        string GoodbyeMessage(string restaurantName);

        string BookingPromptForTableDisplay(int tableNumber, int covers);
        string BookingPromptToConfirm(int covers, int tableNumber, string time, string name);
        string CancelPromptToConfirm(string nameBookedUnder);
        string ShowBookingBookedTableMessage(string name);
        string ShowBookingForTimeSlotMessage(string name);
        string ShowBookingNoBookingsForTimeSlot(string time);
        string ShowBookingNumberOfCoversMessage(int coverCount, int coverSize);
    }
}