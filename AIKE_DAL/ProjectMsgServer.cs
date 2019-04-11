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
   public class ProjectMsgServer
    {
        public static List<ProjectMsgInfo> GetMsgInfo(int ProjectID)
        {
            string sql = "select ProjectTypeID,ProjectName,RaiseMoney,RaiseDays,ProjectAddress,ProjectCover,ProjectIntroduction,ProjectDetails,Label,State,ReleaseTime,Raised_money,Support_man,Like_Count,c.UserID from tb_User c,tb_ProjectMsg b where c.UserID=b.UserID and ProjectID="+ProjectID+"";
            SqlDataReader reader = DBHelper.GetRead(sql);
            if (reader == null) return null;
            List<ProjectMsgInfo> list = new List<ProjectMsgInfo>();
            while(reader.Read())
            {
                ProjectMsgInfo g = new ProjectMsgInfo();

                g.ProjectTypeID = reader.GetInt32(0) ;
                g.ProjectName = reader.GetString(1);
                g.RaiseMoney = reader.GetDecimal(2);
                g.RaiseDays = reader.GetInt32(3);
                g.ProjectAddress = reader.GetString(4);
                g.ProjectCover = reader.GetString(5);
                g.ProjectIntroduction = reader.GetString(6);
                g.ProjectDetails = reader.GetString(7);
                g.Label = reader.GetString(8);
                g.State = reader.GetInt32(9);
                g.ReleaseTime = reader.GetDateTime(10);
                g.Raised_money = reader.GetDecimal(11);
                g.Support_man = reader.GetInt32(12);
                g.Like_Count = reader.GetInt32(13);
                g.UserID = reader.GetInt32(14);
         
                list.Add(g);
            }
            reader.Close();
            return list;
        }
        
    }
}
