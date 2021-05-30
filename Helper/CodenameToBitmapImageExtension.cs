using ArknightsToolkit.Models;
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
        public static BitmapImage ToOperatorImage(this string value)
        {
            byte[] array = (byte[])Resources.Resource.ResourceManager.GetObject($"operator_{value}");
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
            byte[] imageArray = (byte[])Resources.Resource.ResourceManager.GetObject($"ui_{value.ToString().ToLower()}");
            return imageArray.AsBitmapImage();
        }
    }
}
