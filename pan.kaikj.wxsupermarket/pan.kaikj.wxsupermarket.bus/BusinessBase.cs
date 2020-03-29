/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  BusinessBase
*版本号：  V1.0.0.0
*唯一标识：92e4485e-e7f9-482f-9d82-fd7d194e8ec1
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 19:57:58

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 19:57:58
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
using System.Web;
using System.Web.UI;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// BusinessBase 业务基类
    /// </summary>
    public class BusinessBase
    {
        /// <summary>
        /// 新增微信用户的委托定义
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public delegate bool AddWXUser(MWXUserInfo model);

        /// <summary>
        /// 根据code获取用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public MWXUserInfo GetWXUserInfoByCode(string code) {
            //// 实现逻辑步骤
            //// 1、首先判断在session中是否已经存在对应的cdoe，根据实际情况获取openid
            //// 2、如果存在说明不是第一次跳转过来的，那么直接用session中对应的openid做操作
            //// 3、如果不存在，那么需要根据code，到微信获取对应的openid
            //// 4、根据openid 到数据库中查询用户数据信息
            //// 5、如果数据库未查询到数据信息，那么根据openid到微信查询对应的用户信息
            //// 6、对步骤5获取的用户数据信息入库
            //// 7、返回最终查询到的用户信息对象

            //// 用户信息模型
            MWXUserInfo model = null;
            string openid = string.Empty;

            //// 1、首先判断在session中是否已经存在对应的cdoe，根据实际情况获取openid
            HttpContext httpContext = HttpContext.Current;
            if (string.IsNullOrEmpty(httpContext.Session["code"] + string.Empty))
            {
                //// 3、如果不存在，那么需要根据code，到支付获取对应的openid
                 openid = new WXApiOpert().GetOpenIdByCode(code);
                //// LogOpert.AddWeiXinMessage("1根据code到微信获取openid：" + openid);
            }
            else
            {
                //// 取session中的openid
                openid = httpContext.Session["openid"]+string.Empty;
                ////  LogOpert.AddWeiXinMessage("在内存中获取openid：" + openid);

                if (string.IsNullOrEmpty(openid))
                {
                    openid = new WXApiOpert().GetOpenIdByCode(code);
                    ////  LogOpert.AddWeiXinMessage("2根据code到微信获取openid：" + openid);
                }
            }

            ////  LogOpert.AddWeiXinMessage("最终的openid值为：" + openid);

            //// 方法封装了
            model = this.GetWXUserInfoByOpenid(openid);
            httpContext.Session["loginuserId"] = model.wxuserid;
            httpContext.Session["loginuserName"] = model.nickname;
            //// 7、返回最终查询到的用户信息对象
            return model;
        }

        /// <summary>
        /// 根据code获取用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public MWXUserInfo GetWXUserInfoByOpenid(string openid)
        {
            //// 实现逻辑步骤
            //// 1、根据openid 到数据库中查询用户数据信息
            //// 2、如果数据库未查询到数据信息，那么根据openid到微信查询对应的用户信息
            //// 3、对步骤5获取的用户数据信息入库
            //// 4、返回最终查询到的用户信息对象

            //// 用户信息模型
            MWXUserInfo model = null;

            if (!string.IsNullOrEmpty(openid))
            {
                //// 1、根据openid 到数据库中查询用户数据信息
                model = new WXuserService().GetWXUserInfoByOpenid(openid);

                if (model == null)
                {
                    //// 2、如果数据库未查询到数据信息，那么根据openid到微信查询对应的用户信息
                    model = new WXApiOpert().GetUserInfo(openid);

                    if (model!=null)
                    {
                        model.great_time = System.DateTime.Now;
                        model.modify_time = System.DateTime.Now;
                    }
                    //// LogOpert.AddWeiXinMessage("微信中根据openid获取到的用户信息为：" + JsonHelper.GetJson<MWXUserInfo>(model));

                    if (model != null)
                    {
                        //// 3、对步骤5获取的用户数据信息入库 异步入库
                        AddWXUser handler = new AddWXUser(new WXuserService().AddWXuser);
                        model.wxuserid = PublicTools.GetRandomNumberByTime();
                        handler.BeginInvoke(model, null, null);
                        //// LogOpert.AddWeiXinMessage("用户信息异步数据入库：" + JsonHelper.GetJson<MWXUserInfo>(model));
                    }
                }
                else
                {
                    ////  LogOpert.AddWeiXinMessage("数据库中根据openid获取到的用户信息为：" + JsonHelper.GetJson<MWXUserInfo>(model));
                }
            }

            //// 4、返回最终查询到的用户信息对象
            return model;
        }

    }
}
