using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using Dos.Common;
using Dos.Common;
using Dos.WeChat.Common;


namespace Dos.WeChat
{
    /// <summary>
    /// 开放平台api
    /// </summary>
    public class Open
    {
        /// <summary>
        /// 获取第三方平台access_token。该API用于获取第三方平台令牌（component_access_token）
        /// <para>传入：ComponentVerifyTicket(微信后台推送的ticket，此ticket会定时推送)</para>
        /// </summary>
        /// <param name="param"></param>
        /// <returns>返回ComponentAccessToken(第三方平台access_token)</returns>
        public static ComponentTokenResult GetComponentToken(WeChatParam param)
        {
            var result = CacheHelper.Get("ComponentToken") as ComponentTokenResult;
            if (result == null || string.IsNullOrWhiteSpace(result.ComponentAccessToken))
            {
                result = HttpHelper.Post<ComponentTokenResult>(ApiList.ApiComponentToken, new
                {
                    component_appid = WeChatConfig.GetOpenAppId(),
                    component_appsecret = WeChatConfig.GetOpenAppSecret(),
                    component_verify_ticket = param.ComponentVerifyTicket
                });
                if (!string.IsNullOrWhiteSpace(result.ComponentAccessToken))
                {
                    CacheHelper.Set("ComponentToken", result, result.ExpiresIn - 60);
                }
                else
                {
                    LogHelper.Debug("GetComponentToken失败！" + result.ErrMsg, "微信_Fail_");
                }
            }
            return result;
        }
        /// <summary>
        /// 获取预授权码.该API用于获取预授权码。预授权码用于公众号授权时的第三方平台方安全验证。
        /// <para>传入：ComponentVerifyTicket(微信后台推送的ticket，此ticket会定时推送)</para>
        /// </summary>
        /// <param name="param"></param>
        /// <returns>返回：pre_auth_code(预授权码)、expires_in（有效期，为20分钟）</returns>
        public static CreatePreauthcodeResult GetCreatePreAuthCode(WeChatParam param)
        {
            var result = CacheHelper.Get("PreAuthCode") as CreatePreauthcodeResult;
            if (result == null || string.IsNullOrWhiteSpace(result.PreAuthCode))
            {
                var token = GetComponentToken(new WeChatParam()
                {
                    ComponentVerifyTicket = param.ComponentVerifyTicket
                });
                if (!token.IsSuccess)
                {
                    return new CreatePreauthcodeResult()
                    {
                        IsSuccess = false,
                        ErrMsg = token.ErrMsg
                    };
                }
                result = HttpHelper.Post<CreatePreauthcodeResult>(new HttpParam()
                {
                    Url = ApiList.ApiCreatePreauthcode,
                    PostParam = new
                    {
                        component_appid = WeChatConfig.GetOpenAppId()
                    },
                    GetParam = new
                    {
                        component_access_token = token.ComponentAccessToken
                    }
                });
                if (!string.IsNullOrWhiteSpace(result.PreAuthCode))
                {
                    CacheHelper.Set("PreAuthCode", result, result.ExpiresIn);
                }
                else
                {
                    LogHelper.Debug("GetCreatePreAuthCode失败！" + result.ErrMsg, "微信_Fail_");
                }
            }
            return result;
        }
        /// <summary>
        /// 使用授权码换取公众号的接口调用凭据和授权信息
        /// <para>传入：AuthorizationCode(授权code)、ComponentVerifyTicket(微信后台推送的ticket，此ticket会定时推送)</para>
        /// </summary>
        /// <param name="param"></param>
        public static QueryAuthResult QueryAuth(WeChatParam param)
        {
            var result = CacheHelper.Get("QueryAuth") as QueryAuthResult;
            if (result == null || string.IsNullOrWhiteSpace(result.AuthorizationInfo.AuthorizerAccessToken))
            {
                var token = GetComponentToken(new WeChatParam()
                {
                    ComponentVerifyTicket = param.ComponentVerifyTicket
                });
                if (!token.IsSuccess)
                {
                    return new QueryAuthResult()
                    {
                        IsSuccess = false,
                        ErrMsg = token.ErrMsg
                    };
                }
                result = HttpHelper.Post<QueryAuthResult>(new HttpParam()
                {
                    Url = ApiList.ApiQueryAuth,
                    PostParam = new
                        {
                            component_appid = WeChatConfig.GetOpenAppId(),
                            authorization_code = param.AuthorizationCode
                        },
                    GetParam = new
                    {

                        component_access_token = token.ComponentAccessToken
                    }
                });
                if (result.AuthorizationInfo != null)
                {
                    CacheHelper.Set("QueryAuth", result, result.AuthorizationInfo.ExpiresIn - 60);
                }
                else
                {
                    LogHelper.Debug("QueryAuth失败！" + result.ErrMsg, "微信_Fail_");
                }
            }
            return result;
        }
        /// <summary>
        /// 获取授权方的公众号帐号基本信息。该API用于获取授权方的公众号基本信息，包括头像、昵称、帐号类型、认证类型、微信号、原始ID和二维码图片URL。
        /// <para>传入：AuthorizerAppid(授权方appid)、ComponentVerifyTicket(微信后台推送的ticket，此ticket会定时推送)</para>
        /// </summary>
        /// <param name="param"></param>
        public static GetAuthorizerInfoResult GetAuthorizerInfo(WeChatParam param)
        {
            var token = GetComponentToken(new WeChatParam()
            {
                ComponentVerifyTicket = param.ComponentVerifyTicket
            });
            if (!token.IsSuccess)
            {
                return new GetAuthorizerInfoResult()
                {
                    IsSuccess = false,
                    ErrMsg = token.ErrMsg
                };
            }
            var str = HttpHelper.Post(new HttpParam()
            {
                Url = ApiList.ApiGetAuthorizerInfo,
                PostParam =
                new
                {
                    component_appid = WeChatConfig.GetOpenAppId(),
                    authorizer_appid = param.AuthorizerAppid
                },
                GetParam = new
                {
                    component_access_token = token.ComponentAccessToken
                }
            });
            var result = JSON.ToObject<GetAuthorizerInfoResult>(str);
            if (!result.IsSuccess)
            {
                LogHelper.Debug("GetAuthorizerInfo失败！" + result.ErrMsg, "微信_Fail_");
            }
            return result;
        }
    }
}
