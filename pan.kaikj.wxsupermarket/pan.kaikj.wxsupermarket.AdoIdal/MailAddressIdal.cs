/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoIdal
*文件名：  MailAddressIdal
*版本号：  V1.0.0.0
*唯一标识：8feea159-0660-418c-85c7-fd5046ca1f1a
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 20:00:21

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 20:00:21
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
    /// MailAddressIdal
    /// </summary>
    public interface MailAddressIdal
    {
        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool AddMailAddress(MmailAddress model);

        /// <summary>
        /// 更新用户的默认地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        bool UpdateMailAddressDefault(string userId, string addressId);

        /// <summary>
        /// 删除邮寄地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        bool DeleteMailAddress(string userId, string addressId);

        /// <summary>
        /// 根据用户ID获取其全部地址信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<MmailAddress> GetMmailAddressesByUserId(string userId);
    }
}
