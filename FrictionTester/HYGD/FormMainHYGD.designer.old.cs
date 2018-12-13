namespace FrictionTester
{
    partial class FormMainHYGD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainHYGD));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystemSet = new System.Windows.Forms.ToolStripMenuItem();
            this.NetLinkStarted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBackupParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRestoreParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrepare = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewStartTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStopTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDispClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAnalysisProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowImageAnalysisDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuManualDetect = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoteTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTextSystem = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusSeparator = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTextTestTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrDisplay = new System.Windows.Forms.Timer(this.components);
            this.tBtnSystemSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewStartTest = new System.Windows.Forms.ToolStripButton();
            this.tBtnStopTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnManualTest = new System.Windows.Forms.ToolStripButton();
            this.tBtnDataManager = new System.Windows.Forms.ToolStripButton();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.btnPrepare = new System.Windows.Forms.ToolStripButton();
            this.btnFall = new System.Windows.Forms.ToolStripButton();
            this.btnRise = new System.Windows.Forms.ToolStripButton();
            this.btnDispStop = new System.Windows.Forms.ToolStripButton();
            this.btnClearDisp = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblTempMax = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.statusTestPhase = new System.Windows.Forms.Label();
            this.statusTestSiralNo = new System.Windows.Forms.Label();
            this.lblConfigDistance = new System.Windows.Forms.Label();
            this.statusTextDistance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrAutoStopFire = new System.Windows.Forms.Timer(this.components);
            this.ymfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.toolMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Font = new System.Drawing.Font("宋体", 9F);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystem,
            this.menuTest,
            this.menuWindows,
            this.menuDetect,
            this.menuData,
            this.帮助HToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(1308, 32);
            this.menuMain.TabIndex = 38;
            this.menuMain.Text = "menuStrip1";
            this.menuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuMain_ItemClicked);
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystemSet,
            this.NetLinkStarted,
            this.toolStripSeparator5,
            this.menuBackupParameter,
            this.menuRestoreParameter,
            this.toolStripSeparator10,
            this.退出XToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuSystem.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(106, 28);
            this.menuSystem.Text = "系统(&S)";
            this.menuSystem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // menuSystemSet
            // 
            this.menuSystemSet.AutoSize = false;
            this.menuSystemSet.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuSystemSet.Image = ((System.Drawing.Image)(resources.GetObject("menuSystemSet.Image")));
            this.menuSystemSet.Name = "menuSystemSet";
            this.menuSystemSet.Size = new System.Drawing.Size(152, 25);
            this.menuSystemSet.Text = "系统设置(&Y)";
            this.menuSystemSet.Click += new System.EventHandler(this.menuSystemSet_Click);
            // 
            // NetLinkStarted
            // 
            this.NetLinkStarted.Name = "NetLinkStarted";
            this.NetLinkStarted.Size = new System.Drawing.Size(224, 28);
            this.NetLinkStarted.Text = "网络服务启动";
            this.NetLinkStarted.Click += new System.EventHandler(this.NetLinkStarted_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(221, 6);
            this.toolStripSeparator5.Visible = false;
            // 
            // menuBackupParameter
            // 
            this.menuBackupParameter.Name = "menuBackupParameter";
            this.menuBackupParameter.Size = new System.Drawing.Size(224, 28);
            this.menuBackupParameter.Text = "备份参数";
            this.menuBackupParameter.Visible = false;
            // 
            // menuRestoreParameter
            // 
            this.menuRestoreParameter.Name = "menuRestoreParameter";
            this.menuRestoreParameter.Size = new System.Drawing.Size(224, 28);
            this.menuRestoreParameter.Text = "恢复参数";
            this.menuRestoreParameter.Visible = false;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(221, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(224, 28);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(224, 28);
            this.toolStripMenuItem1.Text = "串口测试";
            this.toolStripMenuItem1.Visible = false;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuTest
            // 
            this.menuTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrepare,
            this.menuNewStartTest,
            this.menuStopTest,
            this.toolStripSeparator6,
            this.menuDispClear});
            this.menuTest.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuTest.Name = "menuTest";
            this.menuTest.Size = new System.Drawing.Size(106, 28);
            this.menuTest.Text = "实验(&T)";
            // 
            // menuPrepare
            // 
            this.menuPrepare.Name = "menuPrepare";
            this.menuPrepare.Size = new System.Drawing.Size(176, 28);
            this.menuPrepare.Text = "预置";
            this.menuPrepare.Click += new System.EventHandler(this.menuPrepare_Click);
            // 
            // menuNewStartTest
            // 
            this.menuNewStartTest.Image = ((System.Drawing.Image)(resources.GetObject("menuNewStartTest.Image")));
            this.menuNewStartTest.Name = "menuNewStartTest";
            this.menuNewStartTest.Size = new System.Drawing.Size(176, 28);
            this.menuNewStartTest.Text = "开始实验";
            // 
            // menuStopTest
            // 
            this.menuStopTest.Image = ((System.Drawing.Image)(resources.GetObject("menuStopTest.Image")));
            this.menuStopTest.Name = "menuStopTest";
            this.menuStopTest.Size = new System.Drawing.Size(176, 28);
            this.menuStopTest.Text = "停止实验";
            this.menuStopTest.Click += new System.EventHandler(this.tBtnStopTest_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(173, 6);
            // 
            // menuDispClear
            // 
            this.menuDispClear.Name = "menuDispClear";
            this.menuDispClear.Size = new System.Drawing.Size(176, 28);
            this.menuDispClear.Text = "位移清零";
            this.menuDispClear.Click += new System.EventHandler(this.menuDispClear_Click);
            // 
            // menuWindows
            // 
            this.menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWindowStatus,
            this.menuAnalysisProperty,
            this.menuWindowImageAnalysisDebug});
            this.menuWindows.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(106, 28);
            this.menuWindows.Text = "视图(&V)";
            // 
            // menuWindowStatus
            // 
            this.menuWindowStatus.Name = "menuWindowStatus";
            this.menuWindowStatus.Size = new System.Drawing.Size(224, 28);
            this.menuWindowStatus.Text = "实时状态窗口";
            // 
            // menuAnalysisProperty
            // 
            this.menuAnalysisProperty.Name = "menuAnalysisProperty";
            this.menuAnalysisProperty.Size = new System.Drawing.Size(224, 28);
            this.menuAnalysisProperty.Text = "摩擦感度试验";
            this.menuAnalysisProperty.Visible = false;
            // 
            // menuWindowImageAnalysisDebug
            // 
            this.menuWindowImageAnalysisDebug.Name = "menuWindowImageAnalysisDebug";
            this.menuWindowImageAnalysisDebug.Size = new System.Drawing.Size(224, 28);
            this.menuWindowImageAnalysisDebug.Text = "撞击感度试验";
            this.menuWindowImageAnalysisDebug.Visible = false;
            // 
            // menuDetect
            // 
            this.menuDetect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManualDetect,
            this.RemoteTest});
            this.menuDetect.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuDetect.Name = "menuDetect";
            this.menuDetect.Size = new System.Drawing.Size(106, 28);
            this.menuDetect.Text = "检测(&D)";
            // 
            // menuManualDetect
            // 
            this.menuManualDetect.Image = ((System.Drawing.Image)(resources.GetObject("menuManualDetect.Image")));
            this.menuManualDetect.Name = "menuManualDetect";
            this.menuManualDetect.Size = new System.Drawing.Size(212, 28);
            this.menuManualDetect.Text = "人工检测(&M)";
            this.menuManualDetect.Click += new System.EventHandler(this.menuManualDetect_Click);
            // 
            // RemoteTest
            // 
            this.RemoteTest.Name = "RemoteTest";
            this.RemoteTest.Size = new System.Drawing.Size(212, 28);
            this.RemoteTest.Text = "远程检测";
            this.RemoteTest.Visible = false;
            this.RemoteTest.Click += new System.EventHandler(this.RemoteTest_Click);
            // 
            // menuData
            // 
            this.menuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenDatabase,
            this.ymfToolStripMenuItem});
            this.menuData.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(106, 28);
            this.menuData.Text = "数据(&S)";
            // 
            // menuOpenDatabase
            // 
            this.menuOpenDatabase.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDatabase.Image")));
            this.menuOpenDatabase.Name = "menuOpenDatabase";
            this.menuOpenDatabase.Size = new System.Drawing.Size(212, 28);
            this.menuOpenDatabase.Text = "数据管理(&D)";
            this.menuOpenDatabase.Click += new System.EventHandler(this.menuOpenDatabase_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelp,
            this.menuAbout});
            this.帮助HToolStripMenuItem.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(106, 28);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // menuHelp
            // 
            this.menuHelp.Image = ((System.Drawing.Image)(resources.GetObject("menuHelp.Image")));
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(176, 28);
            this.menuHelp.Text = "帮助(&C) ";
            this.menuHelp.Visible = false;
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(176, 28);
            this.menuAbout.Text = "关于(&A)";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this.dockPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 251);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(1308, 438);
            this.dockPanel1.TabIndex = 41;
            // 
            // statusMain
            // 
            this.statusMain.AutoSize = false;
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusTextSystem,
            this.toolStripSeparator3,
            this.statusSeparator,
            this.toolStripStatusLabel5,
            this.statusTextTestTime});
            this.statusMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusMain.Location = new System.Drawing.Point(0, 689);
            this.statusMain.Name = "statusMain";
            this.statusMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusMain.Size = new System.Drawing.Size(1308, 36);
            this.statusMain.TabIndex = 44;
            this.statusMain.Text = "statusStrip1";
            this.statusMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusMain_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 26);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "系统状态:";
            // 
            // statusTextSystem
            // 
            this.statusTextSystem.AutoSize = false;
            this.statusTextSystem.Font = new System.Drawing.Font("宋体", 10.5F);
            this.statusTextSystem.ForeColor = System.Drawing.Color.Red;
            this.statusTextSystem.Name = "statusTextSystem";
            this.statusTextSystem.Size = new System.Drawing.Size(140, 26);
            this.statusTextSystem.Text = "未联机";
            this.statusTextSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // statusSeparator
            // 
            this.statusSeparator.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.statusSeparator.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.statusSeparator.Name = "statusSeparator";
            this.statusSeparator.Size = new System.Drawing.Size(4, 4);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.AutoSize = false;
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(80, 26);
            this.toolStripStatusLabel5.Text = "实验时间:";
            // 
            // statusTextTestTime
            // 
            this.statusTextTestTime.AutoSize = false;
            this.statusTextTestTime.Font = new System.Drawing.Font("宋体", 10.5F);
            this.statusTextTestTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statusTextTestTime.Name = "statusTextTestTime";
            this.statusTextTestTime.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statusTextTestTime.Size = new System.Drawing.Size(80, 26);
            this.statusTextTestTime.Text = "00:00:00";
            // 
            // tmrDisplay
            // 
            this.tmrDisplay.Interval = 200;
            this.tmrDisplay.Tick += new System.EventHandler(this.tmrDisplay_Tick);
            // 
            // tBtnSystemSet
            // 
            this.tBtnSystemSet.AutoSize = false;
            this.tBtnSystemSet.Image = ((System.Drawing.Image)(resources.GetObject("tBtnSystemSet.Image")));
            this.tBtnSystemSet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tBtnSystemSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnSystemSet.Name = "tBtnSystemSet";
            this.tBtnSystemSet.RightToLeftAutoMirrorImage = true;
            this.tBtnSystemSet.Size = new System.Drawing.Size(63, 63);
            this.tBtnSystemSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tBtnSystemSet.ToolTipText = "系统设置";
            this.tBtnSystemSet.Click += new System.EventHandler(this.menuSystemSet_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 82);
            // 
            // btnNewStartTest
            // 
            this.btnNewStartTest.AutoSize = false;
            this.btnNewStartTest.Image = ((System.Drawing.Image)(resources.GetObject("btnNewStartTest.Image")));
            this.btnNewStartTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewStartTest.Name = "btnNewStartTest";
            this.btnNewStartTest.Size = new System.Drawing.Size(63, 63);
            this.btnNewStartTest.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnNewStartTest.ToolTipText = "开始实验";
            this.btnNewStartTest.Click += new System.EventHandler(this.btnNewStartTest_Click);
            // 
            // tBtnStopTest
            // 
            this.tBtnStopTest.AutoSize = false;
            this.tBtnStopTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtnStopTest.Image = ((System.Drawing.Image)(resources.GetObject("tBtnStopTest.Image")));
            this.tBtnStopTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnStopTest.Margin = new System.Windows.Forms.Padding(1);
            this.tBtnStopTest.Name = "tBtnStopTest";
            this.tBtnStopTest.Size = new System.Drawing.Size(63, 63);
            this.tBtnStopTest.Text = "toolStripButton1";
            this.tBtnStopTest.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tBtnStopTest.ToolTipText = "停止实验";
            this.tBtnStopTest.Click += new System.EventHandler(this.tBtnStopTest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 82);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 82);
            // 
            // btnManualTest
            // 
            this.btnManualTest.AutoSize = false;
            this.btnManualTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnManualTest.Image = ((System.Drawing.Image)(resources.GetObject("btnManualTest.Image")));
            this.btnManualTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManualTest.Name = "btnManualTest";
            this.btnManualTest.Size = new System.Drawing.Size(63, 63);
            this.btnManualTest.Text = "人工检测";
            this.btnManualTest.Click += new System.EventHandler(this.menuManualDetect_Click);
            // 
            // tBtnDataManager
            // 
            this.tBtnDataManager.AutoSize = false;
            this.tBtnDataManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtnDataManager.Image = ((System.Drawing.Image)(resources.GetObject("tBtnDataManager.Image")));
            this.tBtnDataManager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtnDataManager.Name = "tBtnDataManager";
            this.tBtnDataManager.Size = new System.Drawing.Size(63, 63);
            this.tBtnDataManager.Text = "toolStripButton1";
            this.tBtnDataManager.ToolTipText = "数据管理";
            this.tBtnDataManager.Click += new System.EventHandler(this.menuOpenDatabase_Click);
            // 
            // toolMain
            // 
            this.toolMain.AutoSize = false;
            this.toolMain.Font = new System.Drawing.Font("宋体", 9F);
            this.toolMain.ImageScalingSize = new System.Drawing.Size(42, 42);
            this.toolMain.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBtnSystemSet,
            this.toolStripSeparator1,
            this.btnPrepare,
            this.btnNewStartTest,
            this.tBtnStopTest,
            this.btnFall,
            this.btnRise,
            this.btnDispStop,
            this.toolStripSeparator4,
            this.btnClearDisp,
            this.toolStripSeparator2,
            this.btnManualTest,
            this.tBtnDataManager});
            this.toolMain.Location = new System.Drawing.Point(0, 32);
            this.toolMain.Name = "toolMain";
            this.toolMain.ShowItemToolTips = false;
            this.toolMain.Size = new System.Drawing.Size(1308, 82);
            this.toolMain.TabIndex = 39;
            this.toolMain.Text = "toolStrip1";
            // 
            // btnPrepare
            // 
            this.btnPrepare.AutoSize = false;
            this.btnPrepare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrepare.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrepare.Image = ((System.Drawing.Image)(resources.GetObject("btnPrepare.Image")));
            this.btnPrepare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(63, 63);
            this.btnPrepare.Text = "预置";
            this.btnPrepare.Click += new System.EventHandler(this.menuPrepare_Click);
            // 
            // btnFall
            // 
            this.btnFall.AutoSize = false;
            this.btnFall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFall.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFall.Image = ((System.Drawing.Image)(resources.GetObject("btnFall.Image")));
            this.btnFall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFall.Name = "btnFall";
            this.btnFall.Size = new System.Drawing.Size(63, 63);
            this.btnFall.Text = "下降";
            this.btnFall.Click += new System.EventHandler(this.btnFall_Click);
            // 
            // btnRise
            // 
            this.btnRise.AutoSize = false;
            this.btnRise.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRise.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRise.Image = ((System.Drawing.Image)(resources.GetObject("btnRise.Image")));
            this.btnRise.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRise.Name = "btnRise";
            this.btnRise.Size = new System.Drawing.Size(63, 63);
            this.btnRise.Text = "上升";
            this.btnRise.Click += new System.EventHandler(this.btnRise_Click);
            // 
            // btnDispStop
            // 
            this.btnDispStop.AutoSize = false;
            this.btnDispStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDispStop.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDispStop.Image = ((System.Drawing.Image)(resources.GetObject("btnDispStop.Image")));
            this.btnDispStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDispStop.Name = "btnDispStop";
            this.btnDispStop.Size = new System.Drawing.Size(63, 63);
            this.btnDispStop.Text = "停止";
            this.btnDispStop.ToolTipText = "停 止";
            this.btnDispStop.Click += new System.EventHandler(this.btnDispStop_Click);
            // 
            // btnClearDisp
            // 
            this.btnClearDisp.AutoSize = false;
            this.btnClearDisp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearDisp.Image = global::FrictionTester.Properties.Resources.无标题;
            this.btnClearDisp.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClearDisp.Name = "btnClearDisp";
            this.btnClearDisp.Size = new System.Drawing.Size(63, 63);
            this.btnClearDisp.Text = " 位移";
            this.btnClearDisp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnClearDisp.ToolTipText = " 位 移";
            this.btnClearDisp.Click += new System.EventHandler(this.menuDispClear_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblStep);
            this.panel1.Controls.Add(this.lblTempMax);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.statusTestPhase);
            this.panel1.Controls.Add(this.statusTestSiralNo);
            this.panel1.Controls.Add(this.lblConfigDistance);
            this.panel1.Controls.Add(this.statusTextDistance);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 137);
            this.panel1.TabIndex = 47;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblStep
            // 
            this.lblStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep.ForeColor = System.Drawing.Color.Blue;
            this.lblStep.Location = new System.Drawing.Point(799, 98);
            this.lblStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(108, 24);
            this.lblStep.TabIndex = 13;
            this.lblStep.Text = "0.0";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTempMax
            // 
            this.lblTempMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempMax.ForeColor = System.Drawing.Color.Blue;
            this.lblTempMax.Location = new System.Drawing.Point(1819, 11);
            this.lblTempMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempMax.Name = "lblTempMax";
            this.lblTempMax.Size = new System.Drawing.Size(108, 28);
            this.lblTempMax.TabIndex = 12;
            this.lblTempMax.Text = "0.00";
            this.lblTempMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTempMax.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(720, 102);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "步长：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(1700, 19);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "温度(最大值):";
            this.label9.Visible = false;
            // 
            // statusTestPhase
            // 
            this.statusTestPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTestPhase.ForeColor = System.Drawing.Color.Red;
            this.statusTestPhase.Location = new System.Drawing.Point(503, 24);
            this.statusTestPhase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusTestPhase.Name = "statusTestPhase";
            this.statusTestPhase.Size = new System.Drawing.Size(179, 69);
            this.statusTestPhase.TabIndex = 7;
            this.statusTestPhase.Text = "预备试验";
            this.statusTestPhase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusTestSiralNo
            // 
            this.statusTestSiralNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTestSiralNo.ForeColor = System.Drawing.Color.Blue;
            this.statusTestSiralNo.Location = new System.Drawing.Point(507, 98);
            this.statusTestSiralNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusTestSiralNo.Name = "statusTestSiralNo";
            this.statusTestSiralNo.Size = new System.Drawing.Size(108, 24);
            this.statusTestSiralNo.TabIndex = 6;
            this.statusTestSiralNo.Text = "0";
            this.statusTestSiralNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfigDistance
            // 
            this.lblConfigDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigDistance.ForeColor = System.Drawing.Color.Red;
            this.lblConfigDistance.Location = new System.Drawing.Point(795, 22);
            this.lblConfigDistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfigDistance.Name = "lblConfigDistance";
            this.lblConfigDistance.Size = new System.Drawing.Size(268, 69);
            this.lblConfigDistance.TabIndex = 5;
            this.lblConfigDistance.Text = "0.0";
            this.lblConfigDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusTextDistance
            // 
            this.statusTextDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTextDistance.ForeColor = System.Drawing.Color.Red;
            this.statusTextDistance.Location = new System.Drawing.Point(187, 24);
            this.statusTextDistance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusTextDistance.Name = "statusTextDistance";
            this.statusTextDistance.Size = new System.Drawing.Size(207, 69);
            this.statusTextDistance.TabIndex = 4;
            this.statusTextDistance.Text = "0.0";
            this.statusTextDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(396, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "测试阶段:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(396, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "当前次数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(677, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "下次距离：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "点火距离(mm):";
            // 
            // tmrAutoStopFire
            // 
            this.tmrAutoStopFire.Interval = 6000;
            this.tmrAutoStopFire.Tick += new System.EventHandler(this.tmrAutoStopFire_Tick);
            // 
            // ymfToolStripMenuItem
            // 
            this.ymfToolStripMenuItem.Name = "ymfToolStripMenuItem";
            this.ymfToolStripMenuItem.Size = new System.Drawing.Size(212, 28);
            this.ymfToolStripMenuItem.Text = "ymf";
            // 
            // FormMainHYGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 725);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMainHYGD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微机控制撞击与摩擦感度综合测试系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuSystemSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuBackupParameter;
        private System.Windows.Forms.ToolStripMenuItem menuRestoreParameter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTest;
        private System.Windows.Forms.ToolStripMenuItem menuNewStartTest;
        private System.Windows.Forms.ToolStripMenuItem menuStopTest;
        private System.Windows.Forms.ToolStripMenuItem menuWindows;
        private System.Windows.Forms.ToolStripMenuItem menuWindowStatus;
        private System.Windows.Forms.ToolStripMenuItem menuAnalysisProperty;
        private System.Windows.Forms.ToolStripMenuItem menuWindowImageAnalysisDebug;
        private System.Windows.Forms.ToolStripMenuItem menuDetect;
        private System.Windows.Forms.ToolStripMenuItem menuManualDetect;
        private System.Windows.Forms.ToolStripMenuItem menuData;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDatabase;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusTextSystem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel statusSeparator;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel statusTextTestTime;
        private System.Windows.Forms.Timer tmrDisplay;
        private System.Windows.Forms.ToolStripButton tBtnSystemSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNewStartTest;
        private System.Windows.Forms.ToolStripButton tBtnStopTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnManualTest;
        private System.Windows.Forms.ToolStripButton tBtnDataManager;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label statusTextDistance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusTestPhase;
        private System.Windows.Forms.Label statusTestSiralNo;
        private System.Windows.Forms.Label lblConfigDistance;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblTempMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuDispClear;
        private System.Windows.Forms.ToolStripButton btnClearDisp;
        private System.Windows.Forms.ToolStripMenuItem menuPrepare;
        private System.Windows.Forms.ToolStripButton btnPrepare;
        private System.Windows.Forms.ToolStripButton btnFall;
        private System.Windows.Forms.ToolStripButton btnRise;
        private System.Windows.Forms.ToolStripButton btnDispStop;
        private System.Windows.Forms.Timer tmrAutoStopFire;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem NetLinkStarted;
        private System.Windows.Forms.ToolStripMenuItem RemoteTest;
        private System.Windows.Forms.ToolStripMenuItem ymfToolStripMenuItem;
    }
}

