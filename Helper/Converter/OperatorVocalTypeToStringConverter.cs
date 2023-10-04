using ArknightsResources.Operators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ArknightsToolkit.Helper.Converter
{
    internal class OperatorVocalTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorVoiceType type:
                    switch (type)
                    {
                        case OperatorVoiceType.ChineseMandarin:
                            return "中文普通话";
                        case OperatorVoiceType.ChineseRegional:
                            return "中文方言";
                        case OperatorVoiceType.Japanese:
                            return "日语";
                        case OperatorVoiceType.English:
                            return "英语";
                        case OperatorVoiceType.Korean:
                            return "韩语";
                        default:
                            return DependencyProperty.UnsetValue;
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
