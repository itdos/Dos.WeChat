#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MessageForPush
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/11/11 17:24:12
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

namespace Dos.WeChat.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class MsgParam : WeChatParam
    {
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            if (this.MsgType == "news")
            {
                var a =
                new
                {
                    touser = this.ToUser,
                    msgtype = this.MsgType,
                    news = new { articles = this.Text }
                };
                var result = JsonConvert.SerializeObject(a, settings);
                return result;
            }
            else
            {
                var a =
                    new
                    {
                        text = new { content = this.Text },
                        msgtype = this.MsgType,
                        touser = this.ToUser
                    };
                var result = JsonConvert.SerializeObject(a, settings);
                return result;
            }
        }
    }
}
