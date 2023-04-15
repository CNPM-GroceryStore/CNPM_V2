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
        public void insertOrderHistory(DTO_User user, DTO_OrderHistory orderHistory)
        {

            string statement = "INSERT INTO OrderHistory (idUser, price, amount, paymethod, status, paydate) VALUES ( @idUser , @price , @amount , @paymethod , @status , @paydate )";
            DataProvider.Instance.ExecuteNonQuery(statement, new object[] { user.IdUser, orderHistory.price, orderHistory.amount, orderHistory.paymethod, orderHistory.status, orderHistory.paydate });
        }

        public DataTable showAll(DTO_User user)
        {
            string statement = "SELECT id, price, amount, paymethod, status, paydate FROM OrderHistory WHERE idUser = @idUser";
            return DataProvider.Instance.ExecuteQuery(statement, new object[] { user.IdUser});
        }
    }
}
