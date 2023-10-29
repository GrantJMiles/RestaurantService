// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.Text.Json.Serialization;

public record UserPrompts(
    [property: JsonPropertyName("restaurantName")] string RestaurantName,
    [property: JsonPropertyName("welcomeMessage")] string WelcomeMessage,
    [property: JsonPropertyName("extendedWelcome")] IReadOnlyList<string> ExtendedWelcome,
    [property: JsonPropertyName("promptRestaurantCommand")] string PromptRestaurantCommand,
    [property: JsonPropertyName("promptUserToContinue")] string PromptUserToContinue,
    [property: JsonPropertyName("goodbyeMessage")] string GoodbyeMessage,
    [property: JsonPropertyName("extendedGoodbye")] IReadOnlyList<string> ExtendedGoodbye,
    [property: JsonPropertyName("cancelPromptUserForName")] string CancelPromptUserForName,
    [property: JsonPropertyName("cancelPromptUserForTable")] string CancelPromptUserForTable,
    [property: JsonPropertyName("cancelPromptToConfirm")] string CancelPromptToConfirm,
    [property: JsonPropertyName("bookingPromptForTime")] string BookingPromptForTime,
    [property: JsonPropertyName("bookingPromptForTable")] string BookingPromptForTable,
    [property: JsonPropertyName("bookingPromptForTableDisplay")] string BookingPromptForTableDisplay,
    [property: JsonPropertyName("bookingPromptForName")] string BookingPromptForName,
    [property: JsonPropertyName("bookingPromptToConfirm")] string BookingPromptToConfirm,
    [property: JsonPropertyName("showBookingForTimeSlotMessage")] string ShowBookingForTimeSlotMessage,
    [property: JsonPropertyName("showBookingNoBookingsForTimeSlot")] string ShowBookingNoBookingsForTimeSlot,
    [property: JsonPropertyName("showBookingNumberOfCoversMessage")] string ShowBookingNumberOfCoversMessage,
    [property: JsonPropertyName("showBookingBookedTableMessage")] string ShowBookingBookedTableMessage
) : IUserPrompts;

