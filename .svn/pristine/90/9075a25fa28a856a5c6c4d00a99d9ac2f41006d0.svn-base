using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SDAF.DataBase
{
     static class GlobalCofigData
     {
          public static PrintConfigSection PrintConfig;
          public static SystemConfigSection SystemConfig;
          public static Configuration Config;
     
     }

    public class SystemConfigSection : ConfigurationSection
    {

        public SystemConfigSection()
        {
            BackUpInterval = 10;
            AutoBackup = false;
            PassWord = "123456";
            PictureSavePath = System.Windows.Forms.Application.StartupPath + @"\DataBase\Data";
            LastBackUpDateTime = DateTime.Now;
        }


        /// <summary>
        /// 最后一次备份的时间
        /// </summary>
         [ConfigurationProperty("LastBackUpDateTime")]
        public DateTime  LastBackUpDateTime
        {
             get { return (DateTime)this["LastBackUpDateTime"]; }
             set { this["LastBackUpDateTime"] = value; }
        }
        /// <summary>
        /// 自动备份数据库间隔天数
        /// </summary>
        [ConfigurationProperty("BackUpInterval")]
        public int BackUpInterval
        {
            get { return (int)this["BackUpInterval"]; }
            set { this["BackUpInterval"] = value; }
        }
        /// <summary>
        /// 是否自动备份数据库
        /// </summary>
        [ConfigurationProperty("AutoBackup")]
        public bool AutoBackup
        {
            get { return (bool)this["AutoBackup"]; }
            set { this["AutoBackup"] = value; }
        }

        /// <summary>
        /// 用户密码 配置文件保存的密码无效 密码保存在注册表中 和主程序共用密码
        /// </summary>
        [ConfigurationProperty("PassWord")]
        public string PassWord
        {
            get { return (string)this["PassWord"]; }
            set { this["PassWord"] = value; }
        }
         [ConfigurationProperty("PictureSavePath")]
         public string PictureSavePath
         {
              get { return (string)this["PictureSavePath"]; }
              set { this["PictureSavePath"] = value; }
         }  
    
    }

     public class PrintConfigSection : ConfigurationSection
     {

          public PrintConfigSection()
          {
               IsReport = false;
               IsPrintTester = true;
               Tester = "        ";
               IsPrintChecker = true;
               Checker = "        ";
               IsTestOrganization = true;
               TestOrganization = ""; 
                if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US") ReportTitle =   "Test Report";
                             else ReportTitle = "实验报告单";
                if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "en-US") SheetTitle = "Test Report Table";
                             else SheetTitle = "实验报表";

          }
          /// <summary>
          /// 打印类型 true-报告单  false 报表
          /// </summary>
          [ConfigurationProperty("IsReport")]
          public bool IsReport
          {
               get { return (bool)this["IsReport"]; }
               set { this["IsReport"] = value; }
          }
          /// <summary>
          /// 是否打印化验栏
          /// </summary>
          [ConfigurationProperty("IsPrintTester")]
          public bool IsPrintTester
          {
               get { return (bool)this["IsPrintTester"]; }
               set { this["IsPrintTester"] = value; }
          }
          /// <summary>
          /// 化验
          /// </summary>
          [ConfigurationProperty("Tester")]
          public string Tester
          {
               get { return (string)this["Tester"]; }
               set { this["Tester"] = value; }
          }
          /// <summary>
          /// 是否打印审核栏
          /// </summary>
          [ConfigurationProperty("IsPrintChecker")]
          public bool IsPrintChecker
          {
               get { return (bool)this["IsPrintChecker"]; }
               set { this["IsPrintChecker"] = value; }
          }
          /// <summary>
          /// 审核
          /// </summary>
          [ConfigurationProperty("Checker")]
          public string Checker
          {
               get { return (string)this["Checker"]; }
               set { this["Checker"] = value; }
          }
          /// <summary>
          /// 是否打印化验单位栏
          /// </summary>
          [ConfigurationProperty("IsTestOrganization")]
          public bool IsTestOrganization
          {
               get { return (bool)this["IsTestOrganization"]; }
               set { this["IsTestOrganization"] = value; }
          }
          /// <summary>
          /// 化验单位
          /// </summary>
          [ConfigurationProperty("TestOrganization")]
          public string TestOrganization
          {
               get { return (string)this["TestOrganization"]; }
               set { this["TestOrganization"] = value; }
          }
          
          /// <summary>
          /// 报告单标题
          /// </summary>
          [ConfigurationProperty("ReportTitle")]
          public string ReportTitle
          {
               get { return (string)this["ReportTitle"]; }
               set { this["ReportTitle"] = value; }
          }
          /// <summary>
          /// 报表标题
          /// </summary>
          [ConfigurationProperty("SheetTitle")]
          public string SheetTitle
          {
               get { return (string)this["SheetTitle"]; }
               set { this["SheetTitle"] = value; }
          }

     }  
}

