using ArknightsToolkit.Models.Operators;
using ArknightsToolkit.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 表示干员的类
    /// </summary>
    public class Operator : INotifyPropertyChanged
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

        /// <summary>
        /// 干员档案
        /// </summary>
        public OperatorProfiles Profiles { get; set; }

        public Operator()
        {
            OperatorDetailsViewModel.OperatorTypeChanged += OnOperatorTypeChanged;
        }

        private void OnOperatorTypeChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Children)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name;
        }
    }
}
