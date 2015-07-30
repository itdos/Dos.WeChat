#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：BaseResultModel
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/29 23:03:02
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
    public class BaseResultModel
    {
        /// <summary>
        /// 错误信息号
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 错误消息文本
        /// </summary>
        public string errmsg { get; set; }
    }
}
