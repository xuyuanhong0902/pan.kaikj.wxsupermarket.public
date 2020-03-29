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
    /// WXuserDal 新闻
    /// </summary>
    public class NewsDal : NewsIdal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNews(Mnews model)
        {
            //// sql语句
            string sql = "INSERT INTO [news] ([id],[type],[title],[value],[isDelete],[isEffective],[great_time],[modify_time]) " +
                         "VALUES (@id,@type,@title,@value,@isDelete,@isEffective,@great_time,@modify_time)";

            List<MySqlParameter> parameterList = GetMySqlParameterListByModel(model);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据id获取新闻信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public Mnews GetNewsById(string id)
        {

            Mnews model = null;

            //// 语句
            string sql = "SELECT TOP 1 [id],[type],[title],[value],[isDelete],[isEffective],[great_time],[modify_time]  FROM news where id=@id";

            MySqlParameter[] parameterList = new MySqlParameter[1];
            MySqlParameter parameter = new MySqlParameter("@id", MySqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList[0] = parameter;

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader.Read())
                {
                    model = new Mnews();
                    model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;
                    model.title = sqlDataReader["title"] != DBNull.Value ? sqlDataReader["title"].ToString() : string.Empty;
                    model.value = sqlDataReader["value"] != DBNull.Value ? sqlDataReader["value"].ToString() : string.Empty;
                    model.type = sqlDataReader["type"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["type"].ToString()) : 0;
                    model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                    model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                }
            }

            return model;
        }

        /// <summary>
        /// 根据id更新新闻信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateNews(Mnews model)
        {
            string sql = "update news set title=@title,value=@value where id=@id ";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@id", MySqlDbType.VarChar, 25);
            parameter.Value = model.id;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@title", MySqlDbType.VarChar, 100);
            parameter.Value = model.title;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@value", SqlDbType.Text);
            parameter.Value = model.value;
            parameterList.Add(parameter);

            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 分页获取新闻信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<Mnews> GetNewsPagList(int pagIndex, int pagCount)
        {
            string sql = "  SELECT  TOP " + pagCount * pagIndex + " [id],[type],[title],[value],[isDelete],[isEffective],[great_time],[modify_time] " +
                " FROM( SELECT ROW_NUMBER() OVER(ORDER BY great_time DESC) AS ROWID,* FROM news) AS TEMP1  WHERE ROWID> " + pagCount * (pagIndex - 1);


            List<Mnews> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, null))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<Mnews>();
                    while (sqlDataReader.Read())
                    {
                        Mnews model = new Mnews();
                        model.id = sqlDataReader["id"] != DBNull.Value ? sqlDataReader["id"].ToString() : string.Empty;
                        model.title = sqlDataReader["title"] != DBNull.Value ? sqlDataReader["title"].ToString() : string.Empty;
                        model.value = sqlDataReader["value"] != DBNull.Value ? sqlDataReader["value"].ToString() : string.Empty;
                        model.type = sqlDataReader["type"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["type"].ToString()) : 0;
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
        public bool DeleteNews(string id)
        {
            string sql = "delete from news where id=@id;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@id", MySqlDbType.VarChar, 25);
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
        private List<MySqlParameter> GetMySqlParameterListByModel(Mnews model)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@id", MySqlDbType.VarChar, 25);
            parameter.Value = model.id;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@title", MySqlDbType.VarChar, 100);
            parameter.Value = model.title;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@value", SqlDbType.Text);
            parameter.Value = model.value;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@type", SqlDbType.Int);
            parameter.Value = model.type;
            parameterList.Add(parameter);


            parameter = new MySqlParameter("@isDelete", MySqlDbType.Int16, 1);
            parameter.Value = model.isDelete;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@isEffective", MySqlDbType.Int16, 1);
            parameter.Value = model.isEffective;
            parameterList.Add(parameter);

            DateTime dateTime = System.DateTime.Now;
            parameter = new MySqlParameter("@great_time", SqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@modify_time", SqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            return parameterList;
        }
    }
}
