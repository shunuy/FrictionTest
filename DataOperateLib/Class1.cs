using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using C1.Win.C1FlexGrid;


namespace SDAF.DataOperateLib
{
    public enum EquipMentTypes
    {
        HYGD,
        JDGD,
        BFD,
        ZJMC
    }

    public class DataOperate
    {

                //  if (fg.Cols[i].Name == "压应力" || fg.Cols[i].Name == "落高")
                //{
                //    fg.Cols[i].DataType = typeof(Single);
                //    fg.Cols[i].Format = "0.0";
                //}
                //else if (fg.Cols[i].Name == "药量"|| fg.Cols[i].Name == "温度变化" || fg.Cols[i].Name == "气体变化")
        public const int 自动编号 = 0;
        public const int 人工编号 = 1;
        public const int 试验阶段 = 2;
        public const int 序号 = 3;
        public const int 初始高度 = 4;
        public const int 试验步长 = 5;
        public const int 点火高度 = 6;
        public const int 药量 = 7;
        public const int 温度变化 = 8;
        public const int 气体变化 = 9;
        public const int 实验结果 = 10;
        public const int 实验员 = 11;
        public const int 实验日期 = 12;
        public const int 实验时间 = 13;
        public const int 实验标准 = 14;
        public const int 备注 = 15;
      
        public static int CurrentDataBase = 2017;
        //  public  static  DataSet  dataSet11;
        public static DataSet dataSet11 = new DataSet();
        /// <summary>
        /// =dataSet11.Tables["TestData"];
        /// </summary>
        public static DataTable MyTable;
        public static EquipMentTypes EquipMentType = EquipMentTypes.BFD;
        /// <summary>
        /// 待打印的数据
        /// </summary>
        public static DataTable printData;
        public static DataTable printSample;
        private static string ContStr = "";
        private static OleDbConnection OleCon;
        private static OleDbDataAdapter dataAdapterTestData;
        private static OleDbDataAdapter dataAdapterConfigure;
        private static OleDbDataAdapter dataAdapterUser;
        public static OleDbDataAdapter dataAdapterSampleTable;
        private static C1FlexGrid fg;
        /// <summary>
        /// 加载数据
        /// </summary>
        public static bool InitDataOprate(C1FlexGrid flexGrid)
        {
            bool beResumeTest = false;
            try
            {
             

                string Database;

                string directoryPathfile = System.Windows.Forms.Application.StartupPath + "\\hygd.ini";
                string directoryPathfile1 = System.Windows.Forms.Application.StartupPath + "\\jdgd.ini";
                string directoryPathfile2 = System.Windows.Forms.Application.StartupPath + "\\zjmc.ini";
                SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.BFD;
                if (System.IO.File.Exists(directoryPathfile))
                {
                    SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.HYGD;
                }
                else if (System.IO.File.Exists(directoryPathfile1))
                {
                    SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.JDGD;
                }
                else if (System.IO.File.Exists(directoryPathfile2))
                {
                    SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.ZJMC;
                }




                Database = Application.StartupPath + @"\DataBase\" + "SDAF2017.mdb";
                ContStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + Database + " ; Jet OLEDB:Database Password = service ";
                if (!File.Exists(Database))
                {
                    if (!System.IO.Directory.Exists(Application.StartupPath + @"\DataBase"))
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\DataBase");
                    File.Copy(Application.StartupPath + @"\SDAF.mdb", Database);
                }
                FindDayData();
                fg = flexGrid;
                MyTable = dataSet11.Tables["TestData"];


                if ((string)fg.Tag == "Master")
                {
                    if (File.Exists(Application.StartupPath + @"\ResumeTestData.xml")&&false)
                    {
                        dataSet11.Tables["TestData"].Rows.Clear();
                        dataSet11.Tables["TestData"].ReadXml(Application.StartupPath + @"\ResumeTestData.xml");
                        if (MyTable.Rows.Count >= 1 && !(MyTable.Rows[0]["自动编号"] is DBNull))
                        {
                            //您上一次使用软件时异常退出，是否恢复上一次实验？
                            //  if (MessageBox.Show(Resource1.AskResume, Resource1.HintCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            //人工识别 只要判了灰锥就恢复  自动识别必须有实验结果 
                            bool isResume = false;
                            if ((string)MyTable.Rows[0]["识别方式"] == "人工识别" || (string)MyTable.Rows[0]["识别方式"] == "Manual identification") isResume = true;
                            else
                            {
                                for (int i = 0; i < MyTable.Rows.Count; i++)
                                {
                                    if (!(MyTable.Rows[0]["变形温度"] is DBNull)) isResume = true;
                                }
                            }
                            if (isResume)
                            {
                                UpdateTestData();
                            }
                            else File.Delete(Application.StartupPath + @"\ResumeTestData.xml");
                        }
                        else File.Delete(Application.StartupPath + @"\ResumeTestData.xml");
                    }
                    dataSet11.Tables["TestData"].Rows.Clear();

                    //没有人工识别，取消恢复实验功能  人工识别只有在低温下才能恢复，在主程序中当温度超过可恢复实验温度时，修改SDAF.mdb
                    //if (false&&File.Exists(Application.StartupPath + @"\ResumeTestData.xml") && File.Exists(Application.StartupPath + @"\SDAF.mdb"))
                    //{
                    //     DateTime startTestTime = File.GetLastWriteTime(Application.StartupPath + @"\ResumeTestData.xml");
                    //     DateTime lastWriteTime = File.GetLastWriteTime(Application.StartupPath + @"\SDAF.mdb");
                    //     if (startTestTime > lastWriteTime)
                    //     {


                    //          //您上一次使用软件时异常退出，是否恢复上一次实验？
                    //          if (MessageBox.Show(Resource1.AskResume, Resource1.HintCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    //          {

                    //               dataSet11.Tables["TestData"].ReadXml(Application.StartupPath + @"\ResumeTestData.xml");
                    //               beResumeTest = true;
                    //          }
                    //          else File.Delete(Application.StartupPath + @"\ResumeTestData.xml");
                    //     }
                    //}
                    DataRow temptRow;
                    for (int i = 0; i < 20; i++)
                    {
                        temptRow = dataSet11.Tables["TestData"].NewRow();
                        dataSet11.Tables["TestData"].Rows.Add(temptRow);
                    }
                }
                else
                {
                    //不显示和处理正在实验的数据
                    //if (File.Exists(Application.StartupPath + @"\ResumeTestData.xml"))
                    //{
                    //     dataSet11.Tables["TestData"].Rows.Clear();
                    //     dataSet11.Tables["TestData"].ReadXml(Application.StartupPath + @"\ResumeTestData.xml");
                    //     DataTable table = dataSet11.Tables["TestData"];
                    //     for (int i = table.Rows.Count - 1; i >= 0; i--)
                    //     {
                    //          if (table.Rows[i]["实验类型"] is DBNull)
                    //          {
                    //               table.Rows[i].Delete();
                    //          }
                    //     }
                    //}
                }
                if (dataSet11.Tables["TestData"] != null) fg.DataSource = dataSet11.Tables["TestData"];
                OleCon = new OleDbConnection(ContStr);
                if (OleCon.State == ConnectionState.Closed) OleCon.Open();
                string Sql = "SELECT * FROM Configure order by 自动编号";//SELECT * FROM  Configure";
                OleDbCommand cmd = new OleDbCommand(Sql, OleCon);
                dataAdapterConfigure = new OleDbDataAdapter();
                dataAdapterConfigure.SelectCommand = cmd;
                OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(dataAdapterConfigure);
                dataAdapterConfigure.Fill(dataSet11, "Configure");
                Sql = "SELECT * FROM UserTable";
                cmd = new OleDbCommand(Sql, OleCon);
                dataAdapterUser = new OleDbDataAdapter();
                dataAdapterUser.SelectCommand = cmd;
                OleDbCommandBuilder cmdBuilder2 = new OleDbCommandBuilder(dataAdapterUser);
                dataAdapterUser.Fill(dataSet11, "UserTable");

                Sql = "SELECT * FROM SampleTable";
                cmd = new OleDbCommand(Sql, OleCon);
                dataAdapterSampleTable = new OleDbDataAdapter();
                dataAdapterSampleTable.SelectCommand = cmd;
                OleDbCommandBuilder cmdBuilder3 = new OleDbCommandBuilder(dataAdapterSampleTable);
                dataAdapterSampleTable.Fill(dataSet11, "SampleTable");

                OleCon.Close();
                InitFlexGrid();
                return beResumeTest;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public static void FineSampleData(string aa)
        {
            printSample = new DataTable();
            string Sql = "SELECT * FROM SampleTable where 人工编号 = '" + aa + "'";
            OleDbCommand cmd = new OleDbCommand(Sql, OleCon);
            dataAdapterSampleTable = new OleDbDataAdapter();
            dataAdapterSampleTable.SelectCommand = cmd;
            OleDbCommandBuilder cmdBuilder3 = new OleDbCommandBuilder(dataAdapterSampleTable);
            dataAdapterSampleTable.Fill(printSample);
        }

        public static void ReInitDataOprate(DateTime startTime)
        {
            bool beResumeTest = false;
            try
            {
                string Database;
                Database = Application.StartupPath + @"\DataBase\" +  "SDAF" + DateTime.Now.Year.ToString() + ".mdb";
                if (CurrentDataBase != startTime.Year && (string)fg.Tag == "Master")
                {
                    if (!File.Exists(Database))
                    {
                        if (!System.IO.Directory.Exists(Application.StartupPath + @"\DataBase"))
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\DataBase");
                        File.Copy(Application.StartupPath + @"\SDAF.mdb", Database);
                    }
                    CurrentDataBase = startTime.Year;
                    FindDayData();
                    MyTable = dataSet11.Tables["TestData"];
                    dataSet11.Tables["TestData"].Rows.Clear();
                    DataRow temptRow;
                    for (int i = 0; i < 20; i++)
                    {
                        temptRow = dataSet11.Tables["TestData"].NewRow();
                        dataSet11.Tables["TestData"].Rows.Add(temptRow);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FindDayData()
        {
            try
            {
                string Database;
                Database = Application.StartupPath + @"\DataBase\" + "SDAF" + CurrentDataBase.ToString() + ".mdb";
                ContStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + Database + " ; Jet OLEDB:Database Password = service ";
                OleCon = new OleDbConnection(ContStr);
                if (OleCon.State == ConnectionState.Closed) OleCon.Open();
                string Sql = "SELECT * FROM  TestData WHERE TRUE  AND  TestData.[实验日期]  =  #" + DateTime.Now.ToString("yyyy-MM-dd") + "#" + " ORDER BY TestData.[自动编号]";
                OleDbCommand cmd = new OleDbCommand(Sql, OleCon);
                dataAdapterTestData = new OleDbDataAdapter();
                dataAdapterTestData.SelectCommand = cmd;

                if (dataSet11.Tables["TestData"] != null) dataSet11.Tables["TestData"].Clear();
                dataAdapterTestData.Fill(dataSet11, "TestData");
                OleCon.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void FindYearData()
        {
            try
            {
                string Database;
                Database = Application.StartupPath + @"\DataBase\" + "SDAF" + CurrentDataBase.ToString() + ".mdb";
                ContStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + Database + " ; Jet OLEDB:Database Password = service ";
                OleCon = new OleDbConnection(ContStr);
                if (OleCon.State == ConnectionState.Closed) OleCon.Open();
                string Sql = "SELECT * FROM  TestData ORDER BY TestData.[自动编号]";// WHERE TRUE  AND  DataTable.[实验日期]  =  #" + DateTime.Now.ToString("yyyy-MM-dd") + "#" + " ORDER BY DataTable.[自动编号]";
                OleDbCommand cmd = new OleDbCommand(Sql, OleCon);
                dataAdapterTestData = new OleDbDataAdapter();
                dataAdapterTestData.SelectCommand = cmd;
                if (dataSet11.Tables["TestData"] != null) dataSet11.Tables["TestData"].Clear();
                dataAdapterTestData.Fill(dataSet11, "TestData");
                OleCon.Close();
                if (fg.Rows.Count > 1) fg.Row = fg.Rows.Count - 1;
            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //public static void UpdateFlexGrid()
        //{

        //}
        public static void AfterResizeRow()
        {
            try
            {
                if ((string)fg.Tag != "Master" && dataSet11.Tables["Configure"].Columns["数据库显示宽度"] != null)//兼容没有“数据库显示宽度”字段的数据库
                {
                    for (int i = 1; i < fg.Cols.Count; i++)
                    {
                        dataSet11.Tables["Configure"].Rows[i - 1]["数据库显示宽度"] = fg.Cols[i].Width;
                    }
                }
                else
                {
                    for (int i = 1; i < fg.Cols.Count; i++)
                    {
                        dataSet11.Tables["Configure"].Rows[i - 1]["显示宽度"] = fg.Cols[i].Width;
                    }
                }
                dataAdapterConfigure.Update(dataSet11.Tables["Configure"]);
            }
            catch (Exception err)//在数据库和主程序中同时点容易报错
            {
                /* ************** 异常文本 ************** 
                System.Data.DBConcurrencyException: 违反并发性: UpdateCommand 影响了预期 1 条记录中的 0 条。
                   在 System.Data.Common.DbDataAdapter.UpdatedRowStatusErrors(RowUpdatedEventArgs rowUpdatedEvent, BatchCommandInfo[] batchCommands, Int32 commandCount)
                   在 System.Data.Common.DbDataAdapter.UpdatedRowStatus(RowUpdatedEventArgs rowUpdatedEvent, BatchCommandInfo[] batchCommands, Int32 commandCount)
                   在 System.Data.Common.DbDataAdapter.Update(DataRow[] dataRows, DataTableMapping tableMapping)
                   在 System.Data.Common.DbDataAdapter.UpdateFromDataTable(DataTable dataTable, DataTableMapping tableMapping)
                   在 System.Data.Common.DbDataAdapter.Update(DataTable dataTable)
                   在 SDAF.DataOperateLib.DataOperate.AfterResizeRow()
                   在 SDAF.FormView.c1FlexGrid1_AfterResizeColumn(Object sender, RowColEventArgs e)
                   在 C1.Win.C1FlexGrid.C1FlexGridBase.OnAfterResizeColumn(RowColEventArgs e)
                   在 C1.Win.C1FlexGrid.y.ac(MouseEventArgs A_0)
                   在 C1.Win.C1FlexGrid.C1FlexGridBase.OnMouseUp(MouseEventArgs e)
                   在 System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
                   在 System.Windows.Forms.Control.WndProc(Message& m)
                   在 C1.Win.C1FlexGrid.Util.BaseControls.ScrollableControl.WndProc(Message& m)
                   在 System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
                   在 System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
                   在 System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
                */
            }
        }
        public static void InitFlexGrid()
        {
            fg.Cols.Frozen = 1;
            for (int i = 1; i < fg.Cols.Count; i++)
            {
                if (fg.Cols[i].Name == "压应力" || fg.Cols[i].Name == "落高")
                {
                    fg.Cols[i].DataType = typeof(Single);
                    fg.Cols[i].Format = "0.0";
                }
                else if (fg.Cols[i].Name == "药量"|| fg.Cols[i].Name == "温度变化" || fg.Cols[i].Name == "气体变化")
                {
                    fg.Cols[i].DataType = typeof(Single);
                    fg.Cols[i].Format = "0.00";
                }

                //fg.Cols[i].Name == "人工编号" 2014/6/30  去掉可手动选择试样编号的功能
                if ( fg.Cols[i].Name == "备注" || fg.Cols[i].Name == "药量" || fg.Cols[i].Name == "实验结果") 
                    fg.Cols[i].AllowEditing = true;
                else fg.Cols[i].AllowEditing = false;

                fg.Cols[i].TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                fg.Cols[i].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

                fg.Cols[i].Visible = (bool)dataSet11.Tables["Configure"].Rows[i-1]["是否显示"];//Columns["是否显示"];

            }
            if ((string)fg.Tag != "Master" && dataSet11.Tables["Configure"].Columns["数据库显示宽度"] != null)//兼容没有“数据库显示宽度”字段的数据库
            {
                fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.ListBox;     //可选择多行  
                for (int i = 1; i < fg.Cols.Count; i++)
                {
                    fg.Cols[i].Caption = (string)dataSet11.Tables["Configure"].Rows[i - 1]["显示名称"];
                    fg.Cols[i].Width = (int)dataSet11.Tables["Configure"].Rows[i - 1]["数据库显示宽度"];
                }
            }
            else
            {
                fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row ;     //可选择多行  
                for (int i = 1; i < fg.Cols.Count; i++)
                {  
                    fg.Cols[i].Caption = (string)dataSet11.Tables["Configure"].Rows[i - 1]["显示名称"];
                    fg.Cols[i].Width = (int)dataSet11.Tables["Configure"].Rows[i - 1]["显示宽度"];
                }
            }
            if ((string)fg.Tag == "Master")
            {
                //fg.Cols["人工编号"].AllowEditing = false;
                fg.Cols["实验结果"].AllowEditing = true;
            }

            string aa = dataSet11.Tables["SampleTable"].Rows[0]["人工编号"].ToString();
            for (int i = 1; i < dataSet11.Tables["SampleTable"].Rows.Count; i++)
            {
                aa = aa +"|"+ dataSet11.Tables["SampleTable"].Rows[i]["人工编号"].ToString();
            }

            fg.Cols["人工编号"].ComboList = aa;


                fg.Cols["实验结果"].ComboList = "发火|瞎火";
             
           


          
            fg.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;        //行列均可以调整宽度              
            fg.Cols.Frozen = 1;
            fg.Styles.Alternate.BackColor = Color.WhiteSmoke;
            fg.Styles.Frozen.BackColor = fg.Styles.Normal.BackColor;

           fg.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(fg_ValidateEdit);   
        }


         private static void fg_ValidateEdit(object sender, C1.Win.C1FlexGrid.ValidateEditEventArgs e)
         {
       
                 if (fg.Cols[e.Col].Name == "变形温度" || fg.Cols[e.Col].Name == "软化温度" || fg.Cols[e.Col].Name == "半球温度" || fg.Cols[e.Col].Name == "流动温度")
                 {
                    string text = ((TextBox)((C1.Win.C1FlexGrid.C1FlexGrid)sender).Editor).Text.Trim();
                    if (text!=null&&text.Length > 0)  //值可以为空
                    {
                        try
                        {   //值可以为空
                            //if (text.Length == 0)
                            //{
                            //    MessageBox.Show(Resource1.SpaceError, Resource1.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //    e.Cancel = true;
                            //}
                            //else
                            {
                                if (text.Length > 1 && text.Substring(0, 1) == ">") text = text.Substring(1, text.Length - 1);
                                int value = int.Parse(text);
                                if (value >= 500 && value <= 1600) e.Cancel = false;
                                else
                                {
                                    MessageBox.Show(Resource1.InputLimit + " 500～1600  ", Resource1.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    e.Cancel = true;
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show(Resource1.ErrChar, Resource1.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            e.Cancel = true;
                        }
                    }
                 }
        }

        public static void UpdateConfigureData()
        {
            try
            {
                dataAdapterConfigure.Update(dataSet11.Tables["Configure"]);
            }
            catch (DBConcurrencyException errDb)
            {
                //数据库并发错误不处理
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void UpdateUserTable()
        {
            dataAdapterUser.Update(dataSet11.Tables["UserTable"]);
        }

        public static void UpdateTestDataXML()
        {
            try
            {
                dataSet11.Tables["TestData"].WriteXml(Application.StartupPath + @"\ResumeTestData.xml", XmlWriteMode.WriteSchema);
                //      if (GlobalData.BeDebug) GlobalData.frmStatus.WriteLog("实验数据保存到ResumeTestData.xml");
            }
            catch (Exception err)
            {
                 MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void UpdateTestData()
        {
            try
            {
                if ((string)fg.Tag == "Master")
                {
                    DataTable table = dataSet11.Tables["TestData"];
                    for (int i = table.Rows.Count - 1; i >= 0; i--)
                    {
                        if (table.Rows[i]["自动编号"] is DBNull)
                        {
                            table.Rows[i].Delete();
                        }
                        else
                        {
                                    //table.Rows[i]["实验日期"] = DateTime.Now.Date;    //GlobalData.timeStartTest.Date;
                                    //table.Rows[i]["实验时间"] = DateTime.Now.ToLongTimeString();//GlobalData.timeStartTest.ToLongTimeString();
                        }
                    }
                }
                OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(dataAdapterTestData);
                dataAdapterTestData.Update(dataSet11.Tables["TestData"]);
                if (File.Exists(Application.StartupPath + @"\ResumeTestData.xml")) File.Delete(Application.StartupPath + @"\ResumeTestData.xml");
            }
            catch (DBConcurrencyException dbErr)
            {
                //数据库屏蔽这个错误
                if ((string)fg.Tag == "Master") MessageBox.Show(dbErr.Message, Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                if ((string)fg.Tag == "Master")
                {
                    UpdateTestDataXML();
                }
                MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //finally
            //{
            //    if ((string)fg.Tag == "Master")
            //    {
            //        DataRow temptRow;
            //        for (int i = 0; i < 9; i++)
            //        {
            //            temptRow = dataSet11.Tables["TestData"].NewRow();
            //            dataSet11.Tables["TestData"].Rows.Add(temptRow);
            //        }
            //    }
            //}
        }
        public enum SqlOrder
        {
            Find = 1,
            Delete = 2,
            Update = 3
        }
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="DataBase"></param>
        /// <param name="OrderKnd">命令类型（删除，查找，更新）</param>
        /// <returns></returns>
        public static int ExecuteSQL(string sqlstr, string DataBase, SqlOrder OrderKnd)
        {
            int i = 0;
            try
            {
                if (!File.Exists(DataBase))
                {
                    //数据库文件不存在,操作失败!  
                    MessageBox.Show(Resource1.NoDataFile, Resource1.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return i;
                }
                if (OleCon.State == ConnectionState.Open) OleCon.Close();
                ContStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source= " + DataBase + " ; Jet OLEDB:Database Password = service ";
                OleCon.ConnectionString = ContStr;
                if (OleCon.State == ConnectionState.Closed) OleCon.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstr, OleCon);
                if (OrderKnd == SqlOrder.Find)
                {
                    dataAdapterTestData.SelectCommand = cmd;
                    dataSet11.Tables["TestData"].Clear();
                    dataAdapterTestData.Fill(dataSet11, "TestData");
                    if (fg.Rows.Count > 2) fg.Row = fg.Rows.Count - 1;
                }
                else if (OrderKnd == SqlOrder.Update)
                {
                    i = cmd.ExecuteNonQuery();
                }
                else if (OrderKnd == SqlOrder.Delete)
                {
                    i = cmd.ExecuteNonQuery();
                }
                OleCon.Close();
                return i;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), Resource1.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return i;
            }
        }

     
    }
 
 
}
