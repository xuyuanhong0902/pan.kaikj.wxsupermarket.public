using Microsoft.VisualStudio.TestTools.UnitTesting;
using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoServiceTests
*文件名：  WXuserServiceTests
*版本号：  V1.0.0.0
*唯一标识：bd2a866e-1f2c-4706-a9d3-6ee43c3816ca
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 22:30:25

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 22:30:25
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoService.Tests
{
    [TestClass()]
    public class WXuserServiceTests
    {
        [TestMethod()]
        public void GetWXUserInfoPagListTest()
        {
            MWXUserInfo mod = new WXuserService().GetWXUserInfoByOpenid("oUvS-0SDYj8NVGkzKWnFuvtR8jXw");

            int count = new WXuserService().GetWXUserInfoPagCount();

            List<MWXUserInfo> mWXUserInfos = new WXuserService().GetWXUserInfoPagList(1, 2);


            Assert.Fail();
        }
    }
}