using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AIKE_Model;
namespace AIKE_DAL
{
   public class HomeServer
    {
       public static List<ProjectType> GetProjectTypes()
        {
            List<ProjectType> list = new List<ProjectType>();

            string sql = "select ProjectType from tb_ProjectType";

            SqlDataReader dr = DBHelper.GetRead(sql);

            while (dr.Read())
            {
                ProjectType type = new ProjectType();
                type.ProjectTypeName = dr.GetString(0);
                list.Add(type);
            }
            dr.Close();
            return list;
        }
    }
}
