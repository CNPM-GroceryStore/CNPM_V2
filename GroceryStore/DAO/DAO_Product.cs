using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Product
    {
        #region 1. Insert product
        public void insertProduct(DTO_Product product)
        {
            string statement = "INSERT INTO SanPham (TenSP, GiaSP, HinhAnh, LoaiSP) VALUES ( @TenSP , @GiaSP , @HinhAnh , @LoaiSP )";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { product.TenSP, product.GiaSP, product.HinhAnh , product.LoaiSP});
        }
        #endregion

            
        #region 2. Delete product
        public void deleteProduct(DTO_Product product)
        {
            string statement = "DELETE FROM SanPham WHERE MaSP = @masp";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] {product.MaSP});
        }
        #endregion


        #region 3. Update product
        public void updateProduct(DTO_Product product)
        {
            string statement = "UPDATE SanPham SET TenSP = @TenSP , GiaSP = @GiaSP , HinhAnh = @HinhAnh , LoaiSP = @LoaiSP";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { product.TenSP, product.GiaSP, product.HinhAnh , product.LoaiSP});
        }
        #endregion

        #region 4. Check exists Product

        public bool checkExistsProduct(DTO_Product product)
        {
            string statement = "SELECT TenSP , GiaSP , HinhAnh FROM SanPham WHERE TenSP = @TenSP , GiaSP = @GiaSP , HinhAnh = @HinhAnh , LoaiSP = @LoaiSP";
            if (DataProvider.Instance.ExecuteNonQuery(statement, new object[] { product.TenSP, product.LoaiSP }) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
