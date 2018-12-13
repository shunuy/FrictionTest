namespace FrictionTester
{
    partial class StopReason
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
            this.testsuccess = new System.Windows.Forms.Button();
            this.testnofire = new System.Windows.Forms.Button();
            this.testfail = new System.Windows.Forms.Button();
            this.endfire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testsuccess
            // 
            this.testsuccess.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testsuccess.Location = new System.Drawing.Point(33, 33);
            this.testsuccess.Margin = new System.Windows.Forms.Padding(4);
            this.testsuccess.Name = "testsuccess";
            this.testsuccess.Size = new System.Drawing.Size(134, 75);
            this.testsuccess.TabIndex = 0;
            this.testsuccess.Text = "发 火";
            this.testsuccess.UseVisualStyleBackColor = true;
            this.testsuccess.Click += new System.EventHandler(this.testsuccess_Click);
            // 
            // testnofire
            // 
            this.testnofire.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testnofire.Location = new System.Drawing.Point(185, 33);
            this.testnofire.Margin = new System.Windows.Forms.Padding(4);
            this.testnofire.Name = "testnofire";
            this.testnofire.Size = new System.Drawing.Size(134, 75);
            this.testnofire.TabIndex = 1;
            this.testnofire.Text = "瞎 火";
            this.testnofire.UseVisualStyleBackColor = true;
            this.testnofire.Click += new System.EventHandler(this.testnofire_Click);
            // 
            // testfail
            // 
            this.testfail.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testfail.Location = new System.Drawing.Point(338, 33);
            this.testfail.Margin = new System.Windows.Forms.Padding(4);
            this.testfail.Name = "testfail";
            this.testfail.Size = new System.Drawing.Size(134, 75);
            this.testfail.TabIndex = 2;
            this.testfail.Text = "废 样";
            this.testfail.UseVisualStyleBackColor = true;
            this.testfail.Click += new System.EventHandler(this.testfail_Click);
            // 
            // endfire
            // 
            this.endfire.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endfire.Location = new System.Drawing.Point(503, 33);
            this.endfire.Margin = new System.Windows.Forms.Padding(4);
            this.endfire.Name = "endfire";
            this.endfire.Size = new System.Drawing.Size(134, 75);
            this.endfire.TabIndex = 3;
            this.endfire.Text = "实验结束";
            this.endfire.UseVisualStyleBackColor = true;
            this.endfire.Click += new System.EventHandler(this.endfire_Click);
            // 
            // StopReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 141);
            this.Controls.Add(this.endfire);
            this.Controls.Add(this.testfail);
            this.Controls.Add(this.testnofire);
            this.Controls.Add(this.testsuccess);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StopReason";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实验结果选择 【默认：废样】";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StopReason_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testsuccess;
        private System.Windows.Forms.Button testnofire;
        private System.Windows.Forms.Button testfail;
        private System.Windows.Forms.Button endfire;
    }
}