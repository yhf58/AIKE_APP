using AIKE_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_BLL
{
    public class DataManager
    {
        public static Project project = new Project();
        public static List<ProjectReturn> list = new List<ProjectReturn>();
        /// <summary>
        /// 普通用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool loginManager(string name, string pwd)
        {
            return AIKE_DAL.DataServer.loginServer(name,pwd);
        }
        /// <summary>
        /// 后台登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        /// 

        
       public static List<Userinfo>GetUserinfos()
        {
            return AIKE_DAL.DataServer.GetUserinfos();
        }


        public static bool AdminloginManager(string name, string pwd)
        {
            return AIKE_DAL.DataServer.AdminloginServer(name, pwd);
        }

        public static bool addUser_manager(string niName, string phone, string acName, string pwd)
        {
            return AIKE_DAL.DataServer.addUser_server(niName,phone,acName,pwd);
        }

        public static bool deletemanager(int id)
        {
            return AIKE_DAL.DataServer.Detele(id);
        }

        public static List<Userinfo> chackListmanager()
        {
            return AIKE_DAL.DataServer.chackList();
        }
        public static bool UpPwd(string pwd,string acc)
        {
            return AIKE_DAL.DataServer.UpPwd(pwd,acc);
        }

        public static AllDatas AllDatas()
        {
            return AIKE_DAL.DataServer.GetAllDatas();
        }

        /// <summary>
        /// 创建项目
        /// </summary>
        /// <returns></returns>
        public static bool addProject()
        {
            return AIKE_DAL.DataServer.addReturn(list, project);
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        public static List<Project> ReadProject()
        {
            return AIKE_DAL.DataServer.ReadProject("");
        }



        public static List<ProjectMsgInfo> GetProjectMsgInfos(int ProjectID)
        {
            return AIKE_DAL.ProjectMsgServer.GetMsgInfo(ProjectID);
        }

        /// <summary>
        /// 插入评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static bool AddComment(InserComment comment)
        {
            return AIKE_DAL.CommentServer.AddComment(comment);
        }

        public static List<CommentInfo> GetCommentInfos(int ProjectID)
        {
            return AIKE_DAL.CommentServer.GetComment(ProjectID);
        }
    }
}
