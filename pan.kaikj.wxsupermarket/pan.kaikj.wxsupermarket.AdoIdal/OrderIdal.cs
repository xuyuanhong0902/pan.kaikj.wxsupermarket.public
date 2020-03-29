/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  OrderIdal
*版本号：  V1.0.0.0
*唯一标识：bd82a8a3-0de9-4bb2-b4e0-a916f0c6fbaa
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 19:34:03

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 19:34:03
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoIdal
{
    /// <summary>
    /// OrderIdal
    /// </summary>
    public interface OrderIdal
    {
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddOrder(List<Morder> model);

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        bool UpdateOrderState(string orderid, int orderState);

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        bool UpdateOrderStateByIds(string orderidS, int orderState);

        /// <summary>
        /// 根据订单状态为送货中
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        bool UpdateOrderStateToDelivery(string orderid, string deliveryName, string deliveryTell);

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        bool UpdateOrderStateByGroupid(string orderGroupId, int orderState);

        /// <summary>
        /// 根据订单状态为送货中
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        bool UpdateOrderStateToDeliveryByGroupid(string orderGroupId, string deliveryName, string deliveryTell);

        /// <summary>
        /// 根据条件获取分页数据总条数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderState"></param>
        /// <param name="productname"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        int GetOrderInfoPagCount(string userId, string userName, int orderState, string productname, string startTime, string endTime, string groupOrderId, string orderId);

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
        List<Morder> GetOrderInfoPagList(int pagIndex, int pagCount, string userId, string userName, int orderState,
            string productname, string startTime, string endTime, string groupOrderId, string orderId);

        /// <summary>
        /// 根据产品ID获取model
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        Morder GetOrderInfoById(string orderid);

        /// <summary>
        /// 根据订单组Id获取订单列表
        /// </summary>
        /// <param name="orderGroupId"></param>
        /// <returns></returns>
        List<Morder> GetOrderInfoByGroupId(string orderGroupId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Mstatic Static();

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        MstaticSendOrder SaticSendGoodesCount();

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        int SaticSendGoodesTotaCount();
    }
}
