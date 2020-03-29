/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：weiXinGongZhongHao.Bus
*文件名：  LogOpert
*版本号：  V1.0.0.0
*唯一标识：18b0f1e5-1d86-4850-a15f-b619606c3a16
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/2 20:39:18

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/2 20:39:18
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
    /// LogOpert 日志操作类
    /// </summary>
    public static class LogOpert
    {
        /// <summary>
        /// 定义一个添加日志的委托
        /// </summary>
        public delegate bool AddLogDelegate(string message);

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message"></param>
        public static void AddWeiXinMessage(string message)
        {
            try
            {
                AddMessage(message);
              //// AddLogDelegate handler = new AddLogDelegate(AddMessage);
              //// handler.BeginInvoke(message, null, null);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message"></param>
        public static bool AddMessage(string message)
        {
            try
            {
                //// 记录接收到的微信消息日志
                //// 获取微信消息日志存储位置

                //// 是否记录微信消息日志 1:记录 0：不记录 默认为0
                string isAddWXMessageLog = WebConfigeOpert.GetIsAddWXMessageLog();

                //// 如果不记录日志，那么直接返回
                if (isAddWXMessageLog != "1")
                {
                    return true;
                }

                //// 微信消息日志记录路径
                string wxMessageLogPath = WebConfigeOpert.GetWXMessageLogPath();

                if (string.IsNullOrEmpty(wxMessageLogPath))
                {
                    return true;
                }

                DateTime dateNow = System.DateTime.Now;

                //// 检查创建文件夹
                CreateDirectoryByMoth(dateNow, wxMessageLogPath);

                string filePath = string.Format("{0}//{1}//{2}//{3}.txt", wxMessageLogPath, dateNow.ToString("yyyy"), dateNow.ToString("MM"), dateNow.ToString("yyyyMMdd"));
                //// 按照日期创建文件
                CreateFile(filePath);

                //// 写文件
                FileOpert.WriteFile(filePath, message, true);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据年月检查创建文件
        /// </summary>
        /// <param name="date">时间标准</param>
        /// <param name="filePath"></param>
        private static void CreateDirectoryByMoth(DateTime date, string filePath)
        {

            //// 先判读年文件夹是否已经创建
            filePath = filePath + "//" + date.ToString("yyyy");
            FileOpert.CheckDirectoryIsExists(filePath, true);

            //// 检查月文件是否已经创建
            filePath = filePath + "//" + date.ToString("MM");
            FileOpert.CheckDirectoryIsExists(filePath, true);
        }

        private static void CreateFile(string filePath)
        {
            //// 先判读年文件夹是否已经创建
            FileOpert.CheckFileIsExists(filePath, true);
        }
    }
}
