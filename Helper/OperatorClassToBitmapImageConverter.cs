using ArknightsToolkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    class OperatorClassToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorClass operatorsClass:
                    byte[] imageArray = (byte[])Resources.Resource.ResourceManager.GetObject($"ui_{operatorsClass.ToString().ToLower()}");
                    return imageArray.AsBitmapImage();
                default:
                    return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
