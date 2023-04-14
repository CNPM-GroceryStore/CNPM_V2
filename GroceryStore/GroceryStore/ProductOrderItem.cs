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
    public partial class ProductOrderItem : UserControl
    {
        public ProductOrderItem()
        {
            InitializeComponent();
        }

        #region Properties
        private String _nameItemOder;
        private int _priceItemOder;
        private int _lb_totalItem;
        public event EventHandler pb_plusClicked;
        public event EventHandler pb_minusClicked;
        private void ItemOder_Load(object sender, EventArgs e)
        {
            //pb_plus.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
            //pb_minus.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }

        private void pb_plus_Click(object sender, EventArgs e)
        {
            NumberOfItem += 1;
            pb_plusClicked?.Invoke(this, EventArgs.Empty);
        }

        private void pb_minus_Click(object sender, EventArgs e)
        {
            NumberOfItem -= 1;
            pb_minusClicked?.Invoke(this, EventArgs.Empty);
        }

        public ProductOrderItem(string name, string price, int number)
        {
            this.lb_nameItemOder.Text = name;
            this.lb_priceItemOder.Text = price;
            this.lb_totalItem.Text = number.ToString();
        }

        [Category("N5")]
        public String NameItemOder
        {
            get { return _nameItemOder; }
            set { _nameItemOder = value; lb_nameItemOder.Text = value; }
        }

        [Category("N5")]
        public int PriceItemOder
        {
            get { return _priceItemOder; }
            set { _priceItemOder = value; lb_priceItemOder.Text = value.ToString(); }
        }

        [Category("N5")]
        public int NumberOfItem
        {
            get { return _lb_totalItem; }
            set { _lb_totalItem = value; lb_totalItem.Text = value.ToString(); }
        }

        #endregion

        private void lb_nameItemOder_Click(object sender, EventArgs e)
        {

        }
    }
}
