using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Advantech.Adam;
using System.Net.Sockets;
namespace FrictionTester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Adam6024 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtCurrentValue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelDO;
		private System.Windows.Forms.TextBox txtDOCh0;
		private System.Windows.Forms.Button btnDOCh1;
		private System.Windows.Forms.Button btnDOCh0;
		private System.Windows.Forms.TextBox txtDOCh1;
		private System.Windows.Forms.Panel panelOutput;
		private System.Windows.Forms.Button btnApplyOutput;
		private System.Windows.Forms.TextBox txtOutputValue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblHigh;
		private System.Windows.Forms.Label lblLow;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxAOChannel;
		private System.Windows.Forms.TextBox txtModule;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtReadCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Panel panelDI;
		private System.Windows.Forms.TextBox txtDICh0;
		private System.Windows.Forms.Button btnCh1;
		private System.Windows.Forms.Button btnCh0;
		private System.Windows.Forms.TextBox txtDICh1;
		private System.Windows.Forms.TextBox txtCh5;
		private System.Windows.Forms.CheckBox chkboxCh5;
		private System.Windows.Forms.TextBox txtCh4;
		private System.Windows.Forms.CheckBox chkboxCh4;
		private System.Windows.Forms.TextBox txtCh3;
		private System.Windows.Forms.CheckBox chkboxCh3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox txtCh2;
		private System.Windows.Forms.CheckBox chkboxCh2;
		private System.Windows.Forms.TextBox txtCh1;
		private System.Windows.Forms.CheckBox chkboxCh1;
		private System.Windows.Forms.TextBox txtCh0;
		private System.Windows.Forms.CheckBox chkboxCh0;
		private System.ComponentModel.IContainer components;

		private int  m_iCount;
		private int m_iAiTotal, m_iAoTotal, m_iDiTotal, m_iDoTotal;
		private bool[] m_bChEnabled;
		private byte[] m_byAiRange, m_byAoRange;
		private bool m_bStart;
		private AdamSocket  adamModbus;
		private Adam6000Type m_Adam6000Type;
		private string m_szIP;
		private int m_iPort;

		public Adam6024()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			int iIdx;

			m_bStart = false;			// the action stops at the beginning
			m_szIP = "10.0.0.1";	// modbus slave IP address
			m_iPort = 502;				// modbus TCP port is 502
			adamModbus = new AdamSocket();
			adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP

			m_Adam6000Type = Adam6000Type.Adam6024; // the sample is for ADAM-6050

			// modbus current list view item
			m_iAiTotal = AnalogInput.GetChannelTotal(m_Adam6000Type);
			m_iDiTotal = DigitalInput.GetChannelTotal(m_Adam6000Type);
			m_iAoTotal = AnalogOutput.GetChannelTotal(m_Adam6000Type);
			m_iDoTotal = DigitalOutput.GetChannelTotal(m_Adam6000Type);

			m_bChEnabled = new bool[m_iAiTotal];
			m_byAiRange = new byte[m_iAiTotal];
			m_byAoRange = new byte[m_iAoTotal];

			for (iIdx=0; iIdx<m_iAoTotal; iIdx++)
			{
				//
				cbxAOChannel.Items.Add(iIdx.ToString());
				//
			}	
			cbxAOChannel.SelectedIndex = -1;

			txtModule.Text = m_Adam6000Type.ToString();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.txtCurrentValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDO = new System.Windows.Forms.Panel();
            this.txtDOCh0 = new System.Windows.Forms.TextBox();
            this.btnDOCh1 = new System.Windows.Forms.Button();
            this.btnDOCh0 = new System.Windows.Forms.Button();
            this.txtDOCh1 = new System.Windows.Forms.TextBox();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAOChannel = new System.Windows.Forms.ComboBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelDI = new System.Windows.Forms.Panel();
            this.txtDICh0 = new System.Windows.Forms.TextBox();
            this.btnCh1 = new System.Windows.Forms.Button();
            this.btnCh0 = new System.Windows.Forms.Button();
            this.txtDICh1 = new System.Windows.Forms.TextBox();
            this.txtCh5 = new System.Windows.Forms.TextBox();
            this.chkboxCh5 = new System.Windows.Forms.CheckBox();
            this.txtCh4 = new System.Windows.Forms.TextBox();
            this.chkboxCh4 = new System.Windows.Forms.CheckBox();
            this.txtCh3 = new System.Windows.Forms.TextBox();
            this.chkboxCh3 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtCh2 = new System.Windows.Forms.TextBox();
            this.chkboxCh2 = new System.Windows.Forms.CheckBox();
            this.txtCh1 = new System.Windows.Forms.TextBox();
            this.chkboxCh1 = new System.Windows.Forms.CheckBox();
            this.txtCh0 = new System.Windows.Forms.TextBox();
            this.chkboxCh0 = new System.Windows.Forms.CheckBox();
            this.panelDO.SuspendLayout();
            this.panelOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panelDI.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCurrentValue
            // 
            this.txtCurrentValue.Location = new System.Drawing.Point(269, 138);
            this.txtCurrentValue.Name = "txtCurrentValue";
            this.txtCurrentValue.ReadOnly = true;
            this.txtCurrentValue.Size = new System.Drawing.Size(179, 25);
            this.txtCurrentValue.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 29);
            this.label5.TabIndex = 25;
            this.label5.Text = "当前值:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 28);
            this.label1.TabIndex = 26;
            this.label1.Text = "输出";
            // 
            // panelDO
            // 
            this.panelDO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelDO.Controls.Add(this.txtDOCh0);
            this.panelDO.Controls.Add(this.btnDOCh1);
            this.panelDO.Controls.Add(this.btnDOCh0);
            this.panelDO.Controls.Add(this.txtDOCh1);
            this.panelDO.Enabled = false;
            this.panelDO.Location = new System.Drawing.Point(589, 176);
            this.panelDO.Name = "panelDO";
            this.panelDO.Size = new System.Drawing.Size(243, 183);
            this.panelDO.TabIndex = 27;
            // 
            // txtDOCh0
            // 
            this.txtDOCh0.Location = new System.Drawing.Point(103, 39);
            this.txtDOCh0.Name = "txtDOCh0";
            this.txtDOCh0.Size = new System.Drawing.Size(128, 25);
            this.txtDOCh0.TabIndex = 0;
            // 
            // btnDOCh1
            // 
            this.btnDOCh1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnDOCh1.Location = new System.Drawing.Point(13, 105);
            this.btnDOCh1.Name = "btnDOCh1";
            this.btnDOCh1.Size = new System.Drawing.Size(76, 30);
            this.btnDOCh1.TabIndex = 1;
            this.btnDOCh1.Text = "DO 1";
            this.btnDOCh1.UseVisualStyleBackColor = false;
            this.btnDOCh1.Click += new System.EventHandler(this.btnDOCh1_Click);
            // 
            // btnDOCh0
            // 
            this.btnDOCh0.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnDOCh0.Location = new System.Drawing.Point(13, 39);
            this.btnDOCh0.Name = "btnDOCh0";
            this.btnDOCh0.Size = new System.Drawing.Size(76, 28);
            this.btnDOCh0.TabIndex = 2;
            this.btnDOCh0.Text = "DO 0";
            this.btnDOCh0.UseVisualStyleBackColor = false;
            this.btnDOCh0.Click += new System.EventHandler(this.btnDOCh0_Click);
            // 
            // txtDOCh1
            // 
            this.txtDOCh1.Location = new System.Drawing.Point(103, 105);
            this.txtDOCh1.Name = "txtDOCh1";
            this.txtDOCh1.Size = new System.Drawing.Size(128, 25);
            this.txtDOCh1.TabIndex = 3;
            // 
            // panelOutput
            // 
            this.panelOutput.BackColor = System.Drawing.Color.SkyBlue;
            this.panelOutput.Controls.Add(this.btnApplyOutput);
            this.panelOutput.Controls.Add(this.txtOutputValue);
            this.panelOutput.Controls.Add(this.label4);
            this.panelOutput.Controls.Add(this.lblHigh);
            this.panelOutput.Controls.Add(this.lblLow);
            this.panelOutput.Controls.Add(this.trackBar1);
            this.panelOutput.Controls.Add(this.label2);
            this.panelOutput.Controls.Add(this.cbxAOChannel);
            this.panelOutput.Enabled = false;
            this.panelOutput.Location = new System.Drawing.Point(13, 176);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(576, 183);
            this.panelOutput.TabIndex = 28;
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnApplyOutput.Location = new System.Drawing.Point(384, 135);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(179, 37);
            this.btnApplyOutput.TabIndex = 0;
            this.btnApplyOutput.Text = "输出应用";
            this.btnApplyOutput.UseVisualStyleBackColor = false;
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(192, 144);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.ReadOnly = true;
            this.txtOutputValue.Size = new System.Drawing.Size(179, 25);
            this.txtOutputValue.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "输出电压值:";
            // 
            // lblHigh
            // 
            this.lblHigh.Location = new System.Drawing.Point(473, 58);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(90, 28);
            this.lblHigh.TabIndex = 3;
            this.lblHigh.Text = "高";
            this.lblHigh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLow
            // 
            this.lblLow.Location = new System.Drawing.Point(13, 58);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(90, 28);
            this.lblLow.TabIndex = 4;
            this.lblLow.Text = "低";
            this.lblLow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 16;
            this.trackBar1.Location = new System.Drawing.Point(39, 19);
            this.trackBar1.Maximum = 4096;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(498, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickFrequency = 256;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "通道类型:";
            // 
            // cbxAOChannel
            // 
            this.cbxAOChannel.Location = new System.Drawing.Point(192, 96);
            this.cbxAOChannel.Name = "cbxAOChannel";
            this.cbxAOChannel.Size = new System.Drawing.Size(179, 23);
            this.cbxAOChannel.TabIndex = 7;
            this.cbxAOChannel.SelectedIndexChanged += new System.EventHandler(this.cbxAOChannel_SelectedIndexChanged);
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(269, 23);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(282, 25);
            this.txtModule.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(25, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "设备名：";
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(269, 62);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.Size = new System.Drawing.Size(282, 25);
            this.txtReadCount.TabIndex = 31;
            this.txtReadCount.Text = "0";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(25, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 23);
            this.label6.TabIndex = 32;
            this.label6.Text = "采样计数：";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(589, 23);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(115, 28);
            this.buttonStart.TabIndex = 33;
            this.buttonStart.Text = "连接...";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelDI
            // 
            this.panelDI.BackColor = System.Drawing.Color.SkyBlue;
            this.panelDI.Controls.Add(this.txtDICh0);
            this.panelDI.Controls.Add(this.btnCh1);
            this.panelDI.Controls.Add(this.btnCh0);
            this.panelDI.Controls.Add(this.txtDICh1);
            this.panelDI.Location = new System.Drawing.Point(589, 406);
            this.panelDI.Name = "panelDI";
            this.panelDI.Size = new System.Drawing.Size(243, 107);
            this.panelDI.TabIndex = 34;
            // 
            // txtDICh0
            // 
            this.txtDICh0.Location = new System.Drawing.Point(103, 19);
            this.txtDICh0.Name = "txtDICh0";
            this.txtDICh0.Size = new System.Drawing.Size(128, 25);
            this.txtDICh0.TabIndex = 0;
            // 
            // btnCh1
            // 
            this.btnCh1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnCh1.Enabled = false;
            this.btnCh1.Location = new System.Drawing.Point(13, 67);
            this.btnCh1.Name = "btnCh1";
            this.btnCh1.Size = new System.Drawing.Size(76, 29);
            this.btnCh1.TabIndex = 1;
            this.btnCh1.Text = "DI 1";
            this.btnCh1.UseVisualStyleBackColor = false;
            // 
            // btnCh0
            // 
            this.btnCh0.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnCh0.Enabled = false;
            this.btnCh0.Location = new System.Drawing.Point(13, 19);
            this.btnCh0.Name = "btnCh0";
            this.btnCh0.Size = new System.Drawing.Size(76, 29);
            this.btnCh0.TabIndex = 2;
            this.btnCh0.Text = "DI 0";
            this.btnCh0.UseVisualStyleBackColor = false;
            // 
            // txtDICh1
            // 
            this.txtDICh1.Location = new System.Drawing.Point(103, 67);
            this.txtDICh1.Name = "txtDICh1";
            this.txtDICh1.Size = new System.Drawing.Size(128, 25);
            this.txtDICh1.TabIndex = 3;
            // 
            // txtCh5
            // 
            this.txtCh5.Location = new System.Drawing.Point(409, 483);
            this.txtCh5.Name = "txtCh5";
            this.txtCh5.ReadOnly = true;
            this.txtCh5.Size = new System.Drawing.Size(154, 25);
            this.txtCh5.TabIndex = 35;
            // 
            // chkboxCh5
            // 
            this.chkboxCh5.Enabled = false;
            this.chkboxCh5.Location = new System.Drawing.Point(307, 483);
            this.chkboxCh5.Name = "chkboxCh5";
            this.chkboxCh5.Size = new System.Drawing.Size(90, 30);
            this.chkboxCh5.TabIndex = 36;
            this.chkboxCh5.Text = "通道5";
            // 
            // txtCh4
            // 
            this.txtCh4.Location = new System.Drawing.Point(409, 445);
            this.txtCh4.Name = "txtCh4";
            this.txtCh4.ReadOnly = true;
            this.txtCh4.Size = new System.Drawing.Size(154, 25);
            this.txtCh4.TabIndex = 37;
            // 
            // chkboxCh4
            // 
            this.chkboxCh4.Enabled = false;
            this.chkboxCh4.Location = new System.Drawing.Point(307, 445);
            this.chkboxCh4.Name = "chkboxCh4";
            this.chkboxCh4.Size = new System.Drawing.Size(90, 29);
            this.chkboxCh4.TabIndex = 38;
            this.chkboxCh4.Text = "通道4";
            // 
            // txtCh3
            // 
            this.txtCh3.Location = new System.Drawing.Point(409, 406);
            this.txtCh3.Name = "txtCh3";
            this.txtCh3.ReadOnly = true;
            this.txtCh3.Size = new System.Drawing.Size(154, 25);
            this.txtCh3.TabIndex = 39;
            // 
            // chkboxCh3
            // 
            this.chkboxCh3.Enabled = false;
            this.chkboxCh3.Location = new System.Drawing.Point(307, 406);
            this.chkboxCh3.Name = "chkboxCh3";
            this.chkboxCh3.Size = new System.Drawing.Size(90, 30);
            this.chkboxCh3.TabIndex = 40;
            this.chkboxCh3.Text = "通道3";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 27);
            this.label3.TabIndex = 41;
            this.label3.Text = "模拟输入：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtCh2
            // 
            this.txtCh2.Location = new System.Drawing.Point(141, 483);
            this.txtCh2.Name = "txtCh2";
            this.txtCh2.ReadOnly = true;
            this.txtCh2.Size = new System.Drawing.Size(154, 25);
            this.txtCh2.TabIndex = 42;
            // 
            // chkboxCh2
            // 
            this.chkboxCh2.Enabled = false;
            this.chkboxCh2.Location = new System.Drawing.Point(39, 483);
            this.chkboxCh2.Name = "chkboxCh2";
            this.chkboxCh2.Size = new System.Drawing.Size(89, 30);
            this.chkboxCh2.TabIndex = 43;
            this.chkboxCh2.Text = "通道2";
            // 
            // txtCh1
            // 
            this.txtCh1.Location = new System.Drawing.Point(141, 445);
            this.txtCh1.Name = "txtCh1";
            this.txtCh1.ReadOnly = true;
            this.txtCh1.Size = new System.Drawing.Size(154, 25);
            this.txtCh1.TabIndex = 44;
            // 
            // chkboxCh1
            // 
            this.chkboxCh1.Enabled = false;
            this.chkboxCh1.Location = new System.Drawing.Point(39, 445);
            this.chkboxCh1.Name = "chkboxCh1";
            this.chkboxCh1.Size = new System.Drawing.Size(89, 29);
            this.chkboxCh1.TabIndex = 45;
            this.chkboxCh1.Text = "通道1";
            // 
            // txtCh0
            // 
            this.txtCh0.Location = new System.Drawing.Point(141, 406);
            this.txtCh0.Name = "txtCh0";
            this.txtCh0.ReadOnly = true;
            this.txtCh0.Size = new System.Drawing.Size(154, 25);
            this.txtCh0.TabIndex = 46;
            // 
            // chkboxCh0
            // 
            this.chkboxCh0.Enabled = false;
            this.chkboxCh0.Location = new System.Drawing.Point(39, 406);
            this.chkboxCh0.Name = "chkboxCh0";
            this.chkboxCh0.Size = new System.Drawing.Size(89, 30);
            this.chkboxCh0.TabIndex = 47;
            this.chkboxCh0.Text = "通道0";
            // 
            // Adam6024
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(871, 570);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelDO);
            this.Controls.Add(this.panelOutput);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelDI);
            this.Controls.Add(this.txtCh5);
            this.Controls.Add(this.chkboxCh5);
            this.Controls.Add(this.txtCh4);
            this.Controls.Add(this.chkboxCh4);
            this.Controls.Add(this.txtCh3);
            this.Controls.Add(this.chkboxCh3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCh2);
            this.Controls.Add(this.chkboxCh2);
            this.Controls.Add(this.txtCh1);
            this.Controls.Add(this.chkboxCh1);
            this.Controls.Add(this.txtCh0);
            this.Controls.Add(this.chkboxCh0);
            this.Controls.Add(this.txtCurrentValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Adam6024";
            this.Text = "Adam6024 读/写 控制";
            this.Load += new System.EventHandler(this.Adam6024_Load);
            this.panelDO.ResumeLayout(false);
            this.panelDO.PerformLayout();
            this.panelOutput.ResumeLayout(false);
            this.panelOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panelDI.ResumeLayout(false);
            this.panelDI.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>


		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(m_bStart)
			{
				timer1.Enabled = false;
				adamModbus.Disconnect(); // disconnect slave
			}
		}

		private void RefreshAiChannelRange(int i_iChannel)
		{
			byte byRange;
			if (adamModbus.AnalogInput().GetInputRange(i_iChannel, out byRange))
				m_byAiRange[i_iChannel] = byRange;
			else
				txtReadCount.Text += "取得输入范围失败;";
		}

		private void RefreshAoChannelRange(int i_iChannel)
		{
			byte byRange;
			if (adamModbus.AnalogOutput().GetConfiguration(i_iChannel, out byRange))
				m_byAoRange[i_iChannel] = byRange;
			else
				txtReadCount.Text += "获得设备配置失败;";
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{			
			timer1.Enabled = false;

			m_iCount++; // increment the reading counter
			txtReadCount.Text = "真实数据采样第 "+ m_iCount.ToString() + " 次";
			RefreshAiChannelValue();
			RefreshDI();
			RefreshAoChannelValue(cbxAOChannel.SelectedIndex);
			RefreshDO();		
			timer1.Enabled = true;
		}

		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			if (m_bStart)                    // was started
			{
				panelDO.Enabled=false;
				panelOutput.Enabled=false;
				m_bStart = false;		     // starting flag
				timer1.Enabled = false;      // disable timer
				adamModbus.Disconnect();     // disconnect slave
				buttonStart.Text = "开始";
			}
			else	// was stoped
			{
				if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
				{
					RefreshAiChannelRange(5);
					RefreshAiChannelRange(4);
					RefreshAiChannelRange(3);
					RefreshAiChannelRange(2);
					RefreshAiChannelRange(1);
					RefreshAiChannelRange(0);
					RefreshAoChannelRange(1);
					RefreshAoChannelRange(0);

					cbxAOChannel.SelectedIndex = 0;
					RefreshAiChannelEnabled();

					panelDO.Enabled=true;
					panelOutput.Enabled=true;
					m_iCount = 0; // reset the reading counter
					timer1.Enabled = true; // enable timer
					buttonStart.Text = "停止";
					m_bStart = true; // starting flag
				}
				else
					MessageBox.Show("连接到 "+ m_szIP + " 失败", "错误提示");
			}				
		}

		private void RefreshOutputValue(int i_iChannel)
		{
			int iStart = 11+i_iChannel;
			int[] iData;
			float fValue;
			string szFormat;
			Adam6024_OutputRange byRange;

			if (adamModbus.Modbus().ReadInputRegs(iStart, 1, out iData))
			{
				fValue = AnalogOutput.GetScaledValue(m_Adam6000Type, m_byAoRange[i_iChannel], iData[0]);
				// 
				szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_byAoRange[i_iChannel]);
				byRange = (Adam6024_OutputRange)m_byAoRange[i_iChannel];
	
				if (byRange == Adam6024_OutputRange.mA_0To20) // 0~20mA
				{
					lblLow.Text = "0 mA";
					lblHigh.Text = "20 mA";
					trackBar1.Value = Convert.ToInt32(fValue*trackBar1.Maximum/20);
				}
				else if (byRange == Adam6024_OutputRange.mA_4To20) // 4~20mA
				{
					lblLow.Text = "4 mA";
					lblHigh.Text = "20 mA";
					trackBar1.Value = Convert.ToInt32((fValue-4.0)*trackBar1.Maximum/16);
				}
				else // 0~10V
				{
					lblLow.Text = "0 V";
					lblHigh.Text = "10 V";
					trackBar1.Value = Convert.ToInt32(fValue*trackBar1.Maximum/10);
				}
				txtOutputValue.Text = fValue.ToString(szFormat);
			}
			else
				txtReadCount.Text += "真实读入范围失败;";
		}

		private void RefreshAiChannelEnabled()
		{
			bool[] bEnabled;

			if (adamModbus.AnalogInput().GetChannelEnabled(m_iAiTotal, out bEnabled))
			{
				Array.Copy(bEnabled, 0, m_bChEnabled, 0, m_iAiTotal);
				chkboxCh0.Checked = m_bChEnabled[0];
				chkboxCh1.Checked = m_bChEnabled[1];
				chkboxCh2.Checked = m_bChEnabled[2];
				chkboxCh3.Checked = m_bChEnabled[3];
				chkboxCh4.Checked = m_bChEnabled[4];
				chkboxCh5.Checked = m_bChEnabled[5];
				if (!m_bChEnabled[0])
					txtCh0.Text = "";
				if (!m_bChEnabled[1])
					txtCh1.Text = "";
				if (!m_bChEnabled[2])
					txtCh2.Text = "";
				if (!m_bChEnabled[3])
					txtCh3.Text = "";
				if (!m_bChEnabled[4])
					txtCh4.Text = "";
				if (!m_bChEnabled[5])
					txtCh5.Text = "";
			}
			else
				txtReadCount.Text += "取得使能通道状态失败;";
		}

		private void RefreshDI()
		{
			int iStart = 1;
			bool[] bData;

			if (adamModbus.Modbus().ReadCoilStatus(iStart, m_iDiTotal, out bData))
			{
				txtDICh0.Text = bData[0].ToString();
				txtDICh1.Text = bData[1].ToString();
			}
			else
			{
				txtDICh0.Text = "Fail";
				txtDICh1.Text = "Fail";
			}
		}

		private void RefreshDO()
		{
			int iStart = 17;
			bool[] bData;

			if (adamModbus.Modbus().ReadCoilStatus(iStart, m_iDoTotal, out bData))
			{
				txtDOCh0.Text = bData[0].ToString();
				txtDOCh1.Text = bData[1].ToString();
			}
			else
			{
				txtDOCh0.Text = "Fail";
				txtDOCh1.Text = "Fail";
			}
		}

		private void RefreshSingleAiChannel(int i_iIndex, ref TextBox txtCh, float fValue, int i_iStatus)
		{
			string szFormat;

			if (m_bChEnabled[i_iIndex])
			{
				if (i_iStatus == 0)
				{
					szFormat = AnalogInput.GetFloatFormat(m_Adam6000Type, m_byAiRange[i_iIndex]);
					txtCh.Text = fValue.ToString(szFormat)+" "+AnalogInput.GetUnitName(m_Adam6000Type, m_byAiRange[i_iIndex]);
				}
				else if (i_iStatus == 1)
					txtCh.Text = "Over(H)";
				else if (i_iStatus == 2)
					txtCh.Text = "Over(L)";
				else
					txtCh.Text = "Invalid(R)";
			}
		}

		private void RefreshAiChannelValue()
		{
			int iStart = 1, iStatusStart = 21;
			int iIdx;
			int[] iData;
			float[] fValue = new float[m_iAiTotal];
			int[] iStatus = new int[m_iAiTotal];

			if (adamModbus.Modbus().ReadInputRegs(iStart, m_iAiTotal, out iData) && 
				adamModbus.Modbus().ReadInputRegs(iStatusStart, m_iAiTotal, out iStatus))
			{
				for (iIdx=0; iIdx<m_iAiTotal; iIdx++)
					fValue[iIdx] = AnalogInput.GetScaledValue(m_Adam6000Type, m_byAiRange[iIdx], iData[iIdx]);
				RefreshSingleAiChannel(0, ref txtCh0, fValue[0], iStatus[0]);
				RefreshSingleAiChannel(1, ref txtCh1, fValue[1], iStatus[1]);
				RefreshSingleAiChannel(2, ref txtCh2, fValue[2], iStatus[2]);
				RefreshSingleAiChannel(3, ref txtCh3, fValue[3], iStatus[3]);
				RefreshSingleAiChannel(4, ref txtCh4, fValue[4], iStatus[4]);
				RefreshSingleAiChannel(5, ref txtCh5, fValue[5], iStatus[5]);
			}
			else
			{
				txtReadCount.Text += "ReadInputRegs() failed;";
			}
		}

		private void RefreshAoChannelValue(int i_iChannel)
		{
			int iStart = 11+i_iChannel;
			int[] iData;
			float fValue;
			string szFormat;

			if (adamModbus.Modbus().ReadInputRegs(iStart, 1, out iData))
			{
				fValue = AnalogOutput.GetScaledValue(m_Adam6000Type, m_byAoRange[i_iChannel], iData[0]);
				// 
				szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_byAoRange[i_iChannel]);
				//
				txtCurrentValue.Text = fValue.ToString(szFormat)+" "+AnalogOutput.GetUnitName(m_Adam6000Type, m_byAoRange[i_iChannel]);
			}
			else
			{
				txtReadCount.Text += "ReadInputRegs() failed;";
			}
		}

		private void btnApplyOutput_Click(object sender, System.EventArgs e)
		{
			int iChannel = cbxAOChannel.SelectedIndex;
			int iStart = 11+iChannel;
			int iValue;

			timer1.Enabled = false;
			iValue = trackBar1.Value;
			if (iValue>4095)
				iValue = 4095;
			if (adamModbus.Modbus().PresetSingleReg(iStart, iValue))
			{
				System.Threading.Thread.Sleep(500);
				RefreshAoChannelValue(iChannel);
				RefreshOutputValue(iChannel);
			}
			else
				MessageBox.Show("Change current value failed!", "Error");
			timer1.Enabled = true;
		}

		private void btnCh_Click(int i_iCh, TextBox txtBox)
		{
			int iOnOff, iStart = 17+i_iCh;

			timer1.Enabled = false;
			if (txtBox.Text == "True") // was ON, now set to OFF
				iOnOff = 0;
			else
				iOnOff = 1;
			if (adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff))
				RefreshDO();
			else
				MessageBox.Show("Set digital output failed!", "Error");
			timer1.Enabled = true;
		}

		private void btnDOCh0_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(0, txtDOCh0);
		}

		private void btnDOCh1_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(1, txtDOCh1);
		}

		private void cbxAOChannel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int iChannel = cbxAOChannel.SelectedIndex;
			timer1.Enabled = false;
			RefreshAoChannelValue(iChannel);
			RefreshOutputValue(iChannel);
			timer1.Enabled = true;
		}

		private void trackBar1_ValueChanged(object sender, System.EventArgs e)
		{
			int iCh;
			float fValue;
			Adam6024_OutputRange byRange;

			if (m_bStart) // was started
			{
				timer1.Enabled = false;
				iCh = cbxAOChannel.SelectedIndex;
				fValue = Convert.ToSingle(trackBar1.Value);
				byRange = (Adam6024_OutputRange)m_byAoRange[iCh];
				if (byRange == Adam6024_OutputRange.mA_0To20) // 0~20mA
					fValue = fValue*20/trackBar1.Maximum;
				else if (byRange == Adam6024_OutputRange.mA_4To20) // 4~20mA
					fValue = 4.0f+fValue*16/trackBar1.Maximum;
				else // 0~10V
					fValue = fValue*10/trackBar1.Maximum;
				txtOutputValue.Text = fValue.ToString("0.000");
				timer1.Enabled = true;		
			}
		}

        private void Adam6024_Load(object sender, EventArgs e)
        {

        }
  }
}
