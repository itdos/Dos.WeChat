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
        public static string GetAppid(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatAppId"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatAppId_XczJl"];
            }
            return WebConfigurationManager.AppSettings["WeChatAppId"];
        }
        public static string GetMchId(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["PartnerID"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["PartnerID_XczJl"];
            }
            return WebConfigurationManager.AppSettings["PartnerID"];
        }
        public static string GetKey(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["PartnerKey"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["PartnerKey_XczJl"];
            }
            return WebConfigurationManager.AppSettings["PartnerKey"];
        }
        public static string GetCertPath(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatCertPath"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatCertPath_XczJl"];
            }
            return WebConfigurationManager.AppSettings["WeChatCertPath"];
        }
        public static string GetCertPwd(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatCertPwd"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatCertPwd_XczJl"];
            }
            return WebConfigurationManager.AppSettings["WeChatCertPwd"];
        }
        public static string GetSecret(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatSecret"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatSecret_XczJl"];
            }
            return WebConfigurationManager.AppSettings["WeChatSecret"];
        }
        public static string GetNotify(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["TenpayNotify"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["TenpayNotify_XczJl"];
            }
            return WebConfigurationManager.AppSettings["TenpayNotify"];
        }
        public static string GetToken(WeChatParam param)
        {
            if (param.WeChatPublic == EnumHelper.WeChatPublic.Xcz.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatToken"];
            }
            else if (param.WeChatPublic == EnumHelper.WeChatPublic.XczJl.ToString())
            {
                return WebConfigurationManager.AppSettings["WeChatToken_XczJl"];
            }
            return WebConfigurationManager.AppSettings["WeChatToken"];
        }
    }
}
