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
    /// AdminuserService
    /// </summary>
    public class AdminuserService
    {
        public AdminuserIdal opertService = new AdminuserDal();

        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddAdminUser(Madminuser model)
        {
            return opertService.AddAdminUser(model);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public bool DeleteAdminUser(string adminuserid)
        {
            return opertService.DeleteAdminUser(adminuserid);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public bool ChangAdminUserPass(string adminuserid, string newPass)
        {
            return opertService.ChangAdminUserPass(adminuserid, newPass);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public bool ChangAdminUserInfor(Madminuser model)
        {
            return opertService.ChangAdminUserInfor(model);
        }

        /// <summary>
        /// 根据登录账号获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Madminuser GetMadminuserModelByAcount(string account)
        {
            return opertService.GetMadminuserModelByAcount(account);
        }

        /// <summary>
        /// 获取管理员数据总条数
        /// </summary>
        /// <returns></returns>
        public int GetAdminUserInfoPagCount(string acount, string name)
        {
            return opertService.GetAdminUserInfoPagCount(acount, name);
        }

        /// <summary>
        /// 分页获取管理严用户信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<Madminuser> GetAdminUserInfoPagList(int pagIndex, int pagCount, string acount, string name)
        {
            return opertService.GetAdminUserInfoPagList(pagIndex, pagCount, acount, name);
        }
    }
}
