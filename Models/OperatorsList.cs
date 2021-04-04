using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 干员列表
    /// </summary>
    [XmlRoot("OperatorsList",Namespace = "http://schema.livestudio.com/Operators.xsd"), XmlType("OperatorsList", Namespace = "http://schema.livestudio.com/Operators.xsd")]
    public class OperatorsList
    {
        [XmlElement(ElementName = "Operator")]
        public List<Operators> OperatorList { get; } = new List<Operators>();
    }
}
