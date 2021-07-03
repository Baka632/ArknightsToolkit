using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using ArknightsToolkit.Services;
using ArknightsToolkit.Views;
using Microsoft.Toolkit.Uwp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using OperatorsListClass = ArknightsToolkit.Models.OperatorsList;

namespace ArknightsToolkit.ViewModels
{
    class OperatorListsViewModel : NotificationObject
    {
        public static event Action<OperatorComparerOption> CompareByNameRequested;
        public static event Action<OperatorComparerOption> CompareByStarCountRequested;
        public static event Func<string, Operator> OperatorRequested;

        public DelegateCommand CompareByName { get; set; } = new DelegateCommand((object obj) => CompareByNameRequested?.Invoke((OperatorComparerOption)obj));
        public DelegateCommand CompareByStarCount { get; set; } = new DelegateCommand((object obj) => CompareByStarCountRequested?.Invoke((OperatorComparerOption)obj));
        public DelegateCommand NavigateToOperatorDetailsCommand { get; set; }

        public OperatorType RequestedClass { get; set; } = OperatorType.Elite0;

        public BitmapImage BackgroundImage { get; } = new BitmapImage(new Uri(@"ms-appx:///Assets/UI/ui_operators_background.png", UriKind.Absolute));

        public BitmapImage AmiyaBackground { get; } = new BitmapImage(new Uri(@"ms-appx:///Assets/UI/ui_amiya_bg.png", UriKind.Absolute));

        public IncrementalLoadingCollection<OperatorsList, Operator> OperatorsList { get; }

        public OperatorListsViewModel()
        {
            this.OperatorsList = new IncrementalLoadingCollection<OperatorsList, Operator>();
            _ = this.OperatorsList.RefreshAsync();
            OperatorsListClass.CollectionChanged += OperatorsListChanged;
            NavigateToOperatorDetailsCommand = new DelegateCommand((object obj) =>
            {
                Operator requestedOperator = OperatorRequested?.Invoke(obj as string);
                NavigationHelper.Navigate(typeof(OperatorDetails), requestedOperator, new SuppressNavigationTransitionInfo());
            });
        }

        private async void OperatorsListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            await OperatorsList.RefreshAsync();
        }
    }
}
