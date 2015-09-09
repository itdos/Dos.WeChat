#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：CreateQRCode
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/1/4 10:43:50
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
using System.Net;
using System.Text;
using System.Web.Caching;
using Dos.Common;
using Dos.WeChat.Common;
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    public class QrCode
    {

        /// <summary>
        /// 创建二维码。
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static QrResult CreateTempQrCode(CreateQrCode msg)
        {
            var result = HttpHelper.Post<QrResult>(ApiList.QrcodeCreateUrl, msg.ToString(), "access_token=" + Token.GetAccessToken(msg));
            return result;
        }
        /// <summary>
        /// 传入ExpireSeconds，ActionName，ActionInfo（sceneId）。获取临时二维码，返回二维码图片文件的服务器地址。
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Stream GetTempQrCode(CreateQrCode msg)
        {
            msg.ActionName = EnumHelper.QrCodeType.QR_SCENE.ToString();
            var result = HttpHelper.Post<QrResult>(ApiList.QrcodeCreateUrl, msg.ToString(), "access_token=" + Token.GetAccessToken(msg));
            var url = ApiList.ShowQrcodeUrl + "?ticket=" + result.Ticket + "&access_token=" + Token.GetAccessToken(msg);
            var stream = HttpHelper.GetStream(url,"");
            return stream;
        }
        /// <summary>
        /// 传入ActionName，ActionInfo（scene_id对应QR_LIMIT_SCENE，scene_str对应QR_LIMIT_STR_SCENE）
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Stream GetEverQrCode(CreateQrCode msg)
        {
            msg.ActionName = EnumHelper.QrCodeType.QR_LIMIT_STR_SCENE.ToString();
            var result = HttpHelper.Post<QrResult>(ApiList.QrcodeCreateUrl, msg.ToString(),
                "access_token=" + Token.GetAccessToken(msg));
            var url = ApiList.ShowQrcodeUrl + "?ticket=" + result.Ticket + "&access_token=" + Token.GetAccessToken(msg);
            var stream = HttpHelper.GetStream(url, "");
            return stream;
        }
    }
}
