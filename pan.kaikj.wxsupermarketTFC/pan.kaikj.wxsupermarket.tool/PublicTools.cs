/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：weiXinGongZhongHao.Tool
*文件名：  PublicTools
*版本号：  V1.0.0.0
*唯一标识：878f7ea5-da4c-45d5-8c30-50f3eeea265d
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/2 19:16:19

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/2 19:16:19
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace pan.kaikj.wxsupermarket.tool
{
    /// <summary>
    /// PublicTools 公共帮助类
    /// </summary>
    public static class PublicTools
    {
        /// <summary>
        /// 通过key,获取appSetting的值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>value</returns>
        public static string GetWebConfigValueByKey(string key)
        {
            string value = string.Empty;
            try
            {
                Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                AppSettingsSection appSetting = (AppSettingsSection)config.GetSection("appSettings");
                if (appSetting.Settings[key] != null)//如果不存在此节点，则添加  
                {
                    value = appSetting.Settings[key].Value;
                }
            }
            catch (Exception)
            {
            }
            return value;
        }

        /// <summary>
        /// 时间戳转换为datetime
        /// </summary>
        /// <param name="timeStamp">将秒字符串转换为时间格式</param>
        /// <returns></returns>
        public static DateTime GetDateTimeWithSecond(long timeStamp)
        {
            return GetDateTimeWithMilliSecond(timeStamp * 1000);
        }

        /// <summary>
        /// 时间戳转换为datetime
        /// </summary>
        /// <param name="timeStamp">将毫秒字符串转换为时间格式</param>
        /// <returns></returns>
        public static DateTime GetDateTimeWithMilliSecond(long timeStamp)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(timeStamp);
            return dt;
        }

        /// <summary>
        /// 得到一个由日期组成的随机数
        /// </summary>
        /// <returns></returns>
        public static string GetRandomNumberByTime()
        {
            //// 首先获取系统当天时间构成一个随机数
            string randomNumber = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
            Random rd = new Random();
            int i = rd.Next(1000, 9999);
            return randomNumber + i;
        }

        /// <summary>
        /// HttpPostRequest 返回结果为一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="interfaceUrl"></param>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static T HttpPostRequest<T>(string interfaceUrl, string postValue)
        {
            return JsonHelper.ParseFormJson<T>(HttpPostRequestAsString(interfaceUrl, postValue));
        }

        /// <summary>
        /// HttpPostRequest 返回结果为一个字符串
        /// </summary>
        /// <param name="interfaceUrl"></param>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static string HttpPostRequestAsString(string interfaceUrl, string postValue)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(interfaceUrl);
            //设置连接超时时间 
            request.Timeout = 30000;
            request.KeepAlive = true;
            Encoding encodeType = Encoding.GetEncoding("UTF-8");
            request.Headers.Set("Pragma", "no-cache");
            request.Method = "POST";

            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; Maxthon; .NET CLR 1.1.4322); Http STdns";
            request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            request.CookieContainer = new CookieContainer();
            byte[] Bytes = encodeType.GetBytes(postValue);

            request.ContentLength = Bytes.Length;
            request.AllowAutoRedirect = true;

            //发送数据
            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(Bytes, 0, Bytes.Length);
                writer.Close();
            }

            StringBuilder strb = new StringBuilder();
            //接收数据
            using (Stream reader = request.GetResponse().GetResponseStream())
            {
                StreamReader sr = new StreamReader(reader, encodeType);
                strb.Append(sr.ReadToEnd());
                sr.Close();
                reader.Close();
            }

            return strb.ToString();
        }

        /// <summary>
        /// HttpGetRequest 返回结果为一个对象
        /// </summary>
        /// <param name="interfaceUrl"></param>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static T HttpGetRequest<T>(string interfaceUrl)
        {
            return JsonHelper.ParseFormJson<T>(HttpGetRequestAsString(interfaceUrl));
        }

        /// <summary>
        /// HttpGetRequest 返回结果为一个字符串
        /// </summary>
        /// <param name="interfaceUrl"></param>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static string HttpGetRequestAsString(string interfaceUrl)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(interfaceUrl);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MD5CryptoService(string value) {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] palindata = Encoding.Default.GetBytes(value);//将要加密的字符串转换为字节数组
            byte[] encryptdata = md5.ComputeHash(palindata);//将字符串加密后也转换为字符数组
            return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为加密字符串
        }

        // 随机生成指定长度的验证码字符串
        public static string RandomCode(int length)
        {
            string s = "3456789xcvbnmasdfghjkqwertyuip";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            int index;
            for (int i = 0; i < length; i++)
            {
                index = rand.Next(0, s.Length);
                sb.Append(s[index]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 验证字符串是否由数字和字母组成
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckIsNumOrLetter(string value) {
            Regex reg = new Regex("^[a-zA-Z_0-9]+$");
            return reg.IsMatch(value);
        }

        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckIsPhonNum(string value)
        {
            Regex reg = new Regex(@"^[1]\d{10}$");
            return reg.IsMatch(value);
        }
    }
}
