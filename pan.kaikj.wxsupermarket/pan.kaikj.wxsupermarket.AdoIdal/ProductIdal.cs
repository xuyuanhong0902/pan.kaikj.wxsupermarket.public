/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  ProductIdal
*版本号：  V1.0.0.0
*唯一标识：697da322-581f-4b3c-a55d-ae501b6e926e
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/18 22:18:47

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/18 22:18:47
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
    /// ProductIdal
    /// </summary>
    public interface ProductIdal
    {
        /// <summary>
        /// 新增产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddProduct(Mproduct model);

        /// <summary>
        /// 根据ID删除一个产品信息
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        bool DeleteProduct(string productid);

        /// <summary>
        /// 根据商品的上下架状态
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        bool UpdateProductShelfstate(string productid, int shelfstate);

        /// <summary>
        /// 根据产品的价格、库存信息
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="origprice"></param>
        /// <param name="sellprice"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        bool UpdateProdctPrice(string productid, decimal origprice, decimal sellprice, int stock, int priority);

        /// <summary>
        /// 根据产品类别，查询对应的产品数量
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        int CetProductByClassid(int classid);

        /// <summary>
        /// 根据产品父类别，查询对应的产品数量
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        int CetProductBySupClassid(int supclassid);

        /// <summary>
        /// 根据产品ID获取产品model
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        Mproduct GetMproductModelById(string productid);

        /// <summary>
        /// 获取产品数据总条数
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="supclassid"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        int GetProductPagCount(int classid, int supclassid, string productname, int shelfstate);

        /// <summary>
        /// 获取产品数据总条数
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="supclassid"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        List<Mproduct> GetProductPagList(int pagIndex, int pagCount, int classid, int supclassid, string productname, int shelfstate);
    }
}
