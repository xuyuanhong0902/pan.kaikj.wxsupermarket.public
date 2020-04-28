using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class marketController : Controller
    {

        public marketController()
        {
               ViewData["platformName"] = WebConfigeOpert.GetPlatformName();
            ViewData["PalteWebSite"] = WebConfigeOpert.GetPalteWebSite();
        }
        /// <summary>
        /// 检查是否登录
        /// </summary>
        /// <returns></returns>
        // GET: Base
        public bool CheckIsLogin()
        {
            if (Session["loginuserId"] == null || string.IsNullOrEmpty(Session["loginuserId"].ToString()))
            {
                return false;
            }

            return true;
        }

        // GET: market
        public ActionResult Index(String code)
        {
            new ProductBus().GetWXUserInfoJesonByCode(code);

            ViewData["AllClass"] = new ProductBus().GetAllSupProductclassList();

            return View();
        }

        /// <summary>
        /// 产品详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult detail(string productId)
        {
            ViewData["ProductDetailInfo"] = new ProductBus().GetProductById(productId);
            return View();
        }



        /// <summary>
        /// 购物车结算页面
        /// </summary>
        /// <returns></returns>
        public ActionResult takeout()
        {
            if (!this.CheckIsLogin())
            {
                return RedirectToAction("userCenter", "market");
            }
            ViewData["AllShoppingCartList"] = new ShoppingCartBus().GetAllShoppingCartListBySserId(Session["loginuserId"] + string.Empty);
            ViewData["AllMmailAddresses"] = new MailAddressBus().GetMmailAddressesByUserId(Session["loginuserId"] + string.Empty);
            return View();
        }


        /// <summary>
        /// 获取产品分页数据
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public string GetProductcListBySupClassId(string pagIndex, string supClassid)
        {
            //if (!this.CheckIsLogin())
            //{
            //    return "-1";
            //}

            int pagIndexI = 0;
            Int32.TryParse(pagIndex, out pagIndexI);

            int supClassidI = 0;
            Int32.TryParse(supClassid, out supClassidI);

            return new ProductBus().GetProductcListBySupClassId(pagIndexI, supClassidI, 1);
        }

        /// <summary>
        /// 加入到购物车
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddShopCart(MshoppingCart model)
        {
            if (!this.CheckIsLogin())
            {
                return "-1";
            }

            model.userId = Session["loginuserId"] + string.Empty;
            model.userName = Session["loginuserName"] + string.Empty;
            return new ShoppingCartBus().AddShopCart(model);
        }

        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddMailAddress(MmailAddress model)
        {
            if (!this.CheckIsLogin())
            {
                return "-1";
            }

            model.userId = Session["loginuserId"] + string.Empty;
            model.userName = Session["loginuserName"] + string.Empty;
            new MailAddressBus().AddMailAddress(model);
            return string.Empty;
        }

        public string UpdateMailAddressDefault(string addressId)
        {
            if (!this.CheckIsLogin())
            {
                return "-1";
            }

            new MailAddressBus().UpdateMailAddressDefault(Session["loginuserId"] + string.Empty, addressId);
            return string.Empty;
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult orderDetail(string groupid, string id)
        {
            if (!this.CheckIsLogin())
            {
                return RedirectToAction("userCenter", "market");
            }

            //// 获取订单详情
            if (!string.IsNullOrEmpty(groupid))
            {
                ViewData["OrderDetile"] = new OrderBus().GetOrderInfoByGroupId(groupid);
            }
            else
            {
                ViewData["OrderDetile"] = new OrderBus().GetOrderInfoById(id);
            }
            return View();
        }

        /// <summary>
        /// 订单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult orderList()
        {
            if (!this.CheckIsLogin())
            {
                return RedirectToAction("userCenter", "market");
            }
            return View();
        }

        /// <summary>
        /// 分页获取订单数据信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="orderstats">订单状态 0:全部 4：待送货 7：派送中 8：完成</param>
        /// <returns></returns>
        public string GetOrderInfoPagList(string pagIndex,int orderState)
        {
            if (!this.CheckIsLogin())
            {
                return "-1";
            }

            int pageIndexI = 1;
            int.TryParse(pagIndex, out pageIndexI);
            LogOpert.AddWeiXinMessage("获取订单列表1：" + Session["loginuserId"]);

            return new OrderBus().GetOrderInfoPagList(pageIndexI, Session["loginuserId"] + string.Empty, string.Empty, orderState > 0 ? orderState : -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="deliveryTime"></param>
        /// <param name="detailedAddress"></param>
        /// <param name="contactName"></param>
        /// <param name="contactTell"></param>
        /// <returns></returns>
        public string AddOrder(string deliveryTime, string detailedAddress, string contactName, string contactTell)
        {
            if (!this.CheckIsLogin())
            {
                return "-1";
            }

            return new OrderBus().AddOrderByShoppingCart(Session["loginuserId"] + string.Empty, deliveryTime, detailedAddress, contactName, contactTell);
        }

        /// <summary>
        /// 确认收货操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ConfirmGoodes(string id, string groupid)
        {
            if (!this.CheckIsLogin())
            {
                return "-1";
            }

            if (!string.IsNullOrEmpty(groupid))
            {
                return new OrderBus().UpdateOrderStateByGroupid(groupid, 8);

            }
            else
            {
                return new OrderBus().UpdateOrderState(id, 8);
            }
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string CancleOrder(string id, string groupid)
        {
            if (!this.CheckIsLogin())
            {
                return "-1";
            }

            if (!string.IsNullOrEmpty(groupid))
            {
                return new OrderBus().UpdateOrderStateByGroupid(groupid, 2);

            }
            else
            {
                return new OrderBus().UpdateOrderState(id, 2);
            }
        }

        /// <summary>
        /// 用户个人中心
        /// </summary>
        /// <returns></returns>
        public ActionResult userCenter(String code)
        {
            //// ViewData["PalteWebSite"] = WebConfigeOpert.GetPalteWebSite();
            //// new ProductBus().GetWXUserInfoJesonByCode(code);
            return View();
        }

        /// <summary>
        /// 创建测试账号
        /// </summary>
        /// <returns></returns>
        public ActionResult creatTest()
        {
            Session["loginuserId"] = "111111";
            Session["loginuserName"] = "ces";
            return View();
        }

        public ActionResult viewNew(string id)
        {
            return View(new NewsBus().GetNewsById(id));
        }
    }
}