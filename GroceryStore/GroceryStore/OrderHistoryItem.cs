using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStore
{
    public partial class OrderHistoryItem : UserControl
    {
        public OrderHistoryItem()
        {
            InitializeComponent();
        }

        private string id;
        private int price;
        private int amount;
        private string paymethod;
        private string paydate;
        private string status;


        public int Price
        {
            get { return price; }
            set { price = value; lb_price.Text = value.ToString() + "đ"; }
        }

        public string ID { get { return id; } set { id = value; lb_id.Text = value.ToString(); } }

        public string Paymethod { get { return paymethod; } set { paymethod = value; lb_paymethod.Text = value.ToString(); } }

        public string Paydate { get { return paydate; } set { paydate = value; lb_paydate.Text = value.ToString(); } }

        public string Status { get { return status; } set { status = value; lb_status.Text = value.ToString(); } }

        public int Amount { get { return amount; } set { amount = value; lb_amount.Text = value.ToString(); } }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public OrderHistoryItem(string id, int price, int amount, string paymethod, string paydate, string status)
        {
            this.id = id;
            this.price = price;
            this.amount = amount;
            this.paymethod = paymethod;
            this.paydate = paydate;
            this.status = status;
        }

        private void lb_id_Click(object sender, EventArgs e)
        {

        }

        private void lb_status_Click(object sender, EventArgs e)
        {
        }

        private void OrderHistoryItem_Load(object sender, EventArgs e)
        {
        }

        private void lb_amount_Click(object sender, EventArgs e)
        {
        }

        private void lb_price_Click(object sender, EventArgs e)
        {
        }

        private void lb_paymethod_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
