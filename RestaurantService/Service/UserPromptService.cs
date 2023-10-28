using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService
{
    internal class UserPromptService : IUserPromptService
    {
        public T GetUserSelectionResponse<T>(string prompt, IEnumerable<T> selectionOptions, Func<T, string> propertySelector) where T : class => AnsiConsole.Prompt(
            prompt: new SelectionPrompt<T>()
                .Title(prompt)
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to select options)[/]")
                .UseConverter(propertySelector)
                .AddChoices(selectionOptions));

        public string GetUserSelectionResponse(string prompt, IEnumerable<string> selectionOptions)
        => GetUserSelectionResponse(prompt, selectionOptions, p => p);

        public string PromptUserForInput(string prompt) => AnsiConsole.Ask<string>(prompt);

        public bool PromptUserForYesNo(string prompt) => AnsiConsole.Confirm(prompt);
    }
}
