/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoDal
*文件名：  ProductclassDal
*版本号：  V1.0.0.0
*唯一标识：658d7aaf-dc74-411d-936b-2aab2aa88fda
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/16 21:05:48

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/16 21:05:48
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

namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// ProductclassDal
    /// </summary>
    public class ProductclassDal: ProductclassIdal
    {
        /// <summary>
        /// 新增产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddProductclass(Mproductclass model)
        {

            //// sql语句
            string sql = "INSERT INTO productclass(supclassid,classname,priority,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES (?supclassid,?classname,?priority,?isDelete,?isEffective,?great_time,?modify_time)";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?supclassid", MySqlDbType.Int32);
            parameter.Value = model.supclassid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?classname", MySqlDbType.VarChar,50);
            parameter.Value = model.classname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?priority", MySqlDbType.Int32);
            parameter.Value = model.priority;
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
        /// 编辑产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditProductclass(Mproductclass model)
        {

            //// sql语句
            string sql = "update  productclass set supclassid=?supclassid, classname=?classname,priority=?priority ,modify_time=?modify_time where classid=?classid;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("?classid", MySqlDbType.Int32);
            parameter.Value = model.classid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?supclassid", MySqlDbType.Int32);
            parameter.Value = model.supclassid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?classname", MySqlDbType.VarChar, 50);
            parameter.Value = model.classname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?priority", MySqlDbType.Int32);
            parameter.Value = model.priority;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("?modify_time", MySqlDbType.DateTime);
            parameter.Value = System.DateTime.Now;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public bool DeleteProductclass(int classid,int supclassid)
        {
            ///// 实现步骤
            //// 1、首先根据classid到产品表中查询是否有数据
            //// 2、如果查询到数据，那么不允许删除
            //// 3、如果没查询到数据，那么直接删除其第一的类以及其子类

            //// 说明删除主分类
            int hasThisClassProductNum = 0;
            if (supclassid == 0)
            {
                hasThisClassProductNum = new ProductDal().CetProductBySupClassid(supclassid);
            }
            else
            {
                hasThisClassProductNum = new ProductDal().CetProductByClassid(classid);
            }

            if (hasThisClassProductNum>0)
            {
                return false;
            }

            //// sql语句
            string sql = string.Empty;
            if (supclassid == 0)
            {
                //// sql语句 删除其本身子分类
                sql = "delete from productclass where supclassid=?classid or classid=?classid";
            }
            else
            {
                //// 删除自己
                sql = "delete from productclass where classid=?classid";
            }

            MySqlParameter[] parameterList = new MySqlParameter[1];
            parameterList[0] = new MySqlParameter("?classid", MySqlDbType.Int32);
            parameterList[0].Value = classid;

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList) > 0;
        }

        /// <summary>
        /// 直接获取所有分类
        /// </summary>
        /// <returns></returns>
        public List<Mproductclass> GetMproductclasses(int supclassid) {
            string sql = "  SELECT classid,supclassid,classname,priority,isDelete,isEffective,great_time,modify_time from productclass where 1=1 ";
            if (supclassid>=0)
            {
                sql = sql + " and supclassid = ?supclassid;";
            }
            MySqlParameter[] parameterList = new MySqlParameter[1];
            parameterList[0] = new MySqlParameter("?supclassid", MySqlDbType.Int32);
            parameterList[0].Value = supclassid;

            List<Mproductclass> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<Mproductclass>();
                    while (sqlDataReader.Read())
                    {
                        Mproductclass model = new Mproductclass();
                        model.classid = sqlDataReader["classid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["classid"].ToString()) : 0;
                        model.supclassid = sqlDataReader["supclassid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["supclassid"].ToString()) : 0;
                        model.priority = sqlDataReader["priority"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["priority"].ToString()) : 0;
                        model.classname = sqlDataReader["classname"] != DBNull.Value ? sqlDataReader["classname"].ToString() : string.Empty;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }

        /// <summary>
        /// 根据类别ID获取model
        /// </summary>
        /// <param name="classid">classid</param>
        /// <returns></returns>
        public Mproductclass GetMproductclassByClassid(int classid)
        {
            string sql = "  SELECT classid,supclassid,classname,priority,isDelete,isEffective,great_time,modify_time from productclass where 1=1 and classid = ?classid;";

            MySqlParameter[] parameterList = new MySqlParameter[1];
            parameterList[0] = new MySqlParameter("?classid", MySqlDbType.Int32);
            parameterList[0].Value = classid;

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader != null)
                {
                    if (sqlDataReader.Read())
                    {
                        Mproductclass model = new Mproductclass();
                        model.classid = sqlDataReader["classid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["classid"].ToString()) : 0;
                        model.supclassid = sqlDataReader["supclassid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["supclassid"].ToString()) : 0;
                        model.priority = sqlDataReader["priority"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["priority"].ToString()) : 0;
                        model.classname = sqlDataReader["classname"] != DBNull.Value ? sqlDataReader["classname"].ToString() : string.Empty;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        return model;
                    }
                }
            }

            return null;
        }
    }
}
