using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester.ZJMC
{
    public partial class FormZJMCCtl : Form
    {
        FormMainZJMC frmParent;
        public FormZJMCCtl(FormMainZJMC frmZM)
        {
            InitializeComponent();
            frmParent = frmZM;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.StartRise();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.StartFall();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.StopRiseFall();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.StopLoadUnload();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.StartLoad();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.StartUnload();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.Reset();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.Install();
        }

        private void FormZJMCCtl_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmParent.plcZM.Release();
        }
    }
}