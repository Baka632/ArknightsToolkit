using System;
using ArknightsResources.Operators.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ArknightsToolkit.Helper.Converter
{
    public class IllustToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorIllustrationInfo illustInfo:
                    return illustInfo.ToOperatorImage().Result;
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
