/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  User
*版本号：  V1.0.0.0
*唯一标识：ef1a6a8a-964a-4876-b0c7-0796119179ba
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/15 21:55:25

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/15 21:55:25
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// User
    /// </summary>
    public class UserBus
    {
        /// <summary>
        /// 分页获取微信用户数据信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetUserListPage(int pagIndex, string nickname, string subscribe)
        {
            try
            {
                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<MWXUserInfo> pageListResult = new MPageListResult<MWXUserInfo>();

                //// 每页获取20条数据
                int pagSize = 20;

                //// 1、首先获取符号要求的数据总条数
                WXuserService opertService = new WXuserService();
                pageListResult.totalNum = opertService.GetWXUserInfoPagCount(nickname, subscribe);
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    pagIndex = pagIndex > pageListResult.totalPage ? pageListResult.totalPage : pagIndex;

                    //// 3、获取具体的分页数据信息
                    pageListResult.dataList = opertService.GetWXUserInfoPagList(pagIndex, pagSize, nickname, subscribe);
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;

                return JsonHelper.GetJson<MPageListResult<MWXUserInfo>>(pageListResult);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据Openid获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public MWXUserInfo GetWXUserInfoByOpenid(string openid)
        {
            try
            {
                return new WXuserService().GetWXUserInfoByOpenid(openid);
            }
            catch (Exception) {
                return new MWXUserInfo();
            }
        }
    }
}
