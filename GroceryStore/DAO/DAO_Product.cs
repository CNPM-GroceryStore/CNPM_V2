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
            string statement = "INSERT INTO Product (nameProduct, amountProduct, priceProduct, imageProduct, typeProduct, shipment, shelflife) VALUES ( @nameProduct , @amountProduct , @priceProduct , @imageProduct , @typeProduct , @shipment , @shelflife )";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { product.TenSP, product.Amount, product.GiaSP, product.HinhAnh , product.LoaiSP, product.Shipment, DateTime.Parse(product.Shelflife)});
        }
        #endregion

            
        #region 2. Delete product
        public void deleteProduct(DTO_Product product)
        {
            string statement = "DELETE FROM Product WHERE idProduct = @idProduct";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] {product.MaSP});
        }
        #endregion


        #region 3. Update product
        public void updateProduct(DTO_Product product)
        {
            string statement = "UPDATE Product SET nameProduct = @nameProduct , priceProduct = @priceProduct , imageProduct = @imageProduct , typeProduct = @typeProduct, shipment = @shipment, shelflife = @shelflife";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { product.TenSP, product.GiaSP, product.HinhAnh , product.LoaiSP, product.Shipment, product.Shelflife});
        }
        #endregion

        #region 4. Check exists Product

        public bool checkExistsProduct(DTO_Product product)
        {
            string statement = "SELECT nameProduct , priceProduct , imageProduct FROM Product WHERE nameProduct = @nameProduct , priceProduct = @priceProduct , imageProduct = @imageProduct , typeProduct = @typeProduct";
            if (DataProvider.Instance.ExecuteNonQuery(statement, new object[] { product.TenSP, product.GiaSP, product.HinhAnh, product.LoaiSP }) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
