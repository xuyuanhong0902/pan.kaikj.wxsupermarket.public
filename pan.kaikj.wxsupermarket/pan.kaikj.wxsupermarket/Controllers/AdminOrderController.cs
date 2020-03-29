using pan.kaikj.wxsupermarket.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class AdminOrderController : BaseController
    {
        // GET: AdminOrder
        public ActionResult List()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["AllSendGoodUserList"] = new SndGoodsUserBus().GetAllSndGoodsUserList();

            return View();
        }

        /// <summary>
        /// 获取订单列表数据
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="userName"></param>
        /// <param name="productname"></param>
        /// <param name="orderState"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public string SelectOrderListMeth(int pagIndex, string userName, string productname,
            int orderState, string startDate, string endDate,string groupOrderId,string orderId)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new OrderBus().GetOrderInfoPagList(pagIndex, string.Empty, userName, orderState, productname, startDate, endDate,groupOrderId,orderId);
        }

        /// <summary>
        /// 更新订单已完成
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string UpdateOrderHasRecepitMeth(string orderid) {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            
            return new OrderBus().UpdateOrderHasRecepit(orderid);
        }

        /// <summary>
        /// 更新订单已完成
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string UpdateOrderHasRecepitByIdsMeth(string orderidS)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new OrderBus().UpdateOrderHasRecepitByIds(orderidS);
        }


        /// <summary>
        /// 更新订单已取消
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string UpdateOrderHasCancleByIdsMeth(string orderidS)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new OrderBus().UpdateOrderHasCancleByIds(orderidS);
        }


        /// <summary>
        /// 订单详情
        /// </summary>
        /// <returns></returns>
        public  ActionResult orderDetail(string id)
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["AllSendGoodUserList"] = new SndGoodsUserBus().GetAllSndGoodsUserList();

            return View(new OrderBus().GetOrderInfroById(id));
        }

        /// <summary>
        /// 更新送货信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <param name="deliveryTime"></param>
        /// <returns></returns>
        public string UdateOrderDeliveryInfor(string id,string deliveryName,string deliveryTell,string deliveryTime) {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new OrderBus().UpdateOrderStateToDelivery(id, deliveryName, deliveryTell);
        }

        /// <summary>
        /// 更新送货信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <param name="deliveryTime"></param>
        /// <returns></returns>
        public string UdateOrderDeliveryByIds(string ids, string sendGoodUserId)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new OrderBus().UpdateOrderStateToDelivery(ids, sendGoodUserId);
        }

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        public string SaticSendGoodesTotaCount()
        {
            return new OrderBus().SaticSendGoodesTotaCount().ToString();
        }

        /// <summary>
        /// 获取新订单数据
        /// </summary>
        /// <returns></returns>
        public string GetTotalNewOrder() {

            return new OrderBus().GetTotalNewOrder().ToString();
        }
    }
}