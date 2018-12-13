using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Charts
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private C1.Win.C1Chart.C1Chart c1Chart1;
		private C1.Win.C1Chart.C1Chart c1Chart2;
		private C1.Win.C1Chart.C1Chart c1Chart3;
		private C1.Win.C1Chart.C1Chart c1Chart4;
		private C1.Win.C1Chart.C1Chart c1Chart5;
		private C1.Win.C1Chart.C1Chart c1Chart6;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D1;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D2;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D3;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D4;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D5;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D6;
		private System.Windows.Forms.Button button1;
		private C1.C1Pdf.C1PdfDocument _c1pdf;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D7;
		private C1.Win.C1Chart3D.C1Chart3D c1Chart3D8;
		private C1.Win.C1Chart.C1Chart c1Chart7;
		private C1.Win.C1Chart.C1Chart c1Chart8;
		private System.Windows.Forms.Label label1;
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.c1Chart1 = new C1.Win.C1Chart.C1Chart();
			this.c1Chart2 = new C1.Win.C1Chart.C1Chart();
			this.c1Chart3 = new C1.Win.C1Chart.C1Chart();
			this.c1Chart5 = new C1.Win.C1Chart.C1Chart();
			this.c1Chart6 = new C1.Win.C1Chart.C1Chart();
			this.c1Chart4 = new C1.Win.C1Chart.C1Chart();
			this.c1Chart7 = new C1.Win.C1Chart.C1Chart();
			this.c1Chart8 = new C1.Win.C1Chart.C1Chart();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.c1Chart3D1 = new C1.Win.C1Chart3D.C1Chart3D();
			this.c1Chart3D2 = new C1.Win.C1Chart3D.C1Chart3D();
			this.c1Chart3D3 = new C1.Win.C1Chart3D.C1Chart3D();
			this.c1Chart3D4 = new C1.Win.C1Chart3D.C1Chart3D();
			this.c1Chart3D6 = new C1.Win.C1Chart3D.C1Chart3D();
			this.c1Chart3D5 = new C1.Win.C1Chart3D.C1Chart3D();
			this.c1Chart3D7 = new C1.Win.C1Chart3D.C1Chart3D();
			this.c1Chart3D8 = new C1.Win.C1Chart3D.C1Chart3D();
			this.button1 = new System.Windows.Forms.Button();
			this._c1pdf = new C1.C1Pdf.C1PdfDocument();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart8)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D8)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2});
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(626, 352);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.c1Chart1,
																				   this.c1Chart2,
																				   this.c1Chart3,
																				   this.c1Chart5,
																				   this.c1Chart6,
																				   this.c1Chart4,
																				   this.c1Chart7,
																				   this.c1Chart8});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(618, 326);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "2D Charts";
			// 
			// c1Chart1
			// 
			this.c1Chart1.DataSource = null;
			this.c1Chart1.Location = new System.Drawing.Point(8, 8);
			this.c1Chart1.Name = "c1Chart1";
			this.c1Chart1.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>Border=None,Control,1;</StyleData></Nam" +
				"edStyle><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\"><StyleData /></Nam" +
				"edStyle><NamedStyle Name=\"Footer\" ParentName=\"Control\"><StyleData>Border=None,Co" +
				"ntrol,1;</StyleData></NamedStyle><NamedStyle Name=\"Area\" ParentName=\"Area.defaul" +
				"t\"><StyleData /></NamedStyle><NamedStyle Name=\"Control\" ParentName=\"Control.defa" +
				"ult\"><StyleData /></NamedStyle><NamedStyle Name=\"AxisX\" ParentName=\"Area\"><Style" +
				"Data>Rotation=Rotate0;Border=None,Control,1;AlignHorz=Center;BackColor=Transpare" +
				"nt;Opaque=False;AlignVert=Bottom;</StyleData></NamedStyle><NamedStyle Name=\"Axis" +
				"Y\" ParentName=\"Area\"><StyleData>Rotation=Rotate270;Border=None,Control,1;AlignHo" +
				"rz=Near;BackColor=Transparent;Opaque=False;AlignVert=Center;</StyleData></NamedS" +
				"tyle><NamedStyle Name=\"LabelStyleDefault\" ParentName=\"LabelStyleDefault.default\"" +
				"><StyleData /></NamedStyle><NamedStyle Name=\"Legend.default\" ParentName=\"Control" +
				"\"><StyleData>Border=None,Black,1;Wrap=False;AlignVert=Top;</StyleData></NamedSty" +
				"le><NamedStyle Name=\"LabelStyleDefault.default\" ParentName=\"Control\"><StyleData>" +
				"Border=None,Control,1;BackColor=Transparent;</StyleData></NamedStyle><NamedStyle" +
				" Name=\"Header\" ParentName=\"Control\"><StyleData>Border=None,Control,1;</StyleData" +
				"></NamedStyle><NamedStyle Name=\"Control.default\" ParentName=\"\"><StyleData>ForeCo" +
				"lor=ControlText;Border=None,Control,1;BackColor=Control;</StyleData></NamedStyle" +
				"><NamedStyle Name=\"AxisY2\" ParentName=\"Area\"><StyleData>Rotation=Rotate90;Border" +
				"=None,Transparent,1;AlignHorz=Far;BackColor=Transparent;AlignVert=Center;</Style" +
				"Data></NamedStyle><NamedStyle Name=\"Area.default\" ParentName=\"Control\"><StyleDat" +
				"a>Border=None,Control,1;AlignVert=Top;</StyleData></NamedStyle></StyleCollection" +
				"><ChartGroupsCollection><ChartGroup><DataSerializer Hole=\"3.4028234663852886E+38" +
				"\" DefaultSet=\"True\"><DataSeriesCollection><DataSeriesSerializer><LineStyle Color" +
				"=\"DarkGoldenrod\" /><SymbolStyle Color=\"Coral\" Shape=\"Box\" /><SeriesLabel>series " +
				"0</SeriesLabel><X>1;2;3;4;5</X><Y>20;22;19;24;25</Y><Y1 /><Y2 /><Y3 /><DataTypes" +
				">Single;Single;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag" +
				" /></DataSeriesSerializer><DataSeriesSerializer><LineStyle Color=\"DarkGray\" /><S" +
				"ymbolStyle Color=\"CornflowerBlue\" Shape=\"Dot\" /><SeriesLabel>series 1</SeriesLab" +
				"el><X>1;2;3;4;5</X><Y>8;12;10;12;15</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Singl" +
				"e;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeri" +
				"esSerializer><DataSeriesSerializer><LineStyle Color=\"DarkGreen\" /><SymbolStyle C" +
				"olor=\"Cornsilk\" Shape=\"Tri\" /><SeriesLabel>series 2</SeriesLabel><X>1;2;3;4;5</X" +
				"><Y>10;16;17;15;23</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;D" +
				"ouble</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer><Dat" +
				"aSeriesSerializer><LineStyle Color=\"DarkKhaki\" /><SymbolStyle Color=\"Crimson\" Sh" +
				"ape=\"Diamond\" /><SeriesLabel>series 3</SeriesLabel><X>1;2;3;4;5</X><Y>16;19;15;2" +
				"2;18</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;Double</DataTyp" +
				"es><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer></DataSeriesCollec" +
				"tion></DataSerializer><Name>Group1</Name><Stacked>False</Stacked><ChartType>XYPl" +
				"ot</ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth" +
				"=50</Bar><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False,ShowClo" +
				"se=True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20,M" +
				"inimumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Polar>" +
				"<Radar>Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOutl" +
				"ine>True</ShowOutline></ChartGroup><ChartGroup><DataSerializer Hole=\"3.402823466" +
				"3852886E+38\" /><Name>Group2</Name><Stacked>False</Stacked><ChartType>XYPlot</Cha" +
				"rtType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50</Ba" +
				"r><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=True" +
				",ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20,MinimumS" +
				"ize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Polar><Radar>" +
				"Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOutline>Tru" +
				"e</ShowOutline></ChartGroup></ChartGroupsCollection><Header Compass=\"North\"><Tex" +
				"t /></Header><Footer Compass=\"South\"><Text /></Footer><Legend Compass=\"East\" Vis" +
				"ible=\"False\"><Text /></Legend><ChartArea /><Axes><Axis Max=\"5\" Min=\"1\" UnitMajor" +
				"=\"1\" UnitMinor=\"0.5\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"T" +
				"rue\" _onTop=\"0\" Compass=\"South\"><Text /><GridMajor AutoSpace=\"True\" Color=\"Light" +
				"Gray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Da" +
				"sh\" /></Axis><Axis Max=\"25\" Min=\"5\" UnitMajor=\"5\" UnitMinor=\"2.5\" AutoMajor=\"Tru" +
				"e\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"West\"><Tex" +
				"t /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor Au" +
				"toSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"0\" Min=\"0\" U" +
				"nitMajor=\"0\" UnitMinor=\"0\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" Auto" +
				"Min=\"True\" _onTop=\"0\" Compass=\"East\"><Text /><GridMajor AutoSpace=\"True\" Color=\"" +
				"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightGray\" Patter" +
				"n=\"Dash\" /></Axis></Axes></Chart2DPropBag>";
			this.c1Chart1.Size = new System.Drawing.Size(152, 152);
			this.c1Chart1.TabIndex = 0;
			// 
			// c1Chart2
			// 
			this.c1Chart2.DataSource = null;
			this.c1Chart2.Location = new System.Drawing.Point(160, 8);
			this.c1Chart2.Name = "c1Chart2";
			this.c1Chart2.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>Border=None,Control,1;Opaque=True;</Sty" +
				"leData></NamedStyle><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\"><Style" +
				"Data /></NamedStyle><NamedStyle Name=\"Footer\" ParentName=\"Control\"><StyleData>Bo" +
				"rder=None,Control,1;</StyleData></NamedStyle><NamedStyle Name=\"Area\" ParentName=" +
				"\"Area.default\"><StyleData /></NamedStyle><NamedStyle Name=\"Control\" ParentName=\"" +
				"Control.default\"><StyleData /></NamedStyle><NamedStyle Name=\"AxisX\" ParentName=\"" +
				"Area\"><StyleData>Rotation=Rotate0;Border=None,Control,1;AlignHorz=Center;BackCol" +
				"or=Transparent;Opaque=False;AlignVert=Bottom;</StyleData></NamedStyle><NamedStyl" +
				"e Name=\"AxisY\" ParentName=\"Area\"><StyleData>Rotation=Rotate270;Border=None,Contr" +
				"ol,1;AlignHorz=Near;BackColor=Transparent;Opaque=False;AlignVert=Center;</StyleD" +
				"ata></NamedStyle><NamedStyle Name=\"LabelStyleDefault\" ParentName=\"LabelStyleDefa" +
				"ult.default\"><StyleData /></NamedStyle><NamedStyle Name=\"Legend.default\" ParentN" +
				"ame=\"Control\"><StyleData>Border=None,Black,1;Wrap=False;AlignVert=Top;</StyleDat" +
				"a></NamedStyle><NamedStyle Name=\"LabelStyleDefault.default\" ParentName=\"Control\"" +
				"><StyleData>Border=None,Control,1;BackColor=Transparent;</StyleData></NamedStyle" +
				"><NamedStyle Name=\"Header\" ParentName=\"Control\"><StyleData>Border=None,Control,1" +
				";</StyleData></NamedStyle><NamedStyle Name=\"Control.default\" ParentName=\"\"><Styl" +
				"eData>ForeColor=ControlText;Border=None,Control,1;BackColor=Control;</StyleData>" +
				"</NamedStyle><NamedStyle Name=\"AxisY2\" ParentName=\"Area\"><StyleData>Rotation=Rot" +
				"ate90;Border=None,Transparent,1;AlignHorz=Far;BackColor=Transparent;AlignVert=Ce" +
				"nter;</StyleData></NamedStyle><NamedStyle Name=\"Area.default\" ParentName=\"Contro" +
				"l\"><StyleData>Border=None,Control,1;AlignVert=Top;</StyleData></NamedStyle></Sty" +
				"leCollection><ChartGroupsCollection><ChartGroup><DataSerializer Hole=\"3.40282346" +
				"63852886E+38\" DefaultSet=\"True\"><DataSeriesCollection><DataSeriesSerializer><Lin" +
				"eStyle Color=\"DarkGoldenrod\" /><SymbolStyle Color=\"Coral\" Shape=\"None\" /><Series" +
				"Label>series 0</SeriesLabel><X>1;2;3;4;5</X><Y>20;22;19;24;25</Y><Y1 /><Y2 /><Y3" +
				" /><DataTypes>Single;Single;Double;Double;Double</DataTypes><DataFields>;;;;</Da" +
				"taFields><Tag /></DataSeriesSerializer><DataSeriesSerializer><LineStyle Color=\"D" +
				"arkGray\" /><SymbolStyle Color=\"CornflowerBlue\" Shape=\"None\" /><SeriesLabel>serie" +
				"s 1</SeriesLabel><X>1;2;3;4;5</X><Y>8;12;10;12;15</Y><Y1 /><Y2 /><Y3 /><DataType" +
				"s>Single;Single;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Ta" +
				"g /></DataSeriesSerializer><DataSeriesSerializer><LineStyle Color=\"DarkGreen\" />" +
				"<SymbolStyle Color=\"Cornsilk\" Shape=\"None\" /><SeriesLabel>series 2</SeriesLabel>" +
				"<X>1;2;3;4;5</X><Y>10;16;17;15;23</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;" +
				"Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeries" +
				"Serializer><DataSeriesSerializer><LineStyle Color=\"DarkKhaki\" /><SymbolStyle Col" +
				"or=\"Crimson\" Shape=\"None\" /><SeriesLabel>series 3</SeriesLabel><X>1;2;3;4;5</X><" +
				"Y>16;19;15;22;18</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;Dou" +
				"ble</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer></Data" +
				"SeriesCollection></DataSerializer><Name>Group1</Name><Stacked>False</Stacked><Ch" +
				"artType>XYPlot</ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0," +
				"ClusterWidth=50</Bar><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=F" +
				"alse,ShowClose=True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,Maxi" +
				"mumSize=20,MinimumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Sta" +
				"rt=0</Polar><Radar>Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visib" +
				"le><ShowOutline>True</ShowOutline></ChartGroup><ChartGroup><DataSerializer Hole=" +
				"\"3.4028234663852886E+38\" /><Name>Group2</Name><Stacked>False</Stacked><ChartType" +
				">XYPlot</ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,Cluster" +
				"Width=50</Bar><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False,Sh" +
				"owClose=True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize" +
				"=20,MinimumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</P" +
				"olar><Radar>Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visible><Sho" +
				"wOutline>True</ShowOutline></ChartGroup></ChartGroupsCollection><Header Compass=" +
				"\"North\"><Text /></Header><Footer Compass=\"South\"><Text /></Footer><Legend Compas" +
				"s=\"East\" Visible=\"False\"><Text /></Legend><ChartArea Depth=\"20\" Rotation=\"45\" El" +
				"evation=\"45\" /><Axes><Axis Max=\"5\" Min=\"1\" UnitMajor=\"1\" UnitMinor=\"0.5\" AutoMaj" +
				"or=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"Sou" +
				"th\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><Grid" +
				"Minor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"25\" " +
				"Min=\"5\" UnitMajor=\"5\" UnitMinor=\"2.5\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=" +
				"\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"West\"><Text /><GridMajor AutoSpace=\"Tr" +
				"ue\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightG" +
				"ray\" Pattern=\"Dash\" /></Axis><Axis Max=\"0\" Min=\"0\" UnitMajor=\"0\" UnitMinor=\"0\" A" +
				"utoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compas" +
				"s=\"East\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" />" +
				"<GridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis></Axes></C" +
				"hart2DPropBag>";
			this.c1Chart2.Size = new System.Drawing.Size(152, 152);
			this.c1Chart2.TabIndex = 0;
			// 
			// c1Chart3
			// 
			this.c1Chart3.DataSource = null;
			this.c1Chart3.Location = new System.Drawing.Point(312, 8);
			this.c1Chart3.Name = "c1Chart3";
			this.c1Chart3.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>Border=None,Control,1;BackColor=255, 22" +
				"4, 192;Opaque=False;</StyleData></NamedStyle><NamedStyle Name=\"Legend\" ParentNam" +
				"e=\"Legend.default\"><StyleData /></NamedStyle><NamedStyle Name=\"Footer\" ParentNam" +
				"e=\"Control\"><StyleData>Border=None,Control,1;</StyleData></NamedStyle><NamedStyl" +
				"e Name=\"Area\" ParentName=\"Area.default\"><StyleData /></NamedStyle><NamedStyle Na" +
				"me=\"Control\" ParentName=\"Control.default\"><StyleData /></NamedStyle><NamedStyle " +
				"Name=\"AxisX\" ParentName=\"Area\"><StyleData>Rotation=Rotate0;Border=None,Control,1" +
				";AlignHorz=Center;BackColor=Transparent;Opaque=False;AlignVert=Bottom;</StyleDat" +
				"a></NamedStyle><NamedStyle Name=\"AxisY\" ParentName=\"Area\"><StyleData>Rotation=Ro" +
				"tate270;Border=None,Control,1;AlignHorz=Near;BackColor=Transparent;Opaque=False;" +
				"AlignVert=Center;</StyleData></NamedStyle><NamedStyle Name=\"LabelStyleDefault\" P" +
				"arentName=\"LabelStyleDefault.default\"><StyleData /></NamedStyle><NamedStyle Name" +
				"=\"Legend.default\" ParentName=\"Control\"><StyleData>Border=None,Black,1;Wrap=False" +
				";AlignVert=Top;</StyleData></NamedStyle><NamedStyle Name=\"LabelStyleDefault.defa" +
				"ult\" ParentName=\"Control\"><StyleData>Border=None,Control,1;BackColor=Transparent" +
				";</StyleData></NamedStyle><NamedStyle Name=\"Header\" ParentName=\"Control\"><StyleD" +
				"ata>Border=None,Control,1;</StyleData></NamedStyle><NamedStyle Name=\"Control.def" +
				"ault\" ParentName=\"\"><StyleData>ForeColor=ControlText;Border=None,Control,1;BackC" +
				"olor=Control;</StyleData></NamedStyle><NamedStyle Name=\"AxisY2\" ParentName=\"Area" +
				"\"><StyleData>Rotation=Rotate90;Border=None,Transparent,1;AlignHorz=Far;BackColor" +
				"=Transparent;AlignVert=Center;</StyleData></NamedStyle><NamedStyle Name=\"Area.de" +
				"fault\" ParentName=\"Control\"><StyleData>Border=None,Control,1;AlignVert=Top;</Sty" +
				"leData></NamedStyle></StyleCollection><ChartGroupsCollection><ChartGroup><DataSe" +
				"rializer Hole=\"3.4028234663852886E+38\" DefaultSet=\"True\"><DataSeriesCollection><" +
				"DataSeriesSerializer FitType=\"Spline\"><LineStyle Color=\"DarkGoldenrod\" /><Symbol" +
				"Style Color=\"Coral\" Shape=\"None\" /><SeriesLabel>series 0</SeriesLabel><X>1;2;3;4" +
				";5</X><Y>20;22;19;24;25</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Dou" +
				"ble;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer" +
				"><DataSeriesSerializer FitType=\"Spline\"><LineStyle Color=\"DarkGray\" /><SymbolSty" +
				"le Color=\"CornflowerBlue\" Shape=\"None\" /><SeriesLabel>series 1</SeriesLabel><X>1" +
				";2;3;4;5</X><Y>8;12;10;12;15</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Doubl" +
				"e;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSeria" +
				"lizer><DataSeriesSerializer FitType=\"Spline\"><LineStyle Color=\"DarkGreen\" /><Sym" +
				"bolStyle Color=\"Cornsilk\" Shape=\"None\" /><SeriesLabel>series 2</SeriesLabel><X>1" +
				";2;3;4;5</X><Y>10;16;17;15;23</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Doub" +
				"le;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSeri" +
				"alizer><DataSeriesSerializer FitType=\"Spline\"><LineStyle Color=\"DarkKhaki\" /><Sy" +
				"mbolStyle Color=\"Crimson\" Shape=\"None\" /><SeriesLabel>series 3</SeriesLabel><X>1" +
				";2;3;4;5</X><Y>16;19;15;22;18</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Doub" +
				"le;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSeri" +
				"alizer></DataSeriesCollection></DataSerializer><Name>Group1</Name><Stacked>False" +
				"</Stacked><ChartType>XYPlot</ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>Clus" +
				"terOverlap=0,ClusterWidth=50</Bar><HiLoData>FillFalling=True,FillTransparent=Tru" +
				"e,FullWidth=False,ShowClose=True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=" +
				"Diameter,MaximumSize=20,MinimumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotat" +
				"ions=True,Start=0</Polar><Radar>Degrees=True,Filled=False,Start=0</Radar><Visibl" +
				"e>True</Visible><ShowOutline>True</ShowOutline></ChartGroup><ChartGroup><DataSer" +
				"ializer Hole=\"3.4028234663852886E+38\" /><Name>Group2</Name><Stacked>False</Stack" +
				"ed><ChartType>XYPlot</ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOver" +
				"lap=0,ClusterWidth=50</Bar><HiLoData>FillFalling=True,FillTransparent=True,FullW" +
				"idth=False,ShowClose=True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diamete" +
				"r,MaximumSize=20,MinimumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=Tr" +
				"ue,Start=0</Polar><Radar>Degrees=True,Filled=False,Start=0</Radar><Visible>True<" +
				"/Visible><ShowOutline>True</ShowOutline></ChartGroup></ChartGroupsCollection><He" +
				"ader Compass=\"North\"><Text /></Header><Footer Compass=\"South\"><Text /></Footer><" +
				"Legend Compass=\"East\" Visible=\"False\"><Text /></Legend><ChartArea /><Axes><Axis " +
				"Max=\"5\" Min=\"1\" UnitMajor=\"1\" UnitMinor=\"0.5\" AutoMajor=\"True\" AutoMinor=\"True\" " +
				"AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"South\"><Text /><GridMajor Auto" +
				"Space=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Colo" +
				"r=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"25\" Min=\"5\" UnitMajor=\"5\" UnitM" +
				"inor=\"2.5\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTo" +
				"p=\"0\" Compass=\"West\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Patte" +
				"rn=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axi" +
				"s><Axis Max=\"0\" Min=\"0\" UnitMajor=\"0\" UnitMinor=\"0\" AutoMajor=\"True\" AutoMinor=\"" +
				"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"East\"><Text /><GridMajor" +
				" AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\"" +
				" Color=\"LightGray\" Pattern=\"Dash\" /></Axis></Axes></Chart2DPropBag>";
			this.c1Chart3.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3.TabIndex = 0;
			// 
			// c1Chart5
			// 
			this.c1Chart5.DataSource = null;
			this.c1Chart5.Location = new System.Drawing.Point(8, 168);
			this.c1Chart5.Name = "c1Chart5";
			this.c1Chart5.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>Border=None,Control,1;</StyleData></Nam" +
				"edStyle><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\"><StyleData /></Nam" +
				"edStyle><NamedStyle Name=\"Footer\" ParentName=\"Control\"><StyleData>Border=None,Co" +
				"ntrol,1;</StyleData></NamedStyle><NamedStyle Name=\"Area\" ParentName=\"Area.defaul" +
				"t\"><StyleData /></NamedStyle><NamedStyle Name=\"Control\" ParentName=\"Control.defa" +
				"ult\"><StyleData /></NamedStyle><NamedStyle Name=\"AxisX\" ParentName=\"Area\"><Style" +
				"Data>Rotation=Rotate270;Border=None,Control,1;AlignHorz=Near;BackColor=Transpare" +
				"nt;Opaque=False;AlignVert=Center;</StyleData></NamedStyle><NamedStyle Name=\"Axis" +
				"Y\" ParentName=\"Area\"><StyleData>Rotation=Rotate0;Border=None,Control,1;AlignHorz" +
				"=Center;BackColor=Transparent;Opaque=False;AlignVert=Bottom;</StyleData></NamedS" +
				"tyle><NamedStyle Name=\"LabelStyleDefault\" ParentName=\"LabelStyleDefault.default\"" +
				"><StyleData /></NamedStyle><NamedStyle Name=\"Legend.default\" ParentName=\"Control" +
				"\"><StyleData>Border=None,Black,1;Wrap=False;AlignVert=Top;</StyleData></NamedSty" +
				"le><NamedStyle Name=\"LabelStyleDefault.default\" ParentName=\"Control\"><StyleData>" +
				"Border=None,Control,1;BackColor=Transparent;</StyleData></NamedStyle><NamedStyle" +
				" Name=\"Header\" ParentName=\"Control\"><StyleData>Border=None,Control,1;</StyleData" +
				"></NamedStyle><NamedStyle Name=\"Control.default\" ParentName=\"\"><StyleData>ForeCo" +
				"lor=ControlText;Border=None,Control,1;BackColor=Control;</StyleData></NamedStyle" +
				"><NamedStyle Name=\"AxisY2\" ParentName=\"Area\"><StyleData>Rotation=Rotate0;Border=" +
				"None,Transparent,1;AlignHorz=Center;BackColor=Transparent;AlignVert=Top;</StyleD" +
				"ata></NamedStyle><NamedStyle Name=\"Area.default\" ParentName=\"Control\"><StyleData" +
				">Border=None,Control,1;AlignVert=Top;</StyleData></NamedStyle></StyleCollection>" +
				"<ChartGroupsCollection><ChartGroup><DataSerializer Hole=\"3.4028234663852886E+38\"" +
				" DefaultSet=\"True\"><DataSeriesCollection><DataSeriesSerializer><LineStyle Color=" +
				"\"DarkGoldenrod\" /><SymbolStyle Color=\"Coral\" Shape=\"Box\" /><SeriesLabel>series 0" +
				"</SeriesLabel><X>1;2;3;4;5</X><Y>20;22;19;24;25</Y><Y1 /><Y2 /><Y3 /><DataTypes>" +
				"Single;Single;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag " +
				"/></DataSeriesSerializer><DataSeriesSerializer><LineStyle Color=\"DarkGray\" /><Sy" +
				"mbolStyle Color=\"CornflowerBlue\" Shape=\"Dot\" /><SeriesLabel>series 1</SeriesLabe" +
				"l><X>1;2;3;4;5</X><Y>8;12;10;12;15</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single" +
				";Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSerie" +
				"sSerializer><DataSeriesSerializer><LineStyle Color=\"DarkGreen\" /><SymbolStyle Co" +
				"lor=\"Cornsilk\" Shape=\"Tri\" /><SeriesLabel>series 2</SeriesLabel><X>1;2;3;4;5</X>" +
				"<Y>10;16;17;15;23</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;Do" +
				"uble</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer><Data" +
				"SeriesSerializer><LineStyle Color=\"DarkKhaki\" /><SymbolStyle Color=\"Crimson\" Sha" +
				"pe=\"Diamond\" /><SeriesLabel>series 3</SeriesLabel><X>1;2;3;4;5</X><Y>16;19;15;22" +
				";18</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;Double</DataType" +
				"s><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer></DataSeriesCollect" +
				"ion></DataSerializer><Name>Group1</Name><Stacked>False</Stacked><ChartType>Bar</" +
				"ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50<" +
				"/Bar><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=T" +
				"rue,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20,Minim" +
				"umSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Polar><Rad" +
				"ar>Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOutline>" +
				"True</ShowOutline></ChartGroup><ChartGroup><DataSerializer Hole=\"3.4028234663852" +
				"886E+38\" /><Name>Group2</Name><Stacked>False</Stacked><ChartType>XYPlot</ChartTy" +
				"pe><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50</Bar><H" +
				"iLoData>FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=True,Sho" +
				"wOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20,MinimumSize=" +
				"5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Polar><Radar>Degr" +
				"ees=True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOutline>True</S" +
				"howOutline></ChartGroup></ChartGroupsCollection><Header Compass=\"North\"><Text />" +
				"</Header><Footer Compass=\"South\"><Text /></Footer><Legend Compass=\"East\" Visible" +
				"=\"False\"><Text /></Legend><ChartArea Inverted=\"True\" Depth=\"20\" Rotation=\"45\" El" +
				"evation=\"45\" /><Axes><Axis Max=\"5.5\" Min=\"0.5\" UnitMajor=\"1\" UnitMinor=\"0.5\" Aut" +
				"oMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=" +
				"\"West\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><G" +
				"ridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"2" +
				"5\" Min=\"5\" UnitMajor=\"5\" UnitMinor=\"2.5\" AutoMajor=\"True\" AutoMinor=\"True\" AutoM" +
				"ax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"South\"><Text /><GridMajor AutoSpace" +
				"=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"Li" +
				"ghtGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"0\" Min=\"0\" UnitMajor=\"0\" UnitMinor=\"" +
				"0\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Co" +
				"mpass=\"North\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Das" +
				"h\" /><GridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis></Axe" +
				"s></Chart2DPropBag>";
			this.c1Chart5.Size = new System.Drawing.Size(152, 152);
			this.c1Chart5.TabIndex = 0;
			// 
			// c1Chart6
			// 
			this.c1Chart6.DataSource = null;
			this.c1Chart6.Location = new System.Drawing.Point(160, 168);
			this.c1Chart6.Name = "c1Chart6";
			this.c1Chart6.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>Border=None,Control,1;</StyleData></Nam" +
				"edStyle><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\"><StyleData /></Nam" +
				"edStyle><NamedStyle Name=\"Footer\" ParentName=\"Control\"><StyleData>Border=None,Co" +
				"ntrol,1;</StyleData></NamedStyle><NamedStyle Name=\"Area\" ParentName=\"Area.defaul" +
				"t\"><StyleData /></NamedStyle><NamedStyle Name=\"Control\" ParentName=\"Control.defa" +
				"ult\"><StyleData /></NamedStyle><NamedStyle Name=\"AxisX\" ParentName=\"Area\"><Style" +
				"Data>Rotation=Rotate0;Border=None,Control,1;AlignHorz=Center;BackColor=Transpare" +
				"nt;Opaque=False;AlignVert=Bottom;</StyleData></NamedStyle><NamedStyle Name=\"Axis" +
				"Y\" ParentName=\"Area\"><StyleData>Rotation=Rotate270;Border=None,Control,1;AlignHo" +
				"rz=Near;BackColor=Transparent;Opaque=False;AlignVert=Center;</StyleData></NamedS" +
				"tyle><NamedStyle Name=\"LabelStyleDefault\" ParentName=\"LabelStyleDefault.default\"" +
				"><StyleData /></NamedStyle><NamedStyle Name=\"Legend.default\" ParentName=\"Control" +
				"\"><StyleData>Border=None,Black,1;Wrap=False;AlignVert=Top;</StyleData></NamedSty" +
				"le><NamedStyle Name=\"LabelStyleDefault.default\" ParentName=\"Control\"><StyleData>" +
				"Border=None,Control,1;BackColor=Transparent;</StyleData></NamedStyle><NamedStyle" +
				" Name=\"Header\" ParentName=\"Control\"><StyleData>Border=None,Control,1;</StyleData" +
				"></NamedStyle><NamedStyle Name=\"Control.default\" ParentName=\"\"><StyleData>ForeCo" +
				"lor=ControlText;Border=None,Control,1;BackColor=Control;</StyleData></NamedStyle" +
				"><NamedStyle Name=\"AxisY2\" ParentName=\"Area\"><StyleData>Rotation=Rotate90;Border" +
				"=None,Transparent,1;AlignHorz=Far;BackColor=Transparent;AlignVert=Center;</Style" +
				"Data></NamedStyle><NamedStyle Name=\"Area.default\" ParentName=\"Control\"><StyleDat" +
				"a>Border=None,Control,1;AlignVert=Top;</StyleData></NamedStyle></StyleCollection" +
				"><ChartGroupsCollection><ChartGroup><DataSerializer Hole=\"3.4028234663852886E+38" +
				"\" DefaultSet=\"True\"><DataSeriesCollection><DataSeriesSerializer><LineStyle Color" +
				"=\"DarkGoldenrod\" /><SymbolStyle Color=\"Coral\" Shape=\"Box\" /><SeriesLabel>series " +
				"0</SeriesLabel><X>1;2;3;4;5</X><Y>20;22;19;24;25</Y><Y1 /><Y2 /><Y3 /><DataTypes" +
				">Single;Single;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag" +
				" /></DataSeriesSerializer><DataSeriesSerializer><LineStyle Color=\"DarkGray\" /><S" +
				"ymbolStyle Color=\"CornflowerBlue\" Shape=\"Dot\" /><SeriesLabel>series 1</SeriesLab" +
				"el><X>1;2;3;4;5</X><Y>8;12;10;12;15</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Singl" +
				"e;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeri" +
				"esSerializer><DataSeriesSerializer><LineStyle Color=\"DarkGreen\" /><SymbolStyle C" +
				"olor=\"Cornsilk\" Shape=\"Tri\" /><SeriesLabel>series 2</SeriesLabel><X>1;2;3;4;5</X" +
				"><Y>10;16;17;15;23</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;D" +
				"ouble</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer><Dat" +
				"aSeriesSerializer><LineStyle Color=\"DarkKhaki\" /><SymbolStyle Color=\"Crimson\" Sh" +
				"ape=\"Diamond\" /><SeriesLabel>series 3</SeriesLabel><X>1;2;3;4;5</X><Y>16;19;15;2" +
				"2;18</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;Double</DataTyp" +
				"es><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer></DataSeriesCollec" +
				"tion></DataSerializer><Name>Group1</Name><Stacked>True</Stacked><ChartType>Area<" +
				"/ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50" +
				"</Bar><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=" +
				"True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20,Mini" +
				"mumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Polar><Ra" +
				"dar>Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOutline" +
				">True</ShowOutline></ChartGroup><ChartGroup><DataSerializer Hole=\"3.402823466385" +
				"2886E+38\" /><Name>Group2</Name><Stacked>False</Stacked><ChartType>XYPlot</ChartT" +
				"ype><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50</Bar><" +
				"HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=True,Sh" +
				"owOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20,MinimumSize" +
				"=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Polar><Radar>Deg" +
				"rees=True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOutline>True</" +
				"ShowOutline></ChartGroup></ChartGroupsCollection><Header Compass=\"North\"><Text /" +
				"></Header><Footer Compass=\"South\"><Text /></Footer><Legend Compass=\"East\" Visibl" +
				"e=\"False\"><Text /></Legend><ChartArea Depth=\"20\" Rotation=\"45\" Elevation=\"45\" />" +
				"<Axes><Axis Max=\"5\" Min=\"1\" UnitMajor=\"1\" UnitMinor=\"0.5\" AutoMajor=\"True\" AutoM" +
				"inor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"South\"><Text /><Gr" +
				"idMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace" +
				"=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"100\" Min=\"0\" UnitMa" +
				"jor=\"20\" UnitMinor=\"10\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin" +
				"=\"True\" _onTop=\"0\" Compass=\"West\"><Text /><GridMajor AutoSpace=\"True\" Color=\"Lig" +
				"htGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"" +
				"Dash\" /></Axis><Axis Max=\"0\" Min=\"0\" UnitMajor=\"0\" UnitMinor=\"0\" AutoMajor=\"True" +
				"\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"East\"><Text" +
				" /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor Aut" +
				"oSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis></Axes></Chart2DPropBag>" +
				"";
			this.c1Chart6.Size = new System.Drawing.Size(152, 152);
			this.c1Chart6.TabIndex = 0;
			// 
			// c1Chart4
			// 
			this.c1Chart4.DataSource = null;
			this.c1Chart4.Location = new System.Drawing.Point(312, 168);
			this.c1Chart4.Name = "c1Chart4";
			this.c1Chart4.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>Border=None,Control,1;</StyleData></Nam" +
				"edStyle><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\"><StyleData /></Nam" +
				"edStyle><NamedStyle Name=\"Footer\" ParentName=\"Control\"><StyleData>Border=None,Co" +
				"ntrol,1;</StyleData></NamedStyle><NamedStyle Name=\"Area\" ParentName=\"Area.defaul" +
				"t\"><StyleData>GradientStyle=Horizontal;HatchStyle=BackwardDiagonal;</StyleData><" +
				"/NamedStyle><NamedStyle Name=\"Control\" ParentName=\"Control.default\"><StyleData /" +
				"></NamedStyle><NamedStyle Name=\"AxisX\" ParentName=\"Area\"><StyleData>Rotation=Rot" +
				"ate0;Border=None,Control,1;AlignHorz=Center;BackColor=Transparent;Opaque=False;A" +
				"lignVert=Bottom;</StyleData></NamedStyle><NamedStyle Name=\"AxisY\" ParentName=\"Ar" +
				"ea\"><StyleData>Rotation=Rotate270;Border=None,Control,1;AlignHorz=Near;BackColor" +
				"=Transparent;Opaque=False;AlignVert=Center;</StyleData></NamedStyle><NamedStyle " +
				"Name=\"LabelStyleDefault\" ParentName=\"LabelStyleDefault.default\"><StyleData /></N" +
				"amedStyle><NamedStyle Name=\"Legend.default\" ParentName=\"Control\"><StyleData>Bord" +
				"er=None,Black,1;Wrap=False;AlignVert=Top;</StyleData></NamedStyle><NamedStyle Na" +
				"me=\"LabelStyleDefault.default\" ParentName=\"Control\"><StyleData>Border=None,Contr" +
				"ol,1;BackColor=Transparent;</StyleData></NamedStyle><NamedStyle Name=\"Header\" Pa" +
				"rentName=\"Control\"><StyleData>Border=None,Control,1;</StyleData></NamedStyle><Na" +
				"medStyle Name=\"Control.default\" ParentName=\"\"><StyleData>ForeColor=ControlText;B" +
				"order=None,Control,1;BackColor=Control;</StyleData></NamedStyle><NamedStyle Name" +
				"=\"AxisY2\" ParentName=\"Area\"><StyleData>Rotation=Rotate90;Border=None,Transparent" +
				",1;AlignHorz=Far;BackColor=Transparent;AlignVert=Center;</StyleData></NamedStyle" +
				"><NamedStyle Name=\"Area.default\" ParentName=\"Control\"><StyleData>Border=None,Con" +
				"trol,1;AlignVert=Top;</StyleData></NamedStyle></StyleCollection><ChartGroupsColl" +
				"ection><ChartGroup><DataSerializer Hole=\"3.4028234663852886E+38\" DefaultSet=\"Tru" +
				"e\"><DataSeriesCollection><DataSeriesSerializer><LineStyle Color=\"DarkGray\" /><Sy" +
				"mbolStyle Color=\"CornflowerBlue\" Shape=\"Dot\" /><SeriesLabel>series 1</SeriesLabe" +
				"l><X>5</X><Y>8;12;10;12;15</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;" +
				"Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSeriali" +
				"zer><DataSeriesSerializer><LineStyle Color=\"DarkGreen\" /><SymbolStyle Color=\"Cor" +
				"nsilk\" Shape=\"Tri\" /><SeriesLabel>series 2</SeriesLabel><X>5</X><Y>10;16;17;15;2" +
				"3</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;Double</DataTypes>" +
				"<DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer><DataSeriesSerializer" +
				"><LineStyle Color=\"DarkKhaki\" /><SymbolStyle Color=\"Crimson\" Shape=\"Diamond\" /><" +
				"SeriesLabel>series 3</SeriesLabel><X>5</X><Y>16;19;15;22;18</Y><Y1 /><Y2 /><Y3 /" +
				"><DataTypes>Single;Single;Double;Double;Double</DataTypes><DataFields>;;;;</Data" +
				"Fields><Tag /></DataSeriesSerializer></DataSeriesCollection></DataSerializer><Na" +
				"me>Group1</Name><Stacked>False</Stacked><ChartType>Pie</ChartType><Pie>OtherOffs" +
				"et=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50</Bar><HiLoData>FillFalli" +
				"ng=True,FillTransparent=True,FullWidth=False,ShowClose=True,ShowOpen=True</HiLoD" +
				"ata><Bubble>EncodingMethod=Diameter,MaximumSize=20,MinimumSize=5</Bubble><Polar>" +
				"Degrees=True,PiRatioAnnotations=True,Start=0</Polar><Radar>Degrees=True,Filled=F" +
				"alse,Start=0</Radar><Use3D>False</Use3D><Visible>True</Visible><ShowOutline>True" +
				"</ShowOutline></ChartGroup><ChartGroup><DataSerializer Hole=\"3.4028234663852886E" +
				"+38\" /><Name>Group2</Name><Stacked>False</Stacked><ChartType>XYPlot</ChartType><" +
				"Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50</Bar><HiLoD" +
				"ata>FillFalling=True,FillTransparent=True,FullWidth=False,ShowClose=True,ShowOpe" +
				"n=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20,MinimumSize=5</B" +
				"ubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Polar><Radar>Degrees=" +
				"True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOutline>True</ShowO" +
				"utline></ChartGroup></ChartGroupsCollection><Header Compass=\"North\"><Text /></He" +
				"ader><Footer Compass=\"South\"><Text /></Footer><Legend Compass=\"East\" Visible=\"Fa" +
				"lse\"><Text /></Legend><ChartArea Depth=\"20\" Rotation=\"45\" Elevation=\"45\" /><Axes" +
				"><Axis Max=\"5\" Min=\"1\" UnitMajor=\"1\" UnitMinor=\"0.5\" AutoMajor=\"True\" AutoMinor=" +
				"\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"South\"><Text /><GridMaj" +
				"or AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"Tru" +
				"e\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"25\" Min=\"6\" UnitMajor=\"5" +
				"\" UnitMinor=\"2.5\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True" +
				"\" _onTop=\"0\" Compass=\"West\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray" +
				"\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" " +
				"/></Axis><Axis Max=\"0\" Min=\"0\" UnitMajor=\"0\" UnitMinor=\"0\" AutoMajor=\"True\" Auto" +
				"Minor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"East\"><Text /><Gr" +
				"idMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace" +
				"=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis></Axes></Chart2DPropBag>";
			this.c1Chart4.Size = new System.Drawing.Size(152, 152);
			this.c1Chart4.TabIndex = 0;
			// 
			// c1Chart7
			// 
			this.c1Chart7.DataSource = null;
			this.c1Chart7.Location = new System.Drawing.Point(464, 168);
			this.c1Chart7.Name = "c1Chart7";
			this.c1Chart7.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>Border=None,Control,1;</StyleData></Nam" +
				"edStyle><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\"><StyleData /></Nam" +
				"edStyle><NamedStyle Name=\"Footer\" ParentName=\"Control\"><StyleData>Border=None,Co" +
				"ntrol,1;</StyleData></NamedStyle><NamedStyle Name=\"Area\" ParentName=\"Area.defaul" +
				"t\"><StyleData>GradientStyle=Horizontal;HatchStyle=BackwardDiagonal;</StyleData><" +
				"/NamedStyle><NamedStyle Name=\"Control\" ParentName=\"Control.default\"><StyleData /" +
				"></NamedStyle><NamedStyle Name=\"AxisX\" ParentName=\"Area\"><StyleData>Rotation=Rot" +
				"ate0;Border=None,Control,1;AlignHorz=Center;BackColor=Transparent;Opaque=False;A" +
				"lignVert=Bottom;</StyleData></NamedStyle><NamedStyle Name=\"AxisY\" ParentName=\"Ar" +
				"ea\"><StyleData>Rotation=Rotate270;Border=None,Control,1;AlignHorz=Near;BackColor" +
				"=Transparent;Opaque=False;AlignVert=Center;</StyleData></NamedStyle><NamedStyle " +
				"Name=\"LabelStyleDefault\" ParentName=\"LabelStyleDefault.default\"><StyleData /></N" +
				"amedStyle><NamedStyle Name=\"Legend.default\" ParentName=\"Control\"><StyleData>Bord" +
				"er=None,Black,1;Wrap=False;AlignVert=Top;</StyleData></NamedStyle><NamedStyle Na" +
				"me=\"LabelStyleDefault.default\" ParentName=\"Control\"><StyleData>Border=None,Contr" +
				"ol,1;BackColor=Transparent;</StyleData></NamedStyle><NamedStyle Name=\"Header\" Pa" +
				"rentName=\"Control\"><StyleData>Border=None,Control,1;</StyleData></NamedStyle><Na" +
				"medStyle Name=\"Control.default\" ParentName=\"\"><StyleData>ForeColor=ControlText;B" +
				"order=None,Control,1;BackColor=Control;</StyleData></NamedStyle><NamedStyle Name" +
				"=\"AxisY2\" ParentName=\"Area\"><StyleData>Rotation=Rotate90;Border=None,Transparent" +
				",1;AlignHorz=Far;BackColor=Transparent;AlignVert=Center;</StyleData></NamedStyle" +
				"><NamedStyle Name=\"Area.default\" ParentName=\"Control\"><StyleData>Border=None,Con" +
				"trol,1;AlignVert=Top;</StyleData></NamedStyle></StyleCollection><ChartGroupsColl" +
				"ection><ChartGroup><DataSerializer Hole=\"3.4028234663852886E+38\" DefaultSet=\"Tru" +
				"e\"><DataSeriesCollection><DataSeriesSerializer Offset=\"20\"><LineStyle Color=\"Dar" +
				"kGray\" /><SymbolStyle Color=\"CornflowerBlue\" Shape=\"Dot\" /><SeriesLabel>series 1" +
				"</SeriesLabel><X>5</X><Y>8;12;10;12;15</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Si" +
				"ngle;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataS" +
				"eriesSerializer><DataSeriesSerializer Offset=\"20\"><LineStyle Color=\"DarkGreen\" /" +
				"><SymbolStyle Color=\"Cornsilk\" Shape=\"Tri\" /><SeriesLabel>series 2</SeriesLabel>" +
				"<X>5</X><Y>10;16;17;15;23</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;D" +
				"ouble;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializ" +
				"er><DataSeriesSerializer Offset=\"20\"><LineStyle Color=\"DarkKhaki\" /><SymbolStyle" +
				" Color=\"Crimson\" Shape=\"Diamond\" /><SeriesLabel>series 3</SeriesLabel><X>5</X><Y" +
				">16;19;15;22;18</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Single;Double;Double;Doub" +
				"le</DataTypes><DataFields>;;;;</DataFields><Tag /></DataSeriesSerializer></DataS" +
				"eriesCollection></DataSerializer><Name>Group1</Name><Stacked>False</Stacked><Cha" +
				"rtType>Pie</ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,Clus" +
				"terWidth=50</Bar><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False" +
				",ShowClose=True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumS" +
				"ize=20,MinimumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0" +
				"</Polar><Radar>Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visible><" +
				"ShowOutline>False</ShowOutline></ChartGroup><ChartGroup><DataSerializer Hole=\"3." +
				"4028234663852886E+38\" /><Name>Group2</Name><Stacked>False</Stacked><ChartType>XY" +
				"Plot</ChartType><Pie>OtherOffset=0,Start=0</Pie><Bar>ClusterOverlap=0,ClusterWid" +
				"th=50</Bar><HiLoData>FillFalling=True,FillTransparent=True,FullWidth=False,ShowC" +
				"lose=True,ShowOpen=True</HiLoData><Bubble>EncodingMethod=Diameter,MaximumSize=20" +
				",MinimumSize=5</Bubble><Polar>Degrees=True,PiRatioAnnotations=True,Start=0</Pola" +
				"r><Radar>Degrees=True,Filled=False,Start=0</Radar><Visible>True</Visible><ShowOu" +
				"tline>True</ShowOutline></ChartGroup></ChartGroupsCollection><Header Compass=\"No" +
				"rth\"><Text /></Header><Footer Compass=\"South\"><Text /></Footer><Legend Compass=\"" +
				"East\" Visible=\"False\"><Text /></Legend><ChartArea Depth=\"20\" Rotation=\"45\" Eleva" +
				"tion=\"45\" /><Axes><Axis Max=\"5\" Min=\"1\" UnitMajor=\"1\" UnitMinor=\"0.5\" AutoMajor=" +
				"\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"South\"" +
				"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMin" +
				"or AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Max=\"25\" Min" +
				"=\"6\" UnitMajor=\"5\" UnitMinor=\"2.5\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"Tr" +
				"ue\" AutoMin=\"True\" _onTop=\"0\" Compass=\"West\"><Text /><GridMajor AutoSpace=\"True\"" +
				" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightGray" +
				"\" Pattern=\"Dash\" /></Axis><Axis Max=\"0\" Min=\"0\" UnitMajor=\"0\" UnitMinor=\"0\" Auto" +
				"Major=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"" +
				"East\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><Gr" +
				"idMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis></Axes></Char" +
				"t2DPropBag>";
			this.c1Chart7.Size = new System.Drawing.Size(152, 152);
			this.c1Chart7.TabIndex = 0;
			// 
			// c1Chart8
			// 
			this.c1Chart8.DataSource = null;
			this.c1Chart8.Location = new System.Drawing.Point(464, 8);
			this.c1Chart8.Name = "c1Chart8";
			this.c1Chart8.PropBag = "<?xml version=\"1.0\"?><Chart2DPropBag Version=\"\"><StyleCollection><NamedStyle Name" +
				"=\"PlotArea\" ParentName=\"Area\"><StyleData>GradientStyle=Vertical;Border=Solid,Con" +
				"trolText,1;BackColor2=Blue;BackColor=192, 192, 255;Opaque=True;</StyleData></Nam" +
				"edStyle><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\"><StyleData>AlignHo" +
				"rz=General;AlignVert=Top;</StyleData></NamedStyle><NamedStyle Name=\"Footer\" Pare" +
				"ntName=\"Control\"><StyleData>Border=None,Control,1;</StyleData></NamedStyle><Name" +
				"dStyle Name=\"Area\" ParentName=\"Area.default\"><StyleData /></NamedStyle><NamedSty" +
				"le Name=\"Control\" ParentName=\"Control.default\"><StyleData /></NamedStyle><NamedS" +
				"tyle Name=\"AxisX\" ParentName=\"Area\"><StyleData>Rotation=Rotate0;Border=None,Cont" +
				"rol,1;AlignHorz=Center;BackColor=Transparent;Opaque=False;AlignVert=Bottom;</Sty" +
				"leData></NamedStyle><NamedStyle Name=\"AxisY\" ParentName=\"Area\"><StyleData>Rotati" +
				"on=Rotate270;Border=None,Control,1;AlignHorz=Near;BackColor=Transparent;Opaque=F" +
				"alse;AlignVert=Center;</StyleData></NamedStyle><NamedStyle Name=\"LabelStyleDefau" +
				"lt\" ParentName=\"LabelStyleDefault.default\"><StyleData /></NamedStyle><NamedStyle" +
				" Name=\"Legend.default\" ParentName=\"Control\"><StyleData>Border=None,Black,1;Wrap=" +
				"False;AlignVert=Top;</StyleData></NamedStyle><NamedStyle Name=\"LabelStyleDefault" +
				".default\" ParentName=\"Control\"><StyleData>Border=None,Control,1;BackColor=Transp" +
				"arent;</StyleData></NamedStyle><NamedStyle Name=\"Header\" ParentName=\"Control\"><S" +
				"tyleData>Border=None,Control,1;</StyleData></NamedStyle><NamedStyle Name=\"Contro" +
				"l.default\" ParentName=\"\"><StyleData>ForeColor=ControlText;Border=None,Control,1;" +
				"BackColor=Control;</StyleData></NamedStyle><NamedStyle Name=\"AxisY2\" ParentName=" +
				"\"Area\"><StyleData>Rotation=Rotate90;Border=None,Transparent,1;AlignHorz=Far;Back" +
				"Color=Transparent;AlignVert=Center;</StyleData></NamedStyle><NamedStyle Name=\"Ar" +
				"ea.default\" ParentName=\"Control\"><StyleData>Border=None,Control,1;AlignVert=Top;" +
				"</StyleData></NamedStyle></StyleCollection><ChartGroupsCollection><ChartGroup><D" +
				"ataSerializer Hole=\"3.4028234663852886E+38\" DefaultSet=\"True\"><DataSeriesCollect" +
				"ion><DataSeriesSerializer FitType=\"Beziers\"><LineStyle Thickness=\"3\" Color=\"Dark" +
				"Goldenrod\" /><SymbolStyle Color=\"Coral\" Shape=\"Dot\" /><SeriesLabel>bez1</SeriesL" +
				"abel><X>1;2;3;4;5</X><Y>20;22;19;24;25</Y><Y1 /><Y2 /><Y3 /><DataTypes>Single;Si" +
				"ngle;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><Tag /></DataS" +
				"eriesSerializer><DataSeriesSerializer FitType=\"Spline\"><LineStyle Thickness=\"3\" " +
				"Color=\"DarkGreen\" /><SymbolStyle Color=\"Cornsilk\" Shape=\"Dot\" /><SeriesLabel>spl" +
				"ine1</SeriesLabel><X>1;2;3;4;5</X><Y>10;16;17;15;23</Y><Y1 /><Y2 /><Y3 /><DataTy" +
				"pes>Single;Single;Double;Double;Double</DataTypes><DataFields>;;;;</DataFields><" +
				"Tag /></DataSeriesSerializer></DataSeriesCollection></DataSerializer><Name>Group" +
				"1</Name><Stacked>False</Stacked><ChartType>XYPlot</ChartType><Pie>OtherOffset=0," +
				"Start=0</Pie><Bar>ClusterOverlap=0,ClusterWidth=50</Bar><HiLoData>FillFalling=Tr" +
				"ue,FillTransparent=True,FullWidth=False,ShowClose=True,ShowOpen=True</HiLoData><" +
				"Bubble>EncodingMethod=Diameter,MaximumSize=20,MinimumSize=5</Bubble><Polar>Degre" +
				"es=True,PiRatioAnnotations=True,Start=0</Polar><Radar>Degrees=True,Filled=False," +
				"Start=0</Radar><Visible>True</Visible><ShowOutline>True</ShowOutline></ChartGrou" +
				"p><ChartGroup><DataSerializer Hole=\"3.4028234663852886E+38\" /><Name>Group2</Name" +
				"><Stacked>False</Stacked><ChartType>XYPlot</ChartType><Pie>OtherOffset=0,Start=0" +
				"</Pie><Bar>ClusterOverlap=0,ClusterWidth=50</Bar><HiLoData>FillFalling=True,Fill" +
				"Transparent=True,FullWidth=False,ShowClose=True,ShowOpen=True</HiLoData><Bubble>" +
				"EncodingMethod=Diameter,MaximumSize=20,MinimumSize=5</Bubble><Polar>Degrees=True" +
				",PiRatioAnnotations=True,Start=0</Polar><Radar>Degrees=True,Filled=False,Start=0" +
				"</Radar><Visible>True</Visible><ShowOutline>True</ShowOutline></ChartGroup></Cha" +
				"rtGroupsCollection><Header Compass=\"North\"><Text /></Header><Footer Compass=\"Sou" +
				"th\"><Text /></Footer><Legend Compass=\"North\" LocationDefault=\"-1, 0\" Visible=\"Tr" +
				"ue\" Orientation=\"Vertical\"><Text /></Legend><ChartArea /><Axes><Axis Max=\"5\" Min" +
				"=\"1\" UnitMajor=\"1\" UnitMinor=\"0.5\" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"Tr" +
				"ue\" AutoMin=\"True\" _onTop=\"0\" Compass=\"South\"><Text /><GridMajor AutoSpace=\"True" +
				"\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"LightGra" +
				"y\" Pattern=\"Dash\" /></Axis><Axis Max=\"25\" Min=\"10\" UnitMajor=\"5\" UnitMinor=\"2.5\"" +
				" AutoMajor=\"True\" AutoMinor=\"True\" AutoMax=\"True\" AutoMin=\"True\" _onTop=\"0\" Comp" +
				"ass=\"West\"><Text /><GridMajor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" " +
				"/><GridMinor AutoSpace=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /></Axis><Axis Ma" +
				"x=\"0\" Min=\"0\" UnitMajor=\"0\" UnitMinor=\"0\" AutoMajor=\"True\" AutoMinor=\"True\" Auto" +
				"Max=\"True\" AutoMin=\"True\" _onTop=\"0\" Compass=\"East\"><Text /><GridMajor AutoSpace" +
				"=\"True\" Color=\"LightGray\" Pattern=\"Dash\" /><GridMinor AutoSpace=\"True\" Color=\"Li" +
				"ghtGray\" Pattern=\"Dash\" /></Axis></Axes></Chart2DPropBag>";
			this.c1Chart8.Size = new System.Drawing.Size(152, 152);
			this.c1Chart8.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.c1Chart3D1,
																				   this.c1Chart3D2,
																				   this.c1Chart3D3,
																				   this.c1Chart3D4,
																				   this.c1Chart3D6,
																				   this.c1Chart3D5,
																				   this.c1Chart3D7,
																				   this.c1Chart3D8});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(618, 326);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "3D Charts";
			// 
			// c1Chart3D1
			// 
			this.c1Chart3D1.Location = new System.Drawing.Point(8, 8);
			this.c1Chart3D1.Name = "c1Chart3D1";
			this.c1Chart3D1.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View /><ChartGroupsCollection><C" +
				"hart3DGroup><ChartData><Set type=\"Chart3DDataSetGrid\" RowCount=\"11\" ColumnCount=" +
				"\"11\" RowDelta=\"1\" ColumnDelta=\"1\" RowOrigin=\"0\" ColumnOrigin=\"0\" Hole=\"3.4028234" +
				"663852886E+38\"><Data>4.499999888241291 3.599999874830246 2.8999998643994331 2.39" +
				"99998569488525 2.0999998524785042 1.9999998509883881 2.0999998524785042 2.399999" +
				"8569488525 2.8999998643994331 3.599999874830246 4.499999888241291 8.099999941885" +
				"4713 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.6999999061226845" +
				" 5.5999999046325684 5.6999999061226845 5.9999999105930328 6.4999999180436134 7.1" +
				"999999284744263 8.0999999418854713 10.899999983608723 9.9999999701976776 9.29999" +
				"99597668648 8.7999999523162842 8.4999999478459358 8.39999994635582 8.49999994784" +
				"59358 8.7999999523162842 9.2999999597668648 9.9999999701976776 10.89999998360872" +
				"3 12.900000013411045 12 11.299999989569187 10.799999982118607 10.499999977648258" +
				" 10.399999976158142 10.499999977648258 10.799999982118607 11.299999989569187 12 " +
				"12.900000013411045 14.100000031292439 13.200000017881393 12.500000007450581 12 1" +
				"1.699999995529652 11.599999994039536 11.699999995529652 12 12.500000007450581 13" +
				".200000017881393 14.100000031292439 14.500000037252903 13.600000023841858 12.900" +
				"000013411045 12.400000005960465 12.100000001490116 12 12.100000001490116 12.4000" +
				"00005960465 12.900000013411045 13.600000023841858 14.500000037252903 14.10000003" +
				"1292439 13.200000017881393 12.500000007450581 12 11.699999995529652 11.599999994" +
				"039536 11.699999995529652 12 12.500000007450581 13.200000017881393 14.1000000312" +
				"92439 12.900000013411045 12 11.299999989569187 10.799999982118607 10.49999997764" +
				"8258 10.399999976158142 10.499999977648258 10.799999982118607 11.299999989569187" +
				" 12 12.900000013411045 10.899999983608723 9.9999999701976776 9.2999999597668648 " +
				"8.7999999523162842 8.4999999478459358 8.39999994635582 8.4999999478459358 8.7999" +
				"999523162842 9.2999999597668648 9.9999999701976776 10.899999983608723 8.09999994" +
				"18854713 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.699999906122" +
				"6845 5.5999999046325684 5.6999999061226845 5.9999999105930328 6.4999999180436134" +
				" 7.1999999284744263 8.0999999418854713 4.499999888241291 3.599999874830246 2.899" +
				"9998643994331 2.3999998569488525 2.0999998524785042 1.9999998509883881 2.0999998" +
				"524785042 2.3999998569488525 2.8999998643994331 3.599999874830246 4.499999888241" +
				"291</Data></Set></ChartData></Chart3DGroup></ChartGroupsCollection><StyleCollect" +
				"ion><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\" /><NamedStyle Name=\"Fo" +
				"oter\" ParentName=\"Control\" /><NamedStyle Name=\"Area\" ParentName=\"Area.default\" /" +
				"><NamedStyle Name=\"Control\" ParentName=\"Control.default\" /><NamedStyle Name=\"Lab" +
				"elStyleDefault\" ParentName=\"Control\" StyleData=\"BackColor=Transparent;\" /><Named" +
				"Style Name=\"Legend.default\" ParentName=\"Control\" StyleData=\"Wrap=False;AlignVert" +
				"=Top;\" /><NamedStyle Name=\"Header\" ParentName=\"Control\" /><NamedStyle Name=\"Cont" +
				"rol.default\" ParentName=\"\" StyleData=\"ForeColor=ControlText;BackColor=Control;\" " +
				"/><NamedStyle Name=\"Area.default\" ParentName=\"Control\" StyleData=\"AlignVert=Top;" +
				"\" /></StyleCollection><LegendData Compass=\"East\" /><FooterData Visible=\"True\" Co" +
				"mpass=\"South\" /><HeaderData Visible=\"True\" Compass=\"North\" /></Chart3DPropBag>";
			this.c1Chart3D1.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D1.TabIndex = 0;
			// 
			// c1Chart3D2
			// 
			this.c1Chart3D2.Location = new System.Drawing.Point(160, 8);
			this.c1Chart3D2.Name = "c1Chart3D2";
			this.c1Chart3D2.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View RotationX=\"59\" RotationZ=\"2" +
				"18\" /><ChartGroupsCollection><Chart3DGroup ChartType=\"Bar\"><Contour IsContoured=" +
				"\"True\" /><ChartData><Set type=\"Chart3DDataSetGrid\" RowCount=\"11\" ColumnCount=\"11" +
				"\" RowDelta=\"1\" ColumnDelta=\"1\" RowOrigin=\"0\" ColumnOrigin=\"0\" Hole=\"3.4028234663" +
				"852886E+38\"><Data>4.499999888241291 3.599999874830246 2.8999998643994331 2.39999" +
				"98569488525 2.0999998524785042 1.9999998509883881 2.0999998524785042 2.399999856" +
				"9488525 2.8999998643994331 3.599999874830246 4.499999888241291 8.099999941885471" +
				"3 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.6999999061226845 5." +
				"5999999046325684 5.6999999061226845 5.9999999105930328 6.4999999180436134 7.1999" +
				"999284744263 8.0999999418854713 10.899999983608723 9.9999999701976776 9.29999995" +
				"97668648 8.7999999523162842 8.4999999478459358 8.39999994635582 8.49999994784593" +
				"58 8.7999999523162842 9.2999999597668648 9.9999999701976776 10.899999983608723 1" +
				"2.900000013411045 12 11.299999989569187 10.799999982118607 10.499999977648258 10" +
				".399999976158142 10.499999977648258 10.799999982118607 11.299999989569187 12 12." +
				"900000013411045 14.100000031292439 13.200000017881393 12.500000007450581 12 11.6" +
				"99999995529652 11.599999994039536 11.699999995529652 12 12.500000007450581 13.20" +
				"0000017881393 14.100000031292439 14.500000037252903 13.600000023841858 12.900000" +
				"013411045 12.400000005960465 12.100000001490116 12 12.100000001490116 12.4000000" +
				"05960465 12.900000013411045 13.600000023841858 14.500000037252903 14.10000003129" +
				"2439 13.200000017881393 12.500000007450581 12 11.699999995529652 11.599999994039" +
				"536 11.699999995529652 12 12.500000007450581 13.200000017881393 14.1000000312924" +
				"39 12.900000013411045 12 11.299999989569187 10.799999982118607 10.49999997764825" +
				"8 10.399999976158142 10.499999977648258 10.799999982118607 11.299999989569187 12" +
				" 12.900000013411045 10.899999983608723 9.9999999701976776 9.2999999597668648 8.7" +
				"999999523162842 8.4999999478459358 8.39999994635582 8.4999999478459358 8.7999999" +
				"523162842 9.2999999597668648 9.9999999701976776 10.899999983608723 8.09999994188" +
				"54713 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.699999906122684" +
				"5 5.5999999046325684 5.6999999061226845 5.9999999105930328 6.4999999180436134 7." +
				"1999999284744263 8.0999999418854713 4.499999888241291 3.599999874830246 2.899999" +
				"8643994331 2.3999998569488525 2.0999998524785042 1.9999998509883881 2.0999998524" +
				"785042 2.3999998569488525 2.8999998643994331 3.599999874830246 4.499999888241291" +
				"</Data></Set></ChartData></Chart3DGroup></ChartGroupsCollection><ChartStyles><Ch" +
				"art3DStyle><SymbolStyle Size=\"5\" Color=\"Coral\" Shape=\"Box\" OutlineColor=\"\" /><Li" +
				"neStyle Thickness=\"0\" Color=\"Black\" Pattern=\"Solid\" /></Chart3DStyle></ChartStyl" +
				"es><StyleCollection><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\" /><Nam" +
				"edStyle Name=\"Footer\" ParentName=\"Control\" /><NamedStyle Name=\"Area\" ParentName=" +
				"\"Area.default\" /><NamedStyle Name=\"Control\" ParentName=\"Control.default\" /><Name" +
				"dStyle Name=\"LabelStyleDefault\" ParentName=\"Control\" StyleData=\"BackColor=Transp" +
				"arent;\" /><NamedStyle Name=\"Legend.default\" ParentName=\"Control\" StyleData=\"Wrap" +
				"=False;AlignVert=Top;\" /><NamedStyle Name=\"Header\" ParentName=\"Control\" /><Named" +
				"Style Name=\"Control.default\" ParentName=\"\" StyleData=\"ForeColor=ControlText;Back" +
				"Color=Control;\" /><NamedStyle Name=\"Area.default\" ParentName=\"Control\" StyleData" +
				"=\"AlignVert=Top;\" /></StyleCollection><LegendData Compass=\"East\" /><FooterData V" +
				"isible=\"True\" Compass=\"South\" /><HeaderData Visible=\"True\" Compass=\"North\" /></C" +
				"hart3DPropBag>";
			this.c1Chart3D2.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D2.TabIndex = 0;
			// 
			// c1Chart3D3
			// 
			this.c1Chart3D3.Location = new System.Drawing.Point(312, 8);
			this.c1Chart3D3.Name = "c1Chart3D3";
			this.c1Chart3D3.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View RotationX=\"54\" RotationZ=\"1" +
				"30\" /><ChartGroupsCollection><Chart3DGroup ChartType=\"Scatter\"><Contour IsZoned=" +
				"\"True\" /><ChartData><Set type=\"Chart3DDataSetGrid\" RowCount=\"11\" ColumnCount=\"11" +
				"\" RowDelta=\"1\" ColumnDelta=\"1\" RowOrigin=\"0\" ColumnOrigin=\"0\" Hole=\"3.4028234663" +
				"852886E+38\"><Data>4.499999888241291 3.599999874830246 2.8999998643994331 2.39999" +
				"98569488525 2.0999998524785042 1.9999998509883881 2.0999998524785042 2.399999856" +
				"9488525 2.8999998643994331 3.599999874830246 4.499999888241291 8.099999941885471" +
				"3 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.6999999061226845 5." +
				"5999999046325684 5.6999999061226845 5.9999999105930328 6.4999999180436134 7.1999" +
				"999284744263 8.0999999418854713 10.899999983608723 9.9999999701976776 9.29999995" +
				"97668648 8.7999999523162842 8.4999999478459358 8.39999994635582 8.49999994784593" +
				"58 8.7999999523162842 9.2999999597668648 9.9999999701976776 10.899999983608723 1" +
				"2.900000013411045 12 11.299999989569187 10.799999982118607 10.499999977648258 10" +
				".399999976158142 10.499999977648258 10.799999982118607 11.299999989569187 12 12." +
				"900000013411045 14.100000031292439 13.200000017881393 12.500000007450581 12 11.6" +
				"99999995529652 11.599999994039536 11.699999995529652 12 12.500000007450581 13.20" +
				"0000017881393 14.100000031292439 14.500000037252903 13.600000023841858 12.900000" +
				"013411045 12.400000005960465 12.100000001490116 12 12.100000001490116 12.4000000" +
				"05960465 12.900000013411045 13.600000023841858 14.500000037252903 14.10000003129" +
				"2439 13.200000017881393 12.500000007450581 12 11.699999995529652 11.599999994039" +
				"536 11.699999995529652 12 12.500000007450581 13.200000017881393 14.1000000312924" +
				"39 12.900000013411045 12 11.299999989569187 10.799999982118607 10.49999997764825" +
				"8 10.399999976158142 10.499999977648258 10.799999982118607 11.299999989569187 12" +
				" 12.900000013411045 10.899999983608723 9.9999999701976776 9.2999999597668648 8.7" +
				"999999523162842 8.4999999478459358 8.39999994635582 8.4999999478459358 8.7999999" +
				"523162842 9.2999999597668648 9.9999999701976776 10.899999983608723 8.09999994188" +
				"54713 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.699999906122684" +
				"5 5.5999999046325684 5.6999999061226845 5.9999999105930328 6.4999999180436134 7." +
				"1999999284744263 8.0999999418854713 4.499999888241291 3.599999874830246 2.899999" +
				"8643994331 2.3999998569488525 2.0999998524785042 1.9999998509883881 2.0999998524" +
				"785042 2.3999998569488525 2.8999998643994331 3.599999874830246 4.499999888241291" +
				"</Data></Set></ChartData></Chart3DGroup></ChartGroupsCollection><ChartStyles><Ch" +
				"art3DStyle><SymbolStyle Size=\"5\" Color=\"Coral\" Shape=\"Box\" OutlineColor=\"\" /><Li" +
				"neStyle Thickness=\"0\" Color=\"Black\" Pattern=\"Solid\" /></Chart3DStyle></ChartStyl" +
				"es><StyleCollection><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\" /><Nam" +
				"edStyle Name=\"Footer\" ParentName=\"Control\" /><NamedStyle Name=\"Area\" ParentName=" +
				"\"Area.default\" /><NamedStyle Name=\"Control\" ParentName=\"Control.default\" /><Name" +
				"dStyle Name=\"LabelStyleDefault\" ParentName=\"Control\" StyleData=\"BackColor=Transp" +
				"arent;\" /><NamedStyle Name=\"Legend.default\" ParentName=\"Control\" StyleData=\"Wrap" +
				"=False;AlignVert=Top;\" /><NamedStyle Name=\"Header\" ParentName=\"Control\" /><Named" +
				"Style Name=\"Control.default\" ParentName=\"\" StyleData=\"ForeColor=ControlText;Back" +
				"Color=Control;\" /><NamedStyle Name=\"Area.default\" ParentName=\"Control\" StyleData" +
				"=\"AlignVert=Top;\" /></StyleCollection><LegendData Compass=\"East\" /><FooterData V" +
				"isible=\"True\" Compass=\"South\" /><HeaderData Visible=\"True\" Compass=\"North\" /></C" +
				"hart3DPropBag>";
			this.c1Chart3D3.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D3.TabIndex = 0;
			// 
			// c1Chart3D4
			// 
			this.c1Chart3D4.Location = new System.Drawing.Point(8, 168);
			this.c1Chart3D4.Name = "c1Chart3D4";
			this.c1Chart3D4.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View Perspective=\"10000\" Rotatio" +
				"nX=\"69\" RotationZ=\"224\" /><ChartGroupsCollection><Chart3DGroup><Elevation IsMesh" +
				"ed=\"False\" /><Contour IsContoured=\"True\" IsZoned=\"True\" /><ChartData><Set type=\"" +
				"Chart3DDataSetGrid\" RowCount=\"11\" ColumnCount=\"11\" RowDelta=\"1\" ColumnDelta=\"1\" " +
				"RowOrigin=\"0\" ColumnOrigin=\"0\" Hole=\"3.4028234663852886E+38\"><Data>4.49999988824" +
				"1291 3.599999874830246 2.8999998643994331 2.3999998569488525 2.0999998524785042 " +
				"1.9999998509883881 2.0999998524785042 2.3999998569488525 2.8999998643994331 3.59" +
				"9999874830246 4.499999888241291 8.0999999418854713 7.1999999284744263 6.49999991" +
				"80436134 5.9999999105930328 5.6999999061226845 5.5999999046325684 5.699999906122" +
				"6845 5.9999999105930328 6.4999999180436134 7.1999999284744263 8.0999999418854713" +
				" 10.899999983608723 9.9999999701976776 9.2999999597668648 8.7999999523162842 8.4" +
				"999999478459358 8.39999994635582 8.4999999478459358 8.7999999523162842 9.2999999" +
				"597668648 9.9999999701976776 10.899999983608723 12.900000013411045 12 11.2999999" +
				"89569187 10.799999982118607 10.499999977648258 10.399999976158142 10.49999997764" +
				"8258 10.799999982118607 11.299999989569187 12 12.900000013411045 14.100000031292" +
				"439 13.200000017881393 12.500000007450581 12 11.699999995529652 11.5999999940395" +
				"36 11.699999995529652 12 12.500000007450581 13.200000017881393 14.10000003129243" +
				"9 14.500000037252903 13.600000023841858 12.900000013411045 12.400000005960465 12" +
				".100000001490116 12 12.100000001490116 12.400000005960465 12.900000013411045 13." +
				"600000023841858 14.500000037252903 14.100000031292439 13.200000017881393 12.5000" +
				"00007450581 12 11.699999995529652 11.599999994039536 11.699999995529652 12 12.50" +
				"0000007450581 13.200000017881393 14.100000031292439 12.900000013411045 12 11.299" +
				"999989569187 10.799999982118607 10.499999977648258 10.399999976158142 10.4999999" +
				"77648258 10.799999982118607 11.299999989569187 12 12.900000013411045 10.89999998" +
				"3608723 9.9999999701976776 9.2999999597668648 8.7999999523162842 8.4999999478459" +
				"358 8.39999994635582 8.4999999478459358 8.7999999523162842 9.2999999597668648 9." +
				"9999999701976776 10.899999983608723 8.0999999418854713 7.1999999284744263 6.4999" +
				"999180436134 5.9999999105930328 5.6999999061226845 5.5999999046325684 5.69999990" +
				"61226845 5.9999999105930328 6.4999999180436134 7.1999999284744263 8.099999941885" +
				"4713 4.499999888241291 3.599999874830246 2.8999998643994331 2.3999998569488525 2" +
				".0999998524785042 1.9999998509883881 2.0999998524785042 2.3999998569488525 2.899" +
				"9998643994331 3.599999874830246 4.499999888241291</Data></Set></ChartData></Char" +
				"t3DGroup></ChartGroupsCollection><StyleCollection><NamedStyle Name=\"Legend\" Pare" +
				"ntName=\"Legend.default\" /><NamedStyle Name=\"Footer\" ParentName=\"Control\" /><Name" +
				"dStyle Name=\"Area\" ParentName=\"Area.default\" /><NamedStyle Name=\"Control\" Parent" +
				"Name=\"Control.default\" /><NamedStyle Name=\"LabelStyleDefault\" ParentName=\"Contro" +
				"l\" StyleData=\"BackColor=Transparent;\" /><NamedStyle Name=\"Legend.default\" Parent" +
				"Name=\"Control\" StyleData=\"Wrap=False;AlignVert=Top;\" /><NamedStyle Name=\"Header\"" +
				" ParentName=\"Control\" /><NamedStyle Name=\"Control.default\" ParentName=\"\" StyleDa" +
				"ta=\"ForeColor=ControlText;BackColor=Control;\" /><NamedStyle Name=\"Area.default\" " +
				"ParentName=\"Control\" StyleData=\"AlignVert=Top;\" /></StyleCollection><LegendData " +
				"Compass=\"East\" /><FooterData Visible=\"True\" Compass=\"South\" /><HeaderData Visibl" +
				"e=\"True\" Compass=\"North\" /></Chart3DPropBag>";
			this.c1Chart3D4.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D4.TabIndex = 0;
			// 
			// c1Chart3D6
			// 
			this.c1Chart3D6.Location = new System.Drawing.Point(160, 168);
			this.c1Chart3D6.Name = "c1Chart3D6";
			this.c1Chart3D6.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View /><ChartGroupsCollection><C" +
				"hart3DGroup ChartType=\"Bar\"><Contour IsZoned=\"True\" /><ChartData><Set type=\"Char" +
				"t3DDataSetGrid\" RowCount=\"11\" ColumnCount=\"11\" RowDelta=\"1\" ColumnDelta=\"1\" RowO" +
				"rigin=\"0\" ColumnOrigin=\"0\" Hole=\"3.4028234663852886E+38\"><Data>4.499999888241291" +
				" 3.599999874830246 2.8999998643994331 2.3999998569488525 2.0999998524785042 1.99" +
				"99998509883881 2.0999998524785042 2.3999998569488525 2.8999998643994331 3.599999" +
				"874830246 4.499999888241291 8.0999999418854713 7.1999999284744263 6.499999918043" +
				"6134 5.9999999105930328 5.6999999061226845 5.5999999046325684 5.6999999061226845" +
				" 5.9999999105930328 6.4999999180436134 7.1999999284744263 8.0999999418854713 10." +
				"899999983608723 9.9999999701976776 9.2999999597668648 8.7999999523162842 8.49999" +
				"99478459358 8.39999994635582 8.4999999478459358 8.7999999523162842 9.29999995976" +
				"68648 9.9999999701976776 10.899999983608723 12.900000013411045 12 11.29999998956" +
				"9187 10.799999982118607 10.499999977648258 10.399999976158142 10.499999977648258" +
				" 10.799999982118607 11.299999989569187 12 12.900000013411045 14.100000031292439 " +
				"13.200000017881393 12.500000007450581 12 11.699999995529652 11.599999994039536 1" +
				"1.699999995529652 12 12.500000007450581 13.200000017881393 14.100000031292439 14" +
				".500000037252903 13.600000023841858 12.900000013411045 12.400000005960465 12.100" +
				"000001490116 12 12.100000001490116 12.400000005960465 12.900000013411045 13.6000" +
				"00023841858 14.500000037252903 14.100000031292439 13.200000017881393 12.50000000" +
				"7450581 12 11.699999995529652 11.599999994039536 11.699999995529652 12 12.500000" +
				"007450581 13.200000017881393 14.100000031292439 12.900000013411045 12 11.2999999" +
				"89569187 10.799999982118607 10.499999977648258 10.399999976158142 10.49999997764" +
				"8258 10.799999982118607 11.299999989569187 12 12.900000013411045 10.899999983608" +
				"723 9.9999999701976776 9.2999999597668648 8.7999999523162842 8.4999999478459358 " +
				"8.39999994635582 8.4999999478459358 8.7999999523162842 9.2999999597668648 9.9999" +
				"999701976776 10.899999983608723 8.0999999418854713 7.1999999284744263 6.49999991" +
				"80436134 5.9999999105930328 5.6999999061226845 5.5999999046325684 5.699999906122" +
				"6845 5.9999999105930328 6.4999999180436134 7.1999999284744263 8.0999999418854713" +
				" 4.499999888241291 3.599999874830246 2.8999998643994331 2.3999998569488525 2.099" +
				"9998524785042 1.9999998509883881 2.0999998524785042 2.3999998569488525 2.8999998" +
				"643994331 3.599999874830246 4.499999888241291</Data></Set></ChartData></Chart3DG" +
				"roup></ChartGroupsCollection><ChartStyles><Chart3DStyle><SymbolStyle Size=\"5\" Co" +
				"lor=\"Coral\" Shape=\"Box\" OutlineColor=\"\" /><LineStyle Thickness=\"0\" Color=\"Black\"" +
				" Pattern=\"Solid\" /></Chart3DStyle></ChartStyles><StyleCollection><NamedStyle Nam" +
				"e=\"Legend\" ParentName=\"Legend.default\" /><NamedStyle Name=\"Footer\" ParentName=\"C" +
				"ontrol\" /><NamedStyle Name=\"Area\" ParentName=\"Area.default\" /><NamedStyle Name=\"" +
				"Control\" ParentName=\"Control.default\" /><NamedStyle Name=\"LabelStyleDefault\" Par" +
				"entName=\"Control\" StyleData=\"BackColor=Transparent;\" /><NamedStyle Name=\"Legend." +
				"default\" ParentName=\"Control\" StyleData=\"Wrap=False;AlignVert=Top;\" /><NamedStyl" +
				"e Name=\"Header\" ParentName=\"Control\" /><NamedStyle Name=\"Control.default\" Parent" +
				"Name=\"\" StyleData=\"ForeColor=ControlText;BackColor=Control;\" /><NamedStyle Name=" +
				"\"Area.default\" ParentName=\"Control\" StyleData=\"AlignVert=Top;\" /></StyleCollecti" +
				"on><LegendData Compass=\"East\" /><FooterData Visible=\"True\" Compass=\"South\" /><He" +
				"aderData Visible=\"True\" Compass=\"North\" /></Chart3DPropBag>";
			this.c1Chart3D6.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D6.TabIndex = 0;
			// 
			// c1Chart3D5
			// 
			this.c1Chart3D5.Location = new System.Drawing.Point(312, 168);
			this.c1Chart3D5.Name = "c1Chart3D5";
			this.c1Chart3D5.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View RotationX=\"54\" RotationZ=\"2" +
				"18\" /><ChartGroupsCollection><Chart3DGroup ChartType=\"Scatter\"><Elevation DropLi" +
				"nes=\"True\" /><ChartData><Set type=\"Chart3DDataSetGrid\" RowCount=\"11\" ColumnCount" +
				"=\"11\" RowDelta=\"1\" ColumnDelta=\"1\" RowOrigin=\"0\" ColumnOrigin=\"0\" Hole=\"3.402823" +
				"4663852886E+38\"><Data>4.499999888241291 3.599999874830246 2.8999998643994331 2.3" +
				"999998569488525 2.0999998524785042 1.9999998509883881 2.0999998524785042 2.39999" +
				"98569488525 2.8999998643994331 3.599999874830246 4.499999888241291 8.09999994188" +
				"54713 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.699999906122684" +
				"5 5.5999999046325684 5.6999999061226845 5.9999999105930328 6.4999999180436134 7." +
				"1999999284744263 8.0999999418854713 10.899999983608723 9.9999999701976776 9.2999" +
				"999597668648 8.7999999523162842 8.4999999478459358 8.39999994635582 8.4999999478" +
				"459358 8.7999999523162842 9.2999999597668648 9.9999999701976776 10.8999999836087" +
				"23 12.900000013411045 12 11.299999989569187 10.799999982118607 10.49999997764825" +
				"8 10.399999976158142 10.499999977648258 10.799999982118607 11.299999989569187 12" +
				" 12.900000013411045 14.100000031292439 13.200000017881393 12.500000007450581 12 " +
				"11.699999995529652 11.599999994039536 11.699999995529652 12 12.500000007450581 1" +
				"3.200000017881393 14.100000031292439 14.500000037252903 13.600000023841858 12.90" +
				"0000013411045 12.400000005960465 12.100000001490116 12 12.100000001490116 12.400" +
				"000005960465 12.900000013411045 13.600000023841858 14.500000037252903 14.1000000" +
				"31292439 13.200000017881393 12.500000007450581 12 11.699999995529652 11.59999999" +
				"4039536 11.699999995529652 12 12.500000007450581 13.200000017881393 14.100000031" +
				"292439 12.900000013411045 12 11.299999989569187 10.799999982118607 10.4999999776" +
				"48258 10.399999976158142 10.499999977648258 10.799999982118607 11.29999998956918" +
				"7 12 12.900000013411045 10.899999983608723 9.9999999701976776 9.2999999597668648" +
				" 8.7999999523162842 8.4999999478459358 8.39999994635582 8.4999999478459358 8.799" +
				"9999523162842 9.2999999597668648 9.9999999701976776 10.899999983608723 8.0999999" +
				"418854713 7.1999999284744263 6.4999999180436134 5.9999999105930328 5.69999990612" +
				"26845 5.5999999046325684 5.6999999061226845 5.9999999105930328 6.499999918043613" +
				"4 7.1999999284744263 8.0999999418854713 4.499999888241291 3.599999874830246 2.89" +
				"99998643994331 2.3999998569488525 2.0999998524785042 1.9999998509883881 2.099999" +
				"8524785042 2.3999998569488525 2.8999998643994331 3.599999874830246 4.49999988824" +
				"1291</Data></Set></ChartData></Chart3DGroup></ChartGroupsCollection><ChartStyles" +
				"><Chart3DStyle><SymbolStyle Size=\"5\" Color=\"Coral\" Shape=\"Box\" OutlineColor=\"\" /" +
				"><LineStyle Thickness=\"0\" Color=\"Black\" Pattern=\"Solid\" /></Chart3DStyle></Chart" +
				"Styles><StyleCollection><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\" />" +
				"<NamedStyle Name=\"Footer\" ParentName=\"Control\" /><NamedStyle Name=\"Area\" ParentN" +
				"ame=\"Area.default\" /><NamedStyle Name=\"Control\" ParentName=\"Control.default\" /><" +
				"NamedStyle Name=\"LabelStyleDefault\" ParentName=\"Control\" StyleData=\"BackColor=Tr" +
				"ansparent;\" /><NamedStyle Name=\"Legend.default\" ParentName=\"Control\" StyleData=\"" +
				"Wrap=False;AlignVert=Top;\" /><NamedStyle Name=\"Header\" ParentName=\"Control\" /><N" +
				"amedStyle Name=\"Control.default\" ParentName=\"\" StyleData=\"ForeColor=ControlText;" +
				"BackColor=Control;\" /><NamedStyle Name=\"Area.default\" ParentName=\"Control\" Style" +
				"Data=\"AlignVert=Top;\" /></StyleCollection><LegendData Compass=\"East\" /><FooterDa" +
				"ta Visible=\"True\" Compass=\"South\" /><HeaderData Visible=\"True\" Compass=\"North\" /" +
				"></Chart3DPropBag>";
			this.c1Chart3D5.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D5.TabIndex = 0;
			// 
			// c1Chart3D7
			// 
			this.c1Chart3D7.Location = new System.Drawing.Point(464, 8);
			this.c1Chart3D7.Name = "c1Chart3D7";
			this.c1Chart3D7.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View Perspective=\"10000\" Rotatio" +
				"nX=\"0\" RotationZ=\"0\" /><ChartGroupsCollection><Chart3DGroup><Elevation IsMeshed=" +
				"\"False\" /><Contour IsZoned=\"True\" /><ChartData><Set type=\"Chart3DDataSetGrid\" Ro" +
				"wCount=\"11\" ColumnCount=\"11\" RowDelta=\"1\" ColumnDelta=\"1\" RowOrigin=\"0\" ColumnOr" +
				"igin=\"0\" Hole=\"3.4028234663852886E+38\"><Data>4.499999888241291 3.599999874830246" +
				" 2.8999998643994331 2.3999998569488525 2.0999998524785042 1.9999998509883881 2.0" +
				"999998524785042 2.3999998569488525 2.8999998643994331 3.599999874830246 4.499999" +
				"888241291 8.0999999418854713 7.1999999284744263 6.4999999180436134 5.99999991059" +
				"30328 5.6999999061226845 5.5999999046325684 5.6999999061226845 5.999999910593032" +
				"8 6.4999999180436134 7.1999999284744263 8.0999999418854713 10.899999983608723 9." +
				"9999999701976776 9.2999999597668648 8.7999999523162842 8.4999999478459358 8.3999" +
				"9994635582 8.4999999478459358 8.7999999523162842 9.2999999597668648 9.9999999701" +
				"976776 10.899999983608723 12.900000013411045 12 11.299999989569187 10.7999999821" +
				"18607 10.499999977648258 10.399999976158142 10.499999977648258 10.79999998211860" +
				"7 11.299999989569187 12 12.900000013411045 14.100000031292439 13.200000017881393" +
				" 12.500000007450581 12 11.699999995529652 11.599999994039536 11.699999995529652 " +
				"12 12.500000007450581 13.200000017881393 14.100000031292439 14.500000037252903 1" +
				"3.600000023841858 12.900000013411045 12.400000005960465 12.100000001490116 12 12" +
				".100000001490116 12.400000005960465 12.900000013411045 13.600000023841858 14.500" +
				"000037252903 14.100000031292439 13.200000017881393 12.500000007450581 12 11.6999" +
				"99995529652 11.599999994039536 11.699999995529652 12 12.500000007450581 13.20000" +
				"0017881393 14.100000031292439 12.900000013411045 12 11.299999989569187 10.799999" +
				"982118607 10.499999977648258 10.399999976158142 10.499999977648258 10.7999999821" +
				"18607 11.299999989569187 12 12.900000013411045 10.899999983608723 9.999999970197" +
				"6776 9.2999999597668648 8.7999999523162842 8.4999999478459358 8.39999994635582 8" +
				".4999999478459358 8.7999999523162842 9.2999999597668648 9.9999999701976776 10.89" +
				"9999983608723 8.0999999418854713 7.1999999284744263 6.4999999180436134 5.9999999" +
				"105930328 5.6999999061226845 5.5999999046325684 5.6999999061226845 5.99999991059" +
				"30328 6.4999999180436134 7.1999999284744263 8.0999999418854713 4.499999888241291" +
				" 3.599999874830246 2.8999998643994331 2.3999998569488525 2.0999998524785042 1.99" +
				"99998509883881 2.0999998524785042 2.3999998569488525 2.8999998643994331 3.599999" +
				"874830246 4.499999888241291</Data></Set></ChartData></Chart3DGroup></ChartGroups" +
				"Collection><ChartStyles><Chart3DStyle><SymbolStyle Size=\"5\" Color=\"Coral\" Shape=" +
				"\"Box\" OutlineColor=\"\" /><LineStyle Thickness=\"0\" Color=\"Black\" Pattern=\"Solid\" /" +
				"></Chart3DStyle></ChartStyles><StyleCollection><NamedStyle Name=\"Legend\" ParentN" +
				"ame=\"Legend.default\" /><NamedStyle Name=\"Footer\" ParentName=\"Control\" /><NamedSt" +
				"yle Name=\"Area\" ParentName=\"Area.default\" /><NamedStyle Name=\"Control\" ParentNam" +
				"e=\"Control.default\" /><NamedStyle Name=\"LabelStyleDefault\" ParentName=\"Control\" " +
				"StyleData=\"BackColor=Transparent;\" /><NamedStyle Name=\"Legend.default\" ParentNam" +
				"e=\"Control\" StyleData=\"Wrap=False;AlignVert=Top;\" /><NamedStyle Name=\"Header\" Pa" +
				"rentName=\"Control\" /><NamedStyle Name=\"Control.default\" ParentName=\"\" StyleData=" +
				"\"ForeColor=ControlText;BackColor=Control;\" /><NamedStyle Name=\"Area.default\" Par" +
				"entName=\"Control\" StyleData=\"AlignVert=Top;\" /></StyleCollection><LegendData Com" +
				"pass=\"East\" /><FooterData Visible=\"True\" Compass=\"South\" /><HeaderData Visible=\"" +
				"True\" Compass=\"North\" /></Chart3DPropBag>";
			this.c1Chart3D7.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D7.TabIndex = 0;
			// 
			// c1Chart3D8
			// 
			this.c1Chart3D8.Location = new System.Drawing.Point(464, 168);
			this.c1Chart3D8.Name = "c1Chart3D8";
			this.c1Chart3D8.PropBag = "<?xml version=\"1.0\"?><Chart3DPropBag Version=\"\"><View RotationX=\"94\" RotationZ=\"2" +
				"42\" /><ChartGroupsCollection><Chart3DGroup><Elevation IsMeshed=\"False\" /><ChartD" +
				"ata><Set type=\"Chart3DDataSetGrid\" RowCount=\"11\" ColumnCount=\"11\" RowDelta=\"1\" C" +
				"olumnDelta=\"1\" RowOrigin=\"0\" ColumnOrigin=\"0\" Hole=\"3.4028234663852886E+38\"><Dat" +
				"a>4.499999888241291 3.599999874830246 2.8999998643994331 2.3999998569488525 2.09" +
				"99998524785042 1.9999998509883881 2.0999998524785042 2.3999998569488525 2.899999" +
				"8643994331 3.599999874830246 4.499999888241291 8.0999999418854713 7.199999928474" +
				"4263 6.4999999180436134 5.9999999105930328 5.6999999061226845 5.5999999046325684" +
				" 5.6999999061226845 5.9999999105930328 6.4999999180436134 7.1999999284744263 8.0" +
				"999999418854713 10.899999983608723 9.9999999701976776 9.2999999597668648 8.79999" +
				"99523162842 8.4999999478459358 8.39999994635582 8.4999999478459358 8.79999995231" +
				"62842 9.2999999597668648 9.9999999701976776 10.899999983608723 12.90000001341104" +
				"5 12 11.299999989569187 10.799999982118607 10.499999977648258 10.399999976158142" +
				" 10.499999977648258 10.799999982118607 11.299999989569187 12 12.900000013411045 " +
				"14.100000031292439 13.200000017881393 12.500000007450581 12 11.699999995529652 1" +
				"1.599999994039536 11.699999995529652 12 12.500000007450581 13.200000017881393 14" +
				".100000031292439 14.500000037252903 13.600000023841858 12.900000013411045 12.400" +
				"000005960465 12.100000001490116 12 12.100000001490116 12.400000005960465 12.9000" +
				"00013411045 13.600000023841858 14.500000037252903 14.100000031292439 13.20000001" +
				"7881393 12.500000007450581 12 11.699999995529652 11.599999994039536 11.699999995" +
				"529652 12 12.500000007450581 13.200000017881393 14.100000031292439 12.9000000134" +
				"11045 12 11.299999989569187 10.799999982118607 10.499999977648258 10.39999997615" +
				"8142 10.499999977648258 10.799999982118607 11.299999989569187 12 12.900000013411" +
				"045 10.899999983608723 9.9999999701976776 9.2999999597668648 8.7999999523162842 " +
				"8.4999999478459358 8.39999994635582 8.4999999478459358 8.7999999523162842 9.2999" +
				"999597668648 9.9999999701976776 10.899999983608723 8.0999999418854713 7.19999992" +
				"84744263 6.4999999180436134 5.9999999105930328 5.6999999061226845 5.599999904632" +
				"5684 5.6999999061226845 5.9999999105930328 6.4999999180436134 7.1999999284744263" +
				" 8.0999999418854713 4.499999888241291 3.599999874830246 2.8999998643994331 2.399" +
				"9998569488525 2.0999998524785042 1.9999998509883881 2.0999998524785042 2.3999998" +
				"569488525 2.8999998643994331 3.599999874830246 4.499999888241291</Data></Set></C" +
				"hartData></Chart3DGroup></ChartGroupsCollection><ChartStyles><Chart3DStyle><Symb" +
				"olStyle Size=\"5\" Color=\"Coral\" Shape=\"Box\" OutlineColor=\"\" /><LineStyle Thicknes" +
				"s=\"0\" Color=\"Black\" Pattern=\"Solid\" /></Chart3DStyle></ChartStyles><StyleCollect" +
				"ion><NamedStyle Name=\"Legend\" ParentName=\"Legend.default\" /><NamedStyle Name=\"Fo" +
				"oter\" ParentName=\"Control\" /><NamedStyle Name=\"Area\" ParentName=\"Area.default\" /" +
				"><NamedStyle Name=\"Control\" ParentName=\"Control.default\" /><NamedStyle Name=\"Lab" +
				"elStyleDefault\" ParentName=\"Control\" StyleData=\"BackColor=Transparent;\" /><Named" +
				"Style Name=\"Legend.default\" ParentName=\"Control\" StyleData=\"Wrap=False;AlignVert" +
				"=Top;\" /><NamedStyle Name=\"Header\" ParentName=\"Control\" /><NamedStyle Name=\"Cont" +
				"rol.default\" ParentName=\"\" StyleData=\"ForeColor=ControlText;BackColor=Control;\" " +
				"/><NamedStyle Name=\"Area.default\" ParentName=\"Control\" StyleData=\"AlignVert=Top;" +
				"\" /></StyleCollection><LegendData Compass=\"East\" /><FooterData Visible=\"True\" Co" +
				"mpass=\"South\" /><HeaderData Visible=\"True\" Compass=\"North\" /></Chart3DPropBag>";
			this.c1Chart3D8.Size = new System.Drawing.Size(152, 152);
			this.c1Chart3D8.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 368);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "Create PDF";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(152, 376);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(480, 16);
			this.label1.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(642, 405);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.button1,
																		  this.tabControl1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "C1Charts in PDF";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart8)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c1Chart3D8)).EndInit();
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
			// start document
			_c1pdf.Clear();
			//_c1pdf.Landscape = true;

			// build page and chart rectangles
			RectangleF rcPage = _c1pdf.PageRectangle;
			rcPage.Inflate(-60, -72);
			rcPage.X = 72;
			RectangleF rcChart = new RectangleF(rcPage.X, rcPage.Y, 160, 160);

			// show title
			Font font = new Font("Tahoma", 16, FontStyle.Bold);
			string text = "Pdf charts created with the C1Chart control.";
			RectangleF rc = rcPage;
			rc.Y = rcPage.Y - 24;
			_c1pdf.DrawString(text, font, Brushes.DarkGray, rc);

			// scan controls on the selected tab page and render charts
			foreach (Control c in tabControl1.SelectedTab.Controls)
			{
				// skip invisible controls
				if (!c.Visible) continue;

				// get chart control
				C1.Win.C1Chart.C1Chart     c2d = c as C1.Win.C1Chart.C1Chart;
				C1.Win.C1Chart3D.C1Chart3D c3d = c as C1.Win.C1Chart3D.C1Chart3D;

				// get metafile from chart control
				label1.Text = string.Format("Getting image from {0}...", c.Name);
				label1.Update();
				Metafile meta = null;
				if (c2d != null) meta = (Metafile)c2d.GetImage();
				if (c3d != null) meta = (Metafile)c3d.GetImage();

				// make sure we got the metafile
				if (meta == null) continue;

				// draw it, frame it, and move on
				label1.Text = string.Format("Exporting {0}...", c.Name);
				label1.Update();
				_c1pdf.DrawImage(meta, rcChart);
				_c1pdf.DrawRectangle(Pens.SteelBlue, rcChart);
				rcChart = NextChartRect(rcChart, rcPage);
			}
			label1.Text = string.Empty;

			// save document and show it
			string fileName = string.Format(@"c:\temp\test\{0}.pdf", tabControl1.SelectedTab.Text);
			_c1pdf.Save(fileName);
			Process.Start(fileName);
		}

		// update chart rectangle
		RectangleF NextChartRect(RectangleF rc, RectangleF rcPage)
		{
			// move to the right
			rc.Offset(rc.Width+6, 0);

			// wrap to next line
			if (rc.Right > rcPage.Right)
			{
				rc.X = rcPage.X;
				rc.Offset(0, rc.Height+6);
			}

			// wrap to next page
			if (rc.Bottom > rcPage.Bottom)
			{
				_c1pdf.NewPage();
				rc.Location = rcPage.Location;
			}

			// done
			return rc;
		}
	}
}
