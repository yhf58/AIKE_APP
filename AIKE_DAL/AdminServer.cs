using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIKE_Model;
using System.Data.SqlClient;
namespace AIKE_DAL
{
    public class AdminServer
    {
        public static List<AdminUsers> GetAdminUsers()
        {
            string sql = "select tb_User.UserID,tb_UserType.UserType,AccountNumber,RealName,AccountBalance,Phone from tb_User,tb_UserType where tb_User.UserTypeID = tb_UserType.UserTypeID";

            SqlDataReader dr = DBHelper.GetRead(sql);
            List<AdminUsers> list = new List<AdminUsers>();
            while (dr.Read())
            {
                AdminUsers u = new AdminUsers();
                u.ID = dr.GetInt32(0);
                u.UserType = dr.GetString(1);
                u.AccountNumber = dr.GetString(2);
                u.RealName = dr.GetString(3);
                u.AccountBalance = dr.GetDecimal(4);
                u.Phone = dr.GetString(5);
                list.Add(u);
            }
            dr.Close();

            return list;

        }

        public static EditUser GetEdit(int id)
        {
            string sql = "select tb_User.UserID,tb_UserType.UserType,Phone,RealName from tb_User, tb_UserType where tb_User.UserTypeID = tb_UserType.UserTypeID and tb_User.UserID = "+id+"";
            
            SqlDataReader dr = DBHelper.GetRead(sql);
            EditUser u = new EditUser();
            if (dr.Read())
            {
                u.ID = dr.GetInt32(0);
                u.UserType = dr.GetString(1);
                u.Phone = dr.GetString(2);
                u.RealName = dr.GetString(3);
            }

            dr.Close();
            return u;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="realName"></param>
        /// <param name="phone"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Edits(string type ,string realName,string phone,int id)
        {
            int typeId = 0;
            if (type == "普通用户") typeId = 1;
            if (type == "管理员") typeId = 2;
            if (type == "超级管理员") typeId = 3;

            string sql = "update tb_user set UserTypeID="+typeId+",RealName='"+realName+"',Phone='"+phone+"' where UserID="+id+"";

            bool b = DBHelper.GetBool(sql);

            return b;

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeteleUser(int id)
        {
            string sql = "delete from tb_User where UserID="+id+"";

            bool b = DBHelper.GetBool(sql);

            return b;
        }

        public static List<Msg> GetMsg()
        {
            List<Msg> list = new List<Msg>();
 
            string sql = "select MsgID,MsgTitle,MsgType,MsgContent,ExtensionTime from tb_Msg,tb_MsgType where tb_Msg.MsgTypeID=tb_MsgType.MsgTypeID";

            SqlDataReader dr = DBHelper.GetRead(sql);

            while (dr.Read())
            {
                Msg m = new Msg();
                m.ID = dr.GetInt32(0);
                m.Title = dr.GetString(1);
                m.MsgType = dr.GetString(2);
                m.MsgContent = dr.GetString(3);
                m.ExtensionTime = dr.GetDateTime(4);

                list.Add(m);
            }

            return list;
            
        }

        public static bool DeleteNew(int id)
        {
            string sql = "delete from tb_Msg where MsgID="+id+"";

            bool b = DBHelper.GetBool(sql);

            return b;

        }



        public static string GetEditNew(int id)
        {
            string sql = "select MsgContent from tb_Msg where MsgID="+id+"";

            SqlDataReader dr = DBHelper.GetRead(sql);
            string content = "";
            if (dr == null) return "";
            if (dr.Read())
            {
                 content = dr.GetString(0);
            }
            return content;
        }

        public static List<CommentList> GetComment()
        {
            string sql = "select CommentID,AccountNumber,CommentContent,ProjectName,CommentTime from tb_Comment,tb_User,tb_ProjectMsg where tb_Comment.UserID = tb_User.UserID and tb_Comment.ProjectID = tb_ProjectMsg.ProjectID";

            SqlDataReader dr = DBHelper.GetRead(sql);

            List<CommentList> list = new List<CommentList>();
            while (dr.Read())
            {
                CommentList c = new CommentList();
                c.CommentID = dr.GetInt32(0);
                c.AccountNumber = dr.GetString(1);
                c.CommentContent = dr.GetString(2);
                c.ProjectName = dr.GetString(3);
                c.CommentTime = dr.GetDateTime(4);
                list.Add(c);
            }
            dr.Close();

            return list;
        }

        public static bool DeleleComments(int [] id)
        {
            bool b=true;
            foreach(int i in id)
            {
                string sql = "delete from tb_Comment where CommentID="+i+"";
                b = DBHelper.GetBool(sql);
            }

            return b;
        }

        /// <summary>
        /// 项目基本信息
        /// </summary>
        ///// <returns></returns>
        public static List<Admin_ProjectInfo> GetProjectMsgInfos()
        {
            string sql = "select ProjectID,ProjectName,ProjectType,RaiseMoney,State from tb_ProjectMsg,tb_ProjectType where tb_ProjectType.ProjectTypeID = tb_ProjectType.ProjectTypeID";
            SqlDataReader dr = DBHelper.GetRead(sql);
            List<Admin_ProjectInfo> list = new List<Admin_ProjectInfo>();
            while (dr.Read())
            {
                Admin_ProjectInfo p = new Admin_ProjectInfo();
                p.ProjectID = dr.GetInt32(0);
                p.ProjectName = dr.GetString(1);
                p.ProjectTypeName = dr.GetString(2);
                p.RaiseMoney = dr.GetDecimal(3);
                p.State = dr.GetInt32(4);
                list.Add(p);
            }
            dr.Close();
            return list;
        }

        public static bool DeleteProject(int id)
        {

            string sql = "delete from tb_ProjectMsg where ProjectID="+id+"";
            bool b = DBHelper.GetBool(sql);
            return b;

        }
        /// <summary>
        /// 获取资讯类型
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMsgType()
        {
            string sql = "select MsgType from tb_MsgType";
            List<string> list = new List<string>();
            SqlDataReader dr = DBHelper.GetRead(sql);

            while (dr.Read())
            {
                list.Add(dr.GetString(0));
            }
            dr.Close();

            return list;
        }

    }
}
