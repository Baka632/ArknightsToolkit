using ArknightsToolkit.Commands;
using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using ArknightsToolkit.Services;
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
using Windows.UI.Xaml.Media.Imaging;
using OperatorsListClass = ArknightsToolkit.Models.OperatorsList;

namespace ArknightsToolkit.ViewModels
{
    class OperatorListsViewModel : NotificationObject
    {
        public static event Action<OperatorComparerOption> CompareByNameRequested;
        public static event Action<OperatorComparerOption> CompareByStarCountRequested;

        public DelegateCommand CompareByName { get; set; } = new DelegateCommand((object obj) => CompareByNameRequested?.Invoke((OperatorComparerOption)obj));
        public DelegateCommand CompareByStarCount { get; set; } = new DelegateCommand((object obj) => CompareByStarCountRequested?.Invoke((OperatorComparerOption)obj));

        public OperatorType RequestedClass { get; set; } = OperatorType.Elite0;

        public BitmapImage BackgroundImage { get; } = Resources.Resource.background_operators.AsBitmapImage();

        public BitmapImage AmiyaBackground { get; } = Resources.Resource.ui_amiya_bg.AsBitmapImage();

        public IncrementalLoadingCollection<OperatorsList, Operator> OperatorsList { get; }

        public OperatorListsViewModel()
        {
            this.OperatorsList = new IncrementalLoadingCollection<OperatorsList, Operator>();
            this.OperatorsList.RefreshAsync();
            OperatorsListClass.CollectionChanged += OperatorsListChanged;
        }

        private async void OperatorsListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            await OperatorsList.RefreshAsync();
        }
    }
}
