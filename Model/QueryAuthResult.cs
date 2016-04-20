using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "authorization_info")]
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
        [JsonProperty(PropertyName = "authorizer_appid")]
        public string AuthorizerAppid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "authorizer_access_token")]
        public string AuthorizerAccessToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "authorizer_refresh_token")]
        public string AuthorizerRefreshToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "func_info")]
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
        [JsonProperty(PropertyName = "funcscope_category")]
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
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
