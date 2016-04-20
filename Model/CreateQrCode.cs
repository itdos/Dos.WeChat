#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：CreateQrCode
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/1/4 10:55:09
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
    public class CreateQrCode : WeChatParam
    {
        /// <summary>
        /// 该二维码有效时间，以秒为单位。 最大不超过1800。
        /// </summary>
        [JsonProperty(PropertyName = "expire_seconds")]
        public string ExpireSeconds { get; set; }

        /// <summary>
        /// 二维码类型，QR_SCENE为临时,QR_LIMIT_SCENE为永久
        /// </summary>
        [JsonProperty(PropertyName = "action_name")]
        public string ActionName { get; set; }

        /// <summary>
        /// 二维码详细信息
        /// </summary>
        [JsonProperty(PropertyName = "action_info")]
        public object ActionInfo { get; set; }

        ///// <summary>
        ///// 场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000）
        ///// </summary>
        //[JsonProperty(PropertyName = "scene_id")]
        //public string SceneId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ToJsonString()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
