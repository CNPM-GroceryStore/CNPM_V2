using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ListProduct
    {
        #region 1. Show all products 
        public DataTable showAllProducts()
        {
            string statement = "SELECT TenSP, GiaSP, HinhAnh, LoaiSP FROM SanPham";
            return DataProvider.Instance.ExecuteQuery(statement);
        }
        #endregion

        #region 2. show products by type
        public DataTable getProductsByType(String type)
        {
            string statement = $"SELECT TenSP, GiaSP, HinhAnh, LoaiSP FROM SanPham WHERE LoaiSP = @LoaiSP";
            return DataProvider.Instance.ExecuteQuery(statement, new object[] { type });
            
        }
        #endregion 

        #region 3. show products by name
        public DataTable getProductsByName(String name)
        {
            string statement = $"SELECT * FROM SanPham WHERE TenSP = @TenSP";
            return DataProvider.Instance.ExecuteQuery(statement, new object[] { name });

        }
        #endregion 
    }
}
