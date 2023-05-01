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
        public void insertOrderHistory(DTO_User user, DTO_OrderHistory order)
        {
            orderHistory.insertOrderHistory(user, order);
        }
        #endregion

        #region 2. Show all OrderHistory
        public List<DTO_OrderHistory> showALl(DTO_User user=null)
        {
            List<DTO_OrderHistory> orders = new List<DTO_OrderHistory>();
            foreach (DataRow row in orderHistory.showAll(user).Rows)
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

        public DataTable getDataTurnoverOfMonth()
        {
            DataTable data = new DataTable();
            data.Columns.Add("Date", typeof(int));
            data.Columns.Add("Turnover", typeof(int));
            int[] month_30 = { 4, 6, 9, 11 };
            int lastDate = 31;
            int currMonth = int.Parse(DateTime.Now.Month.ToString());
            if(Array.IndexOf(month_30, currMonth) > 0)
            {
                lastDate = 30;
            }
            else if(currMonth == 2 && DateTime.IsLeapYear(DateTime.Now.Year))
            {
                lastDate = 29;
            }
            else if (currMonth == 2)
            {
                lastDate = 38;
            }
            for(int i = 1; i < lastDate; i++)
            {
                DateTime currTime = DateTime.Parse(DateTime.Now.Month + "/" + i + "/" + DateTime.Now.Year);
                data.Rows.Add(i, orderHistory.getTurnoverByDate(currTime));
            }
            return data;
        }
    }
}
