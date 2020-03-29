/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  NewsService
*版本号：  V1.0.0.0
*唯一标识：232aeff8-fe56-4930-b3b8-70aea5434410
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/16 21:08:44

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/16 21:08:44
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
    /// NewsService
    /// </summary>
    public class NewsService
    {
        public NewsIdal opertService = new NewsDal();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNews(Mnews model)
        {
            return opertService.AddNews(model);
        }

        /// <summary>
        /// 根据id获取新闻信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public Mnews GetNewsById(string id)
        {
            return opertService.GetNewsById(id);
        }

        /// <summary>
        /// 根据id更新新闻信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateNews(Mnews model)
        {
            return opertService.UpdateNews(model);
        }

        /// <summary>
        /// 分页获取新闻信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<Mnews> GetNewsPagList(int pagIndex, int pagCount)
        {
            return opertService.GetNewsPagList(pagIndex, pagCount);
        }

        /// <summary>
        /// 根据ID删除微信才菜单
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public bool DeleteNews(string id)
        {
            return opertService.DeleteNews(id);
        }
    }
}
