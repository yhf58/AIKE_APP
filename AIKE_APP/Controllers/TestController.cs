using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIKE_Model;
using AIKE_APP.Models;
using Newtonsoft.Json;
using AIKE_BLL;
namespace AIKE_APP.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<Userinfo> list = AIKE_BLL.DataManager.chackListmanager();

            ViewData["list"] = list;

            return View();
        }
        public ActionResult tt()
        {
       // 客户端ip:
           string id= Request.ServerVariables.Get("Remote_Addr").ToString();
       // 客户端主机名:
           string name= Request.ServerVariables.Get("Remote_Host").ToString();
           // 客户端浏览器IE：
      

       /// 服务器ip:
          string sid=  Request.ServerVariables.Get("Local_Addr").ToString();
            ///服务器名：  
           string sname= Request.ServerVariables.Get("Server_Name").ToString();

            return View();
        }

        public string delete(string id)
        {
            int toId = Convert.ToInt32(id);

            bool b = AIKE_BLL.DataManager.deletemanager(toId);

            if (b)
            {
                return "1";
            }
            else
            {
                return "0";
            }
            
        }

        //public string test(string name)
        //{
        //    //Msg s = new Msg();
        //    //s.discript = "成功！";
        //    //s.status = 1;
        //    //return JsonConvert.SerializeObject(s);
        //}
    }
}