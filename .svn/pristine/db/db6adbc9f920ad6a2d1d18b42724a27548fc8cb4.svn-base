using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SDAF.DataBase
{
     static class Program
     {
          /// <summary>
          /// 应用程序的主入口点。
          /// </summary>
          [STAThread]
          static void Main()
          {
              string directoryPathfile = System.Windows.Forms.Application.StartupPath + "\\hygd.ini";
              if (System.IO.File.Exists(directoryPathfile))
              {
                  SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.HYGD;
              }
               //string directoryPath = System.Windows.Forms.Application.StartupPath + "\\en-US";
               //if (System.IO.Directory.Exists(directoryPath))
               //{
               //   System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
               //}
               //else System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
               String name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
               System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName(name);
               if (p.Length > 1)
               {
                    MessageBox.Show(Properties.Resources.RepeatStart, Properties.Resources.ErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Application.Exit();
                    return;
               }
               else
               {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
               }
          }


       
     }
}