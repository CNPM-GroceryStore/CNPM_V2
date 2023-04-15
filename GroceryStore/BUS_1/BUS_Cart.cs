using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Cart
    {

        DAO_Cart cart = new DAO_Cart();

        #region 1. Create Cart for user
        public void createCart(DTO_User user)
        {
            cart.createCart(user);
        }
        #endregion

        #region 2. Add product
        public void addProductInCart(DTO_User user, DTO_ProductCart productCart)
        {
            cart.insertProductIntoCart(user, productCart);
        }
        #endregion

        #region 3. Delete products
        public void deleteProductFromCart(DTO_User user, DTO_ProductCart productCart)
        {
            cart.deleteProductFromCart(user, productCart);
        }
        #endregion

        #region 4. Show products in cart
        public List<DTO_ProductCart> getProducts(DTO_User user)
        {
            List<DTO_ProductCart> products = new List<DTO_ProductCart>();
            foreach (DataRow row in cart.getAllProductInCart(user).Rows)
            {
                DTO_ProductCart productCard = new DTO_ProductCart(row[0].ToString(), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]));
                products.Add(productCard);

            }
            return products;
        }
        #endregion

        #region 5. Update number of products
        public void updateProductFromCart(DTO_User user, DTO_ProductCart productCart)
        {
            cart.updateProductFromCart(user, productCart);
        }
        #endregion

        #region 6. Check exist Cart
        public bool checkExistCart(DTO_User user)
        {
            return cart.checkExistCart(user);
        }
        #endregion

        #region 7. Delete cart
        public void deleteCart(DTO_User user)
        {
            cart.deleteCart(user);
        }
        #endregion
    }
}
