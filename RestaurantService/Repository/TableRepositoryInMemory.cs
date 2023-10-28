using System.Collections.Immutable;

namespace RestaurantService
{
    internal class TableRepositoryInMemory : ITableRepository
    {
        public List<RestaurantTimeSlot> GetAllTimesWithTables() => new()
        {
            new ("11:00", GetTables()),new ("12:00", GetTables()),new ("13:00", GetTables()),new ("14:00", GetTables())
        };

        static ImmutableList<Table> GetTables() => ImmutableList.Create<Table>(
            new(1, 2), new(2, 2), new(3, 4), new(4, 4), new(5, 8)
        );
    }
}