using RestaurantService;

var restaurantName = args.Length > 0 ? args[0] : "Default Restaurant";
var welcomeService = new WelcomeService(restaurantName);
var userPromptService = new UserPromptService();
var tableRepository = new TableRepositoryInMemory();
var bookingService = new BookingService(
    userPromptService: userPromptService,
    tableRepository: tableRepository);

var restaurant = new Restaurant(
    name: restaurantName,
    welcomeService: welcomeService,
    bookingService: bookingService,
    userPromptService: userPromptService);

restaurant.Start();