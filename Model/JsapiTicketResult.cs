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
    public class JsapiTicketResult : WeChatResult
    {
        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        [JsonProp(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "ticket")]
        public string Ticket { get; set; }
    }
}
