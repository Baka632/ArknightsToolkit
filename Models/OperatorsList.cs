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
    [XmlRoot("OperatorsList"), XmlType("OperatorsList")]
    public class OperatorsList
    {
        [XmlElement(ElementName = "Operator", Namespace = "http://schema.livestudio.com/Operators.xsd")]
        public List<Operators> OperatorList { get; } = new List<Operators>();
    }
}
