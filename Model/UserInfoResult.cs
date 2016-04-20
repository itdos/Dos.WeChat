#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：UserInfoModel
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/11 15:35:47
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
    /// <summary>
    /// 
    /// </summary>
    public class UserInfoResult
    {
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        [JsonProperty(PropertyName = "subscribe")]
        public string Subscribe { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        [JsonProperty(PropertyName = "openid")]
        public string OpenId { get; set; }
        /// <summary>
        /// 用户的昵称
        /// </summary>
        [JsonProperty(PropertyName = "nickname")]
        public string NickName { get; set; }
        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        [JsonProperty(PropertyName = "sex")]
        public string Sex { get; set; }
        /// <summary>
        /// 用户所在城市
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        /// <summary>
        /// 用户所在国家
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        /// <summary>
        /// 用户所在省份
        /// </summary>
        [JsonProperty(PropertyName = "province")]
        public string Province { get; set; }
        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        [JsonProperty(PropertyName = "headimgurl")]
        public string HeadImgUrl { get; set; }
        /// <summary>
        ///用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        [JsonProperty(PropertyName = "subscribe_time")]
        public string SubscribeTime { get; set; }
        /// <summary>
        ///只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        [JsonProperty(PropertyName = "unionid")]
        public string UnionId { get; set; }
        /// <summary>
        ///错误时微信会返回错误码等信息
        /// </summary>
        [JsonProperty(PropertyName = "errcode")]
        public string Errcode { get; set; }
        /// <summary>
        ///错误时微信会返回错误码等信息
        /// </summary>
        [JsonProperty(PropertyName = "errmsg")]
        public string ErrMsg { get; set; }
    }
}
