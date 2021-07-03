using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using ArknightsToolkit.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace ArknightsToolkit.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class OperatorDetails : Page
    {
        public OperatorDetailsViewModel ViewModel { get; }
        
        public OperatorDetails()
        {
            this.InitializeComponent();
            ViewModel = new OperatorDetailsViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.CurrentOperator = e.Parameter as Operator;
            ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
            if (imageAnimation != null)
            {
                _ = imageAnimation.TryStart(OperatorImage, new UIElement[] { operatorImageScrollViewer });
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            _ = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("BackConnectedAnimation", OperatorImage);
            base.OnNavigatingFrom(e);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OperatorInfo infoToGetIndex = (OperatorInfo)e.AddedItems.First();
            List<OperatorInfo> SkinList = (from OperatorInfo info in (sender as ComboBox).Items where info.Type == OperatorType.Skin select info).ToList();
            OperatorChildrenToOperatorImageConverter.IndexRequested = SkinList.IndexOf(infoToGetIndex);
            ViewModel.ChangeOperatorTypeCommandByOperatorInfoCommmand.Execute(e.AddedItems.First());
        }
    }
}
