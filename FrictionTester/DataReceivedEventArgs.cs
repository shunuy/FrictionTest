using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FrictionTester
{
    /// <summary>
    /// 报文数据接收事件参数
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {

        public byte[] BytePackageContent;


        /// <summary>
        /// 初始化报文数据接收事件参数
        /// </summary>
        /// <param name="packageContent">报文内容部分，去掉了头尾、长度、校验字段</param>
        /// <param name="remote">报文来源EndPoint</param>
        public DataReceivedEventArgs(byte[] packageContent)
        {
            this.BytePackageContent = packageContent;
        }
    }
}
