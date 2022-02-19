using ArknightsToolkit.Helper;
using System;
using Windows.UI.Xaml.Media.Animation;

namespace ArknightsToolkit.Commands
{
    internal sealed class NavigationCommand : DelegateCommand
    {
        internal NavigationCommand(Type page, object parameter, NavigationTransitionInfo transitionInfo = null)
        {
            ExecuteAction = (object obj) =>
            {
                NavigationHelper.Navigate(page, parameter, transitionInfo);
            };
        }
    }
}
