using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Views;

namespace ArknightsToolkit.ViewModels
{
    internal class FrontPageViewModel : NotificationObject
    {
        public DelegateCommand NavigateToOperatorsCommand { get; }
        public NavigationCommand NavigateToStoryPageCommand { get; } = new NavigationCommand(typeof(StoryPage), null);


        public FrontPageViewModel()
        {
            NavigateToOperatorsCommand = new DelegateCommand((obj) => NavigationHelper.Navigate(typeof(OperatorLists), null));
        }
    }
}
