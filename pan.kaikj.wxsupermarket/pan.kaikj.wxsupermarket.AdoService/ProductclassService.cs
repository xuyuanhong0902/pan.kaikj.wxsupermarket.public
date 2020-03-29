/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  ProductclassService
*版本号：  V1.0.0.0
*唯一标识：1f8fbf56-3938-49dc-9e35-9e8122bbeb87
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/16 21:35:51

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/16 21:35:51
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
    /// ProductclassService
    /// </summary>
    public class ProductclassService
    {
        public ProductclassDal opertService = new ProductclassDal();

        /// <summary>
        /// 新增产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddProductclass(Mproductclass model)
        {
            return opertService.AddProductclass(model);
        }

        /// <summary>
        /// 编辑产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditProductclass(Mproductclass model)
        {
            return opertService.EditProductclass(model);
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public bool DeleteProductclass(int classid, int supclassid)
        {
            return opertService.DeleteProductclass(classid, supclassid);
        }

        /// <summary>
        /// 直接获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<Mproductclass> GetMproductclasses(int supclassid)
        {
            return opertService.GetMproductclasses(supclassid);
        }

        /// <summary>
        /// 根据类别ID获取model
        /// </summary>
        /// <param name="classid">classid</param>
        /// <returns></returns>
        public Mproductclass GetMproductclassByClassid(int classid) {
            return opertService.GetMproductclassByClassid(classid);
        }
    }
}
