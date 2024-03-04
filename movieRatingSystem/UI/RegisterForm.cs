using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using movieRatingSystem.Bll;

namespace movieRatingSystem.UI
{
    public partial class RegisterForm : Form
    {
        private UserBll userBll;

        public RegisterForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += RegisterForm_enter_down;
            userBll = new UserBll();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void RegisterForm_enter_down(object sender, KeyEventArgs e)
        {
            // MessageBox.Show("按下entry");
            if (e.KeyCode == Keys.Enter)
            {
                RegisterButton_Click(sender, e);
            }
        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!PasswordTextBox.Text.Equals(confrimPasswordTextBox.Text))
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }

            string inputRegisterName = this.NameTextBox.Text;
            string inputPassword = this.PasswordTextBox.Text;
            string inputMail = this.EmailTextBox.Text;
            bool registerResult = userBll.RegisterUser(inputRegisterName, inputPassword, inputMail);

            if (registerResult)
            {
                MessageBox.Show("用户注册成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("用户注册失败！");
            }
        }
    }
}