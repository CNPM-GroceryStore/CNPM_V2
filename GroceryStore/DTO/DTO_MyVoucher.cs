using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_MyVoucher
    {
        public String IdUser { get; set; }
        public int IdMyVoucher { get; set; }
        public string NameMyVoucher { get; set; }
        public int PriceMyVoucher { get; set; }
        public string ImageMyVoucher { get; set; }
        public int QuantityMyVoucher { get; set; }
        public DTO_MyVoucher(string idUser, int idVoucher)
        {
            this.IdUser = idUser;
            this.IdMyVoucher = idVoucher;
        }

        public DTO_MyVoucher(int maMyVoucher, string tenMyVoucher, int giaMyVoucher, string hinhAnh, int quantity)
        {
            this.IdMyVoucher = maMyVoucher;
            this.NameMyVoucher = tenMyVoucher;
            this.PriceMyVoucher = giaMyVoucher;
            this.ImageMyVoucher = hinhAnh;
            this.QuantityMyVoucher = quantity;
        }

        public DTO_MyVoucher(string idUser, int maMyVoucher, int giaMyVoucher, int quantity)
        {
            this.IdUser = idUser;
            this.IdMyVoucher = maMyVoucher;
            this.PriceMyVoucher = giaMyVoucher;
            this.QuantityMyVoucher = quantity;
        }
    }
}

