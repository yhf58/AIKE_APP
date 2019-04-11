using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
   public class CommentList
    {
                //c.CommentID = dr.GetInt32(0);
                //c.AccountNumber = dr.GetString(1);
                //c.CommentContent = dr.GetString(2);
                //c.ProjectName = dr.GetString(3);
                //c.CommentTime = dr.GetDateTime(4);
        public string AccountNumber { get; set; }
        public int CommentID { get; set; }
        public string ProjectName { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
