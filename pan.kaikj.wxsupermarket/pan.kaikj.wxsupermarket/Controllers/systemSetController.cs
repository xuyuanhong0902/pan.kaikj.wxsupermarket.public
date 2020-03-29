using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class systemSetController : BaseController
    {
        // GET: systemSet
        public ActionResult wxmenuList()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["AllMenu"] = new WxmenuBus().GetAllMenu();
            return View();
        }

        // GET: systemSet
        public ActionResult wxmenuAdd()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["AllMainMenu"] = new WxmenuBus().GetAllMainMenu();
            return View();
        }

        public string AddWxmenuMeth(Mwxmenu model)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new WxmenuBus().AddWxmenu(model);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DelectMenuMeth(string id)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new WxmenuBus().DelectMenu(id);
        }

        /// <summary>
        /// 发布菜单到微信公众号
        /// </summary>
        /// <returns></returns>
        public string FabuMenuToWX()
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new WxmenuBus().FabuMenuToWX();
        }
    }
}