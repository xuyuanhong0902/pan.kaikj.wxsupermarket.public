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

namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// WXuserDal 微信用户操作类
    /// </summary>
    public class WxmenuDal : WxmenuIdal
    {
        /// <summary>
        /// 新增微信菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddWxmenu(Mwxmenu model)
        {
            //// sql语句
            string sql = "INSERT INTO wxmenu(id,superId,menuName,type,url,sortNum,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES (?id,?superId,?menuName,?type,?url,?sortNum,?isDelete,?isEffective,?great_time,?modify_time)";

            List<MySqlParameter> parameterList = GetMySqlParameterListByModel(model);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据id获取微信菜单model
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public Mwxmenu GetWxmenuByOpenid(string id)
        {

            Mwxmenu model = null;

            //// 语句
            //string sql = "SELECT TOP 1 [id],[superId],[menuName],[type],[url],[isDelete],[isEffective],[great_time],[modify_time],[sortNum] FROM wxmenu where id=?id";
            string sql = "  SELECT  id,superId,menuName,type,url,sortNum,isDelete,isEffective,great_time,modify_time " +
              $" FROM wxmenu WHERE id=?id; ";


            MySqlParameter[] parameterList = new MySqlParameter[1];
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList[0] = parameter;

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader.Read())
                {
                    model = new Mwxmenu();
                    model.sortNum = sqlDataReader["sortNum"] != DBNull.Value ? Convert.ToInt64(sqlDataReader["sortNum"].ToString()) : 10;
                    model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;
                    model.superId = sqlDataReader["superId"] != DBNull.Value ? sqlDataReader["superId"].ToString() : string.Empty;
                    model.menuName = sqlDataReader["menuName"] != DBNull.Value ? sqlDataReader["menuName"].ToString() : string.Empty;
                    model.type = sqlDataReader["type"] != DBNull.Value ? sqlDataReader["type"].ToString() : string.Empty;
                    model.url = sqlDataReader["url"] != DBNull.Value ? sqlDataReader["url"].ToString() : string.Empty;
                    model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                    model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                }
            }

            return model;
        }

        /// <summary>
        /// 获取全部微信菜单
        /// </summary>
        /// <param name="superId">-1代表获取全部</param>
        /// <returns></returns>
        public List<Mwxmenu> GetAllWxmenu(string superId)
        {
            string sql = "  SELECT  id,superId,menuName,type,url,sortNum,isDelete,isEffective,great_time,modify_time FROM wxmenu where 1=1 ";
            if (superId!="-1")
            {
                sql = sql + " and superId=?superId order by superId desc,id desc ";
            }

            MySqlParameter[] parameterList = new MySqlParameter[1];
            MySqlParameter parameter = new MySqlParameter("?superId", MySqlDbType.VarChar, 25);
            parameter.Value = superId;
            parameterList[0] = parameter;

            List<Mwxmenu> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<Mwxmenu>();
                    while (sqlDataReader.Read())
                    {
                        Mwxmenu model = new Mwxmenu();
                        model.sortNum = sqlDataReader["sortNum"] != DBNull.Value ? Convert.ToInt64(sqlDataReader["sortNum"].ToString()) : 10;
                        model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;
                        model.superId = sqlDataReader["superId"] != DBNull.Value ? sqlDataReader["superId"].ToString() : string.Empty;
                        model.menuName = sqlDataReader["menuName"] != DBNull.Value ? sqlDataReader["menuName"].ToString() : string.Empty;
                        model.type = sqlDataReader["type"] != DBNull.Value ? sqlDataReader["type"].ToString() : string.Empty;
                        model.url = sqlDataReader["url"] != DBNull.Value ? sqlDataReader["url"].ToString() : string.Empty;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }

        /// <summary>
        /// 根据ID删除微信才菜单
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public bool DeleteWxmenu(string id)
        {
            string sql = "delete from wxmenu where id=?id;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 更新菜单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWxmenu(Mwxmenu model)
        {
            string sql = "update  wxmenu set menuName=?menuName,url=?url,sortNum=?sortNum where id=?id;";
            List<MySqlParameter> parameterList = new List<MySqlParameter>();

            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = model.id;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?sortNum", MySqlDbType.VarChar, 25);
            parameter.Value = model.sortNum;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?menuName", MySqlDbType.VarChar, 50);
            parameter.Value = model.menuName;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?url", MySqlDbType.VarChar, 1000);
            parameter.Value = model.url;
            parameterList.Add(parameter);
            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 获取参数化查询对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<MySqlParameter> GetMySqlParameterListByModel(Mwxmenu model)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?id", MySqlDbType.VarChar, 25);
            parameter.Value = model.id;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?sortNum", MySqlDbType.VarChar, 25);
            parameter.Value = model.sortNum+"";
            parameterList.Add(parameter);
            
            parameter = new MySqlParameter("?superId", MySqlDbType.VarChar, 25);
            parameter.Value = model.superId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?menuName", MySqlDbType.VarChar, 50);
            parameter.Value = model.menuName;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?type", MySqlDbType.VarChar, 50);
            parameter.Value = model.type;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?url", MySqlDbType.VarChar, 1000);
            parameter.Value = model.url;
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
