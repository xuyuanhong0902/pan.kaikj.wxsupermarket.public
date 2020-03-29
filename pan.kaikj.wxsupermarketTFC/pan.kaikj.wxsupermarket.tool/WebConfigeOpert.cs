/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.tool
*文件名：  WebConfigeOpert
*版本号：  V1.0.0.0
*唯一标识：1df9b9a2-e35a-41d0-8b16-a34683f9b3aa
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 14:28:12

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 14:28:12
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.tool
{
    /// <summary>
    /// WebConfigeOpert
    /// </summary>
    public static class WebConfigeOpert
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        private static string platformName;

        /// <summary>
        /// 获取平台名称
        /// </summary>
        /// <returns></returns>
        public static string GetPlatformName() {
            if (string.IsNullOrEmpty(platformName))
            {
                platformName = PublicTools.GetWebConfigValueByKey("PlatformName");
            }
            return string.IsNullOrEmpty(platformName)?"平台": platformName;
        }

        /// <summary>
        /// 微信平台中的token值
        /// </summary>
        private static string WXtoken;

        /// <summary>
        /// 获取 WXtoken
        /// </summary>
        /// <returns></returns>
        public static string GetWXtoken()
        {
            if (string.IsNullOrEmpty(WXtoken))
            {
                WXtoken = PublicTools.GetWebConfigValueByKey("WXTOKEN");
            }
            return string.IsNullOrEmpty(WXtoken) ? "pankaikj" : WXtoken;
        }

        /// <summary>
        /// 微信平台的APPID
        /// </summary>
        private static string WXappid;

        /// <summary>
        /// 获取 WXappid
        /// </summary>
        /// <returns></returns>
        public static string GetWXappid()
        {
            if (string.IsNullOrEmpty(WXappid))
            {
                WXappid = PublicTools.GetWebConfigValueByKey("WXAPPID");
            }
            return string.IsNullOrEmpty(WXappid) ? "wxb6b83df5a7c9d84c" : WXappid;
        }

        /// <summary>
        /// 微信平台的密码
        /// </summary>
        private static string WXAppSecret;

        /// <summary>
        /// 获取 WXAppSecret
        /// </summary>
        /// <returns></returns>
        public static string GetWXAppSecret()
        {
            if (string.IsNullOrEmpty(WXAppSecret))
            {
                WXAppSecret = PublicTools.GetWebConfigValueByKey("WXAppSecret");
            }
            return string.IsNullOrEmpty(WXAppSecret) ? "93a5a13791a722cd828b7bec87687d1a" : WXAppSecret;
        }

        /// <summary>
        /// 是否记录微信消息日志 1:记录 0：不记录 默认为0
        /// </summary>
        private static string isAddWXMessageLog;

        /// <summary>
        /// 获取 是否记录微信消息日志
        /// </summary>
        /// <returns></returns>
        public static string GetIsAddWXMessageLog()
        {
            if (string.IsNullOrEmpty(isAddWXMessageLog))
            {
                isAddWXMessageLog = PublicTools.GetWebConfigValueByKey("IsAddWXMessageLog");
            }
            return string.IsNullOrEmpty(isAddWXMessageLog) ? "0" : isAddWXMessageLog;
        }

        /// <summary>
        /// 微信消息日志记录路径 默认值为：c:\WXMessageLog
        /// </summary>
        private static string WXMessageLogPath;

        /// <summary>
        /// 获取 微信消息日志记录路径
        /// </summary>
        /// <returns></returns>
        public static string GetWXMessageLogPath()
        {
            if (string.IsNullOrEmpty(WXMessageLogPath))
            {
                WXMessageLogPath = PublicTools.GetWebConfigValueByKey("WXMessageLogPath");
            }
            return string.IsNullOrEmpty(WXMessageLogPath) ? @"c:\WXMessageLog" : WXMessageLogPath;
        }

        /// <summary>
        /// 微信公众号接口地址 默认值为：https://api.weixin.qq.com/
        /// </summary>
        private static string WXAPIurl;

        /// <summary>
        /// 获取 微信公众号接口地址
        /// </summary>
        /// <returns></returns>
        public static string GetWXAPIURL()
        {
            if (string.IsNullOrEmpty(WXAPIurl))
            {
                WXAPIurl = PublicTools.GetWebConfigValueByKey("WXAPIURL");
            }
            return string.IsNullOrEmpty(WXAPIurl) ? "https://api.weixin.qq.com/" : WXAPIurl;
        }

        /// <summary>
        /// 数据库连接语句
        /// </summary>
        private static string SqlString;

        /// <summary>
        /// 获取数据库连接语句
        /// </summary>
        /// <returns></returns>
        public static string GetSqlString()
        {
            if (string.IsNullOrEmpty(SqlString))
            {
                SqlString = PublicTools.GetWebConfigValueByKey("SqlString");
            }
            return string.IsNullOrEmpty(SqlString) ? "" : SqlString;
        }

    }
}
