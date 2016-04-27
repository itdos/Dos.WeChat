#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：PayParam
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/12/17 10:06:13
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
using System.Text;using Dos.Common;
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    public class PayParam : WeChatParam
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }
        public string RefundNumber { get; set; }
        /// <summary>
        /// 金额（分）
        /// </summary>
        public int? TotalFee { get; set; }
        public int? RefundFee { get; set; }
        /// <summary>
        /// 过期时间，格式（20141010121314）
        /// </summary>
        public string TimeExpire { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 支付成功回调地址
        /// </summary>
        public string NotifyUrl { get; set; }

        public EnumHelper.TradeType? TradeType { get; set; }
    }
}
