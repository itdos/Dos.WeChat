#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：JsSdk
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/29 23:24:19
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
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class JsSdkHelper
    {
        /// <summary>
        /// 必须传入Debug，Url,可选传入：WeChatPublic
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static BaseResult CreateWxConfig(WeChatParam param)
        {
            try
            {
                var noncestr = PayUtil.GetNoncestr();
                var timestamp = PayUtil.GetTimestamp();
                var jsapiTicket = TokenHelper.GetJsapiTicket();
                if (!jsapiTicket.IsSuccess)
                {
                    return new BaseResult(false, null, jsapiTicket.ErrMsg);
                }
                var appId = WeChatConfig.GetAppId();
                var packageReq = new RequestHandler();
                packageReq.SetParameter("noncestr", noncestr);
                packageReq.SetParameter("jsapi_ticket", jsapiTicket.Ticket);
                packageReq.SetParameter("timestamp", timestamp);
                packageReq.SetParameter("url", param.Url);
                var signature = packageReq.CreateSHA1Sign();
                // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                // 必填，公众号的唯一标识
                // 必填，生成签名的时间戳
                // 必填，生成签名的随机串
                // 必填，签名，见附录1
                // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
                var result = "wx.config({debug:" + (param.Debug ? "true" : "false") + ", appId: '" + appId + "', timestamp: " + timestamp + ", nonceStr: '" + noncestr + "', signature: '" + signature + "',jsApiList: ['checkJsApi','onMenuShareTimeline','onMenuShareAppMessage','onMenuShareQQ','onMenuShareWeibo','hideMenuItems','showMenuItems','hideAllNonBaseMenuItem','showAllNonBaseMenuItem','translateVoice','startRecord','stopRecord','onRecordEnd','playVoice','pauseVoice','stopVoice','uploadVoice','downloadVoice','chooseImage','previewImage','uploadImage','downloadImage','getNetworkType','openLocation','getLocation','hideOptionMenu','showOptionMenu','closeWindow','scanQRCode','chooseWXPay','openProductSpecificView','addCard','chooseCard','openCard'] });";//'checkJsApi',
                return new BaseResult(true, result);
            }
            catch (Exception ex)
            {
                return new BaseResult(false, null, "var error='" + ex.Message.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").Replace("<br>", "").Replace("'", "\"") + "';");
            }
        }
    }
}
