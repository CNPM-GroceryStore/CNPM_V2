using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_OrderHistory
    {
        #region 1.add history order
        public void insertOrderHistory(DTO_Staff staff, DTO_OrderHistory orderHistory)
        {

            string statement = "insertOrderHistory @idStaff, @price, @amount, @paymethod, @status, @paydate";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { staff.IdStaff, orderHistory.price, orderHistory.amount, orderHistory.paymethod, orderHistory.status, orderHistory.paydate });
        }
        #endregion

        #region 2. show all history order
        public DataTable showAll(DTO_Staff staff=null)
        {
            if(staff == null)
            {
                string statement = "showAllHistoryOrderNoUser";
                return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
            }
            else
            {
                string statement = "showAllHistoryOrder @idStaff";
                return DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { staff.IdStaff });
            }
        }
        #endregion

        #region  3. get most recent 
        public DataTable getRecentOrder()
        {
            string statement = "getRecentOrder";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
        }
        #endregion

        #region 4.get turnover
        public double getTurnover()
        {
            string statement = "showTurnover";
            return DataProvider.Instance.ExecuteStoredProcedureScalar(statement);
        }
        #endregion

        public int getTurnoverByDate(DateTime date)
        {
            string statement = "getTurnoverByDate @date";
            return (int)DataProvider.Instance.ExecuteStoredProcedureScalar(statement, new object[] {date});
        }

        #region 6. Get orders in date
        public DataTable getOrdersInDate()
        {
            string statement = "getOrdersInDate";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
        }
        #endregion
    }
}
