using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_1
{
    public class BUS_OrderHistory
    {
        DAO_OrderHistory orderHistory = new DAO_OrderHistory();

        #region 1. Insert Order History
        public void insertOrderHistory(DTO_Staff staff, DTO_OrderHistory order)
        {
            orderHistory.insertOrderHistory(staff, order);
        }
        #endregion

        #region 2. Show all OrderHistory
        public List<DTO_OrderHistory> showALl(DTO_Staff staff=null)
        {
            List<DTO_OrderHistory> orders = new List<DTO_OrderHistory>();
            foreach (DataRow row in orderHistory.showAll(staff).Rows)
            {
                DTO_OrderHistory productCard = new DTO_OrderHistory(row[0].ToString(), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]), row[3].ToString(), row[4].ToString(), row[5].ToString());
                orders.Add(productCard);

            }
            return orders;
        }
        #endregion

        #region 3. get 5 most recent order
        public DataTable getRecentOrder()
        {
            return orderHistory.getRecentOrder();
        }
        #endregion

        #region
        public double getTurnover()
        {
            return orderHistory.getTurnover();
        }
        #endregion
    }
}
