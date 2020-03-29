/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoSqlHelper
*文件名：  SqlHelper
*版本号：  V1.0.0.0
*唯一标识：d30ee03b-7617-4b88-9a28-6231e808060c
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/9 15:27:50

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/9 15:27:50
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoSqlHelper
{
    /// <summary>
    /// SqlHelper
    /// </summary>
    /// <summary>
    /// ADO.NET-------底层的数据操作
    /// </summary>
    public static class SqlHelper
    {
        /// <summary>
        /// 连接语句
        /// </summary>
        public static string connectionString = ConfigurationManager.AppSettings["SqlString"];

        #region 执行一个查询，返回查询的结果集+ExecuteDataTable(string sql, CommandType commandtype, SqlParameter[] parameters)
        public static DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }
        public static DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }

        /// <summary>
        /// 执行一个查询，返回查询的结果集。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandtype"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, CommandType commandtype, SqlParameter[] parameters)
        {
            DataTable data = new DataTable();  //实例化datatable,用于装载查询的结果集
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = commandtype;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);   //将参数添加到sql语句中。
                        }
                    }
                    //申明sqldataadapter，通过cmd来实例化它，这个是数据设备器，可以直接往datatable,dataset中写入。
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);   //利用Fill来填充。
                }
            }
            return data;
        }
        #endregion

        #region 返回一个SqlDataReader对象。

        public static SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }
        public static SqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }

        /// <summary>
        /// 返回一个SqlDataReader，从 SQL Server 数据库读取行的只进流的方式
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            //CommandBehavior.CloseConnection+关闭reader对象关闭与其连接的Connection对象。
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 返回一个SqlDataReader，从 SQL Server 数据库读取行的只进流的方式
        /// </summary>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            //CommandBehavior.CloseConnection+关闭reader对象关闭与其连接的Connection对象。
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region 执行一个查询，返回结果集的首行首列。忽略其他行，其他列
        /// <summary>
        /// 只执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }
        /// <summary>
        /// 可以执行存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static  object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }
        /// <summary>
        /// 执行一个查询，返回结果集的首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            //cmd.ExecuteScalar()+执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略其他列或行。
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }

        #endregion

        #region 进行CRUD操作

        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }
        public static int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }

        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">执行的Sql语句</param>
        /// <param name="commandType">要执行的查询语句类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程的参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }

        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">执行的Sql语句</param>
        /// <param name="commandType">要执行的查询语句类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程的参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }

        #endregion

        #region  返回当前连接的数据库中所有用户创建的数据库
        /// <summary>
        /// 返回当前连接的数据库中所有用户创建的数据库
        /// </summary>        
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static  DataTable GetTable(string tableName)
        {
            DataTable table = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                table = conn.GetSchema(tableName);
            }
            return table;
        }
        #endregion

        #region 数据处理

        /// <summary>
        ///   将SqlDataReader转换为Model实体
        /// </summary>
        /// <typeparam name="T">实例类名</typeparam>
        /// <param name="dr">Reader对象</param>
        /// <returns>实体对象</returns>
        public static T ReaderToModel<T>(SqlDataReader dr)
        {
            try
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        Type modelType = typeof(T);
                        T model = Activator.CreateInstance<T>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            if (!IsNullOrDbNull(dr[i]))
                            {
                                PropertyInfo pi = modelType.GetProperty(GetPropertyName(dr.GetName(i)), BindingFlags.NonPublic | BindingFlags.Instance);
                                pi.SetValue(model, HackType(dr[i], pi.PropertyType), null);
                            }
                        }
                        return model;
                    }
                }
                return default(T);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///   将SqlDataReader转换为Model实体
        /// </summary>
        /// <typeparam name="T">实例类名</typeparam>
        /// <param name="dr">Reader对象</param>
        /// <returns>实体对象</returns>
        public static List<T> ReaderToModelList<T>(SqlDataReader dr)
        {
            try
            {
                using (dr)
                {

                    List<T> listModel = null;
                    if (dr!=null)
                    {
                        listModel = new List<T>();
                        if (dr.Read())
                        {
                            Type modelType = typeof(T);
                            T model = Activator.CreateInstance<T>();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                if (!IsNullOrDbNull(dr[i]))
                                {
                                    PropertyInfo pi = modelType.GetProperty(GetPropertyName(dr.GetName(i)), BindingFlags.NonPublic | BindingFlags.Instance);
                                    pi.SetValue(model, HackType(dr[i], pi.PropertyType), null);
                                }
                            }
                            listModel.Add(model);
                        }
                    }

                    return listModel;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///  对可空类型进行判断.
        /// </summary> 
        private static object HackType(object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }
                System.ComponentModel.NullableConverter nullAbleConverter = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullAbleConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, conversionType);
        }

        /// <summary>
        ///  判断字段值是否为NUll
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsNullOrDbNull(object obj)
        {
            return ((obj is DBNull) || string.IsNullOrEmpty(obj.ToString())) ? true : false;
        }

        /// <summary>
        ///  获取属性类的名称
        /// </summary>
        /// <param name="column">列名</param>
        /// <returns>列名</returns>
        private static string GetPropertyName(string column)
        {
            string[] narr = column.Split('_');
            column = "";
            for (int i = 0; i < narr.Length; i++)
            {
                if (narr[i].Length > 1)
                {
                    column += narr[i].Substring(0, 1).ToUpper() + narr[i].Substring(1);
                }
                else
                {
                    column += narr[i].Substring(0, 1).ToUpper();
                }
            }
            return column;
        }

        #endregion
    }
}
