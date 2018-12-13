using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    public partial class netgdsystem : Form
    {
        public netgdsystem()
        {
            InitializeComponent();
        }

        private void userlogin_Click(object sender, EventArgs e)
        {
            GdLogin mydlg = new GdLogin();
            Init();
            mydlg.ShowDialog();
            if (mydlg.Getlogin())
            {
                DeviceList.Visible = true;
                BtRootLinkDevice.Visible = true;
                RootLinkDevice.Visible = true;
                //this.BackgroundImage = null;
                toolStripStatusLb.Text = " »¶Ó­ Äú ³É¹¦µÇÂ½ÍøÂçÏµÍ³£¡ ";
            }
        }

        private void netgdsystem_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            DeviceList.Visible = false;
            BtRootLinkDevice.Visible = false;
            RootLinkDevice.Visible = false;
            toolStripStatusLb.Text = " ÍøÂçÊ§Áª£¡";
        }

        private void QuitSystem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RootLinkDevice_Click(object sender, EventArgs e)
        {

        }

        private void DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
           if  (e.Node.Tag.ToString().Equals("1"))
           {
               RemoteControl dlg = new RemoteControl();
               dlg.Show();
           }
           else if (e.Node.Tag.ToString().Equals("2"))
           {
           }
           else if (e.Node.Tag.ToString().Equals("3"))
           {
               mainframe dlg = new mainframe();
               dlg.Show();
           }
           else if (e.Node.Tag.ToString().Equals("4"))
           {
               ;
           }
           else if (e.Node.Tag.ToString().Equals("5"))
           {
           }
        }

        private void NetAbouts_Click(object sender, EventArgs e)
        {
            Abouts mydlg = new Abouts();
            mydlg.Show();
        }
   }
}