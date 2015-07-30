using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dos.WeChat.Common
{
    /// <summary>
    /// 微信接口列表
    /// </summary>
    public static class ApiList
    {
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
    }
}
