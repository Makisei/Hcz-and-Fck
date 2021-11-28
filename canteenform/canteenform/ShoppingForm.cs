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
    public partial class ShoppingForm : Form
    {
        private string userId;
        public ShoppingForm(string userId)
        {
            this.userId = userId;
            List<Store> stores = Webservice.getStore();
            InitializeComponent();
            comboBox1.DisplayMember = "storeName";
            comboBox1.DataSource = stores;
            // comboBox1.DataBindings.Add("Text", stores, "storeName");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MenuForm(userId, comboBox1.SelectedItem.ToString()).Show();
            this.Hide();
        }
    }
}
