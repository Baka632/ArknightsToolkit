using ArknightsToolkit.Services;
using Microsoft.Toolkit.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 干员列表
    /// </summary>
    [XmlRoot("OperatorsList",Namespace = "http://schema.livestudio.com/Operators.xsd"), XmlType("OperatorsList", Namespace = "http://schema.livestudio.com/Operators.xsd")]
    public class OperatorsList : IIncrementalSource<Operators>
    {
        [XmlElement(ElementName = "Operator")]
        public List<Operators> OperatorList = new List<Operators>();

        public async Task<IEnumerable<Operators>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => OperatorList = XmlService.XmlDeserialize<OperatorsList>(Resources.Resource.Operators, Encoding.UTF8).OperatorList);
            var result = (from p in OperatorList
                          select p).Skip(pageIndex * pageSize).Take(pageSize);
            return result;
        }

        public OperatorsList()
        {
            
        }
    }
}
