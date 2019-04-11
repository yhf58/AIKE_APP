using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
    public class ProjectReturn
    {
        /// <summary>
        /// 支持金额
        /// </summary>
        public decimal SupportMoney { get; set; }
        /// <summary>
        /// 限定人数
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 回报内容
        /// </summary>
        public string ReturnContent { get; set; }
        /// <summary>
        /// 回报时间
        /// </summary>
        public int ReturnTime { get; set; }
    }
}
