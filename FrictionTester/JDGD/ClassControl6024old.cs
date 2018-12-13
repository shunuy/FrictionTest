using System;
using System.Collections.Generic;
using System.Text;
using Advantech.Adam;
using System.Net.Sockets;
using System.Windows.Forms;


namespace FrictionTester
{

   
   public  class ClassControl6024old
    {
        private AdamSocket adamModbus;
        private Adam6000Type m_Adam6000Type;

        public ClassControl6024old()
        {
            adamModbus = new AdamSocket();
            bool isOpened=adamModbus.Connect(AdamType.Adam6000, "10.0.0.1", ProtocolType.Tcp);

            if (isOpened == false)
            {
                GlobalData.SystemStatus = SystemStatuses.NotConnected;
              
            }
        }

        public void StartESD()
        {
            
              adamModbus.Modbus().ForceSingleCoil(17, 1);
        }

        public void StopESD()
        {

            adamModbus.Modbus().ForceSingleCoil(17, 0);
        }

       public int ReadData()
       {
          
           int[] iData;
			float[] fValue = new float[6];
			int[] iStatus = new int[6];
            if (adamModbus.Connected)
            {
                if (adamModbus.Modbus().ReadInputRegs(1, 6, out iData) &&
                     adamModbus.Modbus().ReadInputRegs(21, 6, out iStatus))
                {

                    GlobalData.FireDistance = iData[3]-32768;
                    GlobalData.FireDistance = 30 * GlobalData.FireDistance / 16384;
                    GlobalData.FireDistance = 3 * GlobalData.FireDistance;//（实际10kv时显示为30kv)
                }
            }
           
           if(iStatus ==null  ) return 4;
           else    return iStatus[3];
       }

       public void SetData(float voltage)
       {
           if (adamModbus.Connected)
           {

               if (voltage > 30) voltage = 30;
               voltage = voltage / 3.0f;//当设置为30kV时，实际设置为10kV

               voltage = voltage / 30f;
               voltage = voltage * 2048;
               int iValue = (int)voltage;


               if (iValue > 2048)
                   iValue = 2048;
               if (adamModbus.Modbus().PresetSingleReg(12, iValue))
               {
                   System.Threading.Thread.Sleep(500);

               }
           }
       }


        public void Connect()
        {
          

        }

        

        public void Rise()
        {

          
        }

        public void Reset()
        {

         
        }

        public void Zero()
        {

          
        }

        public void Drop()
        {

           
        }





        public int ReadPessData()
        {
          
            return 0;
        }
        public int ReadDispData()
        {

            return dispData;
        }
        private int dispSetData;
        public int ReadDispSetData()
        {

            return dispSetData;
        }

        public int ReadPressControlData()
        {

            return pressControl;
        }

      

        public void SetDispData(float disp)
        {

            int press = (int)disp;
            if (press > 5000) press = 5000;
            byte[] data = new byte[2];
            data[0] = (byte)(press / 256);
            data[1] = (byte)(press % 256);
            if (data[0] > 117) data[0] = 117;
         
        }

        private int testData;
        private int dispData;
        private int pressControl;
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

                    break;
                case 2:
                    message = "Read discrete inputs";
                    data = values;

                    break;
                case 3:
                    message = "Read holding register";
                    data = values;
                    if (data.Length > 1)//间隙设定值
                    {
                        dispSetData = data[0] * 256 + data[1];
                    }
                    if (data.Length > 3)//间隙值
                    {
                        dispData = data[2] * 256 + data[3];
                    }
                    if (data.Length > 5)//电压控制值
                    {
                        pressControl = data[4] * 256 + data[5];
                    }

                    if (data.Length > 7)//电压反馈值
                    {
                        testData = data[6] * 256 + data[7];
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
