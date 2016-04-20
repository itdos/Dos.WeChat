#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：BasicResult
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
using Newtonsoft.Json;

namespace Dos.WeChat
{
    /// <summary>
    /// 微信结果码
    /// </summary>
    public class WeChatResult
    {
        /// <summary>
        /// 
        /// </summary>
        public WeChatResult()
        {
        }
        /// <summary>
        ///  ErrCode传入0表示成功
        /// </summary>
        public WeChatResult(int errCode)
        {
            _errCode = errCode;
        }
        /// <summary>
        /// ErrCode传入0表示成功
        /// </summary>
        public WeChatResult(int errCode, string errMsg)
        {
            _errMsg = errMsg;
            _errCode = errCode;
        }
        /// <summary>
        /// 
        /// </summary>
        private int _errCode;
        /// <summary>
        /// 结果码
        /// </summary>
        [JsonProperty(PropertyName = "errcode")]
        public int ErrCode
        {
            get { return _errCode; }
            set { _errCode = value; }
        }
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
                switch (ErrCode)
                {
                    case -1:
                        _errMsg = ErrCode + "系统繁忙，请稍候再试_" + value;
                        break;
                    case 61003:
                        _errMsg = ErrCode + "该公众号已取消授权_" + value;
                        break;
                    default:
                        if (ErrCode == 0)
                            _errMsg = value;
                        else
                            _errMsg = ErrCode + value;
                        break;
                }
            }
        }

        private bool? _isSuccess;
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                if (_isSuccess == null)
                {
                    return  ErrCode == 0;
                }
                return _isSuccess.Value;
            }
            set { _isSuccess = value; }
        }
    }
}