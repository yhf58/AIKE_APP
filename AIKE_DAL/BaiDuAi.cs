using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIKE_Model;
using CarAir;
using Newtonsoft.Json;
namespace AIKE_DAL
{
   public class BaiDuAi
    {
        /// <summary>
        /// 图像识别
        /// </summary>
        /// <param name="Path">图像地址</param>
        /// <returns></returns>
        public static List<string>ImageRecognition(string Path)
        {
            List<string> types = null;
            // 设置APPID/AK/SK
            var API_KEY = "bCKBIvGV7CGRCTEmRErE3h8l";
            var SECRET_KEY = "fsdd0brGLR04g47TykqIgZsRB4a7Kba1";
            var client = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            
            // 调用通用物体识别，可能会抛出网络等异常，请使用try/catch捕获
            try
            {
                var image = File.ReadAllBytes(Path);
                var result = client.AdvancedGeneral(image);

                // 如果有可选参数
                var options = new Dictionary<string, object>{
            {"baike_num", 5}};
                result = client.AdvancedGeneral(image, options);
                //解析json数据
                RootObject rb = JsonConvert.DeserializeObject<RootObject>(((object)result).ToString());
                List<Result> list = rb.result;
             
                types = new List<string>();
                foreach (Result itme in list)
                    types.Add(itme.keyword);
                return types;
            }
            catch (Exception ex)
            {
                return types;
            }


        }
        /// <summary>
        /// 文本纠查
        /// </summary>
        /// <param name="oldstr">需要进行纠查的文本内容</param>
        /// <returns></returns>
        public static string TextCorrection(string oldstr)
        {
            string newstr = "";
            // 设置APPID/AK/SK
            var API_KEY = "f9lW5F1dvZYnUyY0giikjG0x";
            var SECRET_KEY = "VpiaIYO9vnDq3IBuaI16fz3tGrCZpOFI";
            try
            {
                var client = new Baidu.Aip.Nlp.Nlp(API_KEY, SECRET_KEY);
                client.Timeout = 60000;  // 修改超时时间
                var result = client.Ecnet(oldstr);// 调用文本纠错，可能会抛出网络等异常，请使用try/catch捕获
                newstr = result["item"]["correct_query"].ToString();
                return newstr;
            }
            catch(Exception e)
            {
                return "";
            }
          
           
        }

        /// <summary>
        /// 文本检测
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int TextDetection(string text)
        {
            var API_KEY = "qiRnQTeHdh2AKsceGQ61BPo1";
            var SECRET_KEY = "Gfyr8kwH7d1zktAthx0HIXfQAvvbW1ws";
            try
            {
                var client = new Baidu.Aip.ContentCensor.TextCensor(API_KEY, SECRET_KEY);
                client.Timeout = 60000;  // 超时，毫秒
                var result = client.AntiSpam(text);
                int i = int.Parse(result["result"]["spam"].ToString());
                return i;
            }
            catch(Exception e)
            {
                return -1;
            }
           

            
        }
    }
}
