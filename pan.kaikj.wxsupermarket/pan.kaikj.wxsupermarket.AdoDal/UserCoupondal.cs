/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoDal
*文件名：  WXuserDal
*版本号：  V1.0.0.0
*唯一标识：4d30d968-82b7-4fba-9695-5bf39afed1b2
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 15:42:44

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 15:42:44
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
using pan.kaikj.wxsupermarket.tool;

namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// CouponDal 优惠券
    /// </summary>
    public class UserCouponDal : UserCouponIdal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Musercoupon model)
        {
            //// sql语句
            string sql = "INSERT INTO usercoupon (id,userId,userName,couponId,name,price,consumAmount,effectiveStart,effectiveEnd,receiveTime,isUse,useTime,orderId,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES (?id,?userId,?userName,?couponId,?name,?price,?consumAmount,?effectiveStart,?effectiveEnd,?receiveTime,?isUse,?useTime,?orderId,?isDelete,?isEffective,?great_time,?modify_time)";

            List<MySqlParameter> parameterList = GetMySqlParameterListByModel(model);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Musercoupon GetById(string id)
        {

            Musercoupon model = null;

            string sql = "  SELECT  id,userId,userName,couponId,name,price,consumAmount,effectiveStart,effectiveEnd,receiveTime,isUse,useTime,orderId,isDelete,isEffective,great_time,modify_time " +
                $" FROM usercoupon WHERE id=?id ; ";


            MySqlParameter[] parameterList = new MySqlParameter[1];
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList[0] = parameter;

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader.Read())
                {
                    model = new Musercoupon();
                    model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;

                    model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;

                    model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;

                    model.userName = Base64.DecodeBase64(model.userName);

                    model.couponId = sqlDataReader["couponId"] != DBNull.Value ? sqlDataReader["couponId"].ToString() : string.Empty;
                    model.name = sqlDataReader["name"] != DBNull.Value ? sqlDataReader["name"].ToString() : string.Empty;
                    model.price = sqlDataReader["price"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["price"].ToString()) : 0M;
                    model.consumAmount = sqlDataReader["consumAmount"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["consumAmount"].ToString()) : 0M;

                    model.effectiveStart = sqlDataReader["effectiveStart"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["effectiveStart"].ToString()) : DateTime.MinValue;
                    model.effectiveEnd = sqlDataReader["effectiveEnd"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["effectiveEnd"].ToString()) : DateTime.MinValue;

                    model.receiveTime = sqlDataReader["receiveTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["receiveTime"].ToString()) : DateTime.MinValue;

                    model.useTime = sqlDataReader["useTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["useTime"].ToString()) : DateTime.MinValue;

                    model.isUse = sqlDataReader["isUse"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["isUse"].ToString()) : 0;
                    model.orderId = sqlDataReader["orderId"] != DBNull.Value ? sqlDataReader["orderId"].ToString() : string.Empty;

                    model.isEffective = sqlDataReader["isEffective"] != DBNull.Value ? sqlDataReader["isEffective"].ToString() : string.Empty;
                    model.isDelete = sqlDataReader["isDelete"] != DBNull.Value ? sqlDataReader["isDelete"].ToString() : string.Empty;

                    model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                    model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;

                }
            }

            return model;
        }

        /// <summary>
        /// 使用优惠券
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int UseCoupon(string id, string orderId)
        {
            string sql = $"update usercoupon set isUse=1,orderId='{orderId}',useTime='{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',modify_time='{System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where id='{id}'";

            return PKMySqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public int GetPagCount(string userId, int isUse)
        {
            // 查询条件
            StringBuilder sqlWhere = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(userId))
            {
                sqlWhere.Append(" and userId = ?userId");
            }

            if (isUse >= 0)
            {
                sqlWhere.Append(" and isUse = ?isUse");
            }

            string sql = $" SELECT count(*) as totalCount  FROM usercoupon WHERE isDelete=0 and {sqlWhere.ToString()}";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?userId", MySqlDbType.VarChar);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?isUse", MySqlDbType.Int32);
            parameter.Value = isUse;
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
        /// 分页获取新闻信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<Musercoupon> GetPagList(string userId, int isUse, int pagIndex, int pagCount)
        {
            // 查询条件
            StringBuilder sqlWhere = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(userId))
            {
                sqlWhere.Append(" and userId = ?userId");
            }

            if (isUse >= 0)
            {
                sqlWhere.Append(" and isUse = ?isUse");
            }

            string sql = "  SELECT  id,userId,userName,couponId,name,price,consumAmount,effectiveStart,effectiveEnd,receiveTime,isUse,useTime,orderId,isDelete,isEffective,great_time,modify_time " +
                $" FROM usercoupon WHERE {sqlWhere.ToString()} and isDelete=0 ORDER BY 1 desc ,1 desc limit {((pagIndex - 1) * pagCount)}, {pagCount}; ";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?userId", MySqlDbType.VarChar);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?isUse", MySqlDbType.Int32);
            parameter.Value = isUse;
            parameterList.Add(parameter);

            List<Musercoupon> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<Musercoupon>();
                    while (sqlDataReader.Read())
                    {
                        Musercoupon model = new Musercoupon();
                        model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;

                        model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;

                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;

                        model.userName = Base64.DecodeBase64(model.userName);

                        model.couponId = sqlDataReader["couponId"] != DBNull.Value ? sqlDataReader["couponId"].ToString() : string.Empty;
                        model.name = sqlDataReader["name"] != DBNull.Value ? sqlDataReader["name"].ToString() : string.Empty;
                        model.price = sqlDataReader["price"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["price"].ToString()) : 0M;
                        model.consumAmount = sqlDataReader["consumAmount"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["consumAmount"].ToString()) : 0M;

                        model.effectiveStart = sqlDataReader["effectiveStart"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["effectiveStart"].ToString()) : DateTime.MinValue;
                        model.effectiveEnd = sqlDataReader["effectiveEnd"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["effectiveEnd"].ToString()) : DateTime.MinValue;

                        model.receiveTime = sqlDataReader["receiveTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["receiveTime"].ToString()) : DateTime.MinValue;

                        model.useTime = sqlDataReader["useTime"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["useTime"].ToString()) : DateTime.MinValue;

                        model.isUse = sqlDataReader["isUse"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["isUse"].ToString()) : 0;
                        model.orderId = sqlDataReader["orderId"] != DBNull.Value ? sqlDataReader["orderId"].ToString() : string.Empty;

                        model.isEffective = sqlDataReader["isEffective"] != DBNull.Value ? sqlDataReader["isEffective"].ToString() : string.Empty;
                        model.isDelete = sqlDataReader["isDelete"] != DBNull.Value ? sqlDataReader["isDelete"].ToString() : string.Empty;

                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;

                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }


        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            string sql = "delete from  usercoupon where  id=?id;";
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 获取参数化查询对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<MySqlParameter> GetMySqlParameterListByModel(Musercoupon model)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = model.id;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userId", MySqlDbType.VarChar, 25);
            parameter.Value = model.userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userName", MySqlDbType.VarChar, 500);
            parameter.Value = Base64.EncodeBase64(model.userName);
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?couponId", MySqlDbType.VarChar, 25);
            parameter.Value = model.couponId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?name", MySqlDbType.VarChar, 100);
            parameter.Value = model.name;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?price", MySqlDbType.Decimal);
            parameter.Value = model.price;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?consumAmount", MySqlDbType.Decimal);
            parameter.Value = model.consumAmount;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?effectiveStart", MySqlDbType.DateTime);
            parameter.Value = model.effectiveStart;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?effectiveEnd", MySqlDbType.DateTime);
            parameter.Value = model.effectiveEnd;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?receiveTime", MySqlDbType.DateTime);
            parameter.Value = model.receiveTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?isUse", MySqlDbType.Int16, 1);
            parameter.Value = model.isUse;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?useTime", MySqlDbType.DateTime);
            parameter.Value = model.useTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?couponId", MySqlDbType.VarChar, 25);
            parameter.Value = model.couponId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?orderId", MySqlDbType.VarChar, 25);
            parameter.Value = model.orderId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?isDelete", MySqlDbType.Int16, 1);
            parameter.Value = model.isDelete;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?isEffective", MySqlDbType.Int16, 1);
            parameter.Value = model.isEffective;
            parameterList.Add(parameter);

            DateTime dateTime = System.DateTime.Now;
            parameter = new MySqlParameter("?great_time", MySqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?modify_time", MySqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            return parameterList;
        }
    }
}
