using RestaurantService;
using RestaurantService.Service;
using System.Text.Json;

var restaurantName = args.Length > 0 ? args[0] : "Default Restaurant";
JsonSerializerOptions _options = new()
{
    IncludeFields = true
};
var json = File.ReadAllText("./UserPrompts.spectre.json");
var userPrompts = JsonSerializer.Deserialize<UserPrompts>(json) ?? throw new InvalidOperationException("Unable to parse JSON file for user prompts");
var messagePromptService = new MessagePromptService(userPrompts);
var outputService = new SpectreOutputService();
var welcomeService = new WelcomeService(restaurantName, outputService, messagePromptService);
var userPromptService = new UserPromptService();
var tableRepository = new TableRepositoryInMemory();
var bookingService = new BookingService(
    userPromptService: userPromptService,
    tableRepository: tableRepository,
    outputService: outputService,
    messagePromptService: messagePromptService);

var restaurant = new Restaurant(
    _name: restaurantName,
    _welcomeService: welcomeService,
    _bookingService: bookingService,
    _userPromptService: userPromptService,
    _outputService: outputService,
    _messagePromptService: messagePromptService);

restaurant.Start();