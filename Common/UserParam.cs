#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：EnumService
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/7/31 10:57:30
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
using Dos.WeChat.Model;

namespace Dos.WeChat.Model
{
    public class UserParam : WeChatParam
    {
        public string Code { get; set; }
    }
}
