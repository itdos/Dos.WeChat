#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：Bill
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/2/22 21:49:47
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

namespace Dos.WeChat
{
    /// <summary>
    /// 
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// 交易时间
        /// </summary>
        public string 交易时间 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 公众账号ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 商户号 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 子商户号 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 设备号 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 微信订单号 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 商户订单号 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 用户标识 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 交易类型 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 交易状态 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 付款银行 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 货币种类 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 总金额 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 企业红包金额 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 微信退款单号 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 商户退款单号 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 退款金额 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 企业红包退款金额 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 退款类型 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 退款状态 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 商品名称 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 商户数据包 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 手续费 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string 费率 { get; set; }
    }
}
