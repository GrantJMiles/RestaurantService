
namespace RestaurantService
{
    internal interface IOutputService
    {
        void PrintSeperator();
        void WriteText(string message, bool writeLine = true);
        void WriteText(string message, ConsoleColor colour, bool writeLine = true);
    }
}