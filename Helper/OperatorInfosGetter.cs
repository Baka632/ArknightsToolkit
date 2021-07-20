using System.Collections.Generic;
using ArknightsResources.Helpers;
using ArknightsResources.Models;
using Microsoft.Toolkit.Uwp.UI.Controls.TextToolbarSymbols;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    public class OperatorInfosGetter
    {
        public OperatorInfosGetter()
        {
            //Don't delete this constructor!(For XAML code)
        }

        public static BitmapImage GetImage(Operator op, int index)
        {
            byte[] image = ResourceHelper.GetOperatorImage(op.ImageCodename, op.Information[index].Type);
            return image.AsBitmapImage();
        }

        public static BitmapImage GetImage(string codename)
        {
            byte[] image = ResourceHelper.GetOperatorImage(codename, OperatorType.Elite0);
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
    }
}
