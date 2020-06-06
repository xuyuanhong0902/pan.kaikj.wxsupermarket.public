/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoService
*文件名：  OrderService
*版本号：  V1.0.0.0
*唯一标识：b9e83762-b5d8-443e-b6c2-d64a65d958a5
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 19:35:41

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 19:35:41
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
    /// UserCouponService
    /// </summary>
    public class UserCouponService
    {
        public UserCouponIdal opertService = new UserCouponDal();

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Musercoupon model)
        {
            return opertService.Add(model);
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Musercoupon GetById(string id)
        {
            return opertService.GetById(id);
        }

        /// <summary>
        /// 使用优惠券
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int UseCoupon(string id, string orderId) {
            return opertService.UseCoupon(id, orderId);
        }

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        /// <returns></returns>
        public int GetPagCount(string userId, int isUse)
        {
            return opertService.GetPagCount(userId,  isUse);
        }

        /// <summary>
        /// 分页获取信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<Musercoupon> GetPagList(string userId, int isUse, int pagIndex, int pagCount)
        {
            return opertService.GetPagList( userId,  isUse, pagIndex, pagCount);
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return opertService.Delete(id);
        }
    }
}
