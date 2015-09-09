#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：ResponseHandler
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/12/16 15:36:56
* 文件描述：
    'api说明：
    'getKey()/setKey(),获取/设置密钥
    'getParameter()/setParameter(),获取/设置参数值
    'getAllParameters(),获取所有参数
    'isTenpaySign(),是否正确的签名,true:是 false:否
    'isWXsign(),是否正确的签名,true:是 false:否
    ' * isWXsignfeedback判断微信维权签名
    ' *getDebugInfo(),获取debug信息
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Text;

namespace Dos.WeChat
{
    public class ResponseHandler
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private string _key;
        /// <summary>
        /// 参与签名的参数列表
        /// </summary>
        //private static string SignField = "appid,appkey,timestamp,openid,noncestr,issubscribe";
        /// <summary>
        /// 微信服务器编码方式
        /// </summary>
        private const string Charset = "utf-8";
        //protected Hashtable parameters;
        private Hashtable xmlMap;

        //获取页面提交的get和post参数
        public ResponseHandler()
        {
            xmlMap = new Hashtable();
            if (HttpContext.Current.Request.InputStream.Length > 0)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Current.Request.InputStream);
                var root = xmlDoc.SelectSingleNode("xml");
                var xnl = root.ChildNodes;
                foreach (XmlNode xnf in xnl)
                {
                    xmlMap.Add(xnf.Name, xnf.InnerText);
                }
            }
        }

        /// <summary>
        /// 初始化加载
        /// </summary>
        public virtual void init()
        {
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
        /// 获取参数值
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetParameter(string parameter)
        {
            var s = (string)xmlMap[parameter];
            return s ?? "";
        }
        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="parameterValue"></param>
        public void SetParameter(string parameter, string parameterValue)
        {
            //if (parameter != null && parameter != "")
            //{
            //    if (parameters.Contains(parameter))
            //    {
            //        parameters.Remove(parameter);
            //    }

            //    parameters.Add(parameter, parameterValue);
            //}
        }

        /// <summary>
        /// 判断微信签名
        /// </summary>
        /// <returns></returns>
        public virtual bool IsWXsign(out string error)
        {
            var sb = new StringBuilder();
            var signMap = new Hashtable();
            foreach (string k in xmlMap.Keys)
            {
                if (k != "sign")
                {
                    signMap.Add(k.ToLower(), xmlMap[k]);
                }
            }
            var akeys = new ArrayList(signMap.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                var v = (string)signMap[k];
                sb.Append(k + "=" + v + "&");
            }
            sb.Append("key=" + this._key);
            var sign = MD5Util.GetMD5(sb.ToString(), Charset).ToUpper();
            error = "sign = " + sign + "\r\n xmlMap[sign]=" + xmlMap["sign"].ToString();
            return sign.Equals(xmlMap["sign"]);
        }

        /// <summary>
        /// 判断微信维权签名
        /// </summary>
        /// <returns></returns>
        public virtual bool IsWXsignfeedback()
        {
            return true;
            //StringBuilder sb = new StringBuilder();
            //Hashtable signMap = new Hashtable();

            //foreach (string k in xmlMap.Keys)
            //{
            //    if (SignField.IndexOf(k.ToLower()) != -1)
            //    {
            //        signMap.Add(k.ToLower(), xmlMap[k]);
            //    }
            //}
            //signMap.Add("appkey", this.appkey);


            //ArrayList akeys = new ArrayList(signMap.Keys);
            //akeys.Sort();

            //foreach (string k in akeys)
            //{
            //    string v = (string)signMap[k];
            //    if (sb.Length == 0)
            //    {
            //        sb.Append(k + "=" + v);
            //    }
            //    else
            //    {
            //        sb.Append("&" + k + "=" + v);
            //    }
            //}

            //string sign = SHA1Util.getSha1(sb.ToString()).ToString().ToLower();

            //this.setDebugInfo(sb.ToString() + " => SHA1 sign:" + sign);

            //return sign.Equals(xmlMap["AppSignature"]);
        }

        /// <summary>
        /// 获取编码方式
        /// </summary>
        /// <returns></returns>
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