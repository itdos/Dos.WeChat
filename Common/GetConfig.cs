#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：GetConfig
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/29 10:50:57
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    public class GetConfig
    {
        /// <summary>
        /// 传入WeChatPublic
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetAppid(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) || param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatAppId"];
            }
            return WebConfigurationManager.AppSettings["WeChatAppId_" + param.WeChatPublic];
        }
        public static string GetMchId(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) || param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatPartnerID"];
            }
            return WebConfigurationManager.AppSettings["WeChatPartnerID_" + param.WeChatPublic];
        }
        public static string GetKey(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) || param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatPartnerKey"];
            }
            return WebConfigurationManager.AppSettings["WeChatPartnerKey_" + param.WeChatPublic];
        }
        public static string GetCertPath(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) || param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatCertPath"];
            }
            return WebConfigurationManager.AppSettings["WeChatCertPath_" + param.WeChatPublic];
        }
        public static string GetCertPwd(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) || param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatCertPwd"];
            }
            return WebConfigurationManager.AppSettings["WeChatCertPwd_" + param.WeChatPublic];
        }
        /// <summary>
        /// 获取web.config的WeChatSecret
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetSecret(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) ||
                param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatSecret"];
            }
            return WebConfigurationManager.AppSettings["WeChatSecret_" + param.WeChatPublic];
        }
        public static string GetNotify(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) ||
                param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["TenpayNotify"];
            }
            return WebConfigurationManager.AppSettings["TenpayNotify_" + param.WeChatPublic];
        }
        public static string GetToken(WeChatParam param = null)
        {
            if (param == null || string.IsNullOrWhiteSpace(param.WeChatPublic) || param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatToken"];
            }
            return WebConfigurationManager.AppSettings["WeChatToken_" + param.WeChatPublic];
        }
    }
}
