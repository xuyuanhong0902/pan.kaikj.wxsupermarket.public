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
    public class Madminuser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string adminuserid
        {
            get;
            set;
        }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string account
        {
            get;
            set;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// 密码密码
        /// </summary>
        public string password
        {
            get;
            set;
        }

        /// <summary>
        /// 用户的性别 
        /// </summary>
        public int sex
        {
            get;
            set;
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int isDelete
        {
            get;
            set;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public int isEffective
        {
            get;
            set;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime great_time
        {
            get;
            set;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public string greatTime
        {
            get;
            set;
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime modify_time
        {
            get;
            set;
        }
    }
}
