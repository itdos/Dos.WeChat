#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：TenpayUtil
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/12/16 15:38:29
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Xml.Linq;
using Dos.Common;
using Dos.Common.Helper;
using Dos.WeChat.Common;
using Dos.WeChat.Model;
using Newtonsoft.Json;
//using ServiceStack.Common.Extensions;
//using ServiceStack.ServiceModel;


namespace Dos.WeChat
{
    public class PayUtil
    {
        /// <summary>
        /// billDate格式 20141212
        /// </summary>
        /// <param name="context"></param>
        /// <param name="billDate"></param>
        /// <returns></returns>
        public static BaseResult DownloadBill(string billDate, WeChatParam param)
        {
            var packageReq = new RequestHandler();
            packageReq.SetKey(GetConfig.GetKey(param));
            packageReq.SetParameter("appid", GetConfig.GetAppid(param));
            packageReq.SetParameter("mch_id", GetConfig.GetMchId(param));
            packageReq.SetParameter("nonce_str", GetNoncestr());
            packageReq.SetParameter("bill_date", billDate);
            packageReq.SetParameter("bill_type", "ALL");
            packageReq.SetParameter("sign", packageReq.CreateMd5Sign());
            var reqXml = packageReq.ParseXml();
            var httpClient = new HttpUtil();
            httpClient.SetCharset(HttpContext.Current.Request.ContentEncoding.BodyName);
            var result = httpClient.Send(reqXml, ApiList.DownloadBillUrl);
            try
            {
                var xe = XElement.Parse(result, LoadOptions.SetLineInfo);
                var reResult1 = xe.GetElement("return_code") == null ? "" : xe.GetElement("return_code").Value;
                var reResult2 = xe.GetElement("return_msg") == null ? "" : xe.GetElement("return_msg").Value;
                return new BaseResult() { IsSuccess = false, Data = "", Message = reResult1 +"_" + reResult2 };
            }
            catch (Exception)
            {
                var list = new List<Bill>();
                var myList = result.Replace("\r\n", "|").Split('|').Skip(1).ToList<string>();
                myList.RemoveAt(myList.Count() - 1);
                myList.RemoveAt(myList.Count() - 1);
                myList.RemoveAt(myList.Count() - 1);
                string[] arr;
                foreach (var str in myList)
                {
                    arr = str.Replace("`", "").Split(',');
                    #region 赋值
                    list.Add(new Bill()
                    {
                        交易时间 = arr[0],
                        公众账号ID = arr[1],
                        商户号 = arr[2],
                        子商户号 = arr[3],
                        设备号 = arr[4],
                        微信订单号 = arr[5],
                        商户订单号 = arr[6],
                        用户标识 = arr[7],
                        交易类型 = arr[8],
                        交易状态 = arr[9],
                        付款银行 = arr[10],
                        货币种类 = arr[11],
                        总金额 = arr[12],
                        企业红包金额 = arr[13],
                        微信退款单号 = arr[14],
                        商户退款单号 = arr[15],
                        退款金额 = arr[16],
                        企业红包退款金额 = arr[17],
                        退款类型 = arr[18],
                        退款状态 = arr[19],
                        商品名称 = arr[20],
                        商户数据包 = arr[21],
                        手续费 = arr[22],
                        费率 = arr[23]
                    });
                    #endregion
                }
                return new BaseResult() { IsSuccess = true, Data = list };
            }
        }
        /// <summary>
        /// 传入订单号OrderNumber，RefundNumber,总金额total_fee（分）,RefundFee退款金额(分)，
        /// </summary>
        /// <param name="context"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static BaseResult Refund(PayParam param)
        {
            if (param.TotalFee == null || param.RefundFee == null || string.IsNullOrWhiteSpace(param.OrderNumber) || string.IsNullOrWhiteSpace(param.RefundNumber))
            {
                return new BaseResult() { IsSuccess = false, Message = "参数错误！" };
            }
            #region 财付通退款，已OK
            //var packageReq = new RequestHandler(context);
            //packageReq.SetKey(Key);
            //packageReq.SetParameter("partner", "1225604801");
            //packageReq.SetParameter("out_trade_no", param.OrderNumber);
            //packageReq.SetParameter("out_refund_no", param.OrderNumber);
            //packageReq.SetParameter("total_fee", param.TotalFee.Value.ToString(CultureInfo.InvariantCulture));
            //packageReq.SetParameter("refund_fee", param.RefundFee.Value.ToString(CultureInfo.InvariantCulture));
            //packageReq.SetParameter("op_user_id", "1225604801");
            //packageReq.SetParameter("op_user_passwd", "111111");
            //packageReq.SetParameter("sign", packageReq.CreateSign());
            //var httpClient = new HttpUtil();
            ////httpClient.SetCharset(context.Request.ContentEncoding.BodyName);
            ////这里很神奇，必须要用 GB2312编码，不能通过 context.Request.ContentEncoding.BodyName获取编码
            //httpClient.SetCharset("gb2312");
            //httpClient.SetCertInfo(WeChatCertPath, WeChatCertPwd);
            //var reqXml = packageReq.GetRequestURL();
            //var result = httpClient.Send(reqXml, "https://mch.tenpay.com/refundapi/gateway/refund.xml");
            //var xe = XElement.Parse(result, LoadOptions.SetLineInfo);
            //return new BaseResult() { IsSuccess = false };
            #endregion

            #region 微信退款
            var packageReq = new RequestHandler();
            packageReq.SetKey(GetConfig.GetKey(param));
            packageReq.SetParameter("appid", GetConfig.GetAppid(param));
            packageReq.SetParameter("mch_id", GetConfig.GetMchId(param));
            packageReq.SetParameter("nonce_str", GetNoncestr());
            //packageReq.SetParameter("transaction_id", "");
            packageReq.SetParameter("out_trade_no", param.OrderNumber);
            packageReq.SetParameter("out_refund_no", param.RefundNumber);
            packageReq.SetParameter("total_fee", (param.TotalFee.Value).ToString(CultureInfo.InvariantCulture));
            packageReq.SetParameter("refund_fee", param.RefundFee.Value.ToString(CultureInfo.InvariantCulture));
            packageReq.SetParameter("op_user_id", GetConfig.GetMchId(param));
            packageReq.SetParameter("sign", packageReq.CreateMd5Sign());
            var reqXml = packageReq.ParseXml();
            var httpClient = new HttpUtil();
            httpClient.SetCharset(HttpContext.Current.Request.ContentEncoding.BodyName);
            httpClient.SetCertInfo(GetConfig.GetCertPath(param), GetConfig.GetCertPwd(param));
            var result = httpClient.Send(reqXml, "https://api.mch.weixin.qq.com/secapi/pay/refund");
            var xe = XElement.Parse(result, LoadOptions.SetLineInfo);
            var returnCode = xe.GetElement("return_code").Value;
            //退款成功
            if (returnCode.Equals("SUCCESS"))
            {
                var resultCode = xe.GetElement("result_code").Value;
                if (resultCode.Equals("SUCCESS"))
                {
                    var outTradeNo = xe.GetElement("out_trade_no").Value;
                    //在外面回写订单
                    return new BaseResult()
                    {
                        IsSuccess = true,
                        Data = new Dictionary<string, string>
                            {
                                {"OrderNumber", outTradeNo}
                            }
                    };
                }
            }
            var errCodeDes = xe.GetElement("err_code_des") == null ? "" : xe.GetElement("err_code_des").Value;
            var returnMsg = xe.GetElement("return_msg") == null ? "" : xe.GetElement("return_msg").Value;

            return new BaseResult() { IsSuccess = false, Message = returnMsg + errCodeDes };
            #endregion
        }

        public static BaseResult Notify(WeChatParam param)
        {
            try
            {
                var res = new ResponseHandler();
                res.SetKey(GetConfig.GetKey(param));
                var error = "";
                //判断签名
                if (res.IsWXsign(out error))
                {
                    #region 参数
                    var returnCode = res.GetParameter("return_code");
                    //返回信息，如非空，为错误原因签名失败参数格式校验错误
                    var returnMsg = res.GetParameter("return_msg");
                    var appid = res.GetParameter("appid");

                    //以下字段在 return_code 为 SUCCESS 的时候有返回--------------------------------
                    var mchId = res.GetParameter("mch_id");
                    var deviceInfo = res.GetParameter("device_info");
                    var nonceStr = res.GetParameter("nonce_str");
                    var resultCode = res.GetParameter("result_code");
                    var errCode = res.GetParameter("err_code");
                    var errCodeDes = res.GetParameter("err_code_des");

                    //以下字段在 return_code 和 result_code 都为 SUCCESS 的时候有返回---------------
                    var openid = res.GetParameter("openid");
                    //Y-关注，N-未关注，仅在公众账号类型支付有效
                    var isSubscribe = res.GetParameter("is_subscribe");
                    var tradeType = res.GetParameter("trade_type");
                    //银行类型，采用字符串类型的银行标识
                    var bankType = res.GetParameter("bank_type");
                    var totalFee = res.GetParameter("total_fee");
                    //货币类型，符合 ISO 4217 标准的三位字母代码，默认人民币：CNY
                    var feeType = res.GetParameter("fee_type");
                    //微信支付订单号
                    var transactionId = res.GetParameter("transaction_id");
                    //商户系统的订单号，与请求一致。
                    var outTradeNo = res.GetParameter("out_trade_no");
                    var attach = res.GetParameter("attach");
                    //格 式 为yyyyMMddhhmmss
                    var timeEnd = res.GetParameter("time_end");
                    #endregion
                    //支付成功
                    if (!outTradeNo.Equals("") && returnCode.Equals("SUCCESS") && resultCode.Equals("SUCCESS"))
                    {
                        //LogHelper.WriteLog("支付回调：", sbResult.ToString() + "notify > success \r\n",EnumService.LogType.Debug);
                        //在外面回写订单
                        return new BaseResult()
                        {
                            IsSuccess = true,
                            Data = new Dictionary<string, string>
                            {
                                {"OrderNumber", outTradeNo},
                                {"WeChat", openid},
                            }
                        };
                    }
                    else
                    {
                        //LogHelper.WriteLog("支付回调：", sbResult.ToString() + "notify > total_fee= " + totalFee + " \r\n  err_code_des= " + errCodeDes + " \r\n  result_code= " + resultCode + " \r\n", EnumService.LogType.Exception);
                    }
                }
                else
                {
                    //LogHelper.WriteLog("支付回调：",sbResult.ToString() + "notify > isWXsign= false \r\n" + error, EnumService.LogType.Exception);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog("支付回调：",sbResult.ToString() + "notify > ex=" + ex.Message + @ex.StackTrace + @ex.InnerException + " \r\n",  EnumService.LogType.Exception);
            }
            return new BaseResult() { IsSuccess = false };
        }
        /// <summary>
        /// 传入ProductName，OrderNumber，TotalFee，TimeExpire，OpenId（可选），TradeType，NotifyUrl（可选）
        /// </summary>
        /// <param name="param"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetUnifiedOrder(PayParam param = null)
        {
            if (param.TotalFee == null || string.IsNullOrWhiteSpace(param.ProductName) || string.IsNullOrWhiteSpace(param.OrderNumber) || string.IsNullOrWhiteSpace(param.TimeExpire) || param.TradeType == null)
            {
                return "参数错误";
            }
            var req = new RequestHandler();
            req.SetKey(GetConfig.GetKey(param));
            req.SetParameter("appid", GetConfig.GetAppid(param));
            req.SetParameter("mch_id", GetConfig.GetMchId(param));
            req.SetParameter("nonce_str", GetNoncestr());
            req.SetParameter("body", param.ProductName);
            req.SetParameter("out_trade_no", param.OrderNumber);
            req.SetParameter("total_fee", param.TotalFee.ToString());
            req.SetParameter("spbill_create_ip", IPHelper.GetVisitorIP());
            req.SetParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            req.SetParameter("time_expire", param.TimeExpire);
            req.SetParameter("notify_url", 
                string.IsNullOrWhiteSpace(param.NotifyUrl) ? GetConfig.GetNotify(param) : param.NotifyUrl);
            req.SetParameter("trade_type", param.TradeType.ToString());
            if (!string.IsNullOrWhiteSpace(param.OpenId))
            {
                req.SetParameter("openid", param.OpenId);
            }
            req.SetParameter("sign", req.CreateMd5Sign());

            var reqXml = req.ParseXml();
            //LogHelper.WriteLog("aa_", "reqXml的值是：" + reqXml);
            var http = new HttpUtil();
            http.SetCharset(HttpContext.Current.Request.ContentEncoding.BodyName);
            var result = http.Send(reqXml, ApiList.UnifiedOrderUrl);
            return result;
        }
        /// <summary>
        /// 传入 OpenId,订单Id，金额（分），过期时间（20141010121314），商品名称。
        /// </summary>
        /// <returns></returns>
        public static string CreateJSAPIPayJson(PayParam param)
        {
            if (param.TotalFee == null || string.IsNullOrWhiteSpace(param.ProductName) || string.IsNullOrWhiteSpace(param.OrderNumber) || string.IsNullOrWhiteSpace(param.OpenId) || string.IsNullOrWhiteSpace(param.TimeExpire))
            {
                return "参数错误";
            }
            param.TradeType = EnumHelper.TradeType.JSAPI;
            var result = GetUnifiedOrder(param);
            //LogHelper.WriteLog("aa_", "GetUnifiedOrder后的值是：" + result);
            var xe = XElement.Parse(result, LoadOptions.SetLineInfo);
#warning 这里暂时使用了 redis的Common
            try
            {
                var prepayId = xe.GetElement("prepay_id").Value;
                var payReq = new RequestHandler();
                payReq.SetKey(GetConfig.GetKey(param));
                payReq.SetParameter("appId", GetConfig.GetAppid(param));
                payReq.SetParameter("timeStamp", PayUtil.GetTimestamp());
                payReq.SetParameter("nonceStr", PayUtil.GetNoncestr());
                payReq.SetParameter("package", "prepay_id=" + prepayId);
                payReq.SetParameter("signType", "MD5");
                //创建签名
                payReq.SetParameter("paySign", payReq.CreateMd5Sign());
                var payReqXml = payReq.ParseXml();
                var payReqJson = payReq.ParseJson();
                return payReqJson;
            }
            catch (Exception)
            {
                var returnCode = xe.GetElement("return_code").Value;
                var returnMsg = xe.GetElement("return_msg").Value;
                return "{Error:'" + returnCode + returnMsg + "'}";
            }
        }
        public static string Tenpay = "1";
        ///// <summary>
        ///// paysignkey(非appkey) 
        ///// </summary>
        //public static string Appkey = "";
        public PayUtil()
        {
        }
        public static string GetNoncestr()
        {
            var random = new Random();
            return MD5Util.GetMD5(random.Next(1000).ToString(CultureInfo.InvariantCulture), "GBK");
        }
        public static string GetTimestamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// 对字符串进行URL编码
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string UrlEncode(string instr, string charset)
        {
            //return instr;
            if (instr == null || instr.Trim() == "")
                return "";
            string res;
            try
            {
                res = HttpUtility.UrlEncode(instr, Encoding.GetEncoding(charset));
            }
            catch
            {
                res = HttpUtility.UrlEncode(instr, Encoding.GetEncoding("utf-8"));
            }
            return res;
        }

        /// <summary>
        /// 对字符串进行URL解码
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string UrlDecode(string instr, string charset)
        {
            if (instr == null || instr.Trim() == "")
                return "";
            else
            {
                string res;
                try
                {
                    res = HttpUtility.UrlDecode(instr, Encoding.GetEncoding(charset));
                }
                catch
                {
                    res = HttpUtility.UrlDecode(instr, Encoding.GetEncoding("utf-8"));
                }
                return res;

            }
        }
        /// <summary>
        /// 取时间戳生成随即数,替换交易单号中的后10位流水号
        /// </summary>
        /// <returns></returns>
        public static UInt32 UnixStamp()
        {
            var ts = DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToUInt32(ts.TotalSeconds);
        }
        /// <summary>
        /// 取随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string BuildRandomStr(int length)
        {
            var rand = new Random();
            var num = rand.Next();
            var str = num.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            else if (str.Length < length)
            {
                int n = length - str.Length;
                while (n > 0)
                {
                    str.Insert(0, "0");
                    n--;
                }
            }
            return str;
        }
    }
}
