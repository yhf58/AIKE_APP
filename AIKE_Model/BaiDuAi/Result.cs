using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 图像识别类别
/// </summary>
namespace CarAir
{
   /// <summary>
   /// 定义与百度返回的json数据相同的类
   /// </summary>
    public class Baike_info
    {
        public string baike_url { get; set; }
        public string image_url { get; set; }
        public string description { get; set; }
    }
    public class Result
    {
        public string score { get; set; }
        public string root { get; set; }
        public Baike_info baike_info { get; set; }
        public string keyword { get; set; }
    }
    public class RootObject
    {
        public string log_id { get; set; }
        public string result_num { get; set; }
        public List<Result> result { get; set; }
    }

}
