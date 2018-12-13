using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;


namespace FrictionTester
{
    /*
     * 一、开关量
M17      手动升锤
M18      手动降锤
M13      停止升降锤
M16      落锤运动模式（自动=1，手动=0）
M20      加压电机手动后退指令
M21      加压电机手动前进指令 
M22      加压电机停止指令
M24      系统复位
M25      摩擦工艺区分撞击工艺位（在摩擦控制界面使其值为1，撞击控制界面使其值为0）
M30      上位机重锤释放指令
M34      上位机装药指令
M38      装药完成
M46      落锤释放完成

二、整形变量
MW5      上位机落锤高度设置值(精确度：0.1mm)
MW6      上位机加压压力设置值(精确度:0.01T)
MW7      上位机重锤高度显示值（精确度：0.1mm)
MW8      上位机加压压力显示值(精确度:0.01T)*/

    public class ClassPLCzm
        {
        private Master MBmaster;


        public ClassPLCzm()
        {
          

            try
            {
                // Create new modbus master and add event functions
                MBmaster = new Master();
         
          
            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
            }


          
        }
        public void Connect()
        {
            MBmaster.connect("192.168.1.10",502);
            MBmaster.OnResponseData += new Master.ResponseData(MBmaster_OnResponseData);
            MBmaster.OnException += new Master.ExceptionData(MBmaster_OnException);

        }

        public void StartRise()
        {
           

            MBmaster.WriteSingleCoils(5,1,17,true);
        }

        public void StartFall()
        {

            MBmaster.WriteSingleCoils(5, 1, 18, true);
        }

        public void StopRiseFall()
        {

            MBmaster.WriteSingleCoils(5, 1, 13, true);
        }

        public void SetManualAutoMode(bool isAuto)
        {
            MBmaster.WriteSingleCoils(5, 1, 16, isAuto);
        }

        public void StartLoad()
        {

            MBmaster.WriteSingleCoils(5, 1, 21, true);
        }


        public void StartUnload()
        {


            MBmaster.WriteSingleCoils(5, 1, 20, true);
        }

        public void StopLoadUnload()
        {

            MBmaster.WriteSingleCoils(5, 1, 22, true);
        }

      

        public void Reset()
        {

            MBmaster.WriteSingleCoils(5, 1, 24, true);
        }

        public void SetHitOrFrictionMode(bool isFriction)
        {

            MBmaster.WriteSingleCoils(5, 1, 25, isFriction);
        }

        public void Release()
        {

            MBmaster.WriteSingleCoils(5, 1, 30, true);
        }

        public void Install()
        {

            MBmaster.WriteSingleCoils(5, 1, 34, true);
        }



        public void ReadStatus()
        {
            if (GlobalData.SystemStatus != SystemStatuses.NotConnected)
            {
                MBmaster.ReadCoils(1, 1, 13, 33);
             
            }
           
        }

        public void ReadData()
        {
            if (GlobalData.SystemStatus != SystemStatuses.NotConnected)    MBmaster.ReadHoldingRegister(3, 1, 5, 4);
          
        }
  

        public void SetPressData(float voltage)
        {

            int press =(int) (voltage * 100);
            if (press > 5000) press = 5000;
            byte[] data=new byte[2];
            data[0] =(byte) (press/256);
            data[1] = (byte)(press % 256);
            if (data[0] > 117) data[0] = 117;
            MBmaster.WriteSingleRegister(6, 1, 6, data);
        }

        public void SetDispData(float disp)
        {

            int press = (int)(disp*10);
            if (press > 5000) press = 5000;
            byte[] data = new byte[2];
            data[0] = (byte)(press / 256);
            data[1] = (byte)(press % 256);
            if (data[0] > 117) data[0] = 117;
            MBmaster.WriteSingleRegister(6, 1, 5, data);
        }

        public int DispSetData;
        public int PressSetData;
        public float DispDispData;
        public float PressDispData;

        public bool isAutoMode;
        public bool isFrictionMode;
        public bool isInstallFinished;
        public bool isReleaseFinished;

           private byte[] data;
        string message;
        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {
   

            // ------------------------------------------------------------------------
            // Identify requested data


        
            switch (ID)
            {
                case 1:
                    message = "Read coils";
                    data = values;
                    if (data.Length > 4)
                    {
                        if ((data[0] & 0x08) == 0) isAutoMode = false;
                        else isAutoMode = true;
                        if ((data[1] & 0x10) == 0) isFrictionMode = false;
                        else isFrictionMode = true;
                        if ((data[3] & 0x02) == 0) isInstallFinished = false;
                        else isInstallFinished = true;
                        if ((data[4] & 0x02) == 0) isReleaseFinished = false;
                        else isReleaseFinished = true;
                    }
     
                    break;
                case 2:
                    message = "Read discrete inputs";
                    data = values;
       
                    break;
                case 3:
                    message = "Read holding register";
                    data = values;
                       if (data.Length > 1)//
                    {
                        DispSetData = data[0] * 256 + data[1];  
                    }
                    if (data.Length > 3)//
                    {
                        PressSetData = data[2] * 256 + data[3];
                    }
                    if (data.Length > 5)//
                    {
                        DispDispData = data[4] * 256 + data[5];
                        DispDispData = DispDispData / 10f;
                    }

                    if (data.Length > 7)//
                    {
                        PressDispData = data[6] * 256 + data[7];
                        PressDispData = PressDispData / 100f;
                    }

                   
               
                    break;
                case 4:
                    message = "Read input register";
                    data = values;
           
                    break;
                case 5:
                    message = "Write single coil";
                    break;
                case 6:
                    message = "Write multiple coils";
                    break;
                case 7:
                    message = "Write single register";
                    break;
                case 8:
                    message = "Write multiple register";
                    break;
            }
        }

        private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception)
        {
            GlobalData.SystemStatus = SystemStatuses.NotConnected;
            string exc = "Modbus says error: ";
            switch (exception)
            {
                case Master.excIllegalFunction: exc += "Illegal function!"; break;
                case Master.excIllegalDataAdr: exc += "Illegal data adress!"; break;
                case Master.excIllegalDataVal: exc += "Illegal data value!"; break;
                case Master.excSlaveDeviceFailure: exc += "Slave device failure!"; break;
                case Master.excAck: exc += "Acknoledge!"; break;
                case Master.excGatePathUnavailable: exc += "Gateway path unavailbale!"; break;
                case Master.excExceptionTimeout: exc += "Slave timed out!"; break;
                case Master.excExceptionConnectionLost: exc += "Connection is lost!"; break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; break;
            }
           
            MessageBox.Show(exc, "Modbus slave exception");
        }
    }
}
