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
    public class ComponentTokenResult :WeChatResult
    {
        /// <summary>
        /// 有效期
        /// </summary>
        [JsonProp(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 第三方平台access_token
        /// </summary>
        [JsonProp(PropertyName = "component_access_token")]
        public string ComponentAccessToken { get; set; }
    }
}
