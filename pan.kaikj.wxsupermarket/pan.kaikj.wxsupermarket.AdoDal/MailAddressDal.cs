/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.AdoDal
*文件名：  MailAddressDal
*版本号：  V1.0.0.0
*唯一标识：52aa1b30-2afd-4636-a2b2-26db3ff67b9c
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/23 19:41:48

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/23 19:41:48
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using pan.kaikj.wxsupermarket.AdoIdal;
using pan.kaikj.wxsupermarket.AdoModel;
using MySql.Data.MySqlClient;
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
    /// MailAddressDal
    /// </summary>
    public class MailAddressDal: MailAddressIdal
    {
        /// <summary>
        /// 新增地址
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddMailAddress(MmailAddress model)
        {
            //// sql语句
            string sql = "";
            if (model.isDefault=="1")
            {
                sql = "update mailAddress set isDefault=0 where userId=@userId;";
            }
             sql += "INSERT INTO mailAddress (addressId,userId,userName,province,city,area,detailedAddress,contactName,contactTell,isDefault,isDelete,isEffective,great_time,modify_time) " +
                         "VALUES(@addressId,@userId,@userName,@province,@city,@area,@detailedAddress,@contactName,@contactTell,@isDefault,@isDelete,@isEffective,@great_time,@modify_time)";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@addressId", MySqlDbType.VarChar, 25);
            parameter.Value = model.addressId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@userId", MySqlDbType.VarChar, 25);
            parameter.Value = model.userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@userName", MySqlDbType.VarChar, 50);
            parameter.Value = model.userName;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@province", MySqlDbType.VarChar, 30);
            parameter.Value = string.IsNullOrEmpty(model.province)?"": model.province;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@city", MySqlDbType.VarChar, 30);
            parameter.Value = string.IsNullOrEmpty(model.city) ? "" : model.city;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@area", MySqlDbType.VarChar, 30);
            parameter.Value = string.IsNullOrEmpty(model.area) ? "" : model.area;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@detailedAddress", MySqlDbType.VarChar, 200);
            parameter.Value = model.detailedAddress;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@contactName", MySqlDbType.VarChar, 30);
            parameter.Value = model.contactName;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@contactTell", MySqlDbType.VarChar, 20);
            parameter.Value = model.contactTell;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@isDefault", MySqlDbType.Int16, 1);
            parameter.Value = model.isDefault;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@isDelete", MySqlDbType.Int16, 1);
            parameter.Value = 0;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@isEffective", MySqlDbType.Int16, 1);
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
        /// 更新用户的默认地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public bool UpdateMailAddressDefault(string userId, string addressId)
        {

            //// 首先清空默认地址，然后在将需要设置的默认地址数据设置为默认地址

            string sql = "update mailAddress set isDefault=0 where userId=@userId;update mailAddress set isDefault=1 where userId=@userId and addressId=@addressId; ";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@addressId", MySqlDbType.VarChar, 25);
            parameter.Value = addressId;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 删除邮寄地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public bool DeleteMailAddress(string userId, string addressId)
        {
            string sql = "delete mailAddress set where userId=@userId and addressId=@addressId; ";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@addressId", MySqlDbType.VarChar, 25);
            parameter.Value = addressId;
            parameterList.Add(parameter);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据用户ID获取其全部地址信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<MmailAddress> GetMmailAddressesByUserId(string userId)
        {
            string sql = "select addressId,userId,userName,province,city,area,detailedAddress,contactName,contactTell,isDefault,isDelete,isEffective,great_time,modify_time from mailAddress where userId=@userId;";

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@userId", MySqlDbType.VarChar, 25);
            parameter.Value = userId;
            parameterList.Add(parameter);

            List<MmailAddress> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<MmailAddress>();
                    while (sqlDataReader.Read())
                    {
                        MmailAddress model = new MmailAddress();
                        model.addressId = sqlDataReader["addressId"] != DBNull.Value ? sqlDataReader["addressId"].ToString() : string.Empty;
                        model.userId = sqlDataReader["userId"] != DBNull.Value ? sqlDataReader["userId"].ToString() : string.Empty;
                        model.userName = sqlDataReader["userName"] != DBNull.Value ? sqlDataReader["userName"].ToString() : string.Empty;
                        model.province = sqlDataReader["province"] != DBNull.Value ? sqlDataReader["province"].ToString() : string.Empty;

                        model.city = sqlDataReader["city"] != DBNull.Value ? sqlDataReader["city"].ToString() : string.Empty;
                        model.area = sqlDataReader["area"] != DBNull.Value ? sqlDataReader["area"].ToString() : string.Empty;
                        model.detailedAddress = sqlDataReader["detailedAddress"] != DBNull.Value ? sqlDataReader["detailedAddress"].ToString() : string.Empty;
                        model.contactName = sqlDataReader["contactName"] != DBNull.Value ? sqlDataReader["contactName"].ToString() : string.Empty;

                        model.contactTell = sqlDataReader["contactTell"] != DBNull.Value ? sqlDataReader["contactTell"].ToString() : string.Empty;
                        model.isDefault = sqlDataReader["isDefault"] != DBNull.Value ? sqlDataReader["isDefault"].ToString() : string.Empty;
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
