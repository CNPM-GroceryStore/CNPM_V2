using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.BUS
{
    public class BUS_Product
    {
        DAO_Product dAO_Product = new DAO_Product();
        #region 1. Insert product
        public void insertProduct(DTO_Product product)
        {
            dAO_Product.insertProduct(product);
        }
        #endregion

        #region 2. Delete product
        public DAO_Product deleteProduct(DTO_Product product)
        {
            DAO_Product dAO_product = new DAO_Product();
            dAO_product.deleteProduct(product);
            return dAO_product;
        }
        #endregion

        #region 3. Update product
        public DTO_Product updateAmount(DTO_Product product, int value)
        {
            dAO_Product.updateAmount(product, value);
            return product;
        }
        #endregion

        #region 
        public bool checkAmount(int amount, int idProduct)
        {
            if (amount > dAO_Product.getAmount(idProduct))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 5. update Product
        public void updateProduct(DTO_Product product)
        {
            dAO_Product.updateProduct(product);
        }
        #endregion
    }
}
