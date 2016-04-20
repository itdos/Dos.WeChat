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
    public class JsapiTicketResult : WeChatResult
    {
        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "ticket")]
        public string Ticket { get; set; }
    }
}
