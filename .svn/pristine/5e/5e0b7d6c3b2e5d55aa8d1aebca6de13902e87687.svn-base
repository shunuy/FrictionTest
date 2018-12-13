using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SDAF.DataOperateLib;
using System.IO;

namespace SDAF.DataBase
{
     public partial class FormSet : Form
     {
          public FormSet()
          {
               InitializeComponent();
               this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
          }

          DataTable temptTable = new DataTable();

          private void FormSet_Load(object sender, EventArgs e)
          {
               this.c1FlexGrid1.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_StartEdit);
               this.c1FlexGrid1.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.c1FlexGrid1_ValidateEdit);

               temptTable = DataOperate.dataSet11.Tables["Configure"].Copy();

   

               configureBindingSource.DataSource = temptTable;
               c1FlexGrid1.Cols["字段名称"].Visible = false;
               c1FlexGrid1.Cols["自动编号"].Visible = false;
               c1FlexGrid1.Cols["是否显示"].Visible = false;
               c1FlexGrid1.Cols["显示名称"].AllowEditing = false;
               c1FlexGrid1.Cols["显示名称"].Caption = "名称";
               c1FlexGrid1.Cols["显示宽度"].Visible = false;
               c1FlexGrid1.Cols["显示位置"].Visible = false;
               c1FlexGrid1.Cols["打印位置"].Visible = false;
               c1FlexGrid1.Cols["最大长度"].Visible = false;
               if (c1FlexGrid1.Cols["数据库显示宽度"] != null) c1FlexGrid1.Cols["数据库显示宽度"].Visible = false;//兼容没有“数据库显示宽度”字段的数据库

               c1FlexGrid1.Rows[DataOperateLib.DataOperate.温度变化+1].Visible = false;
               c1FlexGrid1.Rows[DataOperateLib.DataOperate.气体变化+1].Visible = false;


              // c1FlexGrid1.Rows[13].Visible = false;//识别方式不显示

               if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD)
               {
                   c1FlexGrid1.Rows[SDAF.DataOperateLib.DataOperate.试验步长+1].Visible = false;
               }


               if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US")
               {
                   c1FlexGrid1.Cols["显示名称"].Caption = "Name";
                   c1FlexGrid1.Cols["打印名称"].Caption = "Print name";
                   c1FlexGrid1.Cols["是否打印"].Caption = "Whether to print";
                   c1FlexGrid1.Cols["打印宽度"].Caption = "Print width";
                  
               }
               
               c1FlexGrid1.Rows.DefaultSize = 21;
                 c1FlexGrid1.Cols["显示名称"].Width = (int)(1.2 * c1FlexGrid1.Cols["显示名称"].Width);
                   c1FlexGrid1.Cols["打印名称"].Width = (int)(1.2 * c1FlexGrid1.Cols["打印名称"].Width);
               if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US")
               {
                   c1FlexGrid1.Cols["是否打印"].Width = 110; 
               }

               for (int i = 1; i < c1FlexGrid1.Cols.Count; i++)
               {
                    c1FlexGrid1.Cols[i].TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    c1FlexGrid1.Cols[i].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
               }

               if (GlobalCofigData.PrintConfig.IsReport) rdoReport.Checked = true;
               else rdoSheet.Checked = true;
               chkTester.Checked = GlobalCofigData.PrintConfig.IsPrintTester;
               edtTester.Text = GlobalCofigData.PrintConfig.Tester.Trim(); ;
               chkChecker.Checked = GlobalCofigData.PrintConfig.IsPrintChecker;
               edtChecker.Text = GlobalCofigData.PrintConfig.Checker.Trim();
            chkTestOrgnization.Checked = GlobalCofigData.PrintConfig.IsTestOrganization;
            edtTestOrgnization.Text = GlobalCofigData.PrintConfig.TestOrganization.Trim();
            edtReportTitle.Text = GlobalCofigData.PrintConfig.ReportTitle;
            edtSheetTitle.Text = GlobalCofigData.PrintConfig.SheetTitle;
            edtPictureSavePath.Text=  GlobalCofigData.SystemConfig.PictureSavePath;

            DayDom.Text = GlobalCofigData.SystemConfig.BackUpInterval.ToString() ;
            autoBakChk.Checked = GlobalCofigData.SystemConfig.AutoBackup;
            addapplistItem();
            label8.Text = Application.StartupPath + @"\DataBase\bak\";
          }

          private void btnOK_Click(object sender, EventArgs e)
          {
               if (numberTextBox1.Visible == true) return;
               try
               {
                    DataOperate.dataSet11.Tables.Remove("Configure");
                    DataOperate.dataSet11.Tables.Add(temptTable);
                    if (rdoReport.Checked) GlobalCofigData.PrintConfig.IsReport = true;
                    else GlobalCofigData.PrintConfig.IsReport = false;
                    GlobalCofigData.PrintConfig.IsPrintTester = chkTester.Checked;
                    GlobalCofigData.PrintConfig.Tester = MutiSubString(edtTester.Text + "          ",10);
                    GlobalCofigData.PrintConfig.IsPrintChecker = chkChecker.Checked;
                    GlobalCofigData.PrintConfig.Checker = MutiSubString(edtChecker.Text+"          ",10);
                    GlobalCofigData.PrintConfig.IsTestOrganization = chkTestOrgnization.Checked;
                    GlobalCofigData.PrintConfig.TestOrganization = MutiSubString(edtTestOrgnization.Text + "                                                            ", 60);
                    GlobalCofigData.PrintConfig.ReportTitle = edtReportTitle.Text;
                    GlobalCofigData.PrintConfig.SheetTitle = edtSheetTitle.Text;
                    GlobalCofigData.SystemConfig.BackUpInterval=int.Parse(DayDom.Text);
                    GlobalCofigData.SystemConfig.AutoBackup=autoBakChk.Checked;
                    GlobalCofigData.SystemConfig.PictureSavePath = edtPictureSavePath.Text;
                    GlobalCofigData.Config.Save(ConfigurationSaveMode.Full);
               }
               catch (Exception err)
               {
                    MessageBox.Show(err.Message, Properties.Resources.ErrorCaption, MessageBoxButtons.OK);
               }

          }

          private void chkTester_CheckedChanged(object sender, EventArgs e)
          {
          }

          private void chkChecker_CheckedChanged(object sender, EventArgs e)
          {
          }

          private void chkTestOrgnization_CheckedChanged(object sender, EventArgs e)
          {
          }

          private void btnCancel_Click(object sender, EventArgs e)
          {
               this.Close();
          }

          private void button1_Click(object sender, EventArgs e)
          {
           
          }

         private void bakbut_Click(object sender, EventArgs e)
         {
             label7.Visible = false;
             bakbut.Enabled = false;
             if (File.Exists(Application.StartupPath + @"\DataBase\SDAF" + DateTime.Now.ToString("yyyy") + ".mdb"))
             {
                 if (!System.IO.Directory.Exists(Application.StartupPath + @"\DataBase\bak"))
                     System.IO.Directory.CreateDirectory(Application.StartupPath + @"\DataBase\bak");
                     File.Copy(Application.StartupPath + @"\DataBase\SDAF" + DateTime.Now.ToString("yyyy") + ".mdb",
                     Application.StartupPath + @"\DataBase\bak\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak", true);
                     addapplistItem();
             }
             bakbut.Enabled = true;
         }

         void addapplistItem()
         {
             applist.Items.Clear();
             if (!Directory.Exists(Application.StartupPath + @"\DataBase\bak"))
             {
                 Directory.CreateDirectory(Application.StartupPath + @"\DataBase\bak");
             }
             DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\DataBase\bak");
             FileInfo[] fi;
             fi = di.GetFiles("??????????????.bak", SearchOption.TopDirectoryOnly);
             int k = fi.Length;

             if (k > 0)
             {
                 for (int i = 0; i < k; i++)
                     applist.Items.Add(fi[i].Name.ToString());
             }
         }

         private void hfbut_Click(object sender, EventArgs e)
         {
             label7.Visible = false;

             if (applist.SelectedIndex < 0)
             {
                 label7.Text =Properties.Resources.NoBackupFileSelected;
                 label7.Visible = true;
                 return;
             }

             if (MessageBox.Show(Properties.Resources.AskRestore, Properties.Resources.HintCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                 return;

             hfbut.Enabled = false;
             try
             {
                 if (File.Exists(Application.StartupPath + @"\DataBase\bak\" + applist.SelectedItem.ToString()))
                 {
                     File.Copy(Application.StartupPath + @"\DataBase\bak\" + applist.SelectedItem.ToString(),
                         Application.StartupPath + @"\DataBase\SDAF" + DateTime.Now.ToString("yyyy") + ".mdb", true);

                   //  Main.CurDataBase = DateTime.Now.Year;
                     string Database = Application.StartupPath + @"\DataBase\" + "SDAF" + DateTime.Now.ToString("yyyy") + ".mdb";
                    // Main.ExecuteSQL("SELECT * FROM  SDTGA5000a  ORDER BY SDTGA5000a.[测试日期],SDTGA5000a.[自动编号] ", Database, Main.SqlOrder.Find);
                 }
                 label7.Text =Properties.Resources.RestoreOK ;
                 label7.Visible = true;
             }
             catch
             {
                 label7.Text = Properties.Resources.RestoreErr;
                 label7.Visible = true;
             }

          
             hfbut.Enabled = true;
         }

         private void Delebut_Click(object sender, EventArgs e)
         {
             label7.Visible = false;
             if (applist.SelectedIndex < 0)
             {
                 label7.Text = Properties.Resources.NoBackupFileSelected;
                 label7.Visible = true;
                 return;
             }
             if (MessageBox.Show(Properties.Resources.AskDeleteBackupFile,  Properties.Resources.HintCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                 return;
             Delebut.Enabled = false;
             if (applist.SelectedIndex >= 0)
             {
                 if (File.Exists(Application.StartupPath + @"\DataBase\bak\" + applist.SelectedItem.ToString()))
                 {
                     File.Delete(Application.StartupPath + @"\DataBase\bak\" + applist.SelectedItem.ToString());
                     addapplistItem();
                     label7.Text = Properties.Resources.DeleteDataBackupOK;
                     label7.Visible = true;
                 }
             }
             Delebut.Enabled = true;
         }


          private void c1FlexGrid1_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
          {
               if (c1FlexGrid1.Cols[e.Col].Name == "打印名称")
               {
                    c1FlexGrid1.Editor = numberTextBox1;
                    numberTextBox1.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.String;
                    numberTextBox1.MaxLength = 12;
               }
               else if (c1FlexGrid1.Cols[e.Col].Name == "打印宽度")
               {
                    c1FlexGrid1.Editor = numberTextBox1;
                    numberTextBox1.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.Integer;
                    numberTextBox1.MaxLength = 2;
               }
          }

          private void btnSaveDirectory_Click(object sender, EventArgs e)
          {
               FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
               if (openFileDialog1.ShowDialog() == DialogResult.OK)
               {
                    if (openFileDialog1.SelectedPath != null) edtPictureSavePath.Text = openFileDialog1.SelectedPath;
               }
          }

          /// <summary>
          /// 字符串截取
          /// </summary>
          /// <param name="aOrgStr">原始字符串</param>
          /// <param name="aLength">截取长度</param>
          /// <returns></returns>
          public  String MutiSubString(String aOrgStr, int aLength)
          {
               int intLen = aOrgStr.Length;
               int start = 0;
               int end = intLen;
               int single = 0;
               char[] chars = aOrgStr.ToCharArray();
               for (int i = 0; i < chars.Length; i++)
               {
                    if (System.Convert.ToInt32(chars[i]) > 255)
                    {
                         start += 2;
                    }
                    else
                    {
                         start += 1;
                         single++;
                    }
                    if (start >= aLength)
                    {

                         if (end % 2 == 0)
                         {
                              if (single % 2 == 0)
                              {
                                   end = i + 1;
                              }
                              else
                              {
                                   end = i;
                              }
                         }
                         else
                         {
                              end = i + 1;
                         }
                         break;
                    }
               }
               string temp = aOrgStr.Substring(0, end);
               string temp2 = aOrgStr.Remove(0, end);
               return temp;
          }

 

          private void c1FlexGrid1_ValidateEdit(object sender, C1.Win.C1FlexGrid.ValidateEditEventArgs e)
          {
               if (c1FlexGrid1.Cols[e.Col].Name == "打印宽度")
               {
                    string text = ((TextBox)((C1.Win.C1FlexGrid.C1FlexGrid)sender).Editor).Text.Trim();
                    try
                    {
                        if (text == null||text.Length == 0)
                        {
                            MessageBox.Show(Properties.Resources.SpaceError, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            e.Cancel = true;
                        }
                        else
                        {
                            int value = int.Parse(text);
                            if (value >= 10 && value <= 60) return;
                            else
                            {
                                MessageBox.Show(Properties.Resources.InputLimit + " 10～60  ", Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                e.Cancel = true;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(Properties.Resources.ErrChar, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        e.Cancel = true;
                    }
               }
          }

       
          private void FormSet_FormClosing(object sender, FormClosingEventArgs e)
          {
               this.c1FlexGrid1.StartEdit -= new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_StartEdit);
               this.c1FlexGrid1.ValidateEdit -= new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.c1FlexGrid1_ValidateEdit);
           }

         private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (tabControl1.SelectedIndex == 1) label2.Visible = true;
             else label2.Visible = false;
         }
     }
}