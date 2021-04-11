using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 表示干员的类
    /// </summary>
    public class Operators
    {
        /// <summary>
        /// 名字
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 星级
        /// </summary>
        [XmlAttribute]
        public short Star { get; set; }

        /// <summary>
        /// 干员立绘图代号
        /// </summary>
        [XmlAttribute]
        public string ImageCodename { get; set; }

        /// <summary>
        /// 干员职业
        /// </summary>
       [XmlAttribute]
        public OperatorsClass OperatorClass { get; set; }

        /// <summary>
        /// 指示干员是否拥有皮肤
        /// </summary>
        /// 男默女泪，小羊衣柜
        [XmlAttribute]
        public bool HasSkin { get; set; }

        /// <summary>
        /// 干员生日
        /// </summary>
        public OperatorsBirthday Birthday { get; set; }

        [XmlAttribute]
        /// <summary>
        /// 干员性别
        /// </summary>
        public OperatorsSex Sex { get; set; }

        public override string ToString()
        {
            return $"干员名={Name} 星级={Star} 立绘图代号={ImageCodename}";
        }
    }
}
