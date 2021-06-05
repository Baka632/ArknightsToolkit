using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    public struct OperatorProfile
    {
        [XmlText]
        public string Profile { get; set; }
        [XmlAttribute]
        public OperatorProfileType Type { get; set; }
    }
}
