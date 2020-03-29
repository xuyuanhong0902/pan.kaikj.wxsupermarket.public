/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：winXin.GongZhongHao.Model
*文件名：  MWXUserSampleInfo
*版本号：  V1.0.0.0
*唯一标识：7fa703b4-c523-4882-b1ef-f385cf1f8f48
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/7 23:44:14

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/7 23:44:14
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
    /// MWXUserSampleInfo
    /// </summary>
    public class MWXUserSampleInfo
    {
        /// <summary>
        /// refresh_token
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// scope
        /// </summary>
        public string scope { get; set; }

        public string expires_in { get; set; }
    }
}
