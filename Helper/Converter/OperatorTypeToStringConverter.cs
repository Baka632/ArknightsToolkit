using ArknightsResources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ArknightsToolkit.Helper
{
    public class OperatorTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorType type:
                    switch (type)
                    {
                        case OperatorType.Elite0:
                            return "精零";
                        case OperatorType.Elite1:
                            return "精一";
                        case OperatorType.Elite2:
                            return "精二";
                        case OperatorType.Skin:
                            return "皮肤";
                        case OperatorType.Promotion:
                            return "升变";
                        default:
                            goto default;
                    }
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
