using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dos.WeChat.Common
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class OutputAttribute : Attribute
    {
    }
    /// <summary>
    /// 微信平台接受的消息类型名称
    /// </summary>
    public class MsgTypeAttribute : Attribute
    {
        public string TypeName { get; set; }

        #region 静态方法

        /// <summary>
        /// 获取指定消息类型的微信平台接受名称
        /// </summary>
        /// <param name="mtype"></param>
        /// <returns></returns>
        public static string ObtainMessageType(MsgTypeAttribute mtype)
        {
            return mtype.TypeName;
        }

        /// <summary>
        /// 获取消息枚举对应的微信平台接受的消息名称
        /// </summary>
        public static string ObtainMessageType(EnumHelper.MsgType type)
        {
            var mi = type.GetType().GetMember(Enum.GetName(type.GetType(), type)).FirstOrDefault();
            MsgTypeAttribute attr = null;
            if (mi != null)
            {
                attr =
                    mi.GetCustomAttributes(typeof(MsgTypeAttribute), true).FirstOrDefault() as MsgTypeAttribute;
            }
            return attr == null ? null : ObtainMessageType(attr);
        }

        #endregion
    }
}
