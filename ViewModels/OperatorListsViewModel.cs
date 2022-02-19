using ArknightsResources.Operators;
using ArknightsResources.Operators.Models;
using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Views;
using Microsoft.Toolkit.Uwp.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        public AdvancedCollectionView OperatorsList { get; private set; }

        public OperatorListsViewModel()
        {
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
                        sortDescription = new SortDescription("Star", SortDirection.Descending);
                        break;
                    case OperatorComparerOption.Reverse:
                        sortDescription = new SortDescription("Star", SortDirection.Ascending);
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

        internal async Task InitCollection()
        {
            if (OperatorsList is null)
            {
                ObservableCollection<Operator> oc = await Task.Run(async () =>
                {
                    Operator[] operatorsList = await ResourceHelper.GetAllOperatorsAsync();
                    return new ObservableCollection<Operator>(operatorsList);
                });
                OperatorsList = new AdvancedCollectionView(oc, true);
                OperatorsList.SortDescriptions.Add(new SortDescription("Name", SortDirection.Ascending));
                OperatorsList.RefreshSorting();
                OperatorsList.SortDescriptions.Clear();
                OnPropertiesChanged(nameof(OperatorsList));
            }
        }

        internal void RefreshCollection()
        {
            OperatorsList.Refresh();
        }
    }
}
