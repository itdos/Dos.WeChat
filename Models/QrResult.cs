#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：QrResult
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/1/7 9:21:19
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
    public class QrResult
    {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        [JsonProperty(PropertyName = "ticket")]
        public string Ticket { get; set; }

        /// <summary>
        /// 二维码的有效时间，以秒为单位。最大不超过1800。
        /// </summary>
        [JsonProperty(PropertyName = "expire_seconds")]
        public string ExpireSeconds { get; set; }

        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "errcode")]
        public string Errcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "errmsg")]
        public string Errmsg { get; set; }
    }
}
