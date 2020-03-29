/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  AdminuserIdal
*版本号：  V1.0.0.0
*唯一标识：bddc279b-1653-41bc-99d3-fe4b77f14547
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/11 21:41:33

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/11 21:41:33
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
    /// AdminuserIdal 管理员类
    /// </summary>
    public interface AdminuserIdal
    {
        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddAdminUser(Madminuser model);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        bool DeleteAdminUser(string adminuserid);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        bool ChangAdminUserPass(string adminuserid, string newPass);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        bool ChangAdminUserInfor(Madminuser model);

        /// <summary>
        /// 根据登录账号获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Madminuser GetMadminuserModelByAcount(string account);

        /// <summary>
        /// 获取管理员数据总条数
        /// </summary>
        /// <returns></returns>
        int GetAdminUserInfoPagCount(string acount, string name);

        /// <summary>
        /// 分页获取管理严用户信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        List<Madminuser> GetAdminUserInfoPagList(int pagIndex, int pagCount, string acount, string name);
    }
}
