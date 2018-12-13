using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;


namespace FrictionTester
{


    public class ClassPLC
    {
        private Master MBmaster;


        public ClassPLC()
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
            MBmaster.connect("192.168.1.20",502);
            MBmaster.OnResponseData += new Master.ResponseData(MBmaster_OnResponseData);
            MBmaster.OnException += new Master.ExceptionData(MBmaster_OnException);
 

        }



        /* 

 
         * 一、开关量
         * M4  平台上升
         * M9  点火
         * M10 手动自动模式切换（1为自动模式）
         * M11  平台下降
         * M20   复位
         * 二、整形变量
         * MW10   高度值
         * MW11   高度目标值


*/

        public void StartRise()
        {
           

            MBmaster.WriteSingleCoils(5,1,4,true);
        }

       public void AutoManulMode(bool mode)
    {
        MBmaster.WriteSingleCoils(5,1,10,mode);
    }

        public void StartDrop()
        {


            MBmaster.WriteSingleCoils(5, 1, 11, true);
        }

       

        public void Reset()
        {

            MBmaster.WriteSingleCoils(5, 1, 20, true);
        }

        public void DianhuoStart()
        {

            MBmaster.WriteSingleCoils(5, 1, 9, true);
        }
        public void DianhuoStop()
        {

            MBmaster.WriteSingleCoils(5, 1, 9, false);
        }




        public int ReadPessData()
        {
           
            return testData;
        }
        public int ReadDispData()
        {
            if (GlobalData.SystemStatus != SystemStatuses.NotConnected) MBmaster.ReadHoldingRegister(3, 1, 10, 2);
            return dispData;
        }
        private int dispSetData;
        public int ReadDispSetData()
        {

            return dispSetData;
        }

  



        public void SetDispData(float disp)
        {

            int press = (int)disp;
            if (press > 5000) press = 5000;
            byte[] data = new byte[2];
            data[0] = (byte)(press / 256);
            data[1] = (byte)(press % 256);
             MBmaster.WriteSingleRegister(6, 1, 11, data);
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
                       short aa= (short)(data[0] *(short)256 + data[1]);//zhj modify 1.3
                       if (data[0] >= 0xF0)
                       {
                           aa = (short)(0xFFFF - aa);
                           aa = (short)(-1*aa);
                       }
                       dispData = aa;
                    }
                    if (data.Length > 3)//间隙值
                    {
                        dispSetData = data[2] * 256 + data[3];
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
