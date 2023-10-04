using ArknightsResources.Operators.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ArknightsToolkit.Helper.Converter
{
    public class OperatorProfileTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorProfileType.BasicInfo:
                    return "基础档案";
                case OperatorProfileType.PhysicalExam:
                    return "综合体检测试";
                case OperatorProfileType.ObjectiveProfile:
                    return "客观履历";
                case OperatorProfileType.ClinicalAnalysis:
                    return "临床诊断分析";
                case OperatorProfileType.ArchiveFile1:
                    return "档案资料一";
                case OperatorProfileType.ArchiveFile2:
                    return "档案资料二";
                case OperatorProfileType.ArchiveFile3:
                    return "档案资料三";
                case OperatorProfileType.ArchiveFile4:
                    return "档案资料四";
                case OperatorProfileType.PromotionFile:
                    return "晋升记录";
                case OperatorProfileType.Promotion1:
                    return "升变档案一";
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
