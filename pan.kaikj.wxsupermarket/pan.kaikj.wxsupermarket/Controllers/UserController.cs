using pan.kaikj.wxsupermarket.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// 用户列表（微信用户）
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        /// <summary>
        /// 分页获取用户数据信息列表
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SelectUserListMeth(string pagIndex, string nickname, string subscribe)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            int pagIndexI = 0;
            Int32.TryParse(pagIndex, out pagIndexI);
            return new UserBus().GetUserListPage(pagIndexI, nickname, subscribe);
        }

        /// <summary>
        /// 微信用户详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Userdetail(string id)
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            return View(new UserBus().GetWXUserInfoByOpenid(id));
        }
        
    }
}