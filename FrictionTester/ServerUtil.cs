using System;
using System.Collections.Generic;
//using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;



namespace FrictionTester
{
    public class ServerUtil
    {
        private static readonly string SERVER_IP = "123.56.22.126";
        //private static readonly string SERVER_IP = "192.168.156.1";
        private static readonly int SERVER_PORT = 9090;
        private static readonly int EQUIP_ID = 2;
        private static readonly string USER_NAME = "admin";
        private static readonly string PASSWORD = "11111111";

    
        public string ServerIp;
    
        public int ServerPort;

        public int EquipId;
  
        public EventHandler DataReceived;

        private bool isConnected = false;

        private Socket serverSocket;
        private Thread listenThread;


        byte[] buffer = new byte[64];

        public ServerUtil()
        {
            this.EquipId = EQUIP_ID;
            this.ServerIp = SERVER_IP;
            this.ServerPort = SERVER_PORT;
            isConnected = ConnectServer();
            listenThread = new Thread(new ThreadStart(ListenThread));
            listenThread.Start();
        }

        private bool ConnectServer()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Connect(IPAddress.Parse(ServerIp), ServerPort);
                serverSocket.Send(PackageUtil.buildPackage(IntToBytes(EquipId)));
                
                int len = serverSocket.Receive(buffer);

                byte[] dataReceived = new byte[len];
                Array.Copy(buffer, dataReceived, len);
                byte[] pkgContent = PackageUtil.ParsePackage(dataReceived);
                if (pkgContent[0] == (byte)0x80)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private byte[] IntToBytes(int value)
        {
            byte[] src = new byte[2];
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }
        private void ListenThread()
        {
            while (isConnected)
            {
                int lenReceive = serverSocket.Receive(buffer);
                byte[] dataReceived = new byte[lenReceive];
                Array.Copy(buffer, dataReceived, lenReceive);
                try
                {
                    byte[] pkgContent = PackageUtil.ParsePackage(dataReceived);
                    if (this.DataReceived != null)
                    {
                        DataReceived(this, new DataReceivedEventArgs(pkgContent));
                    }
                }
                catch (ArgumentException e)
                {
                    ///TODO 记录日志
                    byte[] bytesErrorPackage = PackageUtil.GetResponsePackage((byte)0x81);
                    serverSocket.Send(bytesErrorPackage);
                }
            }
        }

        public void SendPackage(byte[] bytesPackageContent)
        {
            byte[] bytesPackage = PackageUtil.buildPackage(bytesPackageContent);
            serverSocket.Send(bytesPackage);
        }

        public void SendResponsePackage(byte responseCode)
        {
            SendPackage(new byte[] { responseCode });
        }

        public void SendSuccessPackage()
        {
            SendResponsePackage(0x80);
        }
    }
}
