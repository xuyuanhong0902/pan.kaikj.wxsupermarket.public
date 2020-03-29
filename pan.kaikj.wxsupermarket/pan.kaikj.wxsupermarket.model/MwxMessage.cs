/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：winXin.GongZhongHao.Model
*文件名：  MwxMessageBase
*版本号：  V1.0.0.0
*唯一标识：8a853cac-aa24-4f66-b198-827c23e536c1
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/2 18:05:48

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/2 18:05:48
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

namespace pan.kaikj.wxsupermarket.model
{
    public class MwxMessage
    {
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public Int64 CreateTime { get; set; }

        /// <summary>
        /// 消息ID 消息id，64位整型
        /// </summary>
        public Int64 MsgId { get; set; }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 事件键
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 指菜单ID
        /// </summary>
        public string MenuID { get; set; }
    }
}
