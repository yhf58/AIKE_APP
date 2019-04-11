using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIKE_Model;
using System.Data;
using System.Data.SqlClient;

namespace AIKE_DAL
{
   public class CommentServer
    {

        public static List<CommentInfo> GetComment(int ProjectID)
        {
            string sql = "select CommentID,tb_comment.UserID,ProjectID,ReplyID,CommentContent,CommentTime,AccountNumber  from tb_user,tb_comment where tb_user.userid=tb_comment.userid and ProjectID="+ProjectID+"  order by CommentID desc";
            SqlDataReader reader= DBHelper.GetRead(sql);
            if (reader == null) return null;
            List<CommentInfo> list = new List<CommentInfo>();
            while(reader.Read())
            {
                CommentInfo comment = new CommentInfo()
                {
                    CommentID=reader.GetInt32(0),
                    UserID=reader.GetInt32(1),
                    ProjectID=reader.GetInt32(2),
                    ReplyID=reader.GetInt32(3),
                    CommentContent=reader.GetString(4),
                    CommentTime=reader.GetDateTime(5),
                    AccountNumber=reader.GetString(6)
                };
                list.Add(comment);
            }
            reader.Close();
            return list;
        }


        //评论插入数据
        public static bool AddComment(InserComment comment)
        {
            string sql = "insert into tb_Comment(UserID,ProjectID,ReplyID,CommentContent) values("+comment.UserID+","+comment.ProjectID+","+comment.ReplyID+",'"+comment.CommentContent+"')";
            bool b = DBHelper.GetBool(sql);
            return b;            
        }
    }
}
