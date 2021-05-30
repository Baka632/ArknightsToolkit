using ArknightsToolkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArknightsToolkit.Helper;
using Windows.UI.Xaml.Media.Imaging;
using ArknightsToolkit.Models.Operators;

namespace ArknightsToolkit.Helper
{
    public static class GetInfomationFromListOfOperatorInfoHelper
    {
        public static OperatorType OperatorType { get; set; } = OperatorType.Elite0;

        public static BitmapImage GetOperatorImageFromList(OperatorChildren children)
        {
            List<string> temp = (from OperatorInfo info in children.ChildList where info.Type == OperatorType select info.ImageCodename).ToList();
            OperatorType = OperatorType.Elite0;
            return temp.First().ToOperatorImage();
        }

        public static BitmapImage GetOperatorClassImageFromList(OperatorChildren children)
        {
            List<OperatorClass> temp = (from OperatorInfo info in children.ChildList where info.Type == OperatorType select info.Class).ToList();
            OperatorType = OperatorType.Elite0;
            return temp.First().ToClassImage();
        }
    }
}
