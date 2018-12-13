using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace FrictionTester
{
    class ClassControlDisp
    {
        public ClassControlDisp()
        {
       
            Speed = 50;
        }
       
    
        public float Speed;
        public bool isGetTarget = false;
        private bool isRun = false;
        private long count = 0;
        public void Run()
        {
            if (isRun)
            {
                count++;
                float newSpeed = 20;


                if (count % 4 == 0) //解决经过一个地方没停，而产生的问题
                {
                    if (GlobalCofigData.SystemConfig.TargetDistance > GlobalData.FireDistance)
                    {

                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fall);
                    }
                    else
                    {

                        GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Rise);
                    }
                }

                //解决开始时已经在确定的高度
                //if (count < 5 && Math.Abs(GlobalData.FireDistance - Target) < 0.5)
                //{
                   // GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Disp_Stop);
                //}
                //GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Disp_Stop);

           
                    if (Math.Abs(GlobalData.FireDistance - GlobalCofigData.SystemConfig.TargetDistance) < 0.3f)
                    {
                        isGetTarget = true;
                        GlobalData.DispCotrol.Stop();
                        return;
                    }
               


                if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD)//为焰感度是丝杆，所以本身很慢
                {
                    if (Math.Abs(GlobalData.FireDistance - GlobalCofigData.SystemConfig.TargetDistance) < 1) newSpeed = GlobalCofigData.SystemConfig.PrepareSpeed;
                    else if (Math.Abs(GlobalData.FireDistance - GlobalCofigData.SystemConfig.TargetDistance) < 2) newSpeed = GlobalCofigData.SystemConfig.PrepareSpeed/2;
                    else if (Math.Abs(GlobalData.FireDistance - GlobalCofigData.SystemConfig.TargetDistance) < 3) newSpeed = GlobalCofigData.SystemConfig.PrepareSpeed/4;
                    else if (Math.Abs(GlobalData.FireDistance - GlobalCofigData.SystemConfig.TargetDistance) < 7) newSpeed = GlobalCofigData.SystemConfig.PrepareSpeed/10;
                    else
                    {
                      if (count < 20) newSpeed = (float)GlobalCofigData.SystemConfig.RiseUpSpeed/10f;
                      else if (count < 40) newSpeed =(float) GlobalCofigData.SystemConfig.RiseUpSpeed/20f;
                      else if (count < 60) newSpeed =(float)GlobalCofigData.SystemConfig.RiseUpSpeed/50f;
                      else newSpeed = (float)GlobalCofigData.SystemConfig.RiseUpSpeed/100f;
                    }
                }
       

                if (newSpeed != Speed)
                {
                    Speed = newSpeed;
                    //火焰感度不调速度
                    //if(SDAF.DataOperateLib.DataOperate.isHYGD==false) 
                    GlobalData.serialPort.TxdCommand(SerialPortControl.SET_Disp_Speed, (short)(Speed*20));
                    
                }
            }
        }

        public void Start()
        {

            isRun = true;
            count = 0;

            GlobalData.serialPort.TxdCommand(SerialPortControl.SET_Disp_Speed, 200);

            if (Math.Abs(GlobalData.FireDistance - GlobalCofigData.SystemConfig.TargetDistance) > 0.3f)
            {
                if (GlobalCofigData.SystemConfig.TargetDistance > GlobalData.FireDistance)
                {
                    
                    GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fall); 
                }
                else
                {

                    GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Rise);
                }
            }
        }


        public void Stop()
        {
            isRun = false;
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Disp_Stop);
        }
    }

}
