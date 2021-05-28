using ArknightsToolkit.Helper;
using ArknightsToolkit.Services;
using ArknightsToolkit.ViewModels;
using Microsoft.Toolkit.Collections;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 干员列表
    /// </summary>
    [XmlRoot("OperatorsList", Namespace = "http://schema.livestudio.com/Operators.xsd"), XmlType("OperatorsList", Namespace = "http://schema.livestudio.com/Operators.xsd")]
    public class OperatorsList : IIncrementalSource<Operator>
    {
        [XmlElement(ElementName = "Operator")]
        public List<Operator> OperatorList = new List<Operator>();

        public static event NotifyCollectionChangedEventHandler CollectionChanged;

        public async Task<IEnumerable<Operator>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            if (OperatorList.Count == 0)
            {
                _ = await Task.Run(() => OperatorList = XmlService.XmlDeserialize<OperatorsList>(Resources.Resource.Operators, Encoding.UTF8).OperatorList);
                OperatorList.Sort(OperatorComparer.CompareByName);
            }
            IEnumerable<Operator> result = (from p in OperatorList
                                            select p).Skip(pageIndex * pageSize)
                                            .Take(pageSize);
            return result;
        }

        public OperatorsList()
        {
            OperatorListsViewModel.CompareByNameRequested += SortListByName;
            OperatorListsViewModel.CompareByStarCountRequested += SortListByStarCount;
        }

        public void SortListByName(OperatorComparerOption option)
        {
            switch (option)
            {
                case OperatorComparerOption.Normal:
                    OperatorList.Sort(OperatorComparer.CompareByName);
                    break;
                case OperatorComparerOption.Reverse:
                    OperatorList.Sort(OperatorComparer.CompareByNameReverse);
                    break;
                default:
                    break;
            }
            CollectionChanged?.Invoke(OperatorList, null);
        }

        public void SortListByStarCount(OperatorComparerOption option)
        {
            switch (option)
            {
                case OperatorComparerOption.Normal:
                    OperatorList.Sort(OperatorComparer.CompareByStarCount);
                    break;
                case OperatorComparerOption.Reverse:
                    OperatorList.Sort(OperatorComparer.CompareByStarCountReverse);
                    break;
                default:
                    break;
            }
            CollectionChanged?.Invoke(OperatorList, null);
        }
    }
}
