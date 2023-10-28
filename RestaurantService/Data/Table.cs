class Table(int tableNumber, int covers)
{
    public int TableNumber { get; set; } = tableNumber;
    public int Covers { get; private set; } = covers;
    public string NameBookedUnder { get; set; } = string.Empty;
}