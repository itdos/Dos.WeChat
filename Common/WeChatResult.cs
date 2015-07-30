#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：BasicResult
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
using Newtonsoft.Json;

namespace Dos.WeChat
{
    public class WeChatResult
    {
        /// <summary>
        /// 结果码
        /// </summary>
        [JsonProperty(PropertyName = "errcode")]
        public int ErrCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private string _errMsg;

        /// <summary>
        /// 结果文本说明
        /// </summary>
        [JsonProperty(PropertyName = "errmsg")]
        public string ErrMsg
        {
            get { return _errMsg; }
            set
            {
                if (value.Contains("access_token"))
                {
                    Token.ClearCache();
                }
                _errMsg = value;
            }
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return ErrCode == 0;
            }
            set { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static WeChatResult GetSuccess(string msg = null)
        {
            return new WeChatResult { ErrCode = 0, ErrMsg = msg ?? "完成" };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static WeChatResult GetFailed(string msg, Exception ex = null)
        {
            return new WeChatResult
            {
                ErrCode = -1,
                ErrMsg = string.Format("{0}\n{1}", msg, ex != null ? "发生异常：" + ex.Message : string.Empty)
            };
        }
    }
}