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
        public string HinhAnh { get; set; }
        public string LoaiSP { get; set; }

        public DTO_Product(int maSP, string tenSP, int giaSP, string hinhAnh, string loaiSP)
        {
            MaSP = maSP;
            TenSP = tenSP;
            GiaSP = giaSP;
            HinhAnh = hinhAnh;
            LoaiSP = loaiSP;
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
    }
}
