using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsToolkit.Models
{
    /// <summary>
    /// 表示干员生日的结构
    /// </summary>
    public struct OperatorBirthday
    {
        public int Month;
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
