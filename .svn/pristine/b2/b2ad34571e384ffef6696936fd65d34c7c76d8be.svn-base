using System;
using System.Collections.Generic;
using System.Text;


namespace FrictionTester
{
    public class PackageUtil
    {
        /// <summary>
        /// 报文的标识，报文头和尾部的字节
        /// </summary>
        private static readonly byte PACKAGE_FLAG = 0xFE;

        /// <summary>
        /// 组装报文
        /// </summary>
        /// <param name="data">报文内容</param>
        /// <returns>报文字节数组</returns>
        public static byte[] buildPackage(byte[] data)
        {
            byte crc = CRC8.CRC(data);
            byte[] ret = new byte[data.Length + 5];
            ret[0] = PACKAGE_FLAG;
            ret[1] = PACKAGE_FLAG;
            ret[2] = (byte)data.Length;
            int i = 0;
            while (i < data.Length)
            {
                ret[3 + i] = data[i];
                i++;
            }
            ret[3 + i] = crc;
            ret[4 + i] = PACKAGE_FLAG;

            return ret;
        }

        /// <summary>
        /// 组装响应的报文字节数组
        /// </summary>
        /// <param name="responseCode">响应的代码：0x80表示成功，其他表示异常[异常代码以后定义]</param>
        /// <returns>响应的报文字节数组</returns>
        public static byte[] GetResponsePackage(byte responseCode)
        {
            return buildPackage(new byte[] { responseCode });
        }

        /// <summary>
        /// 解释报文
        /// </summary>
        /// <param name="pkg">报文字节数组</param>
        /// <returns>报文内容部分的字节数组</returns>
        public static byte[] ParsePackage(byte[] pkg)
        {
            if (pkg == null || pkg.Length < 6 || pkg.Length != (pkg[2] + 5) || pkg[0] != PACKAGE_FLAG || pkg[1] != PACKAGE_FLAG
                || pkg[pkg.Length - 1] != PACKAGE_FLAG)
            {
                throw new ArgumentException("非法报文!");
            }
            else
            {
                int cmdLen = pkg[2];
                byte[] ret = new byte[cmdLen];
                for (int i = 0; i < cmdLen; i++)
                {
                    ret[i] = pkg[3 + i];
                }
                return ret;
            }
        }
    }
}
