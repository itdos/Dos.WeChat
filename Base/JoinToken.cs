#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：EntrySign
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
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    /// <summary>
    /// 接入验证
    /// </summary>
    public class JoinToken
    {
        /// <summary>
        /// 
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nonce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string echostr { get; set; }
        private static void ParseProperties(JoinToken es, HttpContextBase hcb = null)
        {
            if (es == null)
                return;

            var ps = es.GetType().GetProperties();
            foreach (var p in ps)
            {
                if (hcb == null)
                {
                    var context = HttpContext.Current;
                    if (context == null)
                        return;
                    p.SetValue(es, context.Request[p.Name], null);
                }
                else
                {
                    p.SetValue(es, hcb.Request[p.Name], null);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsGetRequest()
        {
            return HttpContext.Current.Request.HttpMethod == "GET";
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsSignatureRequest()
        {
            return string.IsNullOrEmpty(HttpContext.Current.Request["signature"]);
        }
        /// <summary>
        /// 
        /// </summary>
        public static JoinToken ParseJoinToken()
        {
            var result = new JoinToken();
            ParseProperties(result);
            return result;
        }
        /// <summary>
        /// 接入微信
        /// </summary>
        /// <returns></returns>
        public static bool Join(IMsgCall call, WeChatParam param = null)
        {
            var sign = ParseJoinToken();
            if (sign.Check(param))
            {
                if (JoinToken.IsGetRequest())
                    sign.Response();
                else
                    ReceiveMsg.Reg(call);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        public bool Check(WeChatParam param = null)
        {
            var token = GetConfig.GetToken(param);
            var vs = new[] { timestamp, nonce, token }.OrderBy(s => s);
            var str = string.Join("", vs);
            var copu = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");
            if (copu == null)
            {
                return false;
            }
            return copu.Equals(signature, StringComparison.CurrentCultureIgnoreCase);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Response()
        {
            var response = HttpContext.Current.Response;
            response.Write(echostr ?? "echostr is null");
            response.Flush();
            response.Close();
        }
    }
}