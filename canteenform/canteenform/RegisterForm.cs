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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("用户名、性别或者密码不能为空", "注册提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            if (Webservice.getUserByName(textBox1.Text) != null)
            {
                MessageBox.Show("用户名已被注册！", "注册提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }
            Users user = new Users(textBox1.Text, textBox2.Text);
            Webservice.createUser(user);
            MessageBox.Show("注册成功！", "注册提示");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
