using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Cart
    {
        #region 1. Get product in cart
        public DataTable getAllProductInCart(DTO_User user)
        {
            string statement = "loadCart @idUser";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { user.IdUser });

        }
        #endregion

        #region 2. Add product into cart
        public void insertProductIntoCart(DTO_User user, DTO_ProductCart productCard)
        {
            string statement = "usp_InsertProductIntoCart @item_id, @idUser, @nameProduct, @priceProduct, @quantity ";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { productCard.ID, user.IdUser, productCard.Name, productCard.Price, productCard.Quantity });
        }
        #endregion

        #region 2. Delete product from Cart
        public void deleteProductFromCart(DTO_User user, DTO_ProductCart productCard)
        {
            string statement = "usp_DeleteProductIntoCart @item_id, @cart_id ";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { productCard.ID, user.IdUser});
        }
        #endregion

        #region 3. update product from Cart
        public void updateProductFromCart(DTO_User user, DTO_ProductCart productCard)
        {
            string statement = "usp_UpdateProductIntoCart @quantity,@cart_id, @item_id ";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { productCard.Quantity, user.IdUser, productCard.ID}) ;
        }
        #endregion

        #region 4. Create cart for user
        public void createCart(DTO_User user)
        {
            string statement = "usp_CreateCart @cart_id";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] {user.IdUser});
        }
        #endregion

        #region 5. Check Cart
        public bool checkExistCart(DTO_User user)
        {
            string statement = "usp_CheckExistCart @cart_id";
            int count = (Int32)DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] { user.IdUser });
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 6. Delete Cart
        public void deleteCart(DTO_User user)
        {
            string statement = "usp_DeleteCart @cart_id";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { user.IdUser });
        }
        #endregion
    }
}
