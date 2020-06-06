/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  ProductBus
*版本号：  V1.0.0.0
*唯一标识：d10352dc-b0fa-4536-b45d-c1da58d56ce2
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 19:56:13

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 19:56:13
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// ProductBus
    /// </summary>
    public class ProductBus : BusinessBase
    {
        #region  产品类别相关

        /// <summary>
        /// 根据code获取用户信息jeson对象
        /// </summary>
        /// <param name="code"></param>
        public string GetWXUserInfoJesonByCode(string code)
        {
            LogOpert.AddWeiXinMessage("微信用户信息：" + code);
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    MWXUserInfo userMdel = this.GetWXUserInfoByCode(code);
                    if (userMdel != null)
                    {
                        return JsonHelper.GetJson<MWXUserInfo>(userMdel);
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                LogOpert.AddWeiXinMessage("用户信息获取处理异常：" + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据父级类别ID获取所哟类别
        /// </summary>
        /// <param name="supclassid"></param>
        /// <returns></returns>
        public List<Mproductclass> GetProductclassesBySupclassid(int supclassid)
        {
            try
            {
                List<Mproductclass> modelList = new ProductclassService().GetMproductclasses(supclassid);

                if (modelList != null && modelList.Exists(p => p.supclassid != 0))
                {
                    //// 数据产品分类按照上下关系排列
                    List<Mproductclass> supList = modelList.FindAll(p => p.supclassid == 0);

                    if (supList != null)
                    {
                        List<Mproductclass> result = new List<Mproductclass>();
                        foreach (var item in supList)
                        {
                            result.Add(item);
                            if (modelList.Exists(p => p.supclassid == item.classid))
                            {
                                result.AddRange(modelList.FindAll(p => p.supclassid == item.classid));
                            }
                        }

                        return result;
                    }
                }

                return modelList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据父级类别ID获取所哟类别
        /// </summary>
        /// <param name="supclassid"></param>
        /// <returns></returns>
        public List<Mproductclass> GetAllSupProductclassList(int supId=0)
        {
            try
            {
                List<Mproductclass> modelList = new ProductclassService().GetMproductclasses(supId);
                return modelList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        

        /// <summary>
        /// 新增产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddProductclasses(Mproductclass model, HttpPostedFileBase productimgurl, string path)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                //// 数据合法性检查
                if (model == null || string.IsNullOrEmpty(model.classname))
                {
                    mwxResult.errmsg = "操作失败，新增数据不能为空！";
                }

                if (productimgurl == null)
                {
                    mwxResult.errmsg = "图片不能为空！";
                    return JsonHelper.GetJson<MwxResult>(mwxResult);
                }
                
                string savePath = string.Empty;

                //// 存图片
                string fileSave = FileOpert.UploadImg(productimgurl, path + "uploadFile\\" + System.DateTime.Now.ToString("yyyy") + "\\", out savePath);
                if (string.IsNullOrEmpty(fileSave))
                {
                    model.imgpath = savePath.Replace(path, "");
                }
                else
                {
                    //// 构建错误信息并返回
                    mwxResult.errmsg = fileSave;
                    return JsonHelper.GetJson<MwxResult>(mwxResult);
                }

                //// 时间相关参数赋值
                model.great_time = System.DateTime.Now;
                model.modify_time = model.great_time;
                model.isDelete = 0;
                model.isEffective = 1;

                //// 数据落地入库
                if (!new ProductclassService().AddProductclass(model))
                {
                    mwxResult.errmsg = "操作失败";
                }
                else
                {
                    mwxResult.errcode = 0;
                    mwxResult.errmsg = "操作成功";
                    CacheData.allProductClass = null;
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 根据id删除商品类
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string DeletProductclassesByIdMeth(int classid, int supclassid)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (classid < 0 || supclassid < 0)
                {
                    mwxResult.errmsg = "操作失败：ID不能为空！";
                }
                else
                {
                    if (!new ProductclassService().DeleteProductclass(classid, supclassid))
                    {
                        mwxResult.errmsg = "操作失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功";
                        CacheData.allProductClass = null;
                    }
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 根据产品类别ID获取详情信息
        /// </summary>
        /// <returns></returns>
        public Mproductclass GetMproductclassById(int classid)
        {
            try
            {
                return new ProductclassService().GetMproductclassByClassid(classid);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 编辑产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string EditProductclass(Mproductclass model, HttpPostedFileBase productimgurl, string path)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                //// 数据合法性检查
                if (model == null || model.classid < 1 || string.IsNullOrEmpty(model.classname))
                {
                    mwxResult.errmsg = "操作失败，新增数据不能为空！";
                }

                if (productimgurl != null)
                {
                    string savePath = string.Empty;
                    string fileSave = FileOpert.UploadImg(productimgurl, path + "uploadFile\\" + System.DateTime.Now.ToString("yyyy") + "\\", out savePath);
                    if (string.IsNullOrEmpty(fileSave))
                    {
                        model.imgpath = savePath.Replace(path, "");
                    }
                }

                //// 数据落地入库
                if (!new ProductclassService().EditProductclass(model))
                {
                    mwxResult.errmsg = "操作失败";
                }
                else
                {
                    mwxResult.errcode = 0;
                    mwxResult.errmsg = "操作成功";
                    CacheData.allProductClass = null;
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        #endregion

        #region 产品相关

        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="mproduct"></param>
        /// <param name="productimgurl"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string AddProduct(Mproduct mproduct, HttpPostedFileBase productimgurl, string path)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            //// 实现步骤
            //// 1.数据合法性验证
            //// 2.图片入库
            //// 3.数据落地
            string savePath = string.Empty;
            mwxResult.errmsg = this.CheckedProduct(mproduct);

            if (productimgurl == null)
            {
                mwxResult.errmsg = "产品图片不能为空！";
                return JsonHelper.GetJson<MwxResult>(mwxResult);
            }

            if (!string.IsNullOrEmpty(mwxResult.errmsg))
            {
                return JsonHelper.GetJson<MwxResult>(mwxResult);
            }

            //// 存图片
            string fileSave = FileOpert.UploadImg(productimgurl, path + "uploadFile\\" + System.DateTime.Now.ToString("yyyy") + "\\", out savePath);
            if (string.IsNullOrEmpty(fileSave))
            {
                mproduct.productimgurl = savePath.Replace(path, "");
            }
            else
            {
                //// 构建错误信息并返回
                mwxResult.errmsg = fileSave;
                return JsonHelper.GetJson<MwxResult>(mwxResult);
            }

            mproduct.productid = PublicTools.GetRandomNumberByTime();
            ///// 入库
            bool addResult = new ProductService().AddProduct(mproduct);

            if (addResult)
            {
                mwxResult.errmsg = "新增成功！";
                mwxResult.errcode = 0;
                CacheData.allRecommendPro = null;
            }
            else
            {
                mwxResult.errmsg = "新增失败！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 编辑产品
        /// </summary>
        /// <param name="mproduct"></param>
        /// <param name="productimgurl"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string EditeProduct(Mproduct mproduct, HttpPostedFileBase productimgurl, string path)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            if (productimgurl!= null)
            {
                string savePath = string.Empty;
                string fileSave = FileOpert.UploadImg(productimgurl, path + "uploadFile\\" + System.DateTime.Now.ToString("yyyy") + "\\", out savePath);
                if (string.IsNullOrEmpty(fileSave))
                {
                    mproduct.productimgurl = savePath.Replace(path, "");
                }
            }

            bool addResult = new ProductService().UpdateProdctPrice(mproduct.productid, 
                (decimal)mproduct.origprice, (decimal)mproduct.sellprice, (int)mproduct.stock, (int)mproduct.priority, mproduct);

            if (addResult)
            {
                mwxResult.errmsg = "保存成功！";
                mwxResult.errcode = 0;
                CacheData.allRecommendPro = null;

            }
            else
            {
                mwxResult.errmsg = "保存失败！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 检查产品信息的有效性
        /// </summary>
        /// <param name="mproduct"></param>
        /// <returns></returns>
        private string CheckedProduct(Mproduct mproduct)
        {
            if (mproduct == null)
            {
                return "产品参数有误！";
            }

            if (string.IsNullOrEmpty(mproduct.productname))
            {
                return "产品名称不能为空！";
            }

            if (mproduct.classid < 1)
            {
                return "产品类别必须选择！";
            }

            return null;
        }

        /// <summary>
        /// 获取产品分页数据
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
       public string GetProductcList(int pagIndex,  string productname,int shelfstate, int recommend,int type,int superClassid=-1) {
            try
            {
                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<Mproduct> pageListResult = new MPageListResult<Mproduct>();

                //// 每页获取20条数据
                int pagSize = 20;

                //// 1、首先获取符号要求的数据总条数
                ProductService productService = new ProductService();
                type = type > 0 ? type : -1;
                pageListResult.totalNum = productService.GetProductPagCount(type, superClassid, productname, shelfstate, recommend);
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    pagIndex = pagIndex > pageListResult.totalPage ? pageListResult.totalPage : pagIndex;

                    //// 3、获取具体的分页数据信息
                    pageListResult.dataList = productService.GetProductPagList(pagIndex, pagSize, -1, superClassid, productname, shelfstate, recommend);
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;

                return JsonHelper.GetJson<MPageListResult<Mproduct>>(pageListResult);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取产品分页数据
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public string GetProductcListBySupClassId(int pagIndex, int supClassid,
            int shelfstate,int recommend,string keyValues, int classid=-1)
        {
            try
            {
                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<Mproduct> pageListResult = new MPageListResult<Mproduct>();

                //// 每页获取20条数据
                int pagSize = 1000;

                //// 1、首先获取符号要求的数据总条数
                ProductService productService = new ProductService();
                pageListResult.totalNum = productService.GetProductPagCount(classid, supClassid, keyValues, shelfstate, recommend);
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    if (pagIndex <= pageListResult.totalPage )
                    {
                        //// 3、获取具体的分页数据信息
                        pageListResult.dataList = productService.GetProductPagList(pagIndex, pagSize, classid, supClassid, keyValues, shelfstate, recommend);
                    }
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;

                return JsonHelper.GetJson<MPageListResult<Mproduct>>(pageListResult);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 获取产品分页数据
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public List<Mproduct> GetAllProductcListBySupClassId(int maxNum,int supClassid,
            int shelfstate, int recommend, string keyValues, int classid = -1)
        {
            try
            {
               List<Mproduct> listPro = new ProductService().GetProductPagList(1, maxNum, classid, supClassid, keyValues, shelfstate, recommend);

                return listPro;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据id删除商品类
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string DeletProductById(string productid)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(productid))
                {
                    mwxResult.errmsg = "操作失败：ID不能为空！";
                }
                else
                {
                    if (!new ProductService().DeleteProduct(productid))
                    {
                        mwxResult.errmsg = "操作失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功";
                        CacheData.allRecommendPro = null;

                    }
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 根据ID更新其上下架状态
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public string UpdateProductShelfstateById(string productid)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(productid))
                {
                    mwxResult.errmsg = "操作失败：ID不能为空！";
                }
                else
                {
                    if (!new ProductService().UpdateProductShelfstate(productid, 9999))
                    {
                        mwxResult.errmsg = "操作失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功";
                        CacheData.allRecommendPro = null;

                    }
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }


        /// <summary>
        /// 更新商品的是否推荐
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="recommend"></param>
        /// <returns></returns>
        public string UpdateProductRecommend(string productid, int recommend)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(productid))
                {
                    mwxResult.errmsg = "操作失败：ID不能为空！";
                }
                else
                {
                    if (!new ProductService().UpdateProductRecommend(productid, recommend))
                    {
                        mwxResult.errmsg = "操作失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功";
                        CacheData.allRecommendPro = null;
                    }
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 根据产品ID获取产品信息
        /// </summary>
        /// <param name="supclassid"></param>
        /// <returns></returns>
        public Mproduct GetProductById(string productid)
        {
            try
            {
                Mproduct model= new ProductService().GetMproductModelById(productid);

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户ID获取所有推荐商品，并根据其购物车组装对应的购买信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetRecommentProductListAndCarInfor(string userid)
        {
            MPageListResult<Mproduct> pageListResult = new MPageListResult<Mproduct>();
            // 所有推荐商品
            if (CacheData.allRecommendProList != null && 
                CacheData.allRecommendProList.Count > 0)
            {
                pageListResult.dataList =
                JsonHelper.ParseFormJson<List<Mproduct>>(
                JsonHelper.GetJson<List<Mproduct>>(CacheData.allRecommendProList));


                List<MshoppingCart> listShoppingCart = null;

                if (!string.IsNullOrEmpty(userid))
                {
                    // 获取用户的所有购物车详情
                    listShoppingCart = new ShoppingCartBus().GetAllShoppingCartListBySserId(userid);
                }

                // 
                MshoppingCart thisMshoppingCart = null;
                if (pageListResult.dataList != null && pageListResult.dataList.Count > 0)
                {
                    foreach (var item in pageListResult.dataList)
                    {
                        thisMshoppingCart = listShoppingCart == null ? null : listShoppingCart.Find(x => x.productId == item.productid);
                        if (thisMshoppingCart == null || string.IsNullOrEmpty(thisMshoppingCart.productId))
                        {
                            item.hassellnum = 0;
                        }
                        else
                        {
                            item.hassellnum = thisMshoppingCart.buyNum;
                        }
                    }
                }
            }

            return JsonHelper.GetJson<MPageListResult<Mproduct>>(pageListResult);
        }

        #endregion
    }
}
