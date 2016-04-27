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
    public class QueryAuthResult : WeChatResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "authorization_info")]
        public AuthorizationInfo AuthorizationInfo { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "authorizer_appid")]
        public string AuthorizerAppid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "authorizer_access_token")]
        public string AuthorizerAccessToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "authorizer_refresh_token")]
        public string AuthorizerRefreshToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "func_info")]
        public List<FuncInfo> FuncInfo { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FuncInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "funcscope_category")]
        public FuncscopeCategory FuncscopeCategory { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FuncscopeCategory
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "id")]
        public int Id { get; set; }
    }
}
