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
    using System;
    using System.Collections.Generic;
    
    public partial class MmailAddress
    {
        public string addressId { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        public string detailedAddress { get; set; }
        public string contactName { get; set; }
        public string contactTell { get; set; }
        public string isDefault { get; set; }
        public string isDelete { get; set; }
        public string isEffective { get; set; }
        public DateTime great_time { get; set; }
        public DateTime modify_time { get; set; }
    }
}
