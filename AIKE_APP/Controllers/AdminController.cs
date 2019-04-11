using AIKE_APP.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIKE_Model;
using Newtonsoft.Json;


namespace AIKE_APP.Controllers
{
   
    public class AdminController : Controller
    {
        // GET: Admin

        [MyCheckFilterAttribute(IsCheck = true)]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public string  Logins(string name,string pwd)
        {
            if (name == "" || pwd == "" || name == null || pwd == null)
            {

                return "0";
            }

            if (AIKE_BLL.DataManager.AdminloginManager(name, pwd))
           {
                Session.Add("user", name);

                return "1";
            }
            else
            {

                return "2";
            }
        }

        [MyCheckFilterAttribute(IsCheck = true)]
        public new ActionResult User()
        {
            ViewData["userlist"] = AIKE_BLL.AdminManager.GetAdminUsers();

            return View();
        }
        [MyCheckFilterAttribute(IsCheck = true)]
        public ActionResult Comment()
        {
            ViewData["comment"] = AIKE_BLL.AdminManager.GetCommentinfos();
            return View();
        }


        [MyCheckFilterAttribute(IsCheck = true)]
        public ActionResult Project()
        {

            ViewData["projectinfo"] = AIKE_BLL.AdminManager.GetProjectMsgInfos();

            return View();
        }
        
        [MyCheckFilterAttribute(IsCheck = true)]
        public ActionResult NewsList()
        {
            ViewData["newlist"] = AIKE_BLL.AdminManager.GetMsg();
            return View();
        }
        [MyCheckFilterAttribute(IsCheck = true)]
        public ActionResult EditNews(string  id)
        {
            ViewData["MsgType"] =AIKE_BLL.AdminManager.GetMsgType();
            string type =((List<string>)ViewData["MsgType"])[0];
            ViewData["editNew"] = "";
            if (id == null||id=="") return View();

            else
            {
                ViewData["editNew"] = AIKE_BLL.AdminManager.GetEditNew(Convert.ToInt32(id));
            }
            return View();
        }

        /// <summary>
        /// 获取总体数据
        /// </summary>
        /// <returns></returns>
        public string Datas()
        {
            AllDatas d = AIKE_BLL.DataManager.AllDatas();
            return JsonConvert.SerializeObject(d);
        }

        /// <summary>
        /// 获取修改用户的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Edit(string id)
        {
            Session["id"] = id;
            EditUser ed = AIKE_BLL.AdminManager.GetEditUsers(Convert.ToInt32(id));
            return JsonConvert.SerializeObject(ed);
        }
        
        public string Edits(string type,string realName,string phone)
        {
            int id = Convert.ToInt32(Session["id"]);
            bool b = AIKE_BLL.AdminManager.Edits(type,realName,phone,id);
            if (b)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public string DeleteUser(string id)
        {
            bool b = AIKE_BLL.AdminManager.DeleteUser(Convert.ToInt32(id));
            if (b)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

       public ActionResult Logout()
        {
            Session["user"] = null;
            return Redirect("../Admin/Login");
        }
       
       public string DeleteMsg(string id)
       {
            bool b = AIKE_BLL.AdminManager.DeleteMsg(Convert.ToInt32(id));

            if (b)
            {
                return "1";
            }
            else
            {
                return "0";
            }
       }

        public string DeleteComment(string [] id )
        {
            int[] num = new int[id.Length];
           for(int i = 0; i < id.Length; i++)
            {
                num[i] =Convert.ToInt32(id[i]==null?"0":id[i]);
            }
            bool b = AIKE_BLL.AdminManager.DeleteComments(num);

            if (b)
            {
                return "1";
            }
            else
            {
                return "0";
            }
            
        }

        public string DeleteProject(string id)
        {
            bool b = AIKE_BLL.AdminManager.DeleteProject(Convert.ToInt32(id));

            if (b)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string FileUpload(HttpPostedFileBase file)
        {
            var path = $"/Images/MsgImg/{file.FileName}";
            file.SaveAs(Server.MapPath(path));//保存文件
            string fname = file.FileName;
            return file.FileName.ToString();
        }

        public string FileUpload2(HttpPostedFileBase file)
        {
            var path = $"/Images/MsgImg/{file.FileName}";
            file.SaveAs(Server.MapPath(path));//保存文件
            string fname = file.FileName;
            return file.FileName.ToString();
        }

        public string FMsg(string title,string txt,string type,string msg_txt)
        {


            return "";
        }
    }
}