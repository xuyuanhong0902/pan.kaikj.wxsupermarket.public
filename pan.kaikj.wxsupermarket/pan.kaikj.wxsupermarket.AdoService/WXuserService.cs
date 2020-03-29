/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  WXuserService
*版本号：  V1.0.0.0
*唯一标识：be22845e-f12a-477f-8829-6d84a01a0c49
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 15:43:35

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 15:43:35
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
    /// WXuserService
    /// </summary>
    public class WXuserService
    {
        public WXuserIdal opertService = new WXuserDal();

        /// <summary>
        /// 新增微信用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddWXuser(MWXUserInfo model)
        {

            if (model == null)
            {
                return false;
            }

            model.isDelete = 0;
            model.isEffective = 1;

            return opertService.AddWXuser(model);
        }

        /// <summary>
        /// 根据Openid获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public MWXUserInfo GetWXUserInfoByOpenid(string openid)
        {
            return opertService.GetWXUserInfoByOpenid(openid);
        }

        /// <summary>
        /// 根据id获取openId更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWXUserInfo(MWXUserInfo model)
        {
            return opertService.UpdateWXUserInfo(model);
        }

        /// <summary>
        /// 分页获取微信用户信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<MWXUserInfo> GetWXUserInfoPagList(int pagIndex, int pagCount, string nickname, string subscribe)
        {
            return opertService.GetWXUserInfoPagList(pagIndex, pagCount, nickname, subscribe);
        }

        /// <summary>
        /// 获取微信用户信息总条数
        /// </summary>
        /// <returns></returns>
        public int GetWXUserInfoPagCount(string nickname, string subscribe)
        {
            return opertService.GetWXUserInfoPagCount(nickname, subscribe);
        }
    }
}
