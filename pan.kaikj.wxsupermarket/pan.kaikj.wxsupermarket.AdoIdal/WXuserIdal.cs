/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  WXuserIdal
*版本号：  V1.0.0.0
*唯一标识：8ea42c57-decf-412e-b164-acd2e8889d0e
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 15:42:27

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 15:42:27
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
    /// WXuserIdal WXuserIdal
    /// </summary>
    public interface WXuserIdal
    {
        /// <summary>
        /// 新增微信用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddWXuser(MWXUserInfo model);

        /// <summary>
        /// 根据Openid获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        MWXUserInfo GetWXUserInfoByOpenid(string openid);

        /// <summary>
        /// 根据id获取openId更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateWXUserInfo(MWXUserInfo model);

        /// <summary>
        /// 分页获取微信用户信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        List<MWXUserInfo> GetWXUserInfoPagList(int pagIndex, int pagCount, string nickname, string subscribe);

        /// <summary>
        /// 获取微信用户信息总条数
        /// </summary>
        /// <returns></returns>
        int GetWXUserInfoPagCount(string nickname, string subscribe);
    }
}
