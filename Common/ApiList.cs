using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dos.WeChat
{
    /// <summary>
    /// 微信接口列表。
    /// </summary>
    public static class ApiList
    {
        #region 公众号接口
        /// <summary>
        /// 发送客服消息
        /// </summary>
        public static string MessageCustomSendUrl = "https://api.weixin.qq.com/cgi-bin/message/custom/send";
        /// <summary>
        /// 发送模板消息
        /// </summary>
        public static string MessageTemplateSendUrl = "https://api.weixin.qq.com/cgi-bin/message/template/send";
        /// <summary>
        /// 获取access_token的接口地址
        /// </summary>
        public static string GetTokenUrl = "https://api.weixin.qq.com/cgi-bin/token";
        /// <summary>
        /// 获取jsapi_ticket的接口地址
        /// </summary>
        public static string GetticketUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
        /// <summary>
        /// 
        /// </summary>
        public static string MenuCreateUrl = "https://api.weixin.qq.com/cgi-bin/menu/create";
        /// <summary>
        /// 查询菜单接口地址
        /// </summary>
        public static string MenuGetUrl = "https://api.weixin.qq.com/cgi-bin/menu/get";
        /// <summary>
        /// 删除菜单接口地址
        /// </summary>
        public static string MenuDeleteUrl = "https://api.weixin.qq.com/cgi-bin/menu/delete";
        /// <summary>
        /// 
        /// </summary>
        public static string MediaUploadUrl = "http://file.api.weixin.qq.com/cgi-bin/media/upload";
        /// <summary>
        /// 
        /// </summary>
        public static string MediaGet = "http://file.api.weixin.qq.com/cgi-bin/media/get";
        /// <summary>
        /// 网页授权获取用户信息
        /// </summary>
        public static string SnsUserInfo = "https://api.weixin.qq.com/sns/userinfo";
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static string GetUserInfo = "https://api.weixin.qq.com/cgi-bin/user/info";
        /// <summary>
        /// 需要 access_token
        /// </summary>
        public static string QrcodeCreateUrl = "https://api.weixin.qq.com/cgi-bin/qrcode/create";
        /// <summary>
        /// 
        /// </summary>
        public static string ShowQrcodeUrl = "https://mp.weixin.qq.com/cgi-bin/showqrcode";
        /// <summary>
        /// 
        /// </summary>
        public static string DownloadBillUrl = "https://api.mch.weixin.qq.com/pay/downloadbill";
        /// <summary>
        /// 
        /// </summary>
        public static string UnifiedOrderUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        /// <summary>
        /// 
        /// </summary>
        public static string GetOauth2AccessTokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token";
        /// <summary>
        /// 获取永久素材的列表。地址栏需要access_token参数。
        /// </summary>
        public static string BatchgetMaterial = "https://api.weixin.qq.com/cgi-bin/material/batchget_material";
        #endregion

        #region 开放平台接口
        /// <summary>
        /// 该API用于获取第三方平台令牌（component_access_token）
        /// </summary>
        public static string ApiComponentToken = "https://api.weixin.qq.com/cgi-bin/component/api_component_token";
        /// <summary>
        /// 该API用于获取预授权码。预授权码用于公众号授权时的第三方平台方安全验证。地址栏需要component_access_token参数。
        /// </summary>
        public static string ApiCreatePreauthcode = "https://api.weixin.qq.com/cgi-bin/component/api_create_preauthcode";
        /// <summary>
        /// 使用授权码换取公众号的接口调用凭据和授权信息。地址栏需要component_access_token参数。
        /// </summary>
        public static string ApiQueryAuth = "https://api.weixin.qq.com/cgi-bin/component/api_query_auth";
        /// <summary>
        /// 获取（刷新）授权公众号的接口调用凭据（令牌）。地址栏需要component_access_token参数。
        /// </summary>
        public static string ApiAuthorizerToken = "https://api.weixin.qq.com/cgi-bin/component/api_authorizer_token";
        /// <summary>
        /// 获取授权方的公众号帐号基本信息。该API用于获取授权方的公众号基本信息，包括头像、昵称、帐号类型、认证类型、微信号、原始ID和二维码图片URL。地址栏需要component_access_token参数。
        /// </summary>
        public static string ApiGetAuthorizerInfo = "https://api.weixin.qq.com/cgi-bin/component/api_get_authorizer_info";
        #endregion
    }
}
