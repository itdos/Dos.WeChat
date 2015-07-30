#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：LogHelper
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：周浩
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
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Configuration;

namespace Common
{
    public class LogHelperWx
    {
        private static readonly object Olock = new object();
        /// <summary>
        /// filePrefixName是文件名前缀，最好用中文，方便在程序Logs文件下查看。
        /// </summary>
        /// <param name="infos"></param>
        public static void WriteLog(string infos)
        {
            WriteLog("", infos);
        }
        /// <summary>
        /// filePrefixName是文件名前缀，最好用中文，方便在程序Logs文件下查看。
        /// </summary>
        /// <param name="filePrefixName"></param>
        /// <param name="infos"></param>
        public static void WriteLog(string filePrefixName, string infos)
        {
            try
            {
                var isLog = WebConfigurationManager.AppSettings["IsLog"];
                if (isLog == null || isLog == "1")
                {
                    lock (Olock)
                    {
                        #region 日志文件//log4net orchard

                        var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + filePrefixName +
                                   DateTime.Now.ToString("yyyyMMdd") + ".txt";
                        var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\");
                        if (!di.Exists)
                        {
                            di.Create();
                        }
                        using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                        {
                            var sw = new StreamWriter(fs);
                            sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sw.WriteLine();
                            sw.Write(infos);
                            sw.WriteLine();
                            sw.Write("-----------------------------------------------------------------------------");
                            sw.WriteLine();
                            sw.Flush();
                            sw.Close();
                        }

                        #endregion
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// filePrefixName是文件名前缀，最好用中文，方便在程序Logs文件下查看。
        /// </summary>
        /// <param name="filePrefixName"></param>
        /// <param name="infos"></param>
        public static void WriteLogInfo(string filePrefixName, string infos)
        {
            try
            {
                var isLog = WebConfigurationManager.AppSettings["IsLog"];
                if (isLog == null || isLog == "1")
                {
                    lock (Olock)
                    {
                        #region 日志文件//log4net orchard

                        var path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + filePrefixName +
                                   DateTime.Now.ToString("yyyyMMdd") + ".txt";
                        var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + filePrefixName);
                        if (!di.Exists)
                        {
                            di.Create();
                        }
                        using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                        {
                            var sw = new StreamWriter(fs);
                            sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sw.WriteLine();
                            sw.Write(infos);
                            sw.WriteLine();
                            sw.Write("-----------------------------------------------------------------------------");
                            sw.WriteLine();
                            sw.Flush();
                            sw.Close();
                        }

                        #endregion
                    }
                }
            }
            catch
            {
            }
        }
    }
}