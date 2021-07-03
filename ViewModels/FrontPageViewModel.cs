using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Services;
using ArknightsToolkit.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.ViewModels
{
    internal class FrontPageViewModel : NotificationObject
    {
        public NavigationCommand NavigateToOperatorsCommand { get; set; } = new NavigationCommand(typeof(OperatorLists), null);
        public NavigationCommand NavigateToStoryPageCommand { get; set; } = new NavigationCommand(typeof(StoryPage), null);


        public FrontPageViewModel()
        {

        }
    }
}
