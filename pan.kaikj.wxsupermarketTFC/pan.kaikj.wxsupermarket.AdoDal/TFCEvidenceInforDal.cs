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
using pan.kaikj.wxsupermarket.AdoSqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoDal
{
    /// <summary>
    /// ProductDal
    /// </summary>
    public class TFCEvidenceInforDal: TFCEvidenceInfordal
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(MTFCEvidenceInfor model)
        {
            //// sql语句  
       
        string sql = "INSERT INTO TFCEvidenceInfor(amountType,Id,userName,telNum,buildNum,roomNum,thirdPartyCompanyName,payAmount,payDate,domicile,evidences,great_time) " +
                             "VALUES (@amountType,@Id,@userName,@telNum,@buildNum,@roomNum,@thirdPartyCompanyName,@payAmount,@payDate,@domicile,@evidences,@great_time)";
            List<SqlParameter> parameterList = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@Id", SqlDbType.VarChar, 25);
            parameter.Value = model.Id;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@userName", SqlDbType.NVarChar,50);
            parameter.Value = model.userName;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@telNum", SqlDbType.NVarChar, 25);
            parameter.Value = model.telNum;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@buildNum", SqlDbType.NVarChar, 25);
            parameter.Value = model.buildNum;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@roomNum", SqlDbType.NVarChar, 25);
            parameter.Value = model.roomNum;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@thirdPartyCompanyName", SqlDbType.NVarChar, 100);
            parameter.Value = model.thirdPartyCompanyName;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@payAmount", SqlDbType.Decimal);
            parameter.Value = model.payAmount;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@payDate", SqlDbType.DateTime);
            parameter.Value = model.payDate;
            parameterList.Add(parameter);
            

            parameter = new SqlParameter("@domicile", SqlDbType.NVarChar, 50);
            parameter.Value = model.domicile;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@evidences", SqlDbType.NVarChar, 100);
            parameter.Value = model.evidences;
            parameterList.Add(parameter);

            DateTime dateTime = System.DateTime.Now;
            parameter = new SqlParameter("@great_time", SqlDbType.DateTime);
            parameter.Value = dateTime;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@amountType", SqlDbType.Int);
            parameter.Value = model.amountType<1?1: model.amountType;
            parameterList.Add(parameter);
            

            //// 执行操作
            return SqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据id删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delet(string id)
        {
            string sql = "delete from TFCEvidenceInfor where id=@id;";

            List<SqlParameter> parameterList = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList.Add(parameter);

            //// 执行操作
            return SqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MTFCEvidenceInfor GetInfoById(string id) {
            string sql = "select amountType,Id,userName,telNum,buildNum,roomNum,thirdPartyCompanyName,payAmount,payDate,domicile,evidences,great_time from TFCEvidenceInfor  where  id=@id;";
            List<SqlParameter> parameterList = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@id", SqlDbType.VarChar, 25);
            parameter.Value = id;
            parameterList.Add(parameter);

            using (SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    if (sqlDataReader.Read())
                    {
                        MTFCEvidenceInfor model = new MTFCEvidenceInfor();
                        model.Id = sqlDataReader["Id"] != DBNull.Value ? sqlDataReader["Id"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.telNum = sqlDataReader["telNum"] != DBNull.Value ? sqlDataReader["telNum"].ToString() : string.Empty;
                        model.buildNum = sqlDataReader["buildNum"] != DBNull.Value ? sqlDataReader["buildNum"].ToString() : string.Empty;
                        model.roomNum = sqlDataReader["roomNum"] != DBNull.Value ? sqlDataReader["roomNum"].ToString() : string.Empty;
                        model.thirdPartyCompanyName = sqlDataReader["thirdPartyCompanyName"] != DBNull.Value ? sqlDataReader["thirdPartyCompanyName"].ToString() : string.Empty;

                        model.payAmount = sqlDataReader["payAmount"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["payAmount"].ToString()) : 0;
                        model.payDate = sqlDataReader["payDate"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["payDate"]).ToString("yyyy-MM-dd") : "1900-01-01";
                        model.domicile = sqlDataReader["domicile"] != DBNull.Value ? sqlDataReader["domicile"].ToString() : string.Empty;
                        model.evidences = sqlDataReader["evidences"] != DBNull.Value ? sqlDataReader["evidences"].ToString() : string.Empty;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()).ToString("yyyy-MM-dd") : "1900-01-01";
                        model.amountType = sqlDataReader["amountType"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["amountType"].ToString()):1;

                        return model;
                    }
                }
            }

            return null;

        }

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
       public   int GetInfoPagCount(string userName, string buildNum, string amountType)
        {
            string sql = " SELECT count(Id) as totalCount  FROM TFCEvidenceInfor WHERE  1=1 ";

            if (!string.IsNullOrEmpty(userName))
            {
                sql = sql + " and userName like @userName";
            }

            if (!string.IsNullOrEmpty(buildNum)&& buildNum!="0")
            {
                sql = sql + " and buildNum = @buildNum";
            } 

           if (!string.IsNullOrEmpty(amountType) && amountType != "0")
            {
                sql = sql + " and amountType = @amountType";
            }

            List<SqlParameter> parameterList = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            parameter.Value = "%"+ userName+"%";
            parameterList.Add(parameter);

            parameter = new SqlParameter("@buildNum", SqlDbType.NVarChar, 25);
            parameter.Value =  buildNum ;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@amountType", SqlDbType.Int);
            parameter.Value = amountType;
            parameterList.Add(parameter);

            using (SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(sql, parameterList.ToArray()))
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
        public List<MTFCEvidenceInfor> GetInfoPagList(int pagIndex, int pagCount, string userName, string buildNum, string amountType)
        {

            string sql = " SELECT TOP " + pagCount * pagIndex + " amountType,Id,userName,telNum,buildNum,roomNum,thirdPartyCompanyName,payAmount,payDate,domicile,evidences,great_time   " +
                  " FROM( SELECT  ROW_NUMBER() OVER(ORDER BY buildNum asc, roomNum asc  ) AS ROWID,* FROM [TFCEvidenceInfor]) AS TEMP1  WHERE ROWID> " + pagCount * (pagIndex - 1);
        
            if (!string.IsNullOrEmpty(userName))
            {
                sql = sql + " and userName like @userName";
            }

            if (!string.IsNullOrEmpty(buildNum) && buildNum != "0")
            {
                sql = sql + " and buildNum = @buildNum";
            }

            if (!string.IsNullOrEmpty(amountType) && amountType != "0")
            {
                sql = sql + " and amountType = @amountType";
            }

            List<SqlParameter> parameterList = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            parameter.Value = "%" + userName + "%";
            parameterList.Add(parameter);

            parameter = new SqlParameter("@buildNum", SqlDbType.NVarChar, 25);
            parameter.Value =  buildNum  ;
            parameterList.Add(parameter);

            parameter = new SqlParameter("@amountType", SqlDbType.Int);
            parameter.Value = amountType;
            parameterList.Add(parameter);


            List<MTFCEvidenceInfor> listModel = null;
            using (SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<MTFCEvidenceInfor>();
                    while (sqlDataReader.Read())
                    {
                        MTFCEvidenceInfor model = new MTFCEvidenceInfor();
                        model.Id = sqlDataReader["Id"] != DBNull.Value ? sqlDataReader["Id"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.telNum = sqlDataReader["telNum"] != DBNull.Value ? sqlDataReader["telNum"].ToString() : string.Empty;
                        model.buildNum = sqlDataReader["buildNum"] != DBNull.Value ? sqlDataReader["buildNum"].ToString() : string.Empty;
                        model.roomNum = sqlDataReader["roomNum"] != DBNull.Value ? sqlDataReader["roomNum"].ToString() : string.Empty;
                        model.thirdPartyCompanyName = sqlDataReader["thirdPartyCompanyName"] != DBNull.Value ? sqlDataReader["thirdPartyCompanyName"].ToString() : string.Empty;

                        model.payAmount = sqlDataReader["payAmount"] != DBNull.Value ? Convert.ToDecimal(sqlDataReader["payAmount"].ToString()) : 0;
                        model.payDate = sqlDataReader["payDate"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["payDate"]).ToString("yyyy-MM-dd") : "1900-01-01";
                        model.domicile = sqlDataReader["domicile"] != DBNull.Value ? sqlDataReader["domicile"].ToString() : string.Empty;
                        model.evidences = sqlDataReader["evidences"] != DBNull.Value ? sqlDataReader["evidences"].ToString() : string.Empty;
                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()).ToString("yyyy-MM-dd") : "1900-01-01";
                        model.amountType = sqlDataReader["amountType"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["amountType"].ToString()) : 1;

                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }

        /// <summary>
        /// 获取总条数(根据电话号码)
        /// </summary>
        /// <returns></returns>
        public int CheckPhonHasUser(string phonNum)
        {
            string sql = " SELECT count(Id) as totalCount  FROM TFCEvidenceInfor WHERE  telNum=@telNum";

            List<SqlParameter> parameterList = new List<SqlParameter>();
            SqlParameter parameter = new SqlParameter("@telNum", SqlDbType.NVarChar, 25);
            parameter.Value = phonNum;
            parameterList.Add(parameter);

            using (SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(sql, parameterList.ToArray()))
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
    }
}
