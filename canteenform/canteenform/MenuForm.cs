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
    public partial class MenuForm : Form
    {
        private string userId;
        private string storeName;
        private List<Food> foods;
        public MenuForm(string userId, string storeName)
        {
            this.userId = userId;
            this.storeName = storeName;
            List<Store> stores = Webservice.getStoreByName(storeName);
            foreach (Store store in stores)
            {
                foods = store.menu;
            }
            comboBox1.DataSource = foods;
            comboBox1.DisplayMember = "foodName";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Webservice.userOrder(comboBox1.SelectedItem.ToString(), userId);
            MessageBox.Show("添加成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ShoppingForm(userId).Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ShoppingCar(userId, storeName).Show();
            this.Hide();
        }
    }
}
