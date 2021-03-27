using ArknightsToolkit.Commands;
using ArknightsToolkit.Services;
using ArknightsToolkit.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace ArknightsToolkit.ViewModels
{
    class FrontPageViewModel : NotificationObject
    {
        public DelegateCommand NavigateToOperatorsCommand { get; set; } = new DelegateCommand();
        public DelegateCommand NavigateToStoryPageCommand { get; set; } = new DelegateCommand();

        public FrontPageViewModel()
        {
            NavigateToOperatorsCommand.ExecuteAction = NavigateToOperatorsList;
            NavigateToStoryPageCommand.ExecuteAction = NavigateToStoryPage;
        }

        private void NavigateToStoryPage(object obj)
        {
            NavigationService.Navigate(typeof(StoryPage), null);
        }

        private void NavigateToOperatorsList(object obj)
        {
            NavigationService.Navigate(typeof(OperatorLists),null);
        }
    }
}
