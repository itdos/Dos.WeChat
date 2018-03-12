#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MessagePusher
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/11/11 17:22:56
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
using System.Text;using Dos.Common;
using Dos.Common;
using Dos.WeChat;
using Dos.WeChat.Common;
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    /// <summary>
    /// 微信消息
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 发送客服消息。必传：ToUser、MsgType、Content。WeChatType。
        /// </summary>
        public static WeChatResult Send(WeChatParam param)
        {
            var aToken = "";
            if (!string.IsNullOrWhiteSpace(param.AccessToken))
            {
                aToken = param.AccessToken;
            }
            else
            {
                if (param.WeChatType == EnumHelper.WeChatType.Open)
                {
                    var bs = TokenHelper.GetAuthorizerAccessToken(param);
                    if (!bs.IsSuccess)
                    {
                        return bs;
                    }
                    aToken = bs.AuthorizerAccessToken;
                }
                else
                {
                    var bs = TokenHelper.GetAccessToken();
                    if (!bs.IsSuccess)
                    {
                        return bs;
                    }
                    aToken = bs.AccessToken;
                }
            }
            var result = HttpHelper.Post<WeChatResult>(new HttpParam()
            {
                Url = ApiList.MessageCustomSendUrl,
                PostParam =
                new
                {
                    touser = param.ToUser,
                    msgtype = param.MsgType,
                    text = new
                    {
                        content = param.Content
                    }
                },
                GetParam =
                    new
                    {
                        access_token = aToken
                    }
            });
            return result;
        }

        private string GetMsgData(WeChatParam msg)
        {
            //var settings = new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //};
            if (msg.MsgType == "news")
            {
                var a =
                new
                {
                    touser = msg.ToUser,
                    msgtype = msg.MsgType,
                    news = new { articles = msg.Text }
                };
                var result = JSON.ToJSON(a);//, settings
                return result;
            }
            else
            {
                var a =
                    new
                    {
                        text = new { content = msg.Text },
                        msgtype = msg.MsgType,
                        touser = msg.ToUser
                    };
                var result = JSON.ToJSON(a);//, settings
                return result;
            }
        }

        /// <summary>
        /// 传入：ToUser，TemplateId，Url，Data（Dictionary&lt;string,string>）
        /// </summary>
        public static WeChatResult SendTemplate(WeChatParam msg)
        {
            var sss = new Dictionary<string, object>();
            foreach (var dic in msg.Data)
            {
                sss.Add(dic.Key, new
                {
                    value = dic.Value,
                    color = "#173177"
                });
            }
            var param = JSON.ToJSON(new
            {
                touser = msg.ToUser,
                template_id = msg.TemplateId,
                url = msg.Url,
                topcolor = "#FF0000",
                data = sss
            });
            var result = HttpHelper.Post<WeChatResult>(new HttpParam()
            {
                Url = ApiList.MessageTemplateSendUrl,
                PostParam =
                param,
                GetParam = "access_token=" + TokenHelper.GetAccessToken().AccessToken
            });
            return result;
        }
    }
}
