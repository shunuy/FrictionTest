namespace FrictionTester
{
    partial class DeviceControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DoorStateValue = new System.Windows.Forms.Label();
            this.doorState = new System.Windows.Forms.Label();
            this.SeTongXun = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.DoorStateValue);
            this.groupBox2.Controls.Add(this.doorState);
            this.groupBox2.Controls.Add(this.SeTongXun);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "电压步长降";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "电压步长升";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DoorStateValue
            // 
            this.DoorStateValue.AutoEllipsis = true;
            this.DoorStateValue.AutoSize = true;
            this.DoorStateValue.Location = new System.Drawing.Point(199, 25);
            this.DoorStateValue.Name = "DoorStateValue";
            this.DoorStateValue.Size = new System.Drawing.Size(35, 12);
            this.DoorStateValue.TabIndex = 9;
            this.DoorStateValue.Text = "开/关";
            // 
            // doorState
            // 
            this.doorState.AutoSize = true;
            this.doorState.Location = new System.Drawing.Point(128, 25);
            this.doorState.Name = "doorState";
            this.doorState.Size = new System.Drawing.Size(65, 12);
            this.doorState.TabIndex = 8;
            this.doorState.Text = "门控状态：";
            // 
            // SeTongXun
            // 
            this.SeTongXun.Location = new System.Drawing.Point(24, 20);
            this.SeTongXun.Name = "SeTongXun";
            this.SeTongXun.Size = new System.Drawing.Size(75, 23);
            this.SeTongXun.TabIndex = 7;
            this.SeTongXun.Text = "通讯设置";
            this.SeTongXun.UseVisualStyleBackColor = true;
            this.SeTongXun.Click += new System.EventHandler(this.SeTongXun_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "熄 火";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(159, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "点 火";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // DeviceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 186);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实验开始/设备控制";
            this.Load += new System.EventHandler(this.DeviceControl_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button SeTongXun;
        private System.Windows.Forms.Label DoorStateValue;
        private System.Windows.Forms.Label doorState;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}