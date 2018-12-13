using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void btnRise_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xF7);
        }

        private void btnFall_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xF8);
        }

        private void btnBeepOpen_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xF5);
        }

        private void btnBeepClose_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xF6);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xF9);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xFA);
        }

  

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "电机速度：" + trackBar1.Value.ToString();
        }

        private void btnStartFire_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xFB);
        }

        private void btnStopFire_Click(object sender, EventArgs e)
        {
            GlobalData.serialPort.TxdCommand(0xFC);
        }

        private void tbarPWM_Scroll(object sender, EventArgs e)
        {
            lblPWM.Text = "加热占空比：" + tbarPWM.Value.ToString();
        }

     

              private void btnSetMotorSpeed_Click(object sender, EventArgs e)
        {
            Int16 aa = (Int16)trackBar1.Value;
            GlobalData.serialPort.TxdCommand(0xE0, aa);     

        }

        private void btnPWM_Click(object sender, EventArgs e)
        {

            Int16 aa = (Int16)tbarPWM.Value;
            GlobalData.serialPort.TxdCommand(0xE1, aa);
        }

  

        private void chkPWM_CheckedChanged(object sender, EventArgs e)
        {

            if(chkPWM.Checked)     GlobalData.serialPort.TxdCommand(0xB0,0x01);
            else  GlobalData.serialPort.TxdCommand(0xB0, 0x00);
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDebug.Checked) GlobalData.serialPort.TxdCommand(0xB1, 0x01);
            else GlobalData.serialPort.TxdCommand(0xB1, 0x00);
        }

        private void FormControl_Load(object sender, EventArgs e)
        {
          
        }

        private void btnFanOn_Click(object sender, EventArgs e)
        {
            Int16 aa = 0;
            GlobalData.serialPort.TxdCommand(0xF1, aa);
        }

        private void btnFanOFF_Click(object sender, EventArgs e)
        {
            Int16 aa = 0;
            GlobalData.serialPort.TxdCommand(0xF2, aa);
        }

        private void btnHeatON_Click(object sender, EventArgs e)
        {
            Int16 aa = 0;
            GlobalData.serialPort.TxdCommand(0xF3, aa);
        }

        private void btnHeatOFF_Click(object sender, EventArgs e)
        {
            Int16 aa = 0;
            GlobalData.serialPort.TxdCommand(0xF4, aa);
        }

        private void btnHenWenOn_Click(object sender, EventArgs e)
        {
            Int16 aa = 0;
            GlobalData.serialPort.TxdCommand(0xEE, aa);
        }

        private void btnHenWenOFF_Click(object sender, EventArgs e)
        {
            Int16 aa = 0;
            GlobalData.serialPort.TxdCommand(0xEF, aa);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label4.Text = SerialPortControl.Dio_in_Data0.ToString();
            label2.Text = GlobalData.MainTemperature.ToString("F1");
            label10.Text = GlobalData.ConstantTempMode.ToString();

            if ((SerialPortControl.Dio_in_Data0 & 0x01) == 0) lblHourTop.Text = Properties.Resources.ManualPositionIn;
            else lblHourTop.Text = Properties.Resources.ManualPositionOut;
            if ((SerialPortControl.Dio_in_Data0 & 0x02) == 0) lblHourBottom.Text = Properties.Resources.ManualPositionIn;
            else lblHourBottom.Text = Properties.Resources.ManualPositionOut;
            if ((SerialPortControl.Dio_in_Data0 & 0x04) == 0) lblPosition.Text = Properties.Resources.ManualPositionIn;
            else lblPosition.Text = Properties.Resources.ManualPositionOut;


            if ((SerialPortControl.Dio_in_Data0 & 0x10) == 0) lblFanCtrl.Text = Properties.Resources.ManualPositionIn;
            else lblFanCtrl.Text = Properties.Resources.ManualPositionOut;
            if ((SerialPortControl.Dio_in_Data0 & 0x20) == 0) lblFireCtrl.Text = Properties.Resources.ManualPositionIn;
            else lblFireCtrl.Text = Properties.Resources.ManualPositionOut;
            if ((SerialPortControl.Dio_in_Data0 & 0x40) == 0) lblRiseFallCtrl.Text = Properties.Resources.ManualPositionIn;
            else lblRiseFallCtrl.Text = Properties.Resources.ManualPositionOut;
            if ((SerialPortControl.Dio_in_Data0 & 0x80) == 0) lblRotateCtrl.Text = Properties.Resources.ManualPositionIn;
            else lblRotateCtrl.Text = Properties.Resources.ManualPositionOut;


            if ((SerialPortControl.Dio_in_Data1 & 0x10) == 0) lblFireCtrl.Text = Properties.Resources.ManualPositionIn;
            else lblFireCtrl.Text = Properties.Resources.ManualPositionOut;
        }

    

     
    }
}