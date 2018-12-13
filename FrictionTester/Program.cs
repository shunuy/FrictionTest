using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrictionTester
{
    static class Program
    {
 

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string directoryPathfile = System.Windows.Forms.Application.StartupPath + "\\hygd.ini";
                string directoryPathfile1 = System.Windows.Forms.Application.StartupPath + "\\jdgd.ini";
                string directoryPathfile2 = System.Windows.Forms.Application.StartupPath + "\\zjmc.ini";
                SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.BFD;   
                if (System.IO.File.Exists(directoryPathfile))
                {
                    SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.HYGD;
                }
                else if(System.IO.File.Exists(directoryPathfile1))
                {
                    SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.JDGD;
                }
                else if (System.IO.File.Exists(directoryPathfile2))
                {
                    SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.ZJMC;
                }
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
#if DEBUG
                  //  SDAF.DataOperateLib.DataOperate.EquipMentType = SDAF.DataOperateLib.EquipMentTypes.JDGD;
                  

#endif



                    if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.HYGD)
                    {
                      
                        Application.Run(new FormMainHYGD());

                   
                        // private static readonly WebUtil webUtil = new WebUtil("http://" + SERVER_IP + ":8080/LabManage/api", USER_NAME, PASSWORD);

                    }
                    else if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.BFD) Application.Run(new FormMainBFD());
                    else if (SDAF.DataOperateLib.DataOperate.EquipMentType == SDAF.DataOperateLib.EquipMentTypes.ZJMC) Application.Run(new FormMainZJMC());
                    //Application.Run(new FormMainBFD());
                    else Application.Run(new FormMainGDGD());
                    ////FormMain()netgdsystem NetServerStart
                    //Application.Run(new netgdsystem())
                        GlobalCofigData.Config.Save(System.Configuration.ConfigurationSaveMode.Modified);
                }
  
        

    }
    }

}