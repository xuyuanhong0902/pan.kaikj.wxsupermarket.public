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
    public class AdminIndexController : BaseController
    {
        // GET: AdminIndex
        public ActionResult Index()
        {
            if (!base.CheckIsLogin())
            {
               return  RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}