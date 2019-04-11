using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
    /// <summary>
    /// 评论内容实体类
    /// </summary>
   public class CommentInfo
    {
        public string AccountNumber { get; set; }
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public int ReplyID { get; set; }
        public string CommentContent { get; set;}
        public DateTime CommentTime { get; set; }
    }
}
