namespace FrictionTester
{
    partial class RemoteControl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SetAutoMode = new System.Windows.Forms.Button();
            this.SetManeMode = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnsetup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnbeep = new System.Windows.Forms.Button();
            this.btnbeepstop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnfire = new System.Windows.Forms.Button();
            this.btnfireoff = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnraise = new System.Windows.Forms.Button();
            this.btndown = new System.Windows.Forms.Button();
            this.btnoff = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.ComboBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.lstRunningInfo = new System.Windows.Forms.ListBox();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SetAutoMode);
            this.groupBox5.Controls.Add(this.SetManeMode);
            this.groupBox5.Location = new System.Drawing.Point(422, 17);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(161, 120);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "自动模式";
            // 
            // SetAutoMode
            // 
            this.SetAutoMode.Location = new System.Drawing.Point(40, 26);
            this.SetAutoMode.Margin = new System.Windows.Forms.Padding(2);
            this.SetAutoMode.Name = "SetAutoMode";
            this.SetAutoMode.Size = new System.Drawing.Size(99, 34);
            this.SetAutoMode.TabIndex = 0;
            this.SetAutoMode.Text = "自动模式";
            this.SetAutoMode.UseVisualStyleBackColor = true;
            this.SetAutoMode.Click += new System.EventHandler(this.SetAutoMode_Click);
            // 
            // SetManeMode
            // 
            this.SetManeMode.Location = new System.Drawing.Point(40, 72);
            this.SetManeMode.Margin = new System.Windows.Forms.Padding(2);
            this.SetManeMode.Name = "SetManeMode";
            this.SetManeMode.Size = new System.Drawing.Size(99, 34);
            this.SetManeMode.TabIndex = 1;
            this.SetManeMode.Text = "非自动模式";
            this.SetManeMode.UseVisualStyleBackColor = true;
            this.SetManeMode.Click += new System.EventHandler(this.SetManeMode_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnsetup);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.trackBar2);
            this.groupBox4.Location = new System.Drawing.Point(22, 235);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(561, 113);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "电机速度控制";
            // 
            // btnsetup
            // 
            this.btnsetup.Location = new System.Drawing.Point(440, 58);
            this.btnsetup.Margin = new System.Windows.Forms.Padding(2);
            this.btnsetup.Name = "btnsetup";
            this.btnsetup.Size = new System.Drawing.Size(99, 34);
            this.btnsetup.TabIndex = 3;
            this.btnsetup.Text = "设置";
            this.btnsetup.UseVisualStyleBackColor = true;
            this.btnsetup.Click += new System.EventHandler(this.btnsetup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "电机速度: 100";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(26, 19);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar2.Maximum = 2000;
            this.trackBar2.Minimum = 10;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(513, 45);
            this.trackBar2.TabIndex = 1;
            this.trackBar2.Value = 100;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnbeep);
            this.groupBox3.Controls.Add(this.btnbeepstop);
            this.groupBox3.Location = new System.Drawing.Point(303, 150);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(280, 81);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "蜂鸣器控制";
            // 
            // btnbeep
            // 
            this.btnbeep.Location = new System.Drawing.Point(29, 28);
            this.btnbeep.Margin = new System.Windows.Forms.Padding(2);
            this.btnbeep.Name = "btnbeep";
            this.btnbeep.Size = new System.Drawing.Size(99, 34);
            this.btnbeep.TabIndex = 0;
            this.btnbeep.Text = "开始";
            this.btnbeep.UseVisualStyleBackColor = true;
            this.btnbeep.Click += new System.EventHandler(this.btnbeep_Click);
            // 
            // btnbeepstop
            // 
            this.btnbeepstop.Location = new System.Drawing.Point(159, 28);
            this.btnbeepstop.Margin = new System.Windows.Forms.Padding(2);
            this.btnbeepstop.Name = "btnbeepstop";
            this.btnbeepstop.Size = new System.Drawing.Size(99, 34);
            this.btnbeepstop.TabIndex = 1;
            this.btnbeepstop.Text = "停止";
            this.btnbeepstop.UseVisualStyleBackColor = true;
            this.btnbeepstop.Click += new System.EventHandler(this.btnbeepstop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnfire);
            this.groupBox2.Controls.Add(this.btnfireoff);
            this.groupBox2.Location = new System.Drawing.Point(22, 150);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(266, 81);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "点火控制";
            // 
            // btnfire
            // 
            this.btnfire.Location = new System.Drawing.Point(26, 28);
            this.btnfire.Margin = new System.Windows.Forms.Padding(2);
            this.btnfire.Name = "btnfire";
            this.btnfire.Size = new System.Drawing.Size(99, 34);
            this.btnfire.TabIndex = 0;
            this.btnfire.Text = "开始";
            this.btnfire.UseVisualStyleBackColor = true;
            this.btnfire.Click += new System.EventHandler(this.btnfire_Click);
            // 
            // btnfireoff
            // 
            this.btnfireoff.Location = new System.Drawing.Point(147, 28);
            this.btnfireoff.Margin = new System.Windows.Forms.Padding(2);
            this.btnfireoff.Name = "btnfireoff";
            this.btnfireoff.Size = new System.Drawing.Size(99, 34);
            this.btnfireoff.TabIndex = 1;
            this.btnfireoff.Text = "停止";
            this.btnfireoff.UseVisualStyleBackColor = true;
            this.btnfireoff.Click += new System.EventHandler(this.btnfireoff_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnraise);
            this.groupBox1.Controls.Add(this.btndown);
            this.groupBox1.Controls.Add(this.btnoff);
            this.groupBox1.Location = new System.Drawing.Point(22, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(383, 120);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "升降控制";
            // 
            // btnraise
            // 
            this.btnraise.Location = new System.Drawing.Point(26, 26);
            this.btnraise.Margin = new System.Windows.Forms.Padding(2);
            this.btnraise.Name = "btnraise";
            this.btnraise.Size = new System.Drawing.Size(99, 34);
            this.btnraise.TabIndex = 0;
            this.btnraise.Text = "上升";
            this.btnraise.UseVisualStyleBackColor = true;
            this.btnraise.Click += new System.EventHandler(this.btnraise_Click);
            // 
            // btndown
            // 
            this.btndown.Location = new System.Drawing.Point(147, 26);
            this.btndown.Margin = new System.Windows.Forms.Padding(2);
            this.btndown.Name = "btndown";
            this.btndown.Size = new System.Drawing.Size(99, 34);
            this.btndown.TabIndex = 1;
            this.btndown.Text = "下降";
            this.btndown.UseVisualStyleBackColor = true;
            this.btndown.Click += new System.EventHandler(this.btndown_Click);
            // 
            // btnoff
            // 
            this.btnoff.Location = new System.Drawing.Point(26, 72);
            this.btnoff.Margin = new System.Windows.Forms.Padding(2);
            this.btnoff.Name = "btnoff";
            this.btnoff.Size = new System.Drawing.Size(99, 34);
            this.btnoff.TabIndex = 2;
            this.btnoff.Text = "停止";
            this.btnoff.UseVisualStyleBackColor = true;
            this.btnoff.Click += new System.EventHandler(this.btnoff_Click);
            // 
            // txtIP
            // 
            this.txtIP.FormattingEnabled = true;
            this.txtIP.Location = new System.Drawing.Point(31, 376);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(121, 20);
            this.txtIP.TabIndex = 14;
            this.txtIP.SelectedIndexChanged += new System.EventHandler(this.txtIP_SelectedIndexChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(179, 376);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(109, 21);
            this.txtPort.TabIndex = 15;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(382, 376);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 16;
            this.btnConnect.Text = "连接服务器";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(486, 376);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 17;
            this.btnDisconnect.Text = "断开服务器";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(486, 421);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "发送数据";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(31, 421);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(426, 21);
            this.txtSend.TabIndex = 19;
            // 
            // lstRunningInfo
            // 
            this.lstRunningInfo.FormattingEnabled = true;
            this.lstRunningInfo.ItemHeight = 12;
            this.lstRunningInfo.Location = new System.Drawing.Point(31, 467);
            this.lstRunningInfo.Name = "lstRunningInfo";
            this.lstRunningInfo.Size = new System.Drawing.Size(530, 52);
            this.lstRunningInfo.TabIndex = 20;
            this.lstRunningInfo.SelectedIndexChanged += new System.EventHandler(this.lstRunningInfo_SelectedIndexChanged);
            // 
            // RemoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 603);
            this.Controls.Add(this.lstRunningInfo);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RemoteControl";
            this.Text = "火焰感度网络远程控制";
            this.Load += new System.EventHandler(this.RemoteControl_Load);
            this.Click += new System.EventHandler(this.btnConnect_Click);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button SetAutoMode;
        private System.Windows.Forms.Button SetManeMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnsetup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnbeep;
        private System.Windows.Forms.Button btnbeepstop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnfire;
        private System.Windows.Forms.Button btnfireoff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnraise;
        private System.Windows.Forms.Button btndown;
        private System.Windows.Forms.Button btnoff;
        private System.Windows.Forms.ComboBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.ListBox lstRunningInfo;
    }
}