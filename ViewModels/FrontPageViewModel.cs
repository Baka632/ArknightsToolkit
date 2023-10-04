using System;
using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Views;

namespace ArknightsToolkit.ViewModels
{
    internal class FrontPageViewModel : NotificationObject
    {
        public DelegateCommand NavigateToOperatorsCommand { get; } = new NavigationCommand(typeof(OperatorLists), null);
        public NavigationCommand NavigateToStoryPageCommand { get; } = new NavigationCommand(typeof(StoryPage), null);
        public DelegateCommand OpenSettingsCommand { get; }


        public FrontPageViewModel()
        {
            OpenSettingsCommand = new DelegateCommand(async (obj) =>
            {
                SettingsContentDialog dialog = new SettingsContentDialog();
                await dialog.ShowAsync();
            });
        }
    }
}
