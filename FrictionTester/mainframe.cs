using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    
    public partial class mainframe : Form
    {
        private SystemStateWiew statedlg = null;
        ValuesViewGrid grid = new ValuesViewGrid();

        public mainframe()
        {
            InitializeComponent();
            grid.ShowDataList(DataList);
        }

        private void quitsystem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainframe_Load(object sender, EventArgs e)
        {

        }

        private void SystemAbouts_Click(object sender, EventArgs e)
        {
   
        }


        private void ExitSystem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SystemStateWinViews_Click(object sender, EventArgs e)
        {
            if (statedlg != null)
                statedlg.Close();   
            statedlg = new SystemStateWiew();
            statedlg.TopLevel = false;
            statedlg.Parent = this.TestViewBox;
            statedlg.Show();
        }

        private void systemconfig_Click(object sender, EventArgs e)
        {
           systemconfig dlg =new systemconfig();
           dlg.ShowDialog();
        }

        private void DeviceControl_Click(object sender, EventArgs e)
        {
            DeviceControl devdlg = new DeviceControl();
            devdlg.ShowDialog();
        }

        private void StopReason_Click(object sender, EventArgs e)
        {
            StopReason dlg = new StopReason();
            dlg.ShowDialog();
        }

        private void SeTongXun_Click(object sender, EventArgs e)
        {
            systemconfig dlg = new systemconfig();
            dlg.ShowDialog();
        }

        private void TestViewBox_Paint(object sender, PaintEventArgs e)
        {
            grid.ShowGrids(e, PictureFire,picfireoff,swimpic);
        }

        private void ExampFireOpen_Click(object sender, EventArgs e)
        {
            DeviceControl dlg = new DeviceControl();
            dlg.ShowDialog();
        }

        private void adam6024ToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void TestViewBox_MouseMove(object sender, MouseEventArgs e)
        {
            int CurrentColIndex = grid.MouseMove(e);
            int ShowColIndex = CurrentColIndex + 1 + grid.GetStartPosition();
            SelectColIndex.Text = ShowColIndex.ToString();
            int getvalue = grid.GetCurrentColorValue(CurrentColIndex);
            if (getvalue == -100)
                CurrentSelectValue.Text = "无取值";
            else if (getvalue == 1)
                CurrentSelectValue.Text = "发火";
            else if (getvalue == 0)
                CurrentSelectValue.Text = "瞎火";
            getvalue = grid.GetCurrentValue(CurrentColIndex);
            if (getvalue == -100)
                CurrentGetValue.Text = "无取值";
            else
            {
                float jisuangvalue = getvalue * 0.05f + 60;
                CurrentGetValue.Text = jisuangvalue.ToString() + " KV";
            }
            TestViewBox.Refresh();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TestViewBox_Click(object sender, EventArgs e)
        {

        }

        private void viewbar_Scroll(object sender, ScrollEventArgs e)
        {
            grid.SetStartPosition(viewbar.Value);
            TestViewBox.Refresh();
        }

    }
}
