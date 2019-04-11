using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_DAL
{
   public class DBHelper
    {

        // Data Source = 123.207.38.193; Initial Catalog = Aikezc_DB; User ID = sa; Password=12345678+Sql
        public static string connString = "Data Source = 123.207.38.193; Initial Catalog = Aikezc_DB; User ID = sa; Password=12345678+Sql";
        // public static string sqlcon = "server=111.230.196.116;database=FWork;uid=sa;pwd=NET1706yhf";
      //  public static string connString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
       
        //初始化对象
        //public static void Search()
        //{
        //    if (con == null)
        //    {
        //        con = new SqlConnection(connString);
        //    }
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();

        //    }
        //    if (con.State == ConnectionState.Broken)
        //    {
        //        con.Close();
        //        con.Open();
        //    }

        //}
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetRead(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                
                throw;
            }
          
        }
        public static DataTable Gettable(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>

        public static bool GetBool(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                bool b = com.ExecuteNonQuery() > 0;
                con.Close();
                return b ;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
