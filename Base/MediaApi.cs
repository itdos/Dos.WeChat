#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MediaExpand
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/5/7 14:30:06
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
using System.Text.RegularExpressions;
using Dos.Common;
using Dos.WeChat.Common;
using Dos.WeChat.Model;
using Newtonsoft.Json;

namespace Dos.WeChat
{
    public class MediaApi
    {
        /// <summary>
        /// 
        /// </summary>
        public static RemoteMedia Upload(LocalMedia media)
        {
            var checkRet = Check(media);
            if (!checkRet.IsSuccess)
                throw new WxException(-9999, checkRet.ErrMsg);

            var param = new HttpParam
            {
                {"access_token", Token.GetAccessToken(media)},
                {"type", media.MediaType}
            };
            var rs = HttpHelper.Upload(ApiList.MediaUploadUrl, param, media.MediaPath);
            var result = JsonConvert.DeserializeObject<RemoteMedia>(rs);
            if (string.IsNullOrEmpty(result.MediaID))
            {
                var ex = JsonConvert.DeserializeObject<WeChatResult>(rs);
                throw new WxException(ex);
            }
            return result;
        } 

        /// <summary>
        ///     检测上传的媒体是否满足基本要求
        /// </summary>
        private static WeChatResult Check(LocalMedia media)
        {
            var sizes = new Dictionary<string, long>
            {
                {Media.Image, 128*1024},
                {Media.Voice, 256*1024},
                {Media.Video, 1*1024*1024},
                {Media.Thumb, 64*1024},
            };

            if (media == null)
                return WeChatResult.GetFailed("缺少媒体参数");
            if (!File.Exists(media.MediaPath))
                return WeChatResult.GetFailed("指定的媒体文件不存在");
            if (string.IsNullOrEmpty(media.MediaType))
                return WeChatResult.GetFailed("未指定媒体类型");
            if (new FileInfo(media.MediaPath).Length > sizes[media.MediaType])
                return WeChatResult.GetFailed(string.Format("指定的媒体文件超过限制大小{0}K", sizes[media.MediaPath] / 1024));

            return WeChatResult.GetSuccess();
        }

        /// <summary>
        /// 传入MediaID，WeChatPublic
        /// </summary>
        public static WeChatResult Download(MediaParam mediaParam)
        {
            var param = new HttpParam
            {
                {"access_token", Token.GetAccessToken(mediaParam)},
                {"media_id", mediaParam.MediaID}
            };
            var url = string.Format("{0}?{1}", ApiList.MediaGet, param.Format());
            var request = HttpHelper.CreateRequest(url);
            var response = request.GetResponse();
            using (var stream = response.GetResponseStream())
            {
                var disposition = response.Headers["Content-disposition"];
                if (string.IsNullOrEmpty(disposition))
                {
                    var s = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
                    return JsonConvert.DeserializeObject<WeChatResult>(s);
                }
                var fs = new FileStream(mediaParam.FilePath, FileMode.OpenOrCreate);
                try
                {
                    var buffer = new byte[128 * 1024]; //128K
                    int i;
                    while ((i = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, i);
                    }

                    return WeChatResult.GetSuccess(mediaParam.FilePath);
                }
                finally
                {
                    fs.Close();
                }
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MediaParam : WeChatParam
    {
        /// <summary>
        ///     媒体文件上传后，获取时的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "media_id")]
        public string MediaID { get; set; }
        public string FilePath { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Media : WeChatParam
    {
        /// <summary>
        ///     图片（image）: 128K，支持JPG格式
        /// </summary>
        public const string Image = "image";

        /// <summary>
        ///     语音（voice）：256K，播放长度不超过60s，支持AMR\MP3格式
        /// </summary>
        public const string Voice = "voice";

        /// <summary>
        ///     视频（video）：1MB，支持MP4格式
        /// </summary>
        public const string Video = "video";

        /// <summary>
        ///     缩略图（thumb）：64KB，支持JPG格式
        /// </summary>
        public const string Thumb = "thumb";

        /// <summary>
        ///     常量中描述的媒体类型
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string MediaType { get; set; }
    }


    /// <summary>
    ///     本地媒体
    /// </summary>
    public class LocalMedia : Media
    {
        /// <summary>
        ///     本地全路径
        /// </summary>
        public string MediaPath { get; set; }
    }

    /// <summary>
    /// 远程媒体。指保存在微信服务器上的媒体。
    /// </summary>
    public class RemoteMedia : Media
    {
        /// <summary>
        /// 媒体文件上传后，获取时的唯一标识
        /// </summary>
        [JsonProperty(PropertyName = "media_id")]
        public string MediaID { get; set; }

        /// <summary>
        ///     媒体文件上传时间戳
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public int Timestamp { get; set; }
    }
}
