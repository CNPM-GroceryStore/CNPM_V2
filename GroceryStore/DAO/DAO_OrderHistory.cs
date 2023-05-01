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
        public void insertOrderHistory(DTO_User user, DTO_OrderHistory orderHistory)
        {

            string statement = "insertOrderHistory @idUser, @price, @amount, @paymethod, @status, @paydate";
            DataProvider.Instance.ExecuteStoredProcedure(statement, new object[] { user.IdUser, orderHistory.price, orderHistory.amount, orderHistory.paymethod, orderHistory.status, orderHistory.paydate });
        }
        #endregion

        #region 2. show all history order
        public DataTable showAll(DTO_User user=null)
        {
            if(user == null)
            {
                string statement = "showAllHistoryOrderNoUser";
                return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
            }
            else
            {
                string statement = "showAllHistoryOrder @idUser";
                return DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { user.IdUser });
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
    }
}
