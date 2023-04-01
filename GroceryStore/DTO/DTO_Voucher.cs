using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Voucher
    {
        public int MaVoucher { get; set; }
        public string TenVoucher { get; set; }
        public int GiaVoucher { get; set; }
        public string HinhAnh { get; set; }

        public DTO_Voucher(int maVoucher, string tenVoucher, int giaVoucher, string hinhAnh)
        {
            MaVoucher = maVoucher;
            TenVoucher = tenVoucher;
            GiaVoucher = giaVoucher;
            HinhAnh = hinhAnh;
        }
        public DTO_Voucher(string tenVoucher, int giaVoucher, string hinhAnh)
        {
            TenVoucher = tenVoucher;
            GiaVoucher = giaVoucher;
            HinhAnh = hinhAnh;
        }
    }
}
