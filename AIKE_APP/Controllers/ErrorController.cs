using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIKE_APP.Controllers
{
    //自定错误页面
    public class ErrorController : Controller
    {
        // GET: Error：404
        public ActionResult Index()
        {
            return View();
        }
    }
}