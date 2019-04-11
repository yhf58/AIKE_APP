using AIKE_APP.Filter;
using System.Web;
using System.Web.Mvc;

namespace AIKE_APP
{
    //public class FilterConfig
    //{
        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //}
        public class FilterConfig
        {
            public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
                //filters.Add(new HandleErrorAttribute());//原始声明的Action验证器
                filters.Add(new MyCheckFilterAttribute() { IsCheck = true });
            }
        }
}
