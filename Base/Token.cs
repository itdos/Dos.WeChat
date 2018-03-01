#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Credential
* Copyright(c) 道斯软件
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
    /// 
    /// </summary>
    public class TokenHelper
    {
        /// <summary>
        /// 获取access_token。会缓存，过期后自动重新获取新的token。
        /// </summary>
        public static TokenResult GetAccessToken()
        {
            var appId = WeChatConfig.GetAppId();
            var secret = WeChatConfig.GetSecret();
            var result = CacheHelper.Get("AccessToken" + appId) as TokenResult;
            if (result == null || string.IsNullOrWhiteSpace(result.AccessToken))
            {
                result = HttpHelper.Get<TokenResult>(ApiList.GetTokenUrl, new
                    {
                        grant_type = "client_credential",
                        appid = appId,
                        secret = secret
                    });
                if (result.IsSuccess)
                {
                    CacheHelper.Set("AccessToken" + appId, result, result.ExpiresIn - 60);
                }
                else
                {
                    LogHelper.Debug("GetAccessToken失败！" + result.ErrMsg, "微信_Fail_");
                }
            }
            return result;
        }
        /// <summary>
        /// 获取第三方平台AccessToken
        /// 传入component_verify_ticket
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ComponentTokenResult GetOpenAccessToken(WeChatParam param)
        {
            var result = Open.GetComponentToken(new WeChatParam()
            {
                ComponentVerifyTicket = param.ComponentVerifyTicket
            });
            return result;
        }
        /// <summary>
        /// 获取授权公众号的接口调用凭据（令牌）。传入：authorizer_appid(授权方appid)、authorizer_refresh_token（授权方的刷新令牌）、component_verify_ticket(微信后台推送的ticket，此ticket会定时推送)
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static AuthorizerTokenResult GetAuthorizerAccessToken(WeChatParam param)
        {
            if (string.IsNullOrWhiteSpace(param.AuthorizerAppid))
            {
                return null;
            }
            var token = CacheHelper.Get("AuthorizerAccessToken" + param.AuthorizerAppid) as AuthorizerTokenResult;
            if (token != null && !string.IsNullOrWhiteSpace(token.AuthorizerAccessToken))
            {
                return token;
            }
            var componentAccessToken = Open.GetComponentToken(new WeChatParam()
            {
                ComponentVerifyTicket = param.ComponentVerifyTicket
            });
            if (!componentAccessToken.IsSuccess)
            {
                return new AuthorizerTokenResult()
                {
                    IsSuccess = false,
                    ErrMsg = componentAccessToken.ErrMsg
                };
            }
            var result = HttpHelper.Post<AuthorizerTokenResult>(new HttpParam()
            {
                Url = ApiList.ApiAuthorizerToken,
                PostParam = new
                    {
                        component_appid = WeChatConfig.GetOpenAppId(),
                        authorizer_appid = param.AuthorizerAppid,
                        authorizer_refresh_token = param.AuthorizerRefreshToken
                    },
                GetParam = new
                {
                    component_access_token = componentAccessToken.ComponentAccessToken
                }
            });
            if (result.IsSuccess && !string.IsNullOrWhiteSpace(result.AuthorizerAccessToken))
            {
                CacheHelper.Set("AuthorizerAccessToken" + param.AuthorizerAppid, result,
                    result.ExpiresIn - 60);
            }
            else
            {
                LogHelper.Debug("GetAuthorizerAccessToken失败！" + result.ErrMsg, "微信_Fail_");
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        public static JsapiTicketResult GetJsapiTicket()
        {
            var appId = WeChatConfig.GetAppId();
            var result = CacheHelper.Get("JsapiTicket" + appId) as JsapiTicketResult;
            if (result == null || string.IsNullOrWhiteSpace(result.Ticket))
            {
                result = HttpHelper.Get<JsapiTicketResult>(ApiList.GetticketUrl, new
                    {
                        access_token = GetAccessToken().AccessToken,
                        type = "jsapi"
                    });

                if (result.ErrMsg != "ok")
                    throw new Exception("获取JsapiTicket失败！" + result.ErrCode + "_" + result.ErrMsg);

                if (result.IsSuccess)
                {
                    CacheHelper.Set("JsapiTicket" + appId, result, result.ExpiresIn - 60);
                }
                else
                {
                    LogHelper.Debug("GetJsapiTicket失败！" + result.ErrMsg, "微信_Fail_");
                }
            }
            return result;
        }
    }
}
