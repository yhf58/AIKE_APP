using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIKE_Model;
using System.Data.SqlClient;
using System.Data;

namespace AIKE_DAL
{
    public class DataServer
    {
        public static List<Userinfo> GetUserinfos()
        {
            List<Userinfo> list = new List<Userinfo>();
            string sql = "select UserID,UserTypeID,NickrName,Gender,Phone,AccountNumber,PassWord,RealName,AccountBalance,PayPassWord from tb_user";
            SqlDataReader dr = DBHelper.GetRead(sql);
            while (dr.Read())
            {
                Userinfo u = new Userinfo();
                u.UserID = dr.GetInt32(0);
                u.UserType = dr.GetInt32(1);
                u.NickName = dr.GetString(2);
                u.Gender = dr.GetString(3);
                u.Phone = dr.GetString(4);
                u.AccountNumber = dr.GetString(5);
                u.Password = dr.GetString(6);
                u.RealName = dr.GetString(7);
                u.AccountBalance = dr.GetDecimal(8);
                u.PayPassWord = dr.GetInt32(9);
                list.Add(u);
            }
            dr.Close();

            return list;
        }

        /// <summary>
        /// 普通账户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool loginServer(string name,string pwd)
        {
            string sql = "select * from tb_user where AccountNumber='"+name+"'";

            SqlDataReader dr = DBHelper.GetRead(sql);
            if (dr == null) {
                dr.Close();
               
                return false;
            }

            if (dr.Read())
            {
                if (dr["password"].ToString() == pwd &&Convert.ToInt32(dr["UserTypeID"])==1) return true;
            }

            dr.Close();
            return false;
        }
        /// <summary>
        /// 后台登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool AdminloginServer(string name, string pwd)
        {
            string sql = "select * from tb_user where AccountNumber='" + name + "'";

            SqlDataReader dr = DBHelper.GetRead(sql);
            if (dr == null)
            {
                dr.Close();

                return false;
            }

            if (dr.Read())
            {
                if (dr["password"].ToString() == pwd && Convert.ToInt32(dr["UserTypeID"]) ==2) return true;
            }

            dr.Close();
            return false;
        }


        public static bool addUser_server(string niName,string phone,string acName,string pwd)
        {
            string sql = "insert into tb_User(NickrName,Phone, AccountNumber,PassWord) values('"+niName+"','"+phone+"','"+acName+"','"+pwd+"')";

            bool b = DBHelper.GetBool(sql);

            return b;

        }

        public static bool Detele(int id)
        {

            string sql = "delete from tb_User where UserID="+id+"";

            bool b = DBHelper.GetBool(sql);

            if (b)
            {
                return b;
            }
            else
            {
                return false;
            }
            
        }

        public static List<Userinfo> chackList()
        {
            string sql = "select * from tb_user";
            List<Userinfo> list = new List<Userinfo>();
            SqlDataReader dr = DBHelper.GetRead(sql);
            while (dr.Read())
            {
                Userinfo u = new Userinfo();
                u.UserID = dr.GetInt32(0);
                u.UserType = dr.GetInt32(1);
                u.NickName = dr.GetString(2);
                u.Gender = dr.GetString(3);
                u.Phone = dr.GetString(4);
                u.AccountNumber = dr.GetString(5);
                u.Password = dr.GetString(6);
                u.RealName = dr.GetString(7);
                u.AccountBalance = dr.GetDecimal(8);
                u.PayPassWord = dr.GetInt32(9);
                u.PersonalStatement = dr.GetString(10);
                list.Add(u);
            }
            dr.Close();

            return list;
        }

        public static bool UpPwd(string pwd,string acc)
        {

            string sql = "update tb_User set PassWord='"+pwd+"' where AccountNumber ='"+acc+"'";

            bool b = DBHelper.GetBool(sql);

            if (b)
            {
                return b;
            }
            else
            {
                return false;
            }

        }

        public static AllDatas GetAllDatas()
        {
            AllDatas d = new AllDatas();
            string sql1 = "select COUNT(*) from tb_User";
            DataTable dt1 = DBHelper.Gettable(sql1);
            d.Users =Convert.ToInt32( dt1.Rows[0][0]);
            

            string sql2 = "select COUNT(*) from tb_ProjectMsg";
            DataTable dt2= DBHelper.Gettable(sql2);
            d.Projects = Convert.ToInt32(dt2.Rows[0][0]);
           
            string sql3 = "select SUM(Raised_money) from tb_ProjectMsg";
            DataTable dt3 = DBHelper.Gettable(sql3);
            d.ZC_Money = dt3.Rows[0][0]==null? 0: Convert.ToInt32(dt3.Rows[0][0]);
           

            return d;

        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="list">回报列表</param>
        /// <param name="proNumber">项目编号</param>
        /// <param name="project">项目类</param>
        /// <returns></returns>
        public static bool addReturn(List<ProjectReturn> list, Project project)
        {
            //添加项目
            string sql = "insert into tb_ProjectMsg(ProjectTypeID,ProjectName,RaiseMoney,RaiseDays,ProjectAddress,ProjectCover,ProjectIntroduction,ProjectDetails,State,ReleaseTime,Label)values('" + project.ProjectTypeID + "','" + project.ProjectName + "','" + project.RaiseMoney + "','" + project.RaiseDays + "','" + project.ProjectAddress + "','" + project.ProjectCover + "','" + project.ProjectIntroduction + "','" + project.ProjectDetail + "','" + project.State + "','" + project.ReleaseTime + "','" + project.Label + "')";

            bool t = DBHelper.GetBool(sql);

            ////获取新添加的项目的编号
            sql = "select ProjectID from tb_ProjectMsg where ProjectName='" + project.ProjectName + "'";
            SqlDataReader reader = DBHelper.GetRead(sql);
            if (reader.Read())
            {
                int proNumber = Convert.ToInt32(reader.GetInt32(0));
                foreach (ProjectReturn item in list)
                {
                    sql = "insert into [tb_Return](SupportMoney,Number,ReturnContent,ReturnTime,ProjectID)values('" + item.SupportMoney + "'," + item.Number + ",'" + item.ReturnContent + "'," + item.ReturnTime + ",'" + proNumber + "')";

                    bool b = DBHelper.GetBool(sql);

                    if (b == false)
                        return b;
                }
            }



            return true;
        }

        /// <summary>
        /// 读取项目信息
        /// </summary>
        /// <param name="types">项目类型</param>
        /// <returns></returns>
        public static List<Project> ReadProject(string types)
        {
            string sql = "";
            List<Project> list = new List<Project>();

            sql = "select pm.ProjectID, pm.ProjectName,pm.ProjectIntroduction,pm.ProjectTypeID,PM.ProjectCover from tb_ProjectMsg pm";
            SqlDataReader reader = DBHelper.GetRead(sql);
            while (reader.Read())
            {
                Project itme = new Project()
                {
                    ProjectID=reader.GetInt32(0),
                    ProjectName = reader.GetString(1),
                    ProjectIntroduction = reader.GetString(2),
                    ProjectTypeID = reader.GetInt32(3),
                    ProjectCover = reader.GetString(4)
                };
                list.Add(itme);
            }


            return list;
        }

    }
}
