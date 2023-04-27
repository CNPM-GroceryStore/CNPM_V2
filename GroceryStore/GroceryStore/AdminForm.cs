using BUS_1;
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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        BUS_OrderHistory bus_OrderHistory = new BUS_OrderHistory();

        private void AdminForm_Load(object sender, EventArgs e)
        {
            showRecentOrder(sender, e);
        }

        //show 5 most recent order
        public void showRecentOrder(Object sender, EventArgs e)
        {
            DataTable table = bus_OrderHistory.getRecemtOrder();
            dgv_order.DataSource = table;
        }
    }
}
