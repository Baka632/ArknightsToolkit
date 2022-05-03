using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArknightsResources.Operators;
using ArknightsResources.Operators.Models;
using ArknightsResources.Operators.Resources;
using Microsoft.Toolkit.Uwp.UI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    public class OperatorInfosGetter
    {
        internal static ConcurrentDictionary<string, BitmapImage> dict = new ConcurrentDictionary<string, BitmapImage>(5, 100);

        public static BitmapImage GetImage(Operator op, int index)
        {
            if (dict.TryGetValue(op.Illustrations[index].ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                image = ResourceHelper.GetOperatorImageReturnImage(op.Illustrations[index]).AsBitmapImage();
                dict.TryAdd(op.Illustrations[index].ImageCodename, image);
            }
            return image;
        }

        public static BitmapImage GetImage(string codename)
        {
            Operator op = ResourceHelper.GetOperatorWithCodename(codename, CultureInfo.CurrentUICulture);

            OperatorIllustrationInfo illustInfo = op.Illustrations.First();

            if (dict.TryGetValue(illustInfo.ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                image = ResourceHelper.GetOperatorImageReturnImage(illustInfo).AsBitmapImage();
                dict.TryAdd(illustInfo.ImageCodename, image);
            }

            return image;
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

        public static string GetOperatorTypeString(OperatorType type,string illustrationName)
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
                case OperatorType.Promotion:
                    return "升变";
                default:
                    goto default;
            }
        }

        public static string GetOperatorSkinInfoDescription(Operator op, int index)
        {
            return op.Illustrations[index].Description;
        }
    }
}
