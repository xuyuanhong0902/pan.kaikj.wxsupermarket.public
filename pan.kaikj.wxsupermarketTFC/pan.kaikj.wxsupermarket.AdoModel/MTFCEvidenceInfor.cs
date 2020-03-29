/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoModel
*文件名：  Madminuser
*版本号：  V1.0.0.0
*唯一标识：e3d0c997-202d-4ddf-979d-f4750f16f1ab
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/11 21:38:19

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/11 21:38:19
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

namespace pan.kaikj.wxsupermarket.AdoModel
{
    /// <summary>
    /// Madminuser 管理员信息
    /// </summary>
    public class MTFCEvidenceInfor
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName
        {
            get;
            set;
        }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string telNum
        {
            get;
            set;
        }

        /// <summary>
        /// 楼号
        /// </summary>
        public string buildNum
        {
            get;
            set;
        }

        /// <summary>
        /// 房号 
        /// </summary>
        public string roomNum
        {
            get;
            set;
        }

        /// <summary>
        /// 第三方公司名称 
        /// </summary>
        public string thirdPartyCompanyName
        {
            get;
            set;
        }

        /// <summary>
        /// 缴费金额 
        /// </summary>
        public decimal payAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 购买日期 
        /// </summary>
        public string payDate
        {
            get;
            set;
        }

        /// <summary>
        /// 居住地 
        /// </summary>
        public string domicile
        {
            get;
            set;
        }

        /// <summary>
        /// 保存那些证据 
        /// </summary>
        public string evidences
        {
            get;
            set;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string great_time
        {
            get;
            set;
        }

        public int samDataNum {
            get;
            set;
        }

        /// <summary>
        /// 交费类型
        /// </summary>
        public int amountType
        {
            get;
            set;
        }
        
    }
}
