/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoDal
*文件名：  AdminuserDal
*版本号：  V1.0.0.0
*唯一标识：07c70bb3-e3cc-466f-a53c-ea1c982b61e1
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/11 21:46:40

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/11 21:46:40
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
    /// AdminuserDal
    /// </summary>
    public class SndGoodsUserDal : SndGoodsUserIdal
    {
        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSndGoodsUser(MsendGoodsUser model)
        {
            //// sql语句
            string sql = "INSERT INTO sendGoodsUser (id,userName,sex,phone,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES(?id, ?userName,?sex, ?phone,  ?isDelete, ?isEffective, ?great_time, ?modify_time)";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = model.id;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userName", MySqlDbType.VarChar, 500);
            parameter.Value = Base64.EncodeBase64(model.userName) ;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?phone", MySqlDbType.VarChar, 50);
            parameter.Value = model.phone;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?sex", MySqlDbType.Int16, 1);
            parameter.Value = model.sex;
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

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 删除送货员信息
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public bool DeleteSndGoodsUser(string id)
        {
            //// sql语句
            string sql = "delete from sendGoodsUser where id=?id";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 修改送货信息
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public bool ChangSndGoodsUserInfor(MsendGoodsUser model)
        {
            //// sql语句
            string sql = "update sendGoodsUser set userName = ?userName,phone=?phone,sex=?sex where id = ?id";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?userName", MySqlDbType.VarChar, 500);
            parameter.Value = Base64.EncodeBase64(model.userName);
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?phone", MySqlDbType.VarChar, 50);
            parameter.Value = model.phone;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?sex", MySqlDbType.Int16, 1);
            parameter.Value = model.sex;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = model.id;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 获取管理员数据总条数
        /// </summary>
        /// <returns></returns>
        public int GetSndGoodsUserPagCount(string phone, string userName)
        {
            string sql = " SELECT count(id) as totalCount  FROM sendGoodsUser WHERE 1=1 ";
            if (!string.IsNullOrEmpty(phone))
            {
                sql = sql + " and phone like CONCAT('%',?phone,'%')";
            }

            if (!string.IsNullOrEmpty(userName))
            {
                sql = sql + " and userName like CONCAT('%',?userName,'%')";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?phone", MySqlDbType.VarChar, 50);
            parameter.Value = "%" + phone + "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userName", MySqlDbType.VarChar, 500);
            parameter.Value = "%" + Base64.EncodeBase64(userName) + "%";
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
        /// 分页获取管理严用户信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<MsendGoodsUser> GetSendGoodsUserPagList(int pagIndex, int pagCount, string phone, string userName)
        {
            // 查询条件
            StringBuilder sqlWhere = new StringBuilder(" 1=1 ");

            if (!string.IsNullOrEmpty(phone))
            {
                sqlWhere.Append(" and phone like CONCAT('%',?phone,'%')");
            }

            if (!string.IsNullOrEmpty(userName))
            {
                sqlWhere.Append(" and userName like CONCAT('%',?userName,'%')");
            }

            string sql = "  SELECT id,userName,sex,phone,isDelete,isEffective,great_time,modify_time " +
               $" FROM sendGoodsUser WHERE {sqlWhere.ToString()} ORDER BY great_time desc limit {((pagIndex - 1) * pagCount)}, {pagCount}; ";

            //string sql = "  SELECT  TOP " + pagCount * pagIndex + " [id],[userName],[phone],[sex],[isDelete],[isEffective],[great_time],[modify_time] " +
            //    " FROM( SELECT ROW_NUMBER() OVER(ORDER BY great_time DESC) AS ROWID,* FROM sendGoodsUser) AS TEMP1  WHERE ROWID> " + pagCount * (pagIndex - 1);

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?phone", MySqlDbType.VarChar, 50);
            parameter.Value = "%" + phone + "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?userName", MySqlDbType.VarChar, 500);
            parameter.Value = "%" + Base64.EncodeBase64(userName) + "%";
            parameterList.Add(parameter);

            List<MsendGoodsUser> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<MsendGoodsUser>();
                    while (sqlDataReader.Read())
                    {
                        MsendGoodsUser model = new MsendGoodsUser();
                        model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.userName = Base64.DecodeBase64(model.userName);

                        model.phone = sqlDataReader["phone"] != DBNull.Value ? sqlDataReader["phone"].ToString() : string.Empty;
                        model.sex = sqlDataReader["sex"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["sex"].ToString()) : 0;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        model.greatTime = model.great_time.ToString("yyyy-MM-dd HH:mm:ss");
                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }

        /// <summary>
        /// 获取送货人model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MsendGoodsUser GetSendGoodsUserModelById(string id)
        {
            string sql = "  SELECT  id,userName,sex,phone,isDelete,isEffective,great_time,modify_time FROM sendGoodsUser where id=?id";
          
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList.Add(parameter);
            MsendGoodsUser model =null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                   
                    if (sqlDataReader.Read())
                    {
                        model = new MsendGoodsUser();
                        model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.userName = Base64.DecodeBase64(model.userName);

                        model.phone = sqlDataReader["phone"] != DBNull.Value ? sqlDataReader["phone"].ToString() : string.Empty;
                        model.sex = sqlDataReader["sex"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["sex"].ToString()) : 0;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        model.greatTime = model.great_time.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }

            return model;
        }
    }
}
