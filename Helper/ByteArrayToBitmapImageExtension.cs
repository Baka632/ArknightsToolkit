using ArknightsToolkit.Views;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.Helpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Xaml;
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
                stream.Seek(0);
                stream.WriteAsync(byteArray.AsBuffer()).GetResults();
                stream.Seek(0);

                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(stream);
                return bmp;
            }
        }

        public static BitmapImage AsBitmapImage(this Image<Bgra32> image)
        {
            using (var stream = new InMemoryRandomAccessStream())
            {
                using (image)
                {
                    image.SaveAsPng(stream.AsStreamForWrite());
                    stream.Seek(0);
                    BitmapImage bmp = new BitmapImage();
                    bmp.SetSource(stream);
                    return bmp;
                }
            }
        }

        public static async Task<BitmapImage> AsBitmapImageAsync(this Image<Bgra32> image)
        {
            using (var stream = new InMemoryRandomAccessStream())
            {
                using (image)
                {
                    image.SaveAsPng(stream.AsStreamForWrite());
                    stream.Seek(0);
                    BitmapImage img = await MainPage.DispatcherQueue.EnqueueAsync(async () =>
                   {
                       BitmapImage bmp = new BitmapImage();
                       await bmp.SetSourceAsync(stream);
                       return bmp;
                   });
                    return img;
                }
            }
        }
    }
}
