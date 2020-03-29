/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  WxmenuIdal
*版本号：  V1.0.0.0
*唯一标识：954e230f-cde1-4134-a4af-b4b8b78146c9
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/15 11:41:26

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/15 11:41:26
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
    /// WxmenuIdal
    /// </summary>
    public interface WxmenuIdal
    {
        /// <summary>
        /// 新增微信菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         bool AddWxmenu(Mwxmenu model);

        /// <summary>
        /// 根据id获取微信菜单model
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
         Mwxmenu GetWxmenuByOpenid(string id);

        /// <summary>
        /// 获取全部微信菜单
        /// </summary>
        /// <returns></returns>
         List<Mwxmenu> GetAllWxmenu(string superId);

        /// <summary>
        /// 根据ID删除微信才菜单
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
         bool DeleteWxmenu(string id);

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         bool UpdateWxmenu(Mwxmenu model);
    }
}
