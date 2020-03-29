using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class SndGoodsUserController : BaseController
    {
        // GET: SndGoodsUser
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 新增产品分类方法接口
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                MsendGoodsUser model = new SndGoodsUserBus().GetSendGoodsUserModelById(id);
                if (model!=null)
                {
                    ViewData["userName"]= model.userName;
                    ViewData["id"] = model.id;
                    ViewData["phone"] = model.phone;
                    ViewData["sex"] = model.sex;
                }
            }
           
            return View();
        }

        public string AddSndGoodsUserMeth(MsendGoodsUser model)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new SndGoodsUserBus().AddUserMeth(model);
        }

        /// <summary>
        /// 产品列表获取方法
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="productname"></param>
        /// <returns></returns> 
        public string GetSndGoodsUserListMeth(string pagIndex, string userNam, string phone)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            int pagIndexI = 0;
            Int32.TryParse(pagIndex, out pagIndexI);

            return new SndGoodsUserBus().GetSndGoodsUserListPage(pagIndexI, phone, userNam);
        }

        /// <summary>
        /// 根据id删除商品类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletSndGoodsUserByIdMeth(string id)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new SndGoodsUserBus().DeletUserByIdMeth(id);
        }
    }
}