#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MessagePusher
* Copyright(c) 青之软件
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
using System.Text;
using Dos.Common;
using Dos.WeChat;
using Dos.WeChat.Common;
using Dos.WeChat.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dos.WeChat
{
    /// <summary>
    /// 微信消息
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 
        /// </summary>
        public static WeChatResult Send(MsgParam msg)
        {
            var result = HttpHelper.Post<WeChatResult>(ApiList.MessageCustomSendUrl, msg.ToString(),
                "access_token=" + Token.GetAccessToken(msg));
            return result;
        }
        /// <summary>
        /// 传入：ToUser，TemplateId，Url，Data（Dictionary&lt;string,string>）。可传：WeChatPublic
        /// </summary>
        public static WeChatResult SendTemplate(MsgParam msg)
        {
            var sss = new Dictionary<string,object>();
            foreach (var dic in msg.Data)
            {
                sss.Add(dic.Key,new
                {
                    value = dic.Value,
                    color= "#173177"
                });
            }
            var param = JsonConvert.SerializeObject(new
            {
                touser = msg.ToUser,
                template_id = msg.TemplateId,
                url = msg.Url,
                topcolor = "#FF0000",
                data = sss
            });
            var result = HttpHelper.Post<WeChatResult>(ApiList.MessageTemplateSendUrl, param, "access_token=" + Token.GetAccessToken(msg));
            return result;
        }
    }
}
