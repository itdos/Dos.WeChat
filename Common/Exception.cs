#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：WxException
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

namespace Dos.WeChat
{ /// <summary>
    /// 
    /// </summary>
    public class WxException : ApplicationException
    { /// <summary>
        /// 
        /// </summary>
        public WxException(int errCode, string errMsg)
        {
            ErrCode = errCode;
            ErrMsg = errMsg;
        }
        /// <summary>
        /// 
        /// </summary>
        public WxException(WeChatResult result)
        {
            ErrCode = result.ErrCode;
            ErrMsg = result.ErrMsg;
        }
        /// <summary>
        /// 
        /// </summary>
        public int ErrCode { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrMsg { get; private set; }

        /// <summary>
        /// 获取描述当前异常的消息。
        /// </summary>
        /// <returns>
        /// 解释异常原因的错误消息或空字符串 ("")。
        /// </returns>
        public override string Message
        {
            get { return ErrMsg; }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MenuException : WxException
    { /// <summary>
        /// 
        /// </summary>
        public MenuException(int errCode, string errMsg)
            : base(errCode, errMsg)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public MenuException(WeChatResult result)
            : base(result)
        {
        }
    }
}