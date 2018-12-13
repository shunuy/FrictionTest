using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
//此控件是在SDC301.NumberTextBox控件基础上修改的
//SDC301.NumberTextBox有两个版本
//用在516定硫上的版本没有 ValueIsNull 属性
//有SDCH235.snk文件的版本 有ValueIsNull 属性 ,增加 MutiSubString 功能等
//
namespace SDAF.NumberTextBox
{
    public class NumberTextBox : System.Windows.Forms.TextBox
    {
        [DllImport("kernel32")]
        private static extern int lstrlen(string a);

        EnumType m_DataType;// 允许输入的类型
        double m_MinValue, m_MaxValue, m_DefaultValue, m_Value = -1;
        string m_Format;
        bool m_Valid ;
        bool canBeNull;
        bool isCheckValue = true;
       
        private ErrorProvider errorProvider1;
        private IContainer components;
        public enum EnumType
        {
            Integer = 0,
            Double = 1,
            String = 2
        }

        public delegate bool ValidatingEventHandler();
        public event ValidatingEventHandler UserValidating;

        public NumberTextBox()
        {            
            InitializeComponent();
            this.Font = new Font(this.Font, FontStyle.Regular);
            ForeColor = Color.Black;
            this.ContextMenuStrip = new ContextMenuStrip();
        }
        private void InitializeComponent()
        {
             this.components = new System.ComponentModel.Container();
             this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
             ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
             this.SuspendLayout();
             // 
             // NumberTextBox
             // 
             this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
             this.errorProvider1.SetIconPadding(this, 2);
             this.TextChanged += new System.EventHandler(this.NumberTextBox_TextChanged);
             this.GotFocus += new System.EventHandler(this.numberTextBox_GotFocus);
             this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numberTextBox_KeyDown);
             this.Leave += new System.EventHandler(this.NumberTextBox_Leave);
             this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumberTextBox_KeyUp);
             this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTextBox_KeyPress);
             this.Enter += new System.EventHandler(this.NumberTextBox_Enter);
             this.LostFocus += new System.EventHandler(this.numberTextBox_LostFocus);
             this.Validating += new System.ComponentModel.CancelEventHandler(this.NumberTextBox_Validating);
             ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
             this.ResumeLayout(false);

        }
        //[Category("扩展功能"), Description("控件与错误图标的额外空间")]
        public int SetErrorPadding
        {          
            set
            {
                this.errorProvider1.SetIconPadding(this, value);
            }
        }
        public double NText
        {
            set
            {
                if (value >= m_MinValue && value <= m_MaxValue)
                {
                    Text = value.ToString(DisFormat, CultureInfo.CurrentCulture);
                    m_Valid = true;
                    m_Value = value;
                    errorProvider1.SetError(this, "");
                }
                else if (DefaultValue != -1)
                {
                    Text = DefaultValue.ToString(DisFormat, CultureInfo.CurrentCulture);
                    m_Valid = true;
                    m_Value = DefaultValue;
                    errorProvider1.SetError(this, "");
                }
                else
                {
                    Text = "";
                    m_Value = -1;
                    m_Valid = false;
                    errorProvider1.SetError(this, "不能为空!");
                }
            }
        }
        public double GetValue
        {
            get { return m_Value; }
        }
        public bool ValueIsValid
        {
            get { return m_Valid; }
        }
        [Category("扩展功能"), Description("是否验证数值型数据")]
        public bool IsCheckValue
        {
            get
            {
                return isCheckValue;
            }
            set
            {
                isCheckValue = value;
            }
        }
        private bool canBeMinus;
        [Category("扩展功能"), Description("暂时没有用到此功能")]
        public bool CanBeMinus
        {
            get
            {
                return canBeMinus;
            }
            set
            {
                canBeMinus = value;
            }
        }

        [Category("扩展功能"), Description("显示格式")]
        public string DisFormat
        {
            get
            {
                return m_Format;
            }
            set
            {
                m_Format = value;
                if (DataType != EnumType.String)
                {
                    if (m_DefaultValue != -1)
                    {
                        Text = m_Value.ToString(m_Format, CultureInfo.CurrentCulture);
                    }
                    else
                        Text = "";
                }
            }
        }
        [Category("扩展功能"), Description("默认值")]
        public double DefaultValue
        {
            get
            {
                return m_DefaultValue;
            }
            set
            {
                m_DefaultValue = value;
                if (DataType != EnumType.String)
                {
                    if (m_DefaultValue != -1)
                    {
                        m_Value = m_DefaultValue;
                        m_Valid = true;
                    }
                    else
                        Text = "";
                }
            }
        }
        [Category("扩展功能"), Description("允许输入的类型")]
        public EnumType DataType
        {
            get
            {
                return m_DataType;
            }
            set
            {
                m_DataType = value;
            }
        }
        [Category("扩展功能"), Description("最小值")]
        public double MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
            }
        }
        [Category("扩展功能"), Description("最大值")]
        public double MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
            }
        }

        [Category("扩展功能"), Description("是否允许为空值")]
        public bool  CanbeNull
        {
            get
            {
                return canBeNull;
            }
            set
            {
                canBeNull = value;
            }
        }

     

        bool CheckKey(char _KeyChar)
        {
             if (_KeyChar == 8 || _KeyChar == 13 || _KeyChar >= 48 && _KeyChar <= 57)
             {
                  //if (DataType == EnumType.Double)
                  //{
                  //     if (DisFormat=="0.0"&&Text.IndexOf(".") == Text.Length - 2 && _KeyChar >= 48 && _KeyChar <= 57) return false;
                  //     else if (DisFormat == "0.0000" && Text.IndexOf(".") == Text.Length - 5 && _KeyChar >= 48 && _KeyChar <= 57) return false;
                  //     return true;
                  //}
                  //else
                       return true;
             }
            if (DataType == EnumType.Double)
            {
                if (_KeyChar == '.')
                    return Text.IndexOf(".") == -1 || SelectedText.IndexOf(".") != -1;
            }
            if (DataType == EnumType.Double || DataType==EnumType.Integer)
            {
                if (canBeMinus == false) return false;
                if (_KeyChar == '-')
                    return SelectionStart==0 &&Text.IndexOf("-") == -1 || SelectedText.IndexOf("-") != -1;
            }
            return false;
        }
        void numberTextBox_GotFocus(object sender, EventArgs e)
        {
            if (DataType != EnumType.String)
            {
                this.ImeMode = ImeMode.Disable;
            }
        }

         void numberTextBox_LostFocus(object sender, EventArgs e)
         {
              //if (!CheckValue())
              //{
              //     this.Focus();
              //}
           
         }

        void NumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckValue())
            {
                e.Cancel = true;
            }
            else
            {
                if (UserValidating != null)
                {
                    if (UserValidating()) e.Cancel = true;
                }
            }
        }

        void NumberTextBox_Leave(object sender, EventArgs e)
        { 
            this.Font = new Font(this.Font, FontStyle.Regular);
            ForeColor = Color.Black;
            
             //zhj delete
            //if (DataType == EnumType.String)
            //{
            //     this.Text = MutiSubString(this.Text, MaxLength); 
            //}
        }

         // zhj add
         protected override void WndProc(ref Message m)
         {
             //if (m.Msg == 0x000C)   //#define WM_SETTEXT                      0x000C
             //{

             //    int aa = 100;

             //}
             //else
             {
                 base.WndProc(ref m);
                 if (m.Msg == 0x302)
                 {
                     if (DataType == EnumType.String)
                     {
                         this.Text = MutiSubString(this.Text, MaxLength);
                     }
                 }
             }
         }

    


        public bool CheckValue()
        {
            if (DataType == EnumType.String || isCheckValue==false) return true;
            double n;
            m_Value = -1;
            m_Valid = false;

          if (double.TryParse(Text.Trim(), out n))
            {
                if (n < MinValue || n > MaxValue)
                {
                    // errorProvider1.SetError(this, "参数输入允许范围为 " + MinValue.ToString(DisFormat, CultureInfo.CurrentCulture) + "～" + MaxValue.ToString(DisFormat, CultureInfo.CurrentCulture) + " 默认为" + DefaultValue.ToString(DisFormat, CultureInfo.CurrentCulture));
                    MessageBox.Show(Resource1.InputLimit + MinValue.ToString(DisFormat, CultureInfo.CurrentCulture) + "～" + MaxValue.ToString(DisFormat, CultureInfo.CurrentCulture) + "  ", Resource1.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    // this.Focus();
                    return false;
                }
                else
                {
                    if (DataType == EnumType.Integer)
                    {
                        m_Value = Convert.ToInt32(n);
                        Text = m_Value.ToString(CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        m_Value = Convert.ToDouble(n.ToString(DisFormat, CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                        Text = m_Value.ToString(DisFormat, CultureInfo.CurrentCulture);
                    }
                    m_Valid = true;
                    errorProvider1.SetError(this, "");
                    return true;
                }
            }
            else
            {
                if (Text.Trim().Length > 0)
                {
                    // errorProvider1.SetError(this, "您输入了非数字字符!" + " 默认为" + DefaultValue.ToString(DisFormat, CultureInfo.CurrentCulture));
                    MessageBox.Show(Resource1.ErrChar, Resource1.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
                else
                {
                    //errorProvider1.SetError(this, "不能为空!" + " 默认为" + DefaultValue.ToString(DisFormat, CultureInfo.CurrentCulture));
                    if (!canBeNull)
                    {
                        MessageBox.Show(Resource1.SpaceError, Resource1.HintCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Text = DefaultValue.ToString(DisFormat, CultureInfo.CurrentCulture);
                       return false;
                    }
                    else
                        return true;
                }
            }
        }
        void numberTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                this.Parent.SelectNextControl(this, true, true, false, true);
            else if (e.KeyCode == Keys.Up)
                this.Parent.SelectNextControl(this, false, true, false, true);

        }
        void numberTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = (DataType != EnumType.String) && !CheckKey(e.KeyChar);
            if (lstrlen(this.Text) >= MaxLength && this.SelectionLength <= 0 && e.KeyChar != (char)8)
            {
                e.Handled = true;

            }
        }
        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            // if(Text.Length>=MaxLength)                
            //     this.Parent.SelectNextControl(this, true, true, false, true);
        }
        private void NumberTextBox_Enter(object sender, EventArgs e)
        {
            SelectionLength = 0;
            SelectionStart = this.Text.Length ;
            this.Font = new Font(this.Font, FontStyle.Bold);// new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)134));
            ForeColor = Color.Red;
            m_Valid = false;
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="aOrgStr">原始字符串</param>
        /// <param name="aLength">截取长度</param>
        /// <returns></returns>
        public static String MutiSubString(String aOrgStr, int aLength)
        {
            int intLen = aOrgStr.Length;
            int start = 0;
            int end = intLen;
            int single = 0;
            char[] chars = aOrgStr.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (System.Convert.ToInt32(chars[i]) > 255)
                {
                    start += 2;
                }
                else
                {
                    start += 1;
                    single++;
                }
                if (start >= aLength)
                {

                    if (end % 2 == 0)
                    {
                        if (single % 2 == 0)
                        {
                            end = i + 1;
                        }
                        else
                        {
                            end = i;
                        }
                    }
                    else
                    {
                        end = i + 1;
                    }
                    break;
                }
            }
            string temp = aOrgStr.Substring(0, end);
            string temp2 = aOrgStr.Remove(0, end);
            return temp;
        }

         private void NumberTextBox_KeyUp(object sender, KeyEventArgs e)
         {
            //  CheckValue();
         }

    }
}
