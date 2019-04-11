using AIKE_APP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIKE_APP.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index()
        {
            return View();
        }

        public string Pay(string price, int type)
        {
            Dictionary<string, string> remote = new Dictionary<string, string>();
            remote.Add("api_user", "cd9b9095");
            remote.Add("price", price);
            remote.Add("type", type.ToString());
            remote.Add("redirect", "http://localhost:64354/Home/Index");
            remote.Add("order_id", PayUtil.getOrderIdByUUId());
            remote.Add("order_info", "sp001");
            remote.Add("signature", PayUtil.getSignature("cd9b9095", remote));
            return JsonConvert.SerializeObject(remote, Formatting.Indented);
        }
        public string notifyPay(HttpRequest request, HttpResponse response, Paypayzhu paypayzhu)
        {
            // 保证密钥一致性
            if (PayUtil.checkPayKey(paypayzhu))
            {
                // TODO 做自己想做的
                return "成功了";
            }
            else
            {
                // TODO 该怎么做就怎么做
                return "失败了";
            }
        }
    }
}