using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Dos.WeChat
{
    /// <summary>
    /// 获取授权方的公众号帐号基本信息。该API用于获取授权方的公众号基本信息，包括头像、昵称、帐号类型、认证类型、微信号、原始ID和二维码图片URL。
    /// </summary>
    public class GetAuthorizerInfoResult : WeChatResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "authorizer_info")]
        public AuthorizerInfo AuthorizerInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "authorization_info")]
        public AuthorizationInfo AuthorizationInfo { get; set; }
        
    }
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizerInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "nick_name")]
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "head_img")]
        public string HeadImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "service_type_info")]
        public ServiceTypeInfo ServiceTypeInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "verify_type_info")]
        public VerifyTypeInfo VerifyTypeInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "business_info")]
        public BusinessInfo BusinessInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "qrcode_url")]
        public string QrcodeUrl { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ServiceTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class VerifyTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BusinessInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "open_store")]
        public int OpenStore { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "open_scan")]
        public int OpenScan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "open_pay")]
        public int OpenPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "open_card")]
        public int OpenCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "open_shake")]
        public int OpenShake { get; set; }
    }
}
