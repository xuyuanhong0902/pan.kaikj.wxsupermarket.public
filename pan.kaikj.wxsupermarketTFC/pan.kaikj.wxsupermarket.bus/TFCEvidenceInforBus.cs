/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  AdminUser
*版本号：  V1.0.0.0
*唯一标识：ba10e91f-8aed-40ed-ab28-3731477a72b1
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/13 22:54:40

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/13 22:54:40
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// AdminUser
    /// </summary>
    public class TFCEvidenceInforBus
    {
        /// <summary>
        /// 分页获取数据信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="acount"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetInfoPagList(int pagIndex, string userName, string buildNum, string amountType)
        {
            try
            {
                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<MTFCEvidenceInfor> pageListResult = new MPageListResult<MTFCEvidenceInfor>();

                //// 每页获取20条数据
                int pagSize = 50;

                //// 1、首先获取符号要求的数据总条数
                TFCEvidenceInforService service = new TFCEvidenceInforService();
                pageListResult.totalNum = service.GetInfoPagCount(userName, buildNum, amountType);
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    pagIndex = pagIndex > pageListResult.totalPage ? pageListResult.totalPage : pagIndex;

                    //// 3、获取具体的分页数据信息
                    pageListResult.dataList = service.GetInfoPagList(pagIndex, pagSize, userName, buildNum, amountType);

                    if (pageListResult.dataList != null && pageListResult.dataList.Count > 0)
                    {
                        decimal totalPay = 0M;
                        //// 对数据做一个加工，验证重复提交的数据
                        for (int i = 0; i < pageListResult.dataList.Count; i++)
                        {
                            pageListResult.dataList[i].samDataNum = pageListResult.dataList.FindAll(P => P.roomNum == pageListResult.dataList[i].roomNum && P.buildNum == pageListResult.dataList[i].buildNum).Count;
                            totalPay += pageListResult.dataList[i].payAmount;
                        }

                        //// 做一个数据汇总
                        pageListResult.dataList.Add(new MTFCEvidenceInfor() {
                            Id = "-1",
                            payAmount = totalPay,
                            userName="小计"
                        });
                    }
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;

                return JsonHelper.GetJson<MPageListResult<MTFCEvidenceInfor>>(pageListResult);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletById(string id)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    mwxResult.errmsg = "操作失败：ID不能为空！";
                }
                else
                {
                    if (!new TFCEvidenceInforService().Delet(id))
                    {
                        mwxResult.errmsg = "操作失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功";
                    }
                }
            }
            catch (Exception)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MTFCEvidenceInfor GetInfoById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return null;
                }
                else
                {
                    return new TFCEvidenceInforService().GetInfoById(id);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 新增平台用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Add(MTFCEvidenceInfor model)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                //// 数据合法性检查
                string checkResult = this.CheckAddInfor(model);
                if (!string.IsNullOrEmpty(checkResult))
                {
                    mwxResult.errmsg = checkResult;
                }
                else
                {
                    //// 时间相关参数赋值
                    model.great_time = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    model.Id = PublicTools.GetRandomNumberByTime();

                    //// 数据落地入库
                    if (!new TFCEvidenceInforService().Add(model))
                    {
                        mwxResult.errmsg = "提交失败";
                    }
                    else
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "提交成功";
                    }
                }
            }
            catch (Exception)
            {
                mwxResult.errmsg = "提交失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 验证数据的合法性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CheckAddInfor(MTFCEvidenceInfor model)
        {
            if (string.IsNullOrEmpty(model.userName))
            {
                return "姓名必填!";
            }

            if (string.IsNullOrEmpty(model.telNum))
            {
                return "手机号码必填!";
            }

            if (!PublicTools.CheckIsPhonNum(model.telNum))
            {
                return "手机号码格式有误!";
            }

            //// 检查手机号码是否已经被使用
            if (new TFCEvidenceInforService().CheckPhonHasUser(model.telNum) > 0)
            {
                return "该手机号码已经提交过数据!";
            }

            if (string.IsNullOrEmpty(model.roomNum))
            {
                return "房号必填!";
            }

            if (model.payAmount <= 0)
            {
                return "金额必填,且必须为正数!";
            }

            if (string.IsNullOrEmpty(model.payDate))
            {
                return "购买日期必填!";
            }

            return string.Empty;
        }

        /// <summary>
        /// 下载团购费信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="buildNum"></param>
        public void DownLoadTFCInfor(string path, string userName, string buildNum, string amountType)
        {
            List<MTFCEvidenceInfor> list = new TFCEvidenceInforService().GetInfoPagList(1, 500, userName, buildNum, amountType);

            if (list != null && list.Count > 0)
            {
                decimal totalPay = 0M;
                //// 对数据做一个加工，验证重复提交的数据
                for (int i = 0; i < list.Count; i++)
                {
                    totalPay = totalPay + list[i].payAmount;
                    list[i].samDataNum = list.FindAll(P => P.roomNum == list[i].roomNum && P.buildNum == list[i].buildNum).Count;
                }

                List<MTFCEvidenceInfor> totalList = new List<MTFCEvidenceInfor>();

                totalList.Add(new MTFCEvidenceInfor()
                {
                    Id = "-1",
                    telNum = string.Empty,
                    userName = "统计汇总"
                });

                //// 做一个数据汇总
                totalList.Add(new MTFCEvidenceInfor()
                {
                    Id = "-1",
                    telNum = totalPay.ToString("N2"),
                    userName = "总金额"
                });

                //// 总人数
                totalList.Add(new MTFCEvidenceInfor()
                {
                    Id = "-1",
                    telNum = list.Count.ToString(),
                    userName = "总人数"
                });


                //// 根据城市统计人数金额 domicile
                var domicileGroup = list.GroupBy(m => m.domicile).ToList();
                foreach (var item in domicileGroup)
                {
                    if (!string.IsNullOrEmpty(item.Key))
                    {
                        totalList.Add(new MTFCEvidenceInfor()
                        {
                            Id = "-1",
                            telNum = item.Count()+"人",
                            userName = item.Key
                        });
                    }
                }

                ///// 根据楼统计人数和金额
                var buildNumGroup = list.GroupBy(m => m.buildNum).ToList();
                foreach (var item in buildNumGroup)
                {
                    if (!string.IsNullOrEmpty(item.Key))
                    {
                        totalList.Add(new MTFCEvidenceInfor()
                        {
                            Id = "-1",
                            telNum = string.Format("{0}总计【{1}】人，总缴费【{2}】元",
                            item.Key == "17" ? "公寓" : item.Key + "栋",
                            item.Count().ToString(),
                            item.Sum(m => m.payAmount).ToString("N2")),
                            userName = item.Key == "17" ? "公寓" : item.Key + "栋"
                        });
                    }
                }

                //// 根据缴费类型统计
                var amountTypeGroup = list.GroupBy(m => m.amountType).ToList();
                foreach (var item in amountTypeGroup)
                {

                    totalList.Add(new MTFCEvidenceInfor()
                    {
                        Id = "-1",
                        telNum = string.Format("{0}总计【{1}】人，总缴费【{2}】元",
                        item.Key == 2 ? "会员费" : (item.Key == 3 ? "服务费" : "团购费"),
                        item.Count().ToString(),
                        item.Sum(m => m.payAmount).ToString("N2")),
                        userName = item.Key == 2 ? "会员费" : (item.Key == 3 ? "服务费" : "团购费")
                    });
                }

                list.AddRange(totalList);
                //// 根据居住位置统计人数
                ////   = list.Sum(it => it.MathScore);
                ////  chineseScoreSum2 = scoreList.Sum(it => it.ChineseScore);
                ////  engLishScoreSum2 = scoreList.Sum(it => it.EngLishScore);
                ////  physicsScoreSum2 = scoreList.Sum(it => it.PhysicsScore);


                TableToExcel(list, path);
            }
        }


        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        private void TableToExcel(List<MTFCEvidenceInfor> dataList, string file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx") { workbook = new HSSFWorkbook(); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
            if (workbook == null) { return; }
            ISheet sheet = workbook.CreateSheet("天府城团购费邻居信息");

            List<string> headName = new List<string>();
            headName.Add("用户名称");
            headName.Add("电话号码");
            headName.Add("楼号");
            headName.Add("房号");
            headName.Add("第三方公司名称");
            headName.Add("缴费类型");
            headName.Add("缴费金额");
            headName.Add("购买日期");
            headName.Add("居住地");
            headName.Add("保存那些证据");

            //表头  
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < headName.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(headName[i]);
            }

            //数据  
            for (int i = 0; i < dataList.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);

                ICell cell = row1.CreateCell(0);
                cell.SetCellValue(dataList[i].userName);
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }
                cell = row1.CreateCell(1);
                cell.SetCellValue(dataList[i].telNum);
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                if (dataList[i].Id=="-1")
                {
                    continue;
                }

                cell = row1.CreateCell(2);
                cell.SetCellValue(dataList[i].buildNum == "17" ? "公寓" : (dataList[i].buildNum + "栋"));
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                cell = row1.CreateCell(3);
                cell.SetCellValue(dataList[i].roomNum);
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                cell = row1.CreateCell(4);
                cell.SetCellValue(dataList[i].thirdPartyCompanyName);
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                cell = row1.CreateCell(5);
                cell.SetCellValue(dataList[i].amountType <= 1 ? "团购费" : (dataList[i].amountType == 2 ? "会员费" : "服务费"));
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                cell = row1.CreateCell(6);
                cell.SetCellValue(dataList[i].payAmount.ToString("N2"));
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                cell = row1.CreateCell(7);
                cell.SetCellValue(dataList[i].payDate);
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                cell = row1.CreateCell(8);
                cell.SetCellValue(dataList[i].domicile);
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }

                cell = row1.CreateCell(9);
                cell.SetCellValue(dataList[i].evidences);
                if (dataList[i].samDataNum > 1)
                {
                    cell.CellStyle = Getcellstyle(workbook);
                }
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }


        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.BLANK: //BLANK:  
                    return null;
                case CellType.BOOLEAN: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.NUMERIC: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.STRING: //STRING:  
                    return cell.StringCellValue;
                case CellType.ERROR: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.FORMULA: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }


        private ICellStyle Getcellstyle(IWorkbook wb)

        {

            ICellStyle cellStyle = wb.CreateCellStyle();


            //定义几种字体

            //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的

            ////IFont font12 = wb.CreateFont();

            ////font12.FontHeightInPoints = 10;

            ////font12.FontName = "微软雅黑";


            IFont font = wb.CreateFont();

            //// font.FontName = "微软雅黑";
            font.Color = HSSFColor.OLIVE_GREEN.RED.index;

            //font.Underline = 1;下划线

            //IFont fontcolorblue = wb.CreateFont();

            //fontcolorblue.Color = HSSFColor.OLIVE_GREEN.BLUE.index;

            //fontcolorblue.IsItalic = true;//下划线

            //fontcolorblue.FontName = "微软雅黑";

            ////边框

            //cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.DOTTED;

            //cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.HAIR;

            //cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.HAIR;

            //cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.DOTTED;

            ////边框颜色

            //cellStyle.BottomBorderColor = HSSFColor.OLIVE_GREEN.BLUE.index;

            //cellStyle.TopBorderColor = HSSFColor.OLIVE_GREEN.BLUE.index;


            //背景图形，我没有用到过。感觉很丑

            //cellStyle.FillBackgroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;

            //cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;

            //cellStyle.FillForegroundColor = HSSFColor.WHITE.index;

            //// cellStyle.FillPattern = FillPatternType.NO_FILL;

            //cellStyle.FillBackgroundColor = HSSFColor.MAROON.index;



            ////水平对齐

            //cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;


            ////垂直对齐

            //cellStyle.VerticalAlignment = VerticalAlignment.CENTER;


            //自动换行

            //cellStyle.WrapText = true;


            //缩进;当设置为1时，前面留的空白太大了。希旺官网改进。或者是我设置的不对

            //cellStyle.Indention = 0;


            //上面基本都是设共公的设置

            //下面列出了常用的字段类型

            cellStyle.SetFont(font);


            return cellStyle;
        }

    }
}
