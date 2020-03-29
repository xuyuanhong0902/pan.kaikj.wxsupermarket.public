/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  AdminUser
*版本号：  V1.0.0.0
*唯一标识：ba10e91f-8aed-40ed-ab28-3731477a72b1
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/13 22:54:40

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/13 22:54:40
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
    /// SndGoodsUserBus
    /// </summary>
    public class SndGoodsUserBus
    {
        /// <summary>
        /// 分页获取 送货员 数据信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSndGoodsUserListPage(int pagIndex, string phone, string userName)
        {
            try
            {
                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<MsendGoodsUser> pageListResult = new MPageListResult<MsendGoodsUser>();

                //// 每页获取20条数据
                int pagSize = 20;

                //// 1、首先获取符号要求的数据总条数
                SndGoodsUserService sndGoodsUserService = new SndGoodsUserService();
                pageListResult.totalNum = sndGoodsUserService.GetSndGoodsUserPagCount(phone, userName);
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    pagIndex = pagIndex > pageListResult.totalPage ? pageListResult.totalPage : pagIndex;

                    //// 3、获取具体的分页数据信息
                    pageListResult.dataList = sndGoodsUserService.GetSendGoodsUserPagList(pagIndex, pagSize, phone, userName);
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;

                return JsonHelper.GetJson<MPageListResult<MsendGoodsUser>>(pageListResult);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 分页获取 送货员 数据信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<MsendGoodsUser> GetAllSndGoodsUserList()
        {
            try
            {
             return new SndGoodsUserService().GetSendGoodsUserPagList(1, 99999, string.Empty, string.Empty);
              
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据id删除管理员数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletUserByIdMeth(string id)
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
                    if (!new SndGoodsUserService().DeleteSndGoodsUser(id))
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
            catch (Exception)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 新增平台用户
        /// </summary>
        /// <param name="madminuser"></param>
        /// <returns></returns>
        public string AddUserMeth(MsendGoodsUser model)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                //// 数据合法性检查
                string checkAdminUser = this.CheckSendUser(model);
                if (!string.IsNullOrEmpty(checkAdminUser))
                {
                    mwxResult.errmsg = checkAdminUser;
                }

                bool doResult = false;
                if (string.IsNullOrEmpty(model.id))
                {
                    //// 时间相关参数赋值
                    model.great_time = System.DateTime.Now;
                    model.modify_time = model.great_time;
                    model.id = PublicTools.GetRandomNumberByTime();
                    doResult = new SndGoodsUserService().AddSndGoodsUser(model);
                }
                else
                {
                    doResult = new SndGoodsUserService().ChangSndGoodsUserInfor(model);
                }
               
                //// 数据落地入库
                if (!doResult)
                {
                    mwxResult.errmsg = "操作失败";
                }
                else
                {
                    mwxResult.errcode = 0;
                    mwxResult.errmsg = "操作成功";
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 获取送货人model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MsendGoodsUser GetSendGoodsUserModelById(string id) {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            else
            {
                return new SndGoodsUserService().GetSendGoodsUserModelById(id);
            }
        }

        /// <summary>
        /// 检查新增用户的合法性
        /// </summary>
        /// <param name="madminuser"></param>
        /// <returns></returns>
        private string CheckSendUser(MsendGoodsUser model)
        {
            if (model == null)
            {
                return "操作失败：送货员不能为空！";
            }

            if (string.IsNullOrEmpty(model.userName))
            {
                return "操作失败：姓名不能为空！";

                return string.Empty;
            }
            if (string.IsNullOrEmpty(model.phone))
            {
                return "操作失败：手机号码不能为空！";
            }

            if (!PublicTools.IsPhon(model.phone))
            {
                return "操作失败：请输入正确格式的手机号码！";
            }

            //// 验证手机号码是否已经被使用
            if (new SndGoodsUserService().GetSndGoodsUserPagCount(model.phone, string.Empty)>0)
            {
                return "操作失败：该手机号码已被使用！";
            }

            return string.Empty;
        }
    }
}
