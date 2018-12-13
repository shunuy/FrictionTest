
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
    public partial class FormMainBFD : Form
    {
        FormFriction frmDebugInfo;
        public SerialPort rsport;
        private String retvaluestr = "";


  
        /// <summary>
        ///  UDP服务器工具实例化
        /// </summary>
        private static readonly ServerUtil serverUtil = new ServerUtil();
       // private static readonly WebUtil webUtil = new WebUtil("http://" + SERVER_IP + ":8080/LabManage/api", USER_NAME, PASSWORD);


        public FormMainBFD()
        {
            InitializeComponent();
     
            statusTextDistance.Font = new System.Drawing.Font("LcdD", 32F);
            lblConfigDistance.Font = new System.Drawing.Font("LcdD", 24F);
            statusTestSiralNo.Font = new System.Drawing.Font("LcdD", 10.5F);
            lblTargetTemp.Font = new System.Drawing.Font("LcdD", 10.5F);
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
            byte[] ReCMD = new byte[Count];  //存放接收到的数据
            rsport.Read(ReCMD, 0, Count);

            if (ReCMD[0] == 61)
                retvaluestr = "";

            for (int k = 0; k < Count; k++)
                retvaluestr = retvaluestr + ((char)ReCMD[k]).ToString();

            if (ReCMD[0] != 61)
            {
                String right = retvaluestr.Substring(1);
                Int64 y = Convert.ToInt64(right);
                GlobalData.MainTemperature = y;
            }  
        }


        private void DataReceive(object sender, EventArgs e)
        {
            DataReceivedEventArgs ea = (DataReceivedEventArgs)e;
            byte[] byteCmd = ea.BytePackageContent;

            serverUtil.SendSuccessPackage();
            ///TODO 根据不同的报文指令处理
            //if (byteCmd[0] == (byte)0x1)
            //{
            //    MessageBox.Show("收到上升指令！");
            //}
            //else
            //{
            //    MessageBox.Show("收到其他指令！");
            //}
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            serverUtil.DataReceived += new EventHandler(DataReceive);

            ReadConfigure();
            Global_TestTypeChanged(null, null);
            GlobalCofigData.SystemConfig.TestTypeChanged += new TestTypeChangedEventHandler(Global_TestTypeChanged); 
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            if (frmDebugInfo == null) frmDebugInfo = new FormFriction();
            frmDebugInfo.Show(this.dockPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;


            GlobalData.frmStatus = new FormStatus();
            GlobalCofigData.SystemConfig.AutoOffFireDelayTime = 15;
            //zhj delete /V1.08  tmrAutoStopFire.Interval = GlobalCofigData.SystemConfig.AutoOffFireDelayTime * 100;
            GlobalData.frmStatus.WriteLogImmediately(Properties.Resources.LogStartUp);

            GlobalData.SystemStatusChanged += new SystemStatusChangedEventHandler(GlobalData_SystemStatusChanged);
            GlobalData.ConstantTempModeChanged += new ConstantTemperatureStatusChangedEventHandler(GlobalData_ConstantTemperatureStatusChanged);
            GlobalData.SystemStatus = SystemStatuses.SystemReady;//激活SystemStatusChanged事件
            //GlobalData.SystemStatus = SystemStatuses.NotConnected;


            rsport = new SerialPort();
            rsport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(rsport_DataReceived);
            rsport.BaudRate = 19200;
            rsport.DataBits = 8;
            rsport.StopBits = StopBits.One;
            rsport.PortName = "COM6";
            rsport.Parity = System.IO.Ports.Parity.None;
            rsport.ReadTimeout = 1000;
            rsport.RtsEnable = false;
            rsport.DtrEnable = false;
            try
            {
                //rsport.Open();
            }
            catch (Exception aa)
            {
                MessageBox.Show(aa.Message);
            }




            GlobalData.serialPort = new SerialPortControl();
            GlobalData.serialPort.Init_SerialPort();
            GlobalData.serialPort.TxdCommand(SerialPortControl.爆发点_向上发送设置参数);
            tmrDisplay.Enabled = true;

            GlobalCofigData.SystemConfig.PassWord = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", "");
            if (GlobalCofigData.SystemConfig.PassWord == null) GlobalCofigData.SystemConfig.PassWord = "";

            int aWidth = Screen.PrimaryScreen.Bounds.Width;
            int aHeight = Screen.PrimaryScreen.Bounds.Height;
         this.Size = new System.Drawing.Size(aWidth, aHeight);
        }


        private void SetClearEnable(bool isEnable)
        {
     
            menuPrepare.Enabled=isEnable;
       
        }


        private void SetRiseFallButton(bool isEnable)
        {
            btnRise.Enabled = isEnable;
            btnFall.Enabled = isEnable;
            btnDispStop.Enabled = isEnable;
        }

        private void Global_TestTypeChanged(object sender, EventArgs e)
        {
            if (GlobalCofigData.SystemConfig.TestType == TestTypes.正式试验)
            {
                    
            }
            else
            {
            }
        }


        bool startEnableStatus = false;
        private void SetStartEnable()
        {

            bool aa=(SerialPortControl.Dio_in_Data0 & 0x01) == 1;
            btnNewStartTest.Enabled=aa&&startEnableStatus;
           
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

                        startEnableStatus = false;
                        menuNewStartTest.Enabled = false;

                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                        SetClearEnable(false);
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

                         startEnableStatus = true;
                         menuNewStartTest.Enabled = true;

                         btnPrepare.Enabled = true;
                         menuPrepare.Enabled = true;

                         SetClearEnable(true);
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

                        startEnableStatus = false;
                        menuNewStartTest.Enabled = false;


                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                        SetClearEnable(false);
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

                        startEnableStatus = false;
                        menuNewStartTest.Enabled = false;

                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                      
                        btnRise.Enabled = false;
                        btnFall.Enabled = false;
                        btnDispStop.Enabled = true;


                  
                        menuPrepare.Enabled = false;
            
                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog("预加载");
                        break;
         
                    case SystemStatuses.Preparing:

                        menuStopTest.Enabled = true;
                        tBtnStopTest.Enabled = true;

                        //startEnableStatus = true;
                        menuNewStartTest.Enabled = true;

                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                        SetRiseFallButton(false);
                
                        menuPrepare.Enabled = false;
        
            

                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog("预加载");
                        break;
                    case SystemStatuses.WaitingReturnStatus:
  
                        break;
                }
        }


        private void GlobalData_ConstantTemperatureStatusChanged(object sender, EventArgs e)
        {
            switch (GlobalData.ConstantTempMode)
            {
                case ConstantTempModes.ORIGIN:
                    this.pictureBox1.BackgroundImage = global::FrictionTester.Properties.Resources.off;
                    break;
                case ConstantTempModes.ORIGIN_HEAT:
                    this.pictureBox1.BackgroundImage = global::FrictionTester.Properties.Resources.fire;
                    break;
                case ConstantTempModes.ON :
                    this.pictureBox1.BackgroundImage = global::FrictionTester.Properties.Resources.success;
                    break;
                case ConstantTempModes.OFF:
                    this.pictureBox1.BackgroundImage = global::FrictionTester.Properties.Resources.off;
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
                DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["药量"]=30;
            }
          


                GlobalData.SmokeSensorMax = 0;
                GlobalData.TemperatureMax = 0;
                GlobalData.TemperatureOrigin = GlobalData.Temperature;
                GlobalData.SmokeSensorOrigin = GlobalData.SmokeSensor;
                GlobalData.timeStartTest = DateTime.Now;
                frmDebugInfo.StartTest();
                GlobalData.serialPort.TxdCommand(0xFD);
                tmrAutoStopFire.Enabled = true;//忘记停止试验，1分钟后自动关闭点火丝
                GlobalData.SystemStatus = SystemStatuses.BeTesting;
           
        }

        private void tBtnStopTest_Click(object sender, EventArgs e)
        {

           // GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Stop_Fire);
            tmrAutoStopFire.Enabled = false;
            GlobalData.serialPort.TxdCommand(0xF7);

            DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = GlobalData.TimerCount.ToString("f1");
            GlobalData.DataRowIndex++;
            GlobalCofigData.SystemConfig.SerialNo++;
            frmDebugInfo.StopTest();
            GlobalData.SystemStatus = SystemStatuses.SystemReady;
          
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

        }


        bool isShowError = false;
        int timercout = 0;


//        int ADC_firstDone = 0;
// void ADC_Data_filter()
//{
//    int i;
//    int  ADC_Data_select;
//    int max_ADC_data, min_ADC_data;
//    count++;
//     if(count>10)
//         {
//                        count=0;
//                        if (ADC_firstDone == 0)
//                        {
//                                        ADC_Data_array[0] = ADC_Data_array[1];
//                                        ADC_Data_array[1] = ADC_Data_array[2];
//                                        ADC_Data_array[2] = ADC_Data_array[3];
//                                        ADC_Data_array[3] = ADC_Data_array[4];
//                                        ADC_Data_array[4] = ADC_Data_array[5];
//                                        ADC_Data_array[5] = ADC_Data_array[6];
//                                        ADC_Data_array[6] = ADC_Data_array[7];
//                                        ADC_Data_array[7] = ADC_Data_array[8];
//                                        ADC_Data_array[8] = ADC_Data_array[9];
//                                        ADC_Data_array[9] = ADC_ConvertedValue;
			
//                        }
//                        else
//                        {
//                            ADC_Data_array[0] = ADC_ConvertedValue;
//                            ADC_Data_array[1] = ADC_ConvertedValue;
//                            ADC_Data_array[2] = ADC_ConvertedValue;
//                            ADC_Data_array[3] = ADC_ConvertedValue;
//                            ADC_Data_array[4] = ADC_ConvertedValue;
//                            ADC_Data_array[5] = ADC_ConvertedValue;
//                            ADC_Data_array[6] = ADC_ConvertedValue;
//                            ADC_Data_array[7] = ADC_ConvertedValue;
//                            ADC_Data_array[8] = ADC_ConvertedValue;
//                            ADC_Data_array[9] = ADC_ConvertedValue;
//                            ADC_firstDone = 0;
//                        }

//                        //去掉最大和最小的数后做平均值
//                        max_ADC_data = ADC_Data_array[0];
//                        min_ADC_data = ADC_Data_array[0];
//                        for (i=1;i<10;i++)
//                        {
//                            if (ADC_Data_array[i] > max_ADC_data)
//                            {
//                                max_ADC_data = ADC_Data_array[i];
//                            }
//                            if (ADC_Data_array[i] < min_ADC_data)
//                            {
//                                min_ADC_data = ADC_Data_array[i];
//                            }
//                        }
//                        ADC_Data_select = 0;
//                        for (i=0;i<10;i++)
//                        {
//                            ADC_Data_select = ADC_Data_select + ADC_Data_array[i];
//                        }
//                        ADC_Data_select = ADC_Data_select - max_ADC_data - min_ADC_data;
//                        ADC_Data_select = ADC_Data_select / 8;

//                        temperature=12.3;
				
//                    {
//                         temperature= ADC_Data_select;
//                         temperature=(temperature)*500*3.2/4096/2.9;
					
//                    }
//                         T_Real=(int)(temperature*10);
//        }
//}



        private void tmrDisplay_Tick(object sender, EventArgs e)
        {
            //V1.12cs add
            if ((SerialPortControl.Dio_in_Data0 & 0x08) == 0) lblDetect.Text="开";
            else  lblDetect.Text="关";
          

            SetStartEnable();//根据下位机的状态，确定是否可以开始
            if (GlobalData.ConstantTempMode == ConstantTempModes.ORIGIN_HEAT)
            {
                timercout++;
                if (timercout > 3)
                {
                    timercout = 0;
                    if (pictureBox1.Visible) pictureBox1.Visible = false;
                    else pictureBox1.Visible = true;
                }
            }
             //GlobalData.FireDistance = GlobalCofigData.SystemConfig.MaxFireDistance - GlobalData.Displacement;
            //rsport.Close();
            //rsport.Open();
            if (this.WindowState == FormWindowState.Normal) this.WindowState =FormWindowState.Maximized;
            if(rsport.IsOpen) SendCommand(); 
            statusTextDistance.Text = GlobalData.MainTemperature.ToString("F1");
            statusTestPhase.Text = GlobalCofigData.SystemConfig.TestType.ToString();

            lblTargetTemp.Text = GlobalData.targetTemperature.ToString("f1");

            lblConfigDistance.Text = GlobalData.TimerCount.ToString("f1");
           // lblTargetTemp.Text = GlobalData.Displacement.ToString("f1");
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

        
 
         }

        private void menuManualDetect_Click(object sender, EventArgs e)
        {
            FormControl frm = new FormControl();
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
            frmConfigure.ShowDialog();
            
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
            if (btnPrepare.Text == "加热")
            {
                btnPrepare.Text = "停止";
                GlobalData.serialPort.TxdCommand(0xFB);
            }
            else
            {
                btnPrepare.Text = "加热";
                GlobalData.serialPort.TxdCommand(0xFC);
            }
        
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xF8);
            GlobalData.SystemStatus = SystemStatuses.BeManualTest;
        }

        private void btnRise_Click(object sender, EventArgs e)
        {
       

            GlobalData.serialPort.TxdCommand(0xF7);

            GlobalData.SystemStatus = SystemStatuses.BeManualTest;
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

            GlobalData.serialPort.TxdCommand(0xFA);
            GlobalData.SystemStatus = SystemStatuses.SystemReady;
           
        }

        float oldTimercount = 0;
        private void tmrAutoStopFire_Tick(object sender, EventArgs e)
        {

            if (GlobalData.TimerCount > 1.0)
            {
                if(Math.Abs(oldTimercount-GlobalData.TimerCount)<0.1)
                {
                    tmrAutoStopFire.Enabled = false;
                    tBtnStopTest_Click(null, null);//zhj add V1.08CS

                }

                oldTimercount = GlobalData.TimerCount;
            }

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

    }



    class WindowsDll
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(StringBuilder lpClassName, StringBuilder lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //[DllImport("shell32.dll")]
        //public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetDiskFreeSpace(string lpRootPathName, ref long lpSectorsPerCluster, ref long lpBytesPerSector, ref long lpNumberOfFreeClusters, ref long lpTotalNumberOfClusters);
        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);
    }
}