using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using C1.C1Pdf;

namespace JapaneseText
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private C1.C1Pdf.C1PdfDocument _c1pdf;
		private System.Windows.Forms.ComboBox _cmbLanguage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this._c1pdf = new C1.C1Pdf.C1PdfDocument();
			this._cmbLanguage = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "Create Pdf Document";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.textBox1.Location = new System.Drawing.Point(8, 40);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(328, 320);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			this.textBox1.WordWrap = false;
			// 
			// _c1pdf
			// 
			this._c1pdf.DocumentInfo.Producer = "ComponentOne C1Pdf";
			this._c1pdf.FontType = C1.C1Pdf.FontTypeEnum.Embedded;
			this._c1pdf.Security.AllowCopyContent = true;
			this._c1pdf.Security.AllowEditAnnotations = true;
			this._c1pdf.Security.AllowEditContent = true;
			this._c1pdf.Security.AllowPrint = true;
			// 
			// _cmbLanguage
			// 
			this._cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cmbLanguage.Items.AddRange(new object[] {
															  "Japanese",
															  "Chinese",
															  "Russian"});
			this._cmbLanguage.Location = new System.Drawing.Point(176, 8);
			this._cmbLanguage.Name = "_cmbLanguage";
			this._cmbLanguage.Size = new System.Drawing.Size(144, 21);
			this._cmbLanguage.TabIndex = 2;
			this._cmbLanguage.SelectedIndexChanged += new System.EventHandler(this._cmbLanguage_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(344, 373);
			this.Controls.Add(this._cmbLanguage);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "C1Pdf Eastern Text";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			_c1pdf.Clear();
			RectangleF rc = _c1pdf.PageRectangle;
			rc.Inflate(-72, -72);
			_c1pdf.DrawString(textBox1.Text, textBox1.Font, Brushes.Black, rc);

			string infoString = "single char: 不明だった炭素の";
			PdfDocumentInfo info = _c1pdf.DocumentInfo;
			info.Author		= infoString;
			info.Creator	= infoString;
			info.Keywords	= infoString;
			info.Producer	= infoString;
			info.Subject	= infoString;
			info.Title		= infoString;

			// save and show pdf document
			string fileName = string.Format(@"{0}\{1}.pdf", Path.GetDirectoryName(Application.ExecutablePath), _cmbLanguage.Text);
			_c1pdf.Save(fileName);
			Process.Start(fileName);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			_cmbLanguage.SelectedIndex = 0;
		}

		private void _cmbLanguage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (_cmbLanguage.Text.IndexOf("Japanese") > -1)
			{
				textBox1.Text = "このうち、アメリカ合州国の森林は毎年1.4億トンの炭素を吸収している。こ";
			}
			if (_cmbLanguage.Text.IndexOf("Chinese") > -1)
			{
				textBox1.Text = "历史惊人相似 中国女排全胜战绩重圆世界冠军梦";
			}
			if (_cmbLanguage.Text.IndexOf("Russian") > -1)
			{
				textBox1.Text = "До чего же \"кроты\" изрыли нашу партию";
			}
		
//			string language = _cmbLanguage.Text.ToLower();
//			Assembly asm = Assembly.GetExecutingAssembly();
//			foreach (string res in asm.GetManifestResourceNames())
//			{
//				if (res.ToLower().IndexOf(language) > -1)
//				{
//					StreamReader sr = new StreamReader(asm.GetManifestResourceStream(res));
//					textBox1.Text = sr.ReadToEnd();
//					textBox1.Refresh();
//					break;
//				}
//			}
		}
	}
}
