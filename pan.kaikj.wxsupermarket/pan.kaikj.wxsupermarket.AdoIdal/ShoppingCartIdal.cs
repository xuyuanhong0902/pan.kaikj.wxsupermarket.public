/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  ShoppingCartIdal
*版本号：  V1.0.0.0
*唯一标识：91dcaa17-1e81-4601-b830-4b7337627155
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 21:16:42

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 21:16:42
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoIdal
{
    /// <summary>
    /// ShoppingCartIdal
    /// </summary>
    public interface ShoppingCartIdal
    {
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(MshoppingCart model);

        /// <summary>
        /// 更新购物车产品的价格等相关信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <param name="origPrice"></param>
        /// <param name="sellPrice"></param>
        /// <param name="totalPrice"></param>
        /// <param name="buyNum"></param>
        /// <returns></returns>
        bool UpdatePriceAndNum(string shoppingCartId, string userId, decimal origPrice, decimal sellPrice, decimal totalPrice, int buyNum);

        /// <summary>
        /// 根据id删除购物车信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        bool DeleteShoppingCartById(string shoppingCartId, string userId);

        /// <summary>
        /// 根据id删除购物车信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        bool DeleteShoppingCartById(string[] shoppingCartId, string userId);

        /// <summary>
        /// 根据用户ID获取其全部购物车产品
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<MshoppingCart> GetAllShoppingCartListBySserId(string userId);

        /// <summary>
        /// 根据用户ID和产品id获取其对应的购买产品的购物车信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        MshoppingCart GetShoppingCartListByUserIdAndProductId(string userId, string productId);
    }
}
