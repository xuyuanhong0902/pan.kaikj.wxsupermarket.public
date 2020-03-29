/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoDal
*文件名：  ProductDal
*版本号：  V1.0.0.0
*唯一标识：f202ab63-c2b0-4581-9492-529c35629c7b
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/16 21:17:34

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/16 21:17:34
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoIdal;
using pan.kaikj.wxsupermarket.AdoModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pan.kaikj.wxsupermarket.AdoSqlHelper;

namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// ProductDal
    /// </summary>
    public class ProductDal: ProductIdal
    {
        /// <summary>
        /// 新增产品类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddProduct(Mproduct model)
        {

            //// sql语句  

        string sql = "INSERT INTO product(productid,classid,supclassid,className,supclassName,productname,productformat,productformatunit,origprice,sellprice,stock,shelfstate,hassellnum,productdetails,productimgurl,priority,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES (@productid,@classid,@supclassid,(select classname from productclass where classid=@classid),(select classname from productclass where classid=@supclassid),@productname,@productformat,@productformatunit,@origprice,@sellprice,@stock,@shelfstate,@hassellnum,@productdetails,@productimgurl,@priority,@isDelete,@isEffective,@great_time,@modify_time)";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@productid", MySqlDbType.VarChar, 25);
            parameter.Value = model.productid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@classid", SqlDbType.Int);
            parameter.Value = model.classid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@supclassid", SqlDbType.Int);
            parameter.Value = model.supclassid;
            parameterList.Add(parameter);
 
            parameter = new MySqlParameter("@productname", MySqlDbType.VarChar, 100);
            parameter.Value = model.productname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productformat", MySqlDbType.VarChar, 20);
            parameter.Value = model.productformat;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productformatunit", MySqlDbType.VarChar, 50);
            parameter.Value = model.productformatunit;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@origprice", SqlDbType.Decimal);
            parameter.Value = model.origprice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@sellprice", SqlDbType.Decimal);
            parameter.Value = model.sellprice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@stock", SqlDbType.Int);
            parameter.Value = model.stock;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@shelfstate", SqlDbType.Int);
            parameter.Value = model.shelfstate;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@hassellnum", SqlDbType.Int);
            parameter.Value =0;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productdetails", SqlDbType.Text);
            parameter.Value = model.productdetails;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productimgurl", MySqlDbType.VarChar, 100);
            parameter.Value = model.productimgurl;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@priority", SqlDbType.Int);
            parameter.Value = model.priority;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@isDelete", SqlDbType.Int);
            parameter.Value = 0;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@isEffective", SqlDbType.Int);
            parameter.Value = 1;
            parameterList.Add(parameter);

            DateTime dateTime = System.DateTime.Now;
            parameter = new MySqlParameter("@great_time", SqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@modify_time", SqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据ID删除一个产品信息
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public bool DeleteProduct(string productid)
        {
            string sql = "update  product set isDelete=1 where productid=@productid;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@productid", MySqlDbType.VarChar, 25);
            parameter.Value = productid;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据商品的上下架状态
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public bool UpdateProductShelfstate(string productid, int shelfstate)
        {
            string sql = string.Empty;
            if (shelfstate==9999)
            {
                sql = "update  product set shelfstate=-shelfstate where productid=@productid;";
            }
            else
            {
                 sql = "update  product set shelfstate=@shelfstate where productid=@productid;";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@shelfstate", SqlDbType.Int);
            parameter.Value = shelfstate;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productid", MySqlDbType.VarChar, 25);
            parameter.Value = productid;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据产品的价格、库存信息
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="origprice"></param>
        /// <param name="sellprice"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        public bool UpdateProdctPrice(string productid,decimal origprice,decimal sellprice,int stock, int priority) {
            string sql = "update  product set ";

            if (origprice>0)
            {
                sql = sql + "  origprice = @origprice,";
            }

            if (sellprice > 0)
            {
                sql = sql + "  sellprice = @sellprice,";
            }

            if (stock >= 0)
            {
                sql = sql + "  stock = @stock,";
            }

            if (priority > 0)
            {
                sql = sql + "  priority = @priority,";
            }

            sql = sql.TrimEnd(',') + " where productid=@productid;";


            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@productid", MySqlDbType.VarChar, 25);
            parameter.Value = productid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@origprice", SqlDbType.Decimal);
            parameter.Value = origprice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@sellprice", SqlDbType.Decimal);
            parameter.Value = sellprice;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@stock", SqlDbType.Int);
            parameter.Value = stock;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@priority", SqlDbType.Decimal);
            parameter.Value = priority;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据产品类别，查询对应的产品数量
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int CetProductByClassid(int classid)
        {
            string sql = " SELECT count(productid) as totalCount  FROM product WHERE 1=1 and isDelete=0 and classid=@classid";

            MySqlParameter[] parameterList = new MySqlParameter[1];
            parameterList[0] = new MySqlParameter("@classid", SqlDbType.Int);
            parameterList[0].Value = classid;

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
        /// 根据产品父类别，查询对应的产品数量
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int CetProductBySupClassid(int supclassid)
        {
            string sql = " SELECT count(productid) as totalCount  FROM product WHERE  isDelete=0 and supclassid=@supclassid";

            MySqlParameter[] parameterList = new MySqlParameter[1];
            parameterList[0] = new MySqlParameter("@supclassid", SqlDbType.Int);
            parameterList[0].Value = supclassid;

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
        /// 根据产品ID获取产品model
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public Mproduct GetMproductModelById(string productid)
        {
            string sql = "select productid,classid,supclassid,className,supclassName,productname,productformat,productformatunit,origprice,sellprice,stock,shelfstate,hassellnum," +
                "productdetails,productimgurl,priority,isDelete,isEffective,great_time,modify_time from product where isDelete=0  and productid=@productid;";
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@productid", MySqlDbType.VarChar, 25);
            parameter.Value = productid;
            parameterList.Add(parameter);

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    if (sqlDataReader.Read())
                    {
                        Mproduct model = new Mproduct();
                        model.productid = sqlDataReader["productid"] != DBNull.Value ? sqlDataReader["productid"].ToString() : string.Empty;
                        model.classid = sqlDataReader["classid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["classid"].ToString()) : 0;
                        model.supclassid = sqlDataReader["supclassid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["supclassid"].ToString()) : 0;
                        model.className = sqlDataReader["className"] != DBNull.Value ? sqlDataReader["className"].ToString() : string.Empty;
                        model.supclassName = sqlDataReader["supclassName"] != DBNull.Value ? sqlDataReader["supclassName"].ToString() : string.Empty;
                        model.productname = sqlDataReader["productname"] != DBNull.Value ? sqlDataReader["productname"].ToString() : string.Empty;
                        model.productformat = sqlDataReader["productformat"] != DBNull.Value ? sqlDataReader["productformat"].ToString() : string.Empty;
                        model.productformatunit = sqlDataReader["productformatunit"] != DBNull.Value ? sqlDataReader["productformatunit"].ToString() : string.Empty;

                        model.origprice = sqlDataReader["origprice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["origprice"].ToString()) : 0;
                        model.sellprice = sqlDataReader["sellprice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["sellprice"].ToString()) : 0;
                        model.stock = sqlDataReader["stock"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["stock"].ToString()) : 0;
                        model.shelfstate = sqlDataReader["shelfstate"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["shelfstate"].ToString()) : 0;
                        model.hassellnum = sqlDataReader["hassellnum"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["hassellnum"].ToString()) : 0;

                        model.productdetails = sqlDataReader["productdetails"] != DBNull.Value ? sqlDataReader["productdetails"].ToString() : string.Empty;
                        model.productimgurl = sqlDataReader["productimgurl"] != DBNull.Value ? sqlDataReader["productimgurl"].ToString() : string.Empty;
                        model.priority = sqlDataReader["priority"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["priority"].ToString()) : 0;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                        return model;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 获取产品数据总条数
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="supclassid"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public int GetProductPagCount(int classid, int supclassid,string productname,int shelfstate) {
            string sql = " SELECT count(productid) as totalCount  FROM product WHERE  isDelete=0 ";
            if (classid>0)
            {
                sql = sql + " and classid =@classid";
            }

            if (supclassid > 0)
            {
                sql = sql + " and supclassid =@supclassid";
            }

            if (!string.IsNullOrEmpty(productname))
            {
                sql = sql + " and productname like @productname";
            }

            if (shelfstate != 0)
            {
                sql = sql + " and shelfstate =@shelfstate";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@classid", SqlDbType.Int);
            parameter.Value = classid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@supclassid", SqlDbType.Int);
            parameter.Value = supclassid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productname", MySqlDbType.Int16, 100);
            parameter.Value = productname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@shelfstate", SqlDbType.Int);
            parameter.Value = shelfstate;
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
        /// 获取产品数据总条数
        /// </summary>
        /// <param name="classid"></param>
        /// <param name="supclassid"></param>
        /// <param name="productname"></param>
        /// <param name="shelfstate"></param>
        /// <returns></returns>
        public List<Mproduct> GetProductPagList(int pagIndex, int pagCount, int classid, int supclassid, string productname, int shelfstate)
        {
            string sql = "  SELECT  TOP " + pagCount * pagIndex + " productid,classid,supclassid,className,supclassName,productname,productformat,productformatunit,origprice,sellprice,stock,shelfstate,hassellnum," +
                "productdetails,productimgurl,priority,isDelete,isEffective,great_time,modify_time " +
               " FROM( SELECT ROW_NUMBER() OVER(ORDER BY great_time DESC) AS ROWID,* FROM product) AS TEMP1  WHERE isDelete=0 and ROWID> " + pagCount * (pagIndex - 1);

            if (classid > 0)
            {
                sql = sql + " and classid =@classid";
            }

            if (supclassid > 0)
            {
                sql = sql + " and supclassid =@supclassid";
            }

            if (!string.IsNullOrEmpty(productname))
            {
                sql = sql + " and productname like @productname";
            }

            if (shelfstate != 0)
            {
                sql = sql + " and shelfstate =@shelfstate";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@classid", SqlDbType.Int);
            parameter.Value = classid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@supclassid", SqlDbType.Int);
            parameter.Value = supclassid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@productname", MySqlDbType.Int16, 100);
            parameter.Value = productname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@shelfstate", SqlDbType.Int);
            parameter.Value = shelfstate;
            parameterList.Add(parameter);

            List<Mproduct> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<Mproduct>();
                    while (sqlDataReader.Read())
                    {
                        Mproduct model = new Mproduct();
                        model.productid = sqlDataReader["productid"] != DBNull.Value ? sqlDataReader["productid"].ToString() : string.Empty;
                        model.classid = sqlDataReader["classid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["classid"].ToString()) : 0;
                        model.supclassid = sqlDataReader["supclassid"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["supclassid"].ToString()) : 0;
                        model.className = sqlDataReader["className"] != DBNull.Value ? sqlDataReader["className"].ToString() : string.Empty;
                        model.supclassName = sqlDataReader["supclassName"] != DBNull.Value ? sqlDataReader["supclassName"].ToString() : string.Empty;
                        model.productname = sqlDataReader["productname"] != DBNull.Value ? sqlDataReader["productname"].ToString() : string.Empty;
                        model.productformat = sqlDataReader["productformat"] != DBNull.Value ? sqlDataReader["productformat"].ToString() : string.Empty;
                        model.productformatunit = sqlDataReader["productformatunit"] != DBNull.Value ? sqlDataReader["productformatunit"].ToString() : string.Empty;

                        model.origprice = sqlDataReader["origprice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["origprice"].ToString()) : 0;
                        model.sellprice = sqlDataReader["sellprice"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["sellprice"].ToString()) : 0;
                        model.stock = sqlDataReader["stock"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["stock"].ToString()) : 0;
                        model.shelfstate = sqlDataReader["shelfstate"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["shelfstate"].ToString()) : 0;
                        model.hassellnum = sqlDataReader["hassellnum"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["hassellnum"].ToString()) : 0;

                        model.productdetails = sqlDataReader["productdetails"] != DBNull.Value ? sqlDataReader["productdetails"].ToString() : string.Empty;
                        model.productimgurl = sqlDataReader["productimgurl"] != DBNull.Value ? sqlDataReader["productimgurl"].ToString() : string.Empty;
                        model.priority = sqlDataReader["priority"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["priority"].ToString()) : 0;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;

                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }
    }
}
