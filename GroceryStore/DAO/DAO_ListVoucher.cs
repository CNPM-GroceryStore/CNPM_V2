using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ListVoucher
    {
        #region 1. Show all voucher
        public DataTable showAllVouchers()
        {
            string statement = "showAllVouchers";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement);
        }
        #endregion

        #region 2. show vouchers by name
        public DataTable getVouchersByName(String name)
        {
            string statement = $"getVouchersByName";
            return DataProvider.Instance.ExecuteQuery(statement, new object[] { name });

        }
        #endregion

        #region 3. Show all MyVoucher
        public DataTable showAllMyVouchers(String idUser)
        {
            string statement = "listMyVoucher @SoDienThoai";
            return DataProvider.Instance.ExecuteStoredProcedureSelect(statement, new object[] { idUser });
        }
        #endregion
    }
}
