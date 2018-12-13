using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    public partial class FormManualTestZJMC : Form
    {
        public FormManualTestZJMC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Rise);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fire);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Stop_Fire);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Fall);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Disp_Stop);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Beep_On);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Beep_Off);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label1.Text = "电机速度:" + trackBar2.Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Int16 aa = (Int16)trackBar2.Value;
            GlobalData.serialPort.TxdCommand(0xE1, aa);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Auto_Mode,1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(SerialPortControl.Command_Auto_Mode,0);
        }
    }
}