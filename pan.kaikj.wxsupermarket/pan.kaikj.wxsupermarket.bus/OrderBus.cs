/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  OrderBus
*版本号：  V1.0.0.0
*唯一标识：3c27bb6b-7428-413a-9820-b149b43d6014
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/24 15:55:08

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/24 15:55:08
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoService;
using pan.kaikj.wxsupermarket.model;
using pan.kaikj.wxsupermarket.tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// OrderBus
    /// </summary>
    public class OrderBus
    {
        /// <summary>
        /// 分页获取订单数据信息
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="userId"></param>
        /// <param name="orderState"></param>
        /// <param name="productname"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public string GetOrderInfoPagList(int pagIndex, string userId, string userName, 
            int orderState, string productname, string startTime, string endTime, string groupOrderId, string orderId)
        {
            try
            {

                LogOpert.AddWeiXinMessage("获取订单列表：" + userId);

                //// 实现步骤
                //// 1、首先获取符号要求的数据总条数
                //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                //// 3、获取具体的分页数据信息

                MPageListResult<Morder> pageListResult = new MPageListResult<Morder>();

                //// 每页获取20条数据
                int pagSize = 20;

                //// 1、首先获取符号要求的数据总条数
                OrderService orderService = new OrderService();
                if (!string.IsNullOrEmpty(endTime))
                {
                    endTime = Convert.ToDateTime(endTime).AddDays(1).ToString("yyyy-MM-dd");
                }
                pageListResult.totalNum = orderService.GetOrderInfoPagCount(userId, userName, orderState,
                    productname, startTime, endTime,groupOrderId,  orderId);
                if (pageListResult.totalNum > 0)
                {
                    //// 2、根据获取到数据条数、每页数据量、页码。优化处理页面
                    pageListResult.totalPage = (int)Math.Ceiling((double)pageListResult.totalNum / pagSize);
                    pagIndex = pagIndex > pageListResult.totalPage ? pageListResult.totalPage : pagIndex;

                    //// 3、获取具体的分页数据信息
                    pageListResult.dataList = orderService.GetOrderInfoPagList(pagIndex, pagSize, userId, userName, orderState, 
                        productname, startTime, endTime, groupOrderId, orderId);
                }

                pageListResult.pagIndex = pagIndex;
                pageListResult.pagSize = pagSize;
                IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
                return JsonConvert.SerializeObject(pageListResult, Formatting.Indented, timeConverter);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 根据ID获取订单详情
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public List<Morder> GetOrderInfoById(string orderid)
        {
            try
            {
                Morder model = new OrderService().GetOrderInfoById(orderid);
                if (model != null)
                {
                    List<Morder> listModel = new List<Morder>();
                    listModel.Add(model);
                    return listModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string AddOrderByShoppingCart(string userId, string deliveryTime,
           string mailAddress,
string deliveryName,
string deliveryTell)
        {

            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    mwxResult.errmsg = "请先登录！";
                    return JsonHelper.GetJson<MwxResult>(mwxResult);
                }
                ///// 获取该用户的购物车全部商品
                List<MshoppingCart> mshoppingCartsList = new ShoppingCartBus().GetAllShoppingCartListBySserId(userId);

                if (mshoppingCartsList == null || mshoppingCartsList.Count < 0)
                {
                    mwxResult.errmsg = "请选择需要购买的产品！";
                    return JsonHelper.GetJson<MwxResult>(mwxResult);
                }
                else
                {
                    ///// 构建订单列表
                    List<Morder> modelList = new List<Morder>();
                    foreach (var item in mshoppingCartsList)
                    {
                        modelList.Add(new Morder()
                        {
                            buyNum = item.buyNum,
                            mailAddress = mailAddress + "-" + deliveryName + "-" + deliveryTell,
                            requireDeliveryTime = Convert.ToDateTime(deliveryTime),
                            deliveryTime = System.DateTime.MinValue,
                            receiptTime = System.DateTime.MinValue,

                            userId = item.userId,
                            userName = item.userName,
                            productId = item.productId,
                            productname = item.productname,
                            productformat = item.productformat,
                            origPrice = item.origPrice,
                            sellPrice = item.sellPrice,
                            totalPrice = item.sellPrice * item.buyNum,

                            shoppingCartId = item.shoppingCartId
                        });
                    }

                    mwxResult = this.AddOrder(modelList);
                    if (mwxResult.errcode == 0)
                    {
                        try
                        {
                            NewOrderNum.TotalNum = NewOrderNum.TotalNum + 1;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    return JsonHelper.GetJson<MwxResult>(mwxResult);
                }
            }
            catch (Exception)
            {
                mwxResult.errmsg = "下单失败！";
                return JsonHelper.GetJson<MwxResult>(mwxResult);
            }
        }

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MwxResult AddOrder(List<Morder> model)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                //// 数据合法性检查
                mwxResult.errmsg = this.CheckOrderInfro(model);

                if (!string.IsNullOrEmpty(mwxResult.errmsg))
                {
                    JsonHelper.GetJson<MwxResult>(mwxResult);
                }

                //// 数据落地入库
                if (!new OrderService().AddOrder(model))
                {
                    mwxResult.errmsg = "操作失败";
                }
                else
                {
                    mwxResult.errcode = 0;
                    mwxResult.errmsg = model[0].orderGroupId;
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return mwxResult;
        }

        /// <summary>
        /// 更新订单已完成
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public string UpdateOrderHasRecepit(string orderid)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(orderid))
                {
                    mwxResult.errmsg = "操作失败:请选中被操作的订单！";
                }
                else
                {
                    //// 获取一个新密码
                    string newPass = PublicTools.RandomCode(10);

                    //// 重置
                    if (!new OrderService().UpdateOrderState(orderid, 8))
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
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public string UpdateOrderHasRecepitByIds(string orderidS)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(orderidS))
                {
                    mwxResult.errmsg = "操作失败:请选中被操作的订单！";
                }
                else
                {
                    orderidS = orderidS.Trim(',');
                    //// 获取一个新密码
                    string newPass = PublicTools.RandomCode(10);

                    //// 重置
                    if (!new OrderService().UpdateOrderStateByIds(orderidS, 8))
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
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 更新订单状态(已取消)
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public string UpdateOrderHasCancleByIds(string orderidS)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(orderidS))
                {
                    mwxResult.errmsg = "操作失败:请选中被操作的订单！";
                }
                else
                {
                    orderidS = orderidS.Trim(',');
                    //// 获取一个新密码
                    string newPass = PublicTools.RandomCode(10);

                    //// 重置
                    if (!new OrderService().UpdateOrderStateByIds(orderidS, 2))
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
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        

        /// <summary>
        /// 检查订单数据的合法性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CheckOrderInfro(List<Morder> model)
        {

            //// 移除购买数量小于1的产品
            if (model == null)
            {
                model.RemoveAll(P => P.buyNum < 1);
            }

            if (model == null || model.Count < 1)
            {
                return "请选中需要购买的产品！";
            }

            if (model.Exists(p => string.IsNullOrEmpty(p.productId)))
            {
                return "产品信息有误，请重新下单！";
            }

            if (model.Exists(p => string.IsNullOrEmpty(p.userId)))
            {
                return "数据信息有误，请重新下单！";
            }

            if (model.Exists(p => p.buyNum < 1))
            {
                return "所购买的产品数量必须大于0，请重新下单！";
            }

            if (model.Exists(p => p.sellPrice <= 0))
            {
                return "产品价格有误，请重新下单！";
            }

            //// 初始化订单数据
            //// 生成主订单号
            DateTime dateTimeNow = System.DateTime.Now;
            string orderGroupId = PublicTools.GetRandomNumberByTime();

            model.ForEach(c =>
            {
                c.orderid = PublicTools.GetRandomNumberByTime();
                c.orderGroupId = orderGroupId;
                c.payType = 1;
                c.payTypeDesc = "货到付款";
                c.orderState = 4;
                c.orderStateDesc = "下单成功，等待送货";
                c.isDelete = "0";
                c.isEffective = "1";
                c.great_time = dateTimeNow;
                c.modify_time = dateTimeNow;
            });

            return string.Empty;
        }

        /// <summary>
        /// 根据ID获取一个订单model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Morder GetOrderInfroById(string id)
        {
            Morder morder = null;
            try
            {

                morder = new OrderService().GetOrderInfoById(id);
            }
            catch (Exception ex)
            {

            }

            return morder != null ? morder : new Morder();
        }

        /// <summary>
        /// 跟新送货信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        public string UpdateOrderStateToDelivery(string orderid, string deliveryName, string deliveryTell)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(orderid))
                {
                    mwxResult.errmsg = "操作失败:请选中被操作的订单！";
                }
                else
                {
                    //// 重置
                    if (!new OrderService().UpdateOrderStateToDelivery(orderid, deliveryName, deliveryTell))
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
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 跟新送货信息(批量)
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        public string UpdateOrderStateToDelivery(string orderids, string sendGoodUserId)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(orderids))
                {
                    mwxResult.errmsg = "操作失败:请选中被操作的订单！";
                }
                else
                {
                    orderids = orderids.Trim(',');
                    //// 根据送货人ID获取送货人信息

                    MsendGoodsUser model = new SndGoodsUserBus().GetSendGoodsUserModelById(sendGoodUserId);
                    if (model==null)
                    {
                        mwxResult.errmsg = "操作失败:请选择正确的送货员信息！";
                    }
                    else
                    {
                        //// 重置
                        if (!new OrderService().UpdateOrderStateToDelivery(orderids, model.userName, model.phone))
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
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败：系统异常！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 根据订单组Id获取订单列表
        /// </summary>
        /// <param name="orderGroupId"></param>
        /// <returns></returns>
        public List<Morder> GetOrderInfoByGroupId(string orderGroupId)
        {
            if (string.IsNullOrEmpty(orderGroupId))
            {
                return null;
            }
            return new OrderService().GetOrderInfoByGroupId(orderGroupId);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public string UpdateOrderStateByGroupid(string orderGroupId, int orderState)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(orderGroupId))
                {
                    mwxResult.errmsg = "参数有误！";
                }
                else
                {
                    if (new OrderService().UpdateOrderStateByGroupid(orderGroupId, orderState))
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功！";
                    }
                    else
                    {
                        mwxResult.errmsg = "操作失败！";
                    }
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败,系统错误！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public string UpdateOrderState(string orderId, int orderState)
        {
            MwxResult mwxResult = new MwxResult()
            {
                errcode = -1
            };

            try
            {
                if (string.IsNullOrEmpty(orderId))
                {
                    mwxResult.errmsg = "参数有误！";
                }
                else
                {
                    if (new OrderService().UpdateOrderState(orderId, orderState))
                    {
                        mwxResult.errcode = 0;
                        mwxResult.errmsg = "操作成功！";
                    }
                    else
                    {
                        mwxResult.errmsg = "操作失败！";
                    }
                }
            }
            catch (Exception ex)
            {
                mwxResult.errmsg = "操作失败,系统错误！";
            }

            return JsonHelper.GetJson<MwxResult>(mwxResult);
        }

        public Mstatic Static()
        {
            try
            {
                return new OrderService().Static();
            }
            catch (Exception ex)
            {
                return new Mstatic();
            }
        }

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        public MstaticSendOrder SaticSendGoodesCount()
        {
            try
            {
                return new OrderService().SaticSendGoodesCount();
            }
            catch (Exception ex)
            {
                return new MstaticSendOrder();
            }
        }

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        public int SaticSendGoodesTotaCount()
        {
            try
            {
                return new OrderService().SaticSendGoodesTotaCount();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取新订单数据
        /// </summary>
        /// <returns></returns>
        public int GetTotalNewOrder()
        {

            try
            {
                int totalNum = NewOrderNum.TotalNum;
                NewOrderNum.TotalNum = 0;

                return totalNum;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
