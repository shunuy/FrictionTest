using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;


namespace FrictionTester
{


    public class ClassControl6024
    {
        private Master MBmaster;
    

        public ClassControl6024()
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

        public void StartESD()
        {
           

            MBmaster.WriteSingleCoils(5,1,40,true);
        }

        public void StopESD()
        {

            MBmaster.WriteSingleCoils(5,1,40,false);
        }

        public void Rise()
        {

            MBmaster.WriteSingleCoils(5, 1, 10, true);
        }

        public void Reset()
        {

            MBmaster.WriteSingleCoils(5, 1, 30, true);
        }

        public void Zero()
        {

            MBmaster.WriteSingleCoils(5, 1, 20, true);
        }

        public void Drop()
        {

            MBmaster.WriteSingleCoils(5, 1, 7, true);
        }





        public int ReadPessData()
        {
            if (GlobalData.SystemStatus != SystemStatuses.NotConnected)    MBmaster.ReadHoldingRegister(3, 1, 1, 4);
            return testData;
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

        public void 
            SetData(float voltage)
        {

            int press =(int) (voltage * 100);
            if (press > 5000) press = 5000;
            byte[] data=new byte[2];
            data[0] =(byte) (press/256);
            data[1] = (byte)(press % 256);
            if (data[0] > 117) data[0] = 117;
            MBmaster.WriteSingleRegister(6, 1, 3, data);
        }

        public void SetDispData(float disp)
        {

            int press = (int)disp;
            if (press > 5000) press = 5000;
            byte[] data = new byte[2];
            data[0] = (byte)(press / 256);
            data[1] = (byte)(press % 256);
            if (data[0] > 117) data[0] = 117;
            MBmaster.WriteSingleRegister(6, 1, 1, data);
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
