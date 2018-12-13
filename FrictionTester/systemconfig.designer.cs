namespace FrictionTester
{
    partial class systemconfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TongXunSet = new System.Windows.Forms.TabControl();
            this.IpSetting = new System.Windows.Forms.TabPage();
            this.device_stylename = new System.Windows.Forms.Label();
            this.devicestyle = new System.Windows.Forms.Label();
            this.linktest = new System.Windows.Forms.Button();
            this.systemsetting = new System.Windows.Forms.Button();
            this.portvalue = new System.Windows.Forms.TextBox();
            this.portlab = new System.Windows.Forms.Label();
            this.IPaddressvalue = new System.Windows.Forms.TextBox();
            this.IPAddress = new System.Windows.Forms.Label();
            this.testcondition = new System.Windows.Forms.TabPage();
            this.clearSetting = new System.Windows.Forms.Button();
            this.setdefault = new System.Windows.Forms.Button();
            this.savesetting = new System.Windows.Forms.Button();
            this.JixinStyle = new System.Windows.Forms.ComboBox();
            this.Mvalue = new System.Windows.Forms.TextBox();
            this.Rvalue = new System.Windows.Forms.TextBox();
            this.Spacevalue = new System.Windows.Forms.TextBox();
            this.Cvalue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SelectExamp = new System.Windows.Forms.TabPage();
            this.Exampleqiwang = new System.Windows.Forms.Label();
            this.ExampleNO = new System.Windows.Forms.Label();
            this.SelectExampleName = new System.Windows.Forms.Label();
            this.SelectExampleNo = new System.Windows.Forms.Label();
            this.SelectExample = new System.Windows.Forms.Button();
            this.ExampleView = new System.Windows.Forms.DataGridView();
            this.ExampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExampleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExampleMu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExampleNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongXunSet.SuspendLayout();
            this.IpSetting.SuspendLayout();
            this.testcondition.SuspendLayout();
            this.SelectExamp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExampleView)).BeginInit();
            this.SuspendLayout();
            // 
            // TongXunSet
            // 
            this.TongXunSet.Controls.Add(this.IpSetting);
            this.TongXunSet.Controls.Add(this.testcondition);
            this.TongXunSet.Controls.Add(this.SelectExamp);
            this.TongXunSet.Location = new System.Drawing.Point(16, 15);
            this.TongXunSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TongXunSet.Multiline = true;
            this.TongXunSet.Name = "TongXunSet";
            this.TongXunSet.SelectedIndex = 0;
            this.TongXunSet.Size = new System.Drawing.Size(592, 314);
            this.TongXunSet.TabIndex = 0;
            // 
            // IpSetting
            // 
            this.IpSetting.Controls.Add(this.device_stylename);
            this.IpSetting.Controls.Add(this.devicestyle);
            this.IpSetting.Controls.Add(this.linktest);
            this.IpSetting.Controls.Add(this.systemsetting);
            this.IpSetting.Controls.Add(this.portvalue);
            this.IpSetting.Controls.Add(this.portlab);
            this.IpSetting.Controls.Add(this.IPaddressvalue);
            this.IpSetting.Controls.Add(this.IPAddress);
            this.IpSetting.Location = new System.Drawing.Point(4, 25);
            this.IpSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IpSetting.Name = "IpSetting";
            this.IpSetting.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IpSetting.Size = new System.Drawing.Size(584, 285);
            this.IpSetting.TabIndex = 0;
            this.IpSetting.Text = "通讯设置";
            this.IpSetting.UseVisualStyleBackColor = true;
            // 
            // device_stylename
            // 
            this.device_stylename.AutoSize = true;
            this.device_stylename.Location = new System.Drawing.Point(272, 41);
            this.device_stylename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.device_stylename.Name = "device_stylename";
            this.device_stylename.Size = new System.Drawing.Size(135, 15);
            this.device_stylename.TabIndex = 7;
            this.device_stylename.Text = "Adam6024/Device1";
            // 
            // devicestyle
            // 
            this.devicestyle.AutoSize = true;
            this.devicestyle.Location = new System.Drawing.Point(105, 41);
            this.devicestyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.devicestyle.Name = "devicestyle";
            this.devicestyle.Size = new System.Drawing.Size(150, 15);
            this.devicestyle.TabIndex = 6;
            this.devicestyle.Text = "连接设备型号/名称：";
            // 
            // linktest
            // 
            this.linktest.Location = new System.Drawing.Point(264, 214);
            this.linktest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.linktest.Name = "linktest";
            this.linktest.Size = new System.Drawing.Size(89, 29);
            this.linktest.TabIndex = 5;
            this.linktest.Text = "连接测试";
            this.linktest.UseVisualStyleBackColor = true;
            // 
            // systemsetting
            // 
            this.systemsetting.Location = new System.Drawing.Point(381, 214);
            this.systemsetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.systemsetting.Name = "systemsetting";
            this.systemsetting.Size = new System.Drawing.Size(101, 29);
            this.systemsetting.TabIndex = 4;
            this.systemsetting.Text = "设置";
            this.systemsetting.UseVisualStyleBackColor = true;
            // 
            // portvalue
            // 
            this.portvalue.Location = new System.Drawing.Point(248, 145);
            this.portvalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portvalue.Name = "portvalue";
            this.portvalue.Size = new System.Drawing.Size(233, 25);
            this.portvalue.TabIndex = 3;
            this.portvalue.Text = "90";
            // 
            // portlab
            // 
            this.portlab.AutoSize = true;
            this.portlab.Location = new System.Drawing.Point(105, 149);
            this.portlab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portlab.Name = "portlab";
            this.portlab.Size = new System.Drawing.Size(112, 15);
            this.portlab.TabIndex = 2;
            this.portlab.Text = "设备通讯端口：";
            // 
            // IPaddressvalue
            // 
            this.IPaddressvalue.Location = new System.Drawing.Point(248, 90);
            this.IPaddressvalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IPaddressvalue.Name = "IPaddressvalue";
            this.IPaddressvalue.Size = new System.Drawing.Size(233, 25);
            this.IPaddressvalue.TabIndex = 1;
            this.IPaddressvalue.Text = "192.168.0.1";
            // 
            // IPAddress
            // 
            this.IPAddress.AutoSize = true;
            this.IPAddress.Location = new System.Drawing.Point(105, 94);
            this.IPAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.Size = new System.Drawing.Size(128, 15);
            this.IPAddress.TabIndex = 0;
            this.IPAddress.Text = "设备通讯IP地址：";
            // 
            // testcondition
            // 
            this.testcondition.Controls.Add(this.clearSetting);
            this.testcondition.Controls.Add(this.setdefault);
            this.testcondition.Controls.Add(this.savesetting);
            this.testcondition.Controls.Add(this.JixinStyle);
            this.testcondition.Controls.Add(this.Mvalue);
            this.testcondition.Controls.Add(this.Rvalue);
            this.testcondition.Controls.Add(this.Spacevalue);
            this.testcondition.Controls.Add(this.Cvalue);
            this.testcondition.Controls.Add(this.label6);
            this.testcondition.Controls.Add(this.label7);
            this.testcondition.Controls.Add(this.label8);
            this.testcondition.Controls.Add(this.label9);
            this.testcondition.Controls.Add(this.label10);
            this.testcondition.Controls.Add(this.label5);
            this.testcondition.Controls.Add(this.label4);
            this.testcondition.Controls.Add(this.label3);
            this.testcondition.Controls.Add(this.label2);
            this.testcondition.Controls.Add(this.label1);
            this.testcondition.Location = new System.Drawing.Point(4, 25);
            this.testcondition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.testcondition.Name = "testcondition";
            this.testcondition.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.testcondition.Size = new System.Drawing.Size(584, 285);
            this.testcondition.TabIndex = 1;
            this.testcondition.Text = "实验条件";
            this.testcondition.UseVisualStyleBackColor = true;
            // 
            // clearSetting
            // 
            this.clearSetting.Location = new System.Drawing.Point(449, 116);
            this.clearSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearSetting.Name = "clearSetting";
            this.clearSetting.Size = new System.Drawing.Size(100, 29);
            this.clearSetting.TabIndex = 18;
            this.clearSetting.Text = "清除";
            this.clearSetting.UseVisualStyleBackColor = true;
            this.clearSetting.Click += new System.EventHandler(this.clearSetting_Click);
            // 
            // setdefault
            // 
            this.setdefault.Location = new System.Drawing.Point(449, 74);
            this.setdefault.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.setdefault.Name = "setdefault";
            this.setdefault.Size = new System.Drawing.Size(100, 29);
            this.setdefault.TabIndex = 17;
            this.setdefault.Text = "默认";
            this.setdefault.UseVisualStyleBackColor = true;
            // 
            // savesetting
            // 
            this.savesetting.Location = new System.Drawing.Point(449, 30);
            this.savesetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.savesetting.Name = "savesetting";
            this.savesetting.Size = new System.Drawing.Size(100, 29);
            this.savesetting.TabIndex = 16;
            this.savesetting.Text = "保存";
            this.savesetting.UseVisualStyleBackColor = true;
            this.savesetting.Click += new System.EventHandler(this.savesetting_Click);
            // 
            // JixinStyle
            // 
            this.JixinStyle.AutoCompleteCustomSource.AddRange(new string[] {
            "无极性",
            "阳极",
            "阴极"});
            this.JixinStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JixinStyle.FormattingEnabled = true;
            this.JixinStyle.Items.AddRange(new object[] {
            "阳极",
            "阴极"});
            this.JixinStyle.Location = new System.Drawing.Point(173, 161);
            this.JixinStyle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.JixinStyle.Name = "JixinStyle";
            this.JixinStyle.Size = new System.Drawing.Size(79, 23);
            this.JixinStyle.TabIndex = 15;
            // 
            // Mvalue
            // 
            this.Mvalue.Location = new System.Drawing.Point(201, 206);
            this.Mvalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Mvalue.Name = "Mvalue";
            this.Mvalue.Size = new System.Drawing.Size(132, 25);
            this.Mvalue.TabIndex = 14;
            // 
            // Rvalue
            // 
            this.Rvalue.Location = new System.Drawing.Point(173, 119);
            this.Rvalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Rvalue.Name = "Rvalue";
            this.Rvalue.Size = new System.Drawing.Size(160, 25);
            this.Rvalue.TabIndex = 12;
            // 
            // Spacevalue
            // 
            this.Spacevalue.Location = new System.Drawing.Point(140, 76);
            this.Spacevalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Spacevalue.Name = "Spacevalue";
            this.Spacevalue.Size = new System.Drawing.Size(193, 25);
            this.Spacevalue.TabIndex = 11;
            // 
            // Cvalue
            // 
            this.Cvalue.Location = new System.Drawing.Point(140, 32);
            this.Cvalue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cvalue.Name = "Cvalue";
            this.Cvalue.Size = new System.Drawing.Size(193, 25);
            this.Cvalue.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 210);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "克";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 165);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 15);
            this.label7.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "千欧";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(343, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "毫米";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(343, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "皮法";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "点平冲头质量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "极针极性：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "串联电阻：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "间隙：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "电容：";
            // 
            // SelectExamp
            // 
            this.SelectExamp.Controls.Add(this.Exampleqiwang);
            this.SelectExamp.Controls.Add(this.ExampleNO);
            this.SelectExamp.Controls.Add(this.SelectExampleName);
            this.SelectExamp.Controls.Add(this.SelectExampleNo);
            this.SelectExamp.Controls.Add(this.SelectExample);
            this.SelectExamp.Controls.Add(this.ExampleView);
            this.SelectExamp.Location = new System.Drawing.Point(4, 25);
            this.SelectExamp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectExamp.Name = "SelectExamp";
            this.SelectExamp.Size = new System.Drawing.Size(584, 285);
            this.SelectExamp.TabIndex = 2;
            this.SelectExamp.Text = "选择样品";
            this.SelectExamp.UseVisualStyleBackColor = true;
            // 
            // Exampleqiwang
            // 
            this.Exampleqiwang.AutoSize = true;
            this.Exampleqiwang.Location = new System.Drawing.Point(291, 221);
            this.Exampleqiwang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Exampleqiwang.Name = "Exampleqiwang";
            this.Exampleqiwang.Size = new System.Drawing.Size(97, 15);
            this.Exampleqiwang.TabIndex = 5;
            this.Exampleqiwang.Text = "样品期望值：";
            // 
            // ExampleNO
            // 
            this.ExampleNO.AutoSize = true;
            this.ExampleNO.Location = new System.Drawing.Point(123, 221);
            this.ExampleNO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExampleNO.Name = "ExampleNO";
            this.ExampleNO.Size = new System.Drawing.Size(23, 15);
            this.ExampleNO.TabIndex = 4;
            this.ExampleNO.Text = "12";
            // 
            // SelectExampleName
            // 
            this.SelectExampleName.BackColor = System.Drawing.Color.DarkGray;
            this.SelectExampleName.Location = new System.Drawing.Point(17, 248);
            this.SelectExampleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectExampleName.Name = "SelectExampleName";
            this.SelectExampleName.Size = new System.Drawing.Size(376, 20);
            this.SelectExampleName.TabIndex = 3;
            this.SelectExampleName.Text = "选定样品名称";
            // 
            // SelectExampleNo
            // 
            this.SelectExampleNo.AutoSize = true;
            this.SelectExampleNo.Location = new System.Drawing.Point(17, 221);
            this.SelectExampleNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectExampleNo.Name = "SelectExampleNo";
            this.SelectExampleNo.Size = new System.Drawing.Size(90, 15);
            this.SelectExampleNo.TabIndex = 2;
            this.SelectExampleNo.Text = "选定样品号:";
            // 
            // SelectExample
            // 
            this.SelectExample.Location = new System.Drawing.Point(467, 225);
            this.SelectExample.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectExample.Name = "SelectExample";
            this.SelectExample.Size = new System.Drawing.Size(100, 40);
            this.SelectExample.TabIndex = 1;
            this.SelectExample.Text = "选定样品";
            this.SelectExample.UseVisualStyleBackColor = true;
            // 
            // ExampleView
            // 
            this.ExampleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExampleView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExampleID,
            this.ExampleName,
            this.ExampleMu,
            this.ExampleNumber});
            this.ExampleView.Location = new System.Drawing.Point(4, 4);
            this.ExampleView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExampleView.Name = "ExampleView";
            this.ExampleView.RowTemplate.Height = 23;
            this.ExampleView.Size = new System.Drawing.Size(573, 200);
            this.ExampleView.TabIndex = 0;
            // 
            // ExampleID
            // 
            this.ExampleID.HeaderText = "样品号";
            this.ExampleID.Name = "ExampleID";
            // 
            // ExampleName
            // 
            this.ExampleName.HeaderText = "样品名";
            this.ExampleName.Name = "ExampleName";
            // 
            // ExampleMu
            // 
            this.ExampleMu.HeaderText = "期望值";
            this.ExampleMu.Name = "ExampleMu";
            // 
            // ExampleNumber
            // 
            this.ExampleNumber.HeaderText = "样品数量";
            this.ExampleNumber.Name = "ExampleNumber";
            // 
            // systemconfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 342);
            this.Controls.Add(this.TongXunSet);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "systemconfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实验参数设置";
            this.Load += new System.EventHandler(this.systemconfig_Load);
            this.TongXunSet.ResumeLayout(false);
            this.IpSetting.ResumeLayout(false);
            this.IpSetting.PerformLayout();
            this.testcondition.ResumeLayout(false);
            this.testcondition.PerformLayout();
            this.SelectExamp.ResumeLayout(false);
            this.SelectExamp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExampleView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TongXunSet;
        private System.Windows.Forms.TabPage IpSetting;
        private System.Windows.Forms.TabPage testcondition;
        private System.Windows.Forms.Label IPAddress;
        private System.Windows.Forms.TextBox portvalue;
        private System.Windows.Forms.Label portlab;
        private System.Windows.Forms.TextBox IPaddressvalue;
        private System.Windows.Forms.Button systemsetting;
        private System.Windows.Forms.Button linktest;
        private System.Windows.Forms.Label devicestyle;
        private System.Windows.Forms.Label device_stylename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Mvalue;
        private System.Windows.Forms.TextBox Rvalue;
        private System.Windows.Forms.TextBox Spacevalue;
        private System.Windows.Forms.TextBox Cvalue;
        private System.Windows.Forms.ComboBox JixinStyle;
        private System.Windows.Forms.Button savesetting;
        private System.Windows.Forms.Button setdefault;
        private System.Windows.Forms.Button clearSetting;
        private System.Windows.Forms.TabPage SelectExamp;
        private System.Windows.Forms.DataGridView ExampleView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExampleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExampleMu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExampleNumber;
        private System.Windows.Forms.Button SelectExample;
        public System.Windows.Forms.Label SelectExampleName;
        public System.Windows.Forms.Label SelectExampleNo;
        private System.Windows.Forms.Label ExampleNO;
        public System.Windows.Forms.Label Exampleqiwang;
    }
}