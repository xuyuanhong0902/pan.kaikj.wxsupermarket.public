using pan.kaikj.wxsupermarket.bus;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// 产品首页
        /// </summary>
        /// <param name="code">微信的code</param>
        /// <param name="from">标志用户来源 如果微信公众号点击过来值为wx</param>
        /// <returns></returns>
        // GET: Product
        public ActionResult Index(String code,string from)
        {
            LogOpert.AddWeiXinMessage("开始进入到产品页面：code值为："+code);

            ///// 获取用户信息
            ViewBag.Message = new ProductBus().GetWXUserInfoJesonByCode(code);
            LogOpert.AddWeiXinMessage("渲染产品页面：处理后的用户信息为：" + ViewBag.Message);
            return View();
        }
    }
}