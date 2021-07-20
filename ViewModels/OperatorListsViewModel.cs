using ArknightsResources.Helpers;
using ArknightsResources.Models;
using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using ArknightsToolkit.Services;
using ArknightsToolkit.Views;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.ViewModels
{
    class OperatorListsViewModel : NotificationObject
    {
        public DelegateCommand CompareByName { get; }
        public DelegateCommand CompareByStarCount { get; }
        public DelegateCommand NavigateToOperatorDetailsCommand { get; set; }

        public BitmapImage BackgroundImage { get; } = new BitmapImage(new Uri(@"ms-appx:///Assets/UI/ui_operators_background.png", UriKind.Absolute));

        public BitmapImage AmiyaBackground { get; } = new BitmapImage(new Uri(@"ms-appx:///Assets/UI/ui_amiya_bg.png", UriKind.Absolute));

        public AdvancedCollectionView OperatorsList { get; }

        public OperatorListsViewModel()
        {
            ObservableCollection<Operator> oc = new ObservableCollection<Operator>(ResourceHelper.GetAllOperators().OperatorList);
            OperatorsList = new AdvancedCollectionView(oc, true);
            OperatorsList.SortDescriptions.Add(new SortDescription("Name", SortDirection.Ascending));
            OperatorsList.RefreshSorting();
            OperatorsList.SortDescriptions.Clear();

            CompareByName = new DelegateCommand((object obj) =>
            {
                OperatorsList.SortDescriptions.Clear();
                SortDescription sortDescription = null;
                OperatorComparerOption option = (OperatorComparerOption)obj;
                switch (option)
                {
                    case OperatorComparerOption.Normal:
                        sortDescription = new SortDescription("Name", SortDirection.Ascending);
                        break;
                    case OperatorComparerOption.Reverse:
                        sortDescription = new SortDescription("Name", SortDirection.Descending);
                        break;
                    default:
                        break;
                }
                OperatorsList.SortDescriptions.Add(sortDescription);
                OperatorsList.RefreshSorting();
            });
            CompareByStarCount = new DelegateCommand((object obj) =>
            {
                OperatorsList.SortDescriptions.Clear();
                SortDescription sortDescription = null;
                OperatorComparerOption option = (OperatorComparerOption)obj;
                switch (option)
                {
                    case OperatorComparerOption.Normal:
                        sortDescription = new SortDescription("Star", SortDirection.Ascending);
                        break;
                    case OperatorComparerOption.Reverse:
                        sortDescription = new SortDescription("Star", SortDirection.Descending);
                        break;
                    default:
                        break;
                }
                OperatorsList.SortDescriptions.Add(sortDescription);
                OperatorsList.RefreshSorting();
            });
               

            NavigateToOperatorDetailsCommand = new DelegateCommand((object obj) =>
            {
                NavigationHelper.Navigate(typeof(OperatorDetails), obj, new SuppressNavigationTransitionInfo());
            });
        }
    }
}
