using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 干员职业的枚举
    /// </summary>
    public enum OperatorClass
    {

        /// <summary>
        /// 先锋
        /// </summary>
        [XmlEnum(Name = "Vanguard")]
        Vanguard,
        /// <summary>
        /// 狙击
        /// </summary>
        [XmlEnum(Name = "Sniper")]
        Sniper,
        /// <summary>
        /// 近卫
        /// </summary>
        [XmlEnum(Name = "Guard")]
        Guard,
        /// <summary>
        /// 术师
        /// </summary>
        [XmlEnum(Name = "Caster")]
        Caster,
        /// <summary>
        /// 重装
        /// </summary>
        [XmlEnum(Name = "Defender")]
        Defender,
        /// <summary>
        /// 医疗
        /// </summary>
        [XmlEnum(Name = "Medic")]
        Medic,
        /// <summary>
        /// 特种
        /// </summary>
        [XmlEnum(Name = "Specialist")]
        Specialist,
        /// <summary>
        /// 辅助
        /// </summary>
        [XmlEnum(Name = "Supporter")]
        Supporter
    }
}
