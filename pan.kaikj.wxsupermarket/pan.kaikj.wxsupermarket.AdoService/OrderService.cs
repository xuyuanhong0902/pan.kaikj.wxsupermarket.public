/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  OrderService
*版本号：  V1.0.0.0
*唯一标识：b9e83762-b5d8-443e-b6c2-d64a65d958a5
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 19:35:41

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 19:35:41
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoDal;
using pan.kaikj.wxsupermarket.AdoIdal;
using pan.kaikj.wxsupermarket.AdoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoService
{
    /// <summary>
    /// OrderService
    /// </summary>
    public class OrderService
    {
        public OrderIdal opertService = new OrderDal();

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrder(List<Morder> model)
        {
            return opertService.AddOrder(model);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public bool UpdateOrderState(string orderid, int orderState)
        {
            return opertService.UpdateOrderState(orderid, orderState);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public bool UpdateOrderStateByIds(string orderidS, int orderState)
        {
            return opertService.UpdateOrderStateByIds(orderidS, orderState);
        }

        /// <summary>
        /// 根据订单状态为送货中
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        public bool UpdateOrderStateToDelivery(string orderid, string deliveryName, string deliveryTell)
        {
            return opertService.UpdateOrderStateToDelivery(orderid, deliveryName, deliveryTell);
        }

        /// <summary>
        /// 根据条件获取分页数据总条数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderState"></param>
        /// <param name="productname"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetOrderInfoPagCount(string userId, string userName, int orderState,
            string productname, string startTime, string endTime, string groupOrderId, string orderId)
        {
            return opertService.GetOrderInfoPagCount(userId, userName, orderState, productname, startTime, endTime, groupOrderId,  orderId);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public bool UpdateOrderStateByGroupid(string orderGroupId, int orderState)
        {
            return opertService.UpdateOrderStateByGroupid(orderGroupId, orderState);
        }

        /// <summary>
        /// 根据订单状态为送货中
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        public bool UpdateOrderStateToDeliveryByGroupid(string orderGroupId, string deliveryName, string deliveryTell)
        {
            return opertService.UpdateOrderStateToDeliveryByGroupid(orderGroupId, deliveryName, deliveryTell);
        }

        /// <summary>
        /// 分页获取数据集合
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="pagCount"></param>
        /// <param name="userId"></param>
        /// <param name="orderState"></param>
        /// <param name="productname"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<Morder> GetOrderInfoPagList(int pagIndex, int pagCount, string userId, string userName, 
            int orderState, string productname, string startTime, string endTime, string groupOrderId, string orderId)
        {
            return opertService.GetOrderInfoPagList(pagIndex, pagCount, userId,  userName, orderState, productname, startTime, endTime, groupOrderId,  orderId);
        }

        /// <summary>
        /// 根据产品ID获取model
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public Morder GetOrderInfoById(string orderid)
        {
            return opertService.GetOrderInfoById(orderid);
        }

        /// <summary>
        /// 根据订单组Id获取订单列表
        /// </summary>
        /// <param name="orderGroupId"></param>
        /// <returns></returns>
        public List<Morder> GetOrderInfoByGroupId(string orderGroupId)
        {
            return opertService.GetOrderInfoByGroupId(orderGroupId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Mstatic Static()
        {
            return opertService.Static();
        }

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        public MstaticSendOrder SaticSendGoodesCount()
        {
            return opertService.SaticSendGoodesCount();
        }

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        public int SaticSendGoodesTotaCount()
        {
            return opertService.SaticSendGoodesTotaCount();
        }
    }
}
