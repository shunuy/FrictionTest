using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SDAF.DataOperateLib;
using System.IO;


namespace FrictionTester
{
    public partial class FormFriction : DockContent 
    {
        int isHaveStartNumber = -1;

        public FormFriction()
        {
            InitializeComponent();
        }

        private void FormFriction_Load(object sender, EventArgs e)
        {
           DataOperate.InitDataOprate(c1FlexGrid1);
        }

        private void c1FlexGrid1_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (c1FlexGrid1.Cols[e.Col].Name == "人工编号")
            {
                //if (!(c1FlexGrid1.Rows[e.Row]["位置编号"] is DBNull))
                {
                 //   int index = int.Parse(c1FlexGrid1.Rows[e.Row]["位置编号"].ToString());
                //    if (!(c1FlexGrid1.Rows[e.Row]["人工编号"] is DBNull) && !(c1FlexGrid1.Rows[e.Row]["实验类型"] is DBNull)) userControlList[index].Caption = c1FlexGrid1.Rows[e.Row]["人工编号"].ToString();
                }
            }


            if (c1FlexGrid1.Cols[e.Col].Name == "实验结果")
            {

                if (GlobalCofigData.SystemConfig.TestType == TestTypes.预备试验)
                {

                    GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.PrepareH0;



                }
                else
                {
                    GlobalCofigData.SystemConfig.SerialNo = GlobalCofigData.SystemConfig.SerialNo + 1;
                    if (c1FlexGrid1.Rows[e.Row]["实验结果"].ToString() == "发火") GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance + GlobalCofigData.SystemConfig.Step;
                    else GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance - GlobalCofigData.SystemConfig.Step;

                }

            }
        }

        private void c1FlexGrid1_AfterResizeColumn(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            DataOperate.AfterResizeRow();
        }

        private void c1FlexGrid1_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                if (c1FlexGrid1.Rows[e.Row]["自动编号"] is DBNull && c1FlexGrid1.Cols[e.Col].Name != "药量") e.Cancel = true;
                else if(c1FlexGrid1.Cols[e.Col].Name == "实验结果" &&!(c1FlexGrid1.Rows[e.Row]["实验结果"] is DBNull) ) e.Cancel = true;
                else {
                    if (c1FlexGrid1.Cols[e.Col].Name == "药量" )
                    {
                        //if (GlobalCofigData.SystemConfig.IdentifyType == IdentifyTypes.自动识别) e.Cancel = true;
                        //else
                        {
                            c1FlexGrid1.Editor = numberTextBox2;
                            numberTextBox2.MaxLength = 5;
                            numberTextBox2.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.Double;
                            numberTextBox2.DisFormat = "0.00";
                            numberTextBox2.IsCheckValue = false;
                        }
                    }
                    //else if (c1FlexGrid1.Cols[e.Col].Name == "人工编号")
                    //{
                    //    c1FlexGrid1.Editor = numberTextBox2;
                    //    numberTextBox2.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.String;
                    //    numberTextBox2.MaxLength = (short)DataOperate.dataSet11.Tables["Configure"].Rows[DataOperate.人工编号]["最大长度"];
                    //}
                    else if (c1FlexGrid1.Cols[e.Col].Name == "备注")
                    {
                        c1FlexGrid1.Editor = numberTextBox2;
                        numberTextBox2.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.String;
                        numberTextBox2.MaxLength = (short)DataOperate.dataSet11.Tables["Configure"].Rows[DataOperate.备注]["最大长度"];
                    }
                    //取消列编辑功能
                    //else if (c1FlexGrid1.Cols[e.Col].Name == "位置编号")
                    //{
                    //     if ((GlobalCofigData.SystemConfig.IdentifyType == IdentifyTypes.自动识别)||(c1FlexGrid1.Rows[e.Row - 1]["位置编号"] is DBNull) || GlobalData.SystemStatus == SystemStatuses.BeTesting || !(c1FlexGrid1.Rows[e.Row]["实验类型"] is DBNull)) e.Cancel = true;
                    //     else c1FlexGrid1.Editor.LostFocus += new System.EventHandler(this.c1FlexGrid1_Editor_Leave);
                    //}
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString().ToString(),Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void c1FlexGrid1_Validated(object sender, EventArgs e)
        {
 
           
        }

        private void c1FlexGrid1_ValidateEdit(object sender, C1.Win.C1FlexGrid.ValidateEditEventArgs e)
        {
            //if (c1FlexGrid1.Cols[e.Col].Name == "人工编号")
            //{
            //    if (c1FlexGrid1.Editor.Text == "") return;
            //    else
            //    {
            //        if (GlobalData.TestNo == "") GlobalData.TestNo = GetAutoNumber();
            //        c1FlexGrid1.Rows[e.Row]["自动编号"] = GetAutoNumber();// GlobalData.TestNo + dec.ToString();
           
            //    }
            //}


            //if (c1FlexGrid1.Cols[e.Col].Name == "实验结果")
            //{

            //    if (GlobalCofigData.SystemConfig.TestType == TestTypes.预备试验)
            //    {
                 
            //            GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.PrepareH0;



            //    }
            //    else
            //    {
            //         GlobalCofigData.SystemConfig.SerialNo = GlobalCofigData.SystemConfig.SerialNo + 1;
            //         if( c1FlexGrid1.Rows[e.Row]["实验结果"].ToString()=="发火")      GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance + GlobalCofigData.SystemConfig.Step ;
            //         else GlobalCofigData.SystemConfig.TargetDistance = GlobalCofigData.SystemConfig.TargetDistance - GlobalCofigData.SystemConfig.Step;

            //    }

            //}
        }


        public void StartTest()
        {
            if (GlobalData.TestNo == "") GlobalData.TestNo = GetAutoNumber();
            DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["自动编号"] = GetAutoNumber();// GlobalData.TestNo + dec.ToString();
            DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验日期"] = GlobalData.timeStartTest.Date;
            DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验时间"] = GlobalData.timeStartTest.ToLongTimeString();
           // DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.点火高度] = GlobalCofigData.SystemConfig.


            ////V1.14CS 
            if(SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.BFD ) DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.试验步长] = GlobalData.MainTemperature;
            else         DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.试验步长] = GlobalCofigData.SystemConfig.Step;
            DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.点火高度] = GlobalCofigData.SystemConfig.TargetDistance;

         
            DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.序号] = GlobalCofigData.SystemConfig.SerialNo;

            if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.BFD) DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.初始高度] = GlobalData.targetTemperature; 
            else
            {
                    if (GlobalCofigData.SystemConfig.TestType == TestTypes.预备试验)
                    {
                        DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.初始高度] = GlobalCofigData.SystemConfig.PrepareH0;
                    }
                    else
                    {
                        DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.初始高度] = GlobalCofigData.SystemConfig.H0;
                    }
            }
            DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.点火高度] = GlobalCofigData.SystemConfig.TargetDistance;



            DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["实验员"] = GlobalCofigData.SystemConfig.UserName;
            DataOperate.MyTable.Rows[GlobalData.DataRowIndex][DataOperate.试验阶段] = GlobalCofigData.SystemConfig.TestType.ToString();
            if(GlobalCofigData.SystemConfig.SampleNo!="") DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["人工编号"] = GlobalCofigData.SystemConfig.SampleNo;

            try
            {
              //  DataOperate.MyTable.Rows[GlobalData.DataRowIndex]["摆锤角度"] = GlobalCofigData.SystemConfig.FrictionAngle;
            }
            catch (Exception err)
            {
            }

            c1FlexGrid1.Refresh();
    
        }

        public void StopTest()
        {
            //c1FlexGrid1.Rows[GlobalData.DataRowIndex].Selected = false;
            //c1FlexGrid1.Rows[GlobalData.DataRowIndex + 1].Selected = true;
  
        }

        public void C1_Update()
        {
            c1FlexGrid1.Focus();
            c1FlexGrid1.FinishEditing(true);
            numberTextBox2.Visible = false;
           // c1FlexGrid1.fini
        }

        private string GetAutoNumber()
        {
            //读取自动编号
            string str = null;

            DateTime dTime;
            DateTime lastTime;
            //if (GlobalCofigData.SystemConfig.IdentifyType == IdentifyTypes.人工识别) dTime = DateTime.Now;
            //else
            dTime = GlobalData.timeStartTest;
            int SysNumbr;
            try
            {
                string pathStr = Application.StartupPath + @"\TestAtuoNumber.sdaf";
                if (!File.Exists(pathStr))//没有自动编号文件则新建
                {
                    using (StreamWriter sw = File.AppendText(pathStr))
                    {
                        SysNumbr = 1;
                        sw.WriteLine(dTime.ToString("yyyy-MM-dd"));
                        sw.WriteLine(SysNumbr);
                        sw.Flush();//if house price is 
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamReader sr = new StreamReader(pathStr))
                    {
                        try
                        {
                            lastTime = DateTime.Parse(sr.ReadLine());
                            SysNumbr = int.Parse(sr.ReadLine());
                            sr.Close();
                        }
                        catch (Exception)
                        {
                            File.Delete(pathStr);
                            //生成自动编号出错
                            MessageBox.Show(Properties.Resources.BuildAutoIDError, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        //是否为同一天
                        if (DateTime.Parse(dTime.ToString("yyyy-MM-dd")) != lastTime)
                        {
                            using (StreamWriter sw = new StreamWriter(pathStr))
                            {
                                SysNumbr = 1;//序列号
                                sw.WriteLine(dTime.ToString("yyyy-MM-dd"));
                                sw.WriteLine(SysNumbr);
                                sw.Flush();
                                sw.Close();
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = new StreamWriter(pathStr))
                            {
                                SysNumbr++;
                                sw.WriteLine(dTime.ToString("yyyy-MM-dd"));
                                sw.WriteLine(SysNumbr);//
                                sw.Flush();
                                sw.Close();
                            }
                        }
                    }
                }
                if (isHaveStartNumber == -1) isHaveStartNumber = SysNumbr - 1;
            }
            catch (Exception)
            {

                MessageBox.Show(Properties.Resources.BuildAutoIDError, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            str = SysNumbr.ToString("d4");
            return str = dTime.ToString("yyyyMMdd") + str;
             

        }

        private void ResetAutoNumber()
        {
            DateTime dTime;
            dTime = GlobalData.timeStartTest;
            int SysNumbr;
            if (isHaveStartNumber == -1) SysNumbr = 0;
            else SysNumbr = isHaveStartNumber;
            try
            {
                string pathStr = Application.StartupPath + @"\TestAtuoNumber.sdaf";
                if (File.Exists(pathStr))//没有自动编号文件则新建
                {
                    using (StreamWriter sw = new StreamWriter(pathStr))
                    {
                        sw.WriteLine(dTime.ToString("yyyy-MM-dd"));
                        sw.WriteLine(SysNumbr);
                        sw.Flush();
                        sw.Close();
                    }
                }
                isHaveStartNumber = -1;
            }
            catch (Exception)
            {
                MessageBox.Show(Properties.Resources.BuildAutoIDError, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void c1FlexGrid1_StartDrag(object sender, DragEventArgs e)
        {

        }

        private void c1FlexGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            C1.Win.C1FlexGrid.C1FlexGrid temp;
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is C1.Win.C1FlexGrid.C1FlexGrid )
                {
                    temp = (C1.Win.C1FlexGrid.C1FlexGrid)sender;
                    if (temp.ColSel == 7)
                    {
                        temp.Rows[temp.RowSel][7] = temp.Rows[temp.RowSel - 1][7];
                      
                    }
                    if (temp.ColSel == 2)
                    {
                        temp.Rows[temp.RowSel][2] = temp.Rows[temp.RowSel - 1][2];

                    }
                }
            }

        }

        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {

        }

        private void FormFriction_KeyDown(object sender, KeyEventArgs e)
        {
            int aa = 100;
        }
    }
}