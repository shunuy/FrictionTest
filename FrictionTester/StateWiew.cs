using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    public partial class SystemStateWiew : Form
    {
        public SystemStateWiew()
        {
            InitializeComponent();
            debugmsglist.Items.Clear();
            this.TracePrintf(DateTime.Now.ToString() +" 状态查看窗口启动！");
        }
        public void TracePrintf(String words)
        {
            debugmsglist.Items.Add(words);
        }

        private void debugmsglist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
