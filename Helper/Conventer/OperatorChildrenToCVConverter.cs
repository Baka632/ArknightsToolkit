using ArknightsToolkit.Models;
using ArknightsToolkit.Models.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ArknightsToolkit.Helper
{
    public class OperatorChildrenToCVConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case OperatorChildren children:
                    List<string> temp = (from OperatorInfo info in children.ChildList select info.CV).ToList();
                    return temp.First();
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
