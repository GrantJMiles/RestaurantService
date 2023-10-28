using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService
{
    internal class BookingService : IBookingService
    {
        private readonly IUserPromptService _userPromptService;
        private readonly ITableRepository _tableRepository;
        private readonly List<RestaurantTimeSlot> _restaurantTimeSlotsWithTables;

        public BookingService(IUserPromptService userPromptService, ITableRepository tableRepository)
        {
            _userPromptService = userPromptService;
            _tableRepository = tableRepository;
            _restaurantTimeSlotsWithTables = _tableRepository.GetAllTimesWithTables();
        }

        public void CancelBooking()
        {
            // To cancel a booking take input for name and do a search on bookings that meet that criteria before removing booking name
            var bookingName = _userPromptService.PromptUserForInput("What name is the booking under?");
            var tablesThatMatchCriteria = _restaurantTimeSlotsWithTables.SelectMany(w => w.Tables).Where(w => w.NameBookedUnder.ToLowerInvariant().Contains(bookingName.ToLowerInvariant()));
            var selectedTableToCancel = _userPromptService.GetUserSelectionResponse(
                prompt: "Which table do you want to cancel?",
                selectionOptions: tablesThatMatchCriteria,
                propertySelector: p => p.NameBookedUnder);
            var confirmation = _userPromptService.PromptUserForYesNo($"Are you sure you want to [red]cancel[/] a booking for [red]{selectedTableToCancel.NameBookedUnder}[/]");
            if (confirmation) selectedTableToCancel.NameBookedUnder = string.Empty;
        }

        public void MakeBooking()
        {
            var timeslotsWithAvailableTables = _restaurantTimeSlotsWithTables.Where(w => w.Tables.Any(a => string.IsNullOrWhiteSpace(a.NameBookedUnder))).Select(s => s.Time);

            var timeSelection = _userPromptService.GetUserSelectionResponse(
                prompt: "When are you looking to book?",
                selectionOptions: timeslotsWithAvailableTables);

            var availableTables = _restaurantTimeSlotsWithTables.First(f => f.Time == timeSelection).Tables.Where(w => string.IsNullOrEmpty(w.NameBookedUnder));

            var tableSelection = _userPromptService.GetUserSelectionResponse(
                prompt: "Which table would you prefer",
                selectionOptions: availableTables,
                propertySelector: s => $"Table Number {s.TableNumber}, suitable for a {s.Covers} or less");
 
            var name = _userPromptService.PromptUserForInput("What's your [green]name[/]?");

            var confirmation = _userPromptService.PromptUserForYesNo($"You have a booking for [yellow]{tableSelection.Covers}[/] on table number [yellow]{tableSelection.TableNumber}[/] at [yellow]{timeSelection}[/] under the name of [yellow]{name}[/].\nDo you want to continue?");

            if (confirmation)
            {
                tableSelection.NameBookedUnder = name;
                ShowBookings();
            }
        }

        public void ShowBookings()
        {
            foreach (var time in _restaurantTimeSlotsWithTables ?? Enumerable.Empty<RestaurantTimeSlot>())
            {
                var bookedTables = GetTablesAvailableForBooking(time);
                OutputService.PrintSeperator();
                if (bookedTables.Count > 0)
                {

                    OutputService.WriteText($"There are the following bookings at {time.Time}", ConsoleColor.Yellow);
                    ShowBookingsForTimeSegment(bookedTables);
                }
                else
                {
                    OutputService.WriteText($"There are no bookings at {time.Time}", ConsoleColor.Yellow);
                }
            }
        }

        private static List<Table> GetTablesAvailableForBooking(RestaurantTimeSlot restaurantTimeSlot) => restaurantTimeSlot.Tables.Where(w => !string.IsNullOrWhiteSpace(w.NameBookedUnder)).ToList();
        private static void ShowBookingsForTimeSegment(IEnumerable<Table> bookedTables)
        {
            var groupedTables = bookedTables.GroupBy(g => g.Covers);
            foreach (var coverGroup in groupedTables)
            {
                OutputService.WriteText($"There are {coverGroup.Count()} x {coverGroup.Key} covers");
                foreach (var cover in coverGroup)
                {
                    OutputService.WriteText($"Table is booked under the name {cover.NameBookedUnder}");
                }
            }
        }
    }
}
