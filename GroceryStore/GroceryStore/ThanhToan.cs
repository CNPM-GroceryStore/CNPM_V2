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
    public partial class ThanhToan : UserControl
    {
        public ThanhToan()
        {
            InitializeComponent();
        }

        #region Properties
        private int tongTien;
        private int tienVoucher;
        private int diemTichLuy;
        private int tienThanhToan;
        public event EventHandler Mua_Clicked;
        public int TongTien
        {
            get { return tongTien; }
            set { tongTien = value; lb_totalMoney.Text = tongTien.ToString() + " đ"; tinhTienThanhToan(); }
        }

        public int TienVoucher
        {
            get { return tienVoucher; }
            set { tienVoucher = value; lb_voucher.Text = "-" + tienVoucher.ToString() + " đ"; tinhTienThanhToan(); }
        }

        public int DiemTichLuy
        {
            get { return diemTichLuy; }
            set { diemTichLuy = value; lb_soDiemTichLuy.Text = diemTichLuy.ToString() + " đ"; }
        }

        public int TienThanhToan
        {
            get { return tienThanhToan; }
            set { tienThanhToan = value > 0 ? value : 0; lb_pay.Text = tienThanhToan.ToString() + " đ"; }
        }

        public void tinhTienThanhToan()
        {
            TienThanhToan = tongTien - tienVoucher;
            DiemTichLuy = TienThanhToan / 100;
        }

        #endregion

        private void btn_Mua_Click(object sender, EventArgs e)
        {
            Mua_Clicked?.Invoke(this, EventArgs.Empty);
        }

        public void clear()
        {
            TienThanhToan = 0;
            TienVoucher = 0;
            DiemTichLuy = 0;
            TongTien = 0;
        }
    }
}
