using ArknightsToolkit.Models.Operators;
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
    public class Operator
    {
        /// <summary>
        /// 名字
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }       

        /// <summary>
        /// 干员生日
        /// </summary>
        public OperatorBirthday Birthday { get; set; }

        /// <summary>
        /// 星级
        /// </summary>
        [XmlAttribute]
        public short Star { get; set; }

        [XmlAttribute]
        /// <summary>
        /// 干员性别
        /// </summary>
        public OperatorGender Gender { get; set; }

        public OperatorChildren Children { get; set; }

        public Operator()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
