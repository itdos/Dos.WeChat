#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：EnumService
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/1/4 10:57:30
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
using  Dos.WeChat.Common;
namespace Dos.WeChat
{
    public class EnumHelper
    {
        /// <summary>
        /// 接收或响应的消息类型
        /// </summary>
        public enum MsgType
        {
            /// <summary>
            /// 文本消息
            /// </summary>
            [MsgType(TypeName = "text")]
            Text,
            /// <summary>
            /// 图片消息
            /// </summary>
            [MsgType(TypeName = "image")]
            Image,
            /// <summary>
            /// 地理位置消息
            /// </summary>
            [MsgType(TypeName = "location")]
            Location,
            /// <summary>
            /// 链接消息
            /// </summary>
            [MsgType(TypeName = "link")]
            Link,
            /// <summary>
            /// 事件推送消息
            /// </summary>
            [MsgType(TypeName = "event")]
            Event,
            /// <summary>
            /// 音乐消息（用于响应）
            /// </summary>
            [MsgType(TypeName = "music")]
            Music,
            /// <summary>
            /// 图文消息
            /// </summary>
            [MsgType(TypeName = "news")]
            News,
            /// <summary>
            /// 语音消息（用户的语音，可以使用TTS引擎分析成文本）
            /// </summary>
            [MsgType(TypeName = "voice")]
            Voice,
            /// <summary>
            /// 视频消息
            /// </summary>
            [MsgType(TypeName = "video")]
            Video,
            /// <summary>
            /// 多客服消息
            /// </summary>
            [MsgType(TypeName = "transfer_customer_service")]
            Transfer
        }
        public enum WeChatPublic
        {
            
            /// <summary>
            /// 驯车族微信公众号
            /// </summary>
            Xcz,
            /// <summary>
            /// 驯车族教练微信公众号
            /// </summary>
            XczJl
        }

        /// <summary>
        /// 支付方式
        /// </summary>
        public enum TradeType
        {
            /// <summary>
            /// 
            /// </summary>
            JSAPI,
            /// <summary>
            /// 
            /// </summary>
            NATIVE,
            /// <summary>
            /// 
            /// </summary>
            APP
        }

        /// <summary>
        /// 二维码类型
        /// </summary>
        public enum QrCodeType
        {
            /// <summary>
            /// 临时二维码
            /// </summary>
            QR_SCENE,
            /// <summary>
            /// 永久二维码
            /// </summary>
            QR_LIMIT_SCENE,
            /// <summary>
            /// 永久二维码
            /// </summary>
            QR_LIMIT_STR_SCENE
        }
        /// <summary>
        /// trade_state交易状态
        /// </summary>
        public enum TradeState
        {
            /// <summary>
            /// 支付成功
            /// </summary>
            SUCCESS,
            /// <summary>
            /// 转入退款
            /// </summary>
            REFUND,
            /// <summary>
            /// 未支付
            /// </summary>
            NOTPAY,
            /// <summary>
            /// 已关闭
            /// </summary>
            CLOSED,
            /// <summary>
            /// 已撤销
            /// </summary>
            REVOKED,
            /// <summary>
            /// 用户支付中
            /// </summary>
            USERPAYING,
            /// <summary>
            /// 支付失败(其他原因，如银行返回失败)
            /// </summary>
            PAYERROR
        }
    }
}
