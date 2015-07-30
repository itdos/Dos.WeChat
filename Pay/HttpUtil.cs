#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：HttpUtil
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/12/18 13:16:28
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Dos.WeChat
{
    public class HttpUtil
    {
        public HttpUtil()
        {
            _caFile = "";
            _certFile = "";
            _certPasswd = "";
            _reqContent = "";
            _resContent = "";
            _method = "POST";
            _errInfo = "";
            _timeOut = 1 * 60;//5分钟
            _responseCode = 0;
            _charset = "utf-8";
        }
        public HttpUtil(string caFile, string certFile, string certPasswd, string reqContent, string resContent, string method, string errInfo, int timeOut, int responseCode, string charset)
        {
            _caFile = caFile;
            _certFile = certFile;
            _certPasswd = certPasswd;
            _reqContent = reqContent;
            _resContent = resContent;
            _method = method;
            _errInfo = errInfo;
            _timeOut = timeOut;
            _responseCode = responseCode;
            _charset = charset;
        }
        private const string SContentType = "application/x-www-form-urlencoded";
        private const string SUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
        //请求内容，无论post和get，都用get方式提供
        private string _reqContent;
        //应答内容
        private string _resContent;
        //请求方法
        private string _method;
        //错误信息
        private string _errInfo;
        //证书文件 
        private string _certFile;
        //证书密码 
        private string _certPasswd;
        //ca证书文件 
        private string _caFile;
        //超时时间,以秒为单位 
        private int _timeOut;
        //http应答编码 
        private int _responseCode;
        //字符编码
        private string _charset;
        //设置请求内容
        public void SetReqContent(string reqContent)
        {
            this._reqContent = reqContent;
        }
        //获取结果内容
        public string GetResContent()
        {
            return this._resContent;
        }
        //设置请求方法post或者get	
        public void SetMethod(string method)
        {
            this._method = method;
        }
        //获取错误信息
        public string GetErrInfo()
        {
            return this._errInfo;
        }
        //设置证书信息
        public void SetCertInfo(string certFile, string certPasswd)
        {
            this._certFile = certFile;
            this._certPasswd = certPasswd;
        }
        //设置ca
        public void SetCaInfo(string caFile)
        {
            this._caFile = caFile;
        }
        //设置超时时间,以秒为单位
        public void SetTimeOut(int timeOut)
        {
            this._timeOut = timeOut;
        }
        //获取http状态码
        public int GetResponseCode()
        {
            return this._responseCode;
        }
        public void SetCharset(string charset)
        {
            this._charset = charset;
        }
        //验证服务器证书
        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        public string Send(string data, string url)
        {
            return Send(Encoding.GetEncoding(_charset).GetBytes(data), url);
        }
        public string Send(byte[] data, string url)
        {
            string result;
            var req = (HttpWebRequest)WebRequest.Create(url);
            if (!string.IsNullOrWhiteSpace(_certFile))
            {
                ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
                var cer = new X509Certificate2(_certFile, _certPasswd, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                req.ClientCertificates.Add(cer);
                #region 暂时注释不要的
                //ServicePointManager.Expect100Continue = true;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                //req.ProtocolVersion = HttpVersion.Version11;
                //req.UserAgent = SUserAgent;
                //req.KeepAlive = false;
                //var cookieContainer = new CookieContainer();
                //req.CookieContainer = cookieContainer;
                //req.Timeout = 1000 * 60;
                //req.Headers.Add("x-requested-with", "XMLHttpRequest");
                #endregion
            }
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = SContentType;
            var stream = req.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            var res = (HttpWebResponse)req.GetResponse();
            using (var reader = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding(_charset)))
            {
                result = reader.ReadToEnd();
            }
            res.Close();
            return result;
        }
    }
}
