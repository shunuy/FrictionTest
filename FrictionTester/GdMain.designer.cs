namespace FrictionTester
{
    partial class netgdsystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(netgdsystem));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("浏阳火焰1号");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("浏阳火焰2号");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("浏阳火焰3号");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("浏阳火焰4号");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("浏阳火焰5号");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("火焰", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("浏阳摩擦1号");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("浏阳摩擦2号");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("浏阳摩擦3号");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("浏阳摩擦4号");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("浏阳摩擦5号");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("摩擦", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("浏阳静电1号");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("浏阳静电2号");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("浏阳静电3号");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("浏阳静电4号");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("浏阳静电5号");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("静电", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("浏阳撞击1号");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("浏阳撞击2号");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("浏阳撞击3号");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("浏阳撞击4号");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("浏阳撞击5号");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("撞击", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("爆发点1号");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("爆发点", new System.Windows.Forms.TreeNode[] {
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("网络感度设备", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode12,
            treeNode18,
            treeNode24,
            treeNode26});
            this.mainmenu = new System.Windows.Forms.MenuStrip();
            this.系统功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RootLinkDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.userlogin = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetAbouts = new System.Windows.Forms.ToolStripMenuItem();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLb = new System.Windows.Forms.ToolStripStatusLabel();
            this.Systemtools = new System.Windows.Forms.ToolStrip();
            this.BtRootLinkDevice = new System.Windows.Forms.ToolStripButton();
            this.DeviceList = new System.Windows.Forms.TreeView();
            this.mainmenu.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.Systemtools.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainmenu
            // 
            this.mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统功能ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.mainmenu.Location = new System.Drawing.Point(0, 0);
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(870, 40);
            this.mainmenu.TabIndex = 0;
            this.mainmenu.Text = "mainmenu";
            // 
            // 系统功能ToolStripMenuItem
            // 
            this.系统功能ToolStripMenuItem.AutoSize = false;
            this.系统功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RootLinkDevice,
            this.userlogin,
            this.QuitSystem});
            this.系统功能ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.系统功能ToolStripMenuItem.Name = "系统功能ToolStripMenuItem";
            this.系统功能ToolStripMenuItem.Size = new System.Drawing.Size(56, 36);
            this.系统功能ToolStripMenuItem.Text = " 网 络 ";
            // 
            // RootLinkDevice
            // 
            this.RootLinkDevice.Name = "RootLinkDevice";
            this.RootLinkDevice.Size = new System.Drawing.Size(208, 26);
            this.RootLinkDevice.Text = "远程连接感度设备";
            this.RootLinkDevice.Click += new System.EventHandler(this.RootLinkDevice_Click);
            // 
            // userlogin
            // 
            this.userlogin.Name = "userlogin";
            this.userlogin.Size = new System.Drawing.Size(208, 26);
            this.userlogin.Text = "登陆平台";
            this.userlogin.Click += new System.EventHandler(this.userlogin_Click);
            // 
            // QuitSystem
            // 
            this.QuitSystem.Name = "QuitSystem";
            this.QuitSystem.Size = new System.Drawing.Size(208, 26);
            this.QuitSystem.Text = "退出系统";
            this.QuitSystem.Click += new System.EventHandler(this.QuitSystem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NetAbouts});
            this.关于ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(69, 36);
            this.关于ToolStripMenuItem.Text = " 帮 助 ";
            // 
            // NetAbouts
            // 
            this.NetAbouts.Name = "NetAbouts";
            this.NetAbouts.Size = new System.Drawing.Size(112, 26);
            this.NetAbouts.Text = "关于";
            this.NetAbouts.Click += new System.EventHandler(this.NetAbouts_Click);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLb});
            this.statusbar.Location = new System.Drawing.Point(0, 503);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(870, 22);
            this.statusbar.TabIndex = 1;
            this.statusbar.Text = "statusbar";
            // 
            // toolStripStatusLb
            // 
            this.toolStripStatusLb.AutoSize = false;
            this.toolStripStatusLb.Name = "toolStripStatusLb";
            this.toolStripStatusLb.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLb.Text = "未连接网络！";
            this.toolStripStatusLb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Systemtools
            // 
            this.Systemtools.AutoSize = false;
            this.Systemtools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtRootLinkDevice});
            this.Systemtools.Location = new System.Drawing.Point(0, 40);
            this.Systemtools.Name = "Systemtools";
            this.Systemtools.Size = new System.Drawing.Size(870, 45);
            this.Systemtools.TabIndex = 3;
            this.Systemtools.Text = "工具状态条";
            // 
            // BtRootLinkDevice
            // 
            this.BtRootLinkDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtRootLinkDevice.Image = ((System.Drawing.Image)(resources.GetObject("BtRootLinkDevice.Image")));
            this.BtRootLinkDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtRootLinkDevice.Name = "BtRootLinkDevice";
            this.BtRootLinkDevice.Size = new System.Drawing.Size(23, 42);
            this.BtRootLinkDevice.Text = "远程连接设备";
            // 
            // DeviceList
            // 
            this.DeviceList.BackColor = System.Drawing.Color.Cyan;
            this.DeviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DeviceList.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeviceList.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeviceList.Location = new System.Drawing.Point(0, 85);
            this.DeviceList.Name = "DeviceList";
            treeNode1.Name = "节点2";
            treeNode1.Tag = "1";
            treeNode1.Text = "浏阳火焰1号";
            treeNode2.Name = "节点16";
            treeNode2.Tag = "1";
            treeNode2.Text = "浏阳火焰2号";
            treeNode3.Name = "节点1";
            treeNode3.Tag = "1";
            treeNode3.Text = "浏阳火焰3号";
            treeNode4.Name = "节点2";
            treeNode4.Text = "浏阳火焰4号";
            treeNode5.Name = "节点3";
            treeNode5.Text = "浏阳火焰5号";
            treeNode6.Name = "fire";
            treeNode6.Tag = "0";
            treeNode6.Text = "火焰";
            treeNode7.Name = "节点4";
            treeNode7.Tag = "2";
            treeNode7.Text = "浏阳摩擦1号";
            treeNode8.Name = "节点17";
            treeNode8.Tag = "2";
            treeNode8.Text = "浏阳摩擦2号";
            treeNode9.Name = "节点4";
            treeNode9.Tag = "2";
            treeNode9.Text = "浏阳摩擦3号";
            treeNode10.Name = "节点5";
            treeNode10.Tag = "2";
            treeNode10.Text = "浏阳摩擦4号";
            treeNode11.Name = "节点6";
            treeNode11.Tag = "2";
            treeNode11.Text = "浏阳摩擦5号";
            treeNode12.Name = "friction";
            treeNode12.Tag = "0";
            treeNode12.Text = "摩擦";
            treeNode13.Name = "节点15";
            treeNode13.Tag = "3";
            treeNode13.Text = "浏阳静电1号";
            treeNode14.Name = "节点7";
            treeNode14.Tag = "3";
            treeNode14.Text = "浏阳静电2号";
            treeNode15.Name = "节点8";
            treeNode15.Tag = "3";
            treeNode15.Text = "浏阳静电3号";
            treeNode16.Name = "节点9";
            treeNode16.Tag = "3";
            treeNode16.Text = "浏阳静电4号";
            treeNode17.Name = "节点10";
            treeNode17.Tag = "3";
            treeNode17.Text = "浏阳静电5号";
            treeNode18.Name = "节点10";
            treeNode18.Tag = "5";
            treeNode18.Text = "静电";
            treeNode19.Name = "节点18";
            treeNode19.Tag = "4";
            treeNode19.Text = "浏阳撞击1号";
            treeNode20.Name = "节点11";
            treeNode20.Tag = "4";
            treeNode20.Text = "浏阳撞击2号";
            treeNode21.Name = "节点12";
            treeNode21.Tag = "4";
            treeNode21.Text = "浏阳撞击3号";
            treeNode22.Name = "节点13";
            treeNode22.Tag = "4";
            treeNode22.Text = "浏阳撞击4号";
            treeNode23.Name = "节点14";
            treeNode23.Tag = "4";
            treeNode23.Text = "浏阳撞击5号";
            treeNode24.Name = "节点11";
            treeNode24.Tag = "0";
            treeNode24.Text = "撞击";
            treeNode25.Name = "节点19";
            treeNode25.Tag = "5";
            treeNode25.Text = "爆发点1号";
            treeNode26.Name = "节点14";
            treeNode26.Tag = "0";
            treeNode26.Text = "爆发点";
            treeNode27.Name = "AllDevices";
            treeNode27.Tag = "0";
            treeNode27.Text = "网络感度设备";
            this.DeviceList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode27});
            this.DeviceList.Size = new System.Drawing.Size(252, 418);
            this.DeviceList.TabIndex = 4;
            this.DeviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DeviceList_AfterSelect);
            // 
            // netgdsystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(870, 525);
            this.Controls.Add(this.DeviceList);
            this.Controls.Add(this.Systemtools);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.mainmenu);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mainmenu;
            this.Name = "netgdsystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络感度系统";
            this.Load += new System.EventHandler(this.netgdsystem_Load);
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.Systemtools.ResumeLayout(false);
            this.Systemtools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainmenu;
        private System.Windows.Forms.ToolStripMenuItem 系统功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NetAbouts;
        private System.Windows.Forms.ToolStripMenuItem RootLinkDevice;
        private System.Windows.Forms.ToolStripMenuItem userlogin;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLb;
        private System.Windows.Forms.ToolStripMenuItem QuitSystem;
        private System.Windows.Forms.ToolStrip Systemtools;
        private System.Windows.Forms.ToolStripButton BtRootLinkDevice;
        private System.Windows.Forms.TreeView DeviceList;
    }
}

