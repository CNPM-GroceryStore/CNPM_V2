using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ListMyVoucher
    {
        #region 1. Show all Voucher of User
        public DataTable showAllUserVouchers(String idUser)
        {
            string statement = "listMyVoucher @SoDienThoai";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { idUser });
        }
        #endregion
    }
}
