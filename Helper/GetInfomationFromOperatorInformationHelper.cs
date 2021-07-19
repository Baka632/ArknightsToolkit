using ArknightsToolkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArknightsToolkit.Helper;
using Windows.UI.Xaml.Media.Imaging;

namespace ArknightsToolkit.Helper
{
    public static class GetInformationFromOperatorInformationHelper
    {
        public static OperatorType OperatorType { get; set; } = OperatorType.Elite0;

        public static BitmapImage GetOperatorImageFromList(List<OperatorInfo> infos)
        {
            List<string> temp = (from OperatorInfo info in infos where info.Type == OperatorType select info.ImageCodename).ToList();
            OperatorType = OperatorType.Elite0;
            return temp.First().ToOperatorImage();
        }

        public static BitmapImage GetOperatorClassImageFromList(List<OperatorInfo> infos)
        {
            List<OperatorClass> temp = (from OperatorInfo info in infos where info.Type == OperatorType select info.Class).ToList();
            OperatorType = OperatorType.Elite0;
            return temp.First().ToClassImage();
        }
    }
}
