namespace RestaurantService
{
    internal interface IBookingService
    {
        void MakeBooking();
        void CancelBooking();
        void ShowBookings();
    }
}