#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：WeChatParam
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/11 15:43:22
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

namespace Dos.WeChat.Model
{
    public class WeChatParam
    {
        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeChatPublic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Debug { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
    }
}
