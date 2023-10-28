namespace RestaurantService
{
    internal interface ITableRepository
    {
        List<RestaurantTimeSlot> GetAllTimesWithTables();
    }
}