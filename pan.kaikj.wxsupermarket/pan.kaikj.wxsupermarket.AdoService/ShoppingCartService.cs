/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  ShoppingCartService
*版本号：  V1.0.0.0
*唯一标识：d6f9f0a8-377d-4c1a-a858-258d5679353a
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 21:17:03

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 21:17:03
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoDal;
using pan.kaikj.wxsupermarket.AdoIdal;
using pan.kaikj.wxsupermarket.AdoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoService
{
    /// <summary>
    /// ShoppingCartService
    /// </summary>
    public class ShoppingCartService
    {
        public ShoppingCartIdal opertService = new ShoppingCartDal();

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(MshoppingCart model)
        {
            return opertService.Add(model);
        }

        /// <summary>
        /// 更新购物车产品的价格等相关信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <param name="origPrice"></param>
        /// <param name="sellPrice"></param>
        /// <param name="totalPrice"></param>
        /// <param name="buyNum"></param>
        /// <returns></returns>
        public bool UpdatePriceAndNum(string shoppingCartId, string userId, decimal origPrice, decimal sellPrice, decimal totalPrice, int buyNum)
        {
            return opertService.UpdatePriceAndNum(shoppingCartId, userId, origPrice, sellPrice, totalPrice, buyNum);
        }

        /// <summary>
        /// 根据id删除购物车信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        public bool DeleteShoppingCartById(string shoppingCartId, string userId)
        {
            return opertService.DeleteShoppingCartById(shoppingCartId, userId);
        }

        /// <summary>
        /// 根据id删除购物车信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        public bool DeleteShoppingCartById(string[] shoppingCartId, string userId)
        {
            return opertService.DeleteShoppingCartById(shoppingCartId, userId);
        }

        /// <summary>
        /// 根据用户ID获取其全部购物车产品
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MshoppingCart> GetAllShoppingCartListBySserId(string userId)
        {
            return opertService.GetAllShoppingCartListBySserId(userId);
        }

        /// <summary>
        /// 根据用户ID和产品id获取其对应的购买产品的购物车信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MshoppingCart GetShoppingCartListByUserIdAndProductId(string userId, string productId)
        {
            return opertService.GetShoppingCartListByUserIdAndProductId(userId, productId);
        }
    }
}
