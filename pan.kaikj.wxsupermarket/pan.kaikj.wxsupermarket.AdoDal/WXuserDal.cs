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
    public class WXuserDal : WXuserIdal
    {
        /// <summary>
        /// 新增微信用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddWXuser(MWXUserInfo model)
        {

            //// sql语句
            string sql = "INSERT INTO wxuser]([wxuserid],[subscribe],[openid],[nickname],[sex],[sexdes],[city],[country],[province],[language],[headimgurl],[subscribe_time],[remark],[tagid_list],[subscribe_scene],[subscribe_scene_des],[isDelete],[isEffective],[great_time],[modify_time]) " +
                         "VALUES (@wxuserid,@subscribe,@openid,@nickname,@sex,@sexdes,@city,@country,@province,@language,@headimgurl,@subscribe_time,@remark,@tagid_list,@subscribe_scene,@subscribe_scene_des,@isDelete,@isEffective,@great_time,@modify_time)";

            List<MySqlParameter> parameterList = GetMySqlParameterListByModel(model);

            //// 执行操作
            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 根据Openid获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public MWXUserInfo GetWXUserInfoByOpenid(string openid)
        {

            MWXUserInfo model = null;

            //// 语句
            string sql = "SELECT TOP 1 [wxuserid],[subscribe],[openid],[nickname],[sex],[sexdes],[city],[country],[province],[language],[headimgurl],[subscribe_time],[remark],[tagid_list],[subscribe_scene],[subscribe_scene_des],[great_time],[modify_time]  FROM wxuser] where openid=@openid";

            MySqlParameter[] parameterList = new MySqlParameter[1];
            MySqlParameter parameter = new MySqlParameter("@openid", MySqlDbType.VarChar, 50);
            parameter.Value = openid;
            parameterList[0] = parameter;

            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList))
            {
                if (sqlDataReader.Read())
                {
                    model = new MWXUserInfo();
                    model.wxuserid = sqlDataReader["wxuserid"] != DBNull.Value ? sqlDataReader["wxuserid"].ToString() : string.Empty;
                    model.subscribe = (sqlDataReader["subscribe"] != DBNull.Value && string.IsNullOrEmpty(sqlDataReader["subscribe"].ToString())) ? Convert.ToInt32(sqlDataReader["subscribe"].ToString()) : 0;
                    model.openid = sqlDataReader["openid"] != DBNull.Value ? sqlDataReader["openid"].ToString() : string.Empty;
                    model.nickname = sqlDataReader["nickname"] != DBNull.Value ? sqlDataReader["nickname"].ToString() : string.Empty;
                    model.sex = sqlDataReader["sex"] != DBNull.Value ? sqlDataReader["sex"].ToString() : string.Empty;
                    model.sexdes = sqlDataReader["sexdes"] != DBNull.Value ? sqlDataReader["sexdes"].ToString() : string.Empty;

                    model.city = sqlDataReader["city"] != DBNull.Value ? sqlDataReader["city"].ToString() : string.Empty;
                    model.country = sqlDataReader["country"] != DBNull.Value ? sqlDataReader["country"].ToString() : string.Empty;
                    model.province = sqlDataReader["province"] != DBNull.Value ? sqlDataReader["province"].ToString() : string.Empty;
                    model.language = sqlDataReader["language"] != DBNull.Value ? sqlDataReader["language"].ToString() : string.Empty;
                    model.headimgurl = sqlDataReader["headimgurl"] != DBNull.Value ? sqlDataReader["headimgurl"].ToString() : string.Empty;

                    model.subscribe_time = sqlDataReader["subscribe_time"] != DBNull.Value ? sqlDataReader["subscribe_time"].ToString() : string.Empty;
                    model.remark = sqlDataReader["remark"] != DBNull.Value ? sqlDataReader["remark"].ToString() : string.Empty;
                    model.tagid_list = sqlDataReader["tagid_list"] != DBNull.Value ? sqlDataReader["tagid_list"].ToString() : string.Empty;
                    model.subscribe_scene = sqlDataReader["subscribe_scene"] != DBNull.Value ? sqlDataReader["subscribe_scene"].ToString() : string.Empty;
                    model.subscribe_scene_des = sqlDataReader["subscribe_scene_des"] != DBNull.Value ? sqlDataReader["subscribe_scene_des"].ToString() : string.Empty;

                    model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                    model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;
                }
            }

            return model;
        }

        /// <summary>
        /// 根据id获取openId更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWXUserInfo(MWXUserInfo model)
        {
            string sql = "update wxuser] set subscribe='@subscribe',nickname='@nickname',sex='@sex',sexdes='@sexdes',city='@city',country='@country',province='@province',language='@language',headimgurl='@headimgurl',tagid_list='@tagid_list',subscribe_scene='@subscribe_scene',subscribe_scene_des='@subscribe_scene_des',qr_scene_str='@qr_scene_str',qr_scene='@qr_scene' where 1=1 ";

            if (!string.IsNullOrEmpty(model.wxuserid))
            {
                sql = sql + " and wxuserid=@wxuserid";
            }

            if (!string.IsNullOrEmpty(model.openid))
            {
                sql = sql + " and openid=@openid";
            }

            List<MySqlParameter> parameterList = GetMySqlParameterListByModel(model);

            return PKMySqlHelper.ExecuteNonQuery(sql, parameterList.ToArray()) > 0;
        }

        /// <summary>
        /// 分页获取微信用户信息
        /// </summary>
        /// <param name="pagIndex">页码（第一页从1 开始）</param>
        /// <param name="pagCount">每页数据条数</param>
        /// <returns></returns>
        public List<MWXUserInfo> GetWXUserInfoPagList(int pagIndex, int pagCount, string nickname, string subscribe)
        {
            string sql = "  SELECT  TOP " + pagCount * pagIndex + " [wxuserid],[subscribe],[openid],[nickname],[sex],[sexdes],[city],[country],[province],[language],[headimgurl],[subscribe_time],[remark],[tagid_list],[subscribe_scene],[subscribe_scene_des],[qr_scene],[qr_scene_str],[great_time],[modify_time] " +
                " FROM( SELECT ROW_NUMBER() OVER(ORDER BY great_time DESC) AS ROWID,* FROM wxuser]) AS TEMP1  WHERE ROWID> " + pagCount * (pagIndex - 1);

            if (!string.IsNullOrEmpty(nickname))
            {
                sql = sql + " and nickname like @nickname ";
            }

            if (!string.IsNullOrEmpty(subscribe))
            {
                sql = sql + " and subscribe= @subscribe ";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@nickname", MySqlDbType.Int16, 1);
            parameter.Value = nickname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@subscribe", MySqlDbType.Int16, 50);
            parameter.Value = subscribe;
            parameterList.Add(parameter);

            List<MWXUserInfo> listModel = null;
            using (MySqlDataReader sqlDataReader = PKMySqlHelper.ExecuteReader(sql, parameterList.ToArray()))
            {
                if (sqlDataReader != null)
                {
                    listModel = new List<MWXUserInfo>();
                    while (sqlDataReader.Read())
                    {
                        MWXUserInfo model = new MWXUserInfo();
                        model.wxuserid = sqlDataReader["wxuserid"] != DBNull.Value ? sqlDataReader["wxuserid"].ToString() : string.Empty;
                        model.subscribe = (sqlDataReader["subscribe"] != DBNull.Value && string.IsNullOrEmpty(sqlDataReader["subscribe"].ToString())) ? Convert.ToInt32(sqlDataReader["subscribe"].ToString()) : 0;
                        model.openid = sqlDataReader["openid"] != DBNull.Value ? sqlDataReader["openid"].ToString() : string.Empty;
                        model.nickname = sqlDataReader["nickname"] != DBNull.Value ? sqlDataReader["nickname"].ToString() : string.Empty;
                        model.sex = sqlDataReader["sex"] != DBNull.Value ? sqlDataReader["sex"].ToString() : string.Empty;
                        model.sexdes = sqlDataReader["sexdes"] != DBNull.Value ? sqlDataReader["sexdes"].ToString() : string.Empty;

                        model.city = sqlDataReader["city"] != DBNull.Value ? sqlDataReader["city"].ToString() : string.Empty;
                        model.country = sqlDataReader["country"] != DBNull.Value ? sqlDataReader["country"].ToString() : string.Empty;
                        model.province = sqlDataReader["province"] != DBNull.Value ? sqlDataReader["province"].ToString() : string.Empty;
                        model.language = sqlDataReader["language"] != DBNull.Value ? sqlDataReader["language"].ToString() : string.Empty;
                        model.headimgurl = sqlDataReader["headimgurl"] != DBNull.Value ? sqlDataReader["headimgurl"].ToString() : string.Empty;

                        model.subscribe_time = sqlDataReader["subscribe_time"] != DBNull.Value ? sqlDataReader["subscribe_time"].ToString() : string.Empty;
                        model.remark = sqlDataReader["remark"] != DBNull.Value ? sqlDataReader["remark"].ToString() : string.Empty;
                        model.tagid_list = sqlDataReader["tagid_list"] != DBNull.Value ? sqlDataReader["tagid_list"].ToString() : string.Empty;
                        model.subscribe_scene = sqlDataReader["subscribe_scene"] != DBNull.Value ? sqlDataReader["subscribe_scene"].ToString() : string.Empty;
                        model.subscribe_scene_des = sqlDataReader["subscribe_scene_des"] != DBNull.Value ? sqlDataReader["subscribe_scene_des"].ToString() : string.Empty;

                        model.great_time = sqlDataReader["great_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["great_time"].ToString()) : DateTime.MinValue;
                        model.modify_time = sqlDataReader["modify_time"] != DBNull.Value ? Convert.ToDateTime(sqlDataReader["modify_time"].ToString()) : DateTime.MinValue;

                        listModel.Add(model);
                    }
                }
            }

            return listModel;
        }

        /// <summary>
        /// 获取微信用户信息总条数
        /// </summary>
        /// <returns></returns>
        public int GetWXUserInfoPagCount(string nickname, string subscribe)
        {
            string sql = " SELECT count(wxuserid) as totalCount  FROM wxuser] WHERE 1=1 ";
            if (!string.IsNullOrEmpty(nickname))
            {
                sql = sql + " and nickname like @nickname ";
            }

            if (!string.IsNullOrEmpty(subscribe))
            {
                sql = sql + " and subscribe= @subscribe ";
            }

            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@nickname", MySqlDbType.Int16, 1);
            parameter.Value = nickname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@subscribe", MySqlDbType.Int16, 50);
            parameter.Value = subscribe;
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
        /// 获取关注来源描述信息
        /// </summary>
        /// <param name="subscribe_scene"></param>
        /// <returns></returns>
        private string GetSubscribeScenDes(string subscribe_scene)
        {
            switch (subscribe_scene)
            {
                case "ADD_SCENE_SEARCH":
                    return "公众号搜索";
                case "ADD_SCENE_ACCOUNT_MIGRATION":
                    return "公众号迁移";
                case "ADD_SCENE_PROFILE_CARD":
                    return "名片分享";
                case "ADD_SCENE_QR_CODE":
                    return "扫描二维码";
                case "ADD_SCENEPROFILE":
                    return "LINK 图文页内名称点击";
                case "ADD_SCENE_PROFILE_ITEM":
                    return "图文页右上角菜单";
                case "ADD_SCENE_PAID":
                    return "支付后关注";
                case "ADD_SCENE_OTHERS":
                    return "其他";
                default:
                    return "未知";
            }
        }

        /// <summary>
        /// 获取参数化查询对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<MySqlParameter> GetMySqlParameterListByModel(MWXUserInfo model)
        {
            List<MySqlParameter> parameterList = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@wxuserid", MySqlDbType.VarChar, 25);
            parameter.Value = model.wxuserid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@subscribe", MySqlDbType.Int16, 1);
            parameter.Value = model.subscribe;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@openid", MySqlDbType.VarChar, 50);
            parameter.Value = model.openid;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@nickname", MySqlDbType.VarChar, 50);
            parameter.Value = model.nickname;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@sex", MySqlDbType.VarChar, 1);
            parameter.Value = model.sex;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@sexdes", MySqlDbType.VarChar, 10);
            parameter.Value = model.sex == "1" ? "男" : (model.sex == "2" ? "女" : "未知");
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@city", MySqlDbType.VarChar, 30);
            parameter.Value = model.city;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@country", MySqlDbType.VarChar, 30);
            parameter.Value = model.country;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@province", MySqlDbType.VarChar, 30);
            parameter.Value = model.province;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@language", MySqlDbType.VarChar, 20);
            parameter.Value = model.language;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@headimgurl", MySqlDbType.VarChar, 200);
            parameter.Value = model.headimgurl;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@subscribe_time", SqlDbType.DateTime);
            parameter.Value = model.subscribe_time;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@remark", MySqlDbType.VarChar, 200);
            parameter.Value = model.remark;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@tagid_list", MySqlDbType.VarChar, 200);
            parameter.Value = model.tagid_list;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@subscribe_scene", MySqlDbType.VarChar, 50);
            parameter.Value = model.subscribe_scene;
            parameterList.Add(parameter);

            parameter = new MySqlParameter("@subscribe_scene_des", MySqlDbType.VarChar, 50);
            parameter.Value = this.GetSubscribeScenDes(model.subscribe_scene);
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
