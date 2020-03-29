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
    public interface TFCEvidenceInfordal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(MTFCEvidenceInfor model);

        /// <summary>
        /// 根据id删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delet(string id);

        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MTFCEvidenceInfor GetInfoById(string id);

        /// <summary>
        /// 分页获取信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        List<MTFCEvidenceInfor> GetInfoPagList(int pagIndex, int pagCount, string userName, string buildNum, string amountType);

        /// <summary>
        /// 获取信息总条数
        /// </summary>
        /// <returns></returns>
        int GetInfoPagCount(string userName, string buildNum, string amountType);

        /// <summary>
        /// 获取总条数(根据电话号码)
        /// </summary>
        /// <returns></returns>
        int CheckPhonHasUser(string phonNum);
    }
}
