using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace FrictionTester
{
    public partial class RemoteControl : Form
    {
        private Socket m_clientSocket;
        private byte[] m_receiveBuffer = new byte[1024];

        public RemoteControl()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void RemoteControl_Load(object sender, EventArgs e)
        {
                txtIP.Text = "192.168.0.6";
                txtPort.Text = "8899";
        }


            /// <summary>
            /// 连接服务器
            /// </summary>
         private void btnConnect_Click(object sender, EventArgs e)
            {
                string serverIP = txtIP.Text;
                int serverPort = Int32.Parse(txtPort.Text);

                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

                try
                {
                    m_clientSocket.Connect(remoteEndPoint);
                    if (m_clientSocket.Connected)
                    {
                        m_clientSocket.BeginReceive(m_receiveBuffer, 0, m_receiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);

                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;

                        this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Client connect server success.");
                    }
                }
                catch (Exception)
                {
                    this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Client connect server fail.");
                    m_clientSocket = null;
                }
            }

            /// <summary>
            /// 断开连接
            /// </summary>
            private void btnDisconnect_Click(object sender, EventArgs e)
            {
                if (m_clientSocket != null)
                {
                    m_clientSocket.Close();

                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    btnSend.Enabled = false;

                    this.AddRunningInfo(">> " + DateTime.Now.ToString() + " Client disconnected.");
                }
            }

            /// <summary>
            /// 发送信息
            /// </summary>
            private void btnSend_Click(object sender, EventArgs e)
            {
                string strSendData = txtSend.Text;
                byte[] sendBuffer = new byte[1024];
                sendBuffer = Encoding.Unicode.GetBytes(strSendData);

                if (m_clientSocket != null)
                {
                    m_clientSocket.Send(sendBuffer);
                }
            }

            private void ReceiveCallBack(IAsyncResult ar)
            {
                try
                {
                    int REnd = m_clientSocket.EndReceive(ar);
                    string strReceiveData = Encoding.Unicode.GetString(m_receiveBuffer, 0, REnd);
                    this.HandleMessage(strReceiveData);
                    m_clientSocket.BeginReceive(m_receiveBuffer, 0, m_receiveBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
                }
                catch (Exception err)
                {
                    //throw new Exception(ex.Message);
                    ;
                }
            }

            /// <summary>
            /// 处理接收到的数据
            /// </summary>
            private void HandleMessage(string message)
            {
                message = message.Replace("/0", "");
                if (!string.IsNullOrEmpty(message))
                {
                    this.AddRunningInfo(">> Receive Data from server:" + message);
                }
            }

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

            private void txtSend_TextChanged(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(txtSend.Text) && m_clientSocket != null)
                {
                    btnSend.Enabled = true;
                }
                else
                {
                    btnSend.Enabled = false;
                }
            }


        private void btnsetup_Click(object sender, EventArgs e)
        {
            txtSend.Text = "setup";
            btnSend_Click(sender, e);
        }

        private void btnbeepstop_Click(object sender, EventArgs e)
        {
            txtSend.Text = "beepstop";
            btnSend_Click(sender, e);
        }

        private void btnbeep_Click(object sender, EventArgs e)
        {
            txtSend.Text = "beep";
            btnSend_Click(sender, e);
        }

        private void btnfireoff_Click(object sender, EventArgs e)
        {
            txtSend.Text = "fireoff";
            btnSend_Click(sender, e);
        }

        private void btnfire_Click(object sender, EventArgs e)
        {
            txtSend.Text = "fire";
            btnSend_Click(sender, e);
        }

        private void SetManeMode_Click(object sender, EventArgs e)
        {
            txtSend.Text = "SetManMode";
            btnSend_Click(sender, e);
        }

        private void SetAutoMode_Click(object sender, EventArgs e)
        {
            txtSend.Text = "SetAutoMode";
            btnSend_Click(sender, e);
        }

        private void btnraise_Click(object sender, EventArgs e)
        {
            txtSend.Text = "raise";
            btnSend_Click(sender, e);
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            txtSend.Text = "down";
            btnSend_Click(sender, e);
        }

        private void btnoff_Click(object sender, EventArgs e)
        {
            txtSend.Text = "stop";
            btnSend_Click(sender, e);
        }

        private void lstRunningInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
}