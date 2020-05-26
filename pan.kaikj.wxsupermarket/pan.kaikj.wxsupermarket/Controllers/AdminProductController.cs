using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class AdminProductController : BaseController
    {
        #region 产品类别

        // GET: AdminProduct
        public ActionResult ProductclassList()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
           
            return View();
        }

        public ActionResult AddProductclass()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["AllPersonClass"] = new ProductBus().GetProductclassesBySupclassid(0);
            return View();
        }

        /// <summary>
        /// 新增产品分类方法接口
        /// </summary>
        /// <returns></returns>
        public string AddProductclassMeth(Mproductclass model)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            HttpPostedFileBase productimgurl = Request.Files["productimgurl"];
            return new ProductBus().AddProductclasses(model, productimgurl, Server.MapPath("/"));
        }

        /// <summary>
        /// 获取所有类别数据
        /// </summary>
        /// <returns></returns>
        public string GetAllProductclassList()
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return JsonHelper.GetJson<List<Mproductclass>>(new ProductBus().GetProductclassesBySupclassid(-1));
        }

        /// <summary>
        /// 根据id删除商品类
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string DeletProductclassesByIdMeth(int classid, int supclassid)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new ProductBus().DeletProductclassesByIdMeth(classid, supclassid);
        }

        /// <summary>
        /// 产品类别编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EditProductclass(string classid)
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            int id = 0;
            int.TryParse(classid, out id);

            ViewData["AllPersonClass"] = new ProductBus().GetProductclassesBySupclassid(0);
            Mproductclass model = new ProductBus().GetMproductclassById(id);
            if (model == null)
            {
                model = new Mproductclass();
            }
            return View(model);
        }

        /// <summary>
        /// 编辑产品分类方法接口
        /// </summary>
        /// <returns></returns>
        public string EditProductclassMeth(Mproductclass model)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            HttpPostedFileBase productimgurl = Request.Files["productimgurl"];
            return new ProductBus().EditProductclass(model, productimgurl, Server.MapPath("/"));
        }

        #endregion

        #region 产品

        /// <summary>
        /// 新产品
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProduct(string productid)
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["AllClass"] = new ProductBus().GetProductclassesBySupclassid(-1);
            if (!string.IsNullOrEmpty(productid))
            {
                ViewData["ProductModel"] = new ProductBus().GetProductById(productid);
            }
            else
            {
                ViewData["ProductModel"] = null;
            }

            return View();
        }

        /// <summary>
        /// 产品列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductcList()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            ViewData["AllPersonClass"]= new ProductBus().GetProductclassesBySupclassid(0);
            return View();
        }

        /// <summary>
        /// 新产品
        /// </summary>
        /// <returns></returns>
        public string AddProductMeth(Mproduct mproduct)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            HttpPostedFileBase productimgurl = Request.Files["productimgurl"];

            if (string.IsNullOrEmpty(mproduct.productid))
            {
                return new ProductBus().AddProduct(mproduct, productimgurl, Server.MapPath("/"));
            }
            else
            {
                //// 编辑
                return new ProductBus().EditeProduct(mproduct, productimgurl, Server.MapPath("/"));
            }
           
        }

        /// <summary>
        /// 产品列表获取方法
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="productname"></param>
        /// <returns></returns>
        public string GetProductcListMeth(string pagIndex, string productname, string shelfstate,string recommend, string type)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            int pagIndexI = 0;
            Int32.TryParse(pagIndex, out pagIndexI);

            int shelfstateI = 0;
            Int32.TryParse(shelfstate, out shelfstateI);

            int recommendI = -1;
            Int32.TryParse(recommend, out recommendI);

            int typeI = 0;
            Int32.TryParse(type, out typeI);

            return new ProductBus().GetProductcList(pagIndexI, productname, shelfstateI, recommendI,-1, typeI);
        }

        /// <summary>
        /// 根据id删除产品
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public string DeletProductByIdMeth(string productid)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new ProductBus().DeletProductById(productid);
        }

        /// <summary>
        /// 根据ID更新其上下架状态
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public string UpdateProductShelfstateByIdMeth(string productid)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new ProductBus().UpdateProductShelfstateById(productid);
        }

        /// <summary>
        /// 更新商品的是否推荐
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="recommend"></param>
        /// <returns></returns>
        public string UpdateProductRecommend(string productid, int recommend)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new ProductBus().UpdateProductRecommend(productid,recommend);
        }


        #endregion
    }
}