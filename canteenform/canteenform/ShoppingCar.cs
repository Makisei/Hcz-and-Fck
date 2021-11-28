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
    public partial class ShoppingCar : Form
    {
        private string userId;
        private string storeName;
        private float sum;
        private int num;
        public ShoppingCar(string userId, string storeName)
        {
            this.userId = userId;
            this.storeName = storeName;
            InitializeComponent();
            Users user = Webservice.getUserById(userId);
            sum = Webservice.userBuy(userId);
            num = Webservice.userWaitingnum(storeName);
            listBox1.DataSource = user.shoppingCar;
            listBox1.DisplayMember = "foodName";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("总共"+sum+"元"+"，支付成功!\n前面还有"+num+"位。");
            new ShoppingForm(userId).Show();
            this.Hide();
        }
    }
}
