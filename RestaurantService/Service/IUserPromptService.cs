namespace RestaurantService
{
    internal interface IUserPromptService
    {
        string PromptUserForInput(string prompt);
        T GetUserSelectionResponse<T>(string prompt, IEnumerable<T> selectionOptions, Func<T, string> propertySelector) where T : class;
        string GetUserSelectionResponse(string prompt, IEnumerable<string> selectionOptions);
        bool PromptUserForYesNo(string prompt);
    }
}