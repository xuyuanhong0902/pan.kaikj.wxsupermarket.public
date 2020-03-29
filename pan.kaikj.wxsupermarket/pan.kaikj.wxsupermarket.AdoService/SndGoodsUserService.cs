/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  AdminuserService
*版本号：  V1.0.0.0
*唯一标识：518706f0-9b3b-4425-8fcc-fc62405836e9
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/12 21:45:37

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/12 21:45:37
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
    /// SndGoodsUserService
    /// </summary>
    public class SndGoodsUserService
    {
        public SndGoodsUserIdal opertService = new SndGoodsUserDal();

        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSndGoodsUser(MsendGoodsUser model)
        {
            return opertService.AddSndGoodsUser(model);
        }

        /// <summary>
        /// 删除送货员信息
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public bool DeleteSndGoodsUser(string id)
        {
            return opertService.DeleteSndGoodsUser(id);
        }

        /// <summary>
        /// 修改送货信息
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public bool ChangSndGoodsUserInfor(MsendGoodsUser model)
        {
            return opertService.ChangSndGoodsUserInfor(model);
        }

        /// <summary>
        /// 获取管理员数据总条数
        /// </summary>
        /// <returns></returns>
        public int GetSndGoodsUserPagCount(string phone, string userName)
        {
            return opertService.GetSndGoodsUserPagCount(phone, userName);
        }

        /// <summary>
        /// 分页获取管理严用户信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<MsendGoodsUser> GetSendGoodsUserPagList(int pagIndex, int pagCount, string phone, string userName)
        {
            return opertService.GetSendGoodsUserPagList(pagIndex, pagCount, phone, userName);
        }

        /// <summary>
        /// 获取送货人model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MsendGoodsUser GetSendGoodsUserModelById(string id)
        {
            return opertService.GetSendGoodsUserModelById(id);
        }
    }
}
