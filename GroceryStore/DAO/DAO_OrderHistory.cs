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

            string statement = "INSERT INTO OrderHistory (idUser, price, amount, paymethod, status, paydate) VALUES ( @idUser , @price , @amount , @paymethod , @status , @paydate )";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { user.IdUser, orderHistory.price, orderHistory.amount, orderHistory.paymethod, orderHistory.status, DateTime.Parse(orderHistory.paydate) });
        }
        #endregion

        #region 2. show all history order
        public DataTable showAll(DTO_User user=null)
        {
            if(user == null)
            {
                string statement = "SELECT id as 'ID', price as 'Giá', amount as 'Số lượng', paymethod as 'Phương thức thanh toán', status as 'Trạng thái', paydate as 'Ngày thanh toán' FROM OrderHistory";
                return DataProvider.Instance.ExecuteQuery(statement);
            }
            else
            {
                string statement = "SELECT id as 'ID', price as 'Giá', amount as 'Số lượng', paymethod as 'Phương thức thanh toán', status as 'Trạng thái', paydate as 'Ngày thanh toán' FROM OrderHistory WHERE idUser = @idUser";
                return DataProvider.Instance.ExecuteQuery(statement, new object[] { user.IdUser});
            }
        }
        #endregion

        #region  3. get most recent 
        public DataTable getRecentOrder()
        {
            string statement = "SELECT TOP 5 id as 'ID', idUser as 'Mã nhân viên', paydate as 'Ngày thanh toán', price as 'Giá', status as 'Trạng thái' FROM OrderHistory ORDER BY paydate";
            return DataProvider.Instance.ExecuteQuery(statement);
        }
        #endregion

        #region
        public double getTurnover()
        {
            string statement = "EXEC showTurnover";
            return DataProvider.Instance.ExecuteStoredProcedureScalar(statement);
        }
        #endregion
    }
}
