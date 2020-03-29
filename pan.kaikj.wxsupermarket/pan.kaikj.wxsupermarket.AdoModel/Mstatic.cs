/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoModel
*文件名：  Madminuser
*版本号：  V1.0.0.0
*唯一标识：e3d0c997-202d-4ddf-979d-f4750f16f1ab
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/11 21:38:19

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/11 21:38:19
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
{ /// <summary>
  /// Morder 订单
  /// </summary>
    public class Mstatic
    {
        public int totalCount { get; set; }
        public decimal totalPrice { get; set; }

        public int successTotatlCount { get; set; }
        public decimal successTotalPrice { get; set; }

        public int totayTotalCount { get; set; }
        public decimal totayTotalPrice { get; set; }

        public int totaySuccessTotalCount { get; set; }
        public decimal totaySuccessTotalPrice { get; set; }

        public int yesterdayTotalCount { get; set; }
        public decimal yesterdayTotalPrice { get; set; }

        public int yesterdaySuccessTotalCount { get; set; }
        public decimal yesterdaySuccessTotalPrice { get; set; }

        public int daiSendGoodsCount { get; set; }
        public int sendGoodsCount { get; set; }

        public int selGoodsCount { get; set; }
        public int noSelGoodsCount { get; set; }
    }
}
