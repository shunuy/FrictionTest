using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SDAF.DataBase
{
    public partial class FormPDF : Form
    {
        string filename;
        public FormPDF(string pdfName)
        {
            InitializeComponent();
            filename = "C:\\JCJC\\birt\\reportPdfFiles\\" + pdfName + ".pdf";
        }

        private void FormPDF_Load(object sender, EventArgs e)
        {
         

         
            //c1PrintPreview1.FileOpen(filename);
        }

        string MyOpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog(); ofd.Filter = "PDFÎÄµµ(*.pdf)|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK) { return ofd.FileName; } else { return null; }
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void FormPDF_Shown(object sender, EventArgs e)
        {
            //string filename ="C:\\JCJC\\birt\\reportPdfFiles\\201612251531.pdf";// MyOpenFileDialog();

            axAcroPDF1.LoadFile(filename);

 

        }
    }
}