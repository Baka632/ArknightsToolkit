using ArknightsToolkit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsToolkit.Helper
{
    public static class OperatorComparer
    {
        public static int CompareByName(Operator x, Operator y)
        {
            return string.Compare(x.Name, y.Name);
        }

        public static int CompareByNameReverse(Operator x, Operator y)
        {
            return string.Compare(y.Name, x.Name);
        }

        public static int CompareByStarCount(Operator x, Operator y)
        {
            return y.Star.CompareTo(x.Star);
        }

        public static int CompareByStarCountReverse(Operator x, Operator y)
        {
            return x.Star.CompareTo(y.Star);
        }
    }
}
