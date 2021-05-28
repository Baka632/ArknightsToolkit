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
            IEnumerable<string> temp = from OperatorInfo info in children.ChildList where info.Type == OperatorType select info.ImageCodename;
            return temp.First().ToOperatorImage();
        }

        public static BitmapImage GetOperatorClassImageFromList(OperatorChildren children)
        {
            IEnumerable<OperatorClass> temp = from OperatorInfo info in children.ChildList where info.Type == OperatorType select info.Class;
            return temp.First().ToClassImage();
        }
    }
}
