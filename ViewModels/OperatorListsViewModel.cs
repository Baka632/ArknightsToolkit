using ArknightsToolkit.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
