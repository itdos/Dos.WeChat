#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Credential
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/10/25 11:21:51
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using Dos.Common;
using Dos.WeChat;
using Dos.WeChat.Common;
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    /// <summary>
    /// Token
    /// </summary>
    public class Token
    {
        /// <summary>
        /// jsapi_ticket缓存
        /// </summary>
        private static readonly Dictionary<string, TokenCache> AccessTicketsCache =
            new Dictionary<string, TokenCache>();
        /// <summary>
        /// access_token缓存
        /// </summary>
        private static readonly Dictionary<string, TokenCache> AccessTokensCache =
            new Dictionary<string, TokenCache>();
        /// <summary>
        /// 获取access_token。会缓存，过期后自动重新获取新的token。
        /// </summary>
        public static string GetAccessToken(WeChatParam param)
        {
            var appId = GetConfig.GetAppid(param);
            var secret = GetConfig.GetSecret(param);
            if (!AccessTokensCache.ContainsKey(appId) || AccessTokensCache[appId] == null
                    || AccessTokensCache[appId].ExpireTime < DateTime.Now)
            {
                var result = HttpHelper.Get<TokenResult>(ApiList.GetTokenUrl, new HttpParam
                    {
                        {"grant_type", "client_credential"},
                        {"appid", appId},
                        {"secret", secret}
                    });
                if (!result.IsSuccess)
                    throw new WxException(result.errcode, result.errmsg);
                AccessTokensCache[appId] = new TokenCache
                {
                    AccessToken = result.access_token,
                    ExpireTime = DateTime.Now.AddSeconds(result.expires_in - 60)
                };
            }
            return AccessTokensCache[appId].AccessToken;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        public static void RemoveCache(string appId)
        {
            AccessTokensCache.Remove(appId);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void ClearCache()
        {
            AccessTokensCache.Clear();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static string GetJsapiTicket(WeChatParam param)
        {
            var appId = GetConfig.GetAppid(param);
            if (!AccessTicketsCache.ContainsKey(appId) || AccessTicketsCache[appId] == null
                || AccessTicketsCache[appId].ExpireTime < DateTime.Now)
            {
                var result = HttpHelper.Get<TokenResult>(ApiList.GetticketUrl, new HttpParam
                    {
                        {"access_token", GetAccessToken(param)},
                        {"type", "jsapi"}
                    });
                if (result.errmsg != "ok")
                    throw new WxException(result.errcode, result.errmsg);

                AccessTicketsCache[appId] = new TokenCache
                {
                    JsapiTicket = result.ticket,
                    ExpireTime = DateTime.Now.AddSeconds(result.expires_in - 3)
                };
            }
            return AccessTicketsCache[appId].JsapiTicket;
        }
        private class TokenCache
        {
            public string JsapiTicket { get; set; }
            public string AccessToken { get; set; }
            public DateTime ExpireTime { get; set; }
        }
    }

    /// <summary>
    /// 获取凭证时的响应数据
    /// </summary>
    internal class TokenResult : BaseResultModel
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get { return !string.IsNullOrEmpty(access_token); }
        }
    }
}