/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：winXin.GongZhongHao.Model
*文件名：  MWXUserInfo
*版本号：  V1.0.0.0
*唯一标识：ebe44929-b49e-4655-a2ac-025c4069a6bd
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/7 23:42:45

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/7 23:42:45
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.AdoModel
{
    /// <summary>
    /// MWXUserInfo
    /// </summary>
    public class MWXUserInfo
    {
        /// <summary>
        /// 用户ID yyyyMMddHHmmssfff+6位随机数
        /// </summary>
        public string wxuserid { get; set; }

        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        public int subscribe { get; set; }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public string sex { get; set; }

        public string sexdes { get; set; }

        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        public string headimgurl { get; set; }

        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public string subscribe_time { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段
        /// </summary>
        public string unionid { get; set; }

        /// <summary>
        /// 公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 用户所在的分组ID（兼容旧的用户分组接口）
        /// </summary>
        public string groupid { get; set; }

        /// <summary>
        /// 用户被打上的标签ID列表
        /// </summary>
        public string tagid_list { get; set; }

        /// <summary>
        /// 返回用户关注的渠道来源，ADD_SCENE_SEARCH 公众号搜索，ADD_SCENE_ACCOUNT_MIGRATION 公众号迁移，ADD_SCENE_PROFILE_CARD 名片分享，ADD_SCENE_QR_CODE 扫描二维码，ADD_SCENEPROFILE LINK 图文页内名称点击，ADD_SCENE_PROFILE_ITEM 图文页右上角菜单，ADD_SCENE_PAID 支付后关注，ADD_SCENE_OTHERS 其他
        /// </summary>
        public string subscribe_scene { get; set; }

        /// <summary>
        /// 返回用户关注的渠道来源 描述，ADD_SCENE_SEARCH 公众号搜索，ADD_SCENE_ACCOUNT_MIGRATION 公众号迁移，ADD_SCENE_PROFILE_CARD 名片分享，ADD_SCENE_QR_CODE 扫描二维码，ADD_SCENEPROFILE LINK 图文页内名称点击，ADD_SCENE_PROFILE_ITEM 图文页右上角菜单，ADD_SCENE_PAID 支付后关注，ADD_SCENE_OTHERS 其他
        /// </summary>
        public string subscribe_scene_des { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int isDelete { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public int isEffective { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime great_time { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime modify_time { get; set; }
    }
}
