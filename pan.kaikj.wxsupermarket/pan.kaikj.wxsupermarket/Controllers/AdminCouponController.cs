using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class AdminCouponController : BaseController
    {

        // GET: AdminProduct
        public ActionResult List()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

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
        public string SelectListMeth(int pagIndex)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new CouponBus().GetPagList(pagIndex, 20);
        }

        public ActionResult Add()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        /// <summary>
        /// 新增产品分类方法接口
        /// </summary>
        /// <returns></returns>
        public string AddMeth(Mcoupon model)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new CouponBus().Add(model);
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string DeletByIdMeth(string id)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new CouponBus().Delete(id);
        }

        #region 用户优惠券相关

        /// <summary>
        /// 新增产品分类方法接口
        /// </summary>
        /// <returns></returns>
        public string AddUserGroupMeth(Musercoupon model)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new UserCouponBus().Add(model);
        }

        /// <summary>
        /// 使用优惠券
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string UseUserGroupMeth(string id, string orderId)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new UserCouponBus().UseCoupon(id, orderId);
        }

        /// <summary>
        /// 获取用户优惠券列表数据
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="userName"></param>
        /// <param name="productname"></param>
        /// <param name="orderState"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public string SelectUserGroupListMeth(string userId, int isUse, int pagIndex)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new UserCouponBus().GetPagList(userId, isUse, pagIndex, 20);
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string DeletUserGroupByIdMeth(string id)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new UserCouponBus().Delete(id);
        }
        #endregion
    }
}