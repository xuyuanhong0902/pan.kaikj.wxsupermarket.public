/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoDal
*文件名：  OrderDal
*版本号：  V1.0.0.0
*唯一标识：c04d063b-e95d-4db6-8148-28bd989774c5
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 18:29:21

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 18:29:21
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoIdal;
using pan.kaikj.wxsupermarket.AdoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using pan.kaikj.wxsupermarket.AdoSqlHelper;
namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// OrderDal
    /// </summary>
    public class OrderDal : OrderIdal
    {
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrder(List<Morder> model)
        {

            //// sql语句
            string sql = "INSERT INTO [order] (orderid,orderGroupId,userId,userName,productId,productname,productformat,buyNum,origPrice,sellPrice,totalPrice,payType,payTypeDesc,requireDeliveryTime,orderState,orderStateDesc,mailAddress,isDelete,isEffective,great_time,modify_time) VALUES";
            string deleteShoppingCart = " ;delete from shoppingCart where shoppingCartId in(";
            bool hasShoppingCart = false;

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = null;
            for (int i = 0; i < model.Count; i++)
            {
                sql = string.Format("{0} (@orderid{1},@orderGroupId{1},@userId{1},@userName{1},@productId{1},@productname{1},@productformat{1},@buyNum{1},@origPrice{1},@sellPrice{1},@totalPrice{1},@payType{1},@payTypeDesc{1},@requireDeliveryTime{1},@orderState{1},@orderStateDesc{1},@mailAddress{1},@isDelete{1},@isEffective{1},@great_time{1},@modify_time{1}),", sql, i);

                parameter = new MySqlParameter("@orderid" + i, MySqlDbType.VarChar, 25);
                parameter.Value = model[i].orderid;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@orderGroupId" + i, MySqlDbType.VarChar, 25);
                parameter.Value = model[i].orderGroupId;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@userId" + i, MySqlDbType.VarChar, 25);
                parameter.Value = model[i].userId;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@userName" + i, MySqlDbType.VarChar, 50);
                parameter.Value = model[i].userName;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@productId" + i, MySqlDbType.VarChar, 25);
                parameter.Value = model[i].productId;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@productname" + i, MySqlDbType.VarChar, 100);
                parameter.Value = model[i].productname;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@productformat" + i, MySqlDbType.VarChar, 50);
                parameter.Value = model[i].productformat;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@buyNum" + i, SqlDbType.Int);
                parameter.Value = model[i].buyNum;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@origPrice" + i, SqlDbType.Decimal);
                parameter.Value = model[i].origPrice;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@sellPrice" + i, SqlDbType.Decimal);
                parameter.Value = model[i].sellPrice;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@totalPrice" + i, SqlDbType.Decimal);
                parameter.Value = model[i].totalPrice;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@payType" + i, SqlDbType.Int);
                parameter.Value = model[i].payType;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@payTypeDesc" + i, MySqlDbType.VarChar, 20);
                parameter.Value = model[i].payTypeDesc;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@requireDeliveryTime" + i, SqlDbType.DateTime);
                parameter.Value = model[i].requireDeliveryTime;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@orderState" + i, SqlDbType.Int);
                parameter.Value = model[i].orderState;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@orderStateDesc" + i, MySqlDbType.VarChar, 20);
                parameter.Value = model[i].orderStateDesc;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@mailAddress" + i, MySqlDbType.VarChar, 100);
                parameter.Value = model[i].mailAddress;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@isDelete" + i, MySqlDbType.Int16, 1);
                parameter.Value = model[i].isDelete;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@isEffective" + i, MySqlDbType.Int16, 1);
                parameter.Value = model[i].isEffective;
                parameterList.Add(parameter);

                DateTime dateTime = System.DateTime.Now;
                parameter = new MySqlParameter("@great_time" + i, SqlDbType.DateTime);
                parameter.Value = dateTime;
                parameterList.Add(parameter);

                parameter = new MySqlParameter("@modify_time" + i, SqlDbType.DateTime);
                parameter.Value = dateTime;
                parameterList.Add(parameter);

                //// 构建删除对应购物车信息
                if (!string.IsNullOrEmpty(model[i].shoppingCartId))
                {
                    deleteShoppingCart = deleteShoppingCart + " @shoppingCartId" + i + ",";
                    parameter = new MySqlParameter("@shoppingCartId" + i, MySqlDbType.VarChar, 25);
                    parameter.Value = model[i].shoppingCartId;
                    parameterList.Add(parameter);
                    hasShoppingCart = true;
                }
            }

            //// 删除所对应的购物车信息
            sql = sql.TrimEnd(',') + (hasShoppingCart ? deleteShoppingCart.TrimEnd(',') + ")" : string.Empty);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public bool UpdateOrderState(string orderid, int orderState)
        {

            string orderStateDesc = this.GetOrserStateDesc(orderState);
            string sql = "update [order] set orderState=@orderState,orderStateDesc=@orderStateDesc,modify_time=@modify_time ";

            //// 如果更新为7（确认收货，交易结束 那么需要更新确认收货时间）
            if (orderState == 8)
            {
                sql = sql + " , receiptTime=@modify_time ";
            }

            sql = sql + " where orderid = @orderid;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@orderid", MySqlDbType.VarChar, 25);
            parameter.Value = orderid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderState", SqlDbType.Int);
            parameter.Value = orderState;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderStateDesc", MySqlDbType.VarChar, 20);
            parameter.Value = orderStateDesc;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@modify_time", SqlDbType.DateTime);
            parameter.Value = System.DateTime.Now;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public bool UpdateOrderStateByGroupid(string orderGroupId, int orderState)
        {

            string orderStateDesc = this.GetOrserStateDesc(orderState);
            string sql = "update [order] set orderState=@orderState,orderStateDesc=@orderStateDesc,modify_time=@modify_time ";

            //// 如果更新为7（确认收货，交易结束 那么需要更新确认收货时间）
            if (orderState == 8)
            {
                sql = sql + " , receiptTime=@modify_time ";
            }

            sql = sql + " where orderGroupId = @orderGroupId;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@orderGroupId", MySqlDbType.VarChar, 25);
            parameter.Value = orderGroupId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderState", SqlDbType.Int);
            parameter.Value = orderState;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderStateDesc", MySqlDbType.VarChar, 20);
            parameter.Value = orderStateDesc;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@modify_time", SqlDbType.DateTime);
            parameter.Value = System.DateTime.Now;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="orderState"></param>
        /// <returns></returns>
        public bool UpdateOrderStateByIds(string orderidS, int orderState)
        {

            string orderStateDesc = this.GetOrserStateDesc(orderState);
            string sql = "update [order] set orderState=@orderState,orderStateDesc=@orderStateDesc,modify_time=@modify_time ";

            //// 如果更新为7（确认收货，交易结束 那么需要更新确认收货时间）
            if (orderState == 8)
            {
                sql = sql + " , receiptTime=@modify_time ";
            }

            sql = sql + " where orderid in  (" + orderidS + ");";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@orderid", MySqlDbType.VarChar);
            parameter.Value = orderidS;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderState", SqlDbType.Int);
            parameter.Value = orderState;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderStateDesc", MySqlDbType.VarChar, 20);
            parameter.Value = orderStateDesc;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@modify_time", SqlDbType.DateTime);
            parameter.Value = System.DateTime.Now;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据订单状态为送货中
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        public bool UpdateOrderStateToDelivery(string orderid, string deliveryName, string deliveryTell)
        {

            string sql = "update [order] set orderState=7,orderStateDesc='送货中',deliveryName=@deliveryName,deliveryTell=@deliveryTell,deliveryTime=@deliveryTime,modify_time=@deliveryTime where  orderid in  (" + orderid + ");";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@orderid", MySqlDbType.VarChar, 25);
            parameter.Value = orderid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@deliveryName", MySqlDbType.VarChar, 20);
            parameter.Value = deliveryName;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@deliveryTell", MySqlDbType.VarChar, 20);
            parameter.Value = deliveryTell;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@deliveryTime", SqlDbType.DateTime);
            parameter.Value = System.DateTime.Now;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;

        }

        /// <summary>
        /// 根据订单状态为送货中
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="deliveryName"></param>
        /// <param name="deliveryTell"></param>
        /// <returns></returns>
        public bool UpdateOrderStateToDeliveryByGroupid(string orderGroupId, string deliveryName, string deliveryTell)
        {

            string sql = "update [order] set orderState=7,orderStateDesc='送货中',deliveryName=@deliveryName,deliveryTell=@deliveryTell,deliveryTime=@deliveryTime,modify_time=@deliveryTime where orderGroupId=@orderGroupId ;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@orderGroupId", MySqlDbType.VarChar, 25);
            parameter.Value = orderGroupId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@deliveryName", MySqlDbType.VarChar, 20);
            parameter.Value = deliveryName;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@deliveryTell", MySqlDbType.VarChar, 20);
            parameter.Value = deliveryTell;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@deliveryTime", SqlDbType.DateTime);
            parameter.Value = System.DateTime.Now;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;

        }

        /// <summary>
        /// 根据条件获取分页数据总条数
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderState"></param>
        /// <param name="productname"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int GetOrderInfoPagCount(string userId, string userName, int orderState, string productname,
            string startTime, string endTime, string orderGroupId, string orderid)
        {
            string sql = " SELECT count(orderid) as totalCount  FROM [order] WHERE 1=1 ";

            if (!string.IsNullOrEmpty(userId))
            {
                sql = sql + " and userId = @userId";
            }

            if (orderState > 0)
            {
                sql = sql + " and orderState = @orderState";
            }

            if (!string.IsNullOrEmpty(userName))
            {
                sql = sql + " and userName like @userName";
            }

            if (!string.IsNullOrEmpty(orderGroupId))
            {
                sql = sql + " and orderGroupId = @orderGroupId";
            }

            if (!string.IsNullOrEmpty(orderid))
            {
                sql = sql + " and orderid = @orderid";
            }

            if (!string.IsNullOrEmpty(productname))
            {
                sql = sql + " and productname like @productname";
            }

            if (!string.IsNullOrEmpty(startTime))
            {
                sql = sql + " and great_time >=@startTime";
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                sql = sql + " and great_time <@endTime";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@userId", MySqlDbType.VarChar);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderState", SqlDbType.Int);
            parameter.Value = orderState;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productname", MySqlDbType.VarChar, 100);
            parameter.Value = "%" + productname + "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@userName", MySqlDbType.VarChar, 50);
            parameter.Value = "%" + userName + "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@startTime", SqlDbType.VarChar);
            parameter.Value = startTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@endTime", SqlDbType.VarChar);
            parameter.Value = endTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderid", MySqlDbType.VarChar, 25);
            parameter.Value = orderid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderGroupId", MySqlDbType.VarChar, 25);
            parameter.Value = orderGroupId;
            parameterList.Add(parameter);

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    if (sqlDataReader.Read())
                    {
                        return (sqlDataReader["totalCount"] != DBNull.Value) ? Convert.ToInt32(sqlDataReader["totalCount"].ToString()) : 0;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// 分页获取数据集合
        /// </summary>
        /// <param name="pagIndex"></param>
        /// <param name="pagCount"></param>
        /// <param name="userId"></param>
        /// <param name="orderState"></param>
        /// <param name="productname"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<Morder> GetOrderInfoPagList(int pagIndex, int pagCount, string userId, string userName, int orderState,
            string productname, string startTime, string endTime, string orderGroupId, string orderid)
        {
            string sql = " SELECT  TOP " + pagCount * pagIndex + " orderid,orderGroupId,userId,userName,productId,productname,productformat,buyNum,origPrice,sellPrice,totalPrice,payType,payTypeDesc,requireDeliveryTime,orderState,orderStateDesc,mailAddress,deliveryName,deliveryTell,deliveryTime,receiptTime,isDelete,isEffective,great_time,modify_time   " +
                   " FROM( SELECT ROW_NUMBER() OVER(ORDER BY great_time DESC) AS ROWID,* FROM [order]) AS TEMP1  WHERE ROWID> " + pagCount * (pagIndex - 1);

            if (!string.IsNullOrEmpty(userId))
            {
                sql = sql + " and userId = @userId";
            }

            if (orderState > 0)
            {
                sql = sql + " and orderState = @orderState";
            }

            if (!string.IsNullOrEmpty(userName))
            {
                sql = sql + " and userName like @userName";
            }

            if (!string.IsNullOrEmpty(orderGroupId))
            {
                sql = sql + " and orderGroupId = @orderGroupId";
            }

            if (!string.IsNullOrEmpty(orderid))
            {
                sql = sql + " and orderid = @orderid";
            }

            if (!string.IsNullOrEmpty(productname))
            {
                sql = sql + " and productname like @productname";
            }

            if (!string.IsNullOrEmpty(startTime))
            {
                sql = sql + " and great_time >=@startTime";
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                sql = sql + " and great_time <@endTime";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@userId", MySqlDbType.VarChar);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderState", SqlDbType.Int);
            parameter.Value = orderState;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productname", MySqlDbType.VarChar, 100);
            parameter.Value = "%" + productname + "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@userName", MySqlDbType.VarChar, 50);
            parameter.Value = "%" + userName + "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@startTime", SqlDbType.VarChar);
            parameter.Value = startTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@endTime", SqlDbType.VarChar);
            parameter.Value = endTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderid", MySqlDbType.VarChar, 25);
            parameter.Value = orderid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@orderGroupId", MySqlDbType.VarChar, 25);
            parameter.Value = orderGroupId;
            parameterList.Add(parameter);

            List<Morder> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<Morder>();
                    while (sqlDataReader.Read())
                    {
                        Morder model = new Morder();
                        model.orderid = sqlDataReader["orderid"] != DBNull.Value ? sqlDataReader["orderid"].ToString() : string.Empty;
                        model.orderGroupId = sqlDataReader["orderGroupId"] != DBNull.Value ? sqlDataReader["orderGroupId"].ToString() : string.Empty;
                        model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.productId = sqlDataReader["productId"] != DBNull.Value ? sqlDataReader["productId"].ToString() : string.Empty;

                        model.productname = sqlDataReader["productname"] != DBNull.Value ? sqlDataReader["productname"].ToString() : string.Empty;
                        model.productformat = sqlDataReader["productformat"] != DBNull.Value ? sqlDataReader["productformat"].ToString() : string.Empty;
                        model.buyNum = sqlDataReader["buyNum"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["buyNum"].ToString()) : 0;
                        model.origPrice = sqlDataReader["origPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["origPrice"].ToString()) : 0M;
                        model.sellPrice = sqlDataReader["sellPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["sellPrice"].ToString()) : 0M;
                        model.totalPrice = sqlDataReader["totalPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["totalPrice"].ToString()) : 0M;

                        model.payType = sqlDataReader["payType"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["payType"].ToString()) : 0;
                        model.payTypeDesc = sqlDataReader["payTypeDesc"] != DBNull.Value ? sqlDataReader["payTypeDesc"].ToString() : string.Empty;
                        model.requireDeliveryTime = sqlDataReader["requireDeliveryTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["requireDeliveryTime"].ToString()) : DateTime.MinValue;
                        model.orderState = sqlDataReader["orderState"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["orderState"].ToString()) : 0;
                        model.orderStateDesc = sqlDataReader["orderStateDesc"] != DBNull.Value ? sqlDataReader["orderStateDesc"].ToString() : string.Empty;

                        model.mailAddress = sqlDataReader["mailAddress"] != DBNull.Value ? sqlDataReader["mailAddress"].ToString() : string.Empty;
                        model.deliveryName = sqlDataReader["deliveryName"] != DBNull.Value ? sqlDataReader["deliveryName"].ToString() : string.Empty;
                        model.deliveryTell = sqlDataReader["deliveryTell"] != DBNull.Value ? sqlDataReader["deliveryTell"].ToString() : string.Empty;
                        model.deliveryTime = sqlDataReader["deliveryTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["deliveryTime"].ToString()) : DateTime.MinValue;
                        model.receiptTime = sqlDataReader["receiptTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["receiptTime"].ToString()) : DateTime.MinValue;

                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }

        /// <summary>
        /// 根据产品ID获取model
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public Morder GetOrderInfoById(string orderid)
        {
            string sql = " SELECT orderid,orderGroupId,userId,userName,productId,productname,productformat,buyNum,origPrice,sellPrice,totalPrice,payType,payTypeDesc,requireDeliveryTime,orderState,orderStateDesc,mailAddress,deliveryName,deliveryTell,deliveryTime,receiptTime,isDelete,isEffective,great_time,modify_time  FROM [order] where orderid=@orderid";
            MySqlParameter[] parameterList = new MySqlParameter[1];
            parameterList[0] = new MySqlParameter("@orderid", MySqlDbType.VarChar, 25);
            parameterList[0].Value = orderid;

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader != null)
                {
                    if (sqlDataReader.Read())
                    {
                        Morder model = new Morder();
                        model.orderid = sqlDataReader["orderid"] != DBNull.Value ? sqlDataReader["orderid"].ToString() : string.Empty;
                        model.orderGroupId = sqlDataReader["orderGroupId"] != DBNull.Value ? sqlDataReader["orderGroupId"].ToString() : string.Empty;
                        model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.productId = sqlDataReader["productId"] != DBNull.Value ? sqlDataReader["productId"].ToString() : string.Empty;

                        model.productname = sqlDataReader["productname"] != DBNull.Value ? sqlDataReader["productname"].ToString() : string.Empty;
                        model.productformat = sqlDataReader["productformat"] != DBNull.Value ? sqlDataReader["productformat"].ToString() : string.Empty;
                        model.buyNum = sqlDataReader["buyNum"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["buyNum"].ToString()) : 0;
                        model.origPrice = sqlDataReader["origPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["origPrice"].ToString()) : 0M;
                        model.sellPrice = sqlDataReader["sellPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["sellPrice"].ToString()) : 0M;
                        model.totalPrice = sqlDataReader["totalPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["totalPrice"].ToString()) : 0M;

                        model.payType = sqlDataReader["payType"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["payType"].ToString()) : 0;
                        model.payTypeDesc = sqlDataReader["payTypeDesc"] != DBNull.Value ? sqlDataReader["payTypeDesc"].ToString() : string.Empty;
                        model.requireDeliveryTime = sqlDataReader["requireDeliveryTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["requireDeliveryTime"].ToString()) : DateTime.MaxValue;
                        model.orderState = sqlDataReader["orderState"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["orderState"].ToString()) : 0;
                        model.orderStateDesc = sqlDataReader["orderStateDesc"] != DBNull.Value ? sqlDataReader["orderStateDesc"].ToString() : string.Empty;

                        model.mailAddress = sqlDataReader["mailAddress"] != DBNull.Value ? sqlDataReader["mailAddress"].ToString() : string.Empty;
                        model.deliveryName = sqlDataReader["deliveryName"] != DBNull.Value ? sqlDataReader["deliveryName"].ToString() : string.Empty;
                        model.deliveryTell = sqlDataReader["deliveryTell"] != DBNull.Value ? sqlDataReader["deliveryTell"].ToString() : string.Empty;
                        model.receiptTime = sqlDataReader["receiptTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["receiptTime"].ToString()) : DateTime.MinValue;
                        model.deliveryTime = sqlDataReader["deliveryTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["deliveryTime"].ToString()) : DateTime.MinValue;

                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;

                        return model;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 获取订单状态描述
        /// </summary>
        /// <param name="orderState"></param>
        /// <returns></returns>
        private string GetOrserStateDesc(int orderState)
        {
            switch (orderState)
            {
                case 1:
                    return "新订单，等待支付";
                case 2:
                    return "取消支付，交易结束";
                case 3:
                    return "支付成功，等待送货";
                case 4:
                    return "下单成功，等待送货";
                case 5:
                    return "取消等待，等待退款";
                case 6:
                    return "退款完成，交易结束";
                case 7:
                    return "送货中";
                case 8:
                    return "确认收货，交易结束";
            }

            return string.Empty;
        }

        /// <summary>
        /// 根据订单组Id获取订单列表
        /// </summary>
        /// <param name="orderGroupId"></param>
        /// <returns></returns>
        public List<Morder> GetOrderInfoByGroupId(string orderGroupId)
        {
            string sql = " SELECT orderid,orderGroupId,userId,userName,productId,productname,productformat,buyNum,origPrice,sellPrice,totalPrice,payType,payTypeDesc,requireDeliveryTime,orderState,orderStateDesc,mailAddress,deliveryName,deliveryTell,deliveryTime,receiptTime,isDelete,isEffective,great_time,modify_time  FROM [order] where orderGroupId=@orderGroupId";
            MySqlParameter[] parameterList = new MySqlParameter[1];
            parameterList[0] = new MySqlParameter("@orderGroupId", MySqlDbType.VarChar, 25);
            parameterList[0].Value = orderGroupId;

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader != null)
                {
                    List<Morder> listModel = new List<Morder>();
                    while (sqlDataReader.Read())
                    {
                        Morder model = new Morder();
                        model.orderid = sqlDataReader["orderid"] != DBNull.Value ? sqlDataReader["orderid"].ToString() : string.Empty;
                        model.orderGroupId = sqlDataReader["orderGroupId"] != DBNull.Value ? sqlDataReader["orderGroupId"].ToString() : string.Empty;
                        model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.productId = sqlDataReader["productId"] != DBNull.Value ? sqlDataReader["productId"].ToString() : string.Empty;

                        model.productname = sqlDataReader["productname"] != DBNull.Value ? sqlDataReader["productname"].ToString() : string.Empty;
                        model.productformat = sqlDataReader["productformat"] != DBNull.Value ? sqlDataReader["productformat"].ToString() : string.Empty;
                        model.buyNum = sqlDataReader["buyNum"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["buyNum"].ToString()) : 0;
                        model.origPrice = sqlDataReader["origPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["origPrice"].ToString()) : 0M;
                        model.sellPrice = sqlDataReader["sellPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["sellPrice"].ToString()) : 0M;
                        model.totalPrice = sqlDataReader["totalPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["totalPrice"].ToString()) : 0M;

                        model.payType = sqlDataReader["payType"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["payType"].ToString()) : 0;
                        model.payTypeDesc = sqlDataReader["payTypeDesc"] != DBNull.Value ? sqlDataReader["payTypeDesc"].ToString() : string.Empty;
                        model.requireDeliveryTime = sqlDataReader["requireDeliveryTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["requireDeliveryTime"].ToString()) : DateTime.MaxValue;
                        model.orderState = sqlDataReader["orderState"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["orderState"].ToString()) : 0;
                        model.orderStateDesc = sqlDataReader["orderStateDesc"] != DBNull.Value ? sqlDataReader["orderStateDesc"].ToString() : string.Empty;

                        model.mailAddress = sqlDataReader["mailAddress"] != DBNull.Value ? sqlDataReader["mailAddress"].ToString() : string.Empty;
                        model.deliveryName = sqlDataReader["deliveryName"] != DBNull.Value ? sqlDataReader["deliveryName"].ToString() : string.Empty;
                        model.deliveryTell = sqlDataReader["deliveryTell"] != DBNull.Value ? sqlDataReader["deliveryTell"].ToString() : string.Empty;
                        model.receiptTime = sqlDataReader["receiptTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["receiptTime"].ToString()) : DateTime.MinValue;
                        model.deliveryTime = sqlDataReader["deliveryTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["deliveryTime"].ToString()) : DateTime.MinValue;

                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;

                        listModel.Add(model);
                    }

                    return listModel;
                }
            }

            return null;
        }

        public Mstatic Static()
        {
            Mstatic model = new Mstatic();
            string sql = string.Format(@"select COUNT(1) as totalCount,SUM(totalPrice) as totalPrice from [order] where 1=1;
                                        select COUNT(1) as successTotalCount,SUM(totalPrice) as successTotalPrice from[order]
                                        where orderState not in(1, 2, 5, 6);
                                                    select COUNT(1) as totayTotalCount,SUM(totalPrice) as totayTotalPrice from[order]where 1 = 1
                                        and great_time between '{0}' and '{1}';
                                                    select COUNT(1) as totaySuccessTotalCount,SUM(totalPrice) as totaySuccessTotalPrice from[order]
                                        where orderState not in(1, 2, 5, 6) and great_time between '{0}' and '{1}';
                                                    select COUNT(1) as yesterdayTotalCount,SUM(totalPrice) as yesterdayTotalPrice from[order]where 1 = 1
                                        and great_time between '{2}' and '{0}';
                                                    select COUNT(1) as yesterdaySuccessTotalCount,SUM(totalPrice) as yesterdaySuccessTotalPrice from[order]
                                        where orderState not in(1, 2, 5, 6) and great_time between '{2}' and '{0}';
                                        select COUNT(1) as count,shelfstate from product group by shelfstate;
                                        select COUNT(1) as daiSendGoodsCount from[order] where orderState = 4;
                                        select COUNT(1) as sendGoodsCount from[order] where orderState = 7;
                                        ", System.DateTime.Now.ToString("yyyy-MM-dd"),
                                        System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                                        System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));

            DataSet resultTable = PKMySqlHelper.ExecuteDataSet(sql, null);

            if (resultTable != null && resultTable.Tables != null && resultTable.Tables.Count > 8)
            {
                DataTable totalTable = resultTable.Tables[0];
                if (totalTable != null && totalTable.Rows.Count > 0)
                {
                    model.totalCount = totalTable.Rows[0]["totalCount"] != DBNull.Value ?
                        Convert.ToInt32(totalTable.Rows[0]["totalCount"].ToString()) : 0;
                    model.totalPrice = totalTable.Rows[0]["totalPrice"] != DBNull.Value ?
                        Convert.ToDecimal(totalTable.Rows[0]["totalPrice"].ToString()) : 0M;
                }

                DataTable successTotalTable = resultTable.Tables[1];
                if (successTotalTable != null && successTotalTable.Rows.Count > 0)
                {
                    model.successTotatlCount = successTotalTable.Rows[0]["successTotalCount"] != DBNull.Value ?
                        Convert.ToInt32(successTotalTable.Rows[0]["successTotalCount"].ToString()) : 0;
                    model.successTotalPrice = successTotalTable.Rows[0]["successTotalPrice"] != DBNull.Value ?
                        Convert.ToDecimal(successTotalTable.Rows[0]["successTotalPrice"].ToString()) : 0M;
                }

                DataTable totayTotalTable = resultTable.Tables[2];
                if (totayTotalTable != null && totayTotalTable.Rows.Count > 0)
                {
                    model.totayTotalCount = totayTotalTable.Rows[0]["totayTotalCount"] != DBNull.Value ?
                        Convert.ToInt32(totayTotalTable.Rows[0]["totayTotalCount"].ToString()) : 0;
                    model.totayTotalPrice = totayTotalTable.Rows[0]["totayTotalPrice"] != DBNull.Value ?
                        Convert.ToDecimal(totayTotalTable.Rows[0]["totayTotalPrice"].ToString()) : 0M;
                }

                DataTable totaySuccessTotalTable = resultTable.Tables[3];
                if (totaySuccessTotalTable != null && totaySuccessTotalTable.Rows.Count > 0)
                {
                    model.totaySuccessTotalCount = totaySuccessTotalTable.Rows[0]["totaySuccessTotalCount"] != DBNull.Value ?
                        Convert.ToInt32(totaySuccessTotalTable.Rows[0]["totaySuccessTotalCount"].ToString()) : 0;
                    model.totaySuccessTotalPrice = totaySuccessTotalTable.Rows[0]["totaySuccessTotalPrice"] != DBNull.Value ?
                        Convert.ToDecimal(totaySuccessTotalTable.Rows[0]["totaySuccessTotalPrice"].ToString()) : 0M;
                }

                DataTable yesterdayTotalTable = resultTable.Tables[4];
                if (yesterdayTotalTable != null && yesterdayTotalTable.Rows.Count > 0)
                {
                    model.yesterdayTotalCount = yesterdayTotalTable.Rows[0]["yesterdayTotalCount"] != DBNull.Value ?
                        Convert.ToInt32(yesterdayTotalTable.Rows[0]["yesterdayTotalCount"].ToString()) : 0;
                    model.yesterdayTotalPrice = yesterdayTotalTable.Rows[0]["yesterdayTotalPrice"] != DBNull.Value ?
                        Convert.ToDecimal(yesterdayTotalTable.Rows[0]["yesterdayTotalPrice"].ToString()) : 0M;
                }

                DataTable yesterdaySuccessTotalTable = resultTable.Tables[5];
                if (yesterdaySuccessTotalTable != null && yesterdaySuccessTotalTable.Rows.Count > 0)
                {
                    model.yesterdaySuccessTotalCount = yesterdaySuccessTotalTable.Rows[0]["yesterdaySuccessTotalCount"] != DBNull.Value ?
                        Convert.ToInt32(yesterdaySuccessTotalTable.Rows[0]["yesterdaySuccessTotalCount"].ToString()) : 0;
                    model.yesterdaySuccessTotalPrice = yesterdaySuccessTotalTable.Rows[0]["yesterdaySuccessTotalPrice"] != DBNull.Value ?
                        Convert.ToDecimal(yesterdaySuccessTotalTable.Rows[0]["yesterdaySuccessTotalPrice"].ToString()) : 0M;
                }

                DataTable productTotalTable = resultTable.Tables[6];
                if (productTotalTable != null && productTotalTable.Rows.Count > 0)
                {
                    for (int i = 0; i < productTotalTable.Rows.Count; i++)
                    {
                        int statuse = productTotalTable.Rows[i]["shelfstate"] != DBNull.Value ? Convert.ToInt32(productTotalTable.Rows[i]["shelfstate"].ToString()) : 0;
                        if (statuse == 1)
                        {
                            model.selGoodsCount = productTotalTable.Rows[i]["count"] != DBNull.Value ?
                       Convert.ToInt32(productTotalTable.Rows[i]["count"].ToString()) : 0;
                        }
                        else
                        {
                            model.noSelGoodsCount = productTotalTable.Rows[i]["count"] != DBNull.Value ?
                       Convert.ToInt32(productTotalTable.Rows[i]["count"].ToString()) : 0;
                        }
                    }
                }

                DataTable daiSendGoodsCountTotalTable = resultTable.Tables[7];
                if (daiSendGoodsCountTotalTable != null && daiSendGoodsCountTotalTable.Rows.Count > 0)
                {
                    model.daiSendGoodsCount = daiSendGoodsCountTotalTable.Rows[0]["daiSendGoodsCount"] != DBNull.Value ?
                      Convert.ToInt32(daiSendGoodsCountTotalTable.Rows[0]["daiSendGoodsCount"].ToString()) : 0;
                }

                DataTable sendGoodsCountTotalTable = resultTable.Tables[8];
                if (sendGoodsCountTotalTable != null && sendGoodsCountTotalTable.Rows.Count > 0)
                {
                    model.sendGoodsCount = sendGoodsCountTotalTable.Rows[0]["sendGoodsCount"] != DBNull.Value ?
                      Convert.ToInt32(sendGoodsCountTotalTable.Rows[0]["sendGoodsCount"].ToString()) : 0;
                }
            }

            return model;
        }

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        public MstaticSendOrder SaticSendGoodesCount()
        {
            string sql = string.Format(@"select COUNT(1) as sendGoodsCount from[order] where orderState = 4;
                                         select COUNT(1) as delayedSendGoodsCount from[order] where
                                             requireDeliveryTime < '{0}' and orderState = 4;
                                         select COUNT(1) as halfhourSendGoodsCount from[order] where
                                                 requireDeliveryTime between '{0}' and '{1}' and orderState = 4;
                                         select COUNT(1) as todaySendGoodsCount from[order] where
                                             requireDeliveryTime <= '{0}' and orderState = 4;",
                                             System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                             System.DateTime.Now.AddHours(0.5).ToString("yyyy-MM-dd HH:mm:ss"),
                                             System.DateTime.Now.ToString("yyyy-MM-dd " + "23:59:59")
                                             );

            MstaticSendOrder model = new MstaticSendOrder();
            DataSet resultTable = PKMySqlHelper.ExecuteDataSet(sql, null);

            if (resultTable != null && resultTable.Tables != null && resultTable.Tables.Count > 3)
            {
                DataTable totalTable = resultTable.Tables[0];
                if (totalTable != null && totalTable.Rows.Count > 0)
                {
                    model.sendGoodsCount = totalTable.Rows[0]["sendGoodsCount"] != DBNull.Value ?
                        Convert.ToInt32(totalTable.Rows[0]["sendGoodsCount"].ToString()) : 0;
                }

                totalTable = resultTable.Tables[1];
                if (totalTable != null && totalTable.Rows.Count > 0)
                {
                    model.delayedSendGoodsCount = totalTable.Rows[0]["delayedSendGoodsCount"] != DBNull.Value ?
                        Convert.ToInt32(totalTable.Rows[0]["delayedSendGoodsCount"].ToString()) : 0;
                }

                totalTable = resultTable.Tables[2];
                if (totalTable != null && totalTable.Rows.Count > 0)
                {
                    model.halfhourSendGoodsCount = totalTable.Rows[0]["halfhourSendGoodsCount"] != DBNull.Value ?
                        Convert.ToInt32(totalTable.Rows[0]["halfhourSendGoodsCount"].ToString()) : 0;
                }

                totalTable = resultTable.Tables[3];
                if (totalTable != null && totalTable.Rows.Count > 0)
                {
                    model.todaySendGoodsCount = totalTable.Rows[0]["todaySendGoodsCount"] != DBNull.Value ?
                        Convert.ToInt32(totalTable.Rows[0]["todaySendGoodsCount"].ToString()) : 0;
                }
            }

            return model;
        }

        /// <summary>
        /// 获取待送货的订单数
        /// </summary>
        /// <returns></returns>
        public int SaticSendGoodesTotaCount()
        {
            string sql = "select COUNT(1) as sendGoodsCount from[order] where orderState = 4";

            DataSet resultTable = PKMySqlHelper.ExecuteDataSet(sql, null);

            if (resultTable != null && resultTable.Tables != null && resultTable.Tables.Count > 0)
            {
                DataTable totalTable = resultTable.Tables[0];
                if (totalTable != null && totalTable.Rows.Count > 0)
                {
                    return  totalTable.Rows[0]["sendGoodsCount"] != DBNull.Value ?
                        Convert.ToInt32(totalTable.Rows[0]["sendGoodsCount"].ToString()) : 0;
                }
            }

            return 0;
        }
    }
}
