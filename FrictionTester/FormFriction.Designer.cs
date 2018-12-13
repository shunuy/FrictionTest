namespace FrictionTester
{
    partial class FormFriction
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFriction));
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.numberTextBox2 = new SDAF.NumberTextBox.NumberTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.c1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.c1FlexGrid1.ColumnInfo = resources.GetString("c1FlexGrid1.ColumnInfo");
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 1;
            this.c1FlexGrid1.Rows.DefaultSize = 20;
            this.c1FlexGrid1.Rows.MaxSize = 60;
            this.c1FlexGrid1.Rows.MinSize = 25;
            this.c1FlexGrid1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.c1FlexGrid1.Size = new System.Drawing.Size(1109, 842);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 27;
            this.c1FlexGrid1.Tag = "Master";
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGrid1.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_StartEdit);
            this.c1FlexGrid1.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_AfterEdit);
            this.c1FlexGrid1.StartDrag += new System.Windows.Forms.DragEventHandler(this.c1FlexGrid1_StartDrag);
            this.c1FlexGrid1.ValidateEdit += new C1.Win.C1FlexGrid.ValidateEditEventHandler(this.c1FlexGrid1_ValidateEdit);
            this.c1FlexGrid1.Validated += new System.EventHandler(this.c1FlexGrid1_Validated);
            this.c1FlexGrid1.AfterResizeColumn += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_AfterResizeColumn);
            this.c1FlexGrid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.c1FlexGrid1_KeyUp);
            // 
            // numberTextBox2
            // 
            this.numberTextBox2.CanBeMinus = false;
            this.numberTextBox2.CanbeNull = true;
            this.numberTextBox2.DataType = SDAF.NumberTextBox.NumberTextBox.EnumType.String;
            this.numberTextBox2.DefaultValue = 0;
            this.numberTextBox2.DisFormat = null;
            this.numberTextBox2.Font = new System.Drawing.Font("宋体", 9F);
            this.numberTextBox2.ForeColor = System.Drawing.Color.Black;
            this.numberTextBox2.IsCheckValue = true;
            this.numberTextBox2.Location = new System.Drawing.Point(383, 232);
            this.numberTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.numberTextBox2.MaxLength = 12;
            this.numberTextBox2.MaxValue = 0;
            this.numberTextBox2.MinValue = 0;
            this.numberTextBox2.Name = "numberTextBox2";
            this.numberTextBox2.Size = new System.Drawing.Size(132, 25);
            this.numberTextBox2.TabIndex = 28;
            this.numberTextBox2.Visible = false;
            // 
            // FormFriction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 842);
            this.Controls.Add(this.numberTextBox2);
            this.Controls.Add(this.c1FlexGrid1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormFriction";
            this.TabText = "摩擦感度试验";
            this.Text = "摩擦感度试验";
            this.Load += new System.EventHandler(this.FormFriction_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFriction_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private SDAF.NumberTextBox.NumberTextBox numberTextBox2;

    }
}