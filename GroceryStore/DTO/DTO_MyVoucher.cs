using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_MyVoucher
    {
        public String MaUser { get; set; }
        public int MaMyVoucher { get; set; }
        public string TenMyVoucher { get; set; }
        public int GiaMyVoucher { get; set; }
        public string HinhAnh { get; set; }
        public int Quantity { get; set; }
        public DTO_MyVoucher(string idUser, int idVoucher)
        {
            this.MaUser = idUser;
            this.MaMyVoucher = idVoucher;
        }

        public DTO_MyVoucher(int maMyVoucher, string tenMyVoucher, int giaMyVoucher, string hinhAnh, int quantity)
        {
            this.MaMyVoucher = maMyVoucher;
            this.TenMyVoucher = tenMyVoucher;
            this.GiaMyVoucher = giaMyVoucher;
            this.HinhAnh = hinhAnh;
            this.Quantity = quantity;
        }

        public DTO_MyVoucher(string idUser, int maMyVoucher, int giaMyVoucher, int quantity)
        {
            this.MaUser = idUser;
            this.MaMyVoucher = maMyVoucher;
            this.GiaMyVoucher = giaMyVoucher;
            this.Quantity = quantity;
        }
    }
}

