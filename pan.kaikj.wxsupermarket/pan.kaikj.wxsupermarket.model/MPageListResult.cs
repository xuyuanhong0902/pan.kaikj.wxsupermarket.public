/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.model
*文件名：  MPageListResult
*版本号：  V1.0.0.0
*唯一标识：3832abfc-e083-475b-bc74-800c9cc560f6
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/13 22:59:58

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/13 22:59:58
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

namespace pan.kaikj.wxsupermarket.model
{
    /// <summary>
    /// MPageListResult
    /// </summary>
    public class MPageListResult<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public int totalNum
        {
            get;
            set;
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int pagIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 总页码
        /// </summary>
        public int totalPage{
            get;
            set;
        }

        /// <summary>
        /// 每页数据条数
        /// </summary>
        public int pagSize {
            get;
            set;
        }

        /// <summary>
        /// 具体数据集合
        /// </summary>
        public List<T> dataList {
            get;
            set;
        }
    }
}
