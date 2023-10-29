using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantService
{
    internal class WelcomeService(string restaurantName, IOutputService _outputService, IMessagePromptService _messagePromptService) : IWelcomeService
    {
        private bool _firstRun = true;
  

        public void ShowWelcomeMessage(bool showAll = false)
        {
            _outputService.PrintSeperator();
            _outputService.WriteText(_messagePromptService.WelcomeMessage(restaurantName));
            if (_firstRun || showAll)
            {
                _firstRun = false;
                foreach (var line in _messagePromptService.ExtendedWelcome ?? Enumerable.Empty<string>())
                {
                    _outputService.WriteText(line);
                }
            }
        }
    }
}
