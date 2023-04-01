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
    public partial class Voucher : UserControl
    {
        public Voucher()
        {
            InitializeComponent();
        }


        #region Properties
        private Image _imageVoucher;
        private String _nameVoucher;
        private int _priceVoucher;

        private void Voucher_Load(object sender, EventArgs e)
        {
            pb_imageVoucher.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }

        [Category("N5")]
        public Image ImageVoucher
        {
            get { return _imageVoucher; }
            set { _imageVoucher = value; pb_imageVoucher.Image = value; }
        }

        [Category("N5")]
        public String NameVoucher
        {
            get { return _nameVoucher; }
            set { _nameVoucher = value; lb_nameVoucher.Text = value; }
        }

        [Category("N5")]
        public int PriceVoucher
        {
            get { return _priceVoucher; }
            set { _priceVoucher = value; lb_priceVoucher.Text = value.ToString() + "đ"; }
        }

        #endregion
    }
}
