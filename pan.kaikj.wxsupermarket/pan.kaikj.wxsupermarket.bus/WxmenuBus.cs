/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  WxmenuBus
*版本号：  V1.0.0.0
*唯一标识：58c96a05-6ddf-43ea-b5fa-00b2abd666c8
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/15 12:39:02

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/15 12:39:02
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using Newtonsoft.Json;
using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// WxmenuBus
    /// </summary>
    public class WxmenuBus
    {
        /// <summary>
        /// 获取所有主菜单
        /// </summary>
        /// <returns></returns>
        public List<Mwxmenu> GetAllMainMenu()
        {
            try
            {
                WxmenuService opert = new WxmenuService();
                return opert.GetAllWxmenu("");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public List<Mwxmenu> GetAllMenu()
        {
            try
            {
                WxmenuService opert = new WxmenuService();
                return opert.GetAllWxmenu("-1");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public string DelectMenu(string id)
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
                    if (!new WxmenuService().DeleteWxmenu(id))
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

        /// <summary>
        /// 新增微信菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddWxmenu(Mwxmenu model)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                //// 时间相关参数赋值
                model.url = string.IsNullOrEmpty(model.url) ? "" : model.url;
                model.id= PublicTools.GetRandomNumberByTime();
                model.type = "view";
                model.great_time = System.DateTime.Now;
                model.modify_time = model.great_time;
                model.isDelete = 0;
                model.isEffective = 1;
                if (model.superId=="0")
                {
                    model.superId = "";
                }
                //// 数据落地入库
                if (!new WxmenuService().AddWxmenu(model))
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
        /// 发布微信菜单
        /// </summary>
        /// <returns></returns>
        public string FabuMenuToWX() {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                List<Mwxmenu> menuList = this.GetAllMenu();
                if (menuList!=null&& menuList.Count>0)
                {
                    ///// 构建微信菜单对象
                    MwxMenu<MwxMenuBase> wxMenu = new MwxMenu<MwxMenuBase>();
                    wxMenu.button = new List<MwxMenuBase>();
                    //// 获取所有主菜单
                    List<Mwxmenu> mianMenuList = menuList.FindAll(p=>string.IsNullOrEmpty(p.superId));
                    if (mianMenuList!=null&& mianMenuList.Count>0)
                    {
                        mianMenuList= mianMenuList.OrderBy(p=>p.sortNum).ToList<Mwxmenu>();
                        foreach (var item in mianMenuList)
                        {
                            if (menuList.Exists(p=>p.superId==item.id))
                            {
                                List<MwxMenuView> listSubMent = new List<MwxMenuView>();
                                List<Mwxmenu> subMenu = menuList.FindAll(p => p.superId == item.id);
                                subMenu= subMenu.OrderBy(p => p.sortNum).ToList<Mwxmenu>(); ;
                                foreach (var item2 in subMenu)
                                {
                                    MwxMenuView model2 = new MwxMenuView();
                                    model2.type = item2.type;
                                    model2.name = item2.menuName;
                                    model2.url = item2.url;
                                    listSubMent.Add(model2);
                                }
                                ///// 存在子菜单
                                MminWxMenuView<MwxMenuView>  model = new MminWxMenuView<MwxMenuView>();
                                model.name = item.menuName;
                                model.sub_button = listSubMent;
                                wxMenu.button.Add(model);
                            }
                            else
                            {
                                MwxMenuView model = new MwxMenuView();
                                model.type = item.type;
                                model.name = item.menuName;
                                model.url = item.url;
                                wxMenu.button.Add(model);
                            }
                        }
                    }

                    if (wxMenu!=null)
                    {
                        string menuHtml = JsonConvert.SerializeObject(wxMenu);

                        //// 开始调用接口生成菜单
                        mwxResult=  new WXApiOpert().AddMenu(menuHtml);
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
