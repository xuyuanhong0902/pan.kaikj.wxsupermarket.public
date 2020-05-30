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
  /// Mcoupon 优惠券
  /// </summary>
    public class Mcoupon
    {
        public string id { get; set; }

        /// <summary>
        /// 优化名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 优惠券面额
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 最大消费金额
        /// </summary>
        public decimal consumAmount { get; set; }

        /// <summary>
        /// 有效期开始时间
        /// </summary>
        public DateTime effectiveStart { get; set; }

        /// <summary>
        /// 有效期结束时间
        /// </summary>
        public DateTime effectiveEnd { get; set; }

        /// <summary>
        /// 已经发放数量
        /// </summary>
        public int creatCount { get; set; }

        /// <summary>
        /// 已经使用数量
        /// </summary>
        public int useCount { get; set; }

        public string isDelete { get; set; }
        public string isEffective { get; set; }
        public DateTime great_time { get; set; }
        public DateTime modify_time { get; set; }
    }
}
