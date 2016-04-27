#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MenuHelper
* Copyright(c) 道斯软件
* CLR 版本: 4.0.30319.17929
* 创 建 人：ITdos
* 电子邮箱：admin@itdos.com
* 创建日期：2014/10/25 11:21:51
* 文件描述：
******************************************************
* 修 改 人：
* 修改日期：
* 备注描述：
*******************************************************/
#endregion
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Dos.Common;
using Dos.WeChat.Common;
using Dos.WeChat.Model;


namespace Dos.WeChat
{
    /// <summary>
    /// 自定义菜单 
    /// </summary>
    public class MenuHelper
    {
        /// <summary>
        /// 创建菜单。传入Menu。若是开放平台，则需要传入AuthorizerAppid(授权方appid)、AuthorizerRefreshToken（授权方的刷新令牌）、ComponentVerifyTicket(微信后台推送的ticket，此ticket会定时推送)
        /// </summary>
        public static WeChatResult Save(WeChatParam param)
        {
            var token = "";
            if (param.WeChatType == EnumHelper.WeChatType.Open)
            {
                var bs = TokenHelper.GetAuthorizerAccessToken(param);
                if (!bs.IsSuccess)
                {
                    return bs;
                }
                token = bs.AuthorizerAccessToken;
            }
            else
            {
                var bs = TokenHelper.GetAccessToken();
                if (!bs.IsSuccess)
                {
                    return bs;
                }
                token = bs.AccessToken;
            }

            var r = HttpHelper.Post<WeChatResult>(new HttpParam()
            {
                Url = ApiList.MenuCreateUrl,
                PostParam =
                JSON.ToNiceJSON(param.Menu,new JSONParameters()
                {
                    SerializeNullValues = false,
                    UseEscapedUnicode = false
                }),//, new JsonSerializerSettings{NullValueHandling = ullValueHandling.Ignore}
                GetParam = "access_token=" + token
            });
            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        public class menuObj
        {
            public MenuResult menu { get; set; }
        }

        /// <summary>
        /// 查询菜单。
        /// 取公众号菜单，不需要传入参数。若是开放平台，则需要传入AuthorizerAppid(授权方appid)、AuthorizerRefreshToken（授权方的刷新令牌）、ComponentVerifyTicket(微信后台推送的ticket，此ticket会定时推送)
        /// </summary>
        /// <returns></returns>
        public static MenuResult Get(WeChatParam param = null)
        {
            //var menuObj = new { menu = new MenuResult() };
            var httpParam = new HttpParam();
            var aToken = "";
            if (param != null && param.WeChatType == EnumHelper.WeChatType.Open)
            {
                var bs = TokenHelper.GetAuthorizerAccessToken(param);
                if (!bs.IsSuccess)
                {
                    return new MenuResult()
                    {
                        IsSuccess = false,
                        ErrMsg = bs.ErrMsg
                    };
                }
                aToken = bs.AuthorizerAccessToken;
            }
            else
            {
                var bs = TokenHelper.GetAccessToken();
                if (!bs.IsSuccess)
                {
                    return new MenuResult()
                    {
                        IsSuccess = false,
                        ErrMsg = bs.ErrMsg
                    };
                }
                aToken = bs.AccessToken;
            }
            string json = HttpHelper.Get(ApiList.MenuGetUrl, new { access_token = aToken });
            //var or = JsonConvert.DeserializeAnonymousType(json, menuObj);
            var or = JSON.ToObject<menuObj>(json);//, menuObj
            var result = or.menu;
            if (result == null)
            {
                var retTemp = JSON.ToObject<MenuResult>(json);
                return retTemp;
            }
            return result;
        }

        /// <summary>
        /// 取消当前使用的自定义菜单
        /// </summary>
        public static WeChatResult Delete()
        {
            var result = HttpHelper.Get<WeChatResult>(ApiList.MenuDeleteUrl,
                new { access_token = TokenHelper.GetAccessToken() });
            return result;
        }
    }
}