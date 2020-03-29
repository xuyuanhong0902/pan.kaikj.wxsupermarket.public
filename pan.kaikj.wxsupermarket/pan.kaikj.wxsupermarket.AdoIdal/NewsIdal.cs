/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  NewsIdal
*版本号：  V1.0.0.0
*唯一标识：684d09ce-7a64-4e3c-a222-02c0a6c33966
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/16 21:06:42

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/16 21:06:42
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
    /// NewsIdal
    /// </summary>
    public interface NewsIdal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddNews(Mnews model);

        /// <summary>
        /// 根据id获取新闻信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        Mnews GetNewsById(string id);

        /// <summary>
        /// 根据id更新新闻信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateNews(Mnews model);

        /// <summary>
        /// 分页获取新闻信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        List<Mnews> GetNewsPagList(int pagIndex, int pagCount);

        /// <summary>
        /// 根据ID删除微信才菜单
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
         bool DeleteNews(string id);
    }
}
