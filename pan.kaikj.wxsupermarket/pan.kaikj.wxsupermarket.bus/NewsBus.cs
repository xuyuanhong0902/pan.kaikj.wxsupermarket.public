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

using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// NewsBus
    /// </summary>
    public class NewsBus
    {
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddNews(Mnews model)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };


            try
            {
                if (string.IsNullOrEmpty(model.id))
                {
                    DateTime dateTimeNow = System.DateTime.Now;
                    model.isDelete = "0";
                    model.isEffective = "1";
                    model.great_time = dateTimeNow;
                    model.modify_time = dateTimeNow;
                    model.type = 1;
                    model.id = PublicTools.GetRandomNumberByTime();
                    if (new NewsService().AddNews(model))
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功！";
                    }
                    else
                    {
                        mwxResult.errmsg = "操作失败！";
                    }
                }
                else
                {
                    if (new NewsService().UpdateNews(model))
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功！";
                    }
                    else
                    {
                        mwxResult.errmsg = "操作失败！";
                    }
                }

            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        public List<Mnews> GetAllNews()
        {
            try
            {
                NewsService opert = new NewsService();
                return opert.GetNewsPagList(1,999);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mnews GetNewsById(string id)
        {
            Mnews model = null;
            try
            {
                NewsService opert = new NewsService();
                model =opert.GetNewsById(id);
            }
            catch (Exception ex)
            {
               
            }

            return model == null ? new Mnews() : model;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public string DelectNews(string id)
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
                    if (!new NewsService().DeleteNews(id))
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
