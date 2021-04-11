using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using ArknightsToolkit.Services;
using Microsoft.Toolkit.Uwp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.ViewModels
{
    class OperatorListsViewModel : NotificationObject
    {

        public BitmapImage BackgroundImage { get; } = Resources.Resource.background_operators.AsBitmapImage();

        public BitmapImage AmiyaBackground { get; } = Resources.Resource.ui_amiya_bg.AsBitmapImage();

        //看以后情况
        public IncrementalLoadingCollection<OperatorsList,Operators> OperatorsList { get; }
        //public List<Operators> OperatorsList { get; private set; }

        public OperatorListsViewModel()
        {
            OperatorsList = new IncrementalLoadingCollection<OperatorsList, Operators>();
        }
    }
}
