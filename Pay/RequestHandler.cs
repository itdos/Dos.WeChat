#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：RequestHandler
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/12/16 15:36:07
* 文件描述： 
   'api说明：
   'init();
   '初始化函数，默认给一些参数赋值。
   'setKey(key_)'设置商户密钥
   'createMd5Sign(signParams);字典生成Md5签名
   'genPackage(packageParams);获取package包
   'createSHA1Sign(signParams);创建签名SHA1
   'parseXML();输出xml
   'getDebugInfo(),获取debug信息
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Dos.WeChat
{
    public class RequestHandler
    {
        public RequestHandler()
        {
            Parameters = new Hashtable();
        }
        /// <summary>
        /// 密钥
        /// </summary>
        private string _key;
        /// <summary>
        /// 请求的参数
        /// </summary>
        protected Hashtable Parameters;
        /// <summary>
        /// debug信息
        /// </summary>
        private string _debugInfo;
        /// <summary>
        /// 初始化函数
        /// </summary>
        public virtual void Init()
        {
            
        }
        /// <summary>
        /// 获取debug信息
        /// </summary>
        /// <returns></returns>
        public String GetDebugInfo()
        {
            return _debugInfo;
        }
        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            return _key;
        }
        /// <summary>
        /// 设置密钥
        /// </summary>
        /// <param name="key"></param>
        public void SetKey(string key)
        {
            this._key = key;
        }
        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="parameterValue"></param>
        public void SetParameter(string parameter, string parameterValue)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                if (Parameters.Contains(parameter))
                {
                    Parameters.Remove(parameter);
                }
                Parameters.Add(parameter, parameterValue);
            }
        }
        /// <summary>
        /// 获取package带参数的签名包
        /// </summary>
        /// <returns></returns>
        public string GetRequestURL()
        {
            this.CreateMd5Sign();
            var sb = new StringBuilder();
            var akeys = new ArrayList(Parameters.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                var v = (string)Parameters[k];
                if (null != v && String.Compare("key", k, StringComparison.Ordinal) != 0)
                {
                    sb.Append(k + "=" + PayUtil.UrlEncode(v, GetCharset()) + "&");
                }
            }
            //去掉最后一个&
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 创建package签名，按参数名称a-z排序,遇到空值的参数不参加签名。
        /// </summary>
        /// <returns></returns>
        public string CreateMd5Sign()
        {
            var sb = new StringBuilder();
            var akeys = new ArrayList(Parameters.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                var v = (string)Parameters[k];
                if (null != v && String.Compare("", v, StringComparison.Ordinal) != 0
                    && String.Compare("sign", k, StringComparison.Ordinal) != 0 && String.Compare("key", k, StringComparison.Ordinal) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }
            sb.Append("key=" + GetKey());
            var sign = MD5Util.GetMD5(sb.ToString(), GetCharset()).ToUpper();
            return sign;
        }
        /// <summary>
        /// 创建sha1签名
        /// </summary>
        /// <returns></returns>
        public string CreateSHA1Sign()
        {
            var sb = new StringBuilder();
            var akeys = new ArrayList(Parameters.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                var v = (string)Parameters[k];
                if (null != v && String.Compare("", v, StringComparison.Ordinal) != 0
                       && String.Compare("sign", k, StringComparison.Ordinal) != 0 && String.Compare("key", k, StringComparison.Ordinal) != 0)
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(k + "=" + v);
                    }
                    else
                    {
                        sb.Append("&" + k + "=" + v);
                    }
                }
            }
            var paySign = Sha1Util.GetSha1(sb.ToString()).ToLower();
            return paySign;
        }
        /// <summary>
        /// 输出XML
        /// </summary>
        /// <returns></returns>
        public string ParseXml()
        {
            var sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (string k in Parameters.Keys)
            {
                var v = (string)Parameters[k];
                if (Regex.IsMatch(v, @"^[0-9.]$"))
                {
                    sb.Append("<" + k + ">" + v + "</" + k + ">");
                }
                else
                {
                    sb.Append("<" + k + "><![CDATA[" + v + "]]></" + k + ">");
                }
            }
            sb.Append("</xml>");
            return sb.ToString();
        }
        /// <summary>
        /// 输出XML
        /// </summary>
        /// <returns></returns>
        public string ParseXmlNoCdata()
        {
            var sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (string k in Parameters.Keys)
            {
                var v = (string)Parameters[k];
                sb.Append("<" + k + ">" + v + "</" + k + ">");
            }
            sb.Append("</xml>");
            return sb.ToString();
        }
        /// <summary>
        /// 输出JSON
        /// </summary>
        /// <returns></returns>
        public string ParseJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            foreach (string k in Parameters.Keys)
            {
                var v = (string)Parameters[k];
                sb.Append("\"" + k + "\":\"" + v +"\",");
            }
            var str = sb.ToString().TrimEnd(',');
            str += "}";
            return str;
        }
        public Hashtable GetAllParameters()
        {
            return this.Parameters;
        }
        protected virtual string GetCharset()
        {
            try
            {
                return HttpContext.Current.Request.ContentEncoding.BodyName;
            }
            catch (Exception)
            {
                return "UTF-8";
            }
        }
    }
}
