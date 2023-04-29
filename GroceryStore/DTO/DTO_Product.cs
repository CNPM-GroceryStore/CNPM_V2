using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Product
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int GiaSP { get; set; }
        public int Amount { get; set; }
        public string HinhAnh { get; set; }
        public string LoaiSP { get; set; }

        public string Shipment { get; set; }
        public string Shelflife { get; set; }

        public DTO_Product(int MaSp, string tenSP, int amount, int giaSP, string hinhAnh, string loaiSP, string shipment, string shelflife)
        {
            MaSP = MaSp;
            TenSP = tenSP;
            Amount = amount;
            GiaSP = giaSP;
            HinhAnh = hinhAnh;
            LoaiSP = loaiSP;
            Shipment = shipment;
            Shelflife = shelflife;
        }
        public DTO_Product(string tenSP, int giaSP, string hinhAnh, string loaiSP)
        {
            TenSP = tenSP;
            GiaSP = giaSP;
            HinhAnh = hinhAnh;
            LoaiSP = loaiSP;
        }
        public DTO_Product(string tenSP, int giaSP, string hinhAnh)
        {
            TenSP = tenSP;
            GiaSP = giaSP;
            HinhAnh = hinhAnh;
        }

        public DTO_Product(string tenSP, int amount, int giaSP, string hinhAnh, string loaiSP, string shipment, string shelflife)
        {
            TenSP = tenSP;
            Amount = amount;
            GiaSP = giaSP;
            HinhAnh = hinhAnh;
            LoaiSP = loaiSP;
            Shipment = shipment;
            Shelflife = shelflife;
        }

        public String ToString()
        {
            return this.TenSP+", "+Amount+", "+GiaSP+", "+HinhAnh+", "+LoaiSP+", "+Shipment+", "+", "+Shelflife;
        }
    }
}
