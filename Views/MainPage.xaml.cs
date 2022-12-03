using ArknightsToolkit.Helper;
using ArknightsToolkit.ViewModels;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

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
        public static CoreDispatcher CoreDispatcher { get; private set; }
        internal static readonly DispatcherQueue DispatcherQueue = DispatcherQueue.GetForCurrentThread();

        public MainPage()
        {
            this.InitializeComponent();
            CoreDispatcher = Dispatcher;
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
