using ArknightsToolkit.Models;
using ArknightsToolkit.Models.Operators;
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
    class OperatorChildrenToClassImageConverter : IValueConverter
    {
        public static OperatorType OperatorType { get; set; } = OperatorType.Elite0;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorChildren children:
                    List<OperatorClass> temp = (from OperatorInfo info in children.ChildList where info.Type == OperatorType select info.Class).ToList();
                    OperatorType = OperatorType.Elite0;
                    return temp.First().ToClassImage();
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
