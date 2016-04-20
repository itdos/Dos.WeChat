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
    public class ComponentTokenResult :WeChatResult
    {
        /// <summary>
        /// 有效期
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 第三方平台access_token
        /// </summary>
        [JsonProperty(PropertyName = "component_access_token")]
        public string ComponentAccessToken { get; set; }
    }
}
