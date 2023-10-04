using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using ArknightsResources.Operators.Models;
using ArknightsResources.Utility;
using ArknightsToolkit.Services;
using Windows.UI.Xaml.Media.Imaging;
using OperatorIllustResources = ArknightsResources.Operators.IllustResources.Properties.Resources;

namespace ArknightsToolkit.Helper
{
    public class OperatorInfosGetter
    {
        internal static ConcurrentDictionary<string, BitmapImage> dict = new ConcurrentDictionary<string, BitmapImage>(5, 200);
        private static readonly OperatorIllustResourceHelper operatorResourceHelper = new OperatorIllustResourceHelper(OperatorIllustResources.ResourceManager);

        public static async Task<BitmapImage> GetImageAsync(Operator op, int index)
        {
            OperatorIllustrationInfo illustInfo = op.Illustrations[index];

            if (Settings.IsImageGenerated)
            {
                BitmapImage bmp = new BitmapImage
                {
                    UriSource = new Uri($@"{OperatorResourceService.SaveFolder.Path}\{illustInfo.ImageCodename}.png")
                };
                return bmp;
            }

            if (dict.TryGetValue(illustInfo.ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                byte[] imgByteArray = await operatorResourceHelper.GetOperatorIllustrationAsync(op.Illustrations[index]);
                image = await imgByteArray.AsBitmapImageAsync();
                dict.TryAdd(op.Illustrations[index].ImageCodename, image);
                return image;
            }
        }

        public static BitmapImage GetImage(OperatorIllustrationInfo illustInfo)
        {
            if (Settings.IsImageGenerated)
            {
                BitmapImage bmp = new BitmapImage
                {
                    UriSource = new Uri($@"{OperatorResourceService.SaveFolder.Path}\{illustInfo.ImageCodename}.png")
                };
                return bmp;
            }

            if (dict.TryGetValue(illustInfo.ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                image = operatorResourceHelper.GetOperatorIllustration(illustInfo).AsBitmapImage();
                dict.TryAdd(illustInfo.ImageCodename, image);
                return image;
            }
        }

        public static async Task<BitmapImage> GetImageAsync(OperatorIllustrationInfo illustInfo)
        {
            if (Settings.IsImageGenerated)
            {
                BitmapImage bmp = new BitmapImage
                {
                    UriSource = new Uri($@"{OperatorResourceService.SaveFolder.Path}\{illustInfo.ImageCodename}.png")
                };
                return bmp;
            }

            if (dict.TryGetValue(illustInfo.ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                byte[] imgByteArray = await operatorResourceHelper.GetOperatorIllustrationAsync(illustInfo);
                image = await imgByteArray.AsBitmapImageAsync();
                dict.TryAdd(illustInfo.ImageCodename, image);
                return image;
            }
        }

        public static BitmapImage GetClassImage(Operator op)
        {
            return op.Class.ToClassImage();
        }

        public static BitmapImage GetClassImage(OperatorClass opClass)
        {
            return opClass.ToClassImage();
        }

        public static string GetIllustrator(Operator op, int index)
        {
            return op.Illustrations[index].Illustrator;
        }

        public static string GetOperatorTypeString(OperatorType type, string illustrationName)
        {
            switch (type)
            {
                case OperatorType.Elite0:
                    return "精零";
                case OperatorType.Elite1:
                    return "精一";
                case OperatorType.Elite2:
                    return "精二";
                case OperatorType.Skin:
                    return illustrationName;
                default:
#if DEBUG
                    Debugger.Break();
#endif
                    return string.Empty;
            }
        }

        public static string GetOperatorSkinInfoDescription(Operator op, int index)
        {
            return op.Illustrations[index].Description;
        }
    }
}
