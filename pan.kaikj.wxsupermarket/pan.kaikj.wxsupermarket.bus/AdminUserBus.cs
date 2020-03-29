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
    /// AdminUser
    /// </summary>
    public class AdminUserBus
    {
        /// <summary>
        /// 分页获取管理员数据信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetAdminUserListPage(int pagIndex, string acount, string name)
        {
            try
            {
                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<Madminuser> pageListResult = new MPageListResult<Madminuser>();

                //// 每页获取20条数据
                int pagSize = 20;

                //// 1、首先获取符号要求的数据总条数
                AdminuserService adminuserService = new AdminuserService();
                pageListResult.totalNum = adminuserService.GetAdminUserInfoPagCount(acount, name);
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    pagIndex = pagIndex > pageListResult.totalPage ? pageListResult.totalPage : pagIndex;

                    //// 3、获取具体的分页数据信息
                    pageListResult.dataList = adminuserService.GetAdminUserInfoPagList(pagIndex, pagSize, acount, name);
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;

                return JsonHelper.GetJson<MPageListResult<Madminuser>>(pageListResult);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据id删除管理员数据
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string DeletUserByIdMeth(string adminuserid)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(adminuserid))
                {
                    mwxResult.errmsg = "操作失败：ID不能为空！";
                }
                else
                {
                    if (!new AdminuserService().DeleteAdminUser(adminuserid))
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
        public string AddUserMeth(Madminuser madminuser)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                //// 数据合法性检查
                string checkAdminUser = this.CheckAdminUser(madminuser);
                if (!string.IsNullOrEmpty(checkAdminUser))
                {
                    mwxResult.errmsg = checkAdminUser;
                }

                //// 时间相关参数赋值
                madminuser.great_time = System.DateTime.Now;
                madminuser.modify_time = madminuser.great_time;
                madminuser.adminuserid = PublicTools.GetRandomNumberByTime();
                madminuser.isEffective = 1;
                madminuser.password = PublicTools.MD5CryptoService(madminuser.password);
                //// 数据落地入库
                if (!new AdminuserService().AddAdminUser(madminuser))
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
        /// 检查新增用户的合法性
        /// </summary>
        /// <param name="madminuser"></param>
        /// <returns></returns>
        private string CheckAdminUser(Madminuser madminuser)
        {
            if (madminuser == null)
            {
                return "操作失败：用户信息不能为空！";
            }

            if (string.IsNullOrEmpty(madminuser.account))
            {
                return "操作失败：账号不能为空！";
            }

            if (!PublicTools.CheckIsNumOrLetter(madminuser.account))
            {
                return "操作失败：账号只能由数字和字母组成！";
            }

            if (string.IsNullOrEmpty(madminuser.name))
            {
                return "操作失败：姓名不能为空！";
            }

            return string.Empty;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string ChangAdminUserPass(string adminuserid)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(adminuserid))
                {
                    mwxResult.errmsg = "操作失败:请选中被操作用户！";
                }
                else
                {
                    //// 获取一个新密码
                    string newPass = PublicTools.RandomCode(10);

                    //// 重置
                    if (!new AdminuserService().ChangAdminUserPass(adminuserid, PublicTools.MD5CryptoService(newPass) ))
                    {
                        mwxResult.errmsg = "操作失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功，新的密码为："+ newPass;
                    }
                }
            }
            catch (Exception)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

    }
}
