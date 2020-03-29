/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.tool
*文件名：  WXApiOpert
*版本号：  V1.0.0.0
*唯一标识：ea184b3e-00da-4748-bac0-22ca6fa815e0
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 20:05:37

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 20:05:37
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.tool
{
    /// <summary>
    /// WXApiOpert
    /// </summary>
    public class WXApiOpert
    { /// <summary>
      /// 微信服务器配置验证
      /// </summary>
      /// <param name="signature"signature></param>
      /// <param name="timestamp">timestamp</param>
      /// <param name="nonce">nonce</param>
      /// <param name="token">token</param>
      /// <returns></returns>
        public bool CheckSignature(string signature, string timestamp, string nonce, string token)
        {
            string[] ArrTmp = { token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();

            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 菜单操作

        /// <summary>
        /// 向微信服务器请求创建自定义菜单
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public MwxResult AddMenu(string jsonStr)
        {
            //// 处理结果对象
            MwxResult model = null;

            //// 微信API地址
            string interfaceUrl = WebConfigeOpert.GetWXAPIURL();
            interfaceUrl = string.IsNullOrEmpty(interfaceUrl) ? "https://api.weixin.qq.com/" : interfaceUrl;

            //声明一个HttpWebRequest请求
            interfaceUrl = string.Format("{0}cgi-bin/menu/create?access_token={1}", interfaceUrl, WXTokenOpert.GetAccessToken());

            model = PublicTools.HttpPostRequest<MwxResult>(interfaceUrl, jsonStr);

            return model;
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public string GetMenu()
        {
            //// 微信API地址
            string wxAPIURL = WebConfigeOpert.GetWXAPIURL();

            string strUrl = wxAPIURL + "cgi-bin/menu/get?access_token=" + WXTokenOpert.GetAccessToken();

            return PublicTools.HttpGetRequestAsString(strUrl);
        }

        /// <summary>
        /// 删除所有菜单
        /// </summary>
        /// <returns></returns>
        public MwxResult DeletMenu()
        {
            //// 微信API地址
            string wxAPIURL = WebConfigeOpert.GetWXAPIURL();

            string strUrl = wxAPIURL + "cgi-bin/menu/delete?access_token=" + WXTokenOpert.GetAccessToken();
            return PublicTools.HttpGetRequest<MwxResult>(strUrl);
        }

        #endregion 

        #region 微信消息处理

        /// <summary>    
        /// 发送文字消息    
        /// </summary>    
        /// <param name="wx">获取的收发者信息    
        /// <param name="content">内容    
        /// <returns></returns>    
        public string SendTextMessage(MwxMessage wx, string content)
        {
            string res = string.Format(@" ", wx.FromUserName, wx.ToUserName, DateTime.Now, content);
            return res;
        }

        /// <summary>
        /// 发送被动响应消息
        /// </summary>
        /// <param name="ToUserName">接收方帐号（收到的OpenID）</param>
        /// <param name="Content">回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）</param>
        /// <param name="FromUserName">开发者微信号</param>
        /// <param name="CreateTime">消息创建时间 （整型）</param>
        /// <param name="MsgType">text</param>
        /// <returns></returns>
        public string GetSendMessage(MwxMessage wx, string content)
        {
            var createTime = ConvertDateTimeInt(DateTime.Now);

            return
                string.Format(@"<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Content><![CDATA[{4}]]></Content></xml>",
                wx.FromUserName, wx.ToUserName, createTime, wx.MsgType, content);
        }

        /// <summary>
        /// datetime转换为unixtime
        /// 将时间类型转换为整形
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        #endregion

        /// <summary>
        /// 根据code获取openid(一个code只能查询一次)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public String GetOpenIdByCode(String code)
        {
            //// 微信API地址
            string wxAPIURL = WebConfigeOpert.GetWXAPIURL();

            //// 微信平台的APPID
            string appid = WebConfigeOpert.GetWXappid();

            //// 微信平台的密码
            string secret = WebConfigeOpert.GetWXAppSecret();
            secret = string.IsNullOrEmpty(secret) ? "7233eefb8657eb0f6a1ed7224fdc0e7f" : secret;

            // 换取access_token 其中包含了openid
            // 这里通过code换取的是一个特殊的网页授权access_token,与基础支持中的access_token（该access_token用于调用其他接口）不同。
            String strUrl = string.Format("{0}sns/oauth2/access_token?appid={1}&secret={2}&code={3}&grant_type=authorization_code", wxAPIURL, appid, secret, code);

            MWXUserSampleInfo model = null;
            model= PublicTools.HttpGetRequest<MWXUserSampleInfo>(strUrl);

            if (model != null)
            {
                return model.openid;
            }

            return string.Empty;
        }

        #region 用户信息

        /// <summary>
        /// 根据OpenID 获取用户基本信息(需关注公众号）
        /// </summary>
        /// <param name="openId"></param>
        public MWXUserInfo GetUserInfo(string openId)
        {
            //// 微信API地址
            string wxAPIURL = WebConfigeOpert.GetWXAPIURL();

            String strUrl = string.Format("{0}cgi-bin/user/info?access_token={1}&openid={2}&lang=zh_CN", wxAPIURL, WXTokenOpert.GetAccessToken(), openId);
            MWXUserInfo model = PublicTools.HttpGetRequest<MWXUserInfo>(strUrl);

            //// 对获取大的用户信息的关注日期和头像做处理
            if (model!=null)
            {
                model.subscribe_time = PublicTools.GetDateTimeWithSecond(Convert.ToInt64(model.subscribe_time)).ToString("yyyy-MM-dd HH:mm:ss");
                model.headimgurl = model.headimgurl.Substring(0,model.headimgurl.LastIndexOf('/')+1);
            }

            return model;
        }

        /// <summary>
        /// 修改用户备注信息
        /// </summary>
        /// <param name="openid">被修改这者的openid</param>
        /// <param name="remark">修改后的备注信息</param>
        /// <returns></returns>
        public MwxResult CheckUserRemark(string openid, string remark)
        {
            //// 处理结果对象
            MwxResult model = null;

            //// 微信API地址
            string wxAPIURL = WebConfigeOpert.GetWXAPIURL();

            //声明一个HttpWebRequest请求
            string interfaceUrl = string.Format("{0}cgi-bin/user/info/updateremark?access_token={1}", wxAPIURL, WXTokenOpert.GetAccessToken());

            string jsonStr = "{" + "\"openid\";" + openid + ",\"remark\":" + remark + "}";

            model = PublicTools.HttpPostRequest<MwxResult>(interfaceUrl, jsonStr);

            return model;
        }

        #endregion

    }
}
