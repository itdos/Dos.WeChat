#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：EntrySign
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
using System;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using Dos.Common;
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
        private static void ParseProperties(JoinToken es)
        {
            if (es == null)
                return;
            var ps = es.GetType().GetProperties();
            foreach (var p in ps)
            {
                var context = HttpContext.Current;
                if (context == null)
                    return;
                p.SetValue(es, context.Request[p.Name], null);
                LogHelper.Debug("ParseProperties）" + p.Name +"：" + context.Request[p.Name], "微信CallBack_");
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
        public static bool Join(IMsgCall call)
        {
            var sign = ParseJoinToken();
            if (sign.Check())
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
        /// 验证签名。默认公众号不需要参数。传入authorizer_appid(授权方appid)、authorizer_refresh_token(授权方的刷新令牌)则验证该公众号(用于微信开放平台)、component_verify_ticket(微信后台推送的ticket，此ticket会定时推送)
        /// </summary>
        public bool Check(WeChatParam param = null)
        {
            string token;
            if (param != null && !string.IsNullOrWhiteSpace(param.AuthorizerAppid))
            {
                if (string.IsNullOrWhiteSpace(param.AuthorizerRefreshToken))
                {
                    LogHelper.Debug("参数错误！authorizer_refresh_token必传！", "微信CallBack_");
                    return false;
                }
                var bs = TokenHelper.GetAuthorizerAccessToken(new WeChatParam()
                {
                    AuthorizerAppid = param.AuthorizerAppid,
                    AuthorizerRefreshToken = param.AuthorizerRefreshToken,
                    ComponentVerifyTicket = param.ComponentVerifyTicket
                });
                if (!bs.IsSuccess)
                {
                    return false;
                }
                token = bs.AuthorizerAccessToken;
            }
            else
            {
                token = WeChatConfig.GetToken();
            }
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