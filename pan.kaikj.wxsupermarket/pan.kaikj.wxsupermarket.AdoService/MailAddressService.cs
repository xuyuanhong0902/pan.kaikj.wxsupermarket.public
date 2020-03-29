/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  MailAddressService
*版本号：  V1.0.0.0
*唯一标识：07c5adbb-67de-4960-879b-a35ed6625a5c
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 20:00:34

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 20:00:34
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
    /// MailAddressService
    /// </summary>
    public class MailAddressService
    {
        public MailAddressIdal opertService = new MailAddressDal();

        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddMailAddress(MmailAddress model)
        {
            return opertService.AddMailAddress(model);
        }

        /// <summary>
        /// 更新用户的默认地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public bool UpdateMailAddressDefault(string userId, string addressId)
        {
            return opertService.UpdateMailAddressDefault(userId, addressId);
        }

        /// <summary>
        /// 删除邮寄地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public bool DeleteMailAddress(string userId, string addressId)
        {
            return opertService.DeleteMailAddress(userId, addressId);
        }

        /// <summary>
        /// 根据用户ID获取其全部地址信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MmailAddress> GetMmailAddressesByUserId(string userId)
        {
            return opertService.GetMmailAddressesByUserId(userId);
        }
    }
}
