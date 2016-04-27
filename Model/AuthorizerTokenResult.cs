using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using Dos.Common;
using Dos.Common;


namespace Dos.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizerTokenResult : WeChatResult
    {
        /// <summary>
        /// 有效期。单位：秒
        /// </summary>
        [JsonProp(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 授权方令牌
        /// </summary>
        [JsonProp(PropertyName = "authorizer_access_token")]
        public string AuthorizerAccessToken { get; set; }
        /// <summary>
        /// 刷新令牌
        /// </summary>
        [JsonProp(PropertyName = "authorizer_refresh_token")]
        public string AuthorizerRefreshToken { get; set; }

    }
}
