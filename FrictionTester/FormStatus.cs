using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
namespace FrictionTester
{
     public partial class FormStatus : DockContent 
     {
         StreamWriter streamwriter;
         UInt32  bufferCount;
   
            public FormStatus()
          {
              InitializeComponent();
              bufferCount=0;
              if (!System.IO.Directory.Exists(Application.StartupPath + @"\log"))
                   System.IO.Directory.CreateDirectory(Application.StartupPath + @"\log");
              try
              {
                   streamwriter = File.AppendText(Application.StartupPath + @"\log\Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
              }
              catch (Exception err)
              {
                 MessageBox.Show("出错了，重复启动程序", Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
          }
       
    
          
         public   void  WriteLog(string dataToWrite)
          {
               bufferCount++;
               string temptString = string.Format("{0}  {1}", DateTime.Now.ToLongTimeString(), dataToWrite);
               this.richTextBox1.AppendText(temptString + "\n");
               streamwriter.WriteLine(temptString);
               if(bufferCount%10==0) streamwriter.Flush();
        
          }
          /// <summary>
          /// 
          /// </summary>
          /// <param name="dataToWrite"></param>
          /// <param name="beNormal">beNormal为false时,只写文件不显示 </param>
          public void WriteLog(string dataToWrite,bool beNormal)
          {
               bufferCount++;
               string temptString = string.Format("{0}  {1}", DateTime.Now.ToLongTimeString(), dataToWrite);
              // if (beNormal||GlobalData.BeDebug)
                   this.richTextBox1.AppendText(temptString + "\n");
               streamwriter.WriteLine(temptString);
               if (bufferCount % 10 == 0) streamwriter.Flush();
          }
          public  void WriteLogImmediately(string dataToWrite)
          {
              string temptString = string.Format("{0}  {1}", DateTime.Now.ToLongTimeString(), dataToWrite);
               this.richTextBox1.AppendText(temptString + "\n");
               streamwriter.WriteLine(temptString);
               streamwriter.Flush();
          }
        
     }
}