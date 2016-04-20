#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：WeChatParam
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/11 15:43:22
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Dos.WeChat
{
    public class WeChatParam
    {
        /// <summary>
        /// 微信接入方式
        /// </summary>
        public EnumHelper.WeChatType WeChatType { get; set; }
        #region 常用
        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeChatPublic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Debug { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        public string Code { get; set; }
        #endregion

        #region 开放平台
        /// <summary>
        /// 微信后台推送的ticket，此ticket会定时推送
        /// </summary>
        public string ComponentVerifyTicket { get; set; }
        /// <summary>
        /// 授权方的刷新令牌
        /// </summary>
        public string AuthorizerRefreshToken { get; set; }
        /// <summary>
        /// 授权方appid
        /// </summary>
        public string AuthorizerAppid { get; set; }
        /// <summary>
        /// 第三方平台appid
        /// </summary>
        public string ComponentAppid { get; set; }
        /// <summary>
        /// 第三方平台appsecret
        /// </summary>
        public string ComponentAppsecret { get; set; }
        /// <summary>
        /// 授权code,会在授权成功时返回给第三方平台
        /// </summary>
        public string AuthorizationCode { get; set; }
        /// <summary>
        /// 第三方平台access_token。
        /// </summary>
        public string ComponentAccessToken { get; set; }
        #endregion

        #region 消息
        /// <summary>
        /// 
        /// </summary>
        public Guid? MsgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SendCount { get; set; }
        /// <summary>
        /// 文本消息
        /// </summary>
        public const string TextMsg = "text";
        /// <summary>
        /// 图片消息
        /// </summary>
        public const string ImageMsg = "image";
        /// <summary>
        /// 语音消息
        /// </summary>
        public const string VoiceMsg = "voice";
        /// <summary>
        /// 视频消息
        /// </summary>
        public const string VideoMsg = "video";
        /// <summary>
        /// 音乐消息
        /// </summary>
        public const string MusicMsg = "music";
        /// <summary>
        /// 图文消息
        /// </summary>
        public const string NewsMsg = "news";
        /// <summary>
        /// 接收消息的用户的openid
        /// </summary>
        [JsonProperty(PropertyName = "touser")]
        public string ToUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "template_id")]
        public string TemplateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public Dictionary<string, string> Data { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty(PropertyName = "msgtype")]
        public string MsgType { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public object Text { get; set; }
        #endregion

        #region 自定义菜单
        /// <summary>
        /// 菜单json数据
        /// </summary>
        public MenuResult Menu { get; set; }
        #endregion

        #region MediaParam
        /// <summary>
        ///     媒体文件上传后，获取时的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "media_id")]
        public string MediaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }
        #endregion
    }
}
