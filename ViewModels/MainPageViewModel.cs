using ArknightsToolkit.Services;
using ArknightsToolkit.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace ArknightsToolkit.ViewModels
{
    class MainPageViewModel : NotificationObject
    {
        public TitleBarService TitleBarService { get; }

        public MainPageViewModel(Frame frame)
        {
            TitleBarService = new TitleBarService(frame);
            NavigationService.CurrentFrame = frame;
            NavigationService.Navigate(typeof(FrontPage), null);
        }
    }
}
