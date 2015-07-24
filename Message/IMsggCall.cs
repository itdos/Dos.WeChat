#region << 版 本 注 释 >>
/****************************************************
* 文 件 名：IMessageHandler
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
namespace Dos.WeChat
{
    /// <summary>
    /// 微信消息接口
    /// </summary>
    public interface IMsgCall
    {
        /// <summary>
        /// 收到文本消息时回调
        /// </summary>
        ResponseMsg TextMsgCall(RecTextMsg msg);
        /// <summary>
        /// 收到语音消息时回调
        /// </summary>
        ResponseMsg VoiceMsgCall(RecVoiceMsg msg);
        /// <summary>
        /// 收到图片消息时回调
        /// </summary>
        ResponseMsg ImageMsgCall(RecImgMsg msg);
        /// <summary>
        /// 收到链接消息时回调
        /// </summary>
        ResponseMsg LinkMsgCall(RecLinkMsg msg);
        /// <summary>
        /// 收到地理位置消息时回调
        /// </summary>
        ResponseMsg LocationMsgCall(RecLocationMsg msg);
        /// <summary>
        /// 事件回调
        /// </summary>
        ResponseMsg EventMsgCall(RecEventMsg msg);
        /// <summary>
        /// 消息回调执行后
        /// </summary>
        void AfterMsgCall(ReceiveMsg msg, ResponseMsg repMsg);
    }
}