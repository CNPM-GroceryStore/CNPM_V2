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
    public partial class MyVoucher : UserControl
    {
        public MyVoucher()
        {
            InitializeComponent();
        }

        #region Properties
        private int _quantity;
        private int _idMyVoucher;
        private Image _imageMyVoucher;
        private String _nameMyVoucher;
        private int _priceMyVoucher;
        public event EventHandler UseVoucherClicked;
        public event EventHandler BoVoucherClicked;
        public int _ownVoucher;

        private void MyVoucher_Load(object sender, EventArgs e)
        {
            _ownVoucher = _quantity;
        }

        private void btn_use_Click(object sender, EventArgs e)
        {
            UseVoucherClicked?.Invoke(this, EventArgs.Empty);
            _quantity -= 1;
            lb_soLuong.Text = "x" + _quantity.ToString();
            checkClick();
        }

        private void btn_bo_Click(object sender, EventArgs e)
        {
            BoVoucherClicked?.Invoke(this, EventArgs.Empty);
            _quantity += 1;
            lb_soLuong.Text = "x" + _quantity.ToString();
            checkClick();
        }

        private void checkClick()
        {
            if (_quantity == 0)
            {
                btn_use.Visible = false;
                btn_bo.Visible = true;
            }
            else
            {
                btn_use.Visible = true;
            }
            if (_quantity == _ownVoucher)
            {
                btn_bo.Visible = false;
            }
            else
            {
                btn_bo.Visible = true;
            }
        }

        public int Quantity { get { return _quantity; } set { _quantity = value; lb_soLuong.Text = "x" + value.ToString(); _ownVoucher = _quantity; } }

        public int IdMyVoucher
        {
            get { return _idMyVoucher; }
            set { _idMyVoucher = value; }
        }
        public Image ImageMyVoucher
        {
            get { return _imageMyVoucher; }
            set { _imageMyVoucher = value; pb_imageMyVoucher.Image = value; }
        }

        public String NameMyVoucher
        {
            get { return _nameMyVoucher; }
            set { _nameMyVoucher = value; lb_nameMyVoucher.Text = value; }
        }

        public int PriceMyVoucher
        {
            get { return _priceMyVoucher; }
            set { _priceMyVoucher = value; lb_priceMyVoucher.Text = value.ToString() + "đ"; }
        }
        #endregion
    }
}
