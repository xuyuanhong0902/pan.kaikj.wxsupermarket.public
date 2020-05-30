/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  OrderIdal
*版本号：  V1.0.0.0
*唯一标识：bd82a8a3-0de9-4bb2-b4e0-a916f0c6fbaa
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 19:34:03

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 19:34:03
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
    /// OrderIdal
    /// </summary>
    public interface CouponIdal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(Mcoupon model);

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Mcoupon GetById(string id);

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        int GetPagCount();

        /// <summary>
        /// 分页获取新闻信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        List<Mcoupon> GetNewsPagList(int pagIndex, int pagCount);

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        bool Delete(string id);
    }
}
