#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：MenuHelper
* Copyright(c) 青之软件
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
using Newtonsoft.Json;

namespace Dos.WeChat
{
    public class MenuHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public string CreateUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QueryUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeleteUrl { get; set; }

        /// <summary>
        /// 获取默认的MenuHelper。
        /// 此实例设置了默认Url并（在传递null时）读取缓存的access_token
        /// </summary>
        /// <returns></returns>
        public static MenuHelper Create(string accessToken = null)
        {
            var result = new MenuHelper
            {
                CreateUrl = ApiList.MenuCreateUrl,
                QueryUrl = ApiList.MenuGetUrl,
                DeleteUrl = ApiList.MenuDeleteUrl
            };
            return result;
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        public WeChatResult CreateMenu(Menu menu, WeChatParam param)
        {
            var r = HttpHelper.Post<WeChatResult>(CreateUrl, menu.ToString(), "access_token=" + Token.GetAccessToken(param));
            return r;
        }

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        public Menu Get(WeChatParam param)
        {
            var oo = new { menu = new Menu() };
            var json = HttpHelper.Get(QueryUrl, new HttpParam() { { "access_token", Token.GetAccessToken(param) } });
            var or = JsonConvert.DeserializeAnonymousType(json, oo);
            var result = or.menu;
            if (result == null)
            {
                var retTemp = JsonConvert.DeserializeObject<WeChatResult>(json);
                throw new MenuException(retTemp.ErrCode, retTemp.ErrMsg);
            }
            return result;
        }

        /// <summary>
        /// 取消当前使用的自定义菜单
        /// </summary>
        public WeChatResult Delete(WeChatParam param)
        {
            var result = HttpHelper.Get<WeChatResult>(DeleteUrl, new HttpParam() { { "access_token", Token.GetAccessToken(param) } });
            return result;
        }
    }

    /// <summary>
    /// 菜单结构
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "button")]
        public List<MenuItem> Items { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static Menu FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Menu>(json);
        }
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// 用户点击click类型按钮后，微信服务器会通过消息接口(event类型)推送点击事件给开发者，并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值进行消息回复
        /// </summary>
        public const string Click = "click";
        /// <summary>
        /// 用户点击view类型按钮后，会直接跳转到开发者指定的url中
        /// </summary>
        public const string View = "view";
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 类型。从常量中获取
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// view button 的url地址
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "sub_button")]
        public List<MenuItem> Items { get; set; }
    }
}