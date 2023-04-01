using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Cart
    {

        #region 1.Calculate bill
        public int calculateBill(DTO_Cart cart)
        {
            int sumMoney = 0;
            foreach(DTO_Product product in cart.Products.GetAll())
            {
                sumMoney += product.GiaSP;
            }
            return sumMoney;
        }
        #endregion

        #region 2. Add product
        public void addProduct(DTO_Cart cart, DTO_Product product)
        {
            cart.Products.Add(product);
        }
        #endregion

        #region 3. Delete products
        public void deleteProduct(DTO_Cart cart, DTO_Product product)
        {
            cart.Products.Remove(product);
        }
        #endregion


        #region 4. convert price from int to string

        public string convertPrice(int price)
        {
            return price + " đ";
        }
        #endregion
    }
}
