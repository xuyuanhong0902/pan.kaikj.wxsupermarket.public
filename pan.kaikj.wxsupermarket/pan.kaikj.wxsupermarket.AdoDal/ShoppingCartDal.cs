/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoDal
*文件名：  ShoppingCartDal
*版本号：  V1.0.0.0
*唯一标识：6c18e9cc-3afa-4716-a490-d803acb17759
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 21:16:25

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 21:16:25
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoIdal;
using pan.kaikj.wxsupermarket.AdoModel;
using pan.kaikj.wxsupermarket.AdoSqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pan.kaikj.wxsupermarket.tool;

namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// ShoppingCartDal
    /// </summary>
    public class ShoppingCartDal : ShoppingCartIdal
    {
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(MshoppingCart model)
        {
            //// sql语句
            string sql = "INSERT INTO shoppingCart (shoppingCartId,userId,userName,productId,productname,productformat,buyNum,origPrice,sellPrice,totalPrice,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES(?shoppingCartId, ?userId, ?userName, ?productId, ?productname, ?productformat, ?buyNum, ?origPrice, ?sellPrice, ?totalPrice, ?isDelete, ?isEffective, ?great_time, ?modify_time)";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?shoppingCartId", MySqlDbType.VarChar, 25);
            parameter.Value = model.shoppingCartId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userId", MySqlDbType.VarChar, 25);
            parameter.Value = model.userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userName", MySqlDbType.VarChar, 500);
            parameter.Value = Base64.EncodeBase64(model.userName) ;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?productId", MySqlDbType.VarChar, 25);
            parameter.Value = model.productId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?productname", MySqlDbType.VarChar, 100);
            parameter.Value = model.productname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?productformat", MySqlDbType.VarChar, 50);
            parameter.Value = model.productformat;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?buyNum", MySqlDbType.Int32);
            parameter.Value = model.buyNum;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?origPrice", MySqlDbType.Decimal);
            parameter.Value = model.origPrice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?sellPrice", MySqlDbType.Decimal);
            parameter.Value = model.sellPrice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?totalPrice", MySqlDbType.Decimal);
            parameter.Value = model.totalPrice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?isDelete", MySqlDbType.Int16, 1);
            parameter.Value = 0;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?isEffective", MySqlDbType.Int16, 1);
            parameter.Value = 1;
            parameterList.Add(parameter);

            DateTime dateTime = System.DateTime.Now;
            parameter = new MySqlParameter("?great_time", MySqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?modify_time", MySqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 更新购物车产品的价格等相关信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <param name="origPrice"></param>
        /// <param name="sellPrice"></param>
        /// <param name="totalPrice"></param>
        /// <param name="buyNum"></param>
        /// <returns></returns>
        public bool UpdatePriceAndNum(string shoppingCartId, string userId, decimal origPrice, decimal sellPrice, decimal totalPrice, int buyNum)
        {
            string sql = "update shoppingCart set origPrice=?origPrice,  sellPrice=?sellPrice,  totalPrice=?totalPrice ";
            if (buyNum != 0)
            {
                sql = sql + ",buyNum=buyNum+?buyNum ";
            }

            sql = sql + " where shoppingCartId=?shoppingCartId and userId=?userId;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?shoppingCartId", MySqlDbType.VarChar, 25);
            parameter.Value = shoppingCartId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?buyNum", MySqlDbType.Int32);
            parameter.Value = buyNum;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?origPrice", MySqlDbType.Decimal);
            parameter.Value = origPrice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?sellPrice", MySqlDbType.Decimal);
            parameter.Value = sellPrice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?totalPrice", MySqlDbType.Decimal);
            parameter.Value = totalPrice;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据id删除购物车信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        public bool DeleteShoppingCartById(string shoppingCartId, string userId)
        {
            string sql = "delete from shoppingCart where shoppingCartId=?shoppingCartId and userId=?userId;";
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?shoppingCartId", MySqlDbType.VarChar, 25);
            parameter.Value = shoppingCartId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据id删除购物车信息
        /// </summary>
        /// <param name="shoppingCartId"></param>
        /// <returns></returns>
        public bool DeleteShoppingCartById(string[] shoppingCartId, string userId)
        {
            string sql = "delete from shoppingCart where shoppingCartId in ?shoppingCartId and userId=?userId;";
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?shoppingCartId", MySqlDbType.VarChar, 25);
            parameter.Value = "'"+string.Join("','", shoppingCartId)+"'";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据用户ID获取其全部购物车产品
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MshoppingCart> GetAllShoppingCartListBySserId(string userId)
        {
            string sql = @"select sc.shoppingCartId,sc.userId,sc.userName,sc.productId,
                           p.productname,p.productformat,sc.buyNum,p.origPrice,p.sellPrice,
                           sc.totalPrice,sc.isDelete,sc.isEffective,sc.great_time,
                           sc.modify_time from shoppingCart as sc 
                           JOIN product as p on sc.productId = p.productId 
                           where sc.userId=?userId;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = parameter = new MySqlParameter("?userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            List<MshoppingCart> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<MshoppingCart>();
                    while (sqlDataReader.Read())
                    {
                        MshoppingCart model = new MshoppingCart();
                        model.shoppingCartId = sqlDataReader["shoppingCartId"] != DBNull.Value ? sqlDataReader["shoppingCartId"].ToString() : string.Empty;
                        model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.userName = Base64.DecodeBase64(model.userName);

                        model.productId = sqlDataReader["productId"] != DBNull.Value ? sqlDataReader["productId"].ToString() : string.Empty;

                        model.productname = sqlDataReader["productname"] != DBNull.Value ? sqlDataReader["productname"].ToString() : string.Empty;
                        model.productformat = sqlDataReader["productformat"] != DBNull.Value ? sqlDataReader["productformat"].ToString() : string.Empty;
                        model.buyNum = sqlDataReader["buyNum"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["buyNum"].ToString()) : 0;
                        model.origPrice = sqlDataReader["origPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["origPrice"].ToString()) : 0M;
                        model.sellPrice = sqlDataReader["sellPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["sellPrice"].ToString()) : 0M;
                        model.totalPrice = sqlDataReader["totalPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["totalPrice"].ToString()) : 0M;

                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }

        /// <summary>
        /// 根据用户ID和产品id获取其对应的购买产品的购物车信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MshoppingCart GetShoppingCartListByUserIdAndProductId(string userId,string productId)
        {
            string sql = "select shoppingCartId,userId,userName,productId,productname,productformat,buyNum,origPrice,sellPrice,totalPrice,isDelete,isEffective,great_time,modify_time from shoppingCart where userId=?userId and productId=?productId;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = parameter = new MySqlParameter("?userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = parameter = new MySqlParameter("?productId", MySqlDbType.VarChar, 25);
            parameter.Value = productId;
            parameterList.Add(parameter);

            MshoppingCart model =null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    if (sqlDataReader.Read())
                    {
                        model = new MshoppingCart();
                        model.shoppingCartId = sqlDataReader["shoppingCartId"] != DBNull.Value ? sqlDataReader["shoppingCartId"].ToString() : string.Empty;
                        model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.userName = Base64.DecodeBase64(model.userName);

                        model.productId = sqlDataReader["productId"] != DBNull.Value ? sqlDataReader["productId"].ToString() : string.Empty;

                        model.productname = sqlDataReader["productname"] != DBNull.Value ? sqlDataReader["productname"].ToString() : string.Empty;
                        model.productformat = sqlDataReader["productformat"] != DBNull.Value ? sqlDataReader["productformat"].ToString() : string.Empty;
                        model.buyNum = sqlDataReader["buyNum"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["buyNum"].ToString()) : 0;
                        model.origPrice = sqlDataReader["origPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["origPrice"].ToString()) : 0M;
                        model.sellPrice = sqlDataReader["sellPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["sellPrice"].ToString()) : 0M;
                        model.totalPrice = sqlDataReader["totalPrice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["totalPrice"].ToString()) : 0M;

                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                    }
                }
            }

            return model;
        }
    }
}
