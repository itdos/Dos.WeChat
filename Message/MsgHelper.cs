#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MessageHelper
* Copyright(c) 青之软件
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Dos.WeChat.Common;

namespace Dos.WeChat
{
    public class MsgHelper
    {
        /// <summary>
        /// 开发者微信公众号
        /// </summary>
        [Output]
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方OpenID
        /// </summary>
        [Output]
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        [Output]
        public int CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [Output]
        public EnumHelper.MsgType MsgType { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
        private string _rootName = "xml";
        /// <summary>
        /// 
        /// </summary>
        public string RootName
        {
            get { return _rootName; }
            set { _rootName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual IEnumerable<PropertyInfo> OutProperties
        {
            get { return MsgHelper.GetOutputPropertys(this); }
        }
        public override string ToString()
        {
            return ToXml();
        }
        /// <summary>
        /// 转换为xml
        /// </summary>
        public virtual string ToXml()
        {
            return string.Format("<{0}>\n{1}\n</{0}>", RootName, InnerToXml());
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual string InnerToXml()
        {
            return MsgHelper.ToXml(this, OutProperties);
        }

        /// <summary>
        /// 从xml文本中获取值
        /// </summary>
        public virtual void ParseFrom(string text)
        {
            var root = XElement.Parse(text);
            foreach (var p in OutProperties)
            {
                var e = root.Element(XName.Get(p.Name));
                if (e == null)
                    continue;
                object value = e.Value;
                if (p.PropertyType == typeof(EnumHelper.MsgType))
                {
                    value = Enum.Parse(typeof(EnumHelper.MsgType), value.ToString(), true);
                }
                var tValue = Convert.ChangeType(value, p.PropertyType);
                p.SetValue(this, tValue, null);
            }
        }
        /// <summary>
        /// 将指定对象的带[Output]标识的属性序列化为xml文本
        /// </summary>
        public static string ToXml(object obj)
        {
            return ToXml(obj, GetOutputPropertys(obj));
        }

        /// <summary>
        /// 将指定对象的指定属性列表序列化为xml文本。
        /// </summary>
        public static string ToXml(object obj, IEnumerable<PropertyInfo> ps)
        {
            var sb = new StringBuilder();
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                ConformanceLevel = ConformanceLevel.Fragment,
                Indent = true,
                CloseOutput = false
            };
            var writer = XmlWriter.Create(sb, settings);
            foreach (var p in ps)
            {
                writer.WriteStartElement(p.Name);
                //字符串返回CDATA节点
                if (p.PropertyType == typeof(string))
                {
                    writer.WriteCData(Convert.ToString(p.GetValue(obj, null)));
                }
                else if (p.PropertyType == typeof(EnumHelper.MsgType))
                {
                    writer.WriteCData(MsgTypeAttribute.ObtainMessageType((EnumHelper.MsgType)p.GetValue(obj, null)));
                }
                else
                {
                    writer.WriteValue(p.GetValue(obj, null));
                }
                writer.WriteEndElement();
            }
            writer.Flush();
            writer.Close();
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<PropertyInfo> GetOutputPropertys(object obj)
        {
            var ps =
                obj.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(OutputAttribute), true).Any());
            return ps;
        }
    }
    /// <summary>
    /// 接收的消息
    /// </summary>
    public class ReceiveMsg : MsgHelper
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [Output]
        public long MsgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static IMsgCall _IMsgCall;
        /// <summary>
        /// 
        /// </summary>
        public static void Reg(IMsgCall call)
        {
            if (_IMsgCall == null)
            {
                RegIMsgCall(call);
            }
            ParseReceiveMsg().RegMsgCall().Response(true);
        }
        /// <summary>
        /// 从xml文件解析消息。
        /// </summary>
        public static ReceiveMsg Parse(string text)
        {
            var result = ObtainByType(text);
            result.ParseFrom(text);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ReceiveMsg ParseReceiveMsg()
        {
            var request = HttpContext.Current.Request;
            var sr = new StreamReader(request.InputStream);
            var msg = Parse(sr.ReadToEnd());
            return msg;
        }

        /// <summary>
        /// 
        /// </summary>
        private static ReceiveMsg ObtainByType(string text)
        {
            var e = XElement.Parse(text);
            var t = e.Element("MsgType").Value;
            switch (t)
            {
                case "text":
                    return new RecTextMsg();
                case "image":
                    return new RecImgMsg();
                case "location":
                    return new RecLocationMsg();
                case "link":
                    return new RecLinkMsg();
                case "event":
                    return new RecEventMsg();
                case "voice":
                    return new RecVoiceMsg();
            }
            return null;
        }


        /// <summary>
        /// 注册消息处理接口
        /// </summary>
        public static void RegIMsgCall(IMsgCall call)
        {
            _IMsgCall = call;
        }
        /// <summary>
        /// 从接收到的消息中获取信息以填充到响应消息中。
        /// </summary>
        /// <param name="msg"></param>
        private void FillRepMsg(ResponseMsg msg)
        {
            msg.FromUserName = ToUserName;
            msg.ToUserName = FromUserName;
        }

        /// <summary>
        /// 获取文本响应消息
        /// </summary>
        /// <returns></returns>
        public RepTextMessage GetTextResponse(string text = null)
        {
            var result = new RepTextMessage();
            FillRepMsg(result);
            result.Data = (TextMsgData)text;
            return result;
        }
        public RepTransferMessage GetTransferResponse(string text = null)
        {
            var result = new RepTransferMessage();
            FillRepMsg(result);
            result.Data = (TextMsgData)text;
            return result;
        }
        /// <summary>
        /// 获取音乐响应消息
        /// </summary>
        public RepMusicMessage GetMusicResponse()
        {
            var result = new RepMusicMessage();
            FillRepMsg(result);
            return result;
        }

        /// <summary>
        /// 获取图文响应消息
        /// </summary>
        /// <returns></returns>
        public RepNewsMessage GetNewsResponse(IEnumerable<NewsItem> data = null)
        {
            var result = new RepNewsMessage();
            FillRepMsg(result);
            if (data != null)
            {
                var msgData = new NewsMsgData();
                msgData.Items.AddRange(data);
                result.Data = msgData;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public ResponseMsg RegMsgCall()
        {
            if (_IMsgCall == null)
            {
                throw new Exception("未注册事件回调函数！");
            }
            var dic = new Dictionary<EnumHelper.MsgType, Func<ReceiveMsg, ResponseMsg>>
            {
                {
                    EnumHelper.MsgType.Text, msg => _IMsgCall.TextMsgCall(msg as RecTextMsg)
                },
                {
                    EnumHelper.MsgType.Image, msg => _IMsgCall.ImageMsgCall(msg as RecImgMsg)
                },
                {
                    EnumHelper.MsgType.Link, msg => _IMsgCall.LinkMsgCall((RecLinkMsg) msg)
                },
                {
                    EnumHelper.MsgType.Location, msg => _IMsgCall.LocationMsgCall((RecLocationMsg) msg)
                },
                {
                    EnumHelper.MsgType.Event, msg => _IMsgCall.EventMsgCall((RecEventMsg) msg)
                },
                {
                    EnumHelper.MsgType.Voice, msg => _IMsgCall.VoiceMsgCall(msg as RecVoiceMsg)
                },
            };
            var result = dic[MsgType](this);
            _IMsgCall.AfterMsgCall(this, result);
            return result;
        }
    }

    /// <summary>
    /// 响应消息
    /// </summary>
    public class ResponseMsg : MsgHelper
    {
        public ResponseMsg()
        {
            CreateTime = (int)(DateTime.Now - DateTime.Parse("1970-1-1")).TotalSeconds;
        }

        public RepMsgData Data { get; set; }

        public override string InnerToXml()
        {
            var result = base.InnerToXml();
            if (Data != null)
            {
                result += "\n" + Data.ToXml();
            }
            return result;
        }

        /// <summary>
        /// 将响应写入响应流。
        /// </summary>
        public void Response(bool end = true)
        {
            var response = HttpContext.Current.Response;
            if (response.IsClientConnected)
            {
                response.Write(ToXml());
                if (end)
                {
                    response.Flush();
                    response.Close();
                }
            }
        }
    }

    /// <summary>
    /// 响应消息数据
    /// </summary>
    public abstract class RepMsgData
    {
        public abstract string ToXml();

        public override string ToString()
        {
            return ToXml();
        }
    }
}