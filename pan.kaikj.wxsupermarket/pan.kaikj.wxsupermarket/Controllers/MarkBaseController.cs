using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class MarkBaseController : Controller
    {
        public MarkBaseController()
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
    }
}