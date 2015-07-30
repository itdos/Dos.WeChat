#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：UserHelper
* Copyright(c) 青之软件
* CLR 版本: 4.0.30319.18408
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2015/4/11 15:27:42
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
using System.Text;
using Dos.Common;
using Dos.WeChat.Common;
using Dos.WeChat.Model;

namespace Dos.WeChat
{
    public class UserHelper
    {
        
        /// <summary>
        /// 传入OpenId，AccessToken
        /// </summary>
        public UserInfoModel GetSnsUserInfo(WeChatParam param)
        {
            var result = HttpHelper.Get<UserInfoModel>(ApiList.SnsUserInfo, new HttpParam()
            {
                { "access_token", param.AccessToken }, 
                { "openid", param.OpenId }, 
                { "lang", "zh_CN" }
            });
            return result;
        }
        /// <summary>
        /// 传入OpenId，AccessToken
        /// </summary>
        public UserInfoModel GetUserInfo(WeChatParam param)
        {
            var result = HttpHelper.Get<UserInfoModel>(ApiList.GetUserInfo, new HttpParam()
            {
                { "access_token", param.AccessToken }, 
                { "openid", param.OpenId }, 
                { "lang", "zh_CN" }
            });
            return result;
        }
    }
}
