using ArknightsResources.Models;
using ArknightsResources.Models.WindowsRuntime;
using ArknightsResources.Models.WindowsRuntime.Operators;
using ArknightsToolkit.OperatorPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    public static class CodenameToBitmapImageExtension
    {
        public static BitmapImage ToOperatorImage(this string value, OperatorType type, OperatorSkinInfo skinInfo)
        {
            byte[] array = ResourceHelper.GetOperatorImage(value, type, skinInfo);
            using (var stream = new InMemoryRandomAccessStream())
            {
                stream.WriteAsync(array.AsBuffer()).GetResults();
                stream.Seek(0);
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(stream);
                return bmp;
            }
        }

        public static BitmapImage ToClassImage(this OperatorClass value)
        {
            Uri uri = new Uri($"ms-appx:///Assets/UI/ui_{value.ToString().ToLower()}.png");
            return new BitmapImage(uri);
        }
    }
}
