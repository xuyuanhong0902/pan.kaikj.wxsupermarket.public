/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.tool
*文件名：  WXTokenOpert
*版本号：  V1.0.0.0
*唯一标识：b2f01229-57b6-4946-a5ea-dbb66e290aeb
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 20:07:09

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 20:07:09
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.tool
{
    /// <summary>
    /// WXTokenOpert 微信服务器验证处理
    /// </summary>
    public class WXTokenOpert
    {
        /// <summary>
        /// 微信token对象
        /// </summary>
        public static MAccessToken AccessToken;

        /// <summary>
        /// 获取token值
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken()
        {
            //// 实现步骤
            //// 1、首先判断AccessToken是否有值
            //// 2、如果没有值，那么直接获取token
            //// 2、如果有值，那么在判断是否过期
            //// 3、如果过期，那么重新获取token
            AccessToken = GetAccesstokenFromWX();
          //// if (AccessToken == null ||
          ////     string.IsNullOrEmpty(AccessToken.access_token) ||
          ////     AccessToken.ExpiresDateTime < System.DateTime.Now)
          //// {
          ////     AccessToken = GetAccesstokenFromWX();
          //// }

            return AccessToken.access_token;
        }

        /// <summary>
        /// 通过appID和appsecret获取Access_token
        /// </summary>
        /// <returns></returns>
        private static MAccessToken GetAccesstokenFromWX()
        {
            try
            {
                //// 微信API地址
                string wxAPIURL = WebConfigeOpert.GetWXAPIURL();

                //// 微信平台的APPID
                string appid = WebConfigeOpert.GetWXappid();

                //// 微信平台的密码
                string secret = WebConfigeOpert.GetWXAppSecret();

                string strUrl = wxAPIURL + "cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret;
                MAccessToken mode = PublicTools.HttpGetRequest<MAccessToken>(strUrl);
                LogOpert.AddWeiXinMessage("获取wxAccesstoken结果：" + mode.access_token);
                return mode;
            }
            catch (Exception ex)
            {
                LogOpert.AddWeiXinMessage("获取wxAccesstoken异常：" + ex);
            }

            return null;
        }
    }
}
