using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 检查是否登录
        /// </summary>
        /// <returns></returns>
        // GET: Base
        public bool CheckIsLogin()
        {
            if (Session["acount"] ==null||string.IsNullOrEmpty(Session["acount"].ToString()))
            {
                return false;
            }

            ViewData["platformName"] = WebConfigeOpert.GetPlatformName() ;
            return true;
        }
    }
}