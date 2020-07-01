using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using WeifenLuo.WinFormsUI.Docking;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using SDAF.DataOperateLib;
using System.IO.Ports;

namespace FrictionTester
{
    public partial class FormMainHYGD : Form
    {
        FormFriction frmDebugInfo;
        public SerialPort rsport;
        private String retvaluestr = "";

   
        /// <summary>
        ///  UDP服务器工具实例化
        /// </summary>



        public FormMainHYGD()
        {
            InitializeComponent();
    
            statusTextDistance.Font = new System.Drawing.Font("LcdD", 32F);
            lblConfigDistance.Font = new System.Drawing.Font("LcdD", 24F);
            statusTestSiralNo.Font = new System.Drawing.Font("LcdD", 10.5F);
                     lblStep.Font = new System.Drawing.Font("LcdD", 10.5F);

           
        }

        public void SendCommand()
        {
            byte[] cmdmsg = new byte[4];
            cmdmsg[0] = 0x23;
            cmdmsg[1] = 0x30;
            cmdmsg[2] = 0x31;
            cmdmsg[3] = 0x0D;
            rsport.Write(cmdmsg, 0, 4);
        }

        void rsport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int Count = rsport.BytesToRead;
            byte[] ReCMD = new byte[12];  //存放接收到的数据

            if (Count > 50)
            {
                ReCMD = new byte[Count]; 
                rsport.Read(ReCMD, 0, 1);
            }

            else if (Count > 12)
            {

                rsport.Read(ReCMD, 0, 1);
                if (ReCMD[0] == 0x3D)
                {
                    rsport.Read(ReCMD, 0, 12);
                    if(ReCMD[11] == 0x0D)
                    retvaluestr = "";

                    for (int k = 0; k < 12; k++)
                        retvaluestr = retvaluestr + ((char)ReCMD[k]).ToString();

                    //  if (ReCMD[0] != 61)
                    {
                        String right = retvaluestr.Substring(1,10);
                        try
                        {
                            float y = Convert.ToSingle(right);
                            y = y / 10f;
                            GlobalData.FireDistance = y + 10 - GlobalCofigData.SystemConfig.DistanceAdjust; ; //zhj modify V1.03.01
                        }
                        catch (Exception err)
                        { }

                    }
                }
            }
        }
        
        private void DataReceive(object sender, EventArgs e)
        {
            DataReceivedEventArgs ea = (DataReceivedEventArgs)e;
            byte[] byteCmd = ea.BytePackageContent;

            GlobalData.serverUtil.SendSuccessPackage();
            ///TODO 根据不同的报文指令处理
            //if (byteCmd[0] == (byte)0x1)
            //{
            //    MessageBox.Show("收到上升指令！");
            //}
            //else
            //{
            //    MessageBox.Show("收到其他指令！");
            //}


            switch (byteCmd[0])
            {
                case 1:
                   btnNewStartTest_Click(null, null);
                    break;
                case 2:
                    btnDispStop_Click(null, null);
                    break;
                case 5:
                    btnRise_Click(null, null);
                    break;
                case 6:
                    btnFall_Click(null, null);
                    break;
               
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
           


                
            ReadConfigure();
            Global_TestTypeChanged(null, null);
            GlobalCofigData.SystemConfig.TestTypeChanged += new TestTypeChangedEventHandler(Global_TestTypeChanged); 
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            if (frmDebugInfo == null) frmDebugInfo = new FormFriction();
            frmDebugInfo.Show(this.dockPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;


            GlobalData.frmStatus = new FormStatus();
            GlobalCofigData.SystemConfig.AutoOffFireDelayTime = 15;
            tmrAutoStopFire.Interval = GlobalCofigData.SystemConfig.AutoOffFireDelayTime * 1000;
            GlobalData.frmStatus.WriteLogImmediately(Properties.Resources.LogStartUp);

            GlobalData.SystemStatusChanged += new SystemStatusChangedEventHandler(GlobalData_SystemStatusChanged);
            GlobalData.SystemStatus = SystemStatuses.SystemReady;//激活SystemStatusChanged事件
            GlobalData.SystemStatus = SystemStatuses.NotConnected;


            rsport = new SerialPort();
            rsport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(rsport_DataReceived);
            rsport.BaudRate = 19200;
            rsport.DataBits = 8;
            rsport.StopBits = StopBits.One;
            rsport.PortName = "COM1";
            rsport.Parity = System.IO.Ports.Parity.None;
            rsport.ReadTimeout = 1000;
            rsport.RtsEnable = false;
            rsport.DtrEnable = false;
            try
            {
                 
              
		    	if(GlobalCofigData.SystemConfig.ControlType==ControlTypes.RS232) 	rsport.Open();
            }
            catch (Exception aa)
            {
                MessageBox.Show(aa.Message);
            }




            GlobalData.serialPort = new SerialPortControl();
            GlobalData.serialPort.Init_SerialPort();
            tmrDisplay.Enabled = true;

            GlobalCofigData.SystemConfig.PassWord = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", "");
            if (GlobalCofigData.SystemConfig.PassWord == null) GlobalCofigData.SystemConfig.PassWord = "";

         //   int aWidth = Screen.PrimaryScreen.Bounds.Width;
         //   int aHeight = Screen.PrimaryScreen.Bounds.Height;
         //this.Size = new System.Drawing.Size(aWidth, aHeight);

//zhj modify V1.03 更改了位置
           // GlobalData.serverUtil = new ServerUtil();
           // GlobalData.serverUtil.DataReceived += new EventHandler(DataReceive);

            if (GlobalCofigData.SystemConfig.ControlType==ControlTypes.PLC)
            {
                plc = new ClassPLC();
                plc.Connect();
            }
        }

        private ClassPLC plc;



        private void SetRiseFallButton(bool isEnable)
        {
            btnRise.Enabled = isEnable;
            btnFall.Enabled = isEnable;
            btnDispStop.Enabled = isEnable;
        }

        private void Global_TestTypeChanged(object sender, EventArgs e)
        {
            if (GlobalCofigData.SystemConfig.TestType == TestTypes.撞击感度)
            {
                    
            }
            else
            {
            }
        }


        /// <summary>
        ///  要据系统状态改变用户界面状态  响应系统状态变化时产生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalData_SystemStatusChanged(object sender, EventArgs e)
        {
            if (GlobalData.SystemStatus == SystemStatuses.NotConnected)
            {
              
                menuManualDetect.Enabled = false;
                btnManualTest.Enabled = false;

            }
            else
            {
                menuManualDetect.Enabled = true;
                btnManualTest.Enabled = true;
            }
           switch (GlobalData.SystemStatus)
                {
                    case SystemStatuses.NotConnected:

                        menuStopTest.Enabled = false;
                        tBtnStopTest.Enabled = false;

                        btnNewStartTest.Enabled = false;
                        menuNewStartTest.Enabled = false;

                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

           
                        SetRiseFallButton(false);

                        statusTextSystem.Text = Properties.Resources.LogUnconnected;
                        statusTextSystem.ForeColor = Color.Red;
                        GlobalData.frmStatus.WriteLog(Properties.Resources.LogUnconnected);
                        try
                        {
                            //for (int i = 0; i < 5; i++)  if (frmErrorList[i] != null && frmErrorList[i].IsDisposed == false) frmErrorList[i].Close();
                            GlobalData.ErrorShown = 0;
                        }
                        catch (Exception err)
                        {
                            if (GlobalData.BeDebug) MessageBox.Show(err.ToString(), Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
          
                    case  SystemStatuses.SystemReady:
                         menuStopTest.Enabled = false;
                         tBtnStopTest.Enabled = false;

                         btnNewStartTest.Enabled = false;
                         menuNewStartTest.Enabled = false;

                         btnPrepare.Enabled = true;
                         menuPrepare.Enabled = true;

                  
                         SetRiseFallButton(true);

                         menuStopTest.Text = Properties.Resources.LogEndTest;
                         tBtnStopTest.ToolTipText = Properties.Resources.LogEndTest;
                         statusTextSystem.Text = Properties.Resources.LogSystemReady;
                         statusTextSystem.ForeColor = Color.Black;
                         GlobalData.frmStatus.WriteLog(Properties.Resources.LogSystemReady);
                         break;
                    case SystemStatuses.BeTesting:
         

                        menuStopTest.Enabled = true;
                        tBtnStopTest.Enabled = true;

                        btnNewStartTest.Enabled = false;
                        menuNewStartTest.Enabled = false;


                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

               
                        SetRiseFallButton(false);

                        menuStopTest.Text = Properties.Resources.LogEndTest;
                        tBtnStopTest.ToolTipText = Properties.Resources.LogEndTest;

                        statusTextSystem.Text = GlobalCofigData.SystemConfig.TestType.ToString();

                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog(Properties.Resources.LogStartTest);
                        break;
                    case SystemStatuses.BeManualTest:

                        menuStopTest.Enabled = false;
                        tBtnStopTest.Enabled = false;

                        btnNewStartTest.Enabled = false;
                        menuNewStartTest.Enabled = false;

                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                      
                        btnRise.Enabled = false;
                        btnFall.Enabled = false;
                        btnDispStop.Enabled = true;


                
                  
                        menuDispClear.Enabled = false;
                        statusTextSystem.Text = "命令控制上升下降中";
                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog("预加载");
                        break;
         
                    case SystemStatuses.Preparing:

                        menuStopTest.Enabled = true;
                        tBtnStopTest.Enabled = true;

               
                        menuNewStartTest.Enabled = false;

                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                        SetRiseFallButton(false);
                
                
                        menuDispClear.Enabled = false;


                        statusTextSystem.Text = "试样正自动调整到目标高度";
                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog("预加载");
                        break;
                    case SystemStatuses.WaitingReturnStatus:
  
                        break;
                }
        }



        private byte[] HexStringToByte(string hexString)
        {
            hexString = hexString.Replace(",", "");
            int len=hexString.Length / 2;
            byte[] returnBytes = new byte[len];
            for (int i = 0; i < len; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        private void ReadConfigure()
        {
            try
            {
                ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = Application.StartupPath + @"\Preferences.config";
                GlobalCofigData.Config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
                
                if (GlobalCofigData.Config.Sections["SystemConfig"] == null)
                {
                    SystemConfigSection customSection = new SystemConfigSection();
                    GlobalCofigData.Config.Sections.Add("SystemConfig", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    GlobalCofigData.Config.Save(ConfigurationSaveMode.Full);
                }
                GlobalCofigData.SystemConfig = GlobalCofigData.Config.Sections["SystemConfig"] as SystemConfigSection;

                if (GlobalCofigData.Config.Sections["SerialConfig"] == null)
                {
                    SerialConfigSection customSection = new SerialConfigSection();
                    GlobalCofigData.Config.Sections.Add("SerialConfig", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    GlobalCofigData.Config.Save(ConfigurationSaveMode.Full);
                }
                GlobalCofigData.SerialConfig = GlobalCofigData.Config.Sections["SerialConfig"] as SerialConfigSection;




                GlobalCofigData.MicroControllorPreferences = HexStringToByte(GlobalCofigData.SystemConfig.MicroControllorPreferences);
                GlobalCofigData.SystemConfig.PassWord = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", "");
                if (GlobalCofigData.SystemConfig.PassWord == null) GlobalCofigData.SystemConfig.PassWord = "";

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
           
            if (MessageBox.Show("是否退出本系统?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
            else
            {

                if (GlobalData.DataRowIndex > 0 && MessageBox.Show("是否保存测试数据?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
                {
                    try
                    {
                        DataOperate.UpdateTestData();
                     }
                    catch (Exception err)
                    {
                        GlobalData.frmStatus.WriteLog("是否保存测试数据? " + err.Message, false);
                    }
                 }

                 tmrDisplay.Enabled = false;
                 GlobalData.serialPort.ColseSerialPort();
                }
        }


        private void menuOpenDatabase_Click(object sender, EventArgs e)
        {

            if (GlobalData.DataRowIndex > 0)
            {
                try
                {
                    DataOperate.UpdateTestData();
                    NewTestData();
                    GlobalData.DataRowIndex = 0;
                }
                catch (Exception err)
                {
                    GlobalData.frmStatus.WriteLog("menuOpenDatabase_Click: " + err.Message, false);

                }
            }
            
            
            // ShellExecute(this.Handle, new StringBuilder("Open"), new StringBuilder("SDAFDataBase.exe"), new StringBuilder(""), new StringBuilder(Application.StartupPath), 1);
            try
            {
                GlobalData.frmStatus.WriteLog(Properties.Resources.LogOpenDataBase);
                Process[] p = System.Diagnostics.Process.GetProcessesByName("SDAF.DataBase");
                if (p.Length == 0 && File.Exists(Application.StartupPath + @"\SDAF.DataBase.exe"))
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\SDAF.DataBase.exe");
                else if (p.Length > 0)
                {
                    StringBuilder Str = new StringBuilder(Properties.Resources.DataBaseName);
                    IntPtr hWnd = WindowsDll.FindWindow(null, Str);
                    if (hWnd != null)
                    {
                        WindowsDll.SendMessage(hWnd, 0x500, 0, 0);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnNewStartTest_Click(object sender, EventArgs e)
        {

            //FormRemoteControl frmRemoteControl = new FormRemoteControl();
            //if (frmRemoteControl.ShowDialog() == DialogResult.Cancel)
            //{
            //    return;
            //}

           frmDebugInfo.C1_Update();
           if (DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["药量"] is DBNull || DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["药量"].ToString() == "")
            {
                DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["药量"] = 30;
            }
            {
                GlobalData.SmokeSensorMax = 0;
                GlobalData.TemperatureMax = 0;
                GlobalData.TemperatureOrigin = GlobalData.Temperature;
                GlobalData.SmokeSensorOrigin = GlobalData.SmokeSensor;
                GlobalData.timeStartTest = DateTime.Now;
                frmDebugInfo.StartTest();
                GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fire);//启动点火
                if (GlobalCofigData.SystemConfig.ControlType == ControlTypes.PLC) plc.DianhuoStart();
                tmrAutoStopFire.Enabled = true;//忘记停止试验，1分钟后自动关闭点火丝
                GlobalData.SystemStatus = SystemStatuses.BeTesting;
            }
        }

        private void tBtnStopTest_Click(object sender, EventArgs e)
        {
            if (GlobalData.SystemStatus == SystemStatuses.Preparing)
            {
                btnDispStop_Click(null, null);
                return;
            }

            float oldoldTarget = 0;
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Stop_Fire);
            if(GlobalCofigData.SystemConfig.ControlType==ControlTypes.PLC) plc.DianhuoStop();
            tmrAutoStopFire.Enabled = false;
            StopReason dlg = new StopReason();
            dlg.ShowDialog();

            if (dlg.selectindex == 0)
            {

                if (GlobalCofigData.SystemConfig.TestType == TestTypes.撞击感度) GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance + GlobalCofigData.SystemConfig.Step;
                else
                {
                    if (GlobalCofigData.SystemConfig.SerialNo == 1)
                    {
                        GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance * 2;
                    }
                    else
                    {
                        int aa = GlobalData.DataRowIndex - 1;
                        if (aa >= 0) oldoldTarget = (float)DataOperate.MyTable.Rows[aa][DataOperate.点火高度];
                        GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance + Math.Abs(GlobalCofigData.SystemConfig.TargetDistance - oldoldTarget) / 2;

                    }
               }


                 DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "发火";
          
                GlobalCofigData.SystemConfig.SerialNo++;////V1.03.02LY 
            }

            if (dlg.selectindex == 1)
            {


                if (GlobalCofigData.SystemConfig.TestType == TestTypes.撞击感度) GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance - GlobalCofigData.SystemConfig.Step;
                else
                {

                    if (GlobalCofigData.SystemConfig.SerialNo == 1)
                    {
                        GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance / 2;
                    }
                    else
                    {
                        int aa = GlobalData.DataRowIndex - 1;
                        if (aa >= 0) oldoldTarget = (float)DataOperate.MyTable.Rows[aa][DataOperate.点火高度];
                        GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance - Math.Abs(GlobalCofigData.SystemConfig.TargetDistance - oldoldTarget) / 2;
                        GlobalCofigData.SystemConfig.TargetDistance = (int)GlobalCofigData.SystemConfig.TargetDistance;//V1.14 只取整数，（如果精度为正负1mm,自动调节高度不能自动退出）
                    }


                }
                
                
                
                
                DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "瞎火";
                GlobalCofigData.SystemConfig.SerialNo++;//V1.14CS
            }

            if (dlg.selectindex == 2)
            {
               DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "废样";
            }


            if (dlg.selectindex == 3)
            {
                if (GlobalCofigData.SystemConfig.TestType == TestTypes.摩擦感度)
                {
                    //DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "预置实验结束";
                    System.Windows.Forms.MessageBox.Show("预置测试已经结束！", "操作提示");
                    GlobalCofigData.SystemConfig.TestType = TestTypes.撞击感度;
                    NewTestData();
                }
                else
                {
                    //DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "正式实验结束";
                    System.Windows.Forms.MessageBox.Show("样品数据最少25个，正式实验已经结束！", "操作提示");
                    GlobalCofigData.SystemConfig.SerialNo = 1;//V1.14CS
                }
            }

            if (GlobalData.SystemStatus == SystemStatuses.BeTesting)//区分预置停止还是实验停止
            {
                DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["温度变化"] = GlobalData.TemperatureMax;//2014/6/30 2、解决原  温度变化和烟雾变化 在数据列中位置错误的问题。

                DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["气体变化"] = GlobalData.SmokeSensorMax;


                //{
                //    if (DataOperate.isHYGD) DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "发火";
                //    else DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "爆炸";
                //}
                //
                //{
                //    if (DataOperate.isHYGD) 
                //        DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "瞎火";
                //    else
                //        DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "不爆";
                //}
                GlobalData.SmokeSensorMax = 0;
                GlobalData.TemperatureMax = 0;

                GlobalData.DataRowIndex++;

            }

            frmDebugInfo.StopTest();
            GlobalData.SystemStatus = SystemStatuses.SystemReady;
            GlobalData.DispCotrol.Stop();
            //GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fall);
            if (GlobalData.DataRowIndex > 10)
            {
                try
                {
                    DataOperate.UpdateTestData();
                    menuOpenDatabase_Click(null, null);
                    NewTestData();
                    GlobalData.DataRowIndex = 0;
                }
                catch (Exception err)
                {
                    GlobalData.frmStatus.WriteLog("tBtnStopTest_Click: " + err.Message, false);
                }
            }


            if (dlg.selectindex < 2) menuPrepare_Click(null, null);
        }


        bool isShowError = false;
        private void tmrDisplay_Tick(object sender, EventArgs e)
        {

             //GlobalData.FireDistance = GlobalCofigData.SystemConfig.MaxFireDistance - GlobalData.Displacement;
            //rsport.Close();
            //rsport.Open();
            if (this.WindowState == FormWindowState.Normal) this.WindowState =FormWindowState.Maximized;
            if(rsport.IsOpen) SendCommand();
           	if(GlobalCofigData.SystemConfig.ControlType==ControlTypes.PLC)  GlobalData.FireDistance = (float)plc.ReadDispData() / 10f + GlobalCofigData.SystemConfig.DistanceAdjust; ;   //zhj add V1.07 
            statusTextDistance.Text = GlobalData.FireDistance.ToString("F1");
            statusTestPhase.Text = GlobalCofigData.SystemConfig.TestType.ToString();
   
            lblConfigDistance.Text = GlobalCofigData.SystemConfig.TargetDistance.ToString("F1");
            statusTestSiralNo.Text = GlobalCofigData.SystemConfig.SerialNo.ToString();
            lblStep.Text = GlobalCofigData.SystemConfig.Step.ToString("f1");

    　  　  GlobalData.connectedCount = 0;

            if (GlobalData.connectedCount++ > 14)
            {
                if (GlobalData.connectedCount > 100) GlobalData.connectedCount = 100;
                if (GlobalData.SystemStatus == SystemStatuses.BeTesting)
                {
                    // StopTest();
                }
                GlobalData.SystemStatus = SystemStatuses.NotConnected;
              
            }
            else if(GlobalData.connectedCount<5)
            {
                if (GlobalData.SystemStatus == SystemStatuses.NotConnected)
                {
                    GlobalData.SystemStatus = SystemStatuses.SystemReady;
             
                    GlobalData.serialPort.TxdCommand(SerialPortControl.SET_Disp_Speed, 1);
                }
            }

            GlobalData.DispCotrol.Run();
            if (GlobalData.SystemStatus == SystemStatuses.Preparing)
            {
                if (isDebugMode) btnNewStartTest.Enabled = true;
                else
                {
                    btnNewStartTest.Enabled = GlobalData.DispCotrol.isGetTarget;
                }
              
            }
         }

        private void menuManualDetect_Click(object sender, EventArgs e)
        {
            FormManualTest frm = new FormManualTest();
            frm.ShowDialog();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void menuSystemSet_Click(object sender, EventArgs e)
        {
            FormConfigure frmConfigure = new FormConfigure();
            frmConfigure.Owner = this;
            frmConfigure.ShowDialog();
            tmrAutoStopFire.Interval = GlobalCofigData.SystemConfig.AutoOffFireDelayTime * 1000;
        }


        /// <summary>
        /// 重新开始一盘实验,对显示数据进行更新
        /// </summary>
        private void NewTestData()
        {
            DataRow temptRow;
            for (int i = 0; i < 20; i++)
            {
                temptRow = DataOperate.MyTable.NewRow();
                DataOperate.MyTable.Rows.Add(temptRow);
            }
            // for (int i = 0; i<10; i++)当更新到数据库没有成功时,RowState为Added状态   Delete有隔行删除的现象.  
            //{
            //     if (DataOperate.MyTable.Rows[i]["实验类型"] is DBNull) break;
            //     else DataOperate.MyTable.Rows[i].Delete();//当更新到数据库后,删除的行还在DataOperate.MyTable.Rows中,所以要用AcceptChanges()
            //}
            for (int i = DataOperate.MyTable.Rows.Count - 1; i >= 0; i--)
            {
                if (!(DataOperate.MyTable.Rows[i]["自动编号"] is DBNull)) DataOperate.MyTable.Rows[i].Delete();//当更新到数据库后,删除的行还在DataOperate.MyTable.Rows中,所以要用AcceptChanges()
            }
            int aa = DataOperate.MyTable.Rows.Count;
            //if (aa > 10) aa = 10;  //AcceptChanges()后 Deleted rows才真正从DataOperate.MyTable.Rows中删除.
            for (int i = 0; i < aa; i++)
            {
                //没有条件句的话 DataOperate.MyTable.Rows[0] rowstate为unchanged 后续会变为modified 更新时会报"违反并发性"错误
                if (DataOperate.MyTable.Rows[0].RowState == DataRowState.Deleted) DataOperate.MyTable.Rows[0].AcceptChanges();
            }
            //SetReOrNewStart(true);
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // rsport.Close();
            this.Close();
        }

        private void menuDispClear_Click(object sender, EventArgs e)
        {
           
        }

        private void menuPrepare_Click(object sender, EventArgs e)
        {

            if (GlobalCofigData.SystemConfig.TestType == TestTypes.摩擦感度)
            {
                if (GlobalCofigData.SystemConfig.SerialNo == 1)
                    GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.PrepareH0;
            }
            else
            {
                if (GlobalCofigData.SystemConfig.SerialNo == 1)
                    GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.H0;
            }
           

    
            btnNewStartTest.Enabled = false;
            tBtnStopTest.Enabled = false;
            GlobalData.DispCotrol.isGetTarget = false;
            GlobalData.DispCotrol.Start();
            GlobalData.SystemStatus = SystemStatuses.Preparing;
     

	if(GlobalCofigData.SystemConfig.ControlType==ControlTypes.PLC)
	{
            //zhj modify V1.21 plc.SetDispData(GlobalCofigData.SystemConfig.TargetDistance);
        plc.SetDispData(GlobalCofigData.SystemConfig.TargetDistance-GlobalCofigData.SystemConfig.DistanceAdjust);//zhj modify V1.23去除-10
            
            int tick = Environment.TickCount;

            while (Environment.TickCount - tick < 1000)
            {

                Application.DoEvents();

            }
            plc.AutoManulMode(true);
			}
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xE1, (short)GlobalCofigData.SystemConfig.RiseUpSpeed);
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fall);

           // GlobalData.DispCotrol.Target = -1000;
           // GlobalData.DispCotrol.Start();
            GlobalData.SystemStatus = SystemStatuses.BeManualTest;
	if(GlobalCofigData.SystemConfig.ControlType==ControlTypes.PLC)
	{
            plc.AutoManulMode(false);
            int tick = Environment.TickCount;

            while (Environment.TickCount - tick < 1000)
            {

                Application.DoEvents();

            }
            plc.StartDrop();
			}
        }

        private void btnRise_Click(object sender, EventArgs e)
        {

            GlobalData.serialPort.TxdCommand(0xE1, (short)GlobalCofigData.SystemConfig.RiseUpSpeed);
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Rise);

            //GlobalData.DispCotrol.Target = 1000;
            //GlobalData.DispCotrol.Start();
            GlobalData.SystemStatus = SystemStatuses.BeManualTest;
				if(GlobalCofigData.SystemConfig.ControlType==ControlTypes.PLC)
				{
            plc.AutoManulMode(false);
            int tick = Environment.TickCount;

            while (Environment.TickCount - tick < 1000)
            {

                Application.DoEvents();

            }
            plc.StartRise();
			}
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            
            //object oMissing = System.Reflection.Missing.Value;
            //Word._Application oWord;
            //Word._Document oDoc;
            //oWord = new Word.Application();
            //oWord.Visible = true;
            //object fileName = @"E:\CCCXCXX\TestDoc.doc";
            //oDoc = oWord.Documents.Open(ref fileName,
            //ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
            //ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }

        private void btnDispStop_Click(object sender, EventArgs e)
        {
          
            
           	if(GlobalCofigData.SystemConfig.ControlType==ControlTypes.PLC) plc.Reset();
            GlobalData.DispCotrol.Stop();
            GlobalData.SystemStatus = SystemStatuses.SystemReady;
           
        }


        private void tmrAutoStopFire_Tick(object sender, EventArgs e)
        {
            tmrAutoStopFire.Enabled = false;

            tBtnStopTest_Click(null, null);//V1.14CS

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //RS485WIN mydlg = new RS485WIN();
            //mydlg.ShowDialog();
        }



        private void NetLinkStarted_Click(object sender, EventArgs e)
        {
            NetServerStart dlg = new NetServerStart();
            dlg.Show();
        }

        private void RemoteTest_Click(object sender, EventArgs e)
        {
            RemoteControl dlg = new RemoteControl();
            dlg.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        bool isDebugMode = false;
        private void FormMainHYGD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Control)
            {

                if (isDebugMode)
                {
                    isDebugMode = false;
                }
                else
                {
                    isDebugMode = true;
                }


            } 
        }

    }



   
}