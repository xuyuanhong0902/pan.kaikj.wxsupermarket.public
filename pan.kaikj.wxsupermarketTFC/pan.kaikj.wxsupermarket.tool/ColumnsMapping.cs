/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.tool
*文件名：  ColumnsMapping
*版本号：  V1.0.0.0
*唯一标识：4acffcd8-8cec-41b8-a32b-8e3e68c46f12
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/10/27 19:45:20

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/10/27 19:45:20
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

namespace pan.kaikj.wxsupermarket.tool
{
    /// <summary>
    /// ColumnsMapping
    /// </summary>
    public class ColumnsMapping
    {
        #region 属性
        /// <summary>
        /// Excel 列头显示的值
        /// </summary>
        public string ColumnsText { get; set; }
        /// <summary>
        /// Excel 列绑定对像的属性, 可以为空
        /// </summary>
        public string ColumnsData { get; set; }
        /// <summary>
        /// Excel 列的宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 是否需要总计行
        /// </summary>
        public bool IsTotal { get; set; }
        /// <summary>
        /// Excel列的索引
        /// </summary>
        public int ColumnsIndex { get; set; }
        #endregion

        #region 构造方法
        /// <summary>
        /// Excel列头的相关设置
        /// </summary>
        public ColumnsMapping() { }
        /// <summary>
        /// Excel列头的相关设置
        /// </summary>
        public ColumnsMapping(string colText, string colData, int width, int colIndex, bool _isTotal)
        {
            this.ColumnsText = colText;
            this.ColumnsData = colData;
            this.Width = width;
            this.IsTotal = _isTotal;
            this.ColumnsIndex = colIndex;
        }
        #endregion
    }
}
