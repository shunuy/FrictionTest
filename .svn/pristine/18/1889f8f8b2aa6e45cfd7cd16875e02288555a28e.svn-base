using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;

namespace FrictionTester
{

    public class SerialPortControl
    {

        public static byte Command_Beep_On = 0xF5;
        public static byte Command_Beep_Off =  0xF6;

        public static byte Command_Rise = 0xF7;// 0xF5;
        public static byte Command_Fall = 0xF8;//  0xF6;

        public const byte  Command_Disp_Clear = 0xF9;// 0xF0;
        public const byte  Command_Disp_Stop = 0xFA;// 


        public const byte Command_Fire = 0xFB;// 0xF7;
        public const byte Command_Stop_Fire = 0xFC;// 0x

        public const byte  Command_Auto_Mode = 0xB0;// 0xF7;
        public const byte  Command_Debug_Mode = 0xB1;// 0xF7;

        public const byte SET_Disp_Speed = 0xE1;

        public const byte 爆发点_向上发送设置参数 = 0xE3;
        public const byte 爆发点_向下设置参数 = 0xE5;


        public SerialPort SralPrt;
        public int temprErrCount;

        public float temperature;
        /// <summary>准备关闭串口=true</summary>
        private bool m_IsTryToClosePort = false;

        /// <summary>true表示正在接收数据</summary>
        private bool m_IsReceiving = false;

        public int Tp_NoConnectCount = 0;

        public bool Tp_ConnectState = false;


        public byte ControlStatus = 0;
        public Queue<byte> ReceivedByte;

        public static byte Dio_in_Data0 = 1;
        public static byte Dio_in_Data1 = 0;

        public SerialPortControl()
        {
            temprErrCount = 0;
         
            //SerialConfigSection serialconfigure = GlobalCofigData.SerialConfig; ;
            SralPrt = new SerialPort();//(serialconfigure.PortName, serialconfigure.Braudrate, (System.IO.Ports.Parity)serialconfigure.Parity, 7, (System.IO.Ports.StopBits)serialconfigure.StopBit);
            ReceivedByte = new Queue<byte>();
            SralPrt.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(SralPrt_DataReceived);
        }

        //初始化串口
        public bool Init_SerialPort()
        {
            SerialConfigSection SC = GlobalCofigData.SerialConfig;
            ColseSerialPort();
            try
            {
                m_IsTryToClosePort = false;
                Tp_ConnectState = true;
                SralPrt.BaudRate = 9600;// SC.Braudrate;
                SralPrt.DataBits = 8;// SC.DataBites;
                SralPrt.StopBits = StopBits.One; //(System.IO.Ports.StopBits)SC.StopBit;
                SralPrt.PortName = SC.PortName;
                SralPrt.Parity = System.IO.Ports.Parity.None;
                SralPrt.ReadTimeout = 1000;
                SralPrt.RtsEnable = true;
                SralPrt.DtrEnable = true;
                if (GlobalCofigData.SystemConfig.ControlType == ControlTypes.RS232) SralPrt.Open();
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("打开端口错误");
                Tp_ConnectState = false;
                return false;

            }
        }


        public void ColseSerialPort()
        {
            try
            {
                m_IsTryToClosePort = true;
                while (m_IsReceiving)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                if (SralPrt.IsOpen)
                    SralPrt.Close();

                Tp_ConnectState = false;
            }
            catch (Exception e)
            {
                ;
                //MessageBox.Show(e.Message.ToString());
            }

        }

        public void TxdCommand(Byte command)
        {
            if (GlobalCofigData.SystemConfig.ControlType == ControlTypes.RS232) TxdCommand(command, 0);

        }

        const int ReadLen = 8;

        void SralPrt_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {

                if (m_IsTryToClosePort) // 关键！！！
                {
                    return;
                }

                m_IsReceiving = true; // 关键!!!  

                byte[] str = new byte[150];

                int Count = SralPrt.BytesToRead;
                int point = 0;
                int pckPoi;

                while (Count - point > ReadLen - 1)
                {
                    SralPrt.Read(str, 0, 1);
                    if (ReceivedByte.Count < 1000) ReceivedByte.Enqueue(str[0]);
                    point++;
                    //
                    if (str[0] == 0xAA)
                    {
                        SralPrt.Read(str, 1, ReadLen - 1);

                        if (ReceivedByte.Count < 1000)
                        {
                            for (int i = 1; i < ReadLen; i++) ReceivedByte.Enqueue(str[i]);
                        }

                        point = point + ReadLen;


                        if (str[ReadLen - 1] == 0x55)
                        {
                            
                            UInt16 gaoWei = (UInt16)(str[1] * 256);
                            UInt16 deWei = str[2];
                            float aa = (UInt16)(gaoWei + deWei);
                            GlobalData.MainTemperature = aa / 10f;// * GlobalCofigData.SystemConfig.DisplacementCoefficient;
                          
                            
                            gaoWei = (UInt16)(str[3] * 256);
                            deWei = str[4];
                            aa=(UInt16)(gaoWei + deWei);
                            GlobalData.TimerCount = aa/1000;


                            Dio_in_Data0 = str[5];

                            GlobalData.ConstantTempMode = (ConstantTempModes)str[6];
                            
                        }
                        else if (str[ReadLen - 1] == 0x5A)
                        {
                            UInt16 gaoWei = (UInt16)(str[1] * 256);
                            UInt16 deWei = str[2];
                            float aa = (UInt16)(gaoWei + deWei);
                            GlobalData.targetTemperature  = aa / 10f;// * GlobalCofigData.SystemConfig.DisplacementCoefficient;


                            gaoWei = (UInt16)(str[3] * 256);
                            deWei = str[4];
                            GlobalData.heatSpeed = (UInt16)(gaoWei + deWei);
                          

                            gaoWei = (UInt16)(str[5] * 256);
                            deWei = str[6];
                            GlobalData.verSion = (UInt16)(gaoWei + deWei);
                           
                        


                        }
                        else if (str[ReadLen - 1] == 0xA5)
                        {
                            UInt16 gaoWei = (UInt16)(str[1] * 256);
                            UInt16 deWei = str[2];
                            float aa = (UInt16)(gaoWei + deWei);
                            GlobalData.tempDiff = aa / 10f;// * GlobalCofigData.SystemConfig.DisplacementCoefficient;


                         




                        }


                    }
                }
                Tp_NoConnectCount = 0;
            }
            catch
            {
                
            }
            finally // 放在finally里面比较好。
            {
                m_IsReceiving = false; // 关键!!!
            }
        }

        bool ReSend = false;
        bool beOK = false;

        public void TxdCommand(byte command, Int16 sendData)
        {
            byte[] aa = new byte[12];
            byte dataFiste = (byte)(sendData >> 8);
            byte dataLast = (byte)(sendData & 0xFF);


            ReSend = false;
            beOK = false;

            aa[0] = 0x55;
            aa[1] = command;
            aa[2] = dataFiste;
            aa[3] = dataLast;
            aa[4] = 0xaa;

            try
            {
               if(GlobalCofigData.SystemConfig.ControlType ==ControlTypes.RS232)  SralPrt.Write(aa, 0, 5);
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show("写端口错误");
 
            }
        }

    }
}
