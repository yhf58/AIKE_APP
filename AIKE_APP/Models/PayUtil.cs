using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AIKE_APP.Models
{
    public class PayUtil
    {
        public static string REDIRECT_URL = "http://localhost:64354/Home/Index";

        public static string API_USER = "cd9b9095";

        public static string API_KEY = "326bcc21-9861-45c1-990a-669dab5cdc41";

        public static Dictionary<string, string> payOrder(Dictionary<string, string> remoteMap)
        {
            Dictionary<string, string> paramMap = new Dictionary<string, string>();
            paramMap = remoteMap;

            paramMap.Add("redirect", REDIRECT_URL);
            paramMap.Add("api_user", API_USER);

            string signature = getSignature(API_USER, paramMap);

            paramMap.Add("signature", signature);

            return paramMap;
        }
        public static string getSignature(string api_user, Dictionary<string, string> remoteMap)
        {

            Dictionary<string, string> treeMap = new Dictionary<string, string>();
            treeMap.Add("api_user", api_user);
            if (null != remoteMap["price"])
            {
                treeMap.Add("price", remoteMap["price"]);
            }
            if (null != remoteMap["type"])
            {
                treeMap.Add("type", remoteMap["type"]);
            }
            if (null != remoteMap["redirect"])
            {
                treeMap.Add("redirect", remoteMap["redirect"]);
            }
            if (null != remoteMap["order_id"])
            {
                treeMap.Add("order_id", remoteMap["order_id"]);
            }
            if (null != remoteMap["order_info"])
            {
                treeMap.Add("order_info", remoteMap["order_info"]);
            }
            string signStr = API_KEY;
            foreach (string value in treeMap.Values)
            {
                string u = value;
                signStr = signStr + value;
            }
            return getMd5Hash(signStr);
        }

        public static string getOrderIdByUUId()
        {
            int machineId = 1;
            // int hashCodeV = UUID.randomUUID().toString().hashCode();
            string id = System.Guid.NewGuid().ToString("N");
            //if (hashCodeV < 0)
            //{// 有可能是负数
            //    hashCodeV = -hashCodeV;
            //}
            //  0 代表前面补充0;d 代表参数为正数型
            return machineId + id;
        }


        public static bool checkPayKey(Paypayzhu paypayzhu)
        {
            Dictionary<string, string> treeMap = new Dictionary<string, string>();
            if (!isBlank(paypayzhu.Ppz_order_id))
            {
                treeMap.Add("ppz_order_id", paypayzhu.Ppz_order_id);
                //System.out.println("支付回来的平台订单号：" + paypayzhu.getPpz_order_id());
            }
            if (!isBlank(paypayzhu.Order_id))
            {
                treeMap.Add("order_id", paypayzhu.Order_id);
                //System.out.println("支付回来的订单号：" + paypayzhu.getOrder_id());
            }
            if (!isBlank(paypayzhu.Price))
            {
                treeMap.Add("price", paypayzhu.Price.ToString());
                //System.out.println("支付回来的价格：" + paypayzhu.getPrice());
            }
            if (!isBlank(paypayzhu.Real_price))
            {
                treeMap.Add("real_price", paypayzhu.Real_price.ToString());
                //System.out.println("支付回来的真实价格：" + paypayzhu.getReal_price());
            }
            if (!isBlank(paypayzhu.Order_info))
            {
                treeMap.Add("order_info", paypayzhu.Order_info);
                //System.out.println("支付回来的订单信息：" + paypayzhu.getOrder_info());
            }

            string signStr = API_KEY;
            foreach (string value in treeMap.Values)
            {
                signStr = signStr + value;
            }
            string signMd5 = getMd5Hash(signStr);
            //System.out.println("我们自己拼接的签名：" + signMd5);
            return paypayzhu.Signature.Equals(signMd5);
        }

        public static bool isBlank(string str)
        {
            return str == null || str.Trim().Length == 0;
        }

        /**
         * 判断字符串是否为空
         * @param charSequence
         * @return
         */
        public static bool isEmpty(string charSequence)
        {
            return charSequence == null || charSequence.Length == 0;
        }

        //public static string makeMd5Sum(string str)
        //{
        //    if (str == null)
        //    {
        //        return null;
        //    }


        //    byte[] s;
        //    try
        //    {

        //        //string pwd = "";
        //        MD5 md5 = MD5.Create(); //实例化一个md5对像
        //        // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
        //        s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //    return Convert.ToBase64String(s);
        //}

        //public static string GetMD5(string myString)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;

        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x");
        //    }

        //    return byte2String;
        //}
        //public static string MD5Encrypt(string strText)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
        //    return System.Text.Encoding.UTF8.GetString(result);
        //}

        //static string UserMd5(string str)
        //{
        //    string cl = str;
        //    string pwd = "";
        //    MD5 md5 = MD5.Create();//实例化一个md5对像
        //    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
        //    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
        //    // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符

        //        pwd = pwd + s[i].ToString("X");

        //    }
        //    return pwd;
        //}

        //public static string MD5Encrypt(string input, Encoding encode)
        //{
        //    if (string.IsNullOrEmpty(input))
        //    {
        //        return null;
        //    }
        //    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        //    byte[] data = md5Hasher.ComputeHash(encode.GetBytes(input));
        //    StringBuilder sBuilder = new StringBuilder();
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }
        //    return sBuilder.ToString();
        //}

        //public static string MD5(string Password, int Length)
        //{

        //    if (Length != 16 && Length != 32) throw new System.ArgumentException("Length参数无效,只能为16位或32位");
        //    System.Security.Cryptography.MD5CryptoServiceProvider MD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        //    byte[] b = MD5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
        //    System.Text.StringBuilder StrB = new System.Text.StringBuilder();
        //    for (int i = 0; i < b.Length; i++)
        //        StrB.Append(b[i].ToString("x").PadLeft(2, '0'));
        //    if (Length == 16)
        //        return StrB.ToString(8, 16);
        //    else
        //        return StrB.ToString();
        //}

        //public static string getMd5(string userPwd)
        //{
        //    //获取userPwd的byte类型数组
        //    byte[] byteUserPwd = Encoding.UTF8.GetBytes(userPwd);
        //    //实例化MD5CryptoServiceProvider
        //    MD5CryptoServiceProvider myMd5 = new MD5CryptoServiceProvider();
        //    // byte类型数组的值转换为 byte类型的Md5值
        //    byte[] byteMd5UserPwd = myMd5.ComputeHash(byteUserPwd);
        //    //将byte类型的Md5值转换为字符串
        //    string strMd5Pwd = Encoding.Default.GetString(byteMd5UserPwd).Trim();
        //    //返回Md5字符串
        //    return strMd5Pwd;
        //}
        public static string getMd5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.
            char[] temp = input.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}