using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    public struct OperatorSkinInfo
    {
        /// <summary>
        /// 皮肤名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }
        /// <summary>
        /// 皮肤描述
        /// </summary>
        [XmlAttribute]
        public string Description { get; set; }
    }
}
