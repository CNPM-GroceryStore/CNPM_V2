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
        private int _idVoucher;
        private Image _imageVoucher;
        private String _nameVoucher;
        private int _priceVoucher;
        public event EventHandler DoiVoucherClicked;

        private void Voucher_Load(object sender, EventArgs e)
        {
            //btn_Doi.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }

        private void btn_Doi_Click(object sender, EventArgs e)
        {
            DoiVoucherClicked?.Invoke(this, EventArgs.Empty);
        }

        public int IdVoucher
        {
            get { return _idVoucher; }
            set { _idVoucher = value; }
        }
        public Image ImageVoucher
        {
            get { return _imageVoucher; }
            set { _imageVoucher = value; pb_imageVoucher.Image = value; }
        }

        public String NameVoucher
        {
            get { return _nameVoucher; }
            set { _nameVoucher = value; lb_nameVoucher.Text = value; }
        }

        public int PriceVoucher
        {
            get { return _priceVoucher; }
            set { _priceVoucher = value; lb_priceVoucher.Text = value.ToString() + "đ"; }
        }

        #endregion
    }
}
