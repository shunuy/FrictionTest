
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
    public partial class FormMainGDGD : Form
    {
        FormFriction frmDebugInfo;
  
        private String retvaluestr = "";

        public FormMainGDGD()
        {
            InitializeComponent();
      
            lblPress.Font = new System.Drawing.Font("LcdD", 32F);
            lblConfigDistance.Font = new System.Drawing.Font("LcdD", 24F);
            statusTestSiralNo.Font = new System.Drawing.Font("LcdD", 10.5F);
            lblCapacity.Font = new System.Drawing.Font("LcdD", 10.5F);
            lblStep.Font = new System.Drawing.Font("LcdD", 10.5F);

           
        }

     

      

        ClassControl6024 control6024;
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


  
            tmrDisplay.Enabled = true;

            GlobalCofigData.SystemConfig.PassWord = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", "");
            if (GlobalCofigData.SystemConfig.PassWord == null) GlobalCofigData.SystemConfig.PassWord = "";

            int aWidth = Screen.PrimaryScreen.Bounds.Width;
            int aHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Size = new System.Drawing.Size(aWidth, aHeight);

            control6024 = new ClassControl6024();
            control6024.Connect();
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

                        btnRise.Enabled = false;
                        btnDrop.Enabled = false;
                        btnZero.Enabled = false;
                        btnReset.Enabled = false;
                        btnVotageZero.Enabled = false;

                 

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

                         btnNewStartTest.Enabled = true;
                         menuNewStartTest.Enabled = true;

                         btnPrepare.Enabled = true;
                         menuPrepare.Enabled = true;


                         btnRise.Enabled = true;
                         btnDrop.Enabled = true;
                         btnZero.Enabled = true;
                         btnReset.Enabled = true;
                         btnVotageZero.Enabled = true;



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


                        btnRise.Enabled = false;
                        btnDrop.Enabled = false;
                        btnZero.Enabled = false;
                        btnReset.Enabled = false;
                        btnVotageZero.Enabled = false;

                   

                        menuStopTest.Text = Properties.Resources.LogEndTest;
                        tBtnStopTest.ToolTipText = Properties.Resources.LogEndTest;

                        statusTextSystem.Text = GlobalCofigData.SystemConfig.TestType.ToString();

                        statusTextSystem.ForeColor = Color.Black;
                        GlobalData.frmStatus.WriteLog(Properties.Resources.LogStartTest);
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
           

           // adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff);
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
                control6024.StartESD();
                tmrAutoStopFire.Enabled = true;//
                GlobalData.SystemStatus = SystemStatuses.BeTesting;
            }
        }

        private void tBtnStopTest_Click(object sender, EventArgs e)
        {
            control6024.StopESD();
   
            float oldoldTarget = 0;
            tmrAutoStopFire.Enabled = false;
            StopReason dlg = new StopReason();
            dlg.Owner = this;
            dlg.ShowDialog();

            if (dlg.selectindex == 0)
            {

                if (GlobalCofigData.SystemConfig.TestType == TestTypes.正式试验)
                {
                    GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance - GlobalCofigData.SystemConfig.Step;//V1.19
                }
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


                if (GlobalCofigData.SystemConfig.TestType == TestTypes.正式试验)
                {

                    GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance + GlobalCofigData.SystemConfig.Step;//V1.19
                }
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
                GlobalCofigData.SystemConfig.SerialNo++;
            }

            if (dlg.selectindex == 2)
            {
               DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "废样";
            }


            if (dlg.selectindex == 3)
            {
                if (GlobalCofigData.SystemConfig.TestType == TestTypes.预备试验)
                {
                    //DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验结果"] = "预置实验结束";
                    System.Windows.Forms.MessageBox.Show("预置测试已经结束！", "操作提示");
                    GlobalCofigData.SystemConfig.TestType = TestTypes.正式试验;
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


           //暂时不考虑自动设置电压 if (dlg.selectindex < 2) menuPrepare_Click(null, null);
        }


        bool isShowError = false;
        private void tmrDisplay_Tick(object sender, EventArgs e)
        {
        
            if (GlobalCofigData.SystemConfig is SystemConfigSection)
            {
                lblPowerPolar.Text = ( GlobalCofigData.SystemConfig).PowerPolar;

                lblResister.Text = ( GlobalCofigData.SystemConfig).Resister;
                lblCapacity.Text = ( GlobalCofigData.SystemConfig).Capacity;
            }
       

            if (this.WindowState == FormWindowState.Normal) this.WindowState =FormWindowState.Maximized;
            int press=control6024.ReadPessData() ;
            float bbe = (float)press / 100f;
          
            lblVotageFeedback.Text = bbe.ToString("F2");
            float disp = control6024.ReadDispData();
            disp = disp / 100f;
            int pressConrol = control6024.ReadPressControlData();

            int aa = control6024.ReadDispSetData();
            lblDisplaySet.Text = aa.ToString();

            label14.Text = control6024.Read_MF68().ToString();

            //if (i_iStatus== 0)
            //{
            //    lblPress.Text = GlobalData.FireDistance.ToString("F2");
            //}
            //else if (i_iStatus == 1)
            //    lblPress.Text = "Over(H)";
            //else if (i_iStatus == 2)
            //    lblPress.Text = "Over(L)";
            //else
            //  
            float bb = (float)pressConrol/100f;
            lblPress.Text = GlobalCofigData.SystemConfig.TargetDistance.ToString("F1");
            //lblPress.Text =press.ToString();

            lblDisp.Text = disp.ToString();

            statusTestPhase.Text = GlobalCofigData.SystemConfig.TestType.ToString();
   
            lblConfigDistance.Text = GlobalCofigData.SystemConfig.TargetDistance.ToString("F1");
            //lblDisplace.Text = GlobalData.Displacement.ToString("f1");
            statusTestSiralNo.Text = GlobalCofigData.SystemConfig.SerialNo.ToString();
            lblStep.Text = GlobalCofigData.SystemConfig.Step.ToString("f1");
            lblVotageSet.Text = pressConrol.ToString();

    　  
         
         }

        private void menuManualDetect_Click(object sender, EventArgs e)
        {
            JDGD.FormControl fr = new  JDGD.FormControl();
            fr.ShowDialog();
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
            btnVotageZero_Click(null, null);
        }

        private void menuPrepare_Click(object sender, EventArgs e)
        {

            if (GlobalCofigData.SystemConfig.TestType == TestTypes.预备试验)
            {
                if (GlobalCofigData.SystemConfig.SerialNo == 1)
                    GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.PrepareH0;
            }
            else
            {
                if (GlobalCofigData.SystemConfig.SerialNo == 1)
                    GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.H0;
            }
            control6024.SetData(GlobalCofigData.SystemConfig.TargetDistance);

            control6024.SetDispData(GlobalCofigData.SystemConfig.DistanceAdjust);
     
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
      
        }

        private void btnRise_Click(object sender, EventArgs e)
        {

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
        
           
           
        }


        private void tmrAutoStopFire_Tick(object sender, EventArgs e)
        {
            tmrAutoStopFire.Enabled = false;
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            control6024.Zero();
        }

        private void btnRise_Click_1(object sender, EventArgs e)
        {
            control6024.Rise();
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            control6024.Drop();
        }

        private void FormMainGDGD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D && e.Control)
            {
               
                if (lblVotageSet.Visible==false)
                {
                    panel1.Height = 132;
                    lblVotageSet.Visible = true;
                }
                else
                {
                    panel1.Height = 102;
                    lblVotageSet.Visible = false;
                }


            } 

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            control6024.Reset();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {


        }

    

        private void FormMainGDGD_KeyPress(object sender, KeyPressEventArgs e)
        {
   
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnVotageZero_Click(object sender, EventArgs e)
        {
    
            control6024.SetData(0);
            GlobalCofigData.SystemConfig.H0 = 5;
            GlobalCofigData.SystemConfig.PrepareH0 = 5;
           //V1.20 为了安全操作点了置0，后续试验无法继续 GlobalCofigData.SystemConfig.TargetDistance = 0;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalData.SystemStatus = SystemStatuses.SystemReady; 

        }



    }



   
}