using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FrictionTester
{
    public partial class NetServerStart : Form
    {
        private Thread m_serverThread;
        private Socket m_serverSocket;
        private string m_serverIP;
        private int m_serverPort;
        public delegate void ReceiveMessageDelegate(Client client);
        ReceiveMessageDelegate receiveMessageDelegate;

        public NetServerStart()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void NetServerStart_Load(object sender, EventArgs e)
        {
            string[] addresses = GetLocalAddresses();
            cmbIP.Items.Clear();
            if (addresses.Length > 0)
            {
                for (int i = 0; i < addresses.Length; i++)
                {
                    cmbIP.Items.Add(addresses[i]);
                }
                cmbIP.Text = (string)cmbIP.Items[0];
            }
            cmbIP.Items.Add("192.168.0.6");
            cmbIP.SelectedIndex = 0;
            txtPort.Text = "8899";
        }

        
        private void btnStart_Click(object sender, EventArgs e)
        {
            m_serverIP = cmbIP.Text;
            m_serverPort = Int32.Parse(txtPort.Text);

            Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        /// <summary>
        /// 开始服务
        /// </summary>
        private void Start()
        {
            try
            {
                m_serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(m_serverIP), m_serverPort);
                m_serverSocket.Bind(localEndPoint);
                m_serverSocket.Listen(1);  //这里可以设置连接的客户数

                m_serverThread = new Thread(new ThreadStart(ReceiveAccept));
                m_serverThread.Start();

                this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Server started.");
            }
            catch (SocketException se)
            {
                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        private void Stop()
        {
            try
            {
                m_serverThread.Abort(); // 线程终止
                m_serverSocket.Close(); // Socket Close

                this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Server stoped.");
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void ReceiveAccept()
        {
            while (true)
            {
                Client client = new Client();

                try
                {
                    client.ClientSocket = m_serverSocket.Accept();
                    this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Client[" + client.ClientSocket.RemoteEndPoint.ToString() + "] connected.");

                    receiveMessageDelegate = new ReceiveMessageDelegate(ReceiveMessages);
                    receiveMessageDelegate.BeginInvoke(client, ReceiveMessagesCallback, "");
                }
                catch (Exception ex)
                {
                    ;
                }
            }
        }

        private void ReceiveMessages(Client client)
        {
            while (true)
            {
                byte[] receiveBuffer = new byte[1024];

                client.ClientSocket.Receive(receiveBuffer);

                string strReceiveData = Encoding.Unicode.GetString(receiveBuffer);
                if (!string.IsNullOrEmpty(strReceiveData))
                {
                    this.AddRunningInfo(">> Receive data from [" + client.ClientSocket.RemoteEndPoint.ToString()+ "]:" + strReceiveData);
                    string strSendData = "OK. The content is:" + strReceiveData;
                    int sendBufferSize = Encoding.Unicode.GetByteCount(strSendData);
                    byte[] sendBuffer = new byte[sendBufferSize];
                    sendBuffer = Encoding.Unicode.GetBytes(strSendData);

                    client.ClientSocket.Send(sendBuffer);
                    processcmd(strReceiveData);
                }
            }
        }

        private void processcmd(string ClientCmd)
        {
            //if (ClientCmd.Equals("beep"))
                //System.Windows.Forms.MessageBox.Show(ClientCmd, "操作提示");
            //switch (ClientCmd)
            //{
                //case "setup":
                    //break;
                //case "beepstop":
                   // GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Beep_Off);
                    //break;
                    //System.Windows.Forms.MessageBox.Show(ClientCmd, "操作提示");
                    netstring.Text = ClientCmd;
                    if (netstring.Text == "beepstop")
                    {
                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Beep_Off);
                        return;
                    }

                    if (netstring.Text=="beep")
                    {
                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Beep_On);
                        return;
                    }
                    if (netstring.Text=="fireoff")
                    {
                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Stop_Fire);
                        return;
                    }
   
                    if (netstring.Text == "fire")
                    {

                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fire);
                        return;
                    }

                    if (netstring.Text == "raise")
                    {
                        GlobalData.serialPort.TxdCommand(0xE1, (short)GlobalCofigData.SystemConfig.RiseUpSpeed);
                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Rise);
                        return;
                    }
  
                    if (netstring.Text == "down")
                    {
                        GlobalData.serialPort.TxdCommand(0xE1, (short)GlobalCofigData.SystemConfig.RiseUpSpeed);
                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fall);
                        return;
                    }
  
                    if (netstring.Text == "stop")
                    {
                        GlobalData.DispCotrol.Stop();
                        return;
                    }

        }

        private void ReceiveMessagesCallback(IAsyncResult AR)
        {
            receiveMessageDelegate.EndInvoke(AR);
        }

        /// <summary>
        /// 将运行信息加入显示列表
        /// </summary>
        private void AddRunningInfo(string message)
        {
            lstRunningInfo.BeginUpdate();
            lstRunningInfo.Items.Insert(0, message);

            if (lstRunningInfo.Items.Count > 100)
            {
                lstRunningInfo.Items.RemoveAt(100);
            }

            lstRunningInfo.EndUpdate();
        }

        /// <summary>
        /// 获取本机地址列表
        /// </summary>
        public string[] GetLocalAddresses()
        {
            // 获取主机名
            string strHostName = Dns.GetHostName();

            // 根据主机名进行查找
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

            string[] retval = new string[iphostentry.AddressList.Length];

            int i = 0;
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                retval[i] = ipaddress.ToString();
                i++;
            }
            return retval;
        }

        private void lstRunningInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

    public class Client
    {
        Socket m_clientSocket;

        public Client() { }

        public Socket ClientSocket
        {
            get { return m_clientSocket; }
            set { this.m_clientSocket = value; }
        }
    }


}