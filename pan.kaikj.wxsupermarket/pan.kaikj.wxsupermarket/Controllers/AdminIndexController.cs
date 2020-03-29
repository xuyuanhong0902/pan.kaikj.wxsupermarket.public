using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class AdminIndexController : BaseController
    {
        // GET: AdminIndex
        public ActionResult Index()
        {
            if (!base.CheckIsLogin())
            {
               return  RedirectToAction("Index", "Login");
            }

            ViewData["Static"] = new OrderBus().Static(); 

            return View();
        }

        /// <summary>
        /// 平台用户管理列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        /// <summary>
        /// 分页获取用户数据信息列表
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SelectUserListMeth(string pagIndex, string acount, string name)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            int pagIndexI = 0;
            Int32.TryParse(pagIndex, out pagIndexI);
            return new AdminUserBus().GetAdminUserListPage(pagIndexI, acount, name);
        }

        /// <summary>
        /// 根据ID删除管理员信息
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string DeletUserByIdMeth(string adminuserid)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new AdminUserBus().DeletUserByIdMeth(adminuserid);
        }

        /// <summary>
        /// 新增平台用户
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUser()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            //// 获取一个随机的密码
            ViewData["passWord"] = PublicTools.RandomCode(10);
            return View();
        }

        /// <summary>
        /// 新增平台用户
        /// </summary>
        /// <param name="madminuser"></param>
        /// <returns></returns>
        public string AddUserMeth(Madminuser madminuser)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new AdminUserBus().AddUserMeth(madminuser);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public string ChangAdminUserPass(string adminuserid)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new AdminUserBus().ChangAdminUserPass(adminuserid);
        }
    }
}