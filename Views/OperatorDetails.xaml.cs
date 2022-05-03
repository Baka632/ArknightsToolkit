using ArknightsResources.Operators.Models;
using ArknightsResources.Operators.Resources;
using ArknightsToolkit.Helper;
using ArknightsToolkit.ViewModels;
using Microsoft.Toolkit.Uwp.UI.Controls;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
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
            ViewModel.CurrentOperator = (Operator)e.Parameter;
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

        //private async void OperatorImage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (sender is ImageEx image)
        //    {
        //        int index = OperatorInformationComboBox.SelectedIndex;
        //        image.Source = await Task.Run(() =>
        //        {
        //            return OperatorInfosGetter.GetImage(ViewModel.CurrentOperator, index);
        //        });
        //    }
        //}
    }
}
