using ArknightsToolkit.Models.Operators;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    [XmlType(TypeName = "Profiles")]
    public class OperatorProfiles
    {
        [XmlElement(ElementName = "Profile")]
        public List<OperatorProfile> ProfilesList = new List<OperatorProfile>();
    }
}