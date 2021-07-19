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
    class OperatorInformationToOperatorImageConverter : IValueConverter
    {
        public static OperatorType OperatorType { get; set; } = OperatorType.Elite0;
        public static int IndexRequested = -1;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case List<OperatorInfo> Information:
                    List<string> temp = (from OperatorInfo info in Information where info.Type == OperatorType select info.ImageCodename).ToList();
                    if (temp.Count > 1 && IndexRequested is int i && i != -1)
                    {
                        ResetOperatorType();
                        return temp.ElementAt(i).ToOperatorImage();
                    }
                    else
                    {
                        OperatorType = OperatorType.Elite0;
                        return temp.First().ToOperatorImage();
                    }
                default:
                    return DependencyProperty.UnsetValue;
            }
        }

        private static void ResetOperatorType()
        {
            OperatorType = OperatorType.Elite0;
        }

        [Obsolete("不应该调用该方法",true)]
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
