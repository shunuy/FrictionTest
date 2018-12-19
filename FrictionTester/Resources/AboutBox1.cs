using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
namespace FrictionTester
{
    partial class AboutBox1 : Form
    {
        //版本号：V1.02LY 在浏阳把爆发点把位移按钮去掉
        //版本号：V1.03LY 在浏阳调试的新版静电感度     
        //                火焰感度，解决老版本（试验室使用）没有考虑无联网的情况（仍存在试验过程中，开始按钮没有变灰的情况）
        //版本号：V1.04LY 在浏阳完善新版静电感度 
        //版本号：V1.05LY 在浏阳完善新版静电感度 试验基本正常
        //版本号：V1.06CS 
        //静电感度：让从PLC获取的电压反馈值、电压设置值、放电间隙设置值 正常情况不显示，通过Ctrl+D打开显示
        //             增加配置文件，能配置电容、电阻及电压极性
        //V1.07CSAT  V1.07 火焰感度由电路板控制型，改成由PLC控制型 还需要完善
        //仍存在的问题：初始高度可有问题 
        //V1.08LY 更换大连泰思曼电源，由0-5控制改成0-10V控制 50000V控制数为5000
        //爆发点使自动停止有效
        //V1.09LY 解决静电感度一个bug控制电压 
        //V1.10LY 电压置0后，把下一次的预置电压也改小，用以防止误操作带来突然很大的电压 
        //V1.11CS  静电把电压放开到50kV
        ////V1.12CS  爆发点把温度设置由400放开到550
        ////V1.13CS  新版便携一体重新编写，老程序全部替换
        ////V1.14CS 把火焰感度V1.03.02LY更新合并到一个版本，区分plc控制和电路板控制，
        //V1.15 静电修改与完善
        //V1.16 数据库pdf报表完善版
        //v1.17 火焰感度速度调节功能生效
        //v1.18 静电在浏阳现场更改单位等工作
        //v1.19 上一个版本在浏阳调试发现存在发火加步长，不发火减步长的现象。 数据库把数据库文件调为2017年，增加静电的表格处理
        //v1.20 解决置0后下次电压为0的问题
        //v1.21PB v1.07奥托发货版使用正常，新版软件自动预置至目标值无效，只发现上传位移做了处理，V1.21下降也作相应处理。能否解决问题需要验证，在浦北没有验证
        //V1.22 在奥托科技调试成功的版本，（上位机只是把静电设置界面里步长根据试验类型确定单位) 认为高度+10不合适，-10合理一些
       //1.23LZ 在泸州调整火焰感度可以处理负数，高度取消+10 
        //1.24ZY(专用版) 从四川泸州拖回来的老火焰进行改造（原来是用364位传感器，有电路板采集位移。为了以后软件管理维护，改造后采用上海精浦的绝对是拉绳编码器。由上位机直接读位移）
        //这台设备，只有两个串口,二为485接口
        //1.25 醴陵静电专业版 
        


        string Ver = "V1.25醴陵";
        
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox1));
        public AboutBox1()
        {
            InitializeComponent();
            String builderTime="";
            String dllBuilderTime="";
            try
            {
                 String name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                 DateTime modifyDatatime = System.IO.File.GetLastWriteTime(Application.StartupPath + @"\"+name+".exe");
                 builderTime = modifyDatatime.ToString("yyyy-MM-dd hh:mm");// +" " + modifyDatatime.ToShortTimeString();
                 modifyDatatime = System.IO.File.GetLastWriteTime(Application.StartupPath + @"\BitmapProcess.dll");
                 dllBuilderTime = "BitmapProcess: " + modifyDatatime.ToString("yyyy-MM-dd") + " " + modifyDatatime.ToShortTimeString();
            }
            catch (Exception err)
            {
            }
  
             this.labelVersion .Text = String.Format(Ver.ToString()+"   Build:{0}", builderTime);//(String)resources.GetObject("labelVersion.Text") +

        }
        #region 程序集属性访问器
        public string AssemblyTitle
        {
            get
            {
                // 获取此程序集上的所有 Title 属性
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // 如果至少有一个 Title 属性
                if (attributes.Length > 0)
                {
                    // 请选择第一个属性
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // 如果该属性为非空字符串，则将其返回
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // 如果没有 Title 属性，或者 Title 属性为一个空字符串，则返回 .exe 的名称
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        public string AssemblyVersion
        {
             get
             {
                  Version temptVersion = Assembly.GetExecutingAssembly().GetName().Version;
                  return String.Format("V{0}.{1}", temptVersion.Major.ToString(), temptVersion.MinorRevision.ToString("00"));
             }
        }
        public string AssemblyDescription
        {
            get
            {
                // 获取此程序集的所有 Description 属性
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // 如果 Description 属性不存在，则返回一个空字符串
                if (attributes.Length == 0)
                    return "";
                // 如果有 Description 属性，则返回该属性的值
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        public string AssemblyProduct
        {
            get
            {
                // 获取此程序集上的所有 Product 属性
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // 如果 Product 属性不存在，则返回一个空字符串
                if (attributes.Length == 0)
                    return "";
                // 如果有 Product 属性，则返回该属性的值
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        public string AssemblyCopyright
        {
            get
            {
                // 获取此程序集上的所有 Copyright 属性
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // 如果 Copyright 属性不存在，则返回一个空字符串
                if (attributes.Length == 0)
                    return "";
                // 如果有 Copyright 属性，则返回该属性的值
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        public string AssemblyCompany
        {
            get
            {
                // 获取此程序集上的所有 Company 属性
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // 如果 Company 属性不存在，则返回一个空字符串
                if (attributes.Length == 0)
                    return "";
                // 如果有 Company 属性，则返回该属性的值
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
         private void button1_Click(object sender, EventArgs e)
         {
         }
         private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
         {
         }

        private void AboutBox1_Load(object sender, EventArgs e)
        {
            label1.Text = "V" + GlobalData.verSion.ToString();
        }
    }
}
