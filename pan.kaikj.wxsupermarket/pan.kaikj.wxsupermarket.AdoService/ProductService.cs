/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  ProductService
*版本号：  V1.0.0.0
*唯一标识：ba2167af-4742-4bc4-8145-59d424863022
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/18 22:20:58

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/18 22:20:58
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
    /// ProductService
    /// </summary>
    public class ProductService
    {
        public ProductIdal opertService = new ProductDal();

        /// <summary>
        /// 新增产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddProduct(Mproduct model)
        {
            return opertService.AddProduct(model);
        }

        /// <summary>
        /// 根据ID删除一个产品信息
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public bool DeleteProduct(string productid)
        {
            return opertService.DeleteProduct(productid);
        }

        /// <summary>
        /// 根据商品的上下架状态
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public bool UpdateProductShelfstate(string productid, int shelfstate)
        {
            return opertService.UpdateProductShelfstate(productid, shelfstate);
        }

        /// <summary>
        /// 根据产品的价格、库存信息
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="origprice"></param>
        /// <param name="sellprice"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool UpdateProdctPrice(string productid, decimal origprice, decimal sellprice, int stock,int priority)
        {
            return opertService.UpdateProdctPrice(productid, origprice, sellprice, stock, priority);
        }

        /// <summary>
        /// 根据产品类别，查询对应的产品数量
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int CetProductByClassid(int classid)
        {
            return opertService.CetProductByClassid(classid);
        }

        /// <summary>
        /// 根据产品父类别，查询对应的产品数量
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int CetProductBySupClassid(int supclassid)
        {
            return opertService.CetProductBySupClassid(supclassid);
        }

        /// <summary>
        /// 根据产品ID获取产品model
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public Mproduct GetMproductModelById(string productid)
        {
            return opertService.GetMproductModelById(productid);
        }

        /// <summary>
        /// 获取产品数据总条数
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="supclassid"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public int GetProductPagCount(int classid, int supclassid, string productname, int shelfstate)
        {
            return opertService.GetProductPagCount(classid, supclassid, productname, shelfstate);
        }

        /// <summary>
        /// 获取产品数据总条数
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="supclassid"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public List<Mproduct> GetProductPagList(int pagIndex, int pagCount, int classid, int supclassid, string productname, int shelfstate)
        {
            return opertService.GetProductPagList(pagIndex, pagCount, classid, supclassid, productname, shelfstate);
        }
    }
}
