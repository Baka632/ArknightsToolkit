using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    public static class ByteArrayToBitmapImageExtension
    {
        public static async Task<BitmapImage> AsBitmapImageAsync(this byte[] byteArray)
        {
            BitmapImage bmp = new BitmapImage();
            IRandomAccessStream stream = new MemoryStream(byteArray).AsRandomAccessStream();
            await bmp.SetSourceAsync(stream);
            return bmp;
        }
    }
}
