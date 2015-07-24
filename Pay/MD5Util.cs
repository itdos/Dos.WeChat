#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MD5Util
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/12/16 15:34:47
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
using System.Security.Cryptography;
using System.Text;

namespace Dos.WeChat
{
    public class MD5Util
    {
        public MD5Util()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, string charset)
        {
            var m5 = new MD5CryptoServiceProvider();
            //创建md5对象
            byte[] inputBye;
            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch
            {
                inputBye = Encoding.GetEncoding("utf-8").GetBytes(encypStr);
            }
            var outputBye = m5.ComputeHash(inputBye);
            var retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
    }
}
