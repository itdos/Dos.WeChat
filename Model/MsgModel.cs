#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：RecTextMessage
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/10/25 11:21:51
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion

using System.Collections.Generic;
using System.Text;using Dos.Common;
using Dos.WeChat.Common;

namespace Dos.WeChat
{
    /// <summary>
    /// 接收的文本消息
    /// </summary>
    public class RecTextMsg : ReceiveMsg
    {
        public RecTextMsg()
        {
            MsgType = EnumHelper.MsgType.Text;
        }

        [Output]
        public string Content { get; set; }
    }

    /// <summary>
    /// 图片消息
    /// </summary>
    public class RecImgMsg : ReceiveMsg
    {
        public RecImgMsg()
        {
            MsgType = EnumHelper.MsgType.Image;
        }

        [Output]
        public string PicUrl { get; set; }
    }

    /// <summary>
    /// 地理位置消息
    /// </summary>
    public class RecLocationMsg : ReceiveMsg
    {
        public RecLocationMsg()
        {
            MsgType = EnumHelper.MsgType.Location;
        }

        /// <summary>
        /// X 坐标
        /// </summary>
        [Output]
        public double LocationX { get; set; }

        /// <summary>
        /// Y 坐标
        /// </summary>
        [Output]
        public double LocationY { get; set; }

        /// <summary>
        /// 缩放级别
        /// </summary>
        [Output]
        public int Scale { get; set; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        [Output]
        public string Label { get; set; }
    }

    /// <summary>
    /// 链接消息
    /// </summary>
    public class RecLinkMsg : ReceiveMsg
    {
        public RecLinkMsg()
        {
            MsgType = EnumHelper.MsgType.Link;
        }

        /// <summary>
        /// 消息标题
        /// </summary>
        [Output]
        public string Title { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        [Output]
        public string Description { get; set; }

        /// <summary>
        /// 消息链接
        /// </summary>
        [Output]
        public string Url { get; set; }
    }

    /// <summary>
    /// 事件推送消息
    /// </summary>
    public class RecEventMsg : ReceiveMsg
    {
        /// <summary>
        /// 订阅事件
        /// </summary>
        public const string Subscribe = "subscribe";

        /// <summary>
        /// 退订事件
        /// </summary>
        public const string UnSubscribe = "unsubscribe";

        /// <summary>
        /// 菜单点击事件
        /// </summary>
        public const string Click = "click";

        /// <summary>
        /// 扫描二维码事件
        /// </summary>
        public const string Scan = "scan";

        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        public const string Location = "location";
        /// <summary>
        /// 
        /// </summary>
        public RecEventMsg()
        {
            MsgType = EnumHelper.MsgType.Event;
        }

        /// <summary>
        /// 事件类型。从常量中获取
        /// </summary>
        [Output]
        public string Event { get; set; }

        /// <summary>
        /// 事件Key。用户通过扫描带参二维码订阅时：qrscene_为前缀，后面为二维码的参数值。扫描带参二维码事件：一个32位无符号整数
        /// </summary>
        [Output]
        public string EventKey { get; set; }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片。仅在扫描带参二维码时有值。
        /// </summary>
        [Output]
        public string Ticket { get; set; }

        /// <summary>
        /// 地理位置纬度
        /// </summary>
        [Output]
        public double Latitude { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        [Output]
        public double Longitude { get; set; }

        /// <summary>
        /// 地理位置精度
        /// </summary>
        [Output]
        public double Precision { get; set; }
    }

    /// <summary>
    /// 语音消息
    /// </summary>
    public class RecVoiceMsg : ReceiveMsg
    {
        public RecVoiceMsg()
        {
            MsgType = EnumHelper.MsgType.Voice;
        }

        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取该媒体
        /// </summary>
        [Output]
        public string MediaID { get; set; }

        /// <summary>
        /// 语音格式：amr
        /// </summary>
        [Output]
        public string Format { get; set; }

        /// <summary>
        /// 语音识别结果，UTF8编码
        /// </summary>
        [Output]
        public string Recognition { get; set; }
    }

    /// <summary>
    /// 视频消息
    /// </summary>
    public class RecVideoMsg : ReceiveMsg
    {
        public RecVideoMsg()
        {
            MsgType = EnumHelper.MsgType.Video;
        }

        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        [Output]
        public string MediaId { get; set; }

        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        [Output]
        public string ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 响应文本消息
    /// </summary>
    public class TextMsgData : RepMsgData
    {
        [Output]
        public string Content { get; set; }

        public override string ToXml()
        {
            return MsgHelper.ToXml(this);
        }

        public static implicit operator TextMsgData(string s)
        {
            var result = new TextMsgData
            {
                Content = s
            };
            return result;
        }
    }

    /// <summary>
    /// 响应音乐消息
    /// </summary>
    public class MusicMsgData : RepMsgData
    {
        public const string NodeName = "Music";

        [Output]
        public string Title { get; set; }

        [Output]
        public string Description { get; set; }

        [Output]
        public string MusicUrl { get; set; }

        [Output]
        public string HQMusicUrl { get; set; }

        public override string ToXml()
        {
            var temp = MsgHelper.ToXml(this);
            return string.Format("<{0}>\n{1}\n</{0}>", NodeName, temp);
        }
    }

    /// <summary>
    /// 响应图文消息
    /// </summary>
    public class NewsMsgData : RepMsgData
    {
        public const string NodeName = "Articles";

        public NewsMsgData()
        {
            Items = new List<NewsItem>();
        }

        /// <summary>
        /// 新闻条目列表
        /// </summary>
        public List<NewsItem> Items { get; set; }

        public int ArticleCount
        {
            get { return Items.Count; }
        }

        public override string ToXml()
        {
            var temp = new StringBuilder();
            foreach (var item in Items)
            {
                temp.AppendLine(item.ToXml());
            }
            var result = string.Format("<{0}>\n{1}</{0}>", NodeName, temp);
            result = string.Format("<ArticleCount>{0}</ArticleCount>\n{1}", ArticleCount, result);
            return result;
        }
    }

    public class NewsItem
    {
        public const string NodeName = "item";

        [Output]
        public string Title { get; set; }

        [Output]
        public string Description { get; set; }

        [Output]
        public string PicUrl { get; set; }

        [Output]
        public string Url { get; set; }

        public string ToXml()
        {
            var temp = MsgHelper.ToXml(this);
            return string.Format("<{0}>\n{1}\n</{0}>", NodeName, temp);
        }

        public override string ToString()
        {
            return ToXml();
        }
    }
    /// <summary>
    /// 响应文件消息
    /// </summary>
    public class RepTextMessage : ResponseMsg
    {
        public RepTextMessage()
        {
            MsgType = EnumHelper.MsgType.Text;
        }
    }
    public class RepTransferMessage : ResponseMsg
    {
        public RepTransferMessage()
        {
            MsgType = EnumHelper.MsgType.Transfer;
        }
    }
    /// <summary>
    /// 响应音乐消息
    /// </summary>
    public class RepMusicMessage : ResponseMsg
    {
        public RepMusicMessage()
        {
            MsgType = EnumHelper.MsgType.Music;
        }
    }

    /// <summary>
    /// 响应图文消息
    /// </summary>
    public class RepNewsMessage : ResponseMsg
    {
        public RepNewsMessage()
        {
            MsgType = EnumHelper.MsgType.News;
        }
    }
}