using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.bus;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace pan.kaikj.wxsupermarket.Controllers
{
    /// <summary>
    /// 微信API相关
    /// </summary>
    public class WXAPIController : Controller
    {
        #region 微信消息处理

        /// <summary>
        /// 微信API入口
        /// </summary>
        /// <returns></returns>
        public string Index()
        {
            //// 只有在第一次服务搭建的时候开启，后面注释掉该代码
            //// return CheckSignature();
            try
            {
                MwxMessage wx = GetWxMessage();
                string res = "";

                string sendMessage = string.Empty;
                if (wx.MsgType == "text")
                {
                    if (wx.Content=="待送货订单")
                    {
                        ///// 查询待送货订单
                        //// 包括3条数据
                        //// 1、总待送货
                        //// 2、半小时内需要送货的订单数
                        //// 3、今天内需要送货的订单数
                        sendMessage = this.GetSendGoodesCount();
                    }
                    else
                    { 
                    //// 记录一条日志信息
                    sendMessage = string.Format("您好, {0}已收到你消息。!", WebConfigeOpert.GetPlatformName());
                    }
                }

                if (!string.IsNullOrEmpty(sendMessage))
                {                
                    res = new WXApiOpert().GetSendMessage(wx, sendMessage);
                }

                return res;
            }
            catch (Exception )
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 注册检查
        /// </summary>
        /// <returns></returns>
        private string CheckSignature()
        {
            if (!string.IsNullOrEmpty(Request["echoStr"]))
            {
                var signature = Request["signature"];
                var timestamp = Request["timestamp"];
                var nonce = Request["nonce"];
                var token = WebConfigeOpert.GetWXtoken();

                bool checkReslut = new WXApiOpert().CheckSignature(signature, timestamp, nonce, token);

                return checkReslut ? Request["echoStr"] : string.Empty;
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取消息对象
        /// </summary>
        /// <returns></returns>
        private MwxMessage GetWxMessage()
        {
            MwxMessage wx = new MwxMessage();
            StreamReader str = new StreamReader(Request.InputStream, System.Text.Encoding.UTF8);
            XmlDocument xml = new XmlDocument();
            xml.Load(str);
            wx.ToUserName = xml.SelectSingleNode("xml").SelectSingleNode("ToUserName").InnerText;
            wx.FromUserName = xml.SelectSingleNode("xml").SelectSingleNode("FromUserName").InnerText;
            wx.CreateTime = Convert.ToInt64(xml.SelectSingleNode("xml").SelectSingleNode("CreateTime").InnerText);
            wx.MsgId = Convert.ToInt64(xml.SelectSingleNode("xml").SelectSingleNode("MsgId").InnerText);
            wx.MsgType = xml.SelectSingleNode("xml").SelectSingleNode("MsgType").InnerText;
            switch (wx.MsgType.Trim())
            {
                case "text":
                    wx.Content = xml.SelectSingleNode("xml").SelectSingleNode("Content").InnerText;
                    break;
                case "event":
                    wx.Event = xml.SelectSingleNode("xml").SelectSingleNode("Event").InnerText;
                    wx.EventKey = xml.SelectSingleNode("xml").SelectSingleNode("EventKey").InnerText;
                    break;
            }
            return wx;
        }

        /// <summary>
        /// 获取待送货的订单数据
        /// </summary>
        /// <returns></returns>
        private string GetSendGoodesCount() {
            MstaticSendOrder model = new OrderBus().SaticSendGoodesCount();

            return string.Format(@"代发货的订单总数为：{0}。其中送货超时的订单数为：{1},其中半小时内需要送货的订单数为：{2},其中今天需要送货的订单数为：{3}",
                                model.sendGoodsCount,model.delayedSendGoodsCount,
                                model.halfhourSendGoodsCount,model.todaySendGoodsCount);

        }

        #endregion
    }
}