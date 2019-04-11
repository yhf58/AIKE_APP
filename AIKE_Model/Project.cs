using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
   public class Project
    {
        public int ProjectID { get; set; }
        /// <summary>
        /// 项目类型编号
        /// </summary>
        public int ProjectTypeID { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 筹集金额
        /// </summary>
        public decimal RaiseMoney { get; set; }
        /// <summary>
        /// 筹集天数
        /// </summary>
        public int RaiseDays { get; set; }
        /// <summary>
        /// 项目地址
        /// </summary>
        public string ProjectAddress { get; set; }
        /// <summary>
        /// 项目封面
        /// </summary>
        public string ProjectCover { get; set; }
        /// <summary>
        /// 项目简介
        /// </summary>
        public string ProjectIntroduction { get; set; }
        /// <summary>
        /// 项目详情
        /// </summary>
        public string ProjectDetails { get; set; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public String Label { get; set; }
    }
}
