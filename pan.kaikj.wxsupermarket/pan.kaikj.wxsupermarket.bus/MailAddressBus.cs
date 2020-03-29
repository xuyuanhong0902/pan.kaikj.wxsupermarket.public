/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  MailAddressBus
*版本号：  V1.0.0.0
*唯一标识：2b247e7b-6c7e-4025-acdd-0f6c1ae44fcf
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/11/18 21:07:18

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/11/18 21:07:18
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// MailAddressBus
    /// </summary>
    public class MailAddressBus
    {
        public MailAddressService opertService = new MailAddressService();

        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddMailAddress(MmailAddress model)
        {
            try
            {
                model.isDefault = "1";
                model.addressId = PublicTools.GetRandomNumberByTime();
                return opertService.AddMailAddress(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新用户的默认地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public bool UpdateMailAddressDefault(string userId, string addressId)
        {
            if (string.IsNullOrEmpty(userId)||string.IsNullOrEmpty(addressId))
            {
                return false;
            }
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
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return null;
                }
                return opertService.GetMmailAddressesByUserId(userId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
