using AIKE_APP.Filter;
using AIKE_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIKE_APP.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {

            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult ProjectDetail(string path)
        {
            Session["LoginName"] = "Project/ProjectDetail";
            ViewData["photo"] = "";
            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult Returns()
        {

            return View();
        }
        /// <summary>
        /// 图像识别
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string Pro(string path)
        {
            List<string> list = new List<string>();
            list = AIKE_BLL.BaiDuAI.ImageRecognition(path);
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 文本纠查
        /// </summary>
        /// <param name="oldstr"></param>
        /// <returns></returns>
        public string NewTxet(string oldstr)
        {
            string newstr = AIKE_BLL.BaiDuAI.TextCorrection(oldstr);
            return newstr;
        }
        public string Detection(string strs)
        {
            int i = AIKE_BLL.BaiDuAI.TextDetection(strs);
            return i.ToString();
        }


        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            var path = $"/Images/{file.FileName}";
            file.SaveAs(Server.MapPath(path));      //保存文件
            string fname = file.FileName;
            Session["sphoto"] = fname;
            return Redirect("../Project/ProjectDetail");
        }
        public string getPhoto()
        {
            return Session["sphoto"].ToString();
        }
        public ActionResult File()
        {
            return View();
        }

        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult ProjectReturn()
        {
            return View();
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="name">项目名称</param>
        /// <param name="days">筹集天数</param>
        /// <param name="money">筹集金额</param>
        /// <param name="Add">发起地址</param>
        /// <param name="Details">项目详情</param>
        /// <param name="Introduction">项目简介</param>
        public void AddProject(string name, int days, decimal money, string Add, string Details, string Introduction, string Label)
        {
            Project project = new Project()
            {
                ProjectAddress = Add,
                ProjectCover = "",
                ProjectDetail = Details,
                ProjectIntroduction = Introduction,
                ProjectName = name,
                ProjectTypeID = 1,
                RaiseDays = days,
                RaiseMoney = money,
                State = 0,
                Label = Label,
                ReleaseTime = DateTime.Parse("2010-2-12")

            };
            AIKE_BLL.DataManager.project = project;
        }

        public void AddReturn(int Money, int number, string Content, int time)
        {
            ProjectReturn projectReturn = new ProjectReturn()
            {
                SupportMoney = Money,
                Number = number,
                ReturnContent = Content,
                ReturnTime = time
            };
            AIKE_BLL.DataManager.list.Add(projectReturn);
        }
        public void AddNumber()
        {
            AIKE_BLL.DataManager.addProject();
        }

    }
}