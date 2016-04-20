using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Dos.WeChat
{
    /// <summary>
    /// 菜单结构
    /// </summary>
    public class MenuResult : WeChatResult
    {
        /// <summary>
        /// 菜单按钮数组
        /// </summary>
        [JsonProperty(PropertyName = "button")]
        public List<Item> Button { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Item
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
        /// view Button 的url地址
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "sub_button")]
        public List<Item> SubButton { get; set; }

        /// <summary>
        /// 用于bootstrap-treeview。不需要可以删除。
        /// </summary>
        public string text
        {
            get { return Name; }
        }
        /// <summary>
        /// 用于bootstrap-treeview。不需要可以删除。
        /// </summary>
        public List<Item> nodes
        {
            get { return SubButton; }
        }
    }
}
