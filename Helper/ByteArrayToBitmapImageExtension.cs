using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            using (var stream = new InMemoryRandomAccessStream())
            {
                stream.WriteAsync(byteArray.AsBuffer()).GetResults();
                stream.Seek(0);
                BitmapImage bmp = new BitmapImage();
                await bmp.SetSourceAsync(stream);
                return bmp;
            }
        }

        public static BitmapImage AsBitmapImage(this byte[] byteArray)
        {
            using (var stream = new InMemoryRandomAccessStream())
            {
                stream.WriteAsync(byteArray.AsBuffer()).GetResults();
                stream.Seek(0);
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(stream);
                return bmp;
            }
        }
    }
}
