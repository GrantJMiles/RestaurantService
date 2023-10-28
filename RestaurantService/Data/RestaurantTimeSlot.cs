using System.Collections.Immutable;

class RestaurantTimeSlot(string time, ImmutableList<Table> tables)
{
    public string Time { get; set; } = time;
    public ImmutableList<Table> Tables { get; set; } = tables;
}