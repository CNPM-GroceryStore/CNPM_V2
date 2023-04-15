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
            string statement = "EXECUTE loadCart @idUser";
            return DataProvider.Instance.ExecuteQuery(statement, new object[] { user.IdUser });

        }
        #endregion

        #region 2. Add product into cart
        public void insertProductIntoCart(DTO_User user, DTO_ProductCart productCard)
        {
            string statement = "INSERT INTO cart_item (item_id, cart_id, item_name, item_price, quantity) VALUES ( @item_id , @idUser , @nameProduct , @priceProduct , @quantity )";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] {productCard.ID, user.IdUser, productCard.Name, productCard.Price, productCard.Quantity });
        }
        #endregion

        #region 2. Delete product from Cart
        public void deleteProductFromCart(DTO_User user, DTO_ProductCart productCard)
        {
            string statement = "DELETE FROM cart_item WHERE item_id = @item_id and cart_id = @id";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { productCard.ID, user.IdUser});
        }
        #endregion

        #region 3. update product from Cart
        public void updateProductFromCart(DTO_User user, DTO_ProductCart productCard)
        {
            string statement = "UPDATE cart_item SET quantity = @quantity WHERE cart_id = @id and item_id = @item_id";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { productCard.Quantity, user.IdUser, productCard.ID}) ;
        }
        #endregion

        #region 4. Create cart for user
        public void createCart(DTO_User user)
        {
            string statement = "INSERT INTO Cart VALUES ( @id )";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] {user.IdUser});
        }
        #endregion

        #region 5. Check Cart
        public bool checkExistCart(DTO_User user)
        {
            string statement = "SELECT COUNT(idUser) FROM Cart WHERE idUser = @id";
            int count = (Int32)DataProvider.Instance.ExecuteScalar(statement, new object[] { user.IdUser });
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
            string statement = "DELETE FROM cart_item WHERE cart_id = @id";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { user.IdUser });
        }
        #endregion
    }
}
