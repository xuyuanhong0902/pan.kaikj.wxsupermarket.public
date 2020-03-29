using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class newsController : BaseController
    {
        // GET: news
        public ActionResult newsList()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["AllNews"] = new NewsBus().GetAllNews();
            return View();
        }

        public ActionResult newsAdd(string id)
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
         
            return View(new NewsBus().GetNewsById(id));
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public string AddNewsMeth(Mnews model) {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new NewsBus().AddNews(model);
        }

        public string DelectNewsMeth(string id ) {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new NewsBus().DelectNews(id);
        }
    }
}