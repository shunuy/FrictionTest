using System;
using System.Collections.Generic;
using System.Text;
using Advantech.Adam;
using System.Net.Sockets;
using System.Windows.Forms;


namespace FrictionTester
{

   
   public  class ClassControlold
    {
        private AdamSocket adamModbus;
        private Adam6000Type m_Adam6000Type;

        public ClassControlold()
        {
            adamModbus = new AdamSocket();
            bool isOpened=adamModbus.Connect(AdamType.Adam6000, "10.0.0.1", ProtocolType.Tcp);
            if(isOpened==false) GlobalData.SystemStatus = SystemStatuses.NotConnected;
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


       // ~ClassControl6024()
       //{

       //    adamModbus.Disconnect();
       //}
    }
}
