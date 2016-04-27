#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：SHA1Util
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/12/16 15:37:24
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
using System.Text;using Dos.Common;

namespace Dos.WeChat
{
    public class Sha1Util
    {
        public static String GetSha1(String str)
        {
            //建立SHA1对象
            SHA1 sha = new SHA1CryptoServiceProvider();
            //将mystr转换成byte[] 
            var enc = new ASCIIEncoding();
            var dataToHash = enc.GetBytes(str);
            //Hash运算
            var dataHashed = sha.ComputeHash(dataToHash);
            //将运算结果转换成string
            var hash = BitConverter.ToString(dataHashed).Replace("-", "");
            return hash;
        }
    }
}
