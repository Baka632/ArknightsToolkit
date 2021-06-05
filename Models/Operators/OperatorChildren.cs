using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models.Operators
{
    [XmlType(TypeName = "Children")]
    public class OperatorChildren
    {
        [XmlElement(ElementName = "Child")]
        public List<OperatorInfo> ChildList = new List<OperatorInfo>();
    }
}
