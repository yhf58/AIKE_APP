using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AIKE_APP.Filter;
using AIKE_APP.Models;
using AIKE_BLL;
using AIKE_Model;
using Newtonsoft.Json;

namespace AIKE_APP.Controllers
{
   
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    ViewData["ProjectType"] = AIKE_BLL.HomeManager.GetProjectTypes();
        //    //string strHostName = System.Net.Dns.GetHostName();
        //    //string clientIPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
        //    //string ip = System.Web.HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.UserHostAddress, Encoding.GetEncoding("GB2312"));
        //    System.Web.HttpContext.Current.Application["count"] = Convert.ToInt32(System.Web.HttpContext.Current.Application["count"]) + 1;
        //    return View();
        //}
        static List<Project> list = new List<Project>();
        public ActionResult Index(string typename)
        {
            Session["LoginName"] = "Home/Index";
            System.Web.HttpContext.Current.Application["count"] = Convert.ToInt32(System.Web.HttpContext.Current.Application["count"]) + 1;
            if (typename == "" || typename == null)
            {
                list = AIKE_BLL.DataManager.ReadProject();
                ViewData["Read"] = list;
                return View();
            }
            else
            {
                int typeid = int.Parse(typename);
                List<Project> news = new List<Project>();
                foreach (Project itme in list)
                {
                    int id = itme.ProjectTypeID;
                    if (itme.ProjectTypeID == typeid)
                        news.Add(itme);
                }
                ViewData["Read"] = news;
                return View();
            }


        }

        public ActionResult Login()
        {
            return View();
        }

        public string Logins(string name,string pwd)
        {
            Logins l = new Logins();
          
            if (name == "" || pwd == "" || name == null || pwd == null)
            {
                l.state = 0;
                l.action = "";
                return JsonConvert.SerializeObject(l);
            }

            List<Userinfo> userinfos = AIKE_BLL.DataManager.GetUserinfos();
            
            foreach(Userinfo u in userinfos)
            {
                if (u.AccountNumber == name && u.Password == pwd && u.UserType == 1)
                {
                    Session["person"] = u;
                    l.state = 1;
                    if (Session["LoginName"] == null || Session["LoginName"].ToString() == "")
                    {
                        l.action ="Home/Index";
                    }
                    else
                    {
                        l.action = Session["LoginName"].ToString();
                    }
                   
                    return JsonConvert.SerializeObject(l);
                }
            }
            l.state = 2;
            l.action = "";
            return JsonConvert.SerializeObject(l);
        } 

        public ActionResult Register()
        {
            return View();
        }
        private string THE_UID = "TOPSS"; //用户名  
        private string THE_KEY = "59cf4591e00f1c5ff4e1"; //接口秘钥
        public string YZM(string phone)
        {
            try
            {
                if (phone == "" || phone == null)
                {
                    return "0";
                }
                if (phone.Length!=11)
                {
                    return "2";
                }
              
                    int ra = new Random().Next(10000, 1000000);//随机产生一个验证码
                    Session["yam"] = ra;
                    string number = phone;
                    string smsText = "验证码：" + ra + ",一个小时内有效，为了保障您的账号安全，请勿向他人试漏验证信息";//发送信息的内容
                    //string PostUrl = GetPostUrl(number, smsText);//调用函数

                    //string result = PostSmsInfo(PostUrl);//调用函数

                    //string t = GetResult(result);

                    return "1";
               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /*******************************************短信验证码***********************************************/

        /// <summary>返回UTF-8编码发送接口地址</summary>  
        /// <param name="receivePhoneNumber">目的手机号码（多个手机号请用半角逗号隔开）</param>  
        /// <param name="receiveSms">短信内容，最多支持400个字，普通短信70个字/条，长短信64个字/条计费</param>  
        /// <returns></returns>  
        public string GetPostUrl(string smsMob, string smsText)
        {
            string postUrl = "http://utf8.api.smschinese.cn/?Uid=" + THE_UID + "&key=" + THE_KEY + "&smsMob=" + smsMob + "&smsText=" + smsText;
            return postUrl;
        }
        /// <summary>  
        /// 发送短信，得到返回值  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public string PostSmsInfo(string url)
        {
            //调用时只需要把拼成的URL传给该函数即可。判断返回值即可  
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
                Response.Write(" <script>layer.msg('"+ex.Message+"', { icon: 2 });</ script > ");
            }
            return strRet;
        }
        /// <summary>  
        /// 确认返回信息   
        /// </summary>  
        /// <param name="strRet"></param>  
        /// <returns></returns>  
        public string GetResult(string strRet)
        {
            int result = 0;
            try
            {
                result = int.Parse(strRet);
                switch (result)
                {
                    case -1:
                        strRet = "没有该用户账户";
                        break;
                    case -2:
                        strRet = "接口密钥不正确,不是账户登陆密码";
                        break;
                    case -21:
                        strRet = "MD5接口密钥加密不正确";
                        break;
                    case -3:
                        strRet = "短信数量不足";
                        break;
                    case -11:
                        strRet = "该用户被禁用";
                        break;
                    case -14:
                        strRet = "短信内容出现非法字符";
                        break;
                    case -4:
                        strRet = "手机号格式不正确";
                        break;
                    case -41:
                        strRet = "手机号码为空";
                        break;
                    case -42:
                        strRet = "短信内容为空";
                        break;
                    case -51:
                        strRet = "短信签名格式不正确,接口签名格式为：【签名内容】";
                        break;
                    case -6:
                        strRet = "IP限制";
                        break;
                    default:
                        strRet = "发送短信数量：" + result;
                        break;
                }
            }
            catch (Exception ex)
            {
                strRet = ex.Message;
            }
            return strRet;
        }

        /************************************************************************************************/

        public string Registers(string name, string phone, string pwd, string yzm)
        {
            try
            {
                if (yzm == Convert.ToString(Session["yam"]))
                {
                    if (AIKE_BLL.DataManager.addUser_manager("昵称", phone, name, pwd))
                    {
                        return "2";
                    }
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
          
        }



        public string Forget_yzm(string yzm)
        {
            try
            {
                if (yzm == Convert.ToString(Session["yam"]))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }



        public ActionResult Forget()
        {
            return View();
        }
        
        public string  Uppwd(string pwd,string acc)
        {
            if (AIKE_BLL.DataManager.UpPwd(pwd, acc))
            {
                return "1";
            }
            else
            {
                return "0";
            }   
        }

        //////////////////////登录验证///////////////////////////
        //public void GetAdminExists()
        //{
        //    //1.获取登录用户名和面貌
        //    string username = Request["username"];
        //    string userpwd = Request["password"];
        //    try
        //    {
        //        //2.获取该用户实例对象
        //        administrater admin = adminserver.GetModel(username);
        //        //3.判断用户是否存在
        //        if (adminserver.Exists(username, userpwd))
        //        {
        //            //4.把获取的实例对象添加到Session中
        //            Session.Add("user", admin);
        //            //5.输出结果
        //            Response.Write("<script>alert('登录成功！');window.location.href = '/Admin/AdminPwdChange';</script>");
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('用户名密码错误！'); window.location.href = '/Home/Login';</script>");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Response.Write("<script>alert('登录错误！'); window.location.href = '/Home/Login';</script>");
        //    }
        //}

        /////////////////////////////////////////////////

        ///////////////////获取IP////////////////////////////////////
        //public static string GetWebClientIp()
        //{

        //    string userIP = "未获取用户IP";

        //    try
        //    {
        //        if (System.Web.HttpContext.Current == null
        //         || System.Web.HttpContext.Current.Request == null
        //         || System.Web.HttpContext.Current.Request.ServerVariables == null)
        //        {
        //            return "";
        //        }

        //        string CustomerIP = "";

        //        //CDN加速后取到的IP simone 090805
        //        CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
        //        if (!string.IsNullOrEmpty(CustomerIP))
        //        {
        //            return CustomerIP;
        //        }

        //        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //        if (!String.IsNullOrEmpty(CustomerIP))
        //        {
        //            return CustomerIP;
        //        }

        //        if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
        //        {
        //            CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        //            if (CustomerIP == null)
        //            {
        //                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        //            }
        //        }
        //        else
        //        {
        //            CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        //        }

        //        if (string.Compare(CustomerIP, "unknown", true) == 0 || String.IsNullOrEmpty(CustomerIP))
        //        {
        //            return System.Web.HttpContext.Current.Request.UserHostAddress;
        //        }
        //        return CustomerIP;
        //    }
        //    catch { }

        //    return userIP;

        //}
        /////////////////////////////////////////////////////////////
        ///
        public ActionResult Peek(string TypeName)
        {

            ViewData["Proj"] = "";

            return Redirect("../Home/Index");
        }

        //个人主页
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult Collect()
        {
            
            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult Identification()
        {
            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult Message()
        {
            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult Person()
        {
            Session["LoginName"] = "Home/Person";

            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult ProjectManagement()
        {
            Session["LoginName"] = "Home/ProjectManagement";
            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult Subsidize()
        {
            Session["LoginName"] = "Home/Subsidize";
            return View();
        }
        [PersonCheckFilterAttribute(IsCheck = true)]
        public ActionResult Updata()
        {
            Session["LoginName"] = "Home/Updata";
            return View();
        }


        /// <summary>
        /// 项目详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(int ProjectID)
        {
            ViewData["cemment"] = AIKE_BLL.DataManager.GetCommentInfos(Convert.ToInt32(ProjectID));
            
            ViewData["projectMsg"] = AIKE_BLL.DataManager.GetProjectMsgInfos(Convert.ToInt32(ProjectID));

            return View();
        }

        public string Connrent_s(string txt,int ProjectID)
        {
            if (Session["person"] == null)
            {
                return "2";
            }
            Userinfo u = (Userinfo)Session["person"];
            InserComment comment = new InserComment();
            comment.UserID = u.UserID;
            comment.ProjectID = ProjectID;
            comment.ReplyID = u.UserID;
            comment.CommentContent = txt;
            bool b = AIKE_BLL.DataManager.AddComment(comment);
            if (b)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

    }
}