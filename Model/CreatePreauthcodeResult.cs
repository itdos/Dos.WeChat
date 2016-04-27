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
    public class CreatePreauthcodeResult : WeChatResult
    {
        /// <summary>
        /// 有效期。单位：秒
        /// </summary>
        [JsonProp(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 预授权码
        /// </summary>
        [JsonProp(PropertyName = "pre_auth_code")]
        public string PreAuthCode { get; set; }
    }
}
