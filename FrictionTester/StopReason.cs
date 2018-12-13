using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    public partial class StopReason : Form
    {
        public int selectindex = 2;
        public StopReason()
        {
            InitializeComponent();
        }

        private void testsuccess_Click(object sender, EventArgs e)
        {
            selectindex = 0;
            this.Close();
        }

        private void testnofire_Click(object sender, EventArgs e)
        {
            selectindex = 1;
            this.Close();
        }

        private void testfail_Click(object sender, EventArgs e)
        {
            selectindex = 2;
            this.Close();
        }

        private void StopReason_Load(object sender, EventArgs e)
        {

        }

        private void endfire_Click(object sender, EventArgs e)
        {
            selectindex = 3;
            this.Close();
        }

    }
}
