using ArknightsToolkit.Helper;
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
        public TitleBarHelper TitleBarHelper { get; }

        public MainPageViewModel(Frame frame)
        {
            TitleBarHelper = new TitleBarHelper(frame);
            NavigationHelper.CurrentFrame = frame;
            NavigationHelper.Navigate(typeof(FrontPage), null);
        }
    }
}
