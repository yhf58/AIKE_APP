using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIKE_Model;
namespace AIKE_BLL
{
   public class AdminManager
    {
        public static List<AdminUsers> GetAdminUsers()
        {
            return AIKE_DAL.AdminServer.GetAdminUsers();
        }
        public static EditUser GetEditUsers(int id)
        {
            return AIKE_DAL.AdminServer.GetEdit(id);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Edits(string type, string realName, string phone, int id)
        {
            return AIKE_DAL.AdminServer.Edits(type,realName,phone,id);
        }

        public static bool DeleteUser(int id)
        {
            return AIKE_DAL.AdminServer.DeteleUser(id);
        }

        public static List<Msg> GetMsg()
        {
            return AIKE_DAL.AdminServer.GetMsg();
        }

        public static bool DeleteMsg(int id)
        {
            return AIKE_DAL.AdminServer.DeleteNew(id);
        }

        public static string GetEditNew(int id)
        {
            return AIKE_DAL.AdminServer.GetEditNew(id);
        }
        public static List<CommentList> GetCommentinfos()
        {
            return AIKE_DAL.AdminServer.GetComment();
        }
        
        /// <summary>
        /// 多选删除评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteComments(int [] id)
        {
            return AIKE_DAL.AdminServer.DeleleComments(id);
        }
        /// <summary>
        /// 项目基本信息
        /// </summary>
        /// <returns></returns>
        public static List<Admin_ProjectInfo> GetProjectMsgInfos()
        {
            return AIKE_DAL.AdminServer.GetProjectMsgInfos();
        }
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteProject(int id)
        {
            return AIKE_DAL.AdminServer.DeleteProject(id);
        }

        public static List<string> GetMsgType()
        {
            return AIKE_DAL.AdminServer.GetMsgType();

        }
    }
}
