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
    public class TFCEvidenceInforService
    {
        public TFCEvidenceInfordal opertService = new TFCEvidenceInforDal();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(MTFCEvidenceInfor model) {
            return opertService.Add(model);
        }

        /// <summary>
        /// 根据id删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delet(string id) {
            return opertService.Delet(id);
        }

        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MTFCEvidenceInfor GetInfoById(string id) {
            return opertService.GetInfoById(id);
        }

        /// <summary>
        /// 分页获取信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<MTFCEvidenceInfor> GetInfoPagList(int pagIndex, int pagCount, string userName, string buildNum, string amountType)
        {
            return opertService.GetInfoPagList(pagIndex,  pagCount,  userName,  buildNum,amountType);
        }

        /// <summary>
        /// 获取信息总条数
        /// </summary>
        /// <returns></returns>
        public int GetInfoPagCount(string userName, string buildNum, string amountType)
        {
            return opertService.GetInfoPagCount(userName, buildNum, amountType);
        }

        /// <summary>
        /// 获取总条数(根据电话号码)
        /// </summary>
        /// <returns></returns>
        public int CheckPhonHasUser(string phonNum)
        {
            return opertService.CheckPhonHasUser(phonNum);
        }
    }
}
