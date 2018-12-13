using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    public partial class systemconfig : Form
    {
        public systemconfig()
        {
            InitializeComponent();
        }

        private void clearSetting_Click(object sender, EventArgs e)
        {
            Cvalue.Text = "";
            Rvalue.Text = "";
            Mvalue.Text = "";
            Spacevalue.Text = "";
            JixinStyle.SelectedIndex = -1;
        }

        private void systemconfig_Load(object sender, EventArgs e)
        {

        }

        private void savesetting_Click(object sender, EventArgs e)
        {

        }
    }
}
