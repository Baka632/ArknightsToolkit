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
    public class OperatorInfo
    {
        [XmlAttribute]
        public OperatorType Type { get; set; }

        [XmlAttribute]
        /// <summary>
        /// 干员立绘图代号
        /// </summary>
        public string ImageCodename { get; set; }

        /// <summary>
        /// 干员职业
        /// </summary>
        [XmlAttribute]
        public OperatorClass Class { get; set; }

        public OperatorInfo()
        {

        }
    }
}
