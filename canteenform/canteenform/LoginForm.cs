using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using canteensystem.Models;

namespace canteenform
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("用户名或者密码不能为空！", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            Users user = Webservice.getUserByName(textBox1.Text);
            if (user == null)
            {
                MessageBox.Show("用户名不存在！", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            if (user.password == textBox2.Text)
            {
                new ShoppingForm(user.ID).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("密码错误！", "登录提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
    }
}
