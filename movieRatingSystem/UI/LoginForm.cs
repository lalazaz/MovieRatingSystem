using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using movieRatingSystem.Bll;
using movieRatingSystem.Common;
using movieRatingSystem.UI;
using MySql.Data.MySqlClient;

namespace movieRatingSystem
{
    public partial class LoginForm : Form
    {
        private UserBll userBll;

        public LoginForm()
        {
            userBll = new UserBll();
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
            KeyDown += LoginForm_enter_down;
        }

        // 给键盘的回车键绑定为登录button
        private void LoginForm_enter_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(this.NameTextBox.Text + this.PasswordTextBox.Text);
            string inputName = this.NameTextBox.Text;
            string inputPassword = PasswordTextBox.Text;
            if (userBll.ValidateUserLogin(inputName, inputPassword))
            {
                //               MessageBox.Show("登录成功！");
                GlobalData.UserId = userBll.GetUserIdByUserName(inputName);
                // 管理员登录和普通用户登录
                if ("admin".Equals(inputName))
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Size = new Size(1500, 800);
                    adminForm.ShowDialog();
                    Close();
                }
                else
                {
                    MainForm mainForm = new MainForm();
                    mainForm.ShowDialog();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            foreach (Form? openForm in Application.OpenForms)
            {
                openForm.Close();
            }
        }
    }
}