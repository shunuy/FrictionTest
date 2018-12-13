using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace FrictionTester
{
    public partial class GdLogin : Form
    {
        private bool userhaslogin = false; 
        public GdLogin()
        {
            InitializeComponent();
        }

        private void loginsystem_Click(object sender, EventArgs e)
        {
            userhaslogin = false;
            if (username.Text.Equals("yqq") && userpassword.Text.Equals("1234"))
            {
                userhaslogin = true;
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("输入的用户账号或密码不对！","提示");
            }
        }

        public bool Getlogin()
        {
            return userhaslogin;
        }

        private void GdLogin_Load(object sender, EventArgs e)
        {

        }
    }
}