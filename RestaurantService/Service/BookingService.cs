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
        private readonly IOutputService _outputService;
        private readonly List<RestaurantTimeSlot> _restaurantTimeSlotsWithTables;
        private readonly IMessagePromptService _messagePromptService;

        public BookingService(IUserPromptService userPromptService, ITableRepository tableRepository, IOutputService outputService, IMessagePromptService messagePromptService)
        {
            _userPromptService = userPromptService;
            _tableRepository = tableRepository;
            _restaurantTimeSlotsWithTables = _tableRepository.GetAllTimesWithTables();
            _outputService = outputService;
            _messagePromptService = messagePromptService;
        }

        public void CancelBooking()
        {
            // To cancel a booking take input for name and do a search on bookings that meet that criteria before removing booking name
            var bookingName = _userPromptService.PromptUserForInput(_messagePromptService.CancelPromptUserForName);
            var tablesThatMatchCriteria = _restaurantTimeSlotsWithTables.SelectMany(w => w.Tables).Where(w => w.NameBookedUnder.Contains(bookingName, StringComparison.InvariantCultureIgnoreCase));
            var selectedTableToCancel = _userPromptService.GetUserSelectionResponse(
                prompt: _messagePromptService.CancelPromptUserForTable,
                selectionOptions: tablesThatMatchCriteria,
                propertySelector: p => p.NameBookedUnder);
            var confirmation = _userPromptService.PromptUserForYesNo(_messagePromptService.CancelPromptToConfirm(selectedTableToCancel.NameBookedUnder));
            if (confirmation) selectedTableToCancel.NameBookedUnder = string.Empty;
        }

        public void MakeBooking()
        {
            var timeslotsWithAvailableTables = _restaurantTimeSlotsWithTables.Where(w => w.Tables.Any(a => string.IsNullOrWhiteSpace(a.NameBookedUnder))).Select(s => s.Time);

            var timeSelection = _userPromptService.GetUserSelectionResponse(
                prompt: _messagePromptService.BookingPromptForTime,
                selectionOptions: timeslotsWithAvailableTables);

            var availableTables = _restaurantTimeSlotsWithTables.First(f => f.Time == timeSelection).Tables.Where(w => string.IsNullOrEmpty(w.NameBookedUnder));

            var tableSelection = _userPromptService.GetUserSelectionResponse(
                prompt: _messagePromptService.BookingPromptForTable,
                selectionOptions: availableTables,
                propertySelector: s => _messagePromptService.BookingPromptForTableDisplay(s.TableNumber,s.Covers));
 
            var name = _userPromptService.PromptUserForInput(_messagePromptService.BookingPromptForName);

            var confirmation = _userPromptService.PromptUserForYesNo(_messagePromptService.BookingPromptToConfirm(tableSelection.Covers, tableSelection.TableNumber, timeSelection, name));

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
                _outputService.PrintSeperator();
                if (bookedTables.Count > 0)
                {

                    _outputService.WriteText(_messagePromptService.ShowBookingForTimeSlotMessage(time.Time));
                    ShowBookingsForTimeSegment(bookedTables);
                }
                else
                {
                    _outputService.WriteText(_messagePromptService.ShowBookingNoBookingsForTimeSlot(time.Time));
                }
            }
        }

        private static List<Table> GetTablesAvailableForBooking(RestaurantTimeSlot restaurantTimeSlot) => restaurantTimeSlot.Tables.Where(w => !string.IsNullOrWhiteSpace(w.NameBookedUnder)).ToList();
        private void ShowBookingsForTimeSegment(IEnumerable<Table> bookedTables)
        {
            var groupedTables = bookedTables.GroupBy(g => g.Covers);
            foreach (var coverGroup in groupedTables)
            {
                _outputService.WriteText(_messagePromptService.ShowBookingNumberOfCoversMessage(coverGroup.Count(), coverGroup.Key));
                foreach (var cover in coverGroup)
                {
                    _outputService.WriteText(_messagePromptService.ShowBookingBookedTableMessage(cover.NameBookedUnder));
                }
            }
        }
    }
}
