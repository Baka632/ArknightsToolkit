using ArknightsToolkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ArknightsToolkit.Helper
{
    public class OperatorProfileTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorProfileType.BasicProfile:
                    return "基础档案";
                case OperatorProfileType.ObjectiveProfile:
                    return "客观履历";
                case OperatorProfileType.ClinicalAnalysis:
                    return "临床诊断分析";
                case OperatorProfileType.FIle1:
                    return "档案资料一";
                case OperatorProfileType.File2:
                    return "档案资料二";
                case OperatorProfileType.File3:
                    return "档案资料三";
                case OperatorProfileType.File4:
                    return "档案资料四";
                case OperatorProfileType.PromotionRecord:
                    return "晋升记录";
                case OperatorProfileType.Promotion1:
                    return "升变档案一";
                case OperatorProfileType.Promotion2:
                    return "升变档案二";
                case OperatorProfileType.Promotion3:
                    return "升变档案三";
                case OperatorProfileType.Promotion4:
                    return "升变档案四";
                case OperatorProfileType.Unknown:
                    return "？？？";
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
