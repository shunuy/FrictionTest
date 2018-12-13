namespace SDAF.DataBase
{
     partial class FormPreview
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
              System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPreview));
              this.c1PreviewControl = new System.Windows.Forms.ToolStripContainer();
              this.c1PreviewControl_leftSplitter = new System.Windows.Forms.Splitter();
              this.c1PreviewPane1 = new C1.Win.C1Preview.C1PreviewPane();
              this.c1PrintDocument1 = new C1.C1Preview.C1PrintDocument();
              this.c1PreviewControl_rightSplitter = new System.Windows.Forms.Splitter();
              this.c1PreviewPane1_zoomStrip = new System.Windows.Forms.ToolStrip();
              this.c1PreviewPane1_btnZoomTool = new System.Windows.Forms.ToolStripSplitButton();
              this.c1PreviewPane1_itemZoomInTool = new System.Windows.Forms.ToolStripMenuItem();
              this.c1PreviewPane1_itemZoomOutTool = new System.Windows.Forms.ToolStripMenuItem();
              this.c1PreviewPane1_btnZoomOut = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_txtZoomFactor = new System.Windows.Forms.ToolStripTextBox();
              this.c1PreviewPane1_dropZoomFactor = new System.Windows.Forms.ToolStripDropDownButton();
              this.c1PreviewPane1_btnZoomIn = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_fileStrip = new System.Windows.Forms.ToolStrip();
              this.c1PreviewPane1_btnFileOpen = new System.Windows.Forms.ToolStripSplitButton();
              this.c1PreviewPane1_btnFileSave = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_btnPageSetup = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_btnPrint = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_btnReflow = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_pageStrip = new System.Windows.Forms.ToolStrip();
              this.c1PreviewPane1_btnPageSingle = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_btnPageContinuous = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_btnPageFacing = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewPane1_btnPageFacingContinuous = new System.Windows.Forms.ToolStripButton();
              this.c1PreviewControl.ContentPanel.SuspendLayout();
              this.c1PreviewControl.TopToolStripPanel.SuspendLayout();
              this.c1PreviewControl.SuspendLayout();
              ((System.ComponentModel.ISupportInitialize)(this.c1PreviewPane1)).BeginInit();
              this.c1PreviewPane1_zoomStrip.SuspendLayout();
              this.c1PreviewPane1_fileStrip.SuspendLayout();
              this.c1PreviewPane1_pageStrip.SuspendLayout();
              this.SuspendLayout();
              // 
              // c1PreviewControl
              // 
              // 
              // c1PreviewControl.ContentPanel
              // 
              this.c1PreviewControl.ContentPanel.Controls.Add(this.c1PreviewControl_leftSplitter);
              this.c1PreviewControl.ContentPanel.Controls.Add(this.c1PreviewPane1);
              this.c1PreviewControl.ContentPanel.Controls.Add(this.c1PreviewControl_rightSplitter);
              resources.ApplyResources(this.c1PreviewControl.ContentPanel, "c1PreviewControl.ContentPanel");
              this.c1PreviewControl.ContentPanel.Load += new System.EventHandler(this.c1PreviewControl_ContentPanel_Load);
              resources.ApplyResources(this.c1PreviewControl, "c1PreviewControl");
              this.c1PreviewControl.Name = "c1PreviewControl";
              // 
              // c1PreviewControl.TopToolStripPanel
              // 
              this.c1PreviewControl.TopToolStripPanel.Controls.Add(this.c1PreviewPane1_fileStrip);
              this.c1PreviewControl.TopToolStripPanel.Controls.Add(this.c1PreviewPane1_pageStrip);
              this.c1PreviewControl.TopToolStripPanel.Controls.Add(this.c1PreviewPane1_zoomStrip);
              // 
              // c1PreviewControl_leftSplitter
              // 
              resources.ApplyResources(this.c1PreviewControl_leftSplitter, "c1PreviewControl_leftSplitter");
              this.c1PreviewControl_leftSplitter.Name = "c1PreviewControl_leftSplitter";
              this.c1PreviewControl_leftSplitter.TabStop = false;
              // 
              // c1PreviewPane1
              // 
              resources.ApplyResources(this.c1PreviewPane1, "c1PreviewPane1");
              this.c1PreviewPane1.Document = this.c1PrintDocument1;
              this.c1PreviewPane1.IntegrateExternalTools = true;
              this.c1PreviewPane1.Name = "c1PreviewPane1";
              this.c1PreviewPane1.ZoomMode = C1.Win.C1Preview.ZoomModeEnum.ActualSize;
              // 
              // c1PrintDocument1
              // 
              this.c1PrintDocument1.PageLayouts.Default.PageSettings = new C1.C1Preview.C1PageSettings(System.Drawing.Printing.PaperKind.A4, true, "25.4mm", "25.4mm", "25.4mm", "25.4mm");
              // 
              // c1PreviewControl_rightSplitter
              // 
              resources.ApplyResources(this.c1PreviewControl_rightSplitter, "c1PreviewControl_rightSplitter");
              this.c1PreviewControl_rightSplitter.Name = "c1PreviewControl_rightSplitter";
              this.c1PreviewControl_rightSplitter.TabStop = false;
              // 
              // c1PreviewPane1_zoomStrip
              // 
              resources.ApplyResources(this.c1PreviewPane1_zoomStrip, "c1PreviewPane1_zoomStrip");
              this.c1PreviewPane1_zoomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c1PreviewPane1_btnZoomTool,
            this.c1PreviewPane1_btnZoomOut,
            this.c1PreviewPane1_txtZoomFactor,
            this.c1PreviewPane1_dropZoomFactor,
            this.c1PreviewPane1_btnZoomIn});
              this.c1PreviewPane1_zoomStrip.Name = "c1PreviewPane1_zoomStrip";
              // 
              // c1PreviewPane1_btnZoomTool
              // 
              this.c1PreviewPane1_btnZoomTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c1PreviewPane1_itemZoomInTool,
            this.c1PreviewPane1_itemZoomOutTool});
              resources.ApplyResources(this.c1PreviewPane1_btnZoomTool, "c1PreviewPane1_btnZoomTool");
              this.c1PreviewPane1_btnZoomTool.Name = "c1PreviewPane1_btnZoomTool";
              this.c1PreviewPane1_btnZoomTool.Tag = "C1PreviewActionEnum.ZoomInTool";
              // 
              // c1PreviewPane1_itemZoomInTool
              // 
              resources.ApplyResources(this.c1PreviewPane1_itemZoomInTool, "c1PreviewPane1_itemZoomInTool");
              this.c1PreviewPane1_itemZoomInTool.Name = "c1PreviewPane1_itemZoomInTool";
              this.c1PreviewPane1_itemZoomInTool.Tag = "C1PreviewActionEnum.ZoomInTool";
              // 
              // c1PreviewPane1_itemZoomOutTool
              // 
              resources.ApplyResources(this.c1PreviewPane1_itemZoomOutTool, "c1PreviewPane1_itemZoomOutTool");
              this.c1PreviewPane1_itemZoomOutTool.Name = "c1PreviewPane1_itemZoomOutTool";
              this.c1PreviewPane1_itemZoomOutTool.Tag = "C1PreviewActionEnum.ZoomOutTool";
              // 
              // c1PreviewPane1_btnZoomOut
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnZoomOut, "c1PreviewPane1_btnZoomOut");
              this.c1PreviewPane1_btnZoomOut.Name = "c1PreviewPane1_btnZoomOut";
              this.c1PreviewPane1_btnZoomOut.Tag = "C1PreviewActionEnum.ZoomOut";
              // 
              // c1PreviewPane1_txtZoomFactor
              // 
              this.c1PreviewPane1_txtZoomFactor.Name = "c1PreviewPane1_txtZoomFactor";
              resources.ApplyResources(this.c1PreviewPane1_txtZoomFactor, "c1PreviewPane1_txtZoomFactor");
              this.c1PreviewPane1_txtZoomFactor.Tag = "C1PreviewActionEnum.ZoomFactor";
              // 
              // c1PreviewPane1_dropZoomFactor
              // 
              this.c1PreviewPane1_dropZoomFactor.Name = "c1PreviewPane1_dropZoomFactor";
              resources.ApplyResources(this.c1PreviewPane1_dropZoomFactor, "c1PreviewPane1_dropZoomFactor");
              this.c1PreviewPane1_dropZoomFactor.Tag = "C1PreviewActionEnum.ZoomFactor";
              // 
              // c1PreviewPane1_btnZoomIn
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnZoomIn, "c1PreviewPane1_btnZoomIn");
              this.c1PreviewPane1_btnZoomIn.Name = "c1PreviewPane1_btnZoomIn";
              this.c1PreviewPane1_btnZoomIn.Tag = "C1PreviewActionEnum.ZoomIn";
              // 
              // c1PreviewPane1_fileStrip
              // 
              resources.ApplyResources(this.c1PreviewPane1_fileStrip, "c1PreviewPane1_fileStrip");
              this.c1PreviewPane1_fileStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c1PreviewPane1_btnFileOpen,
            this.c1PreviewPane1_btnFileSave,
            this.c1PreviewPane1_btnPageSetup,
            this.c1PreviewPane1_btnPrint,
            this.c1PreviewPane1_btnReflow});
              this.c1PreviewPane1_fileStrip.Name = "c1PreviewPane1_fileStrip";
              // 
              // c1PreviewPane1_btnFileOpen
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnFileOpen, "c1PreviewPane1_btnFileOpen");
              this.c1PreviewPane1_btnFileOpen.Name = "c1PreviewPane1_btnFileOpen";
              this.c1PreviewPane1_btnFileOpen.Tag = "C1PreviewActionEnum.FileOpen";
              // 
              // c1PreviewPane1_btnFileSave
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnFileSave, "c1PreviewPane1_btnFileSave");
              this.c1PreviewPane1_btnFileSave.Name = "c1PreviewPane1_btnFileSave";
              this.c1PreviewPane1_btnFileSave.Tag = "C1PreviewActionEnum.FileSave";
              // 
              // c1PreviewPane1_btnPageSetup
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnPageSetup, "c1PreviewPane1_btnPageSetup");
              this.c1PreviewPane1_btnPageSetup.Name = "c1PreviewPane1_btnPageSetup";
              this.c1PreviewPane1_btnPageSetup.Tag = "C1PreviewActionEnum.PageSetup";
              // 
              // c1PreviewPane1_btnPrint
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnPrint, "c1PreviewPane1_btnPrint");
              this.c1PreviewPane1_btnPrint.Name = "c1PreviewPane1_btnPrint";
              this.c1PreviewPane1_btnPrint.Tag = "C1PreviewActionEnum.Print";
              // 
              // c1PreviewPane1_btnReflow
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnReflow, "c1PreviewPane1_btnReflow");
              this.c1PreviewPane1_btnReflow.Name = "c1PreviewPane1_btnReflow";
              this.c1PreviewPane1_btnReflow.Tag = "C1PreviewActionEnum.Reflow";
              // 
              // c1PreviewPane1_pageStrip
              // 
              resources.ApplyResources(this.c1PreviewPane1_pageStrip, "c1PreviewPane1_pageStrip");
              this.c1PreviewPane1_pageStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c1PreviewPane1_btnPageSingle,
            this.c1PreviewPane1_btnPageContinuous,
            this.c1PreviewPane1_btnPageFacing,
            this.c1PreviewPane1_btnPageFacingContinuous});
              this.c1PreviewPane1_pageStrip.Name = "c1PreviewPane1_pageStrip";
              // 
              // c1PreviewPane1_btnPageSingle
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnPageSingle, "c1PreviewPane1_btnPageSingle");
              this.c1PreviewPane1_btnPageSingle.Name = "c1PreviewPane1_btnPageSingle";
              this.c1PreviewPane1_btnPageSingle.Tag = "C1PreviewActionEnum.PageSingle";
              // 
              // c1PreviewPane1_btnPageContinuous
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnPageContinuous, "c1PreviewPane1_btnPageContinuous");
              this.c1PreviewPane1_btnPageContinuous.Name = "c1PreviewPane1_btnPageContinuous";
              this.c1PreviewPane1_btnPageContinuous.Tag = "C1PreviewActionEnum.PageContinuous";
              // 
              // c1PreviewPane1_btnPageFacing
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnPageFacing, "c1PreviewPane1_btnPageFacing");
              this.c1PreviewPane1_btnPageFacing.Name = "c1PreviewPane1_btnPageFacing";
              this.c1PreviewPane1_btnPageFacing.Tag = "C1PreviewActionEnum.PageFacing";
              // 
              // c1PreviewPane1_btnPageFacingContinuous
              // 
              resources.ApplyResources(this.c1PreviewPane1_btnPageFacingContinuous, "c1PreviewPane1_btnPageFacingContinuous");
              this.c1PreviewPane1_btnPageFacingContinuous.Name = "c1PreviewPane1_btnPageFacingContinuous";
              this.c1PreviewPane1_btnPageFacingContinuous.Tag = "C1PreviewActionEnum.PageFacingContinuous";
              // 
              // FormPreview
              // 
              resources.ApplyResources(this, "$this");
              this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
              this.Controls.Add(this.c1PreviewControl);
              this.Name = "FormPreview";
              this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPreview_FormClosing);
              this.c1PreviewControl.ContentPanel.ResumeLayout(false);
              this.c1PreviewControl.TopToolStripPanel.ResumeLayout(false);
              this.c1PreviewControl.TopToolStripPanel.PerformLayout();
              this.c1PreviewControl.ResumeLayout(false);
              this.c1PreviewControl.PerformLayout();
              ((System.ComponentModel.ISupportInitialize)(this.c1PreviewPane1)).EndInit();
              this.c1PreviewPane1_zoomStrip.ResumeLayout(false);
              this.c1PreviewPane1_zoomStrip.PerformLayout();
              this.c1PreviewPane1_fileStrip.ResumeLayout(false);
              this.c1PreviewPane1_fileStrip.PerformLayout();
              this.c1PreviewPane1_pageStrip.ResumeLayout(false);
              this.c1PreviewPane1_pageStrip.PerformLayout();
              this.ResumeLayout(false);

          }

          #endregion

          private C1.Win.C1Preview.C1PreviewPane c1PreviewPane1;
          private System.Windows.Forms.ToolStripContainer c1PreviewControl;
          private System.Windows.Forms.Splitter c1PreviewControl_leftSplitter;
          private System.Windows.Forms.Splitter c1PreviewControl_rightSplitter;
          private C1.C1Preview.C1PrintDocument c1PrintDocument1;
          private System.Windows.Forms.ToolStrip c1PreviewPane1_pageStrip;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnPageSingle;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnPageContinuous;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnPageFacing;
         private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnPageFacingContinuous;
          private System.Windows.Forms.ToolStrip c1PreviewPane1_zoomStrip;
          private System.Windows.Forms.ToolStripSplitButton c1PreviewPane1_btnZoomTool;
          private System.Windows.Forms.ToolStripMenuItem c1PreviewPane1_itemZoomInTool;
          private System.Windows.Forms.ToolStripMenuItem c1PreviewPane1_itemZoomOutTool;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnZoomOut;
          private System.Windows.Forms.ToolStripTextBox c1PreviewPane1_txtZoomFactor;
          private System.Windows.Forms.ToolStripDropDownButton c1PreviewPane1_dropZoomFactor;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnZoomIn;
          private System.Windows.Forms.ToolStrip c1PreviewPane1_fileStrip;
          private System.Windows.Forms.ToolStripSplitButton c1PreviewPane1_btnFileOpen;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnFileSave;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnPageSetup;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnPrint;
          private System.Windows.Forms.ToolStripButton c1PreviewPane1_btnReflow;
     }
}