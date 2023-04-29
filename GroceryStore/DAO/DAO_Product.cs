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
            string statement = "insertProduct @nameProduct , @amountProduct , @priceProduct , @imageProduct , @typeProduct , @shipment , @shelflife ";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { product.TenSP, product.Amount, product.GiaSP, product.HinhAnh , product.LoaiSP, produt.Shipment, DateTime.Parse(product.Shelflife) });
        }
        #endregion

            
        #region 2. Delete product
        public void deleteProduct(DTO_Product product)
        {
            string statement = "deleteProduct @idProduct";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] {product.MaSP});
        }
        #endregion


        #region 3. Update product
        public void updateProduct(DTO_Product product)
        {
            string statement = "updateProduct @nameProduct , @priceProduct , @imageProduct , @typeProduct, @idProduct";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { product.TenSP, product.GiaSP, product.HinhAnh , product.LoaiSP});
        }
        #endregion

        #region 4. Check exists Product

        public bool checkExistsProduct(DTO_Product product)
        {
            string statement = "checkExistsProduct @nameProduct, @priceProduct, @imageProduct, @typeProduct";
            int count = (Int32)DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] { product.TenSP, product.GiaSP, product.HinhAnh, product.LoaiSP });
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
