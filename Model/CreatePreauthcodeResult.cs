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
    public class CreatePreauthcodeResult : WeChatResult
    {
        /// <summary>
        /// 有效期。单位：秒
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 预授权码
        /// </summary>
        [JsonProperty(PropertyName = "pre_auth_code")]
        public string PreAuthCode { get; set; }
    }
}
