using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
    /// <summary>
    /// 项目详情实体类
    /// </summary>
   public class ProjectMsgInfo
    {

       
        public int ProjectTypeID { get; set; }//项目类型ID
        public string ProjectName { get; set; }//项目名称
        public Decimal RaiseMoney { get; set; }//筹集金额
        public int RaiseDays { get; set; }//筹集天数

        public string ProjectAddress { get; set; }//项目地址
        public string ProjectCover { get; set; }//项目封面
        public string ProjectIntroduction { get; set; }//项目简介
        public string ProjectDetails { get; set; }//项目详情
        public string Label { get; set; }//项目标签
        public int State { get; set; }//项目筹集状态
        public DateTime ReleaseTime { get; set; }//发布到现在时间
        public Decimal Raised_money { get; set; }//已筹集金额
        public int Support_man { get; set; }//支持人数
        public int Like_Count { get; set; }//喜欢数量
        public int UserID { get; set; }//用户ID
    }
}
