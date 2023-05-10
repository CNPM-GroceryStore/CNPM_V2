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
            string statement = "insertProduct @nameProduct , @amountProduct , @priceProduct , @imageProduct , @typeProduct , @shipment , @shelflife , @supplier";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { product.NameProduct, product.Amount, product.PriceProduct, product.ImageProduct , product.TypeProduct, product.Shipment, DateTime.Parse(product.Shelflife) , product.NameSupplier});
        }
        #endregion

            
        #region 2. Delete product
        public void deleteProduct(DTO_Product product)
        {
            string statement = "deleteProduct @idProduct";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] {product.IdProduct});
        }
        #endregion


        #region 3. Update product
        public void updateProduct(DTO_Product product)
        {
            string statement = "updateProduct @idProduct , @nameProduct , @amountProduct, @priceProduct , @imageProduct , @typeProduct , @shipment , @shelflife, @nameSupplier";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { product.IdProduct.ToString(), product.NameProduct, product.Amount, product.PriceProduct, product.ImageProduct , product.TypeProduct, product.Shipment, DateTime.Parse(product.Shelflife), product.NameSupplier});
        }
        #endregion

        #region 4. Check exists Product

        public bool checkExistsProduct(DTO_Product product)
        {
            string statement = "checkExistsProduct @nameProduct, @priceProduct, @imageProduct, @typeProduct";
            int count = (Int32)DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] { product.NameProduct, product.PriceProduct, product.ImageProduct, product.TypeProduct });
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region
        public int getAmount(int idProduct)
        {
            string statement = "getAmount @idProduct";  
            return (int)DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] {idProduct});
        }
        #endregion

        #region 

        public void updateAmount(DTO_Product product, int value)
        {
            string statement = "updateAmount @idProduct , @value";
            DataProvider.Instance.ExecuteStoredProcedure(statement , new object[] { product.IdProduct, value });
        }
        #endregion

        #region
        public String getNameSupplierById(DTO_Product product)
        {
            string statement = "getNameSupplierById @idProduct";
            DataTable res = DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { product.IdProduct });
            DataRow row = res.Rows[0];
            string myValue = row[0].ToString();
            return myValue;
        }
        #endregion

    }
}
