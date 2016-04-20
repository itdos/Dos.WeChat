#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：UserHelper
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/11 15:27:42
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System.Collections.Generic;
using Dos.Common;

namespace Dos.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class UserHelper
    {

        /// <summary>
        /// 传入OpenId，AccessToken
        /// </summary>
        public static UserInfoResult GetSnsUserInfo(WeChatParam param)
        {
            var result = HttpHelper.Get<UserInfoResult>(ApiList.SnsUserInfo, new
            {
                access_token = param.AccessToken,
                openid = param.OpenId,
                lang = "zh_CN"
            });
            return result;
        }
        /// <summary>
        /// 传入OpenId，AccessToken
        /// </summary>
        public static UserInfoResult GetUserInfo(WeChatParam param)
        {
            var result = HttpHelper.Get<UserInfoResult>(ApiList.GetUserInfo, new
            {
                access_token = TokenHelper.GetAccessToken(),
                openid = param.OpenId,
                lang = "zh_CN"
            });
            return result;
        }
        /// <summary>
        /// 传入Code
        /// </summary>
        public static Dictionary<string, string> GetOauth2AccessToken(WeChatParam param)
        {
            var param2 = new
            {
                appid = WeChatConfig.GetAppId(),
                secret = WeChatConfig.GetSecret(),
                code = param.Code,
                grant_type = "authorization_code"
            };
            var dic = HttpHelper.Get<Dictionary<string, string>>(ApiList.GetOauth2AccessTokenUrl, param2);
            return dic;
        }
    }
}
