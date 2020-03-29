/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  LoginBus
*版本号：  V1.0.0.0
*唯一标识：97c270fc-5d8c-4a00-9915-44483f1adb6a
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/12 21:33:01

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/12 21:33:01
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
using System.Web;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// LoginBus
    /// </summary>
    public class LoginBus
    {
        HttpContext httpContext = HttpContext.Current;

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="acount"></param>
        /// <param name="pass"></param>
        /// <param name="verifiCode"></param>
        /// <returns></returns>
        public string SubLogin(string acount, string pass, string verifiCode)
        {
            //// 实现步骤
            //// 1.首先简单验证数据的合法性
            //// 2.根据账号到数据库用户表取数据，看是否能够取到数据
            //// 3.根据第二步取到的数据，验证密码是否匹配
            //// 4.如果用户信息账号密码相匹配，那么session中存储用户登录信息，并返回登录成功
            //// 5.如果用户账号信息秘密不匹配，登录失败，并返回相应的错误信息

            //// 1.首先简单验证数据的合法性
            MwxResult mwxResult = this.CheckLogin(acount, pass, verifiCode);

            try
            {
                if (mwxResult != null && mwxResult.errcode == 0)
                {
                     if (acount!="admin" && pass!="tfc2018")
                    {
                        mwxResult.errcode = -1;
                        mwxResult.errmsg = "账号密码错误";
                    }
                    else
                    {
                        //// 4.如果用户信息账号密码相匹配，那么session中存储用户登录信息，并返回登录成功
                        httpContext.Session["acount"] = acount;
                        httpContext.Session["adminusername"] = "金地维权中心管理员";
                    }
                }

            }
            catch (Exception)
            {
                mwxResult = new MwxResult() { errcode = -1, errmsg = "系统错误！" };
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 检查登录信息的合法性
        /// </summary>
        /// <param name="acount">acount</param>
        /// <param name="pass">pass</param>
        /// <param name="verifiCode">verifiCode</param>
        /// <returns></returns>
        private MwxResult CheckLogin(string acount, string pass, string verifiCode)
        {
            MwxResult mwxResult = new MwxResult() { errcode = 0 };

            if (string.IsNullOrEmpty(acount))
            {
                mwxResult.errcode = -1;
                mwxResult.errmsg = "账号不能为空！";
            }

            if (string.IsNullOrEmpty(pass))
            {
                mwxResult.errcode = -1;
                mwxResult.errmsg = "密码不能为空！";
            }

            if (string.IsNullOrEmpty(verifiCode))
            {
                mwxResult.errcode = -1;
                mwxResult.errmsg = "验证码不能为空！";
            }

            if (verifiCode != httpContext.Session["verifiCode"] + string.Empty)
            {
                mwxResult.errcode = -2;
                mwxResult.errmsg = "验证码错误！";
            }

            return mwxResult;
        }
    }
}
