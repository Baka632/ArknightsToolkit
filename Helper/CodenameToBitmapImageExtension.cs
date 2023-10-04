using ArknightsResources.Operators.Models;
using ArknightsResources.Utility;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using OperatorResources = ArknightsResources.Operators.IllustResources.Properties.Resources;

namespace ArknightsToolkit.Helper
{
    public static class CodenameToBitmapImageExtension
    {
        private static readonly OperatorIllustResourceHelper operatorResourceHelper = new OperatorIllustResourceHelper(OperatorResources.ResourceManager);

        public static async Task<BitmapImage> ToOperatorImage(this OperatorIllustrationInfo value)
        {
            byte[] array = operatorResourceHelper.GetOperatorIllustration(value);
            using (var stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(array.AsBuffer());
                stream.Seek(0);
                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(stream);
                return bmp;
            }
        }

        public static BitmapImage ToClassImage(this OperatorClass value)
        {
            Uri uri = new Uri($"ms-appx:///Assets/UI/ui_{value.MainClass.ToString().ToLower()}.png");
            return new BitmapImage(uri);
        }
    }
}
