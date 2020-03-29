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
*电子邮箱：1315597862?qq.com
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

namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// AdminuserDal
    /// </summary>
    public class AdminuserDal : AdminuserIdal
    {
        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddAdminUser(Madminuser model)
        {

            //// sql语句
            string sql = "INSERT INTO adminuser (adminuserid,account,name,password,sex,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES(?adminuserid, ?account, ?name, ?password, ?sex, ?isDelete, ?isEffective, ?great_time, ?modify_time)";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?adminuserid", MySqlDbType.VarChar, 25);
            parameter.Value = model.adminuserid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?account", MySqlDbType.VarChar, 50);
            parameter.Value = model.account;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?name", MySqlDbType.VarChar, 50);
            parameter.Value = model.name;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?password", MySqlDbType.VarChar, 50);
            parameter.Value = model.password;
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
        /// 删除用户信息
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <returns></returns>
        public bool DeleteAdminUser(string adminuserid)
        {
            //// sql语句
            string sql = "delete from adminuser where adminuserid=?adminuserid";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?adminuserid", MySqlDbType.VarChar, 25);
            parameter.Value = adminuserid;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="adminuserid"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public bool ChangAdminUserPass(string adminuserid, string newPass)
        {
            //// sql语句
            string sql = "update adminuser  set password = ?password where adminuserid = ?adminuserid";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?password", MySqlDbType.VarChar, 50);
            parameter.Value = newPass;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?adminuserid", MySqlDbType.VarChar, 25);
            parameter.Value = adminuserid;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">model</param>
        /// <returns></returns>
        public bool ChangAdminUserInfor(Madminuser model)
        {
            //// sql语句
            string sql = "update adminuser  set name = ?name,sex=?sex where adminuserid = ?adminuserid";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?name", MySqlDbType.VarChar, 50);
            parameter.Value = model.name;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?sex", MySqlDbType.Int16, 1);
            parameter.Value = model.sex;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?adminuserid", MySqlDbType.VarChar, 25);
            parameter.Value = model.adminuserid;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据登录账号获取用户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Madminuser GetMadminuserModelByAcount(string account)
        {

            //// sql语句
            string sql = "  SELECT adminuserid,account,name,password,sex,isDelete,isEffective,great_time,modify_time " +
                "FROM adminuser where account=?account limit 1";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?account", MySqlDbType.VarChar, 50);
            parameter.Value = account;
            parameterList.Add(parameter);

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null && sqlDataReader.Read())
                {
                    Madminuser model = new Madminuser();
                    model.adminuserid = sqlDataReader["adminuserid"] != DBNull.Value ? sqlDataReader["adminuserid"].ToString() : string.Empty;
                    model.account = sqlDataReader["account"] != DBNull.Value ? sqlDataReader["account"].ToString() : string.Empty;
                    model.name = sqlDataReader["name"] != DBNull.Value ? sqlDataReader["name"].ToString() : string.Empty;
                    model.password = sqlDataReader["password"] != DBNull.Value ? sqlDataReader["password"].ToString() : string.Empty;
                    model.sex = sqlDataReader["sex"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["sex"].ToString()) : 0;
                    model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                    model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                    return model;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取管理员数据总条数
        /// </summary>
        /// <returns></returns>
        public int GetAdminUserInfoPagCount(string acount,string name)
        {
            string sql = " SELECT count(adminuserid) as totalCount  FROM adminuser  WHERE 1=1 ";
            if (!string.IsNullOrEmpty(acount))
            {
                sql = sql + " and account like ?acount";
            }

            if (!string.IsNullOrEmpty(name))
            {
                sql = sql + " and name like ?name";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?acount", MySqlDbType.VarChar, 50);
            parameter.Value = "%"+acount+ "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?name", MySqlDbType.VarChar, 50);
            parameter.Value = "%" + name + "%";
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
        public List<Madminuser> GetAdminUserInfoPagList(int pagIndex, int pagCount, string acount, string name)
        {
            // 查询条件
            StringBuilder sqlWhere = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(acount))
            {
                sqlWhere.Append( " and account like ?acount");
            }

            if (!string.IsNullOrEmpty(name))
            {
                sqlWhere.Append(" and name like ?name");
            }

            string sql = "  SELECT  adminuserid,account,name,password,sex,isDelete,isEffective,great_time,modify_time " +
                $" FROM adminuser WHERE {sqlWhere.ToString()} ORDER BY 1 desc limit {((pagIndex - 1) * pagCount)}, {pagCount}; " ;
           
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?acount", MySqlDbType.VarChar, 50);
            parameter.Value = "%" + acount + "%";
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?name", MySqlDbType.VarChar, 50);
            parameter.Value = "%" + name + "%";
            parameterList.Add(parameter);

            List<Madminuser> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<Madminuser>();
                    while (sqlDataReader.Read())
                    {
                        Madminuser model = new Madminuser();
                        model.adminuserid = sqlDataReader["adminuserid"] != DBNull.Value ? sqlDataReader["adminuserid"].ToString() : string.Empty;
                        model.account = sqlDataReader["account"] != DBNull.Value ? sqlDataReader["account"].ToString() : string.Empty;
                        model.name = sqlDataReader["name"] != DBNull.Value ? sqlDataReader["name"].ToString() : string.Empty;
                        //// model.password = sqlDataReader["password"] != DBNull.Value ? sqlDataReader["password"].ToString() : string.Empty;
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
    }
}
