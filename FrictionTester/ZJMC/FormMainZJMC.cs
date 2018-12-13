
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
    

    public partial class FormMainZJMC : Form
    {
        public const byte COMM_OPEN_1 = 0;
        public const byte COMM_CLOSE_1 = 1;
        public const byte COMM_OPEN_2 = 2;
        public const byte COMM_CLOSE_2 = 3;
        public const byte COMM_OPEN_3 = 4;
        public const byte COMM_CLOSE_3 = 5;
        public const byte COMM_OPEN_4 = 6;
        public const byte COMM_CLOSE_4 = 7;
        public const byte COMM_SEARCH = 8;

        FormFriction frmDebugInfo;
        public ClassPLCzm plcZM;
        private String retvaluestr = "";

   
        /// <summary>
        ///  UDP服务器工具实例化
        /// </summary>



        public FormMainZJMC()
        {
            InitializeComponent();
    
            statusTextDistance.Font = new System.Drawing.Font("LcdD", 32F);
         

           
        }

      

 
       

        private void FormMain_Load(object sender, EventArgs e)
        {
            //GlobalData.serverUtil.DataReceived += new EventHandler(DataReceive);


                
            ReadConfigure();
            Global_TestTypeChanged(null, null);
            GlobalCofigData.SystemConfig.TestTypeChanged += new TestTypeChangedEventHandler(Global_TestTypeChanged); 
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            if (frmDebugInfo == null) frmDebugInfo = new FormFriction();
            frmDebugInfo.Show(this.dockPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;


            GlobalData.frmStatus = new FormStatus();
            GlobalCofigData.SystemConfig.AutoOffFireDelayTime = 15;
            tmrAutoStopTest.Interval = GlobalCofigData.SystemConfig.AutoOffFireDelayTime * 1000;
            GlobalData.frmStatus.WriteLogImmediately(Properties.Resources.LogStartUp);

            GlobalData.SystemStatusChanged += new SystemStatusChangedEventHandler(GlobalData_SystemStatusChanged);
            GlobalData.SystemStatus = SystemStatuses.SystemReady;//激活SystemStatusChanged事件
            GlobalData.SystemStatus = SystemStatuses.NotConnected;







        
           tmrDisplay.Enabled = true;

            GlobalCofigData.SystemConfig.PassWord = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", "");
            if (GlobalCofigData.SystemConfig.PassWord == null) GlobalCofigData.SystemConfig.PassWord = "";

            plcZM = new ClassPLCzm();
            plcZM.Connect();
            plcZM.SetManualAutoMode(true);
        }


        private void SetClearEnable(bool isEnable)
        {
         
     
            menuDispClear.Enabled=isEnable;
       
        }


        private void SetRiseFallButton(bool isEnable)
        {
 
         
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

                         btnNewStartTest.Enabled = false;
                         menuNewStartTest.Enabled = false;

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

                        btnNewStartTest.Enabled = false;
                        menuNewStartTest.Enabled = false;


                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                        SetClearEnable(false);
                        SetRiseFallButton(false);

                        menuStopTest.Text = Properties.Resources.LogEndTest;
                        tBtnStopTest.ToolTipText = Properties.Resources.LogEndTest;

                        statusTextSystem.Text = "等待落锤释放完成";

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

                      
                 
                 
                  
                        menuDispClear.Enabled = false;
            
                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog("预加载");
                        break;
         
                    case SystemStatuses.Preparing:

                    

                        btnNewStartTest.Enabled = false;
                        menuNewStartTest.Enabled = false;

                        btnPrepare.Enabled = false;
                        menuPrepare.Enabled = false;

                     
               
                
                        menuDispClear.Enabled = false;

                        statusTextSystem.Text = "正在预提锤...";

                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog("预加载");
                        break;
                    //case SystemStatuses.WaitingReturnStatus:

                    //    btnNewStartTest.Enabled = false;
                    //    menuNewStartTest.Enabled = false;

                    //    SetRiseFallButton(false);
                      
                    //    break;
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

            plcZM.Release();

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
                GlobalData.SystemStatus = SystemStatuses.BeTesting;
            }
        }

        private void tBtnStopTest_Click(object sender, EventArgs e)
        {

   
            tmrAutoStopTest.Enabled = false;
            StopReason dlg = new StopReason();
            dlg.ShowDialog();

            if (dlg.selectindex == 0)
            {
        
                DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "发火";
             
            }

            if (dlg.selectindex == 1)
            {
           
                DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "瞎火";
         
            }

            if (dlg.selectindex == 2)
            {
               DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "废样";
            }


            if (dlg.selectindex == 3)
            {
                
                    System.Windows.Forms.MessageBox.Show("样品数据最少25个，正式实验已经结束！", "操作提示");
                
            }

          
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

        bool ater = true;
        bool isShowError = false;
        private void tmrDisplay_Tick(object sender, EventArgs e)
        {

            if (GlobalData.SystemStatus == SystemStatuses.Preparing)
            {
                if (plcZM.isInstallFinished)
                {
                    btnNewStartTest.Enabled = true;
                    statusTextSystem.Text = "预提锤完成，装药...";
                }
            }
            if (GlobalData.SystemStatus == SystemStatuses.BeTesting )
            {
                if (plcZM.isReleaseFinished)
                {
                    GlobalData.SystemStatus = SystemStatuses.SystemReady;
                    tBtnStopTest_Click(null, null);
                }
            }
#if DEBUG
#else
           
#endif

            if (ater)
            {
                plcZM.ReadData();
                ater = false;
            }
            else
            {
                plcZM.ReadStatus();
                ater = true;
            }
            //plcZM.ReadStatus();
             //GlobalData.FireDistance = GlobalCofigData.SystemConfig.MaxFireDistance - GlobalData.Displacement;
            //rsport.Close();
            //rsport.Open();
            if (this.WindowState == FormWindowState.Normal) this.WindowState =FormWindowState.Maximized;
           
            statusTextDistance.Text =plcZM.DispDispData.ToString("F1");
            lblPress.Text = plcZM.PressDispData.ToString("F2");
            lblSetDisp.Text = plcZM.DispSetData.ToString();
            lblSetPress.Text = plcZM.PressSetData.ToString();

            chkAutoMode.Checked = plcZM.isAutoMode;
            chkFrictionMode.Checked = plcZM.isFrictionMode;
            chkInstallFinished.Checked = plcZM.isInstallFinished;
            chkReleseFinished.Checked = plcZM.isReleaseFinished;


            //GlobalData.connectedCount = 0;

            //if (GlobalData.connectedCount++ > 14)
            //{
            //    if (GlobalData.connectedCount > 100) GlobalData.connectedCount = 100;
            //    if (GlobalData.SystemStatus == SystemStatuses.BeTesting)
            //    {
            //        // StopTest();
            //    }
            //    GlobalData.SystemStatus = SystemStatuses.NotConnected;

            //}
            //else if (GlobalData.connectedCount < 5)
            //{
            //    if (GlobalData.SystemStatus == SystemStatuses.NotConnected)
            //    {
            //        GlobalData.SystemStatus = SystemStatuses.SystemReady;


            //    }
            //}

   
       
         }

        private void menuManualDetect_Click(object sender, EventArgs e)
        {
            plcZM.SetManualAutoMode(false);
            ZJMC.FormZJMCCtl frm = new FrictionTester.ZJMC.FormZJMCCtl(this);
            frm.ShowDialog();
            plcZM.SetManualAutoMode(true);
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
            plcZM.SetDispData(GlobalCofigData.SystemConfig.PrepareH0);
            plcZM.SetPressData(GlobalCofigData.SystemConfig.H0);
          
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
            plcZM.Install();

            GlobalData.SystemStatus = SystemStatuses.Preparing;
            //if (GlobalCofigData.SystemConfig.TestType == TestTypes.预备试验 )
            //{
                //if (GlobalCofigData.SystemConfig.SerialNo == 1)
                 //   GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.PrepareH0;
            //}
            //else
            //{
                //if (GlobalCofigData.SystemConfig.SerialNo == 1)
                    //GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.H0;
           // }
           // GlobalCofigData.SystemConfig.TargetDistance;

            //GlobalData.DispCotrol.Target = GlobalCofigData.SystemConfig.PrepareH0;
            //btnNewStartTest.Enabled = false;
            //tBtnStopTest.Enabled = false;
            //GlobalData.DispCotrol.isEnabled = false;
            //if (!GlobalData.DispCotrol.Start())
            //    btnRise_Click(sender, e);
            //else 
            //    btnFall_Click(sender, e);
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
            GlobalData.SystemStatus = SystemStatuses.WaitingReturnStatus;
    
            int tick = Environment.TickCount;

            while (Environment.TickCount - tick < 1000)
            {

                Application.DoEvents();

            }

            
            
        
            while (Environment.TickCount - tick < 2000)
            {

                Application.DoEvents();

            }


            tmrAutoStop.Enabled = true;
            tmrAutoStop.Interval = 22000;
        
        }

        private void btnRise_Click(object sender, EventArgs e)
        {
            GlobalData.SystemStatus = SystemStatuses.WaitingReturnStatus;

       
            int tick = Environment.TickCount;

            while (Environment.TickCount - tick < 1000)
            {

                Application.DoEvents();

            }
        
            while (Environment.TickCount - tick < 2000)
            {

                Application.DoEvents();

            }
   

            tmrAutoStop.Enabled = true;
            tmrAutoStop.Interval = 16000;
         
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

      


        private void tmrAutoStopFire_Tick(object sender, EventArgs e)
        {
            tmrAutoStopTest.Enabled = false;

            tBtnStopTest_Click(null, null);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //RS485WIN mydlg = new RS485WIN();
            //mydlg.ShowDialog();
        }



        private void NetLinkStarted_Click(object sender, EventArgs e)
        {
           //plcZM.Connect();
           // //RemoteControl aa = new RemoteControl();
           // //aa.ShowDialog();
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

        private void tmrAutoStop_Tick(object sender, EventArgs e)
        {
            tmrAutoStop.Enabled = false;
            GlobalData.SystemStatus = SystemStatuses.SystemReady;
          

   
            int tick = Environment.TickCount;

            while (Environment.TickCount - tick < 1000)
            {

                Application.DoEvents();

            }

            while (Environment.TickCount - tick < 2000)
            {

                Application.DoEvents();

            }
   

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            plcZM.Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalData.SystemStatus = SystemStatuses.SystemReady;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plcZM.isInstallFinished = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plcZM.isReleaseFinished = true;
        }

        private void FormMainZJMC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Control)
            {
                //if(panel1.Height != 168) panel1.Height = 168;
                //else 
                if (label7.Visible == false)
                {
                    panel1.Height = 189;
                    label7.Visible = true;
                }
                else
                {
                    panel1.Height = 102;
                    label7.Visible = false;
                }


            } 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            plcZM.SetHitOrFrictionMode(checkBox1.Checked);
        }

    }



   
}