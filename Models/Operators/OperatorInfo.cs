using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 表示干员信息的结构
    /// </summary>
    public struct OperatorInfo
    {
        [XmlAttribute]
        public OperatorType Type { get; set; }

        /// <summary>
        /// 干员立绘图代号
        /// </summary>
        [XmlAttribute]
        public string ImageCodename { get; set; }

        [XmlAttribute]
        public string Illustrator { get; set; }

        [XmlAttribute]
        public string CV { get; set; }

        /// <summary>
        /// 干员职业
        /// </summary>
        [XmlAttribute("OperatorClass")]
        public OperatorClass Class { get; set; }
    }
}
