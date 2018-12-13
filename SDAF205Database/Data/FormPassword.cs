using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SDAF.DataBase
{
     public partial class FormPassword : Form
     {
          public FormPassword()
          {
               InitializeComponent();
          }

       

          private void btnOK_Click(object sender, EventArgs e)
          {

          }

          private void button1_Click(object sender, EventArgs e)
          {
            
          }

          private void FormPassword_FormClosing(object sender, FormClosingEventArgs e)
          {

              if (this.DialogResult == DialogResult.OK && textBox1.Text.Trim() != GlobalCofigData.SystemConfig.PassWord)
               {
                   this.Text = Properties.Resources.PasswordInputError;
                   textBox1.Focus();
                    e.Cancel = true;
               }
          }

          private void textBox1_KeyDown(object sender, KeyEventArgs e)
          {
               if (e.KeyCode == Keys.Enter)
               {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
               }
               else if (e.KeyCode == Keys.Escape)
               {
                    this.Close();
               }
               else
               {
                   if (this.Text == Properties.Resources.PasswordInputError) this.Text = Properties.Resources.PasswordInput;

               }
               //if (e.KeyCode == Keys.Enter)
               //{
               //     if (textBox1.Text.Trim() != GlobalCofigData.SystemConfig.PassWord)
               //     {
               //          this.Text = "√‹¬Î¥ÌŒÛ,«Î÷ÿ–¬ ‰»Î:";
               //          textBox1.Focus();
               //     }
               //     else
               //     {
               //          this.DialogResult = DialogResult.OK;
               //          this.Close();
               //          this.DialogResult = DialogResult.OK;
               //     }
               //}
          }

        
         
     }

         
}