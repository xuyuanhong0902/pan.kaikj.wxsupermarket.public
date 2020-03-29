/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：pan.kaikj.wxsupermarket.bus
*文件名：  AliyunMessageApi
*版本号：  V1.0.0.0
*唯一标识：ba923287-3221-4b8a-9d37-ea3f002c1154
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/12/15 21:38:42

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/12/15 21:38:42
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// AliyunMessageApi
    /// </summary>
    public class AliyunMessageApi
    {
        public void SedMessage() {
            String product = "Dysmsapi";//短信API产品名称
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名
            String accessId = "";
            String accessSecret = "";
            String regionIdForPop = "cn-hangzhou";

            IClientProfile profile = DefaultProfile.GetProfile(regionIdForPop, accessId, accessSecret);
            DefaultProfile.AddEndpoint(regionIdForPop, regionIdForPop, product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //request.SignName = "上云预发测试";//"管理控制台中配置的短信签名（状态必须是验证通过）"
                //request.TemplateCode = "SMS_71130001";//管理控制台中配置的审核通过的短信模板的模板CODE（状态必须是验证通过）"
                //request.RecNum = "13567939485";//"接收号码，多个号码可以逗号分隔"
                //request.ParamString = "{\"name\":\"123\"}";//短信模板中的变量；数字需要转换为字符串；个人用户每个变量长度必须小于15个字符。"
                //SingleSendSmsResponse httpResponse = client.GetAcsResponse(request);
                request.PhoneNumbers = "15908150902";
                request.SignName = "";
                request.TemplateCode = "SMS_152543887";
                request.TemplateParam = "{\"name\":\"许洪远\",\"88.88\"}";
                request.OutId = "xxxxxxxx";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                System.Console.WriteLine(sendSmsResponse.Message);

            }
            catch (System.Runtime.Remoting.ServerException e)
            {
                System.Console.WriteLine("ServerException");
            }
            catch (ClientException e)
            {
                System.Console.WriteLine("ClientException");
            }
        }
    }
}
