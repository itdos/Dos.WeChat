#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：GetConfig
* Copyright(c) 道斯软件
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
using System.Text;using Dos.Common;
using System.Web.Configuration;

namespace Dos.WeChat
{
    /// <summary>
    /// 通用配置，可以修改为其它方式存储这些配置。
    /// </summary>
    public class WeChatConfig
    {
        #region 公众号配置
        /// <summary>
        /// 是否加解密
        /// </summary>
        /// <returns></returns>
        public static bool IsEncrypt()
        {
            var isEn = WebConfigurationManager.AppSettings["WeChatIsEncrypt"];
            if (string.IsNullOrWhiteSpace(isEn))
            {
                return false;
            }
            return isEn == "1";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetAppId()
        {
            return WebConfigurationManager.AppSettings["WeChatAppId"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetMchId()
        {
            return WebConfigurationManager.AppSettings["WeChatPartnerID"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetKey()
        {
            return WebConfigurationManager.AppSettings["WeChatPartnerKey"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCertPath()
        {
            return WebConfigurationManager.AppSettings["WeChatCertPath"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCertPwd()
        {
            return WebConfigurationManager.AppSettings["WeChatCertPwd"];
        }
        /// <summary>
        /// 获取web.config的WeChatSecret
        /// </summary>
        /// <returns></returns>
        public static string GetSecret()
        {
            return WebConfigurationManager.AppSettings["WeChatSecret"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetNotify()
        {
            return WebConfigurationManager.AppSettings["TenpayNotify"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            return WebConfigurationManager.AppSettings["WeChatToken"];
        }
        #endregion

        #region 第三方开放平台配置
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetOpenAppId()
        {
            return WebConfigurationManager.AppSettings["OpenAppId"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetOpenAppSecret()
        {
            return WebConfigurationManager.AppSettings["OpenAppSecret"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetOpenToken()
        {
            return WebConfigurationManager.AppSettings["OpenToken"];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetOpenDesKey()
        {
            return WebConfigurationManager.AppSettings["OpenDESKey"];
        }
        #endregion
    }
}
