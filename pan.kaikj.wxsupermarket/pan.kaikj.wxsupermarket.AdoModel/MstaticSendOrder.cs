/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoModel
*文件名：  MstaticSendOrder
*版本号：  V1.0.0.0
*唯一标识：2bc8ef61-71b1-4ace-8d83-96bbd00c4512
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/15 22:30:07

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/15 22:30:07
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

namespace pan.kaikj.wxsupermarket.AdoModel
{
    /// <summary>
    /// MstaticSendOrder
    /// </summary>
    public class MstaticSendOrder
    {

        public int sendGoodsCount { get; set; }

        public int delayedSendGoodsCount { get; set; }

        public int halfhourSendGoodsCount { get; set; }

        public int todaySendGoodsCount { get; set; }
    }
}
