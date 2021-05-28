using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 干员性别
    /// </summary>
    public enum OperatorGender
    {
        /// <summary>
        /// 男性
        /// </summary>
        [XmlEnum(Name = "Male")]
        Male,
        /// <summary>
        /// 女性
        /// </summary>
        [XmlEnum(Name = "Female")]
        Female,
        /// <summary>
        /// 断罪
        /// </summary>
        [XmlEnum(Name = "Conviction")]
        Conviction
    }
}
