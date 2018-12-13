namespace FrictionTester
{
     partial class FormStatus
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
              System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatus));
              this.splitContainer1 = new System.Windows.Forms.SplitContainer();
              this.richTextBox1 = new System.Windows.Forms.RichTextBox();
              this.splitContainer1.Panel1.SuspendLayout();
              this.splitContainer1.SuspendLayout();
              this.SuspendLayout();
              // 
              // splitContainer1
              // 
              this.splitContainer1.AccessibleDescription = null;
              this.splitContainer1.AccessibleName = null;
              resources.ApplyResources(this.splitContainer1, "splitContainer1");
              this.splitContainer1.BackgroundImage = null;
              this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
              this.splitContainer1.Font = null;
              this.splitContainer1.Name = "splitContainer1";
              // 
              // splitContainer1.Panel1
              // 
              this.splitContainer1.Panel1.AccessibleDescription = null;
              this.splitContainer1.Panel1.AccessibleName = null;
              resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
              this.splitContainer1.Panel1.BackgroundImage = null;
              this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
              this.splitContainer1.Panel1.Font = null;
              // 
              // splitContainer1.Panel2
              // 
              this.splitContainer1.Panel2.AccessibleDescription = null;
              this.splitContainer1.Panel2.AccessibleName = null;
              resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
              this.splitContainer1.Panel2.BackgroundImage = null;
              this.splitContainer1.Panel2.Font = null;
              // 
              // richTextBox1
              // 
              this.richTextBox1.AccessibleDescription = null;
              this.richTextBox1.AccessibleName = null;
              resources.ApplyResources(this.richTextBox1, "richTextBox1");
              this.richTextBox1.BackgroundImage = null;
              this.richTextBox1.Name = "richTextBox1";
              this.richTextBox1.ReadOnly = true;
              // 
              // FormStatus
              // 
              this.AccessibleDescription = null;
              this.AccessibleName = null;
              resources.ApplyResources(this, "$this");
              this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
              this.BackgroundImage = null;
              this.Controls.Add(this.splitContainer1);
              this.Font = null;
              this.HideOnClose = true;
              this.Icon = null;
              this.Name = "FormStatus";
              this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Float;
              this.ToolTipText = null;
              this.splitContainer1.Panel1.ResumeLayout(false);
              this.splitContainer1.ResumeLayout(false);
              this.ResumeLayout(false);

          }
          #endregion
          private System.Windows.Forms.SplitContainer splitContainer1;
          private System.Windows.Forms.RichTextBox richTextBox1;
     }
}