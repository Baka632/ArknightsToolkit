﻿using System.Xml.Serialization;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 表示干员生日的结构
    /// </summary>
    public struct OperatorBirthday
    {
        [XmlAttribute]
        public int Month;
        [XmlAttribute]
        public int Day;

        /// <summary>
        /// 使用int类型构造OperatorsBirthday结构
        /// </summary>
        /// <param name="Month">月份</param>
        /// <param name="Day">日</param>
        public OperatorBirthday(int Month,int Day)
        {
            this.Month = Month;
            this.Day = Day;
        }
    }
}
