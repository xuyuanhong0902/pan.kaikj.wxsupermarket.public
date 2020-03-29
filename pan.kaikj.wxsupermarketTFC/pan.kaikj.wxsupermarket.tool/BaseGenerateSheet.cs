/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.tool
*文件名：  BaseGenerateSheet
*版本号：  V1.0.0.0
*唯一标识：bb37934a-cf26-4814-a8f8-2fb6ee6e2341
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/10/27 19:45:44

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/10/27 19:45:44
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.tool
{
    /// <summary>
    /// BaseGenerateSheet
    /// </summary>
    public abstract class BaseGenerateSheet
    {
        public string SheetName { set; get; }

        public IWorkbook Workbook { get; set; }

        public virtual void GenSheet(ISheet sheet)
        {

        }
    }
}
