using ArknightsToolkit.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ArknightsToolkit.Services
{
    class TitleBarService
    {
        public ApplicationViewTitleBar PresentationTitleBar { get; } = ApplicationView.GetForCurrentView().TitleBar;
        public SystemNavigationManager NavigationManager { get; } = SystemNavigationManager.GetForCurrentView();
        public Frame CurrentFrame { get; }
        public static event Action<BackButtonVisibilityChangedEventArgs> BackButtonVisibilityChangedEvent;

        public TitleBarService(Frame frame)
        {
            #region TitleBarColor
            PresentationTitleBar.ButtonBackgroundColor = Colors.Transparent;
            Color ForegroundColor;
            switch (Application.Current.RequestedTheme)
            {
                case ApplicationTheme.Light:
                    ForegroundColor = Colors.Black;
                    break;
                case ApplicationTheme.Dark:
                    ForegroundColor = Colors.White;
                    break;
                default:
                    ForegroundColor = Colors.White;
                    break;
            }
            PresentationTitleBar.ButtonForegroundColor = ForegroundColor;
            #endregion

            CurrentFrame = frame;
            CurrentFrame.Navigated += CurrentFrame_Navigated;
        }

        private void CurrentFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            NavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibilityToBoolean(CurrentFrame.CanGoBack);
            BackButtonVisibilityChangedEvent?.Invoke(new BackButtonVisibilityChangedEventArgs(NavigationManager.AppViewBackButtonVisibility));

            AppViewBackButtonVisibility AppViewBackButtonVisibilityToBoolean(bool canGoBack)
            {
                if (canGoBack)
                {
                    return AppViewBackButtonVisibility.Visible;
                }
                else
                {
                    return AppViewBackButtonVisibility.Collapsed;
                }
            }
        }
    }

    class BackButtonVisibilityChangedEventArgs : EventArgs
    {
        public AppViewBackButtonVisibility BackButtonVisibility { get; }

        public BackButtonVisibilityChangedEventArgs(AppViewBackButtonVisibility visibility)
        {
            BackButtonVisibility = visibility;
        }
    }
}
