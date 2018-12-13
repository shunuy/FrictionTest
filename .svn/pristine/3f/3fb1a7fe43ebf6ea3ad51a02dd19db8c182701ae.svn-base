using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SDAF.DataOperateLib;
using C1.C1Preview;
using C1.Win.C1Preview;
using C1.C1Preview.DataBinding;
using System.IO;

namespace SDAF.DataBase
{
     public partial class FormPreview : Form
     {
          int printTableWidth = 0;
         bool beOK = true;
          public FormPreview()
          {
               InitializeComponent();
               this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
          }


         private void c1PreviewControl_ContentPanel_Load(object sender, EventArgs e)
         {
             if (GlobalCofigData.PrintConfig.IsReport)
             {
                 Reportprint(false);
             }
             else
             {
                 TablePrint(false);
             }

         }

         public void TablePrint(bool isPrint)
         {
             try
             {
                 printTableWidth = 0;
                 MakeDoc1(c1PrintDocument1);
                 c1PreviewPane1.ZoomMode = ZoomModeEnum.PageWidth;
                 c1PrintDocument1.Reflow();

                 if (isPrint && beOK)
                 {
                     PrintDialog Pd = new PrintDialog();
                     DialogResult dr = Pd.ShowDialog();
                     if (dr == DialogResult.OK)
                     {
                         try
                         {
                             c1PrintDocument1.Print(Pd.PrinterSettings);
                         }
                         catch (Exception)
                         {
                             MessageBox.Show(Properties.Resources.PrintConfigureErr, Properties.Resources.HintCaption, MessageBoxButtons.OK);
                         }
                     }
                 }
             }
             catch (Exception err)
             {
                 MessageBox.Show(err.Message);
             }
         }
         public void Reportprint(bool isPrint)
         {
              printTableWidth = 0;
              MakeDoc2(c1PrintDocument1);
              c1PrintDocument1.Reflow();

              if (isPrint)
              {
                   PrintDialog Pd = new PrintDialog();
                   DialogResult dr = Pd.ShowDialog();
                   if (dr == DialogResult.OK)
                   {
                        try
                        {
                             c1PrintDocument1.Print(Pd.PrinterSettings);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(Properties.Resources.PrintConfigureErr, Properties.Resources.HintCaption, MessageBoxButtons.OK);
                        }
                   }

              }
         }
#region 打印报表
         private void MakeDoc1(C1PrintDocument doc)
          {
               doc.Clear();
               doc.PageLayout.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
               if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name != "en-US")   doc.PageLayout.PageFooter = new RenderText("第[PageNo]页,　共[PageCount]页");
               else doc.PageLayout.PageFooter = new RenderText("Page [PageNo] of [PageCount]");
               doc.PageLayout.PageFooter.Style.TextAlignHorz = AlignHorzEnum.Right;
               doc.PageLayout.PageFooter.Style.TextAlignVert = AlignVertEnum.Top;
               doc.PageLayout.PageFooter.Height = "1cm";


               RenderTable renderTable= new RenderTable();
               renderTable.Style.GridLines.All = LineDef.Default;
               renderTable.Style.TextAlignHorz = AlignHorzEnum.Center;
               renderTable.Style.TextAlignVert = AlignVertEnum.Bottom;
               renderTable.Style.Font = new Font("宋体",9);
               renderTable.CellStyle.Padding.All = "1mm";
               renderTable.Width = Unit.Auto;
               renderTable.Style.FlowAlign = FlowAlignEnum.Center;
               renderTable.RepeatBordersHorz = false;
               PrintTable(renderTable);
               if (printTableWidth > 190)
               {
                    doc.PageLayout.PageSettings.Landscape = true;
                    doc.PageLayout.PageSettings.TopMargin = new Unit(10, UnitTypeEnum.Mm);
                    doc.PageLayout.PageSettings.BottomMargin = new Unit(5, UnitTypeEnum.Mm);
                    doc.PageLayout.PageSettings.LeftMargin = new Unit(5, UnitTypeEnum.Mm);
                    doc.PageLayout.PageSettings.RightMargin = new Unit(5, UnitTypeEnum.Mm);
               }
               else
               {
                    doc.PageLayout.PageSettings.Landscape = false;
                    doc.PageLayout.PageSettings.TopMargin = new Unit(10, UnitTypeEnum.Mm);
                    doc.PageLayout.PageSettings.BottomMargin = new Unit(5, UnitTypeEnum.Mm);
                    doc.PageLayout.PageSettings.LeftMargin = new Unit(5, UnitTypeEnum.Mm);
                    doc.PageLayout.PageSettings.RightMargin = new Unit(5, UnitTypeEnum.Mm);
               }
               setCaption(renderTable);

               //表头
               RenderText title = new RenderText(GlobalCofigData.PrintConfig.SheetTitle);//(Settings.Default.tablePageHeat);
               title.Style.Font = new Font("宋体", 14);
               title.Style.TextAlignHorz = AlignHorzEnum.Center;
               title.Style.Padding.All = "5mm";
               doc.Body.Children.Add(title);


               RenderText printTestDate = GetPrintTestData();
               RenderTable tableNote = GetPrintNote();
               doc.Body.Children.Add(printTestDate);
               doc.Body.Children.Add(renderTable);
               doc.Body.Children.Add(tableNote);
           }

          private RenderObject CreateObj(string text)
          {
               RenderText result = new RenderText();
               result.Text = text;
               result.Style.Borders.All = new LineDef("1mm", Color.Blue);
               result.Style.TextAlignHorz = AlignHorzEnum.Center;
               result.Style.TextAlignVert = AlignVertEnum.Center;
               result.Style.BackColor = Color.LightSkyBlue;
               result.CanSplitVert = false;
               result.Width = "7cm";
               result.Height = "4cm";
               return result;
          }

          void PrintTable(RenderTable renderTable)
          {
              
               DataTable dtConfigure=DataOperate.dataSet11.Tables["Configure"].Copy();
               DataTable dt = DataOperate.printData;
               

              int col = 0;
              foreach (DataRow r in dtConfigure.Rows)
             {
                // int _width = int.Parse(r["打印宽度"].ToString());
                 try
                 {
                     if ((!(bool)r["是否打印"])) dt.Columns.Remove((string)r[1]);
                 }
                 catch (Exception errO)
                 {
                     MessageBox.Show(errO.Message);//2014-3-28增加
                 }
                
             }
          
              foreach (DataRow r in dtConfigure.Rows)
              {
                  if (((bool)r["是否打印"])) printTableWidth = printTableWidth + (int)r["打印宽度"];
              }


              beOK = true ; 
              int width = printTableWidth;
  
              if (width == 0)
              {
                   MessageBox.Show(Properties.Resources.NoCheckedColume, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                   beOK = false;
                   if (this.Visible)  this.Close();   

              }
              else if (width > 270)
              {
                   MessageBox.Show(Properties.Resources.PrintWidthOverflow, Properties.Resources.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                   beOK = false; 
                   if(this.Visible) this.Close();
              }
             foreach (DataRow r in dtConfigure.Rows)
             {
                 if (((bool)r["是否打印"]))
                 {
                     renderTable.Cols[col].Width = r["打印宽度"].ToString() + "mm"; //new Unit((int)r["打印宽度"], UnitTypeEnum.Mm);
                     col++;
                 }
             }


           //  renderTable.Height = new Unit(100, UnitTypeEnum.Mm);
             int colCount = dt.Columns.Count; 
               int j=0;
               foreach (DataRow r in dt.Rows )
               {
                    for (int i = 0; i < colCount; i++)
                    {

                        if (r[i] is Single)//2014-3-28修改 仍有问题
                        {
                            if (i == DataOperate.试验步长 || i == DataOperate.点火高度) renderTable.Cells[j, i].Text = ((Single)r[i]).ToString("f1");
                            else renderTable.Cells[j, i].Text = ((Single)r[i]).ToString("f2");
                        }
                        else if (r[i] is DateTime) renderTable.Cells[j, i].Text = ((DateTime)r[i]).ToString("yyyy-MM-dd");
                        else renderTable.Cells[j, i].Text = r[i].ToString();
                    }
                    j++;
               }

            
          }

         void setCaption(RenderTable renderTable)
         {
             DataTable dtConfigure = DataOperate.dataSet11.Tables["Configure"];
             renderTable.Rows.Insert(0, 1);
             renderTable.RowGroups[0, 1].Header = TableHeaderEnum.All;
             int col = 0;
             foreach (DataRow r in dtConfigure.Rows)
             {
                 int _width = int.Parse(r["打印宽度"].ToString());

                 if (bool.Parse(r["是否打印"].ToString()) && _width > 0)
                 {
                     renderTable.Cells[0, col].Text = r["打印名称"].ToString();
                     col++;
                 }
             }
        }
#endregion

        #region 打印报告单

          private void MakeDoc2(C1PrintDocument doc)
          {
               doc.Clear();
               doc.PageLayout.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
               if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name != "en-US") doc.PageLayout.PageFooter = new RenderText("第[PageNo]页,　共[PageCount]页");
               else doc.PageLayout.PageFooter = new RenderText("Page [PageNo] of [PageCount]");
               doc.PageLayout.PageSettings.Landscape = false;
               doc.PageLayout.PageSettings.TopMargin = new Unit(10, UnitTypeEnum.Mm);
               doc.PageLayout.PageSettings.BottomMargin = new Unit(5, UnitTypeEnum.Mm);
               doc.PageLayout.PageSettings.LeftMargin = new Unit(30, UnitTypeEnum.Mm);
               doc.PageLayout.PageSettings.RightMargin = new Unit(30, UnitTypeEnum.Mm);
               doc.PageLayout.PageFooter.Style.TextAlignHorz = AlignHorzEnum.Right;
               doc.PageLayout.PageFooter.Style.TextAlignVert = AlignVertEnum.Top;
               doc.PageLayout.PageFooter.Height = "1cm";


              //计算爆炸概率
               int recordCount = DataOperate.printData.Rows.Count;
               for (int i = 0; i < recordCount; i++)
               {

               }


               RenderTable renderTable = new RenderTable();
               renderTable.Style.GridLines.All = LineDef.Default;
               renderTable.Style.TextAlignHorz = AlignHorzEnum.Center;
               renderTable.Style.TextAlignVert = AlignVertEnum.Bottom;
               renderTable.Style.Font = new Font("宋体", 9);
               renderTable.CellStyle.Padding.All = "1mm";
               renderTable.CellStyle.ImageAlign.StretchHorz = false;
               renderTable.CellStyle.ImageAlign.StretchVert = false;
               renderTable.Style.FlowAlign = FlowAlignEnum.Center;
               renderTable.RepeatBordersHorz = false;
               PrintTable2(renderTable, 0);
       
     
               //表头
               RenderText title = new RenderText(GlobalCofigData.PrintConfig.ReportTitle);//(Settings.Default.tablePageHeat);
               title.Style.Font = new Font("宋体", 14);
               title.Style.TextAlignHorz = AlignHorzEnum.Center;
               title.Style.Padding.Top  = "10mm";
               title.Style.Padding.Bottom = "2mm";
               doc.Body.Children.Add(title);

               printTableWidth = 210 - (int)doc.PageLayout.PageSettings.LeftMargin.Value - (int)doc.PageLayout.PageSettings.RightMargin.Value;
               RenderText printTestDate = GetPrintTestData();
               RenderTable tableNote = GetPrintNote();
          //   if (i != recordCount - 1) tableNote.BreakAfter = BreakEnum.Page;

               doc.Body.Children.Add(printTestDate);
               doc.Body.Children.Add(renderTable);
               doc.Body.Children.Add(tableNote);

               //RenderText blank = new RenderText(" ");//(Settings.Default.tablePageHeat);
               //blank.Style.Padding.All = "10mm";
               //doc.Body.Children.Add(blank);

          }

        

          bool PrintTable2(RenderTable renderTable,int index)
          {
               DataRow printRow=DataOperate.printData.Rows[0];
               DataRow printSimple = DataOperate.printSample.Rows[0];

               DataTable dtConfigure = DataOperate.dataSet11.Tables["Configure"].Copy();
               DataTable dt = DataOperate.printData;

               renderTable.Style.MeasureTrailingSpaces = true;
               renderTable.Cols[0].Width = "21mm";
               renderTable.Cols[0].Style.TextAlignHorz = AlignHorzEnum.Right;
             //  renderTable.Cols[0].Style.Padding.Right = "3mm";
               renderTable.Cols[1].Width = "44mm";
               renderTable.Cols[1].Style.TextAlignHorz = AlignHorzEnum.Right;
              // renderTable.Cols[1].Style.TextAlignVert = AlignVertEnum.
               renderTable.Cols[2].Width = "70mm";


               renderTable.Cells[0, 0].Text = "委托 ";
               renderTable.Cells[0, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[1, 0].Text = "单位 ";

               renderTable.Cells[0, 1].SpanRows = 2;



               renderTable.Cells[0, 2].SpanRows = 2;
               renderTable.Cells[0, 2].Text = "委托日期：________年___ 月___日";
               renderTable.Cells[0, 2].Style.TextAlignVert = AlignVertEnum.Center;


               renderTable.Cells[2, 0].Text = "试样";
               renderTable.Cells[2, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[2, 1].SpanCols = 2;
               renderTable.Cells[2, 1].Style.GridLines.Bottom = LineDef.Empty;

                string aa,bb;
                if (printSimple["样品名称"] is DBNull) aa = "____________________";
                else
                {
                    if (printSimple["样品名称"].ToString() == "") aa = "____________________";
                    else
                    {
                        aa = printSimple["样品名称"].ToString();
                        aa = ClassMain.GetStr(aa.PadRight(20), 20);// +"".PadRight(3);
                    }
                }
                if (printSimple["组分或配方"] is DBNull) bb = "____________________";
                else
                {
                    if (printSimple["组分或配方"].ToString() == "") bb = "____________________";
                    else
                    {
                        bb = printSimple["组分或配方"].ToString();
                        bb = ClassMain.GetStr(bb.PadRight(20), 20);// +"".PadRight(3);
                    }
                }
                renderTable.Cells[2, 1].Style.MeasureTrailingSpaces = true;
                renderTable.Cells[2, 1].Text = aa = "名        称：" + aa + "   组分或配方：" + bb;
               renderTable.Cells[3, 0].Text = "名称";
               renderTable.Cells[3, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[3, 1].SpanCols = 2;
               renderTable.Cells[3, 1].Style.GridLines.Bottom = LineDef.Empty;




               if (printSimple["形态"] is DBNull) aa = "____________________";
               else
               {
                   if (printSimple["形态"].ToString() == "") aa = "____________________";
                   else
                   {
                       aa = printSimple["形态"].ToString();
                       aa = ClassMain.GetStr(aa.PadRight(20), 20);// +"".PadRight(3);
                   }
               }
               if (printSimple["粒度"] is DBNull) bb = "____________________"; 
               else
               {
                   if (printSimple["粒度"].ToString() == "") bb = "____________________";
                   else
                   {
                       bb = printSimple["粒度"].ToString();
                       bb = ClassMain.GetStr(bb.PadRight(20), 20);// +"".PadRight(3);
                   }
               }
               renderTable.Cells[3, 1].Style.MeasureTrailingSpaces = true;
               renderTable.Cells[3, 1].Text = "形        态：" + aa + "   粒      度：" + bb;
               renderTable.Cells[4, 0].Text = "和";
               renderTable.Cells[4, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[4, 1].SpanCols = 2;
               renderTable.Cells[4, 1].Style.GridLines.Bottom = LineDef.Empty;


               if (printSimple["生产厂及批号"] is DBNull) aa = "____________________";
               else
               {
                   if (printSimple["生产厂及批号"].ToString() == "") aa = "____________________";
                   else
                   {
                       aa = printSimple["生产厂及批号"].ToString();
                       aa = ClassMain.GetStr(aa.PadRight(20), 20);// +"".PadRight(3);
                   }
               }
               if (printSimple["其它"] is DBNull) bb = "____________________";
               else
               {
                   if (printSimple["其它"].ToString() == "") bb = "____________________";
                   else
                   {
                       bb = printSimple["其它"].ToString();
                       bb = ClassMain.GetStr(bb.PadRight(20), 20);// +"".PadRight(3);
                   }
               }
               renderTable.Cells[4, 1].Style.MeasureTrailingSpaces = true;
               renderTable.Cells[4, 1].Text = "生产厂及批号：" + aa + "   其      它：" + bb;


               renderTable.Cells[5, 0].Text = "特";
               renderTable.Cells[5, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[6, 0].Text = "征";
               renderTable.Cells[5, 1].SpanRows = 2;
               renderTable.Cells[5, 1].SpanCols = 2;


               renderTable.Cells[7, 0].Text = "实验";
               renderTable.Cells[7, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[7, 1].SpanCols = 2;
               renderTable.Cells[7, 1].Style.GridLines.Bottom = LineDef.Empty;
               if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) aa = printRow["落锤质量"].ToString() + "mm";
               else  aa = printRow["落锤质量"].ToString()+"kg";
               aa = ClassMain.GetStr(aa.PadRight(20), 20);
               bb = printRow["药量"].ToString() + "mg";
               bb = ClassMain.GetStr(bb.PadRight(20), 20);

               if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) renderTable.Cells[7, 1].Text = "试 验 步 长：" + aa + "   药      量：" + bb;
               else renderTable.Cells[7, 1].Text = "落 锤 质 量："+aa+"   药      量："+bb;
               renderTable.Cells[8, 0].Text = "条件";
               renderTable.Cells[8, 1].SpanCols = 2;

               aa = printRow["落高"].ToString() + "mm";
               aa = ClassMain.GetStr(aa.PadRight(20), 20);
               bb = "____________________";
               bb = ClassMain.GetStr(bb.PadRight(20), 20);
               if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) renderTable.Cells[8, 1].Text = "初 始 高 度：" + aa + "   其      它：" + bb;
               else  renderTable.Cells[8, 1].Text = "落       高：" + aa + "   其      它：" + bb;





               renderTable.Cells[9, 0].Text = "实验";
               renderTable.Cells[9, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[9, 1].SpanCols = 2;
               renderTable.Cells[9, 1].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[9, 1].Style.TextAlignHorz = AlignHorzEnum.Center;

               if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) renderTable.Cells[9, 1].Text = "试样50%发火高度： " + DataOperate.printSample.Rows[0]["概率"].ToString() + "mm";
               else renderTable.Cells[9, 1].Text = "爆炸概率点估计值 P= " + DataOperate.printSample.Rows[0]["概率"].ToString() + "     ";
               renderTable.Cells[10, 0].Text = "结果";
               renderTable.Cells[10, 1].SpanCols = 2;
               renderTable.Cells[10, 1].Style.TextAlignHorz = AlignHorzEnum.Center;

               if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD) renderTable.Cells[10, 1].Text = "";
              else renderTable.Cells[10, 1].Text = "置信水平为0.95的置信区间（P , P):  ( " + DataOperate.printSample.Rows[0]["置信下限"].ToString() + " , " + DataOperate.printSample.Rows[0]["置信上限"].ToString() + "    )";

               renderTable.Cells[11, 0].Text = "实验";
               renderTable.Cells[11, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[12, 0].Text = "人员";
               renderTable.Cells[12, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[13, 0].Text = "及完";
               renderTable.Cells[13, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[14, 0].Text = "成日";
               renderTable.Cells[14, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[15, 0].Text = "期";
               renderTable.Cells[11, 1].SpanRows = 5;
               renderTable.Cells[11, 1].SpanCols = 2;
               renderTable.Cells[11, 1].Text = "________年___ 月___日";

               renderTable.Cells[16, 0].Text = "复";
               renderTable.Cells[16, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[17, 0].Text = "核";
               renderTable.Cells[17, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[18, 0].Text = "人";
               renderTable.Cells[16, 1].SpanRows = 3;
               renderTable.Cells[16, 1].SpanCols = 2;
               renderTable.Cells[16, 1].Text = "________年___ 月___日";

               renderTable.Cells[19, 0].Text = "负";
               renderTable.Cells[19, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[20, 0].Text = "责";
               renderTable.Cells[20, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[21, 0].Text = "人";
               renderTable.Cells[19, 1].SpanRows = 3;
               renderTable.Cells[19, 1].SpanCols = 2;
               renderTable.Cells[19, 1].Text = "________年___ 月___日";

               renderTable.Cells[22, 0].Text = "承办";
               renderTable.Cells[22, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[23, 0].Text = "单位";
               renderTable.Cells[22, 1].SpanRows = 2;
               renderTable.Cells[22, 1].SpanCols = 2;

               renderTable.Cells[24, 0].Text = "备";
               renderTable.Cells[24, 0].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Cells[25, 0].Text = "注";
               renderTable.Cells[24, 1].SpanRows = 2;
               renderTable.Cells[24, 1].SpanCols = 2;
            
/*
               renderTable.Cells[0, 0].Text = dtConfigure.Rows[DataOperate.自动编号][7].ToString();
               renderTable.Cells[0, 2].Text = dtConfigure.Rows[DataOperate.温度变化][7].ToString();
               renderTable.Cells[1, 0].Text = dtConfigure.Rows[DataOperate.人工编号][7].ToString();
               renderTable.Cells[1, 2].Text = dtConfigure.Rows[DataOperate.气体变化 ][7].ToString();
               renderTable.Cells[2, 0].Text = dtConfigure.Rows[DataOperate.实验类型][7].ToString();
               renderTable.Cells[2, 2].Text = dtConfigure.Rows[DataOperate.实验日期][7].ToString();

               renderTable.Cells[0, 1].Text = printRow[DataOperate.自动编号].ToString();
               renderTable.Cells[0, 3].Text = printRow[DataOperate.温度变化].ToString();
               renderTable.Cells[1, 1].Text = printRow[DataOperate.人工编号].ToString();
               renderTable.Cells[1, 3].Text = printRow[DataOperate.气体变化].ToString();
               renderTable.Cells[2, 1].Text = printRow[DataOperate.实验类型].ToString();
               renderTable.Cells[2, 3].Text = ((DateTime)printRow[DataOperate.实验日期]).ToString("yyyy-MM-dd");

               renderTable.Rows[4].Style.TextAlignHorz = AlignHorzEnum.Left;
               renderTable.Rows[4].Style.TextAlignVert = AlignVertEnum.Bottom;
               renderTable.Rows[4].Style.GridLines.Bottom = LineDef.Empty;
               renderTable.Rows[4].CellStyle.Padding.Bottom = "0.1mm";

     

               renderTable.Cells[4, 0].Text = dtConfigure.Rows[3][7].ToString() + ": " + (printRow[DataOperate.落锤质量]).ToString();
               renderTable.Cells[4, 1].Text = dtConfigure.Rows[4][7].ToString() + ": " + ((Single)printRow[DataOperate.压应力]).ToString("f1");
               renderTable.Cells[4, 2].Text = dtConfigure.Rows[5][7].ToString() + ": " + ((Single)printRow[DataOperate.落高]).ToString("f1");
               renderTable.Cells[4, 3].Text = dtConfigure.Rows[6][7].ToString() + ": " + ((Single)printRow[DataOperate.药量]).ToString("f2");

               renderTable.Rows[5].CellStyle.Padding.Top = "0.1mm";
               renderTable.Rows[5].Height = Unit.Auto;

               C1.C1Preview.RenderImage img1 = new C1.C1Preview.RenderImage(this.c1PrintDocument1);
               C1.C1Preview.RenderImage img2 = new C1.C1Preview.RenderImage(this.c1PrintDocument1);
               C1.C1Preview.RenderImage img3 = new C1.C1Preview.RenderImage(this.c1PrintDocument1);
               C1.C1Preview.RenderImage img4 = new C1.C1Preview.RenderImage(this.c1PrintDocument1);
         

               if (img1.Image != null || img2.Image != null || img3.Image != null || img4.Image != null)
               {
                    renderTable.Cells[5, 0].RenderObject = img1;
                    renderTable.Cells[5, 1].RenderObject = img2;
                    renderTable.Cells[5, 2].RenderObject = img3;
                    renderTable.Cells[5, 3].RenderObject = img4;
               }
               else
               {
                    renderTable.Rows[4].Style.TextAlignHorz = AlignHorzEnum.Center;
                    renderTable.Rows[5].Height = "45mm";
                    renderTable.Cells[5, 0].Text = "  ";
               } 
 */
               return true;
           
          }
          private Bitmap ConvertBitmap(Image  aa)
          {
               Bitmap returnBitmap = new Bitmap(248, 288);
               Color temptColor;
               for (int j = 0; j < 248; j++)
               {
                    //if (j < 23 ) for (int i = 0; i < 144; i++)
                    //{
                    //     temptColor = ((Bitmap)aa).GetPixel(23, i);
                    //     returnBitmap.SetPixel(j, i * 2, temptColor);
                    //     returnBitmap.SetPixel(j, i * 2 + 1, temptColor);

                    //}
                    //else if (j > 224) for (int i = 0; i < 144; i++)
                    //{
                    //     temptColor = ((Bitmap)aa).GetPixel(224, i);
                    //     returnBitmap.SetPixel(j, i * 2, temptColor);
                    //     returnBitmap.SetPixel(j, i * 2 + 1, temptColor);
                    //}
                    //else 
                     for (int i = 0; i < 144; i++)
                    {
                         temptColor = ((Bitmap)aa).GetPixel(j, i);
                         returnBitmap.SetPixel(j, i * 2, temptColor);
                         returnBitmap.SetPixel(j, i * 2 + 1, temptColor);
                    }
               }
               return returnBitmap;
          }
        #endregion

          private RenderTable GetPrintNote()
          {
               RenderTable tableNote = new RenderTable();
               tableNote.Width = Unit.Auto;
               tableNote.Style.GridLines.All = LineDef.Empty;
               tableNote.Style.TextAlignHorz = AlignHorzEnum.Left;
               tableNote.Style.TextAlignVert = AlignVertEnum.Top;
               tableNote.Style.Font = new Font("宋体", 9);
               tableNote.CellStyle.Padding.All = "0.5mm";
               tableNote.CellStyle.Padding.Top = "1mm";
               tableNote.Style.FlowAlign = FlowAlignEnum.Center;
               tableNote.RepeatBordersHorz = false;
               if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name!= "en-US")
               {
                   tableNote.Cols[0].Width = "17mm";
                   int width=0;
                   //if (printTableWidth > 120)
                       width = printTableWidth - 80;
                       if (width < 10) width = 0;
                   //else    width = 40;
                   tableNote.Cols[1].Width = width.ToString() + "mm";
                   tableNote.Cols[2].Width = "13mm";
                   tableNote.Cols[3].Width = "20mm";
                   tableNote.Cols[4].Width = "10mm";
                   tableNote.Cols[5].Width = "20mm";
               }
               else
               {
                   tableNote.Cols[0].Width = "23mm";
                   int width = 0;

         
                       width = printTableWidth - 90;
                       if (width < 10) width = 0;
                       tableNote.Cols[1].Width = width.ToString() + "mm";
                       tableNote.Cols[2].Width = "13mm";
                       tableNote.Cols[3].Width = "20mm";
                       tableNote.Cols[4].Width = "14mm";
                       tableNote.Cols[5].Width = "20mm";
             
                  
               }
               if (GlobalCofigData.PrintConfig.IsTestOrganization)
               {
                   tableNote.Cells[0, 0].Text = Properties.Resources.TestCormpany;
                    tableNote.Cells[0, 1].Text = GlobalCofigData.PrintConfig.TestOrganization;
               }
               else
               {
                    tableNote.Cells[0, 0].Text = "";
                    tableNote.Cells[0, 1].Text = "";
               }
               if (GlobalCofigData.PrintConfig.IsPrintTester)
               {
                   tableNote.Cells[0, 2].Text = Properties.Resources.Tester;
                    tableNote.Cells[0, 3].Text = GlobalCofigData.PrintConfig.Tester;
               }
               else
               {
                    tableNote.Cells[0, 2].Text = "";
                    tableNote.Cells[0, 3].Text = "";
               }
               if (GlobalCofigData.PrintConfig.IsPrintChecker)
               {
                   tableNote.Cells[0, 4].Text = Properties.Resources.Auditor;
                    tableNote.Cells[0, 5].Text = GlobalCofigData.PrintConfig.Checker;
               }
               else
               {
                    tableNote.Cells[0, 4].Text = "";
                    tableNote.Cells[0, 5].Text = "";
               }
                return tableNote;
          }

          private RenderText GetPrintTestData()
          {
              RenderText testDate = new RenderText(Properties.Resources.PrintDate + DateTime.Today.ToString("yyyy-MM-dd"));//.PadLeft(printTableWidth / 2) + DateTime.Today.ToString("yyyy-MM-dd"));
               testDate.Style.Font = new Font("宋体", 9);
               testDate.Style.TextAlignHorz = AlignHorzEnum.Right;
               testDate.Style.Padding.All = "1mm";
               testDate.Width = printTableWidth.ToString() + "mm";
               testDate.Style.FlowAlign = FlowAlignEnum.Center;
               return testDate;
          }

         private void FormPreview_FormClosing(object sender, FormClosingEventArgs e)
         {
          }
   }

}