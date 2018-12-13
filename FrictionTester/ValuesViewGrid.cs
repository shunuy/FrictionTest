using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrictionTester
{
    class ValuesViewGrid
    {
        private const int TestMaxCount = 25;  //最大测试试样点数
        private int[] values = new int[TestMaxCount];
        private bool[] colorvalues = new bool[TestMaxCount];
        private int h = 20;
        private int rows = 9, cols = 30;
        private int startx = 10, starty = 10;
        private int selectcolindex = -1;
        private int startposition = 0;
        private int endposition = -1;

        public ValuesViewGrid()
        {
            ClearData();
        }

        private void ClearData()
        {
            for (int k = 0; k < TestMaxCount; k++)
            {
                values[k] = 0;
                colorvalues[0] = false;
            }
            MoniSetdata();
        }

        private void MoniSetdata()
        {
            values[0] = 0;
            values[1] = 1;
            values[2] = 2;
            values[3] = 1;
            values[4] = 0;
            values[5] = -1;
            values[6] = 0;
            values[7] = 1;
            values[8] = 1;
            values[9] = 2;
            values[10] = 2;
            values[11] = 3;
            values[12] = 4;
            values[13] = 3;
            values[14] = 2;
            values[15] = 1;
            values[16] = 0;
            values[17] = -1;
            values[18] = -2;
            values[19] = -3;
            values[20] = -2;
            values[21] = -1;
            values[22] = 0;
            values[23] = 1;
            values[24] = 1;
            colorvalues[0] = false;
            colorvalues[1] = false;
            colorvalues[2] = false;
            colorvalues[3] = false;
            colorvalues[4] = false;
            colorvalues[5] = false;
            colorvalues[6] = true;
            colorvalues[7] = false;
            colorvalues[8] = true;
            colorvalues[9] = false;
            colorvalues[10] = true;
            colorvalues[11] = false;
            colorvalues[12] = true;
            colorvalues[13] = false;
            colorvalues[14] = false;
            colorvalues[15] = false;
            colorvalues[16] = false;
            colorvalues[17] = true;
            colorvalues[18] = true;
            colorvalues[19] = true;
            colorvalues[20] = true;
            colorvalues[21] = true;
            colorvalues[22] = true;
            colorvalues[23] = true;
            colorvalues[24] = true;
        }

        public void AddFirePos(bool value)  //true = 发火 false = 瞎火
        {
            if (endposition < TestMaxCount)
            {
                endposition = endposition + 1;
                colorvalues[endposition] = value;
                if (value)
                    values[endposition + 1] = values[endposition] - 1;
                else
                    values[endposition + 1] = values[endposition] + 1;
            }
        }

        public int MouseMove(MouseEventArgs e)
        {
            int CurrentSelectY = e.Y - starty;
            int CurrentSelectX = e.X - startx;
            if (CurrentSelectX < 0 || CurrentSelectX > cols * h + cols || CurrentSelectY < 0 || CurrentSelectY > rows * h + rows)
            {
                selectcolindex = -1;
                return -1;
            }
            selectcolindex = CurrentSelectX / (h + 1);
            return selectcolindex;
        }

        public int GetCurrentValue(int index)
        {
            if (index == -1 || index + startposition > TestMaxCount - 1)
                return -100;
            else
                return this.values[index + startposition];
        }

        public int GetCurrentColorValue(int index)
        {
            if (index == -1 || index + startposition > TestMaxCount - 1 )
                return -100;
            else
            {
                if (colorvalues[index + startposition])
                    return 1;
                else
                    return 0;
            }

        }

        public int GetStartPosition()
        {
            return startposition;
        }

        public void SetStartPosition(int value)
        {
            if (value > -1 && value < TestMaxCount)
               startposition = value;
        }

        public void ShowDataList(ListBox list)
        {
            list.Items.Clear();
            for (int k = 0; k < TestMaxCount; k++)
            {
                float myvalues = values[k] * 0.05f + 60;
                int row = k + 1;
                if (colorvalues[k])
                    list.Items.Add(row.ToString() + " 发火 " + myvalues.ToString() + "KV");
                else
                    list.Items.Add(row.ToString() + " 瞎火 " + myvalues.ToString() + "KV");
            }
        }


        public void ShowGrids(PaintEventArgs e, PictureBox fireon, PictureBox fireoff, PictureBox swim)
        {
            Graphics g = e.Graphics;
            Pen myPen = Pens.Blue;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);//画刷 


            for (int i = 0; i < cols + 1; i++)
            {
                g.DrawLine(myPen, new Point(i + i * h + startx, starty), new Point(i + i * h + startx, rows * h + rows + starty));
            }

            for (int j = 0; j < rows + 1; j++)
            {
                g.DrawLine(myPen, new Point(startx, j + j * h + starty), new Point(cols * h + cols + startx, j + j * h + starty));
            }

            for (int i = 0; i + startposition < TestMaxCount; i++)
            {
                if (colorvalues[i + startposition])
                {
                    g.DrawImage(fireon.BackgroundImage, i + i * h + startx + 5, 4 + 4 * h + starty + h * values[i + startposition] + 5 + values[i + startposition]);
                }
                else
                {
                    g.DrawImage(fireoff.BackgroundImage, i + i * h + startx + 5, 4 + 4 * h + starty + h * values[i + startposition] + 5 + values[i + startposition]);
                }
            }

            if (selectcolindex > -1 && selectcolindex + startposition < TestMaxCount)
                g.DrawImage(swim.BackgroundImage, selectcolindex + selectcolindex * h + startx + 5, starty + 5 );

        }
    }
}
