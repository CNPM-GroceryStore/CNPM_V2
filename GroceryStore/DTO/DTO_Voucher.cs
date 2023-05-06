using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Voucher
    {
        public int IdVoucher { get; set; }
        public string NameVoucher { get; set; }  
        public int PriceVoucher { get; set; }
        public string ImageVoucher { get; set; }

        public DTO_Voucher(int maVoucher, string tenVoucher, int giaVoucher, string hinhAnh)
        {
            IdVoucher = maVoucher;
            NameVoucher = tenVoucher;
            PriceVoucher = giaVoucher;
            ImageVoucher = hinhAnh;
        }
        public DTO_Voucher(string tenVoucher, int giaVoucher, string hinhAnh)
        {
            NameVoucher = tenVoucher;
            PriceVoucher = giaVoucher;
            ImageVoucher = hinhAnh;
        }
    }
}
