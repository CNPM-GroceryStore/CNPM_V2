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

        #region 1. Create Cart for staff
        public void createCart(DTO_Staff staff)
        {
            cart.createCart(staff);
        }
        #endregion

        #region 2. Add product
        public void addProductInCart(DTO_Staff staff, DTO_ProductCart productCart)
        {
            cart.insertProductIntoCart(staff, productCart);
        }
        #endregion

        #region 3. Delete products
        public void deleteProductFromCart(DTO_Staff staff, DTO_ProductCart productCart)
        {
            cart.deleteProductFromCart(staff, productCart);
        }
        #endregion

        #region 4. Show products in cart
        public List<DTO_ProductCart> getProducts(DTO_Staff staff)
        {
            List<DTO_ProductCart> products = new List<DTO_ProductCart>();
            foreach (DataRow row in cart.getAllProductInCart(staff).Rows)
            {
                DTO_ProductCart productCard = new DTO_ProductCart(row[0].ToString(), row[1].ToString(), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]));
                products.Add(productCard);

            }
            return products;
        }
        #endregion

        #region 5. Update number of products
        public void updateProductFromCart(DTO_Staff staff, DTO_ProductCart productCart)
        {
            cart.updateProductFromCart(staff, productCart);
        }
        #endregion

        #region 6. Check exist Cart
        public bool checkExistCart(DTO_Staff staff)
        {
            return cart.checkExistCart(staff);
        }
        #endregion

        #region 7. Delete cart
        public void deleteCart(DTO_Staff staff)
        {
            cart.deleteCart(staff);
        }
        #endregion
    }
}
