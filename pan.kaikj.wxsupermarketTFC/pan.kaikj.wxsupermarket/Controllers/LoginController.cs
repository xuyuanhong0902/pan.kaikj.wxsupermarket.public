using pan.kaikj.wxsupermarket.bus;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pan.kaikj.wxsupermarket.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session.Abandon();//清除全部Session
            ViewData["platformName"] = WebConfigeOpert.GetPlatformName();
            return View();
        }

        /// <summary>
        /// 登录逻辑
        /// </summary>
        /// <param name="acount"></param>
        /// <param name="pass"></param>
        /// <param name="verifiCode"></param>
        /// <returns></returns>
        public string SubLoginMeth(string acount, string pass, string verifiCode)
        {
            return new LoginBus().SubLogin(acount, pass, verifiCode);
        }

        /// <summary>
        /// 绘制验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            byte[] data = null;
            string code = PublicTools.RandomCode(5);
            Session["verifiCode"] = code;
            //定义一个画板
            MemoryStream ms = new MemoryStream();
            using (Bitmap map = new Bitmap(100, 40))
            {
                //画笔,在指定画板画板上画图
                //g.Dispose();
                using (Graphics g = Graphics.FromImage(map))
                {
                    g.Clear(Color.White);
                    g.DrawString(code, new Font("黑体", 18.0F), Brushes.Blue, new Point(10, 8));
                    //绘制干扰线
                    PaintInterLine(g, 15, map.Width, map.Height);
                }
                map.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            data = ms.GetBuffer();
            return File(data, "image/jpeg");
        }

        /// <summary>
        /// 绘制干扰性
        /// </summary>
        /// <param name="g"></param>
        /// <param name="num"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void PaintInterLine(Graphics g, int num, int width, int height)
        {
            Random r = new Random();
            int startX, startY, endX, endY;
            for (int i = 0; i < num; i++)
            {
                startX = r.Next(0, width);
                startY = r.Next(0, height);
                endX = r.Next(0, width);
                endY = r.Next(0, height);
                g.DrawLine(new Pen(Brushes.Red), startX, startY, endX, endY);
            }
        }
    }
}