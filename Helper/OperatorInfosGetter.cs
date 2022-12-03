using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ArknightsResources.Operators;
using ArknightsResources.Operators.Models;
using ArknightsResources.Operators.Resources;
using ArknightsResources.Utility;
using ArknightsToolkit.Views;
using Microsoft.Toolkit.Uwp.UI;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    public class OperatorInfosGetter
    {
        internal static ConcurrentDictionary<string, BitmapImage> dict = new ConcurrentDictionary<string, BitmapImage>(5, 200);

        public static BitmapImage GetImage(Operator op, int index)
        {
            if (dict.TryGetValue(op.Illustrations[index].ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                image = OperatorResourceHelper.Instance.GetOperatorImage(op.Illustrations[index]).AsBitmapImage();
                dict.TryAdd(op.Illustrations[index].ImageCodename, image);
            }
            return image;
        }

        public static async Task<BitmapImage> GetImageAsync(Operator op, int index)
        {
            if (dict.TryGetValue(op.Illustrations[index].ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                byte[] imgByteArray = await OperatorResourceHelper.Instance.GetOperatorImageAsync(op.Illustrations[index]);
                image = await imgByteArray.AsBitmapImageAsync();
                dict.TryAdd(op.Illustrations[index].ImageCodename, image);
                return image;
            }
        }

        public static BitmapImage GetImage(OperatorIllustrationInfo illustInfo)
        {
            if (dict.TryGetValue(illustInfo.ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                image = OperatorResourceHelper.Instance.GetOperatorImage(illustInfo).AsBitmapImage();
                dict.TryAdd(illustInfo.ImageCodename, image);
                return image;
            }
        }

        public static async Task<BitmapImage> GetImageAsync(OperatorIllustrationInfo illustInfo)
        {
            if (dict.TryGetValue(illustInfo.ImageCodename, out BitmapImage image))
            {
                return image;
            }
            else
            {
                byte[] imgByteArray = await OperatorResourceHelper.Instance.GetOperatorImageAsync(illustInfo);
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
                case OperatorType.Promotion:
                    return "升变";
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
