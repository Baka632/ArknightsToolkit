using ArknightsToolkit.Helper;
using ArknightsToolkit.Models;
using ArknightsToolkit.Services;
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
        private BitmapImage backgroundImage;

        public BitmapImage BackgroundImage
        {
            get => backgroundImage;
            set
            {
                backgroundImage = value;
                OnPropertiesChanged();
            }
        }

        public List<Operators> OperatorsList { get; } = XmlService.XmlDeserialize<OperatorsList>(Resources.Resource.Operators, Encoding.UTF8).OperatorList;

        public OperatorListsViewModel()
        {
            SetBackgroundImage();

            async void SetBackgroundImage()
            {
                BackgroundImage = await Resources.Resource.background_operators.AsBitmapImageAsync();
            }
        }
    }
}
