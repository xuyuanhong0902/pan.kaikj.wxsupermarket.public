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
    public class AdminOrderController : BaseController
    {
        // GET: AdminOrder
        public ActionResult List()
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        /// <summary>
        /// 获取订单列表数据
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="userName"></param>
        /// <param name="productname"></param>
        /// <param name="orderState"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public string SelectOrderListMeth(int pagIndex, string userName, string buildNum,string amountType)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }

            return new TFCEvidenceInforBus().GetInfoPagList(pagIndex, userName,buildNum, amountType);
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <returns></returns>
        public  ActionResult orderDetail(string id)
        {
            if (!base.CheckIsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            return View(new TFCEvidenceInforBus().GetInfoById(id));
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <returns></returns>
        public string deleteMeth(string id)
        {
            if (!base.CheckIsLogin())
            {
                return "-1";
            }
            return new TFCEvidenceInforBus().DeletById(id);
        }

        public string addMeth(MTFCEvidenceInfor model)
        {
            return new TFCEvidenceInforBus().Add(model);
        }

        /// <summary>
        /// 下载团购费信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="buildNum"></param>
        public string DownLoadTFCInforMeth(string userName, string buildNum, string amountType)
        {
            string url = "Downloads/TFCTuanGouF" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string excelUrl = Server.MapPath("~/" + url);
            FileOpert.CreateFile(url);
            new TFCEvidenceInforBus().DownLoadTFCInfor(excelUrl, userName,  buildNum, amountType);
            return url;
        }
    }
}