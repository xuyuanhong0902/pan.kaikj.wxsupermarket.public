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
    public class Mordersmain
    {
        public string orderGroupId { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string productId { get; set; }
        public string productname { get; set; }
        public string productformat { get; set; }
        public decimal origPrice { get; set; }
        public decimal sellPrice { get; set; }
        public decimal freight { get; set; }

        public decimal totalPrice { get; set; }
        public int payType { get; set; }
        public string payTypeDesc { get; set; }
        public string requireDeliveryTime { get; set; }
        public int orderState { get; set; }
        public string orderStateDesc { get; set; }
        public string mailAddress { get; set; }
        public string deliveryName { get; set; }
        public string deliveryTell { get; set; }
        public DateTime deliveryTime { get; set; }
        public DateTime receiptTime { get; set; }
        public string isDelete { get; set; }
        public string isEffective { get; set; }
        public DateTime great_time { get; set; }
        public DateTime modify_time { get; set; }

        /// <summary>
        /// 购物车ID
        /// </summary>
        public string shoppingCartId { get; set; }
    }
}
