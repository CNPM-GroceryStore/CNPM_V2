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
    public partial class ProductItem : System.Windows.Forms.UserControl
    {
        public ProductItem()
        {
            InitializeComponent();
        }

        #region Properties
        private Image _imageProduct;
        private String _nameProduct;
        private int _priceProduct;

        private void Item_Load(object sender, EventArgs e)
        {
            pb_imageProduct.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }

        private void pb_imageProduct_Click(object sender, EventArgs e)
        {
            pn_border.Visible = true;
            timer_border.Enabled = true;
        }

        private void timer_border_Tick(object sender, EventArgs e)
        {
            pn_border.Visible = !pn_border.Visible;
            if (!pn_border.Visible)
            {
                timer_border.Enabled = false;
            }
        }

        [Category("N5")]
        public Image ImageProduct
        {
            get { return _imageProduct; }
            set { _imageProduct = value; pb_imageProduct.Image = value; }
        }

        [Category("N5")]
        public String NameProduct
        {
            get { return _nameProduct; }
            set { _nameProduct = value; lb_nameProduct.Text = value; }
        }

        [Category("N5")]
        public int PriceProduct
        {
            get { return _priceProduct; }
            set { _priceProduct = value; lb_priceProduct.Text = value.ToString() + "đ"; }
        }

        #endregion
    }
}

