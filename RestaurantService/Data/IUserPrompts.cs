// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

public interface IUserPrompts
{
    string BookingPromptForName { get; init; }
    string BookingPromptForTable { get; init; }
    string BookingPromptForTableDisplay { get; init; }
    string BookingPromptForTime { get; init; }
    string BookingPromptToConfirm { get; init; }
    string CancelPromptToConfirm { get; init; }
    string CancelPromptUserForName { get; init; }
    string CancelPromptUserForTable { get; init; }
    IReadOnlyList<string> ExtendedGoodbye { get; init; }
    IReadOnlyList<string> ExtendedWelcome { get; init; }
    string GoodbyeMessage { get; init; }
    string PromptRestaurantCommand { get; init; }
    string PromptUserToContinue { get; init; }
    string RestaurantName { get; init; }
    string ShowBookingBookedTableMessage { get; init; }
    string ShowBookingForTimeSlotMessage { get; init; }
    string ShowBookingNoBookingsForTimeSlot { get; init; }
    string ShowBookingNumberOfCoversMessage { get; init; }
    string WelcomeMessage { get; init; }

    void Deconstruct(out string RestaurantName, out string WelcomeMessage, out IReadOnlyList<string> ExtendedWelcome, out string PromptRestaurantCommand, out string PromptUserToContinue, out string GoodbyeMessage, out IReadOnlyList<string> ExtendedGoodbye, out string CancelPromptUserForName, out string CancelPromptUserForTable, out string CancelPromptToConfirm, out string BookingPromptForTime, out string BookingPromptForTable, out string BookingPromptForTableDisplay, out string BookingPromptForName, out string BookingPromptToConfirm, out string ShowBookingForTimeSlotMessage, out string ShowBookingNoBookingsForTimeSlot, out string ShowBookingNumberOfCoversMessage, out string ShowBookingBookedTableMessage);
    bool Equals(object? obj);
    bool Equals(UserPrompts? other);
    int GetHashCode();
    string ToString();
}