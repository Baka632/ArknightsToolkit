using ArknightsResources.Operators.Models;
using ArknightsToolkit.Helper;
using ArknightsToolkit.ViewModels;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
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
    public sealed partial class OperatorLists : Page
    {
        private OperatorListsViewModel ViewModel { get; set; }

        private Operator _storeditem = null;

        public OperatorLists()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            ViewModel = new OperatorListsViewModel();
        }

        private void TextBlock_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            InAmiyaBackgroundStoryboard.Begin();
        }

        private void TextBlock_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            OutAmiyaBackgroundStoryboard.Begin();
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (OperatorListGridView.ContainerFromItem(e.ClickedItem) is GridViewItem container)
            {
                _storeditem = (Operator)container.Content;
            }
            ViewModel.NavigateToOperatorDetailsCommand.Execute((Operator)e.ClickedItem);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (_storeditem != null && e.NavigationMode != NavigationMode.Back)
            {
                _ = OperatorListGridView.PrepareConnectedAnimation("ForwardConnectedAnimation", _storeditem, "OperatorImage");
            }
        }

        private async void OperatorListGridView_Loaded(object sender, RoutedEventArgs e)
        {
            if (_storeditem != null)
            {
                // If the connected item appears outside the viewport, scroll it into view.
                OperatorListGridView.ScrollIntoView(_storeditem, ScrollIntoViewAlignment.Default);
                OperatorListGridView.UpdateLayout();

                // Play the second connected animation. 
                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
                if (animation != null)
                {
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                    {
                        animation.Configuration = new DirectConnectedAnimationConfiguration();
                    }

                    _ = await OperatorListGridView.TryStartConnectedAnimationAsync(animation, _storeditem, "OperatorImage");
                }
            }
            await ViewModel.InitCollection();
        }

        private async void OperatorImage_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is ImageEx image && image.Source is null && image.DataContext is Operator op)
            {
                image.Source = await OperatorInfosGetter.GetImageAsync(op.Illustrations[0]);
            }
        }
    }
}
