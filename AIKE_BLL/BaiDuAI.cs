using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIKE_DAL;
namespace AIKE_BLL
{
    public class BaiDuAI
    {
        /// <summary>
        /// 图像识别
        /// </summary>
        /// <param name="path">图片地址</param>
        /// <returns></returns>
        public static List<string> ImageRecognition(string path)
        {
            return AIKE_DAL.BaiDuAi.ImageRecognition(path);
        }
        /// <summary>
        /// 文本纠查
        /// </summary>
        /// <param name="oldstring">输入要进行纠查的文本</param>
        /// <returns></returns>
        public static string TextCorrection(string oldstring)
        {
            return AIKE_DAL.BaiDuAi.TextCorrection(oldstring);
        }
        /// <summary>
        /// 文本检测
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int TextDetection(string str)
        {
            return AIKE_DAL.BaiDuAi.TextDetection(str);
        }
    }
}
