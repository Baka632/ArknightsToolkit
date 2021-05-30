using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using ArknightsToolkit.Services;
using ArknightsToolkit.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Serialization;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ArknightsToolkit.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel ViewModel { get; }
        private bool IsTitleBarTextBlockInBegun = false;

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainPageViewModel(ContentFrame);
            TitleBarHelper.BackButtonVisibilityChangedEvent += TitleBarHelper_BackButtonVisibilityChangedEvent;
        }

        private void TitleBarHelper_BackButtonVisibilityChangedEvent(BackButtonVisibilityChangedEventArgs args)
        {
            StartTitleBarAnimation(args.BackButtonVisibility);
        }

        private void StartTitleBarAnimation(AppViewBackButtonVisibility buttonVisibility)
        {
            switch (buttonVisibility)
            {
                case AppViewBackButtonVisibility.Disabled:
                case AppViewBackButtonVisibility.Visible:
                    if (IsTitleBarTextBlockInBegun)
                    {
                        goto default;
                    }
                    TitleBarTextBlockIn.Begin();
                    IsTitleBarTextBlockInBegun = true;
                    break;
                case AppViewBackButtonVisibility.Collapsed:
                    TitleBarTextBlockOut.Begin();
                    IsTitleBarTextBlockInBegun = false;
                    break;
                default:
                    break;
            }
        }
    }
}
