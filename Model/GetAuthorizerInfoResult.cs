using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;using Dos.Common;
using Dos.Common;


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
        [JsonProp(PropertyName = "authorizer_info")]
        public AuthorizerInfo AuthorizerInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "authorization_info")]
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
        [JsonProp(PropertyName = "nick_name")]
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "head_img")]
        public string HeadImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "service_type_info")]
        public ServiceTypeInfo ServiceTypeInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "verify_type_info")]
        public VerifyTypeInfo VerifyTypeInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "business_info")]
        public BusinessInfo BusinessInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "alias")]
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "qrcode_url")]
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
        [JsonProp(PropertyName = "id")]
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
        [JsonProp(PropertyName = "id")]
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
        [JsonProp(PropertyName = "open_store")]
        public int OpenStore { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "open_scan")]
        public int OpenScan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "open_pay")]
        public int OpenPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "open_card")]
        public int OpenCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProp(PropertyName = "open_shake")]
        public int OpenShake { get; set; }
    }
}
