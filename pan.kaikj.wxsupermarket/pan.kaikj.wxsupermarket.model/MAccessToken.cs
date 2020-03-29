/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：winXin.GongZhongHao.Model
*文件名：  MAccessToken
*版本号：  V1.0.0.0
*唯一标识：006be022-e08f-4f77-83cf-ada0f97e5927
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/5 21:28:27

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/5 21:28:27
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
    /// MAccessToken
    /// </summary>
    public class MAccessToken
    {
        /// <summary>
        /// AccessToken值
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 有效期秒数
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 微信token过期时间
        /// </summary>
        public DateTime ExpiresDateTime { get; set; }
}
}
