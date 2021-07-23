using ArknightsToolkit.Helper;
using ArknightsToolkit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
