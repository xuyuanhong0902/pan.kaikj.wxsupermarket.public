/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  NewsBus
*版本号：  V1.0.0.0
*唯一标识：9f51a026-bc18-4779-892e-6b0dda0afcc7
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/16 21:44:29

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/16 21:44:29
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// CouponBus
    /// </summary>
    public class CouponBus
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Add(Mcoupon model)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {

                DateTime dateTimeNow = System.DateTime.Now;
                model.isDelete = "0";
                model.isEffective = "1";
                model.great_time = dateTimeNow;
                model.modify_time = dateTimeNow;
                model.id = PublicTools.GetRandomNumberByTime();
                if (new CouponService().Add(model))
                {
                    mwxResult.errcode = 0;
                    mwxResult.errmsg = "操作成功！";
                }
                else
                {
                    mwxResult.errmsg = "操作失败！";
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        public Mcoupon GetById(string id)
        {
            try
            {
                CouponService opert = new CouponService();
                return opert.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 分页获取信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="pagCount"></param>
        /// <returns></returns>
        public string GetPagList(int pagIndex, int pagCount)
        {
            try
            {
                CouponService opert = new CouponService();

                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<Mcoupon> pageListResult = new MPageListResult<Mcoupon>();

                //// 每页获取20条数据
                int pagSize = 20;

                pageListResult.totalNum = opert.GetPagCount();
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    pagIndex = pagIndex > pageListResult.totalPage ? pageListResult.totalPage : pagIndex;

                    //// 3、获取具体的分页数据信息
                    pageListResult.dataList = opert.GetPagList(pagIndex, pagSize);
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;
                IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
                return JsonConvert.SerializeObject(pageListResult, Formatting.Indented, timeConverter);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public string Delete(string id)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    mwxResult.errmsg = "操作失败：ID不能为空！";
                }
                else
                {
                    if (!new CouponService().Delete(id))
                    {
                        mwxResult.errmsg = "操作失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功";
                    }
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }
    }
}
