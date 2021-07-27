using System.Collections.Generic;
using ArknightsResources.Models;
using ArknightsResources.Models.WindowsRuntime;
using ArknightsResources.Models.WindowsRuntime.Operators;
using ArknightsToolkit.OperatorPack;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    public class OperatorInfosGetter
    {
        public static BitmapImage GetImage(Operator op, int index)
        {
            byte[] image = ResourceHelper.GetOperatorImage(op.ImageCodename, op.Information[index].Type, op.Information[index].SkinInfo);
            return image.AsBitmapImage();
        }

        public static BitmapImage GetImage(string codename)
        {
            byte[] image = ResourceHelper.GetOperatorImage(codename, OperatorType.Elite0, null);
            return image.AsBitmapImage();
        }

        public static BitmapImage GetClassImage(Operator op, int index)
        {
            OperatorInfo info = op.Information[index];
            return info.Class.ToClassImage();
        }

        public static BitmapImage GetClassImage(OperatorInfo info)
        {
            return info.Class.ToClassImage();
        }

        public static string GetCV(Operator op, int index)
        {
            OperatorInfo info = op.Information[index];
            return info.CV;
        }

        public static string GetIllustrator(Operator op, int index)
        {
            OperatorInfo info = op.Information[index];
            return info.Illustrator;
        }

        public static string GetOperatorTypeString(OperatorType operatorType, OperatorSkinInfo? skinInfo)
        {
            switch (operatorType)
            {
                case OperatorType.Elite0:
                    return "精零";
                case OperatorType.Elite1:
                    return "精一";
                case OperatorType.Elite2:
                    return "精二";
                case OperatorType.Skin:
                    return skinInfo.Value.Name;
                case OperatorType.Promotion:
                    return "升变";
                default:
                    goto default;
            }
        }

        public static string GetOperatorSkinInfoDescription(Operator op, int index)
        {
            return op.Information[index].SkinInfo?.Description;
        }

        public static Visibility IsSkinInfoDescriptionTextShow(Operator op, int index)
        {
            if (op.Information[index].SkinInfo != null)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
}
