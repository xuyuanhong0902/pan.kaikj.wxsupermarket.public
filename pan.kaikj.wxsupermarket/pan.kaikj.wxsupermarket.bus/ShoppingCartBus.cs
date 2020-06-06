/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  ShoppingCartBus
*版本号：  V1.0.0.0
*唯一标识：ed3d210f-9c7b-41e6-a481-460cdcad6022
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/11/14 20:57:36

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/11/14 20:57:36
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

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// ShoppingCartBus
    /// </summary>
    public class ShoppingCartBus
    {
        /// <summary>
        /// 加入到购物车
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddShopCart(MshoppingCart model)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {

            bool addResult = true;

            ShoppingCartService opert = new ShoppingCartService();
            //// 补全产品信息
            Mproduct product = new ProductBus().GetProductById(model.productId);
            if (product == null || string.IsNullOrEmpty(product.productid))
            {
                addResult = false;
            }
            else
            {
                string productformatunit = product.productformatunit == "0" ? "个" :
                  product.productformatunit == "1" ? "袋" :
                  product.productformatunit == "2" ? "斤" :
                  product.productformatunit == "3" ? "瓶" :
                  product.productformatunit == "4" ? "升" :
                  product.productformatunit == "5" ? "听" :
                  product.productformatunit == "4" ? "升" :
                  product.productformatunit == "6" ? "件" :
                  product.productformatunit == "7" ? "盒" :
                  product.productformatunit == "8" ? "包" :
                  product.productformatunit == "9" ? "提" : "双";
                model.origPrice = product.origprice;
                model.productformat = $"{product.productformat}/{productformatunit}";
                model.productname = product.productname;
                model.sellPrice = product.sellprice;

                //// 首先根据产id和用户 ID获取一次购物车信息
                MshoppingCart shopCartModel = opert.GetShoppingCartListByUserIdAndProductId(model.userId, model.productId);

                if (model.buyNum > 0)
                {
                    ///// 加购物车
                    if (shopCartModel != null && !string.IsNullOrEmpty(shopCartModel.shoppingCartId))
                    {
                        /////  数量加1
                        addResult = opert.UpdatePriceAndNum(shopCartModel.shoppingCartId, model.userId,
                            model.origPrice, model.sellPrice, model.totalPrice + (model.sellPrice * model.buyNum), model.buyNum);
                    }
                    else
                    {
                        //// 新增
                        model.shoppingCartId = PublicTools.GetRandomNumberByTime();
                        addResult = opert.Add(model);
                    }
                }
                else
                {
                    //// 减购物车 
                    if (shopCartModel != null && !string.IsNullOrEmpty(shopCartModel.shoppingCartId))
                    {
                        if (shopCartModel.buyNum <= (-model.buyNum))
                        {
                            //// 直接删除
                            addResult = opert.DeleteShoppingCartById(shopCartModel.shoppingCartId, shopCartModel.userId);
                        }
                        else
                        {
                            /////  数量减1
                            addResult = opert.UpdatePriceAndNum(shopCartModel.shoppingCartId, model.userId,
                                model.origPrice, model.sellPrice, model.totalPrice + shopCartModel.totalPrice, model.buyNum);
                        }
                    }
                }
            }
           

            if (addResult)
            {
                mwxResult.errmsg = "操作成功！";
                mwxResult.errcode = 0;
            }
            else
            {
                mwxResult.errmsg = "操作失败！";
            }

           
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败！";
                LogOpert.AddWeiXinMessage("系统异常：" + ex.Message);
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 跟用户ID获取其全部购物车信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MshoppingCart> GetAllShoppingCartListBySserId(string userId) {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return null;
                }
                else
                {
                    return new ShoppingCartService().GetAllShoppingCartListBySserId(userId);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
