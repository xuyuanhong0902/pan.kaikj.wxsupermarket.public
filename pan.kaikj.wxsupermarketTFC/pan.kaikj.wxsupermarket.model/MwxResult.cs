/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：winXin.GongZhongHao.Model
*文件名：  MwxResult
*版本号：  V1.0.0.0
*唯一标识：fc22eb57-29ff-4b06-81a4-53c858edddc8
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/6 20:55:16

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/6 20:55:16
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
    /// MwxResult
    /// </summary>
    public class MwxResult
    {
        /// <summary>
        /// 错误编码 0 代表成功
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string errmsg { get; set; }
    }
}
