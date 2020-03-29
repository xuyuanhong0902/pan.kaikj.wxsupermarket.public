/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  WxmenuService
*版本号：  V1.0.0.0
*唯一标识：8a7e1868-7099-42a9-ba7e-ff2b4d8cdd2e
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/15 11:58:40

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/15 11:58:40
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
    /// WxmenuService
    /// </summary>
    public class WxmenuService
    {
        public WxmenuIdal opertService = new WxmenuDal();

        /// <summary>
        /// 新增微信菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddWxmenu(Mwxmenu model)
        {

            if (model == null)
            {
                return false;
            }

            model.isDelete = 0;
            model.isEffective = 1;

            return opertService.AddWxmenu(model);
        }

        /// <summary>
        /// 根据id获取微信菜单model
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public Mwxmenu GetWxmenuByOpenid(string id)
        {
            return opertService.GetWxmenuByOpenid(id);
        }

        /// <summary>
        /// 获取全部微信菜单
        /// </summary>
        /// <returns></returns>
        public List<Mwxmenu> GetAllWxmenu(string superId)
        {
            return opertService.GetAllWxmenu(superId);
        }

        /// <summary>
        /// 根据ID删除微信才菜单
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public bool DeleteWxmenu(string id)
        {
            return opertService.DeleteWxmenu(id);
        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWxmenu(Mwxmenu model)
        {
            return opertService.UpdateWxmenu(model);
        }
    }
}
