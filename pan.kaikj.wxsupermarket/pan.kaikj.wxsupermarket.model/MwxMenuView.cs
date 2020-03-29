/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：winXin.GongZhongHao.Model
*文件名：  MwxMenu
*版本号：  V1.0.0.0
*唯一标识：750dc25a-2ec2-47a5-8c97-b0f59bce4238
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/6 21:20:32

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/6 21:20:32
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
    /// <summary>
    /// MwxMenu 微信菜单 url
    /// </summary>
    public class MwxMenuView : MwxMenuBase
    {

        /// <summary>
        /// 域名
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// appid
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// pagepath 具体页面为止地址
        /// </summary>
        public string pagepath { get; set; }
    }
}
