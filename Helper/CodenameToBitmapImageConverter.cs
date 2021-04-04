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
    class CodenameToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value)
            {
                case string codeName:
                    byte[] array = (byte[])Resources.Resource.ResourceManager.GetObject($"operator_{codeName}");
                    using (var stream = new InMemoryRandomAccessStream())
                    {
                        stream.WriteAsync(array.AsBuffer()).GetResults();
                        stream.Seek(0);
                        BitmapImage bmp = new BitmapImage();
                        bmp.SetSource(stream);
                        return bmp;
                    }
                default:
                    return DependencyProperty.UnsetValue;
            }
        }

        [Obsolete("不应该调用该方法",true)]
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
