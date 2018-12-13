using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using SDAF.DataOperateLib;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace SDAF.DataBase
{
     public partial class FormMain : Form
     {
          FormPreview frmPrint;
          bool passwordAccessed = false;
          bool beModifed = false;//此功能用于确定是否更新到数据库
         float[,] pTable;
           public FormMain()
          {
               InitializeComponent();
               pTable=new float[2,26];
               pTable[0,0]=0.00f;   pTable[1,0]=0.14f;
               pTable[0, 1] = 0.00f; pTable[1, 1] = 0.20f;
               pTable[0, 2] = 0.01f; pTable[1, 2] = 0.26f;
               pTable[0, 3] = 0.03f; pTable[1, 3] = 0.31f;
               pTable[0, 4] = 0.04f; pTable[1, 4] = 0.36f;
               pTable[0, 5] = 0.07f; pTable[1, 5] = 0.41f;
               pTable[0, 6] = 0.09f; pTable[1, 6] = 0.45f; 
               pTable[0, 7] = 0.12f; pTable[1, 7] = 0.49f;
               pTable[0, 8] = 0.15f; pTable[1, 8] = 0.54f;
               pTable[0, 9] = 0.18f; pTable[1, 9] = 0.58f;
               pTable[0, 10] = 0.21f; pTable[1, 10] = 0.61f;
               pTable[0, 11] = 0.24f; pTable[1, 11] = 0.65f;
               pTable[0, 12] = 0.28f; pTable[1, 12] = 0.69f;
               pTable[0, 13] = 0.31f; pTable[1, 13] = 0.72f;
               pTable[0, 14] = 0.35f; pTable[1, 14] = 0.76f;
               pTable[0, 15] = 0.39f; pTable[1, 15] = 0.79f;
               pTable[0, 16] = 0.44f; pTable[1, 16] = 0.82f;
               pTable[0, 17] = 0.47f; pTable[1, 17] = 0.85f;
               pTable[0, 18] = 0.51f; pTable[1, 18] = 0.88f;
               pTable[0, 19] = 0.55f; pTable[1, 19] = 0.91f;
               pTable[0, 20] = 0.59f; pTable[1, 20] = 0.93f;
               pTable[0, 21] = 0.64f; pTable[1, 21] = 0.96f;
               pTable[0, 22] = 0.69f; pTable[1, 22] = 0.98f;
               pTable[0, 23] = 0.74f; pTable[1, 23] = 0.99f;
               pTable[0, 24] = 0.80f; pTable[1, 24] = 1.00f;
               pTable[0, 25] = 0.86f; pTable[1, 25] = 1.00f;

               if (DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD)
               {
                   chkTestType.Visible = false;
                   cmbTestType.Visible = false;
               }

               this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
               toolStrip1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
          }

          private void c1FlexGrid1_KeyUpEdit(object sender, C1.Win.C1FlexGrid.KeyEditEventArgs e)
          {
               if (e.Col == 1)
               {
               }
              
          }

        

          private void AutoBackUp()
          {
               TimeSpan intervalTime = DateTime.Now - GlobalCofigData.SystemConfig.LastBackUpDateTime;
               if (GlobalCofigData.SystemConfig.AutoBackup&&intervalTime.Days >= GlobalCofigData.SystemConfig.BackUpInterval)
               {
                    if (File.Exists(Application.StartupPath + @"\DataBase\SDAF" + DateTime.Now.ToString("yyyy") + ".mdb"))
                    {
                         if (!System.IO.Directory.Exists(Application.StartupPath + @"\DataBase\bak"))
                              System.IO.Directory.CreateDirectory(Application.StartupPath + @"\DataBase\bak");
                          File.Copy(Application.StartupPath + @"\DataBase\SDAF" + DateTime.Now.ToString("yyyy") + ".mdb",
                                Application.StartupPath + @"\DataBase\bak\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak", true);
                          GlobalCofigData.SystemConfig.LastBackUpDateTime = DateTime.Now;
                          GlobalCofigData.Config.Save(ConfigurationSaveMode.Full);
                    }
               }
          }
          private void FormMain_Load(object sender, EventArgs e)
          {

              this.Font = menuStrip1.Font;
              //fg.DoubleBuffer = true;
               meuDataBase();
               if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US") 帮助文档ToolStripMenuItem.Visible = false;
               #region Config System
               ExeConfigurationFileMap file = new ExeConfigurationFileMap();
                file.ExeConfigFilename = "DataBase.config";
               GlobalCofigData.Config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);
               if (GlobalCofigData.Config.Sections["PrintConfigSection"] == null)
               {
                    PrintConfigSection customSection = new PrintConfigSection();
                    GlobalCofigData.Config.Sections.Add("PrintConfigSection", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    GlobalCofigData.Config.Save(ConfigurationSaveMode.Full);
               }
               GlobalCofigData.PrintConfig = GlobalCofigData.Config.Sections["PrintConfigSection"] as PrintConfigSection;

               if (GlobalCofigData.Config.Sections["SystemConfigSection"] == null)
               {
                    SystemConfigSection customSection = new SystemConfigSection();
                    GlobalCofigData.Config.Sections.Add("SystemConfigSection", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    GlobalCofigData.Config.Save(ConfigurationSaveMode.Full);
               }
               GlobalCofigData.SystemConfig = GlobalCofigData.Config.Sections["SystemConfigSection"] as SystemConfigSection;
               GlobalCofigData.SystemConfig.PassWord = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", "");
               if (GlobalCofigData.SystemConfig.PassWord == null) GlobalCofigData.SystemConfig.PassWord = "";
               #endregion

              //印尼专用版
               try
               {
                   string pathStr = Application.StartupPath + @"\DeletedData.sdaf";
                   if (File.Exists(pathStr))
                   {
                       using (StreamReader sr = new StreamReader(pathStr))
                       {

                           for (int i = 0; i < 10; i++)
                           {
                               string autoNo = sr.ReadLine();
                               if (autoNo == null) break;
                               else
                               {
                                   string DirectoryPath = GlobalCofigData.SystemConfig.PictureSavePath + @"\" + autoNo.Substring(0, 8) + @"\" + autoNo;
                                   if (System.IO.Directory.Exists(DirectoryPath))
                                       System.IO.Directory.Delete(DirectoryPath, true);
                               }
                           }
                           sr.Close();

                       }
                       File.Delete(pathStr);
                   }
               }
               catch (Exception aa)
               {
               }

               AutoBackUp();

               splitHorizontal2.Panel2Collapsed = true;
               splitVertical.Panel1Collapsed = true;
        
               picTestDate1.Value = DateTime.Now;
               picTestDate2.Value = DateTime.Now;
               cmbResultType.SelectedIndex = 0;
               cmbTestDate.SelectedIndex = 0;
               cmbAutoNo.SelectedIndex = 0;
               cmbTestType.SelectedIndex = 0;
               DataOperate.InitDataOprate(fg);
               cmbTester.DataSource = DataOperate.dataSet11.Tables["UserTable"];
               this.cmbTester.DisplayMember = "用户名称";

               frmPrint = new FormPreview();
               DataOperate.MyTable.RowChanged+=new DataRowChangeEventHandler(MyTable_RowChanged);

               splitHorizontal2.SplitterDistance = 376;
          }

          private void MyTable_RowChanged(object sender, DataRowChangeEventArgs e)
          {
               if (beModifed&&e.Row.RowState==DataRowState.Modified)
               {
                    beModifed = false;
                    DataOperate.UpdateTestData();
               }
          }
          string oldText = "";
          private void fg_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
          {
              try
              {
                 if(fg[e.Row, e.Col]!=null)  oldText = fg[e.Row, e.Col].ToString();
              }
              catch (Exception err)
              {
               // System.NullReferenceException: 未将对象引用设置到对象的实例。
               //在 SDAF.DataBase.FormMain.fg_BeforeEdit(Object sender, RowColEventArgs e)
               //在 C1.Win.C1FlexGrid.C1FlexGridBase.OnBeforeEdit(RowColEventArgs e)
               //在 C1.Win.C1FlexGrid.C1FlexGridBase.az(Int32 A_0, Int32 A_1)
               //在 C1.Win.C1FlexGrid.y.ao(Boolean A_0)
               //在 C1.Win.C1FlexGrid.y.ah(MouseEventArgs A_0)
               //在 C1.Win.C1FlexGrid.C1FlexGridBase.OnMouseDown(MouseEventArgs e)
               //在 System.Windows.Forms.Control.WmMouseDown(Message& m, MouseButtons button, Int32 clicks)
               //在 System.Windows.Forms.Control.WndProc(Message& m)
               //在 C1.Win.C1FlexGrid.Util.BaseControls.ScrollableControl.WndProc(Message& m)
               //在 System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
               //在 System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
               //在 System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
              }
          }
          private void fg_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
          {
    
               if (fg.Cols[e.Col].Name == "变形温度" || fg.Cols[e.Col].Name == "软化温度" || fg.Cols[e.Col].Name == "半球温度" || fg.Cols[e.Col].Name == "流动温度")
               {
                    string value = (string)fg[e.Row, e.Col];
                    try
                    {    //解决当输入的数据前面有0的情况
                         fg[e.Row, e.Col] = int.Parse(value).ToString();  
                    }
                    catch (Exception  err)
                    {
                    }
               }

               string newText = fg[e.Row, e.Col].ToString();
               if (oldText != newText)
               {
                    int index = fg.Row - fg.Rows.Fixed;
                    beModifed = true;
               }
          }
       
          private void button1_Click(object sender, EventArgs e)
          {
               splitHorizontal2.Panel2Collapsed = true;
               图片信息PToolStripMenuItem.Checked = false;
               coordinateImageToolStripMenuItem.Checked = false;
          }

          private void oleDbDataAdapter1_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
          {

          }

          private void 设置SToolStripMenuItem1_Click(object sender, EventArgs e)
          {
               FormSet frmSet = new FormSet();
               frmSet.ShowDialog();
               DataOperate.UpdateConfigureData();//在此更新考虑取消某些数据
          }

          
          private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
          {
               this.Close();
          }

          private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
          {
               //if (splitHorizontal2.Panel2Collapsed == true)
               //{

               //     splitHorizontal2.Panel2Collapsed = !splitHorizontal2.Panel2Collapsed;
               //}
      
          }

          bool AccessPassWord()
          {
               FormPassword frmPassword = new FormPassword();
               frmPassword.ShowDialog();
               if (frmPassword.DialogResult == DialogResult.OK)   passwordAccessed = true;
               else     passwordAccessed = false;
               return passwordAccessed;
          }

          private void 修改MToolStripMenuItem_Click(object sender, EventArgs e)
          {
               if (passwordAccessed || AccessPassWord())
               {
                   // splitHorizontal2.Panel2Collapsed = false;
                    btnUpdateModified.Enabled = true;
                    btnTemperatureModify.Enabled = true;
                    fg.AllowEditing = true;
               }
          }

          private void btnFind_Click(object sender, EventArgs e)
          {
               btnFind.Enabled = false;

               try
               {
                    string[] FindStr = new string[5];
                    string Database = Application.StartupPath + @"\DataBase\" + "SDAF" + DataOperate.CurrentDataBase.ToString().ToString() + ".mdb";

                    for (int i = 0; i < 5; i++)
                    {
                         FindStr[i] = "";
                    }

                    if (!File.Exists(Database))
                    {
                         MessageBox.Show(DataOperate.CurrentDataBase.ToString() + Properties.Resources.DataNotExist, Properties.Resources.HintCaption , MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                         return;
                    }

                    string strSQL = "SELECT * FROM  TestData  ";

                    if (chkAutoNo.Checked && cmbAutoNo.Text.Trim() != "")
                    {
                         if (cmbAutoNo.Text.Trim() == "like")
                         {
                              FindStr[0] = " TestData.[自动编号] LIKE '%" + edtAutoNo.Text + "%'";
                         }
                         else
                         {
                              FindStr[0] = " TestData.[自动编号]  = '" + edtAutoNo.Text + "' ";
                         }
                    }

                    if (chkManualNo.Checked)
                    {
                        if (edtTestType.Text == "") FindStr[1] = " TRUE";
                        else FindStr[1] = " TestData.[人工编号] LIKE '%" + edtTestType.Text + "%'";
                    }

                    if (chkTestType.Checked)
                    {
                         FindStr[4] = " TestData.[实验类型] = '" + cmbTestType.Text + "'";
                    }

                    if (chkTestData.Checked && cmbTestDate.Text.Trim() != "")
                    {
                         if (cmbTestDate.SelectedIndex  ==3)
                              FindStr[2] = " TestData.[实验日期] >= #" + picTestDate1.Value.ToString("yyyy-MM-dd") + "# AND TestData.[实验日期] <= #" + picTestDate2.Value.ToString("yyyy-MM-dd") + "#";
                         else
                              FindStr[2] = " TestData.[实验日期] " + cmbTestDate.Text + " #" + picTestDate2.Value.ToString("yyyy-MM-dd") + "#";
                    }


                    if (chkRestult.Checked && cmbResult.Text.Trim() != "")
                    {
                         if (cmbResultType.Text != "")
                         {
                             String tmptResutlType = "压应力 落高 药量 温度变化 气体变化";
                             switch (cmbResultType.SelectedIndex)
                             {
                                 case 0:
                                     tmptResutlType = "压应力";
                                     break;
                                 case 1:
                                     tmptResutlType = "落高";
                                     break;
                                 case 2:
                                     tmptResutlType = "药量";
                                     break;
                                 case 3:
                                     tmptResutlType = "温度变化";
                                     break;
                                 case 4:
                                     tmptResutlType = "气体变化";
                                     break;
                             }
                              int t = int.Parse(edtResult2.Text.Trim());
                              if (cmbResult.SelectedIndex!=3)
                              {
                                   FindStr[3] = " TestData.[" + tmptResutlType + "]" + cmbResult.Text+ t.ToString() ;
                                               }
                              else
                              {
                                   int min = int.Parse(edtResult1.Text.Trim());
                                   int max = int.Parse(edtResult2.Text.Trim());
                                   String strMin;
                                   String strMax;

                                   strMin = " TestData.[" + tmptResutlType + "] >" + min.ToString();
                         

                                   strMax = " TestData.[" + tmptResutlType + "] <" + max.ToString() ;
                       

                                   FindStr[3] = "(" +strMin+ ") AND (" +strMax+")";
                              }
                            }
                    }
                    string tmp = "";
                    for (int i = 0; i < 5; i++)
                    {
                         if (FindStr[i] != "")
                         {
                              tmp += " AND " + FindStr[i];
                         }
                    }
                    if (tmp != "")
                    {
                         strSQL = strSQL + " WHERE TRUE  " + tmp + " ORDER BY TestData.[实验日期],TestData.[自动编号]";
                         DataOperate.ExecuteSQL(strSQL, Database, DataOperate.SqlOrder.Find);
                    }
               }
               catch
               {
                    MessageBox.Show(Properties.Resources.DataSearchErr, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               }
               btnFind.Enabled = true;
          }



          private void 自定义查找UToolStripMenuItem_Click(object sender, EventArgs e)
          {
               自定义查找UToolStripMenuItem.Checked = !自定义查找UToolStripMenuItem.Checked;
               splitVertical.Panel1Collapsed =  !splitVertical.Panel1Collapsed;
            
          }

         private void DispOneRecord()
         {
             try
             {
                 string currrowstr = "";
                 if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US") currrowstr = "No record";
                 else currrowstr = "无";

                 int i;
                 i = fg.Row - fg.Rows.Fixed;
                 if (i < DataOperate.MyTable.Rows.Count && i >= 0)
                     SetOneRecord();
                 else
                     ClearOneRecord();

                 //CalcLab.Visible = false;
                 i++;
                 if (i > 0) currrowstr = i.ToString();
                 this.RowsNumlab.Text = Properties.Resources.RecordSum + Convert.ToString(fg.Rows.Count - fg.Rows.Fixed) + Properties.Resources.RecordCurrent + currrowstr;
             }
             catch (Exception err)
             {
                 MessageBox.Show(err.ToString(), Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

             }
         }

          private void DispOneRecord(bool beCoordinate)
          {
              int aa = panel3.AutoScrollPosition.X;
              if (beCoordinate)
              {
                  splitHorizontal2.SplitterDistance = 246;

              }
              else
              {
                  splitHorizontal2.SplitterDistance = 376;
      
              }
              DispOneRecord();
          }
          void SetOneRecord()
          {
               int index = fg.Row - fg.Rows.Fixed;
               if (DataOperate.MyTable.Rows[index].RowState != DataRowState.Deleted)
               {
                   string autoNo = DataOperate.MyTable.Rows[index][0].ToString();

                 
               }
          }

   

  

          private void picInitialRounding_Click(object sender, EventArgs e)
          {
               string indexString = (string)((Control)sender).Tag;
               int index = int.Parse(indexString);
           }






  

          private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
          {
               try
               {
              
               }
               catch (Exception err)
               {
               }
          }


          private void btnUpdateModified_Click(object sender, EventArgs e)
          {
               try
               {
                    int index = fg.Row - fg.Rows.Fixed;
                    DataOperate.MyTable.Rows[index][0] = edtAutoNoaa.Text;
                    DataOperate.MyTable.Rows[index][1] = edtManualNoaa.Text;
                    DataOperate.MyTable.Rows[index][2] = cmbTestTypeaa.Text;
                 
                    DataOperate.MyTable.Rows[index]["实验日期"] = edtTestDate.Value;
                    DataOperate.MyTable.Rows[index]["识别方式"] = edtTestMethod.Text;
                    DataOperate.MyTable.Rows[index]["实验员"] = cmbTester.Text;
                    DataOperate.MyTable.Rows[index]["位置编号"] = int.Parse(edtPositionNo.Text);
                    DataOperate.MyTable.Rows[index]["备注"] = edtRemark.Text;
                    DataOperate.UpdateTestData();
                    MessageBox.Show(Properties.Resources.UpdateOK, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
               catch (Exception err)
               {
                    MessageBox.Show(err.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
               }

          }



          void ClearOneRecord()
          {
         
          }

          //更新数据库菜单
          private void meuDataBase()
          {
               数据库ToolStripMenuItem.DropDownItems.Clear();
               DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\DataBase");
               FileInfo[] fi;
               fi = di.GetFiles("SDAF????.mdb", SearchOption.TopDirectoryOnly);
             //for (int i = 0; i < fi.Length; i++)
              //{
               //    if(fi[i].Name.Length!=12) 
               //}
               //ArrayList aa=new ArrayList(
               int k = fi.Length;
               int index = -1;

               if (k > 0)
               {
                    Array year =  Array.CreateInstance(typeof(int), k);
                    for (int i = 0; i < k; i++)
                    {
                         year.SetValue(int.Parse(fi[i].Name.ToString().Substring(4, 4)), i);
                    }
                    Array.Sort(year);
                    for (int i = 0; i < k; i++)
                    {
                         ToolStripMenuItem tp = new ToolStripMenuItem();
                         tp.Text = year.GetValue(i).ToString() +  Properties.Resources.Year;
                         tp.Click += new EventHandler(DataBasetp_Click);
                         tp.Tag = year.GetValue(i);
                         数据库ToolStripMenuItem.DropDownItems.Add(tp);

                         if (DateTime.Now.Year == int.Parse(year.GetValue(i).ToString()))
                              index = i;
                    }

                    if (index < 0) index = k - 1;
                    ToolStripMenuItem CHk_Tp = (ToolStripMenuItem)数据库ToolStripMenuItem.DropDownItems[index];
                    CHk_Tp.Checked = true;
                    DataOperate.CurrentDataBase = (int)year.GetValue(index);
                    CurDb.Text =  Properties.Resources.CurrentDatabase  + DataOperate.CurrentDataBase.ToString() +  Properties.Resources.Year;

               }

          }
          private void DataBasetp_Click(object sender, EventArgs e)
          {
               ToolStripMenuItem tp = (ToolStripMenuItem)sender;
               if (DataOperate.CurrentDataBase != (int)tp.Tag)
               {
                    DataOperate.CurrentDataBase = (int)tp.Tag;
                    CurDb.Text =  Properties.Resources.CurrentDatabase  + DataOperate.CurrentDataBase.ToString() +  Properties.Resources.Year;

                    for (int i = 0; i < 数据库ToolStripMenuItem.DropDownItems.Count; i++)
                    {
                         ToolStripMenuItem Chk_Tp = (ToolStripMenuItem)数据库ToolStripMenuItem.DropDownItems[i];
                         Chk_Tp.Checked = false;
                    }
                    tp.Checked = true;
                    所有记录AToolStripMenuItem_Click(null, null);
               }
               //   SetFindYear();
          }

          private void 所有记录AToolStripMenuItem_Click(object sender, EventArgs e)
          {
               fg.FinishEditing(true);
               DataOperate.FindYearData();

          }

          private void 当天记录CToolStripMenuItem_Click(object sender, EventArgs e)
          {

                fg.FinishEditing(true);
                string Database;
                Database = Application.StartupPath + @"\DataBase\" +  "SDAF" + DateTime.Now.Year.ToString() + ".mdb";
                if (!File.Exists(Database)) return;

               DataOperate.CurrentDataBase = DateTime.Now.Year;
               CurDb.Text = Properties.Resources.CurrentDatabase + DataOperate.CurrentDataBase.ToString() +  Properties.Resources.Year;

               DataOperate.FindDayData();
               for (int i = 0; i < 数据库ToolStripMenuItem.DropDownItems.Count; i++)
               {
                    ToolStripMenuItem Chk_Tp = (ToolStripMenuItem)数据库ToolStripMenuItem.DropDownItems[i];
                    if ((int)Chk_Tp.Tag == DataOperate.CurrentDataBase) Chk_Tp.Checked = true;
                    else Chk_Tp.Checked = false;
               }
          }

          private void c1FlexGrid1_RowColChange(object sender, EventArgs e)
          {
               DispOneRecord();
               string capttion = fg.Cols[fg.Col].Name;
               if (capttion == "流动温度" ||capttion == "半球温度" ||capttion == "软化温度" ||capttion == "变形温度")
               {
                   fg.ImeMode = ImeMode.Disable;
               }
               else fg.ImeMode = ImeMode.NoControl; 
          }

          private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
          {
               AboutBox1 frmAbout = new AboutBox1();
               frmAbout.ShowDialog();
          }

          private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
          {

              if (e.Cancel == true)   //如果输入数据不合理，e.Cance=true;
              {
                  fg.FinishEditing(true);
                  e.Cancel = false;
              }

                   System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("cPowerOff");
                   if (p.Length == 0)
                   {
                       if (MessageBox.Show(Properties.Resources.AskQuit, Properties.Resources.HintCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                       {
                           e.Cancel = true;
                       }
                       else
                       {
                       }
                   }
                   if (e.Cancel != true) fg.FinishEditing(true);
          }



          // C#调用
      
          
           static void RunCmd(string cmd)
           {
           try
           {

           using (Process proc = new Process())
           {
           proc.StartInfo.CreateNoWindow = true;
           proc.StartInfo.FileName = "cmd.exe";
           proc.StartInfo.UseShellExecute = false;
           proc.StartInfo.RedirectStandardError = true;
           proc.StartInfo.RedirectStandardInput = true;
           proc.StartInfo.RedirectStandardOutput = true;
           proc.Start();
           proc.StandardInput.WriteLine(cmd);
           //MessageBox.Show(proc.StandardOutput.ReadToEnd());
           string output = proc.StandardOutput.ReadToEnd();
           proc.WaitForExit();
           proc.Close();
           Console.WriteLine(output);
       
           }
           }
           catch (Exception e)
           {
           Console.WriteLine(e.Message);
           }
           }


          private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
          {

               打印预览ToolStripMenuItem.Enabled = false;
               打印预览.Enabled = false;
               DataOperate.printData = DataOperate.dataSet11.Tables["TestData"].Copy();
               DataOperate.printData.Clear();

        
                    if (GlobalCofigData.PrintConfig.IsReport) //报告单
                    {

                                //选定记录
                      
                        if (fg.Rows[fg.RowSel]["人工编号"] is DBNull)
                        {
           
                         
                            //MessageBox.Show("当前所选数据试样编号为空，请先指定试样编号！", Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            
                        }
                        else
                        {


                            FormReportTip frm = new FormReportTip();
                            frm.Owner = this;
                            frm.Show();

                            //                    int tick = Environment.TickCount;

                            //while (Environment.TickCount - tick < 1000)
                            {

                                Application.DoEvents();

                            }

                            string bb = fg.Rows[fg.RowSel]["人工编号"].ToString();



                            if (!System.IO.File.Exists("C:\\JCJC\\birt\\reportPdfFiles\\" + bb + ".pdf"))
                            {
                                if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD)
                                {
                                    RunCmd("java -jar C:\\JCJC\\LabReport.jar " + bb + " huoyanheihuoyao " + bb + ".pdf&exit");
                                }
                                else if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.JDGD)
                                {
                                    RunCmd("java -jar C:\\JCJC\\LabReport.jar " + bb + " jingdianhuohua " + bb + ".pdf&exit");
                                }
                               
                            }
                            frm.Close();
                            FormPDF frmPdf = new FormPDF(bb);
                            frmPdf.ShowDialog();

                            //DataOperate.FineSampleData(bb);
                            
                            //if(DataOperate.printSample.Rows.Count >0) 
                            //{
                            //    try
                            //    {
                            //        string Database = Application.StartupPath + @"\DataBase\" + "SDAF" + DataOperate.CurrentDataBase.ToString().ToString() + ".mdb";
                            //        if (!File.Exists(Database))
                            //        {
                            //            MessageBox.Show(DataOperate.CurrentDataBase.ToString() + Properties.Resources.DataNotExist, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //            return;
                            //        }
                            //        string strSQL = "SELECT * FROM  TestData where 人工编号 = '"+bb+"'";
                            //        DataOperate.ExecuteSQL(strSQL, Database, DataOperate.SqlOrder.Find);
           
                            //    }
                            //    catch
                            //    {
                            //        MessageBox.Show(Properties.Resources.DataSearchErr, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //    }

                            //    DataOperate.printData = DataOperate.dataSet11.Tables["TestData"].Copy();


                            //    if (DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD)
                            //    {
                            //        MessageBox.Show("当前发火高度发火概率不为50%，请调整步进值继续试验，使发火概率为50%", Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            //    }
                            //    else
                            //    {
                            //        if (DataOperate.printData.Rows.Count > 20)
                            //        {
                            //            //计算爆炸概率
                            //            int exploreCount = 0;
                            //            for (int i = 0; i < DataOperate.printData.Rows.Count; i++)
                            //            {
                            //                if (DataOperate.printData.Rows[i]["实验结果"].ToString() == "爆炸") exploreCount++;
                            //            }
                            //            float popularity = (float)exploreCount / (float)DataOperate.printData.Rows.Count;
                            //            DataOperate.printSample.Rows[0]["概率"] = popularity;
                            //            if (exploreCount > 25) exploreCount = 25;//容错功能
                            //            DataOperate.printSample.Rows[0]["置信下限"] = pTable[0, exploreCount];
                            //            DataOperate.printSample.Rows[0]["置信上限"] = pTable[1, exploreCount];


                            //            if ((string)((ToolStripItem)sender).Tag == "Preview")
                            //            {
                            //                if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US") frmPrint.Text = "Print report";
                            //                else frmPrint.Text = "打印报告单";
                            //                // frmPrint.Clear(); 
                            //                frmPrint.ShowDialog();
                            //            }
                            //            else
                            //                frmPrint.Reportprint(true);
                            //        }
                            //        else
                            //            MessageBox.Show("当前所选试样，测试次数不足，无法计算爆炸概率！", Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            //    }
                            //   }
                            }
                    }
                    else//报表
                    {
                        //选定记录
                        foreach (C1.Win.C1FlexGrid.Row r in fg.Rows)
                        {
                            if (r.Selected && r["自动编号"] != null && r["自动编号"].ToString() != "")
                            {

                                object[] row = DataOperate.dataSet11.Tables["TestData"].Rows[r.Index - 1].ItemArray;
                                DataOperate.printData.Rows.Add(row);
                            }
                        }
                        if (DataOperate.printData.Rows.Count > 0)
                        {
                                            if ((string)((ToolStripItem)sender).Tag == "Preview")
                                            {
                                                if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US") frmPrint.Text = "Print report table";
                                                else frmPrint.Text = "打印报表";
                                                //frmPrint.Clear();
                                                frmPrint.ShowDialog();
                                            }
                                            else
                                            {
                                            
                                                frmPrint.TablePrint(true);
                                            }
                         }
                         else
                        MessageBox.Show(Properties.Resources.NoAvailableRecord,  Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
     
                    }
              
 

               打印预览.Enabled = true;
               打印预览ToolStripMenuItem.Enabled = true;


          }

          private void 删除DToolStripMenuItem_Click(object sender, EventArgs e)
          {
               if (passwordAccessed || AccessPassWord())
               {
                    
                    if (fg.RowSel < 1)
                    {
                         MessageBox.Show(Properties.Resources.NoSelectedRecord,  Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                         return;
                    }

                    if (MessageBox.Show(Properties.Resources.AskDeleteRecord,  Properties.Resources.HintCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                         fg.FinishEditing(true); 
                         DeleteData(false);
                         DispOneRecord();//在删除过程中，因为c1FlexGrid1_RowColChange调用DispOneRecord如果RowState为Deleted时会不处理，需要加上此功能

                        //印尼专业版
                         try
                         {
                             if (deleteDirectory != null && deleteDirectory.Count > 0)
                             {
                                 string pathStr = Application.StartupPath + @"\DeletedData.sdaf";
                                 using (StreamWriter sw = File.AppendText(pathStr))
                                 {
                                     for (int i = deleteDirectory.Count - 1; i >= 0; i--)
                                     {
                                         string autoNo = (string)deleteDirectory[i];
                                         sw.WriteLine(autoNo);
                                     }
                                     sw.Flush();
                                     sw.Close();
                                 }
                             }
                         }
                         catch (Exception err)
                         {
                         }
                    
                    }
               }

          }

          private void fg_BeforeDeleteRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
          {

          }

          //印尼专业版
         ArrayList deleteDirectory; 

          void DeleteData(bool flag)
          {
               try
               {

                    fg.Redraw = false;
                    ArrayList deletedArray = new ArrayList();

                    //印尼专业版
                    deleteDirectory = new ArrayList();
                    
                    int deletedIndex=0;
                    foreach (C1.Win.C1FlexGrid.Row r in fg.Rows.Selected)
                    {
                         deletedIndex=r.Index - 1;
                         deletedArray.Add(deletedIndex);

                         //印尼专业版
                         try
                         {
                             string aa = (string)r["自动编号"];
                             deleteDirectory.Add(aa);
                         }
                         catch (Exception err)
                         {
                         }
                    }
                    for (int i = deletedArray.Count; i > 0; i--)
                    {
                         DataOperate.MyTable.Rows[(int)deletedArray[i - 1]].Delete();
                    }
                    DataOperate.UpdateTestData();
                    fg.Redraw = true;

                    MessageBox.Show(Properties.Resources.DeleteRecordSuccess,  Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

               }
               catch (Exception g)
               {
                    fg.Redraw = true;
                    MessageBox.Show(Properties.Resources.DeleteRecordErr + (char)13 + (char)10 + g.ToString(), Properties.Resources.HintCaption, MessageBoxButtons.OK);
               }
          }

          private void numberTextBox2_TextChanged(object sender, EventArgs e)
          {

          }

          [DllImport("user32.dll")]
          public static extern bool BringWindowToTop(IntPtr hWnd);
          [DllImport("user32.dll")]
          public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
          private void timer1_Tick(object sender, EventArgs e)
          {
               ShowWindow(this.Handle, 1);
               this.Activate();
              // BringWindowToTop(this.Handle);
               timer1.Enabled = false;
              //不显示和处理正在实验的数据
               if (false&&File.Exists(Application.StartupPath + @"\ResumeTestData.xml"))
               {

                    DataOperate.MyTable.Rows.Clear();
                    DataOperate.MyTable.ReadXml(Application.StartupPath + @"\ResumeTestData.xml");
                    DataTable table = DataOperate.MyTable;
                    for (int i = table.Rows.Count - 1; i >= 0; i--)
                    {

                         if (table.Rows[i]["实验类型"] is DBNull)
                         {
                              table.Rows[i].Delete();
                         }
                    }
               }
               else
               {
                    meuDataBase();//跨年测试过程中，变更了年份
                    当天记录CToolStripMenuItem_Click(null, null);
               }
          }

          protected override void WndProc(ref Message m)
          {
               if (m.Msg == 0x500)
               {
                    timer1.Enabled = true;
                    timer1.Interval  = 1000;
          
               }
               else if (m.Msg == 0x501)
               {
                    GlobalCofigData.SystemConfig.PassWord = (string)Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Sundy\SDAF", @"PassWord", "");
               }
               else base.WndProc(ref m);
          }

          private void btnUpdateModified_EnabledChanged(object sender, EventArgs e)
          {
               groupBox1.Enabled = btnUpdateModified.Enabled;
          }

          private void label6_Click(object sender, EventArgs e)
          {

          }

          private void fg_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
          {
               try
               {

              
                    //if (fg.Cols[e.Col].Name == "人工编号")
                    //{
                    //     fg.Editor = numberTextBox1;
                    //     numberTextBox1.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.String;
                    //     numberTextBox1.MaxLength = (short)DataOperate.dataSet11.Tables["Configure"].Rows[DataOperate.人工编号]["最大长度"];
                    // }
                    //else
                        if (fg.Cols[e.Col].Name == "备注")
                    {
                         fg.Editor = numberTextBox1;
                         numberTextBox1.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.String;
                         numberTextBox1.MaxLength =  (short)DataOperate.dataSet11.Tables["Configure"].Rows[DataOperate.备注]["最大长度"];
                    }
                    else
                    {
                         //fg.Editor = numberTextBox1;
                         //numberTextBox1.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.Integer;
                         //numberTextBox1.MaxLength = 4;
                         //numberTextBox1.IsCheckValue = false;
                     }
               }
               catch (Exception err)
               {
                    MessageBox.Show(err.ToString().ToString(),  Properties.Resources.ErrorCaption , MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
          }
          private void label17_Click(object sender, EventArgs e)
          {

          }

          private void chkAutoNo_CheckedChanged(object sender, EventArgs e)
          {
               //cmbAutoNo.Enabled = chkAutoNo.Checked;
               //edtAutoNo.Enabled = chkAutoNo.Checked;
          }

          private void cmbTestDate_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (cmbTestDate.SelectedIndex == 3) picTestDate1.Visible = true;
               else picTestDate1.Visible = false;
          }

          private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (cmbResult.SelectedIndex==3) edtResult1.Enabled = true;
               else edtResult1.Enabled = false;
          }



          private void fg_AfterResizeColumn(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
          {
               DataOperate.AfterResizeRow();
          }
          [DllImport("shell32.dll")]
          public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);
          private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
          {
               帮助文档ToolStripMenuItem.Enabled = false;
               ShellExecute(this.Handle, new StringBuilder("Open"), new StringBuilder(Application.StartupPath + @"\数据库帮助文档.CHM"), new StringBuilder("0"), new StringBuilder("0"), 1);
               帮助文档ToolStripMenuItem.Enabled = true; 
          }


         private void 查找SToolStripMenuItem_Click(object sender, EventArgs e)
         {

         }

         private void fg_LeaveEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
         {
  
         }

         private void picTemperature_Paint(object sender, PaintEventArgs e)
         {
              /* Point firstPoint = new Point(25, 0);
               Point secondPoint = new Point(25, 179);
               Pen myPen = new Pen(Brushes.Black, 1);
               myPen.Width = 0.5f;
               Graphics aa = picTemperature.CreateGraphics(); ;          
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(50, 0);
               secondPoint = new Point(50, 179);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(75, 0);
               secondPoint = new Point(75, 179);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(100, 0);
               secondPoint = new Point(100, 179);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(125, 0);
               secondPoint = new Point(125, 179);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(150, 0);
               secondPoint = new Point(150, 179);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(0, 179-25);
               secondPoint = new Point(154, 179 - 25);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(0, 179 - 50);
               secondPoint = new Point(154, 179 - 50);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(0, 179 - 75);
               secondPoint = new Point(154, 179 - 75);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(0, 179 - 100);
               secondPoint = new Point(154, 179 - 100);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(0, 179 - 125);
               secondPoint = new Point(154, 179 - 125);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(0, 179 - 150);
               secondPoint = new Point(154, 179 - 150);
               aa.DrawLine(myPen, firstPoint, secondPoint);
               firstPoint = new Point(0, 179 - 175);
               secondPoint = new Point(154, 179 - 175);
               aa.DrawLine(myPen, firstPoint, secondPoint);  */
         }

         private void coordinateImageToolStripMenuItem_Click(object sender, EventArgs e)
         {
             if (coordinateImageToolStripMenuItem.Checked)
             {
                 coordinateImageToolStripMenuItem.Checked = false;
                 splitHorizontal2.Panel2Collapsed = true;
             }
             else
             {
                 coordinateImageToolStripMenuItem.Checked = true;
                 图片信息PToolStripMenuItem.Checked = false;
                 splitHorizontal2.Panel2Collapsed = false;
                 DispOneRecord(true);
             }
         }

         private void 图片信息PToolStripMenuItem_Click(object sender, EventArgs e)
         {
             if (图片信息PToolStripMenuItem.Checked)
             {
                 图片信息PToolStripMenuItem.Checked = false;
                 splitHorizontal2.Panel2Collapsed = true;
             }
             else
             {
                 图片信息PToolStripMenuItem.Checked = true;
                 coordinateImageToolStripMenuItem.Checked = false;
                 splitHorizontal2.Panel2Collapsed = false;
                 DispOneRecord(true);
             }
          


             DispOneRecord(false);
         }

         private void edtAutoNo_KeyPress(object sender, KeyPressEventArgs e)
         {
              e.Handled=true;
              if (e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar >= 48 && e.KeyChar <= 57) e.Handled = false;
         }

         private void FormMain_Shown(object sender, EventArgs e)
         {

         }

         private void FormMain_Move(object sender, EventArgs e)
         {


         }

         private void cmbTestType_SelectedIndexChanged(object sender, EventArgs e)
         {

         }
     }
}